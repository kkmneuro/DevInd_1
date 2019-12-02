#include "ServerProtocolImpl.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "atltime.h"
#include "JSONHandler.h"

//#include <cpprest/http_client.h>
//#include <cpprest/filestream.h>
//
//using namespace utility;                    // Common utilities like string conversions
//using namespace web;                        // Common features like URIs.
//using namespace web::http;                  // Common HTTP functionality
//using namespace web::http::client;          // HTTP client features
//using namespace concurrency::streams;       // Asynchronous streams


ClientSession::ClientSession(unsigned int clientID,char* clientIp,unsigned short clientPort)
{
	m_clientID=clientID; 
	//m_clientIp=clientIp; 
	strcpy(m_clientIp, clientIp);
	m_clientPort=clientPort;

	m_continueReceiving=false;

	m_nState = READ_SIZE;
	m_recBufSize = 0;
	m_msgSize = 0;
	m_bHandShakeDone = false;

	m_LastRecvTime = CTime::GetCurrentTime();
	m_LastSendTime = CTime::GetCurrentTime();

	//InitializeCriticalSection(&m_csWebsocketHandle);

	//CreateWebsocketServerHandle();

	InitializeCriticalSection(&m_cs);
	InitializeCriticalSection(&m_csAccounts);
}

bool ClientSession::CreateWebsocketServerHandle()
{
	bool bSuccess = false;

	//EnterCriticalSection(&m_csWebsocketHandle);

	//HRESULT hr = WebSocketCreateServerHandle(NULL, 0, &m_hWebsocketHandle);

	//if (!FAILED(hr))
	//{
	//	bSuccess = true;
	//}

	//LeaveCriticalSection(&m_csWebsocketHandle);

	return bSuccess;
}

bool ClientSession::ParseHTTPHeaders(char *buff, int length, std::map<std::string, std::string>& parsedHeaders)
{
	bool bSuccess = false;

	//std::getline()

	return bSuccess;
}

bool ClientSession::PerformWebsocketHandshake(char *buff)
{
	bool bSuccess = false;

	return bSuccess;
}

ClientSession::~ClientSession()
{
	DeleteCriticalSection(&m_cs);
	DeleteCriticalSection(&m_csAccounts);
	//DeleteCriticalSection(&m_csWebsocketHandle);

	free(m_clientIp);
	//m_clientIp = NULL;
}

unsigned int ClientSession::GetClientId()
{
	return m_clientID;
}
char* ClientSession::GetClientIp()
{
	return m_clientIp;
}
unsigned short ClientSession::GetclientPort()
{
	return m_clientPort;
}

bool ClientSession::IsHandShakeDone()
{
	return m_bHandShakeDone;
}

