////////////////////////////////////////////////////////////////////////////////
// H. Seldon 02.06.11
// http://veridium.net
// hseldon@veridium.net
//
// This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.


#include "stdafx.h"
#include <string.h>

#include "Buffer.h"


CBuffer::CBuffer()
{	
	m_uiSize	= 0;
	m_uiCurrLen	= 0;
	m_pBuff		= NULL;


	if (m_pBuff = new char[MAX_BUFF_SIZE])
	{
		memset(m_pBuff, 0, MAX_BUFF_SIZE);
		m_uiSize = MAX_BUFF_SIZE;
	}
}

CBuffer::CBuffer(unsigned uiSize)
{		
	m_uiSize	= 0;
	m_uiCurrLen = 0;
	m_pBuff		= NULL;


	if (uiSize <= 0) 
		return;


	if (m_pBuff	= new char[uiSize])
	{
		memset(m_pBuff, 0, uiSize);
		m_uiSize	= uiSize;
	}
}

CBuffer::~CBuffer()
{
	Free();
}

bool CBuffer::Alloc(unsigned uiSize)
{
	if (uiSize <= 0)	return false;
	if (m_pBuff)		return false;


	if(!(m_pBuff = new char[uiSize]))
		return false;


	m_uiSize	= uiSize;
	m_uiCurrLen = 0;


	memset(m_pBuff, 0, uiSize);


	return true;
}


bool CBuffer::Realloc(unsigned uiSizeToAdd)
{
	char* pBuff			= NULL;
	unsigned uiLenCurr	= GetCurrLen();
	unsigned uiSizeNew	= uiLenCurr + uiSizeToAdd;


	if (!(pBuff = new char[uiSizeNew]))
		return false;


	memset(pBuff, 0, uiSizeNew);
	memcpy(pBuff, m_pBuff, uiLenCurr);


	Free();


	m_pBuff		= pBuff;
	m_uiSize	= uiSizeNew;
	m_uiCurrLen	= uiLenCurr;


	return true;
}


void CBuffer::Free()
{
	if(!m_pBuff) return;

	delete[] m_pBuff;
	m_pBuff	= NULL;

	m_uiSize	= 0;
	m_uiCurrLen = 0;
}


unsigned int CBuffer::GetSize()
{
	return m_uiSize;
}


unsigned int CBuffer::GetCurrLen()
{
	return m_uiCurrLen;
}


void CBuffer::SetCurrLen(unsigned int uiLen)
{
	if (uiLen > m_uiSize)
		return;
		
	m_uiCurrLen = uiLen;
}


void CBuffer::Reset()
{
	if (m_uiCurrLen == 0) 
		return;

	memset(m_pBuff, 0, m_uiSize);
	m_uiCurrLen = 0;
}


unsigned int CBuffer::Append(const char *pData)
{
	unsigned uiLen = strlen(pData);

	if (!pData || uiLen == 0 || m_uiSize == 0) return 0;


	unsigned int uiLenToCopy = (uiLen + m_uiCurrLen + 1 > m_uiSize)? m_uiSize - (m_uiCurrLen + 1) : uiLen;

	memcpy(m_pBuff+m_uiCurrLen, pData, uiLenToCopy);
	m_uiCurrLen += uiLenToCopy;
	m_pBuff[m_uiCurrLen] = 0;
	

	return uiLenToCopy;
}


unsigned int CBuffer::Append(const char *pData, unsigned int uiLen)
{
	if (!pData || uiLen == 0 || m_uiSize == 0) return 0;


	// One extra byte just in case caller is confused on 0 based count

	unsigned int uiLenToCopy = (uiLen + m_uiCurrLen + 1 > m_uiSize)? m_uiSize - (m_uiCurrLen + 1) : uiLen;

	memcpy(m_pBuff+m_uiCurrLen, pData, uiLenToCopy);
	m_uiCurrLen += uiLenToCopy;
	

	return uiLenToCopy;
}


unsigned int CBuffer::Append(/*const */CBuffer& myBuff)
{
	return Append(myBuff.GetPTR(), myBuff.GetCurrLen());
}


unsigned int CBuffer::Assign(CBuffer& myBuff)
{
	Reset();
	return Append(myBuff.GetPTR(), myBuff.GetCurrLen());
}


unsigned int CBuffer::Assign(const char *pData, unsigned int uiLen)
{
	Reset();
	return Append(pData, uiLen);
}


bool CBuffer::Append(char ch)
{
	if (m_uiCurrLen + 1 + 1 > m_uiSize) return false;

	*(m_pBuff+m_uiCurrLen) = ch;
	m_uiCurrLen++;

	return true;
}


void CBuffer::Erase(unsigned int uiCount, unsigned int uiStart)
{
	if (uiStart + uiCount > m_uiCurrLen) return;

	memmove(m_pBuff + uiStart,
		m_pBuff + uiStart + uiCount,
		m_uiCurrLen - (uiStart + uiCount));

	SetCurrLen(m_uiCurrLen - uiCount);
}


