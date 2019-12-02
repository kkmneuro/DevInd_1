#include "ServerProtocolImpl.h"
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include "atltime.h"
#include "JSONHandler.h"
#include <comdef.h>

#include <cpprest/http_client.h>
#include <cpprest/filestream.h>

#define PAYLOAD_LENGHT_BYTES			2
#define MASK_BIT_LENGTH					4
#define EXTENDED_PAYLOAD_LENGTH			2
#define EXTRA_EXTENDED_PAYLOAD_LENGTH	8
#define PAYLOAD_LENGTH_MASK				127
#define MASK_BIT						128
#define MASK_OPCODE      15

using namespace utility;                    // Common utilities like string conversions
using namespace web;                        // Common features like URIs.
using namespace web::http;                  // Common HTTP functionality
using namespace web::http::client;          // HTTP client features
using namespace concurrency::streams;       // Asynchronous streams
Socket *g_pServerSocket;

ClientSession::ClientSession(unsigned int clientID, char* clientIp, unsigned short clientPort)
{
	m_clientID = clientID;
	//m_clientIp=clientIp; 
	strcpy(m_clientIp, clientIp);
	m_clientPort = clientPort;
	sizeControlBlock = 0;

	m_continueReceiving = false;

	m_nState = READ_SIZE;
	m_recBufSize = 0;
	m_msgSize = 0;
	m_bHandShakeDone = false;

	m_LastRecvTime = CTime::GetCurrentTime();
	m_LastSendTime = CTime::GetCurrentTime();

	InitializeCriticalSection(&m_csWebsocketHandle);

	CreateWebsocketServerHandle();

	InitializeCriticalSection(&m_cs);
	InitializeCriticalSection(&m_csAccounts);
}

bool ClientSession::CreateWebsocketServerHandle()
{
	bool bSuccess = false;

	EnterCriticalSection(&m_csWebsocketHandle);

	HRESULT hr = WebSocketCreateServerHandle(NULL, 0, &m_hWebsocketHandle);

	if (!FAILED(hr))
	{
		bSuccess = true;
	}

	LeaveCriticalSection(&m_csWebsocketHandle);

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
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::~ClientSession:: Delete");
	DeleteCriticalSection(&m_cs);
	DeleteCriticalSection(&m_csAccounts);
	DeleteCriticalSection(&m_csWebsocketHandle);

	free(m_clientIp);
	WebSocketDeleteHandle(m_hWebsocketHandle);
	m_hWebsocketHandle = NULL;
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
	int msgtype;

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleBinaryRecdBuffer:: Enter");
	if (size1 > 0)
	{
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleBinaryRecdBuffer:: %s", buff);
		void *pObject = JSONHandler::GetObjectFromJSON(buff, size1, msgtype);

		if (pObject)
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleBinaryRecdBuffer:: %d", msgtype);
			pServerProtEvents->OnMsgRecv(m_clientID, pObject, msgtype);
		}
		else
		{
			pServerProtEvents->OnMsgRecv(m_clientID, NULL, 0);
		}
	}

	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleBinaryRecdBuffer:: Exit");
	//unsigned int sizeRead = 0;

	//while (sizeRead < size)
	//{
	//	if (m_nState == READ_SIZE)
	//	{
	//		if (size - sizeRead < sizeof(unsigned int))
	//		{
	//			// Copy it to buffer and wait.
	//			memcpy(m_recBuf, buff + sizeRead, size - sizeRead);
	//			m_nState = WAIT_FOR_SIZE_BLOCK;

	//			m_recBufSize += (size - sizeRead);
	//			sizeRead += (size - sizeRead);
	//		}		
	//		else
	//		{
	//			memcpy(&m_msgSize, buff + sizeRead, sizeof(unsigned int));
	//			memcpy(m_recBuf, buff + sizeRead, sizeof(unsigned int));

	//			sizeRead += sizeof(unsigned int);
	//			m_recBufSize += sizeof(unsigned int);

	//			m_nState = MSG_SIZE_READ;
	//		}
	//	}
	//	else if (m_nState == WAIT_FOR_SIZE_BLOCK)
	//	{
	//		memcpy(m_recBuf + m_recBufSize, buff + sizeRead, sizeof(unsigned int) - m_recBufSize);
	//		memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

	//		sizeRead += (sizeof(unsigned int) - m_recBufSize);
	//		m_recBufSize += (sizeof(unsigned int) - m_recBufSize);
	//		m_nState = MSG_SIZE_READ;
	//	}
	//	else if (m_nState == MSG_SIZE_READ)
	//	{
	//		if ((m_msgSize - sizeof(unsigned int)) > size - sizeRead)
	//		{
	//			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
	//			m_recBufSize += (size - sizeRead);
	//			sizeRead += (size - sizeRead);

	//			m_nState = PART_MSG_RECVD;
	//		}
	//		else
	//		{
	//			memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - sizeof(unsigned int)));

	//			m_recBufSize += (m_msgSize - sizeof(unsigned int));
	//			sizeRead += (m_msgSize - sizeof(unsigned int));
	//			m_nState = MSG_READ_COMPLETE;
	//		}
	//	}
	//	else if (m_nState == PART_MSG_RECVD)
	//	{
	//		memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize - m_recBufSize));
	//		sizeRead += (m_msgSize - m_recBufSize);
	//		m_recBufSize += (m_msgSize - m_recBufSize);

	//		m_nState = MSG_READ_COMPLETE;
	//	}

	//	if (m_nState == MSG_READ_COMPLETE)
	//	{
	//		char buffer[4096];
	//		memcpy(buffer, m_recBuf, sizeof(StructureHeader));
	//		pstructureHeader pHeader= (pstructureHeader)buffer;

	//		void* msg=GetMessageObject(pHeader->MessageType);

	//		if (msg)
	//		{
	//			memcpy(msg, m_recBuf, m_msgSize);	

	//			m_LastRecvTime = CTime::GetCurrentTime();

	//			// No need to pass Heartbeat to application layer
	//			if (pHeader->MessageType != HEARTBEAT)
	//			{
	//				pServerProtEvents->OnMsgRecv( m_clientID, msg, pHeader->MessageType );
	//			}
	//			else
	//			{
	//				free(msg);
	//			}
	//		}
	//		else
	//		{
	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Unable to allocate memory");
	//		}

	//		m_recBufSize = 0;
	//		m_msgSize = 0;

	//		m_nState = READ_SIZE;
	//		
	//	}
	//}
	//utility::stringstream_t ss1;
	//wstring str = CA2W(buff);
	//// wstring str1 = str.substr(1,str.size());
	//// wstring str2 = str1.substr(0,str1.size()-1);
	//// str2.erase(std::remove(str2.begin(),str2.end(),'\\'),str2.end());

	//ss1 << str;

	//json::value v1 = json::value::parse(ss1);

	//int size = v1.size();
	//if (size>-1)
	//{
	//	wstring uname = v1.at(L"username").as_string();
	//	wstring password = v1.at(U("password")).as_string();

	//	USES_CONVERSION;

	//	string loginid = W2A(uname.c_str());
	//	//string password1 = W2A(password.c_str());

	//	// Send back response
	//	json::value obj;
	//	obj[L"AccountNo"] = json::value::number(1001);
	//	obj[L"IsValid"] = json::value::string(U("VALID"));
	//	obj[L"Balance"] = json::value::number(100001.666);
	//	obj[L"Master"] = json::value::boolean(true);

	//	WEB_SOCKET_BUFFER buffer;

	//	std::string strTemp;
	//	strTemp = W2A(obj.to_string().c_str());

	//	buffer.Data.pbBuffer = (PBYTE)strTemp.c_str();
	//	buffer.Data.ulBufferLength = strTemp.length();

	//	HRESULT hr = WebSocketSend(m_hWebsocketHandle, WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE, &buffer, NULL);

	//	if (!FAILED(hr))
	//	{
	//		WEB_SOCKET_BUFFER buffers[2] = { 0 };
	//		ULONG bufferCount;
	//		ULONG bytesTransferred;
	//		WEB_SOCKET_BUFFER_TYPE bufferType;
	//		WEB_SOCKET_ACTION action;
	//		PVOID actionContext;

	//		do
	//		{
	//			// Initialize variables that change with every loop revolution.
	//			bufferCount = ARRAYSIZE(buffers);
	//			bytesTransferred = 0;

	//			// Get an action to process.
	//			hr = WebSocketGetAction(
	//				m_hWebsocketHandle,
	//				WEB_SOCKET_ALL_ACTION_QUEUE,
	//				buffers,
	//				&bufferCount,
	//				&action,
	//				&bufferType,
	//				NULL,
	//				&actionContext);
	//			if (FAILED(hr))
	//			{
	//				// If we cannot get an action, abort the handle but continue processing until all operations are completed.
	//				WebSocketAbortHandle(m_hWebsocketHandle);
	//			}

	//			switch (action)
	//			{
	//			case WEB_SOCKET_NO_ACTION:

	//				// No action to perform - just exit the loop.
	//				break;

	//			case WEB_SOCKET_SEND_TO_NETWORK_ACTION:

	//				//wprintf(L"Sending data to a network:\n");

	//				for (ULONG i = 0; i < bufferCount; i++)
	//				{
	//					//DumpData(buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);

	//					// Write data to a transport (in production application this may be a socket).
	//					pServerProtEvents->OnMsgRecv(m_clientID, buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
	//					bytesTransferred += buffers[i].Data.ulBufferLength;
	//				}
	//				break;


	//			case WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION:

	//				wprintf(L"Send operation completed\n");
	//				break;

	//			default:

	//				// This should never happen.
	//				assert(!"Invalid switch");
	//				hr = E_FAIL;
	//				//goto quit;
	//			}

	//			if (FAILED(hr))
	//			{
	//				// If we failed at some point processing actions, abort the handle but continue processing
	//				// until all operations are completed.
	//				WebSocketAbortHandle(m_hWebsocketHandle);
	//			}

	//			// Complete the action. If application performs asynchronous operation, the action has to be
	//			// completed after the async operation has finished. The 'actionContext' then has to be preserved
	//			// so the operation can complete properly.
	//			WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
	//		} while (action != WEB_SOCKET_NO_ACTION);

	//	}
	//		void* msg=GetMessageObject(pHeader->MessageType);

	//		if (msg)
	//		{
	//			memcpy(msg, m_recBuf, m_msgSize);	

	//			m_LastRecvTime = CTime::GetCurrentTime();

	//			// No need to pass Heartbeat to application layer
	//			if (pHeader->MessageType != HEARTBEAT)
	//			{
	//				pServerProtEvents->OnMsgRecv( m_clientID, msg, pHeader->MessageType );
	//			}
	//			else
	//			{
	//				free(msg);
	//			}
	//		}
	//		else
	//		{
	//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Unable to allocate memory");
	//		}
	//}

}

