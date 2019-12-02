/********************************************************************************
xconfigure.cpp

Implementation source file for configuration object class. This provides a useful
wrapper around the WIN32 API registry/config.file access routines. The parameters
to the constructor determine whether we use the registry or a config.file.
********************************************************************************/
#include "stdafx.h"
#include <string>
#include "xstring_util.h"
#include "xconfigure.h"


//#ifdef _DEBUG
//#undef THIS_FILE
//static char THIS_FILE[]=__FILE__;
//#define new DEBUG_NEW
//#endif

const long BUFF_SIZE = 2048;





/*******************************************************************************
Constructor
-----------
This takes a file name and a root key name. If the file name is empty, data will
be accessed via the registry; otherwise, the file name will be expanded to the
full path and data accessed via the file.
*******************************************************************************/
xconfigure::xconfigure(const std::string& sFileName/*=""*/, HKEY aKey/*=NULL*/)
:	m_RootKey(aKey),
	m_bFileOpened(false)
{
	Initialise(sFileName);
}





/*******************************************************************************
Static Method GetSubkeyName
---------------------------
Try and get the name of the registry subkey from "aFileName" using aSectionName,
key "SubkeyName".
*******************************************************************************/
bool xconfigure::GetSubkeyName(const std::string& aFileName, const std::string& aSectionName, const std::string& defaultSubkeyName, std::string& subkeyName)
{
	std::string sFileName(aFileName);
	bool bAnswer = true;
	xconfigure aConfigObj(sFileName, NULL);
	subkeyName = defaultSubkeyName;

	if (aConfigObj.m_bFileOpened)
	{	
		if (!aConfigObj.GetParameterString(aSectionName, std::string("SubkeyName"), subkeyName))
		{
			subkeyName = defaultSubkeyName;
		}
	}
	else
	{
		bAnswer = false;
	}
	return bAnswer;
}





/*******************************************************************************
Initialise
----------
If the file name is empty, do nothing (we will use the registry and need no
initialisation); otherwise, expand the file name to the full path and check
that the file exists and can be opened for reading as a config file
*******************************************************************************/
void xconfigure::Initialise(const std::string& sFileName) 
{
	DWORD dwLen = 0;

	if ( ! sFileName.empty() )
	{
		char sz[BUFF_SIZE];

		if (sFileName.find('\\') == std::string::npos)
		{
#ifdef _UNICODE
			wchar_t wsz[BUFF_SIZE];
			dwLen = ::GetCurrentDirectory(BUFF_SIZE, wsz);
			wcstombs(sz, wsz, BUFF_SIZE);
#else
			dwLen = ::GetCurrentDirectory(BUFF_SIZE, sz);
#endif
			m_bFileOpened = (dwLen > 0);

			if ( m_bFileOpened )
			{
				m_sFilePath.assign(sz);
				m_sFilePath += '\\';
				m_sFilePath += sFileName;
			}
		}
		else
		{
			m_bFileOpened = true;
			m_sFilePath = sFileName;
		}

		if ( m_bFileOpened )
		{
#ifdef _UNICODE
			int iSize = m_sFilePath.size();
			wchar_t *wsz = new wchar_t[iSize + 1];
			mbstowcs(wsz, m_sFilePath.c_str(), iSize);
			wsz[iSize] = 0;

			HANDLE hFile = ::CreateFile(wsz,
										GENERIC_READ,
										FILE_SHARE_READ,
										NULL,
										OPEN_EXISTING,
										FILE_FLAG_RANDOM_ACCESS,
										NULL);
			delete[] wsz;
#else
			HANDLE hFile = ::CreateFile(m_sFilePath.c_str(),
										GENERIC_READ,
										FILE_SHARE_READ,
										NULL,
										OPEN_EXISTING,
										FILE_FLAG_RANDOM_ACCESS,
										NULL);
#endif

			m_bFileOpened = (hFile != INVALID_HANDLE_VALUE);

			if (m_bFileOpened)
				::CloseHandle(hFile);
		}
	}
}