char* CBuffer::GetPTR(unsigned int uiStart)
{
	return m_pBuff+uiStart;
}

//const char* CBuffer::GetConstPTR(unsigned int uiStart)
//{
//	return m_pBuff+uiStart;
//}


#if _UNICODE

#include <tchar.h>


CBufferW::CBufferW()
{		
	m_uiSize	= 0;
	m_uiCurrLen = 0;
	m_pBuff		= NULL;


	if (m_pBuff = new wchar_t[MAX_BUFF_SIZE])
	{	
		memset(m_pBuff, 0, MAX_BUFF_SIZE*sizeof(wchar_t));
		m_uiSize = MAX_BUFF_SIZE;
	}
}

CBufferW::CBufferW(unsigned uiSize)
{
	m_uiCurrLen = 0;
	m_uiSize	= 0;
	m_pBuff		= NULL;


	if (uiSize <= 0) return;


	if (m_pBuff = new wchar_t[uiSize])
	{
		memset(m_pBuff, 0, uiSize*sizeof(wchar_t));
		m_uiSize	= uiSize;
	}
}

CBufferW::~CBufferW()
{
	Free();
}

bool CBufferW::Alloc(unsigned uiSize)
{
	if (uiSize <= 0)	return false;
	if (m_pBuff)		return false;


	if (!(m_pBuff = new wchar_t[uiSize]))
		return false;


	m_uiSize = uiSize;
	memset(m_pBuff, 0, uiSize * sizeof(wchar_t));


	return true;
}

void CBufferW::Free()
{
	if(!m_pBuff) return;

	delete[] m_pBuff;
	m_pBuff	= NULL;

	m_uiSize	= 0;
	m_uiCurrLen = 0;
}

unsigned int CBufferW::GetSize()
{
	return m_uiSize;
}

unsigned int CBufferW::GetCurrLen()
{
	return m_uiCurrLen;
}

void CBufferW::SetCurrLen(unsigned int uiLen)
{
	if (uiLen < m_uiSize) m_uiCurrLen = uiLen;
}

void CBufferW::Reset()
{
	//if (m_uiCurrLen == 0) 
	//	return;

	memset(m_pBuff, 0, m_uiSize * sizeof(wchar_t));
	m_uiCurrLen = 0;
}


unsigned int CBufferW::Append(const wchar_t *pData)
{
	unsigned uiLen = wcslen(pData);

	if (!pData || uiLen == 0 || m_uiSize == 0) return 0;

	unsigned int uiLenToCopy = (uiLen + m_uiCurrLen + 1 > m_uiSize)? m_uiSize - (m_uiCurrLen + 1) : uiLen;

	memcpy(m_pBuff+m_uiCurrLen, pData, uiLenToCopy*sizeof(wchar_t));
	m_uiCurrLen += uiLenToCopy;
	m_pBuff[m_uiCurrLen] = 0;

	return uiLenToCopy;
}


unsigned int CBufferW::Append(const wchar_t *pData, unsigned int uiLen)
{
	if (!pData || uiLen == 0 || m_uiSize == 0) return 0;

	unsigned int uiLenToCopy = (uiLen + m_uiCurrLen + 1 > m_uiSize)? m_uiSize - (m_uiCurrLen + 1) : uiLen;

	memcpy(m_pBuff+m_uiCurrLen, pData, uiLenToCopy * sizeof(wchar_t));
	m_uiCurrLen += uiLenToCopy;

	return uiLenToCopy;
}


unsigned int CBufferW::Append(CBufferW& myBuff)
{
	return Append((wchar_t*)myBuff.GetPTR(), myBuff.GetCurrLen());
}

unsigned int CBufferW::Assign(CBufferW& myBuff)
{
	Reset();
	return Append((wchar_t*)myBuff.GetPTR(), myBuff.GetCurrLen());
}

unsigned int CBufferW::Assign(const wchar_t *pData)
{
	Reset();
	return Append(pData, _tcslen(pData));
}

unsigned int CBufferW::Assign(const wchar_t *pData, unsigned int uiLen)
{
	Reset();
	return Append(pData, uiLen);
}

bool CBufferW::Append(wchar_t ch)
{
	if (m_uiCurrLen + 1 + 1 > m_uiSize) return false;

	*(m_pBuff + m_uiCurrLen) = ch;
	m_uiCurrLen++;

	return true;
}


void CBufferW::Erase(unsigned int uiCount, unsigned int uiStart)
{
	if (uiStart + uiCount > m_uiCurrLen) return;

	memmove(m_pBuff + uiStart,
		m_pBuff + uiStart + uiCount,
		(m_uiCurrLen - (uiStart + uiCount)) * sizeof(wchar_t));

	SetCurrLen(m_uiCurrLen - uiCount);
}


wchar_t* CBufferW::GetPTR(unsigned int uiStart)
{
	return m_pBuff+uiStart;
}

#endif