int ClientSession::HandleWebsocketDataFrame(char *buff, unsigned int size, IServerProtocolEvents* pServerProtEvents)
{
	int nSuccess = 0;
	//0                   1                   2                   3
	//0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
	//+ -+-+-+-+------ - +-+------------ - +------------------------------ - +
	//| F | R | R | R | opcode | M | Payload len | Extended payload length |
	//| I | S | S | S | (4) | A | (7) | (16 / 64) |
	//| N | V | V | V | | S | | (if payload len == 126 / 127) |
	//| | 1 | 2 | 3 | | K | | |
	//+-+-+-+-+------ - +-+------------ - +---------------+
	//| Extended payload length continued, if payload len == 127 |
	//+---------------+------------------------------ - +
	//| | Masking - key, if MASK set to 1 |
	//+------------------------------ - +------------------------------ - +
	//| Masking - key(continued) | Payload Data |
	//+-------------------------------- - --------------+
	//:                     Payload Data continued ... :
	//+-------------------------------+
	//| Payload Data continued ... |
	//+-------------------------------------------------------------- - +
	// Parse Rest of the message	

	unsigned int sizeRead = 0;
	unsigned int sizePayloadRead = 0;
	//unsigned int sizeControlBlock = 0;
	int index = 0;

	try
	{
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: enter 0 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);

		while (sizeRead < size)
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 1 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: Hex Data");
			//for (int i = 0; i < m_recBufSize; i++)
			//{
			//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "%x", m_recBuf[i]);
			//}
			if (m_nState == READ_SIZE)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 2 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				if (m_recBufSize < PAYLOAD_LENGHT_BYTES && (size - sizeRead < PAYLOAD_LENGHT_BYTES))
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 3 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
					// Copy it to buffer and wait.
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					m_nState = WAIT_FOR_SIZE_BLOCK;

					m_recBufSize += (size - sizeRead);
					sizeRead += (size - sizeRead);

					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: < PAYLOAD_LENGTH_SIZE");
				}
				else
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 4 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
					char sss;
					bool bMaskBit = false;

					char opcodeX;
					// Read the size. The size is 0 to 7 bits on byte 

					if (m_recBufSize < PAYLOAD_LENGHT_BYTES)
					{
						memcpy(m_recBuf + m_recBufSize, buff + sizeRead, PAYLOAD_LENGHT_BYTES - m_recBufSize);

						sizeRead += PAYLOAD_LENGHT_BYTES - m_recBufSize;
						m_recBufSize += PAYLOAD_LENGHT_BYTES - m_recBufSize;
					}

					memcpy(&opcodeX, m_recBuf, PAYLOAD_LENGHT_BYTES - 1);
					memcpy(&sss, m_recBuf + 1, PAYLOAD_LENGHT_BYTES - 1);

					//memcpy(&opcodeX, buff + sizeRead, PAYLOAD_LENGHT_BYTES - 1);
					//memcpy(&sss, buff + sizeRead + 1, PAYLOAD_LENGHT_BYTES - 1);


					if (sss & MASK_BIT)
					{
						m_bMaskBit = true;
					}

					m_Opcode = opcodeX & MASK_OPCODE;

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: OP Code %d", m_Opcode);

					sss &= PAYLOAD_LENGTH_MASK;
					m_msgSize = sss;

					//sizeRead += PAYLOAD_LENGHT_BYTES;
					//m_recBufSize += PAYLOAD_LENGHT_BYTES;
					//sizeControlBlock += PAYLOAD_LENGHT_BYTES;

					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: MsgSize = %u, Opcode=%d", m_msgSize, m_Opcode);

					if (m_msgSize <= 125)
					{
						//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 5 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
						// this is the final size, no need to do anything
						if (m_bMaskBit)
						{
							m_nState = MSG_READ_MASK_BIT;
						}
						else
						{
							m_nState = MSG_SIZE_READ;
						}
					}
					else if (m_msgSize == 126)
					{
						m_nState = MSG_READ_EXTENDED_SIZE;
					}
					else if (m_msgSize == 127)
					{
						m_nState = MSG_READ_EXTRA_EXTENDED_SIZE;
					}

					sizeControlBlock += PAYLOAD_LENGHT_BYTES;
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 6 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d Msg Size = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead, m_msgSize);
				}
			}
			else if (m_nState == MSG_READ_EXTENDED_SIZE)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 7 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				if (m_recBufSize - sizeControlBlock < EXTENDED_PAYLOAD_LENGTH && (size - sizeRead < EXTENDED_PAYLOAD_LENGTH))
				{
					// Copy it to buffer and wait.
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					m_nState = WAIT_FOR_EXTENDED_SIZE;

					m_recBufSize += (size - sizeRead);
					sizeRead += (size - sizeRead);
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 8 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				}
				else
				{
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 9 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);

					if (m_recBufSize < EXTENDED_PAYLOAD_LENGTH + sizeControlBlock)
					{
						int nTemp = sizeControlBlock + EXTENDED_PAYLOAD_LENGTH - m_recBufSize;
						memcpy(m_recBuf + m_recBufSize, buff + sizeRead, nTemp);

						m_recBufSize += nTemp;
						sizeRead += nTemp;
					}

					short xxx = 0;
					memcpy(&xxx, m_recBuf + sizeControlBlock, EXTENDED_PAYLOAD_LENGTH);
					m_msgSize = ntohs(xxx);

					sizeControlBlock += EXTENDED_PAYLOAD_LENGTH;

					if (m_bMaskBit)
					{
						m_nState = MSG_READ_MASK_BIT;
					}
					else
					{
						m_nState = MSG_SIZE_READ;
					}

					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 10 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d Msg Size = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead, m_msgSize);
				}
			}
			else if (m_nState == MSG_READ_EXTRA_EXTENDED_SIZE)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 11 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				if (m_recBufSize - sizeControlBlock < EXTRA_EXTENDED_PAYLOAD_LENGTH && (size - sizeRead < EXTRA_EXTENDED_PAYLOAD_LENGTH))
				{
					// Copy it to buffer and wait.
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					m_nState = WAIT_FOR_EXTRA_EXTENDED_SIZE;

					m_recBufSize += (size - sizeRead);
					sizeRead += (size - sizeRead);

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 12 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				}
				else
				{
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 13 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);

					if (m_recBufSize < EXTRA_EXTENDED_PAYLOAD_LENGTH + sizeControlBlock)
					{
						memcpy(m_recBuf + m_recBufSize, buff + sizeRead, EXTRA_EXTENDED_PAYLOAD_LENGTH);

						m_recBufSize += EXTRA_EXTENDED_PAYLOAD_LENGTH;
						sizeRead += EXTRA_EXTENDED_PAYLOAD_LENGTH;
					}

					//memcpy(m_recBuf + m_recBufSize, buff + sizeRead, EXTRA_EXTENDED_PAYLOAD_LENGTH);
					unsigned int xxx = 0;
					memcpy(&xxx, m_recBuf + sizeControlBlock, EXTRA_EXTENDED_PAYLOAD_LENGTH);
					m_msgSize = ntohs(xxx);

					sizeControlBlock += EXTRA_EXTENDED_PAYLOAD_LENGTH;
					//m_recBufSize += EXTRA_EXTENDED_PAYLOAD_LENGTH;
					//sizeRead += EXTRA_EXTENDED_PAYLOAD_LENGTH;

					if (m_bMaskBit)
					{
						m_nState = MSG_READ_MASK_BIT;
					}
					else
					{
						m_nState = MSG_SIZE_READ;
					}
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 14 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d Msg Size = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead, m_msgSize);
				}
			}
			else if (m_nState == MSG_READ_MASK_BIT)
			{
				int nTemp = (sizeControlBlock + MASK_BIT_LENGTH - m_recBufSize);
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 15 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				//if (m_recBufSize - sizeControlBlock < MASK_BIT_LENGTH && (size - sizeRead < MASK_BIT_LENGTH))
				if (sizeControlBlock + MASK_BIT_LENGTH - m_recBufSize > size - sizeRead)
				{
					// Copy it to buffer and wait.
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					m_nState = WAIT_FOR_MASK_BIT;

					m_recBufSize += (size - sizeRead);
					sizeRead += (size - sizeRead);
				}
				else
				{
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 16 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (sizeControlBlock + MASK_BIT_LENGTH - m_recBufSize));

					m_recBufSize += nTemp;
					sizeControlBlock += nTemp;
					sizeRead += nTemp;

					m_nState = MSG_SIZE_READ;
				}
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 17 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			}
			else if (m_nState == WAIT_FOR_EXTENDED_SIZE)
			{
				int nTemp = EXTENDED_PAYLOAD_LENGTH + PAYLOAD_LENGHT_BYTES;
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 18 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);

				if (nTemp - m_recBufSize > size - sizeRead)
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

					sizeRead += (size - sizeRead);
					m_recBufSize += (size - sizeRead);
					m_nState = WAIT_FOR_EXTENDED_SIZE;
				}
				else
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, nTemp - m_recBufSize);
					//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

					sizeRead += (nTemp - m_recBufSize);
					m_recBufSize += (nTemp - m_recBufSize);
					m_nState = MSG_READ_EXTENDED_SIZE;
				}
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 19 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			}
			else if (m_nState == WAIT_FOR_EXTRA_EXTENDED_SIZE)
			{
				int nTemp = PAYLOAD_LENGHT_BYTES + EXTRA_EXTENDED_PAYLOAD_LENGTH;
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 20 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				memcpy(m_recBuf + m_recBufSize, buff + sizeRead, nTemp - m_recBufSize);
				//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

				sizeRead += (nTemp - m_recBufSize);
				m_recBufSize += (nTemp - m_recBufSize);
				m_nState = MSG_READ_EXTRA_EXTENDED_SIZE;
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 21 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			}
			else if (m_nState == WAIT_FOR_MASK_BIT)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 22 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);

				if (MASK_BIT_LENGTH + sizeControlBlock - m_recBufSize > size - sizeRead)
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

					sizeRead += (size - sizeRead);
					m_recBufSize += size - sizeRead;
					//sizeControlBlock += MASK_BIT_LENGTH;
					m_nState = WAIT_FOR_MASK_BIT;
				}
				else
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, MASK_BIT_LENGTH + sizeControlBlock - m_recBufSize);
					//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

					sizeRead += (MASK_BIT_LENGTH + sizeControlBlock - m_recBufSize);
					m_recBufSize += (MASK_BIT_LENGTH + sizeControlBlock - m_recBufSize);
					sizeControlBlock += MASK_BIT_LENGTH;
					m_nState = MSG_SIZE_READ;
				}

				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 23 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			}
			else if (m_nState == WAIT_FOR_SIZE_BLOCK)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 24 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				memcpy(m_recBuf + m_recBufSize, buff + sizeRead, PAYLOAD_LENGHT_BYTES - m_recBufSize);
				//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

				sizeRead += (PAYLOAD_LENGHT_BYTES - m_recBufSize);
				m_recBufSize += (PAYLOAD_LENGHT_BYTES - m_recBufSize);
				m_nState = READ_SIZE;
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 25 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);

				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: WAIT_FOR_SIZE_BLOCK");
				//memcpy(m_recBuf + m_recBufSize, buff + sizeRead, sizeof(unsigned int) - m_recBufSize);
				//memcpy(&m_msgSize, m_recBuf, sizeof(unsigned int));

				//sizeRead += (sizeof(unsigned int) - m_recBufSize);
				//m_recBufSize += (sizeof(unsigned int) - m_recBufSize);
				//m_nState = MSG_SIZE_READ;
			}
			else if (m_nState == MSG_SIZE_READ)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 26 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				if ((m_msgSize) > size - sizeRead)
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					m_recBufSize += (size - sizeRead);
					sizeRead += (size - sizeRead);

					m_nState = PART_MSG_RECVD;
				}
				else
				{
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 27 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, (m_msgSize));

					sizeRead += (m_msgSize);
					m_recBufSize += (m_msgSize);

					m_nState = MSG_READ_COMPLETE;
				}
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 28 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			}
			else if (m_nState == PART_MSG_RECVD)
			{
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 29 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: PART_MSG_RECVD");

				if (m_msgSize + sizeControlBlock - m_recBufSize > size - sizeRead)
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, size - sizeRead);
					sizeRead += size - sizeRead;
					m_recBufSize += (size - sizeRead);

					m_nState = PART_MSG_RECVD;
				}
				else
				{
					memcpy(m_recBuf + m_recBufSize, buff + sizeRead, m_msgSize + sizeControlBlock - m_recBufSize);
					sizeRead += (m_msgSize + sizeControlBlock - m_recBufSize);
					m_recBufSize += (m_msgSize + sizeControlBlock - m_recBufSize);

					m_nState = MSG_READ_COMPLETE;
				}
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 30 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);
			}

			if (m_nState == MSG_READ_COMPLETE)
			{
				char buffer[8192];

				memcpy(buffer, m_recBuf, m_recBufSize);
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: MSG_READ_COMPLETE. OpCode = %d", m_Opcode);

				// If it is text frame or continuation frame
				if (m_Opcode == 1 || m_Opcode == 0)
				{

					if (HandleProcessedWebsocketData(buffer, m_recBufSize, pServerProtEvents) != 0)
					{

						return -1;
					}
				}
				else if (m_Opcode == 8)
				{
					return -1;
				}

				//index++;
				m_recBufSize = 0;
				m_msgSize = 0;
				sizeControlBlock = 0;
				m_bMaskBit = false;
				m_Opcode = 0;

				m_nState = READ_SIZE;
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: 31 Size %d, RecvBufSize=%d, SizeControlBlock=%d, State = %d, Size Read = %d", size, m_recBufSize, sizeControlBlock, m_nState, sizeRead);


			}
		}

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: Exit");
	}

	catch (std::exception ex)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: Catch, Error = ", ex.what());
	}
	catch (...)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleWebsocketDataFrame:: Catch,....");
	}
	return nSuccess;
}

