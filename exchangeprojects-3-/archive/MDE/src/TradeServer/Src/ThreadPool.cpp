#include "ThreadPool.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"

volatile long ThreadPool::m_lInstance = 0;

unsigned int __stdcall ThreadPool::ThreadProc(void* arg)
{
	DWORD					dwWait;
	ThreadPool*				pool;
  	HANDLE					hThread = GetCurrentThread();
	DWORD					dwThreadId = GetCurrentThreadId();
	HANDLE					hWaits[2];
	IRequest*				runObject;
	bool					bAutoDelete;

	//ASSERT(pParam != NULL);
	if(NULL == arg)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::ThreadProc, Arguement is NULL");
		return -1;
	}

	pool = static_cast<ThreadPool*>(arg);
	hWaits[0] = pool->GetWaitHandle(dwThreadId);
	hWaits[1] = pool->GetShutdownHandle();

	loop_here:

	dwWait = WaitForMultipleObjects(2, hWaits, FALSE, INFINITE);

	if(dwWait - WAIT_OBJECT_0 == 0)
	{
		if(pool->CheckThreadStop())
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::ThreadProc, Thread stopped");
			return 0;
		}

		if(pool->GetRunObject(&runObject))
		{	
			pool->BusyNotify(dwThreadId);
			bAutoDelete = runObject->AutoDelete();
			runObject->Run();
			if(bAutoDelete)
			{
				char szMessage[256];
				_stprintf(szMessage, _T("Deleting Run Object of thread , handle = %d, id = %d\n"), 
				 hThread, dwThreadId);

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "ThreadPool::ThreadProc, %s", szMessage);
				delete runObject;
			}
			else
			{
				char szMessage[256];
				_stprintf(szMessage, _T("Not Deleted Run Object of thread , handle = %d, id = %d\n"), 
				 hThread, dwThreadId);

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "ThreadPool::ThreadProc, %s", szMessage);
			}

			pool->FinishNotify(dwThreadId); 
		}
		goto loop_here;
	}
	return 0;
}

ThreadPool::ThreadPool(int nPoolSize, bool bCreateNow, int nWaitTimeForThreadsToComplete)
{
	m_state = Destroyed;
	m_nPoolSize = nPoolSize;
	m_nWaitForThreadsToDieMS = nWaitTimeForThreadsToComplete;

	InitializeCriticalSection(&CS_REQUEST_OBJECT_LIST); 
	InitializeCriticalSection(&CS_THREAD_MAP); 

	if(bCreateNow)
	{
		if(!Create())
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::ThreadPool, Not able to create");
			//throw 1;
		}
	}
}

bool ThreadPool::Create()
{
	if(m_state != Destroyed)
	{
		return false;
	}
	InterlockedIncrement(&ThreadPool::m_lInstance);
	HANDLE		hThread;
	DWORD		dwThreadId;
	ThreadData	threadData;
	TCHAR		szEvtName[30];
	UINT		uThreadId;	
	m_hNotifyShutdown = CreateEvent(NULL, TRUE, FALSE, NULL);
	//ASSERT(m_hNotifyShutdown != NULL);
	if(!m_hNotifyShutdown)
	{
		return false;
	}
	for(int nIndex = 0; nIndex < m_nPoolSize; nIndex++)
	{
		sprintf_s(szEvtName, "PID:%d IID:%d TDX:%d", GetCurrentProcessId(), ThreadPool::m_lInstance, nIndex /* thread index*/);
		hThread = (HANDLE)_beginthreadex(NULL, 0, ThreadPool::ThreadProc, this,CREATE_SUSPENDED, (unsigned int*)&uThreadId);
		//ASSERT(INVALID_HANDLE_VALUE != hThread);
		if(INVALID_HANDLE_VALUE == hThread)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::Create, Invalid hThread");

			return false;
		}

		dwThreadId = uThreadId;
		if(hThread)
		{
			threadData.bFree		= true;
			threadData.WaitHandle	= CreateEvent(NULL, TRUE, FALSE, szEvtName);
			threadData.hThread		= hThread;
			threadData.dwThreadId	= dwThreadId;
		
			m_threads.insert(ThreadMap::value_type(dwThreadId, threadData));		

			ResumeThread(hThread); 
		
			char szMessage[256];
			_stprintf(szMessage, _T("Thread created, handle = %d, id = %d\n"), 
					  hThread, dwThreadId);
		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::Create, hThread is NULL");

			return false;
		}
	}

	m_hRunEvent=CreateEvent(NULL,TRUE,FALSE,FALSE);
	m_hRunThread= (HANDLE)_beginthreadex(NULL, 0, ThreadPool::Run, this,NULL, NULL);
	//ASSERT(INVALID_HANDLE_VALUE != m_hRunThread);
	if(INVALID_HANDLE_VALUE == m_hRunThread)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::Create, Invalid m_hrunthread");
		return false;
	}

	m_state = Ready;

	return true;
}

