#pragma once
#include <stdio.h>

class Logger
{
private:
	FILE* pFile;
public:
	Logger()
	{
		SYSTEMTIME sysTime;
		GetSystemTime(&sysTime);
		char fileName[MAX_PATH];
		sprintf_s(fileName,MAX_PATH,"OME_LOGS_%d_%d_%d.txt",sysTime.wYear,sysTime.wMonth,sysTime.wDay);
		pFile = fopen(fileName, "a"); 

	}
	~Logger()
	{
		fclose(pFile);
	}
	BOOL WriteLog(char* msg)
	{
		SYSTEMTIME sysTime;
		GetSystemTime(&sysTime);
		char msgText[4096];

		sprintf_s(msgText,4096,"[%d:%d:%d.%d ] %s \n",sysTime.wHour,sysTime.wMinute,sysTime.wSecond,sysTime.wMilliseconds,msg);
		int i=fputs(msgText,pFile);
		return i!=EOF;
	}
};