void ClientSession::HandleRecdBuffer(char * buff, unsigned int size, IServerProtocolEvents* pServerProtEvents, char *httpResponse, int& ResponseSize)
{
	//AcquireLock(&m_cs);


	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: enter m_bHandShakeDone = %d size = %d ", m_bHandShakeDone, size);

	if (size == 0) return;

	if (!m_bHandShakeDone)
	{
		try
		{

			EnterCriticalSection(&m_csWebsocketHandle);
			// Add Handshake
			WEB_SOCKET_HTTP_HEADER header[6];
			//header[0].pcName = new char[300];
			//header[0].pcValue = new char[300];
			//header[1].pcName = new char[300];
			//header[1].pcValue = new char[300];
			//header[2].pcName = new char[300];
			//header[2].pcValue = new char[300];

			header[3].pcName = new char[22];
			header[3].pcValue = new char[3];
			header[4].pcName = new char[18];
			header[4].pcValue = new char[300];
			header[5].pcName = new char[25];
			header[5].pcValue = new char[43];

			string strbuff(buff);


			if (strbuff.size() < 10) {

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: strbuff.size() : %d", strbuff.size());
				LeaveCriticalSection(&m_csWebsocketHandle);
				return;
			}


			int found = strbuff.find("Sec-WebSocket-Version");

			if (found < 0) {

				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Sec-WebSocket-Version error : %s", strbuff.c_str());
				LeaveCriticalSection(&m_csWebsocketHandle);
				return;
			}

			char temp[8193];
			memcpy(temp, buff, size);
			temp[size] = '\0';
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: %s", temp);

			string ip = strbuff.substr(strbuff.find("Host:") + 6, strbuff.length());
			ip = ip.substr(0, ip.find("\r\n"));

			string connection = strbuff.substr(strbuff.find("Connection:") + 12, strbuff.length());
			connection = connection.substr(0, connection.find("\r\n"));

			string Upgrade = strbuff.substr(strbuff.find("Upgrade:") + 9, strbuff.length());

			Upgrade = Upgrade.substr(0, Upgrade.find("\r\n"));


			header[0].pcName = new char[5];
			header[0].pcValue = new char[ip.length() + 1];

			strcpy(header[0].pcName, "Host");
			header[0].ulNameLength = strlen(header[0].pcName);
			strcpy_s(header[0].pcValue, ip.length() + 1, ip.c_str());
			header[0].ulValueLength = strlen(header[0].pcValue);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer header[0].pcValue:: %s", header[0].pcValue);


			header[1].pcName = new char[11];
			header[1].pcValue = new char[connection.length() + 1];

			strcpy(header[1].pcName, "Connection");
			header[1].ulNameLength = strlen(header[1].pcName);
			strcpy_s(header[1].pcValue, connection.length() + 1, connection.c_str());
			header[1].ulValueLength = strlen(header[1].pcValue);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer header[1].pcValue:: %s", header[1].pcValue);

			header[2].pcName = new char[8];
			header[2].pcValue = new char[Upgrade.length() + 1];

			strcpy(header[2].pcName, "Upgrade");
			header[2].ulNameLength = strlen(header[2].pcName);
			strcpy_s(header[2].pcValue, Upgrade.length() + 1, Upgrade.c_str());
			header[2].ulValueLength = strlen(header[2].pcValue);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer header[2].pcValue:: %s", header[2].pcValue);

			strcpy(header[3].pcName, "Sec-WebSocket-Version");
			header[3].ulNameLength = strlen(header[3].pcName);
			strcpy(header[3].pcValue, "13");
			header[3].ulValueLength = strlen(header[3].pcValue);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer header[3].pcValue:: %s", header[3].pcValue);

			char *pPos = strstr(buff, "Sec-WebSocket-Key:");
			char *pPos1 = strstr(pPos, "\r\n");

			strcpy(header[4].pcName, "Sec-WebSocket-Key");
			header[4].ulNameLength = strlen(header[4].pcName);
			//int len = pPos1 - pPos;
			pPos += header[4].ulNameLength + 2;
			*pPos1 = '\0';
			strcpy_s(header[4].pcValue, 300, pPos);
			header[4].ulValueLength = strlen(header[4].pcValue);

			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer header[4].pcValue:: %s", header[4].pcValue);

			strcpy(header[5].pcName, "Sec-WebSocket-Extensions");
			header[5].ulNameLength = strlen(header[5].pcName);
			strcpy(header[5].pcValue, "permessage-deflate; client_max_window_bits");
			header[5].ulValueLength = strlen(header[5].pcValue);

			ULONG serverAdditionalHeaderCount = 0;
			WEB_SOCKET_HTTP_HEADER* serverAdditionalHeaders = NULL;

			if (m_hWebsocketHandle != NULL)
			{
				HRESULT hr = WebSocketBeginServerHandshake(m_hWebsocketHandle,
					NULL,
					NULL,
					0,
					header,
					6,
					&serverAdditionalHeaders,
					&serverAdditionalHeaderCount);

				if (!FAILED(hr))
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer WebSocketBeginServerHandshake OK");

					strcpy(httpResponse, "HTTP/1.1 101 Switching Protocols\r\n");

					ResponseSize = strlen(httpResponse);

					// Now add Additional headers
					for (int i = 0; i < serverAdditionalHeaderCount; i++)
					{
						char szTemp[500];
						memset(szTemp, 0, sizeof(szTemp));

						memcpy(szTemp, serverAdditionalHeaders[i].pcName, serverAdditionalHeaders[i].ulNameLength);
						szTemp[serverAdditionalHeaders[i].ulNameLength] = ':';
						szTemp[serverAdditionalHeaders[i].ulNameLength + 1] = ' ';
						memcpy(szTemp + serverAdditionalHeaders[i].ulNameLength + 2, serverAdditionalHeaders[i].pcValue, serverAdditionalHeaders[i].ulValueLength);
						strcat(szTemp, "\r\n");

						strcat(httpResponse, szTemp);
						ResponseSize += serverAdditionalHeaders[i].ulNameLength + serverAdditionalHeaders[i].ulValueLength + 4;
					}

					memcpy(httpResponse + ResponseSize, "\r\n", 2);
					ResponseSize += 2;

					WebSocketEndServerHandshake(m_hWebsocketHandle);

					m_bHandShakeDone = true;
				}
				else
				{
					ResponseSize = 0;
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer WebSocketBeginServerHandshake Failed : %d", hr);
				}
			}
			else
			{
				ResponseSize = 0;
				stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer m_hWebsocketHandle==NULL");
			}

			LeaveCriticalSection(&m_csWebsocketHandle);
		}
		catch (std::exception ex)
		{
			LeaveCriticalSection(&m_csWebsocketHandle);
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Catch, Error = ", ex.what());
		}
		catch (...)
		{
			LeaveCriticalSection(&m_csWebsocketHandle);
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Catch,....");
		}
	}
	else
	{
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: enter 1");
		if (HandleWebsocketDataFrame(buff, size, pServerProtEvents) == -1)
		{
			httpResponse = NULL;
			ResponseSize = -1;
		}

		/*if (HandleProcessedWebsocketData(buff, size, pServerProtEvents) == -1)
		{
		httpResponse = NULL;
		ResponseSize = -1;
		}*/
		//// Parse Rest of the message
		//HRESULT hr = WebSocketReceive(m_hWebsocketHandle, NULL, NULL);

		//if (!FAILED(hr))
		//{
		//	WEB_SOCKET_BUFFER buffers[1] = { 0 };
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
		//			WEB_SOCKET_RECEIVE_ACTION_QUEUE,
		//			buffers,
		//			&bufferCount,
		//			&action,
		//			&bufferType,
		//			NULL,
		//			&actionContext);
		//		if (FAILED(hr))
		//		{
		//			_com_error error(hr);
		//			LPCTSTR errorText = error.ErrorMessage();

		//			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecvBuffer:: WebSocketGetAction Failed %s", errorText);
		//			// If we cannot get an action, abort the handle but continue processing until all operations are completed.
		//			WebSocketAbortHandle(m_hWebsocketHandle);

		//			continue;
		//		}
		//		else
		//		{
		//			switch (action)
		//			{
		//				case WEB_SOCKET_SEND_TO_NETWORK_ACTION:

		//					//wprintf(L"Sending data to a network:\n");

		//					for (ULONG i = 0; i < bufferCount; i++)
		//					{
		//						char temp[8192];
		//						memcpy(temp, buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
		//						temp[buffers[i].Data.ulBufferLength] = '\0';
		//						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketReeive:: Sending Websocket Length = %d, %d=%s", buffers[i].Data.ulBufferLength, i, temp);

		//						g_pServerSocket->Send(m_clientID, (char *)buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
		//						bytesTransferred += buffers[i].Data.ulBufferLength;
		//					}
		//					break;


		//				case WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION:

		//					wprintf(L"Send operation completed\n");
		//					break;


		//				case WEB_SOCKET_NO_ACTION:

		//					// No action to perform - just exit the loop.
		//					break;

		//				case WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION:
		//					memcpy(buffers[0].Data.pbBuffer, buff, size);
		//					//buffers[0].Data.ulBufferLength = size;
		//					bytesTransferred = size;
		//					break;

		//				case WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION:
		//					if (bufferType != WEB_SOCKET_PING_PONG_BUFFER_TYPE && bufferType != WEB_SOCKET_UNSOLICITED_PONG_BUFFER_TYPE)
		//					{
		//						buffers[0].Data.pbBuffer[buffers[0].Data.ulBufferLength] = '\0';
		//						HandleBinaryRecdBuffer((char *)buffers[0].Data.pbBuffer, buffers[0].Data.ulBufferLength, pServerProtEvents);
		//					}
		//					else
		//					{
		//						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecvBuffer:: Received PONG Response");
		//						// It is pingpong response
		//						int x = 0;
		//					}
		//					break;

		//				default:

		//					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecvBuffer:: Invalid Action %d", action);

		//					// This should never happen.
		//					//					assert(!"Invalid switch");
		//					hr = E_FAIL;
		//			}

		//			//if (hr == E_FAIL)
		//			if (FAILED(hr))
		//			{
		//				int y = 0;
		//				// If we failed at some point processing actions, abort the handle but continue processing
		//				// until all operations are completed.
		//				WebSocketAbortHandle(m_hWebsocketHandle);
		//			}

		//			// Complete the action. If application performs asynchronous operation, the action has to be
		//			// completed after the async operation has finished. The 'actionContext' then has to be preserved
		//			// so the operation can complete properly.
		//			//if (!FAILED(hr))
		//			WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
		//		}
		//	} while (action != WEB_SOCKET_NO_ACTION);

		//}


	}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleRecdBuffer:: Exit");
	//LeaveCriticalSection(&m_csWebsocketHandle);

	//ReleaseLock(&m_cs);


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
	m_clientSessionMap.clear();
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

	map<unsigned int, IClientSession*>::iterator it;
	for (it = m_clientSessionMap.begin(); it != m_clientSessionMap.end(); it++)
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

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::UpdateSendTime,  BEFORE Ack CS_CLIENT_SESSION_MAP");
	EnterCriticalSection(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::UpdateSendTime,  After Ack CS_CLIENT_SESSION_MAP");

	map<unsigned int, IClientSession*>::iterator iter = m_clientSessionMap.find(clientID);

	if (iter != m_clientSessionMap.end())
	{
		// Update the send time
		ClientSession *pSession = (ClientSession *)(*iter).second;

		if (pSession)
		{
			pSession->m_LastSendTime = CTime::GetCurrentTime();
		}
	}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::UpdateSendTime,  BEFORE Rel CS_CLIENT_SESSION_MAP");
	LeaveCriticalSection(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::UpdateSendTime,  After Rel CS_CLIENT_SESSION_MAP");

	return bSuccess;
}

void ClientSessionMgr::Add(unsigned int clientId, char* clientIp, unsigned short clientPort)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, Enter");
	IClientSession* clientSession = new ClientSession(clientId, clientIp, clientPort);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Add,  BEFORE Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Add,  after Ack CS_CLIENT_SESSION_MAP");
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, Enter1");
	pair<unsigned int, IClientSession*> pr(clientSession->GetClientId(), clientSession);
	m_clientSessionMap.insert(pr);

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Add,  BEFORE Rel CS_CLIENT_SESSION_MAP");
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Add,  After Rel CS_CLIENT_SESSION_MAP");
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ConnectionMgr::AddConnection, Exit");
}