void ClientSession::HandleBinaryRecdBuffer(char * buff, unsigned int size1, IServerProtocolEvents* pServerProtEvents)
{
	//int msgtype;

	//if (size1 > 0)
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleBinaryRecdBuffer:: %s", buff);
	//	void *pObject = JSONHandler::GetObjectFromJSON(buff, size1, msgtype);

	//	if (pObject)
	//	{
	//		
	//		pServerProtEvents->OnMsgRecv(m_clientID, pObject, msgtype);
	//	}
	//}
	////unsigned int sizeRead = 0;

	////while (sizeRead < size)
	////{
	////	if (m_nState == READ_SIZE)
	////	{
	////		if (size - sizeRead < sizeof(unsigned int))
	////		{
	////			// Copy it to buffer and wait.
	////			memcpy(m_recBuf, buff + sizeRead, size - sizeRead);
	////			m_nState = WAIT_FOR_SIZE_BLOCK;

	////			m_recBufSize += (size - sizeRead);
	////			sizeRead += (size - sizeRead);
	////		}		
	////		else
	////		{
	////			memcpy(&m_msgSize, buff + sizeRead, sizeof(unsigned int));
	////			memcpy(m_recBuf, buff + sizeRead, sizeof(unsigned int));

	////			sizeRead += sizeof(unsigned int);
	////			m_recBufSize += sizeof(unsigned int);

	////			m_nState = MSG_SIZE_READ;
	////		}
	////	}
	////	else if (m_nState == WAIT_FOR_SIZE_BLOCK)
	////	{
	////		memcpy(m_recBuf + m_recBufSize, buff + sizeRead, sizeof(unsigned int) - m_recBufSize);
	////		memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

	////		sizeRead += (sizeof(unsigned int) - m_recBufSize);
	////		m_recBufSize += (sizeof(unsigned int) - m_recBufSize);
	////		m_nState = MSG_SIZE_READ;
	////	}
	////	else if (m_nState == MSG_SIZE_READ)
	////	{
	////		if ((m_msgSize - sizeof(unsigned int)) > size - sizeRead)
	////		{
	////			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
	////			m_recBufSize += (size - sizeRead);
	////			sizeRead += (size - sizeRead);

	////			m_nState = PART_MSG_RECVD;
	////		}
	////		else
	////		{
	////			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - sizeof(unsigned int)));

	////			m_recBufSize += (m_msgSize - sizeof(unsigned int));
	////			sizeRead += (m_msgSize - sizeof(unsigned int));
	////			m_nState = MSG_READ_COMPLETE;
	////		}
	////	}
	////	else if (m_nState == PART_MSG_RECVD)
	////	{
	////		memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - m_recBufSize));
	////		sizeRead += (m_msgSize - m_recBufSize);
	////		m_recBufSize += (m_msgSize - m_recBufSize);

	////		m_nState = MSG_READ_COMPLETE;
	////	}

	////	if (m_nState == MSG_READ_COMPLETE)
	////	{
	////		char buffer[4096];
	////		memcpy(buffer, m_recBuf, sizeof(StructureHeader));
	////		pstructureHeader pHeader= (pstructureHeader)buffer;

	////		void* msg=GetMessageObject(pHeader->MessageType);

	////		if (msg)
	////		{
	////			memcpy(msg, m_recBuf, m_msgSize);	

	////			m_LastRecvTime = CTime::GetCurrentTime();

	////			// No need to pass Heartbeat to application layer
	////			if (pHeader->MessageType != HEARTBEAT)
	////			{
	////				pServerProtEvents->OnMsgRecv( m_clientID, msg, pHeader->MessageType );
	////			}
	////			else
	////			{
	////				free(msg);
	////			}
	////		}
	////		else
	////		{
	////			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Unable to allocate memory");
	////		}

	////		m_recBufSize = 0;
	////		m_msgSize = 0;

	////		m_nState = READ_SIZE;
	////		
	////	}
	////}
	////utility::stringstream_t ss1;
	////wstring str = CA2W(buff);
	////// wstring str1 = str.substr(1,str.size());
	////// wstring str2 = str1.substr(0,str1.size()-1);
	////// str2.erase(std::remove(str2.begin(),str2.end(),'\\'),str2.end());

	////ss1 << str;

	////json::value v1 = json::value::parse(ss1);

	////int size = v1.size();
	////if (size>-1)
	////{
	////	wstring uname = v1.at(L"username").as_string();
	////	wstring password = v1.at(U("password")).as_string();

	////	USES_CONVERSION;

	////	string loginid = W2A(uname.c_str());
	////	//string password1 = W2A(password.c_str());

	////	// Send back response
	////	json::value obj;
	////	obj[L"AccountNo"] = json::value::number(1001);
	////	obj[L"IsValid"] = json::value::string(U("VALID"));
	////	obj[L"Balance"] = json::value::number(100001.666);
	////	obj[L"Master"] = json::value::boolean(true);

	////	WEB_SOCKET_BUFFER buffer;

	////	std::string strTemp;
	////	strTemp = W2A(obj.to_string().c_str());

	////	buffer.Data.pbBuffer = (PBYTE)strTemp.c_str();
	////	buffer.Data.ulBufferLength = strTemp.length();

	////	HRESULT hr = WebSocketSend(m_hWebsocketHandle, WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE, &buffer, NULL);

	////	if (!FAILED(hr))
	////	{
	////		WEB_SOCKET_BUFFER buffers[2] = { 0 };
	////		ULONG bufferCount;
	////		ULONG bytesTransferred;
	////		WEB_SOCKET_BUFFER_TYPE bufferType;
	////		WEB_SOCKET_ACTION action;
	////		PVOID actionContext;

	////		do
	////		{
	////			// Initialize variables that change with every loop revolution.
	////			bufferCount = ARRAYSIZE(buffers);
	////			bytesTransferred = 0;

	////			// Get an action to process.
	////			hr = WebSocketGetAction(
	////				m_hWebsocketHandle,
	////				WEB_SOCKET_ALL_ACTION_QUEUE,
	////				buffers,
	////				&bufferCount,
	////				&action,
	////				&bufferType,
	////				NULL,
	////				&actionContext);
	////			if (FAILED(hr))
	////			{
	////				// If we cannot get an action, abort the handle but continue processing until all operations are completed.
	////				WebSocketAbortHandle(m_hWebsocketHandle);
	////			}

	////			switch (action)
	////			{
	////			case WEB_SOCKET_NO_ACTION:

	////				// No action to perform - just exit the loop.
	////				break;

	////			case WEB_SOCKET_SEND_TO_NETWORK_ACTION:

	////				//wprintf(L"Sending data to a network:\n");

	////				for (ULONG i = 0; i < bufferCount; i++)
	////				{
	////					//DumpData(buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);

	////					// Write data to a transport (in production application this may be a socket).
	////					pServerProtEvents->OnMsgRecv(m_clientID, buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
	////					bytesTransferred += buffers[i].Data.ulBufferLength;
	////				}
	////				break;


	////			case WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION:

	////				wprintf(L"Send operation completed\n");
	////				break;

	////			default:

	////				// This should never happen.
	////				assert(!"Invalid switch");
	////				hr = E_FAIL;
	////				//goto quit;
	////			}

	////			if (FAILED(hr))
	////			{
	////				// If we failed at some point processing actions, abort the handle but continue processing
	////				// until all operations are completed.
	////				WebSocketAbortHandle(m_hWebsocketHandle);
	////			}

	////			// Complete the action. If application performs asynchronous operation, the action has to be
	////			// completed after the async operation has finished. The 'actionContext' then has to be preserved
	////			// so the operation can complete properly.
	////			WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
	////		} while (action != WEB_SOCKET_NO_ACTION);

	////	}
	//	//		void* msg=GetMessageObject(pHeader->MessageType);

	//	//		if (msg)
	//	//		{
	//	//			memcpy(msg, m_recBuf, m_msgSize);	

	//	//			m_LastRecvTime = CTime::GetCurrentTime();

	//	//			// No need to pass Heartbeat to application layer
	//	//			if (pHeader->MessageType != HEARTBEAT)
	//	//			{
	//	//				pServerProtEvents->OnMsgRecv( m_clientID, msg, pHeader->MessageType );
	//	//			}
	//	//			else
	//	//			{
	//	//				free(msg);
	//	//			}
	//	//		}
	//	//		else
	//	//		{
	//	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Unable to allocate memory");
	//	//		}
	////}

}

