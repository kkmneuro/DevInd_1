#pragma once

#define VALID(h)							( (h) != 0 && (h) != INVALID_HANDLE_VALUE )
#define COMPKEY_CLOSE						((DWORD) -1L)
#define COMPKEY_CLOSE_SOCKET				((DWORD) -2L)

enum IOType	
{	
	CLOSED,
	CONNECTING,
	ACCEPTING, 
	READING, 
	WRITING 
};

struct OVERLAPPEDPLUS: public OVERLAPPED
{
	static const int				addrlen;
	static const int				initialReceiveSize;
	const enum						{ bs = 4096 };
	
	SOCKET							s;						// the connection's socket handle
	sockaddr_in						local, peer;			// addresses
	IOType							ioType;					// what the connection is doing
	DWORD							n;						// number of bytes received or sent
	OVERLAPPEDPLUS*					sendOv;
	OVERLAPPEDPLUS*					recOv;
	HANDLE							available;
	bool							valid;

	char*							recBuf;					// receive buffer
	char*							sendBuf;				// Send buffer
	WSABUF							sendBufferDescriptor;	
	WSABUF							recvBufferDescriptor;	
	DWORD							recvFlags;				// needed by WSARecv()
	unsigned long long				pkID;

	OVERLAPPEDPLUS()
	{ 
		s = SOCKET_ERROR;
		valid=false;
		ioType = CLOSED; 
		
		sendOv = 0;
		recOv = 0;
		recBuf=0;
		sendBuf=0;

		Internal = InternalHigh = Offset = OffsetHigh = 0; 
		hEvent = 0; 
		available=CreateEvent(NULL,true,false,NULL);
	}

	OVERLAPPEDPLUS( const OVERLAPPEDPLUS &o )
	{
		s = o.s;
		valid=o.valid;
		local = o.local;
		peer = o.peer;
		ioType = o.ioType;

		sendOv = 0;
		recOv = 0;
		recBuf = 0;
		sendBuf = 0;

		Internal = InternalHigh = Offset = OffsetHigh = 0; 
		hEvent = 0; 
		available=CreateEvent(NULL,true,false,NULL);//Auto Reset Event
	}
	OVERLAPPEDPLUS& operator =(const OVERLAPPEDPLUS &o)
	{
		s = o.s;
		valid=o.valid;
		local = o.local;
		peer = o.peer;
		ioType = o.ioType;

		return *this;
	}

	~OVERLAPPEDPLUS() { } 
};

typedef map<unsigned int,OVERLAPPEDPLUS *>				OVERLAPPEDPLUS_MAP;
typedef OVERLAPPEDPLUS_MAP::iterator					OVERLAPPEDPLUS_MAP_ITER;

typedef vector< HANDLE >								HANDLE_VEC;
typedef HANDLE_VEC::iterator							HANDLE_VEC_ITER;