ThreadPool::~ThreadPool()
{
	Destroy();
	ReleaseMemory();	
	DeleteCriticalSection(&CS_REQUEST_OBJECT_LIST);
	DeleteCriticalSection(&CS_THREAD_MAP);
}

void ThreadPool::ReleaseMemory()
{
	RequestObjectList::iterator requestIter;
	
	for(requestIter = m_requestObjectList.begin(); requestIter != m_requestObjectList.end(); requestIter++) 
	{
		IRequest* requestData = (*requestIter);
		delete requestData;
	}

	m_requestObjectList.clear();
	m_threads.clear();
}

void ThreadPool::Destroy()
{
	if(m_state == Destroying || m_state == Destroyed)
	{
		return;
	}

	m_state = Destroying;
		
	//ASSERT(NULL != m_hNotifyShutdown);
	SetEvent(m_hNotifyShutdown);

	Sleep(2000); 

	if(GetWorkingThreadCount() > 0)
	{
		Sleep(m_nWaitForThreadsToDieMS);
	}
	
	ThreadMap::iterator iter;
	
	for(iter = m_threads.begin(); iter != m_threads.end(); iter++)
	{
		CloseHandle(iter->second.WaitHandle);
		CloseHandle(iter->second.hThread);
	}
	CloseHandle(m_hRunEvent);
	CloseHandle(m_hRunThread);
	CloseHandle(m_hNotifyShutdown);
	m_hNotifyShutdown = NULL;
	ReleaseMemory(); 
	InterlockedDecrement(&ThreadPool::m_lInstance);

	m_state = Destroyed;
}

int ThreadPool::GetPoolSize()
{
	return m_nPoolSize;
}

void ThreadPool::SetPoolSize(int nSize)
{
	//ASSERT(nSize > 0);
	if(nSize <= 0)
	{
		return;
	}

	m_nPoolSize = nSize;
}

HANDLE ThreadPool::GetShutdownHandle()
{
	return m_hNotifyShutdown;
}

bool ThreadPool::GetRunObject(IRequest** runObject)
{
	RequestObjectList::iterator	iter;
	AcquireLock(&CS_REQUEST_OBJECT_LIST);
	
	iter = m_requestObjectList.begin();
	if(iter != m_requestObjectList.end())
	{
		*runObject = *iter;
		m_requestObjectList.pop_front(); 
		ReleaseLock(&CS_REQUEST_OBJECT_LIST);
		return true;	
	}
	else
	{
		ResetEvent(m_hRunEvent);
		ReleaseLock(&CS_REQUEST_OBJECT_LIST);
		return false;
	}
}

