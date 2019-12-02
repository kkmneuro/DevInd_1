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


#pragma once


#define MAX_BUFF_SIZE		4096
#define MED_BUFF_SIZE		1024
#define MIN_BUFF_SIZE		128


class CBuffer;
class CBufferW;


#if _UNICODE
	typedef CBufferW CBufferT;
#else
	typedef CBuffer CBufferT;
#endif


class CBuffer
{
protected:

	char*			m_pBuff;

	unsigned int	m_uiSize;
	unsigned int	m_uiCurrLen;


public:

	CBuffer(unsigned int uiSize);
	CBuffer();
	~CBuffer();

	bool Alloc(unsigned int uiSize);
	bool Realloc(unsigned int uiSizeToAdd);
	void Free();

	unsigned int GetCurrLen();
	unsigned int GetSize();

	void SetCurrLen(unsigned int uiLen);
	void Reset();

	unsigned int Append(const char* pData, unsigned int uiLen);
	unsigned int Append(const char* pData); //treat as NULL terminated
	unsigned int Append(CBuffer& myBuff);
	bool Append(char ch);

	unsigned int Assign(CBuffer& myBuff);
	unsigned int Assign(const char* pData, unsigned int uiLen);

	void Erase(unsigned uiCount, unsigned uiStart = 0);

	char* GetPTR(unsigned int uiStart=0);
	//const char* GetConstPTR(unsigned int uiStart=0);
};



#if _UNICODE

class CBufferW
{
protected:

	wchar_t*		m_pBuff;

	unsigned int	m_uiSize;
	unsigned int	m_uiCurrLen;


public:

	CBufferW(unsigned int uiSize);
	CBufferW();
	~CBufferW();
	
	bool Alloc(unsigned int uiSize);
	void Free();
	
	unsigned int GetCurrLen();
	unsigned int GetSize();

	void SetCurrLen(unsigned int uiLen);
	void Reset();

	unsigned int Append(const wchar_t* pData, unsigned uiLen);
	unsigned int Append(const wchar_t* pData);
	unsigned int Append(CBufferW& myBuff);
	bool Append(wchar_t ch);

	unsigned int Assign(CBufferW& myBuff);
	unsigned int Assign(const wchar_t *pData);
	unsigned int Assign(const wchar_t *pData, unsigned int uiLen);

	void Erase(unsigned uiCount, unsigned uiStart);	

	wchar_t* GetPTR(unsigned int uiStart=0);
};

#endif