void ClientSession::HandleRecdBuffer(char * buff, unsigned int size, IServerProtocolEvents* pServerProtEvents, char *httpResponse, int& ResponseSize)
{
//	AcquireLock(&m_cs);
//
//	EnterCriticalSection(&m_csWebsocketHandle);
//
//	if (!m_bHandShakeDone)
//	{
//		// Add Handshake
//		WEB_SOCKET_HTTP_HEADER header[6];
//		//header[0].pcName = new char[300];
//		//header[0].pcValue = new char[300];
//		//header[1].pcName = new char[300];
//		//header[1].pcValue = new char[300];
//		//header[2].pcName = new char[300];
//		//header[2].pcValue = new char[300];
//
//		header[3].pcName = new char[22];
//		header[3].pcValue = new char[300];
//		header[4].pcName = new char[18];
//		header[4].pcValue = new char[300];
//		header[5].pcName = new char[25];
//		header[5].pcValue = new char[300];
//
//		string strbuff(buff);
//
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: %s", strbuff.c_str());
//
//		//strbuff = strbuff.substr(strbuff.find("Host:") + 6, strbuff.length());
//		//string ip = strbuff.substr(0, strbuff.find("\r\n"));
//
//		//strbuff = strbuff.substr(strbuff.find("Connection:") + 12, strbuff.length());
//		//string connection = strbuff.substr(0, strbuff.find("\r\n"));
//
//		//strbuff = strbuff.substr(strbuff.find("Upgrade:") + 9, strbuff.length());
//
//		//string Upgrade = strbuff.substr(0, strbuff.find("\r\n"));
//
//		string ip = strbuff.substr(strbuff.find("Host:") + 6, strbuff.length());
//		ip = ip.substr(0, ip.find("\r\n"));
//
//		string connection = strbuff.substr(strbuff.find("Connection:") + 12, strbuff.length());
//		connection = connection.substr(0, connection.find("\r\n"));
//
//		string Upgrade = strbuff.substr(strbuff.find("Upgrade:") + 9, strbuff.length());
//
//		Upgrade = Upgrade.substr(0, Upgrade.find("\r\n"));
//
//
//		header[0].pcName = new char[5];
//		header[0].pcValue = new char[ip.length()];
//
//		strcpy(header[0].pcName, "Host");
//		header[0].ulNameLength = strlen(header[0].pcName);
//		strcpy(header[0].pcValue, ip.c_str());
//		header[0].ulValueLength = strlen(header[0].pcValue);
//
//		header[1].pcName = new char[11];
//		header[1].pcValue = new char[connection.length()];
//
//		strcpy(header[1].pcName, "Connection");
//		header[1].ulNameLength = strlen(header[1].pcName);
//		strcpy(header[1].pcValue, connection.c_str());
//		header[1].ulValueLength = strlen(header[1].pcValue);
//
//		header[2].pcName = new char[8];
//		header[2].pcValue = new char[Upgrade.length()];
//
//		strcpy(header[2].pcName, "Upgrade");
//		header[2].ulNameLength = strlen(header[2].pcName);
//		strcpy(header[2].pcValue, Upgrade.c_str());
//		header[2].ulValueLength = strlen(header[2].pcValue);
//
//		strcpy(header[3].pcName, "Sec-WebSocket-Version");
//		header[3].ulNameLength = strlen(header[3].pcName);
//		strcpy(header[3].pcValue, "13");
//		header[3].ulValueLength = strlen(header[3].pcValue);
//
//		char *pPos = strstr(buff, "Sec-WebSocket-Key:");
//		char *pPos1 = strstr(pPos, "\r\n");
//
//		strcpy(header[4].pcName, "Sec-WebSocket-Key");
//		header[4].ulNameLength = strlen(header[4].pcName);
//		//int len = pPos1 - pPos;
//		pPos += header[4].ulNameLength + 2;
//		*pPos1 = '\0';
//		strcpy(header[4].pcValue, pPos);
//		header[4].ulValueLength = strlen(header[4].pcValue);
//
//		strcpy(header[5].pcName, "Sec-WebSocket-Extensions");
//		header[5].ulNameLength = strlen(header[5].pcName);
//		strcpy(header[5].pcValue, "permessage-deflate; client_max_window_bits");
//		header[5].ulValueLength = strlen(header[5].pcValue);
//
//		ULONG serverAdditionalHeaderCount = 0;
//		WEB_SOCKET_HTTP_HEADER* serverAdditionalHeaders = NULL;
//
//
//		HRESULT hr = WebSocketBeginServerHandshake(m_hWebsocketHandle,
//			NULL,
//			NULL,
//			0,
//			header,
//			6,
//			&serverAdditionalHeaders,
//			&serverAdditionalHeaderCount);
//
//		if (!FAILED(hr))
//		{
//			strcpy(httpResponse, "HTTP/1.1 101 Switching Protocols\r\n");
//
//			ResponseSize = strlen(httpResponse);
//
//				// Now add Additional headers
//			for (int i = 0; i < serverAdditionalHeaderCount; i++)
//			{
//				char szTemp[500];
//				memset(szTemp, 0, sizeof(szTemp));
//
//				memcpy(szTemp, serverAdditionalHeaders[i].pcName, serverAdditionalHeaders[i].ulNameLength);
//				szTemp[serverAdditionalHeaders[i].ulNameLength] = ':';
//				szTemp[serverAdditionalHeaders[i].ulNameLength + 1] = ' ';
//				memcpy(szTemp + serverAdditionalHeaders[i].ulNameLength + 2, serverAdditionalHeaders[i].pcValue, serverAdditionalHeaders[i].ulValueLength);
//				strcat(szTemp, "\r\n");
//
//				strcat(httpResponse, szTemp);
//				ResponseSize += serverAdditionalHeaders[i].ulNameLength + serverAdditionalHeaders[i].ulValueLength + 4;
//			}
//
//			memcpy(httpResponse + ResponseSize, "\r\n", 2);
//			ResponseSize += 2;
//
//			WebSocketEndServerHandshake(m_hWebsocketHandle);
//
//			m_bHandShakeDone = true;
//		}
//	}
//	else
//	{
//		// Parse Rest of the message
//		HRESULT hr = WebSocketReceive(m_hWebsocketHandle, NULL, NULL);
//
//		if (!FAILED(hr))
//		{
//			WEB_SOCKET_BUFFER buffers[2] = { 0 };
//			ULONG bufferCount;
//			ULONG bytesTransferred;
//			WEB_SOCKET_BUFFER_TYPE bufferType;
//			WEB_SOCKET_ACTION action;
//			PVOID actionContext;
//
//			do
//			{
//				// Initialize variables that change with every loop revolution.
//				bufferCount = ARRAYSIZE(buffers);
//				bytesTransferred = 0;
//
//				// Get an action to process.
//				hr = WebSocketGetAction(
//					m_hWebsocketHandle,
//					WEB_SOCKET_RECEIVE_ACTION_QUEUE,
//					buffers,
//					&bufferCount,
//					&action,
//					&bufferType,
//					NULL,
//					&actionContext);
//				if (FAILED(hr))
//				{
//					// If we cannot get an action, abort the handle but continue processing until all operations are completed.
//					WebSocketAbortHandle(m_hWebsocketHandle);
//				}
//
//				switch (action)
//				{
//				case WEB_SOCKET_NO_ACTION:
//
//					// No action to perform - just exit the loop.
//					break;
//
//				case WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION:
//					memcpy(buffers[0].Data.pbBuffer, buff, size);
//					buffers[0].Data.ulBufferLength = size;
//					bytesTransferred = size;
//					break;
//
//				case WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION:
//					buffers[0].Data.pbBuffer[buffers[0].Data.ulBufferLength] = '\0';
//					HandleBinaryRecdBuffer((char *)buffers[0].Data.pbBuffer, buffers[0].Data.ulBufferLength, pServerProtEvents);
//					break;
//
//				default:
//
//					// This should never happen.
////					assert(!"Invalid switch");
//					hr = E_FAIL;
//				}
//
//				if (FAILED(hr))
//				{
//					// If we failed at some point processing actions, abort the handle but continue processing
//					// until all operations are completed.
//					WebSocketAbortHandle(m_hWebsocketHandle);
//				}
//
//				// Complete the action. If application performs asynchronous operation, the action has to be
//				// completed after the async operation has finished. The 'actionContext' then has to be preserved
//				// so the operation can complete properly.
//				WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
//			} while (action != WEB_SOCKET_NO_ACTION);
//
//		}
//
//
//	}
//
//	LeaveCriticalSection(&m_csWebsocketHandle);
//
//	ReleaseLock(&m_cs);
}

