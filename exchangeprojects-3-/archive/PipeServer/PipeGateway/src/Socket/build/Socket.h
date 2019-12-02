#pragma once

#ifdef SOCKET_EXPORTS
#define SOCKETAPI __declspec(dllexport)
#else
#define SOCKETAPI __declspec(dllimport)
#endif

typedef enum SocketError
{
	SOCKET_SUCCESS,
	SOCKET_FAILED,
};


class ISocketEvents
{
public:
	virtual void OnConnect(unsigned int clientID, bool connect, char* clientIp, unsigned short clientPort)=0;
	virtual void OnSend(unsigned int  clientID, unsigned int noOfBytesSend, SocketError code)=0;
	virtual void OnReceive(unsigned int clientID, char * buff, unsigned int size)=0;
};

//class IClientSocketEvents
//{
//public:
//	virtual void OnSend(unsigned int noOfBytesSend, SocketError code, unsigned long long pkID)=0;
//	virtual void OnReceive(char * buff, unsigned int size)=0;
//	virtual void OnConnect(bool connect)=0;
//};

class Socket
{
public:
	virtual BOOL Start(int nPort=999,int iMaxNumConnections=1201,int iMaxIOWorkers=1,int nOfWorkers=0,int iMaxNumberOfFreeBuffer=100,int iMaxNumberOfFreeContext=50,BOOL bOrderedSend=TRUE, BOOL bOrderedRead=TRUE,int iNumberOfPendlingReads=5) = 0;
	virtual BOOL Connect(const std::string& strIPAddr, int nPort) = 0;
	//virtual unsigned short  GetListenerPort() = 0;
	//virtual std::string GetHostAddress(SOCKET socket) = 0;
	virtual void ShutDown() = 0;
	virtual void DisconnectClient(unsigned int clientID) = 0;
	virtual void DisconnectAll() = 0;
	virtual bool Send (unsigned int ClientID, char * buff, unsigned int size) = 0;
	virtual void RegisterEvents(ISocketEvents* pServer)=0;
	virtual ~Socket(){};
};

//class ClientSocket
//{
//public:
//	virtual bool Connect (char* serverIp,unsigned short port, unsigned int maxIOWorker) = 0;
//	virtual bool Send (char * buff, unsigned int size, unsigned long long pkID) = 0;
//	virtual void RegisterClientEvents(IClientSocketEvents* pClient)=0;
//	virtual bool Shutdown() = 0;
//	virtual ~ClientSocket(){};
//};


// Factory function that creates instances of the Server Socket object.
SOCKETAPI Socket* __stdcall CreateServerSocket ();

//Function for releasing the Server Socket object.
SOCKETAPI void __stdcall ReleaseServerSocket(Socket* serverSocket);

// Factory function that creates instances of the client Socket object.
SOCKETAPI Socket* __stdcall CreateClientSocket ();

//Function for releasing the client Socket object.
SOCKETAPI void __stdcall ReleaseClientSocket(Socket* clientSocket);