void ClientSessionMgr::AcquireSessionLock()
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::AcquireSessionLock,  BEFORE Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::AcquireSessionLock,  After Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_UNAME_SESSION_MAP);
}

void ClientSessionMgr::ReleaseSessionLock()
{
	ReleaseLock(&CS_UNAME_SESSION_MAP);
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::ReleaseSessionLock,  After Rel CS_CLIENT_SESSION_MAP");
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::ReleaseSessionLock,  After Rel CS_CLIENT_SESSION_MAP");
}


void ClientSessionMgr::AddUserName(unsigned int clientId, std::string strUserName)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::AddUserName,  BEFORE Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::UpdateSendTime,  After Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_UNAME_SESSION_MAP);

	std::map<unsigned int, IClientSession*>::iterator iter = m_clientSessionMap.find(clientId);

	if (iter != m_clientSessionMap.end())
	{
		IClientSession *pSession = (*iter).second;;

		if (pSession)
		{
			std::map<std::string, std::list<unsigned int>>::iterator iter1 = m_mapUserNameClientSession.find(strUserName);

			if (iter1 != m_mapUserNameClientSession.end())
			{
				std::list<unsigned int>& lstSessions = (*iter1).second;

				lstSessions.push_back(pSession->GetClientId());
			}
			else
			{
				std::list<unsigned int> lstSession;

				lstSession.push_back(pSession->GetClientId());
				std::pair<std::string, std::list<unsigned int>> pr(strUserName, lstSession);
				m_mapUserNameClientSession.insert(pr);
			}
		}
	}

	ReleaseLock(&CS_UNAME_SESSION_MAP);

	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::AddUserName,  BEFORE Rel CS_CLIENT_SESSION_MAP");
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::AddUserName,  After Rel CS_CLIENT_SESSION_MAP");
}