int ClientSession::CheckHeartbeat()
{
	int nSuccess = 0;

	EnterCriticalSection(&m_cs);

	CTime tm = CTime::GetCurrentTime();

	CTimeSpan ts = tm - m_LastRecvTime;

	if (ts.GetTotalSeconds() > 90)
	{
		// Disconnect
		nSuccess = -1;
	}

	/*ts = tm - m_LastSendTime;

	if (ts.GetTotalSeconds() > 5)
	{
		nSuccess = 1;
	}*/

	LeaveCriticalSection(&m_cs);

	return nSuccess;
}

void ClientSession::AddAccount(IAccount *pAcc)
{
	EnterCriticalSection(&m_csAccounts);

	m_lstAccounts.push_back(pAcc);

	LeaveCriticalSection(&m_csAccounts);
}

std::list<IAccount *>::iterator ClientSession::RemoveAccount(IAccount *pAcc, std::list<IAccount *>::iterator& iter)
{
	EnterCriticalSection(&m_csAccounts);

	iter = m_lstAccounts.erase(iter);

	LeaveCriticalSection(&m_csAccounts);

	return iter;
}
void ClientSession::SetUserName(char *pszUserName)
{
	m_strUserName = pszUserName;
}

const char *ClientSession::GetUserName()
{
	return m_strUserName.c_str();
}


	
ClientSessionMgr::ClientSessionMgr(IServerProtocol *pProtocol)
{
	///m_connectionMgr=connectionMgr;
	m_pServerProtocol = pProtocol;
	InitializeCriticalSection(&CS_CLIENT_SESSION_MAP);
	InitializeCriticalSection(&CS_UNAME_SESSION_MAP);
	m_bShutdown = false;

	DWORD dwThreadID = 0;
	// Create thread to review all connections
	m_HandleReviewThread = CreateThread(NULL,
										0,
										(LPTHREAD_START_ROUTINE)&ClientSessionMgr::ConnectionReviewer,
										this,
										0,
										&dwThreadID);
}

