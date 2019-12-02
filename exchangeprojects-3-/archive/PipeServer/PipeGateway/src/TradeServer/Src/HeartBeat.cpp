#include "ConnectionMgr.h"
#include "xlogger.h"
HeartBeat::HeartBeat(ConnectionMgr* connectionMgr, unsigned int intervalSec)
{
	m_connectionMgr=connectionMgr;
	m_intervalSec=intervalSec;
}
HeartBeat::~HeartBeat()
{
}
unsigned int _stdcall HeartBeat::SendHeartBeat(void* arg)
{
	/*HeartBeat* pThis=(HeartBeat*) arg;
	while(pThis->m_start)
	{
		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_DEBUG, "Inside While Loop in HeartBeat::SendHeartBeat  m_start");
		Sleep(pThis->m_intervalSec*1000);
	}*/
	return 0;
}

unsigned int HeartBeat::GetInterval()
{
	return m_intervalSec;
}

bool HeartBeat::Start()
{
	m_start=1;
	//Start Thread
	return true;
}
void HeartBeat::Stop()
{
	m_start=0;
	::Sleep(1000);
	//Stop Thread
}