void ClientSessionMgr::Remove(unsigned int clientId)
{
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Remove,  BEFORE Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Remove,  After Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_UNAME_SESSION_MAP);

	std::string strUserName;

	map<unsigned int, IClientSession*>::iterator iter = m_clientSessionMap.find(clientId);
	if (iter != m_clientSessionMap.end())
	{
		IClientSession* pSession = (*iter).second;

		if (pSession)
		{
			strUserName = pSession->GetUserName();

			map<std::string, std::list<unsigned int>>::iterator iter1 = m_mapUserNameClientSession.find(strUserName);

			if (iter1 != m_mapUserNameClientSession.end())
			{
				std::list<unsigned int>& lstSession = (*iter1).second;

				lstSession.remove(clientId);

				if (lstSession.empty())
				{
					m_mapUserNameClientSession.erase(iter1);
				}
			}
		}

		m_clientSessionMap.erase(iter);
	}

	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Remove,  BEFORE Rel CS_CLIENT_SESSION_MAP");
	ReleaseLock(&CS_UNAME_SESSION_MAP);
	//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::Remove,  After Rel CS_CLIENT_SESSION_MAP");
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
}

std::list<unsigned int>* ClientSessionMgr::GetClientSessionList(std::string strUserName)
{
	map<std::string, std::list<unsigned int>>::iterator iter = m_mapUserNameClientSession.find(strUserName);

	std::list<unsigned int> *pList = NULL;

	if (iter != m_mapUserNameClientSession.end())
	{
		pList = &(*iter).second;
	}

	return pList;
}