ClientSessionMgr::~ClientSessionMgr()
{
	m_bShutdown = true;

	// Wait for connectionReviewer thread to close
	WaitForSingleObject(m_HandleReviewThread, 5000);

	map<unsigned int,IClientSession*>::iterator it;
	for( it = m_clientSessionMap.begin() ; it != m_clientSessionMap.end() ; it++ )
	{
		delete it->second;
		it->second = NULL;
	}
	m_clientSessionMap.clear();
	DeleteCriticalSection(&CS_CLIENT_SESSION_MAP);
}

bool ClientSessionMgr::UpdateSendTime(unsigned int clientID)
{
	bool bSuccess = false;

	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);

	map<unsigned int,IClientSession*>::iterator iter = m_clientSessionMap.find(clientID);

	if (iter != m_clientSessionMap.end())
	{
		// Update the send time
		ClientSession *pSession = (ClientSession *)(*iter).second;

		if (pSession)
		{
			pSession->m_LastSendTime = CTime::GetCurrentTime();
		}
	}

	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);

	return bSuccess;
}

void ClientSessionMgr::Add(unsigned int clientId, char* clientIp, unsigned short clientPort)
{
	IClientSession* clientSession = new ClientSession(clientId,clientIp,clientPort);
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	pair<unsigned int,IClientSession*> pr(clientSession->GetClientId(),clientSession);
	m_clientSessionMap.insert(pr);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::AcquireSessionLock()
{
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	AcquireLock(&CS_UNAME_SESSION_MAP);
}

void ClientSessionMgr::ReleaseSessionLock()
{
	ReleaseLock(&CS_UNAME_SESSION_MAP);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}


void ClientSessionMgr::AddUserName(unsigned int clientId, std::string strUserName)
{
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	AcquireLock(&CS_UNAME_SESSION_MAP);

	std::map<unsigned int,IClientSession*>::iterator iter = m_clientSessionMap.find(clientId);

	if (iter != m_clientSessionMap.end())
	{
		IClientSession *pSession = (*iter).second;;

		if (pSession)
		{
			std::map<std::string,std::list<unsigned int>>::iterator iter1 = m_mapUserNameClientSession.find(strUserName);

			if (iter1 != m_mapUserNameClientSession.end())
			{
				std::list<unsigned int>& lstSessions = (*iter1).second;

				lstSessions.push_back(pSession->GetClientId());
			}
			else
			{
				std::list<unsigned int> lstSession;

				lstSession.push_back(pSession->GetClientId());
				std::pair<std::string,std::list<unsigned int>> pr(strUserName, lstSession);
				m_mapUserNameClientSession.insert(pr);
			}
		}
	}

	ReleaseLock(&CS_UNAME_SESSION_MAP);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::Remove(unsigned int clientId)
{
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	AcquireLock(&CS_UNAME_SESSION_MAP);

	std::string strUserName;

	map<unsigned int,IClientSession*>::iterator iter= m_clientSessionMap.find(clientId);
	if(iter!=m_clientSessionMap.end())
	{
		IClientSession* pSession = (*iter).second;

		if (pSession)
		{
			strUserName = pSession->GetUserName();

			map<std::string,std::list<unsigned int>>::iterator iter1 = m_mapUserNameClientSession.find(strUserName);

			if (iter1 != m_mapUserNameClientSession.end())
			{
				std::list<unsigned int>& lstSession = (*iter1).second;

				lstSession.remove(clientId);

				if (lstSession.empty())
				{
					m_mapUserNameClientSession.erase(iter1);
				}
			}

			// Delete the Session
			delete pSession;
		}

		m_clientSessionMap.erase(iter);
	}

	ReleaseLock(&CS_UNAME_SESSION_MAP);
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

std::list<unsigned int>* ClientSessionMgr::GetClientSessionList(std::string strUserName)
{
	map<std::string,std::list<unsigned int>>::iterator iter = m_mapUserNameClientSession.find(strUserName);

	std::list<unsigned int> *pList = NULL;

	if (iter != m_mapUserNameClientSession.end())
	{
		pList = &(*iter).second;
	}

	return pList;
}

IClientSession* ClientSessionMgr::GetClientSession(unsigned int clientId)
{
	IClientSession* clientSession=NULL;
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	map<unsigned int,IClientSession*>::iterator iter= m_clientSessionMap.find(clientId);
	if(iter!=m_clientSessionMap.end())
	{
		clientSession = m_clientSessionMap[clientId];
	}
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
	return clientSession;
}

void ClientSessionMgr::DisconnectClient(unsigned int clientID)
{
	m_pServerProtocol->DisconnectClient(clientID);
}

bool ClientSessionMgr::IsShutdown()
{
	return m_bShutdown;
}

DWORD ClientSessionMgr::ConnectionReviewer (LPVOID lpdwThreadParam )
{
	ClientSessionMgr *pMgr = (ClientSessionMgr *)lpdwThreadParam;

	//while (1)
	//{
	//	pMgr->AcquireCS();

	//	map<unsigned int,IClientSession*> mapClientSession = pMgr->GetClientSessionMap();

	//	map<unsigned int,IClientSession*>::iterator iter = mapClientSession.begin();

	//	while (iter != mapClientSession.end())
	//	{
	//		IClientSession *pSession = iter->second;

	//		if (pSession)
	//		{
	//			if (pSession->CheckHeartbeat() == -1)
	//			{
	//				pMgr->DisconnectClient(pSession->GetClientId());
	//			}
	//		}

	//		iter++;
	//	}

	//	pMgr->ReleaseCS();

	//	Sleep(30000);
	//}

	return 0L;
}

map<unsigned int,IClientSession*>& ClientSessionMgr::GetClientSessionMap()
{
	return m_clientSessionMap;
}

void ClientSessionMgr::AcquireCS()
{
	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);
}

void ClientSessionMgr::ReleaseCS()
{
	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);
}

void ClientSession::SetGroupID(int nGroup)
{
	m_nGroupID = nGroup;
}

int ClientSession::GetGroupID()
{
	return m_nGroupID;
}

bool ClientSession::WebsocketSend(void *pMsg, unsigned int MsgType, Socket *pServerSocket)
{
	bool bSuccess = true;

	//WEB_SOCKET_BUFFER buffer;

	//std::string JSONString;
	//unsigned int MsgSize = 0;

	//JSONHandler::GetJSONFromObject(pMsg, MsgType, JSONString, MsgSize);
	//
	////std::string strTemp;
	////strTemp = W2A(obj.to_string().c_str());

	//EnterCriticalSection(&m_csWebsocketHandle);

	//buffer.Data.pbBuffer = (PBYTE)JSONString.c_str();
	//buffer.Data.ulBufferLength = JSONString.length();

	//HRESULT hr = WebSocketSend(m_hWebsocketHandle, WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE, &buffer, NULL);

	//if (!FAILED(hr))
	//{
	//	WEB_SOCKET_BUFFER buffers[2] = { 0 };
	//	ULONG bufferCount;
	//	ULONG bytesTransferred;
	//	WEB_SOCKET_BUFFER_TYPE bufferType;
	//	WEB_SOCKET_ACTION action;
	//	PVOID actionContext;

	//	do
	//	{
	//		// Initialize variables that change with every loop revolution.
	//		bufferCount = ARRAYSIZE(buffers);
	//		bytesTransferred = 0;

	//		// Get an action to process.
	//		hr = WebSocketGetAction(
	//			m_hWebsocketHandle,
	//			WEB_SOCKET_ALL_ACTION_QUEUE,
	//			buffers,
	//			&bufferCount,
	//			&action,
	//			&bufferType,
	//			NULL,
	//			&actionContext);
	//		if (FAILED(hr))
	//		{
	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: WebSocketGetAction Failed to Send Web Socket");
	//			// If we cannot get an action, abort the handle but continue processing until all operations are completed.
	//			WebSocketAbortHandle(m_hWebsocketHandle);
	//		}

	//		switch (action)
	//		{
	//		case WEB_SOCKET_NO_ACTION:

	//			// No action to perform - just exit the loop.
	//			break;

	//		case WEB_SOCKET_SEND_TO_NETWORK_ACTION:

	//			//wprintf(L"Sending data to a network:\n");

	//			for (ULONG i = 0; i < bufferCount; i++)
	//			{
	//				char temp[8192];
	//				memcpy(temp, buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
	//				temp[buffers[i].Data.ulBufferLength] = '\0';
	//				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Sending Websocket Length = %d, %d=%s", buffers[i].Data.ulBufferLength, i, temp);

	//				pServerSocket->Send(m_clientID, (char *)buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
	//				bytesTransferred += buffers[i].Data.ulBufferLength;
	//			}
	//			break;


	//		case WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION:

	//			wprintf(L"Send operation completed\n");
	//			break;

	//		default:

	//			// This should never happen.
	//			//assert(!"Invalid switch");
	//			hr = E_FAIL;
	//			//goto quit;
	//		}

	//		if (FAILED(hr))
	//		{
	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Failed to Send Web Socket 11");
	//			// If we failed at some point processing actions, abort the handle but continue processing
	//			// until all operations are completed.
	//			WebSocketAbortHandle(m_hWebsocketHandle);
	//		}

	//		// Complete the action. If application performs asynchronous operation, the action has to be
	//		// completed after the async operation has finished. The 'actionContext' then has to be preserved
	//		// so the operation can complete properly.
	//		WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
	//		} while (action != WEB_SOCKET_NO_ACTION);

	//	}
	//else
	//{
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Failed to Send Web Socket");
	//}

	//LeaveCriticalSection(&m_csWebsocketHandle);
	return bSuccess;
}