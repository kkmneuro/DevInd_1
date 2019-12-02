#include "buffer.h"

CBuffer::CBuffer()
{
	m_nSize = 4096;
}

char *CBuffer::GetBuffer(int &size)
{
	size = m_nSize;

	return m_szBuffer;
}

CBuffer::~CBuffer()
{
}