IClientSession* ClientSessionMgr::GetClientSession(unsigned int clientId)
{
	IClientSession* clientSession = NULL;
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::GetClientSession,  BEFORE Ack CS_CLIENT_SESSION_MAP");
	AcquireLock(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::GetClientSession,  After Ack CS_CLIENT_SESSION_MAP");
	map<unsigned int, IClientSession*>::iterator iter = m_clientSessionMap.find(clientId);
	if (iter != m_clientSessionMap.end())
	{
		clientSession = m_clientSessionMap[clientId];
	}

	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::GetClientSession,  BEFORE Rel CS_CLIENT_SESSION_MAP");
	ReleaseLock(&CS_CLIENT_SESSION_MAP);
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "ClientSessionMgr::GetClientSession,  After Rel CS_CLIENT_SESSION_MAP");
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

DWORD ClientSessionMgr::ConnectionReviewer(LPVOID lpdwThreadParam)
{
	ClientSessionMgr *pMgr = (ClientSessionMgr *)lpdwThreadParam;
	std::list<IClientSession *> lstSessions;

	while (1)
	{
		lstSessions.clear();

		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Before Acquire CS");

		pMgr->AcquireCS();

		map<unsigned int, IClientSession*> mapClientSession = pMgr->GetClientSessionMap();

		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: After Acquire CS");

		if (mapClientSession.size() == 0)
		{
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Before Released CS Connected Clients %d", mapClientSession.size());
			pMgr->ReleaseCS();
			//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Released CS Connected Clients %d", mapClientSession.size());

			Sleep(60000);
			continue;
		}

		map<unsigned int, IClientSession*>::iterator iter = mapClientSession.begin();


		while (iter != mapClientSession.end())
		{
			IClientSession *pSession = iter->second;

			if (pSession)
			{
				lstSessions.push_back(pSession);
			}

			iter++;
		}

		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Before Released CS Connected Clients %d", mapClientSession.size());
		pMgr->ReleaseCS();
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Released CS Connected Clients %d", mapClientSession.size());

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Total Connected Clients : %d", mapClientSession.size());

		std::list<IClientSession *>::iterator iter1 = lstSessions.begin();

		while (iter1 != lstSessions.end())
		{
			IClientSession *pSession = (IClientSession *)*iter1;

			if (pSession)
			{
				pMgr->m_pServerProtocol->WebSocketSend(pSession->GetClientId(), NULL, 1000, 0);
			}

			iter1++;
		}

		Sleep(60000);
	}

	return 0L;
}

//DWORD ClientSessionMgr::ConnectionReviewer (LPVOID lpdwThreadParam )
//{
//	ClientSessionMgr *pMgr = (ClientSessionMgr *)lpdwThreadParam;
//
//	while (1)
//	{
//		pMgr->AcquireCS();
//
//		map<unsigned int,IClientSession*> mapClientSession = pMgr->GetClientSessionMap();
//
//		map<unsigned int,IClientSession*>::iterator iter = mapClientSession.begin();
//
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Connected Clients %d", mapClientSession.size());
//
//		while (iter != mapClientSession.end())
//		{
//			IClientSession *pSession = iter->second;
//
//			if (pSession)
//			{
//				pMgr->m_pServerProtocol->WebSocketSend(pSession->GetClientId(), NULL, 1000, 0);
//				/*if (pSession->CheckHeartbeat() == -1)
//				{
//					pMgr->DisconnectClient(pSession->GetClientId());
//				}*/
//			}
//
//			iter++;
//		}
//
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Before Released CS Connected Clients %d", mapClientSession.size());
//		pMgr->ReleaseCS();
//		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSessionMgr::ConnectionReviewer:: Released CS Connected Clients %d", mapClientSession.size());
//
//		Sleep(60000);
//	}
//
//	return 0L;
//}

map<unsigned int, IClientSession*>& ClientSessionMgr::GetClientSessionMap()
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

	try {
		WEB_SOCKET_BUFFER buffer;

		std::string JSONString;
		unsigned int MsgSize = 0;

		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Before CS %u", GetClientId());
		EnterCriticalSection(&m_csWebsocketHandle);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: After CS %u", GetClientId());

		if (m_hWebsocketHandle == NULL)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebsocketSend:: Websockethandle is NULL %u", GetClientId());
			LeaveCriticalSection(&m_csWebsocketHandle);
			return false;
		}

		g_pServerSocket = pServerSocket;

		if (pMsg)
		{
			JSONHandler::GetJSONFromObject(pMsg, MsgType, JSONString, MsgSize);

			buffer.Data.pbBuffer = (PBYTE)JSONString.c_str();
			buffer.Data.ulBufferLength = JSONString.length();
		}

		HRESULT hr;

		if (pMsg)
			hr = WebSocketSend(m_hWebsocketHandle, WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE, &buffer, NULL);
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Send PINGPONG");
			hr = WebSocketSend(m_hWebsocketHandle, _WEB_SOCKET_BUFFER_TYPE::WEB_SOCKET_PING_PONG_BUFFER_TYPE, NULL, NULL);
		}

		if (!FAILED(hr))
		{
			WEB_SOCKET_BUFFER buffers[2] = { 0 };
			ULONG bufferCount;
			ULONG bytesTransferred;
			WEB_SOCKET_BUFFER_TYPE bufferType;
			WEB_SOCKET_ACTION action;
			PVOID actionContext;

			do
			{
				// Initialize variables that change with every loop revolution.
				bufferCount = ARRAYSIZE(buffers);
				bytesTransferred = 0;

				// Get an action to process.
				hr = WebSocketGetAction(
					m_hWebsocketHandle,
					WEB_SOCKET_ALL_ACTION_QUEUE,
					buffers,
					&bufferCount,
					&action,
					&bufferType,
					NULL,
					&actionContext);
				if (FAILED(hr))
				{
					_com_error error(hr);
					LPCTSTR errorText = error.ErrorMessage();

					printf("Error in Sending\n");
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: WebSocketGetAction Failed %s", errorText);
					// If we cannot get an action, abort the handle but continue processing until all operations are completed.
					WebSocketAbortHandle(m_hWebsocketHandle);

					continue;
				}

				switch (action)
				{
				case WEB_SOCKET_NO_ACTION:

					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebsocketSend:: Websockethandle No Action %u", GetClientId());
					// No action to perform - just exit the loop.
					break;

				case WEB_SOCKET_SEND_TO_NETWORK_ACTION:

					//wprintf(L"Sending data to a network:\n");

					//Sleep(50);
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: %u, Buffercount=%d", GetClientId(), bufferCount);

					if (bufferCount == 1)
					{
						for (ULONG i = 0; i < bufferCount; i++)
						{
							char temp[8192];
							memcpy(temp, buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
							temp[buffers[i].Data.ulBufferLength] = '\0';

							//if (buffers[i].Data.ulBufferLength > 4)
							//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Sending Websocket Length = %d, %d=%s", buffers[i].Data.ulBufferLength, i, temp);

							if (buffers[i].Data.ulBufferLength > 4)
								printf("Data Send %s\n", temp);

							pServerSocket->Send(m_clientID, (char *)buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
							bytesTransferred += buffers[i].Data.ulBufferLength;
						}
					}
					else if (bufferCount == 2)
					{

						char temp[8192];
						memcpy(temp, buffers[0].Data.pbBuffer, buffers[0].Data.ulBufferLength);
						memcpy(temp + buffers[0].Data.ulBufferLength, buffers[1].Data.pbBuffer, buffers[1].Data.ulBufferLength);
						temp[buffers[0].Data.ulBufferLength + buffers[1].Data.ulBufferLength] = '\0';

						//if (buffers[i].Data.ulBufferLength > 4)
						//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Sending Websocket Length = %d, %d=%s", buffers[0].Data.ulBufferLength + buffers[1].Data.ulBufferLength, 0, temp);

						//if (buffers[].Data.ulBufferLength > 4)
						printf("Data Send %s\n", temp);

						//pServerSocket->Send(m_clientID, (char *)buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
						//pServerSocket->Send(m_clientID, temp, buffers[0].Data.ulBufferLength + buffers[1].Data.ulBufferLength);

						if (pServerSocket->Send(m_clientID, temp, buffers[0].Data.ulBufferLength + buffers[1].Data.ulBufferLength))
						{
							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Sent To Client %d Message :%s ", m_clientID, temp);
						}
						else
						{
							stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Not Sent To Client %d Message :%s ", m_clientID, temp);
						}		

						bytesTransferred += buffers[0].Data.ulBufferLength + buffers[1].Data.ulBufferLength;
					}

					break;


				case WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION:

					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebsocketSend:: Complete Action %u", GetClientId());
					wprintf(L"Send operation completed\n");
					break;

				default:

					// This should never happen.
					assert(!"Invalid switch");
					hr = E_FAIL;
					//goto quit;
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Invalid Action %d", action);
				}

				if (FAILED(hr))
				{
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Failed to Send Web Socket 11");
					// If we failed at some point processing actions, abort the handle but continue processing
					// until all operations are completed.
					WebSocketAbortHandle(m_hWebsocketHandle);
				}

				// Complete the action. If application performs asynchronous operation, the action has to be
				// completed after the async operation has finished. The 'actionContext' then has to be preserved
				// so the operation can complete properly.
				WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
			} while (action != WEB_SOCKET_NO_ACTION);

		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Failed to Send Web Socket");
		}

		LeaveCriticalSection(&m_csWebsocketHandle);

	}
	catch (std::exception ex)
	{
		LeaveCriticalSection(&m_csWebsocketHandle);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Catch, Error = ", ex.what());
	}
	catch (...)
	{
		LeaveCriticalSection(&m_csWebsocketHandle);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Catch,....");
	}


	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: Before Rel CS %u", GetClientId());
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketSend:: After Rel CS %u", GetClientId());

	return bSuccess;
}