void ThreadPool::FinishNotify(DWORD dwThreadId)
{
	ThreadMap::iterator iter;
	
	AcquireLock(&CS_THREAD_MAP);

	iter = m_threads.find(dwThreadId);

	if(iter == m_threads.end())	
	{			
		ReleaseLock(&CS_THREAD_MAP);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::FinishNotify, No matching thread found.");
		//TRACE(_T("No matching thread found."));
		return;
	}
	else
	{	
		m_threads[dwThreadId].bFree = true;

		char szMessage[256];
		_stprintf(szMessage, _T("Thread free, thread id = %d\n"), dwThreadId);

		if(!m_requestObjectList.empty())
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ThreadPool::FinishNotify, m_requestObjectList is empty");

			ReleaseLock(&CS_THREAD_MAP);
			return;
		}		
		else
		{
			ReleaseLock(&CS_THREAD_MAP);
			ResetEvent(m_threads[dwThreadId].WaitHandle);
		}
	}	
}

void ThreadPool::BusyNotify(DWORD dwThreadId)
{
	ThreadMap::iterator iter;
	
	AcquireLock(&CS_THREAD_MAP);

	iter = m_threads.find(dwThreadId);

	if(iter == m_threads.end())	
	{
		ReleaseLock(&CS_THREAD_MAP);
	}
	else
	{		
		m_threads[dwThreadId].bFree = false;		

		char szMessage[256];
		_stprintf(szMessage, _T("Thread busy, thread id = %d\n"), dwThreadId);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_NORMAL, "ThreadPool::BusyNotify, %s", szMessage);

		ReleaseLock(&CS_THREAD_MAP);
	}	
}

unsigned int __stdcall ThreadPool::Run(void* arg)
{
	ThreadPool* pThis=(ThreadPool*)arg;
	while(WaitForSingleObject(pThis->m_hNotifyShutdown,0)==WAIT_TIMEOUT)
	{
		WaitForSingleObject(pThis->m_hRunEvent,INFINITE);
		ThreadMap::iterator iter;
		ThreadData threadData;
		AcquireLock(&pThis->CS_THREAD_MAP);
		for(iter = pThis->m_threads.begin(); iter != pThis->m_threads.end(); iter++)
		{
			threadData = (*iter).second;
			if(threadData.bFree)
			{
				pThis->m_threads[threadData.dwThreadId].bFree = false;			
				SetEvent(threadData.WaitHandle); 
				break;
			}
		}
		ReleaseLock(&pThis->CS_THREAD_MAP);
	}
	return 0;
}


bool ThreadPool::Run(IRequest* runObject, ThreadPriority priority)
{
	if(m_state == Destroying || m_state == Destroyed)
		return false;

	if(runObject == NULL)
		return false;

	runObject->pThreadPool = this; 
	AcquireLock(&CS_REQUEST_OBJECT_LIST);
	if(priority == Low)
	{
		m_requestObjectList.push_back(runObject);
	}
	else
	{
		m_requestObjectList.push_front(runObject);
	}
	SetEvent(m_hRunEvent);
	ReleaseLock(&CS_REQUEST_OBJECT_LIST);

	return true;
}

HANDLE ThreadPool::GetWaitHandle(DWORD dwThreadId)
{
	HANDLE hWait;
	ThreadMap::iterator iter;
	
	AcquireLock(&CS_THREAD_MAP);
	iter = m_threads.find(dwThreadId);
	
	if(iter == m_threads.end())	
	{
		ReleaseLock(&CS_THREAD_MAP);
		return NULL;
	}
	else
	{		
		hWait = m_threads[dwThreadId].WaitHandle;
		ReleaseLock(&CS_THREAD_MAP);
	}	

	return hWait;
}

bool ThreadPool::CheckThreadStop()
{
	return (m_state == Destroying || m_state == Destroyed);
}

 
int ThreadPool::GetWorkingThreadCount()
{
	ThreadMap::iterator iter;
	ThreadData threadData;
	int nCount = 0;

    for(iter = m_threads.begin(); iter != m_threads.end(); iter++) 
	{
		threadData = (*iter).second;

        if(!threadData.bFree) 
		{
			nCount++;
		}
	}

    return nCount;
}

PoolState ThreadPool::GetState()
{
	return m_state;
}