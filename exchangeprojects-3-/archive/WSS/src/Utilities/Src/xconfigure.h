#if !defined(XCONFIGURE_H__DDCF0333_B3CA_11D2_86CF_004F49037CB3__INCLUDED_)
#define XCONFIGURE_H__DDCF0333_B3CA_11D2_86CF_004F49037CB3__INCLUDED_

#pragma once


#include <list>
#include <string>
#include <windows.h>


//Implementation header for configuration object class. This provides a useful
//wrapper around the WIN32 API registry/config.file access routines. The parameters
//to the constructor determine whether we use the registry or a config.file.
class xconfigure
{
public:

	xconfigure(const std::string& fileName, HKEY aKey=NULL);

	static bool		GetSubkeyName(const std::string& file, const std::string& section, const std::string& defaultSubkey, std::string& subkey);
	bool			GetParameterString(const std::string& section, const std::string& key, std::string& strReturnValue, bool bReportError=false) const;
	bool			GetStringWithDefault(const std::string& section, const std::string& key, const std::string &strDefault, std::string& strReturnValue, bool bReportError=false);
	bool			GetParameterLong(const std::string& section, const std::string& key, long& lReturnValue, bool bReportError = false);
	bool			GetLongWithDefault(const std::string& section,	const std::string& key,	long lDefault, long& lReturnValue, bool bReportError=false);
	bool			GetBoolean(const std::string& section, const std::string& key, bool& bReturn, bool bReportError = false);
	bool			GetBooleanWithDefault(const std::string& section, const std::string& key, bool bDefault, bool& bReturn, bool bReportError=false);


private:

	void			Initialise(const std::string& fileName);


public:

	bool			m_bFileOpened;


private:

	HKEY			m_RootKey;
	std::string		m_sFilePath;
};


#endif //XCONFIGURE_H__DDCF0333_B3CA_11D2_86CF_004F49037CB3__INCLUDED_