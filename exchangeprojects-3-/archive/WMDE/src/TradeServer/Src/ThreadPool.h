#pragma once
#include "ServerInterface.h"

#define POOL_SIZE		10

typedef struct
{
	bool				bFree;
	HANDLE				WaitHandle;
	HANDLE				hThread;
	DWORD				dwThreadId;
} ThreadData;

//class ThreadPool : public IThreadPool
//{
//private:
//	typedef map<DWORD, ThreadData, less<DWORD>, allocator<ThreadData> >		ThreadMap;
//	typedef list<IRequest*, allocator<IRequest*> >							RequestObjectList;
//	RequestObjectList														m_requestObjectList;
//	ThreadMap																m_threads;
//	int																		m_nPoolSize;
//	int																		m_nWaitForThreadsToDieMS; 
//	HANDLE																	m_hNotifyShutdown; 
//	volatile PoolState														m_state;
//	volatile static long													m_lInstance;
//	CRITICAL_SECTION														CS_REQUEST_OBJECT_LIST;
//	CRITICAL_SECTION														CS_THREAD_MAP;
//	HANDLE																	m_hRunEvent;
//	HANDLE																	m_hRunThread;
//	//IServerController*														m_serverController;
//
//
//	bool	GetRunObject(IRequest**); 
//	void	FinishNotify(DWORD dwThreadId);
//	void	BusyNotify(DWORD dwThreadId);
//	void	ReleaseMemory();
//	HANDLE	GetWaitHandle(DWORD dwThreadId);
//	HANDLE	GetShutdownHandle();
//	static unsigned int __stdcall ThreadProc(void* arg);
//	static unsigned int __stdcall Run(void* arg);
//
//public:
//	ThreadPool(int nPoolSize = POOL_SIZE, bool bCreateNow = true, int nWaitTimeForThreadsToComplete = 5000);
//	virtual ~ThreadPool();
//	bool	Create();	
//	void	Destroy();	
//	int		GetPoolSize();
//	void	SetPoolSize(int);
//	bool	Run(IRequest*, ThreadPriority priority = Low);
//	bool	CheckThreadStop();
//	int		GetWorkingThreadCount();
//	PoolState GetState();
//};
