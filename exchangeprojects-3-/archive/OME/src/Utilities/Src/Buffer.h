#include "stdafx.h"


class CBuffer
{
private:
	char m_szBuffer[4096];
	int m_nSize;
public:
	CBuffer();
	~CBuffer();
	char *GetBuffer(int &size);
};