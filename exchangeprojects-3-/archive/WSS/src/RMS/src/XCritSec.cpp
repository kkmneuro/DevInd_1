#include "stdafx.h"
#include "xcritsec.h"


CXCritSec::CXCritSec()
{
	::InitializeCriticalSectionAndSpinCount(&m_crit, 4000);
}
      
CXCritSec::~CXCritSec()
{
	::DeleteCriticalSection(&m_crit);
}

void CXCritSec::Enter()
{
	::EnterCriticalSection(&m_crit);
}

void CXCritSec::Leave()
{
	::LeaveCriticalSection(&m_crit);
}



CXCritSec::CLocker::CLocker(CXCritSec &crit): m_crit(crit)
{
	m_crit.Enter();
}

CXCritSec::CLocker::~CLocker()
{
	m_crit.Leave();
}