/*******************************************************************************
GetParameterString
------------------
Get string value from the config. source. Note that to report errors we use the
GREPORT_ERR which does not require run-time type information. This is because
there is no rtti in C++ constructors (!!). 
*******************************************************************************/
bool xconfigure::GetParameterString(const std::string& strSection, const std::string& strKey, std::string& strReturnValue, bool bReportError/*=false*/) const
{
	bool bAnswer = false;
	std::string strDefault("");
	strReturnValue = "";

	if ( m_sFilePath != "" )
	{
		if ( ! m_bFileOpened )
		{
			return false;
		}
		char strOutBuff[BUFF_SIZE];
		strOutBuff[0] = '\0';

		if (strSection != "" && strKey != "") // These values crash the api call.
		{

#ifdef _UNICODE
			wchar_t wstrOutBuff[BUFF_SIZE];
			wstrOutBuff[0] = '\0';

			int iSize = strSection.size();
			wchar_t *wszSection = new wchar_t[iSize + 1];
			mbstowcs(wszSection, strSection.c_str(), iSize);
			wszSection[iSize] = 0;

			iSize = strKey.size();
			wchar_t *wszKey = new wchar_t[iSize + 1];
			mbstowcs(wszKey, strKey.c_str(), iSize);
			wszKey[iSize] = 0;

			iSize = strDefault.size();
			wchar_t *wszDefault = new wchar_t[iSize + 1];
			mbstowcs(wszDefault, strDefault.c_str(), iSize);
			wszDefault[iSize] = 0;

			iSize = m_sFilePath.size();
			wchar_t *wszFilePath = new wchar_t[iSize + 1];
			mbstowcs(wszFilePath, m_sFilePath.c_str(), iSize);
			wszFilePath[iSize] = 0;

			bAnswer = (GetPrivateProfileString(	wszSection,
												wszKey, 
												wszDefault,
												wstrOutBuff,
												sizeof(wstrOutBuff)/2,
												wszFilePath)
						!= 0);

			wcstombs(strOutBuff, wstrOutBuff, BUFF_SIZE);

			delete[] wszSection;
			delete[] wszKey;
			delete[] wszDefault;
			delete[] wszFilePath;
#else
			bAnswer = (GetPrivateProfileString(	strSection.c_str(),
												strKey.c_str(),
												strDefault.c_str(),
												strOutBuff,
												sizeof(strOutBuff), 
												m_sFilePath.c_str())
						!= 0);
#endif
		}
		strReturnValue = strOutBuff;
					
		if (!bAnswer && bReportError)
		{
			//TRACE("Cannot read ini file key: '%s' in section: '%s'", strKey, strSection);
		}
	}
	else
	{
		int iResult = 0;
		std::string subKeyName; 
		HKEY hKeyResult;
		char szValue[256];
		DWORD dwType, dwSize = sizeof(szValue);

		szValue[0] = 0;
#ifdef _UNICODE
		int iSize = strSection.size();
		wchar_t *wszSection = new wchar_t[iSize + 1];
		mbstowcs(wszSection, strSection.c_str(), iSize);
		wszSection[iSize] = 0;

		iResult = RegOpenKeyEx(m_RootKey, wszSection, 0, KEY_ALL_ACCESS, &hKeyResult);
	
		delete[] wszSection;
#else
		iResult = RegOpenKeyEx(m_RootKey, strSection.c_str(), 0, KEY_ALL_ACCESS, &hKeyResult);
#endif
		if (iResult != ERROR_SUCCESS)
		{
			if (bReportError)
			{
				//TRACE("Cannot open registry section named: '%s'", strSection);
			}
		}
		else  
		{
#ifdef _UNICODE
			wchar_t wszValue[256];

			int iSize = strKey.size();
			wchar_t *wszKey = new wchar_t[iSize + 1];
			mbstowcs(wszKey, strKey.c_str(), iSize);
			wszKey[iSize] = 0;

			iResult = RegQueryValueEx(hKeyResult, wszKey, NULL, &dwType, (BYTE*) wszValue, &dwSize);
		
			wcstombs(szValue, wszValue, dwSize);
			delete[] wszKey;
#else
			iResult = RegQueryValueEx(hKeyResult, strKey.c_str(), NULL, &dwType, (BYTE*) szValue, &dwSize);
#endif
			if (iResult != ERROR_SUCCESS) 
			{
				if (bReportError)
				{
					//TRACE("Cannot query registry value for key: '%s' in section: '%s'", strKey, strSection);
				}
			}
			else
			{
				bAnswer = true;
				strReturnValue = std::string(szValue);
			}
		} 
		RegCloseKey(hKeyResult);
	} 

	return bAnswer;
}