int ClientSession::HandleProcessedWebsocketData(char *buff, unsigned int size, IServerProtocolEvents* pServerProtEvents)
{
	int nSuccess = 0;

	try
	{
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Hex Data");
		//for (int i = 0; i < size; i++)
		//{
		//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "%x", buff[i]);
		//}
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Before CS %u, Size=%u", GetClientId(), size);
		EnterCriticalSection(&m_csWebsocketHandle);
		//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: After CS %u", GetClientId());

		if (m_hWebsocketHandle == NULL)
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Websockethandle is NULL %u", GetClientId());
			LeaveCriticalSection(&m_csWebsocketHandle);
			return -1;
		}
		HRESULT hr = WebSocketReceive(m_hWebsocketHandle, NULL, NULL);

		if (!FAILED(hr))
		{
			WEB_SOCKET_BUFFER buffers[2] = { 0 };
			ULONG bufferCount;
			ULONG bytesTransferred;
			WEB_SOCKET_BUFFER_TYPE bufferType;
			WEB_SOCKET_ACTION action;
			PVOID actionContext;

			do
			{
				// Initialize variables that change with every loop revolution.
				bufferCount = ARRAYSIZE(buffers);
				bytesTransferred = 0;

				// Get an action to process.
				hr = WebSocketGetAction(
					m_hWebsocketHandle,
					WEB_SOCKET_RECEIVE_ACTION_QUEUE,
					buffers,
					&bufferCount,
					&action,
					&bufferType,
					NULL,
					&actionContext);
				if (FAILED(hr))
				{

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Abort 1");
					// If we cannot get an action, abort the handle but continue processing until all operations are completed.
					WebSocketAbortHandle(m_hWebsocketHandle);

					if (hr == E_INVALID_PROTOCOL_FORMAT || hr == E_INVALID_PROTOCOL_OPERATION)
					{

						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Invalid Format of Data. Reason = %s", buffers[0].CloseStatus.pbReason);

						WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
						//					continue;
						WebSocketDeleteHandle(m_hWebsocketHandle);
						HandleBinaryRecdBuffer(NULL, 0, pServerProtEvents);
						m_hWebsocketHandle = NULL;


						nSuccess = -1;
						break;
					}

					//continue;
				}
				else
				{
					//if (bufferType == WEB_SOCKET_PING_PONG_BUFFER_TYPE)
					//{
					//	WebSocketSend(m_hWebsocketHandle, WEB_SOCKET_PING_PONG_BUFFER_TYPE, NULL, NULL);
					////	continue;
					//}
				}

				switch (action)
				{
				case WEB_SOCKET_SEND_TO_NETWORK_ACTION:
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Wrong Action.IT shd not come here");
					//wprintf(L"Sending data to a network:\n");
					//if (bufferType == WEB_SOCKET_PING_PONG_BUFFER_TYPE)
					//{
					//	WebSocketSend(m_hWebsocketHandle, WEB_SOCKET_PING_PONG_BUFFER_TYPE, NULL, NULL);
					//	//	continue;
					//}


					//for (ULONG i = 0; i < bufferCount; i++)
					//{
					//	char temp[8192];
					//	memcpy(temp, buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
					//	temp[buffers[i].Data.ulBufferLength] = '\0';
					//	stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::WebSocketReeive:: Sending Websocket Length = %d, %d=%s", buffers[i].Data.ulBufferLength, i, temp);

					//	g_pServerSocket->Send(m_clientID, (char *)buffers[i].Data.pbBuffer, buffers[i].Data.ulBufferLength);
					//	bytesTransferred += buffers[i].Data.ulBufferLength;
					//}
					break;


				case WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION:

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: SEND, shd not happen");
					wprintf(L"Send operation completed\n");
					break;


				case WEB_SOCKET_NO_ACTION:
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: NO Action");
					// No action to perform - just exit the loop.
					break;

				case WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION:
					if (size > 308)
					{
						int x = 0;
					}

					// Parse the packet. Check FIN bit


					//HandleWebsocketDataFrame(buff, size, buffers, 5);

					if (size > 4096)
					{
						memcpy(buffers[0].Data.pbBuffer, buff, 4096);
						memcpy(buffers[1].Data.pbBuffer, buff + 4096, size - 4096);
						//buffers[0].Data.ulBufferLength = size;
						buffers[0].Data.ulBufferLength = 4096;
						buffers[1].Data.ulBufferLength = size - 4096;
						bytesTransferred = size;
					}
					else
					{
						memcpy(buffers[0].Data.pbBuffer, buff, size);
						buffers[0].Data.ulBufferLength = size;
						bytesTransferred = size;
					}

					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION. Size = %u Bytes XFerred = %lu", size, bytesTransferred);
					break;



				case WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION:
					//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: RECEIVE COMPLETE");
					if (bufferType != WEB_SOCKET_PING_PONG_BUFFER_TYPE && bufferType != WEB_SOCKET_UNSOLICITED_PONG_BUFFER_TYPE)
					{
						//if (buffers[0].Data.ulBufferLength <)
						//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: RECEIVE COMPLETE Length 1 = %lu, Length2 = %lu", buffers[0].Data.ulBufferLength, buffers[1].Data.ulBufferLength);

						if (buffers[0].Data.ulBufferLength == 0 && buffers[1].Data.ulBufferLength == 0)
						{
							int a = 0;
						}
						buffers[0].Data.pbBuffer[buffers[0].Data.ulBufferLength] = '\0';
						HandleBinaryRecdBuffer((char *)buffers[0].Data.pbBuffer, buffers[0].Data.ulBufferLength, pServerProtEvents);

						if (buffers[1].Data.ulBufferLength > 0)
						{
							buffers[1].Data.pbBuffer[buffers[1].Data.ulBufferLength] = '\0';
							HandleBinaryRecdBuffer((char *)buffers[1].Data.pbBuffer, buffers[1].Data.ulBufferLength, pServerProtEvents);
						}
					}
					else
					{
						stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Ping Pong Response");
						// It is pingpong response
						int x = 0;
					}
					break;

				default:

					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: DEFAULT, shd not happen");
					// This should never happen.
					//					assert(!"Invalid switch");
					hr = E_FAIL;
					nSuccess = -1;
				}

				//if (hr == E_FAIL)
				if (FAILED(hr))
				{
					int y = 0;
					nSuccess = -1;
					stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Error 2 %x", hr);
					m_hWebsocketHandle = NULL;
					break;
					// If we failed at some point processing actions, abort the handle but continue processing
					// until all operations are completed.
					//WebSocketAbortHandle(m_hWebsocketHandle);
				}

				// Complete the action. If application performs asynchronous operation, the action has to be
				// completed after the async operation has finished. The 'actionContext' then has to be preserved
				// so the operation can complete properly.
				//if (!FAILED(hr))
				//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: COMPLETE ACTION. Action = %d, Size = %u Bytes XFerred = %lu", action,size, bytesTransferred);
				WebSocketCompleteAction(m_hWebsocketHandle, actionContext, bytesTransferred);
			} while (action != WEB_SOCKET_NO_ACTION);

		}
		else
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Error %x", hr);
		}

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Before Rel CS %u", GetClientId());
		LeaveCriticalSection(&m_csWebsocketHandle);
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: After Rel CS %u", GetClientId());

	}
	catch (std::exception ex)
	{
		LeaveCriticalSection(&m_csWebsocketHandle);
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Catch, Error = ", ex.what());
	}
	catch (...)
	{
		LeaveCriticalSection(&m_csWebsocketHandle);
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Catch,....");
	}

	return nSuccess;
	//stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "ClientSession::HandleProcessedWebsocketData:: Exit");
}