/*******************************************************************************
GetStringWithDefault
--------------------
As above but takes a default value to use if can't get the value from the
config. source
*******************************************************************************/
bool xconfigure::GetStringWithDefault(const std::string& strSection, const std::string& strKey, const std::string &strDefault, std::string& strReturnValue, bool bReportError/*=false*/)
{
	bool ok = GetParameterString(strSection, strKey, strReturnValue, bReportError);

	if (!ok)
	{
		strReturnValue = strDefault;
	}
	return ok;
}





/*******************************************************************************
GetParameterLong
----------------
Get long value from the config. source. Note that to report errors we use the
GREPORT_ERR which does not require run-time type information. This is because
there is no rtti in C++ constructors (!!). 
*******************************************************************************/
bool xconfigure::GetParameterLong(const std::string& strSection, const std::string& strKey, long& lReturnValue, bool bReportError/*=false*/)
{
	bool bAnswer = true;

	std::string strVal;

	bAnswer = GetParameterString ( 
				strSection, 
				strKey, 
				strVal,
				bReportError );

	lReturnValue = atoi(strVal.c_str());
	return bAnswer;
}





/*******************************************************************************
GetLongWithDefault
------------------
As above but takes a default value to use if can't get the value from the
config. source
*******************************************************************************/
bool xconfigure::GetLongWithDefault(const std::string& strSection, const std::string& strKey, long lDefault, long& lReturnValue, bool bReportError/*=false*/)
{
	bool ok = GetParameterLong(strSection, strKey, lReturnValue);

	if (!ok)
	{
		lReturnValue = lDefault;
	}
	return ok;
}





/*******************************************************************************
GetBoolean

Get boolean value from the config. source.

NOTES

1. We interpret a "boolean" string as follows:

   "yes", "y", "true", "t" or "1" => true
   "no", "n", "false", "f" or "0" => false

   String comparisons ignore case and leading and trailing white space.

2. To report errors we use the GREPORT_ERR which does not require run-time type
   information. This is because there is no rtti in C++ constructors (!!).
*******************************************************************************/
bool xconfigure::GetBoolean(const std::string& sSection, const std::string& sKey, bool& bReturn, bool bReportError/*=false*/)
{
	std::string sVal;

	bool ok = GetParameterString(sSection, sKey, sVal, bReportError);

	if (ok)
	{
		stl::utility::strTrim(sVal);

		if (_stricmp(sVal.c_str(), "yes") == 0 ||
			_stricmp(sVal.c_str(), "y") == 0 ||
			_stricmp(sVal.c_str(), "true") == 0 ||
			_stricmp(sVal.c_str(), "t") == 0 ||
			_stricmp(sVal.c_str(), "1") == 0)
		{
			bReturn = true;
		}
		else if (_stricmp(sVal.c_str(), "no") == 0 ||
			_stricmp(sVal.c_str(), "n") == 0 ||
			_stricmp(sVal.c_str(), "false") == 0 ||
			_stricmp(sVal.c_str(), "f") == 0 ||
			_stricmp(sVal.c_str(), "0") == 0)
		{
			bReturn = false;
		}
		else
		{
			ok = false;
		}

		if (!ok && bReportError)
		{
			//TRACE("Could not interpret boolean value in configuration source");
		}
	}

	return ok;
}





/*******************************************************************************
GetBooleanWithDefault

As GetBoolean, but uses a default value if there are problems
*******************************************************************************/
bool xconfigure::GetBooleanWithDefault(const std::string& sSection, const std::string& sKey, bool bDefault, bool& bReturn, bool bReportError/*=false*/)
{
	bool ok = GetBoolean(sSection, sKey, bReturn, bReportError);

	if ( ! ok )
	{
		bReturn = bDefault;
	}
	return ok;
}