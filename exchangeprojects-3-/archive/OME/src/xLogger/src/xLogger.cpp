#include "stdafx.h"
#include <direct.h>
#include <windows.h>

#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>

#include <string>
#include <process.h>
#include "xlogger.h"


#pragma comment(lib, "winmm.lib" )
#ifdef _MIXED_MANAGED
#pragma unmanaged
#endif

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

#define MAX_LOGFILES 10		// maximum number of log files

stl::log::xlogger _logger;	// the one and only instance of xlogger
std::string	stl::log::xlogger::comma = ", ";


 HANDLE hEvent;

//***********************************************************************************************//
// stl::getdir()
//
//		get current working directory.
//
// RETURN VALUE:
//
//		current working directory in unicode std string
//
// PARAMETERS:
//
// REMARKS:
//
// NOTE:
//
//		1. Local definition to check which os platform is running for std library function "getcwd"
//
#define PLATFORM_WINDOWS
//
//		2. other platforms except windows support non-unicode directory folder.
//
//***********************************************************************************************//
TCHAR* stl::system::getdir() throw()
{
try
{
	std::wstring workingdirectory;

#ifdef PLATFORM_WINDOWS

//	char dir[MAX_PATH];
//	wchar_t dir[MAX_PATH];
	TCHAR dir[MAX_PATH];
	
//	if (  getcwd(dir, MAX_PATH)!=NULL )
//	if ( _getcwd(dir, MAX_PATH)!=NULL )
//	if ( _wgetcwd(dir, MAX_PATH)!=NULL )
	if ( _tgetcwd(dir, MAX_PATH)!=NULL )
	{
		//workingdirectory = stl::to_wstring(dir);
	}
#else

	char dir[_MAX_PATH];

	if ( getcwd(dir, _MAX_PATH)!=0 )
	{
		workingdirectory = stl::to_wstring(dir);
	}
#endif

	//return workingdirectory;
	return dir;
}
catch (...)
{
	return "";
}
}




#ifdef COMMENTED
bool stl::log::getlogfilename(std::wstring& logfilename)
{
	_logger.lock();
	logfilename = _logger._logfolder + _T("\\") + _logger._logfile;
	_logger.unlock();

	return !logfilename.empty();
}

bool stl::log::getlogfolder(std::wstring& logfolder)
{
	_logger.lock();
	logfolder = _logger._logfolder;
	_logger.unlock();

	return !logfolder.empty();
}

bool stl::log::getlogfile(std::wstring& logfile)
{
	_logger.lock();
	logfile = _logger._logfile;
	_logger.unlock();

	return !logfile.empty();
}








void stl::log::trace(const stl::xerror& error, std::wstring& loggedfile)
{
	std::string log;

	log += error.what_();
	log += error.route_();

	_logger.lock();

	if ( _logger.trace(log) )
	{
		loggedfile = _logger._logfolder + L"\\" + _logger._logfile;
	}
	_logger.unlock();
}
#endif


void stl::log::setlogfolder( LPCTSTR logfolder)
{
	_logger.lock();
	_logger.setlogfolder(logfolder);
	_logger.unlock();
}

void stl::log::setlogfileprefix( LPCTSTR fileprefix)
{
	_logger.lock();
	_logger.setlogfileprefix(fileprefix);
	_logger.unlock();
}


void stl::log::setLogLevel(UINT nLevel)
{
	_logger.lock();
	_logger.SetTraceLevel(nLevel);
	_logger.unlock();
}


bool stl::log::trace( const std::string& log, UINT group,UINT level/*==TraceDebug*/)
{
	//return true;
	bool logged = false;
	try
	{
		if ( _logger._level != TraceNone )
		if ( _logger._level >= level || level == TraceAlways )
		{
			_logger.lock();
			//logged = _logger.trace(log);
			logged = _logger.append( group, log );
			_logger.unlock();
		}
	}
	catch (...)
	{
		//printf( "xlogger::write.ex\n" );
	}

	return logged;
}

bool stl::log::trace( UINT group, UINT level, LPCTSTR format,...)
{
	//return true;
	bool logged = false;
	try
	{
		if ( _logger._level != TraceNone )
		if ( _logger._level >= level || level == TraceAlways )
		{
			va_list args;
			int len;
			//TCHAR * buffer = NULL;

			va_start( args, format );
			len = _vscprintf( format, args ) // _vscprintf doesn't count
									   + 1; // terminating '\0'
			//buffer = (TCHAR*)malloc( len * sizeof(TCHAR) );
			
			TCHAR	buffer[8000];
			memset(buffer,0,len * sizeof(TCHAR));
			vsprintf( buffer, format, args );
			
			

			_logger.lock();
			//logged = _logger.trace( buffer );
			logged = _logger.append( group, buffer );
			_logger.unlock();

		//	free( buffer );
		}
	}
	catch (...)
	{
		//printf( "xlogger::write.ex\n" );
	}


	return logged;
}

bool stl::log::write()
{	
	//_logger.lock();
	//logged = _logger.trace(log);
	bool logged = _logger.write( );
	//_logger.unlock();
	
	return logged;
}

bool stl::log::close()
{	
	return _logger.close();
	
}


bool stl::log::isActive()
{	
	return _logger.isActive();
}



//************************************************************************
// All these functions will write to the std output window, and append a carriage return
bool bDebugOn = false;

void stl::log::setDebugStringOn()
{
	bDebugOn=true;
}





void stl::log::setDebugStringOff()
{
	bDebugOn=false;
}





void stl::log::debugString(const char * szMsg)
{
	if (bDebugOn)
	{
		OutputDebugString(szMsg);
		OutputDebugString("\n");
	}
}





void stl::log::debugString(const std::string& szMsg)
{
	if (bDebugOn)
	{
		OutputDebugString(szMsg.c_str());
		OutputDebugString("\n");
	}
}





#ifdef COMMENTED
void stl::log::debugString(const CString& szMsg)
{
	if (bDebugOn)
	{
		OutputDebugString(szMsg.operator LPCTSTR());
		OutputDebugString("\n");
	}
}
#endif



DWORD WINAPI LogWriter( LPVOID lpParam ) 
{ 
	
    while( stl::log::isActive() )
	{
		WaitForSingleObject( hEvent, INFINITE );
		ResetEvent(hEvent);
		stl::log::write();
		
	//	Sleep(500);
    }

	/*printf( "LogWriter processing last records...\n" );*/

	// write the remaining logs
	bool bContinue = false;

	do
	{
		bContinue = stl::log::write();
		Sleep(100);
	}
	while ( bContinue );

	/*printf( "LogWriter processing last records over\n" );*/

	return 0; 
} 


stl::log::xlogger::xlogger()
:	_hAuditFile(NULL),
	_hErrorFile( NULL ),
	_level(stl::log::TraceNone),
	m_nThreadId(NULL),
	isActiveFlag( true )
	//, m_auditLogList( MAX_RECORDS )
	//, m_errorLogList( MAX_RECORDS )
		
{
	::InitializeCriticalSection(&_cs);

	// read the settings
	TCHAR moduleFolder[MAX_PATH];

	GetModuleFileName( NULL, moduleFolder, MAX_PATH );
	TCHAR * fileName = (TCHAR *)_tcsrchr( moduleFolder, '\\' );
	*fileName = 0;

	_tcscat( moduleFolder, "\\xlogger.ini" );
	//_tcscat( moduleFolder, 
	
	TCHAR settingBuffer[MAX_PATH];
	DWORD result  = GetPrivateProfileString( _T("xlogger")
							, _T("path")
							, _T( ".\\")
							, settingBuffer
							, MAX_PATH
							, moduleFolder );
	setlogfolder( settingBuffer );
	
	result  = GetPrivateProfileString( _T("xlogger")
							, _T("prefix")
							, _T( "xlogger_pre_")
							, settingBuffer
							, MAX_PATH
							, moduleFolder );
	setlogfileprefix( settingBuffer );

	UINT logLevel = GetPrivateProfileInt( _T("xlogger")
							, _T("log_level")
							, 0
							, moduleFolder );
	
	setLogLevel( logLevel );
	
	m_MaxSizeKB = GetPrivateProfileInt( _T("xlogger")
							, _T("max_size")
							, 1024
							, moduleFolder );
	
	// start the writer thread
	    m_hWriterThread = CreateThread( 
            NULL,                   // default security attributes
            0,                      // use default stack size  
            LogWriter,       // thread function name
            NULL,          // argument to thread function 
            0,                      // use default creation flags 
            &m_dwWriterThreadId );   // returns the thread identifier 


        // Check the return value for success.
        // If CreateThread fails, terminate execution. 
        // This will automatically clean up threads and memory. 

        if ( m_hWriterThread == NULL ) 
        {
           //ErrorHandler(TEXT("CreateThread"));
           //ExitProcess(3);
        }
		hEvent = CreateEvent( NULL, FALSE, TRUE, NULL );
		ResetEvent(hEvent);
}





stl::log::xlogger::xlogger(LPCTSTR logfolder, LPCTSTR prefix)
		: _hAuditFile( NULL )
		, _hErrorFile( NULL )
		, _level(stl::log::TraceNone)
		, m_nThreadId(NULL)
		, m_auditLogList( MAX_RECORDS )
		, m_errorLogList( MAX_RECORDS )
		, isActiveFlag( true )
{
	setlogfolder(logfolder);
	setlogfileprefix(prefix);

	::InitializeCriticalSection(&_cs);
}





stl::log::xlogger::~xlogger()
{
	closefile();

	::DeleteCriticalSection(&_cs);
}




#define AUDIT_FOLDER_NAME "audit"
#define ERROR_FOLDER_NAME "error"

bool stl::log::xlogger::openfile()		// open a new trace file
{
	closefile();

	if ( _logfolder && _tcslen( _logfolder ))
	{
		SYSTEMTIME sysTime;
		::GetLocalTime(&sysTime);

		TCHAR auditFolder[MAX_PATH]={0};
		TCHAR errorFolder[MAX_PATH]={0};
		
		_stprintf(	auditFolder,
					_T("%s\\%s"),
					_logfolder,
					AUDIT_FOLDER_NAME);

		_stprintf(	errorFolder,
					_T("%s\\%s"),
					_logfolder,
					ERROR_FOLDER_NAME);


		_tmkdir ( auditFolder );
		_tmkdir ( errorFolder );

		TCHAR pszFileName[MAX_PATH];
		_stprintf(	pszFileName,
					_T("%s%04d%02d%02d_%02d%02d%02d_%d.txt"),
					_logfileprefix,
					sysTime.wYear,
					sysTime.wMonth,
					sysTime.wDay,
					sysTime.wHour,
					sysTime.wMinute,
					sysTime.wSecond,
					::GetCurrentProcessId() );

		_tcscpy( _logfile , pszFileName );

		TCHAR file[MAX_PATH];
		_stprintf(	file
					, _T("%s\\%s")
					, auditFolder
					, _logfile );

		_hAuditFile = _tfopen( file, _T("a+"));

		_stprintf(	file
					, _T("%s\\%s")
					, errorFolder
					, _logfile );

		_hErrorFile = _tfopen( file, _T("a+"));


		if ( _hAuditFile && _hErrorFile )
		{
			m_timeStart = sysTime;
		}
	}
	return ( _hAuditFile && _hErrorFile );
}





void stl::log::xlogger::closefile()
{
	if ( _hAuditFile )
	{
		fclose(_hAuditFile);
	}

	if ( _hErrorFile )
	{
		fclose(_hErrorFile);
	}

	_hAuditFile = NULL;
	_hErrorFile = NULL;
}



bool stl::log::xlogger::close()
{	
	isActiveFlag = false;
	// wait for 1 minute max
	DWORD result = WaitForSingleObject( this->m_hWriterThread, ( 60*1000 ) );
	return( !result );
}


bool stl::log::xlogger::isActive()
{	
	return isActiveFlag;
}



//***********************************************************************************************//
// stl::log::xlogger::trace()
//
// RETURN VALUE:
//
// PARAMETERS:
//
// REMARKS:
//
// NOTE:
//
//***********************************************************************************************//
bool stl::log::xlogger::write() throw()
{
	//printf( "xlogger::write...\n" );
	bool result = false;
	try
	{
		if( !m_auditLogList.empty() || !m_errorLogList.empty() )
		{
			//printf( "xlogger::write.found\n" );
			// open the trace file if not already open
			if ( ( _hAuditFile==NULL ) || ( _hErrorFile==NULL ) )
			{
				openfile();
			}
			// if it is already a new day, close the old trace file and open a new one
			else 
			{
				SYSTEMTIME dt;
				::GetLocalTime(&dt);

				if ( dt.wYear!=m_timeStart.wYear 
					|| dt.wMonth!=m_timeStart.wMonth 
					|| dt.wDay!=m_timeStart.wDay )
				{
					closefile();
					openfile();
				}
			}

			//m_HiResTime.current(&m_rST);  

			while ( ( !m_auditLogList.empty() ) &&  _hAuditFile )
			{
				//printf( "xlogger::write.file OK\n" );
			//	lock();

				LPCTSTR record = m_auditLogList.front();
				m_auditLogList.pop_front();
				
			//	unlock();

				fwrite( record, sizeof(TCHAR), _tcslen( record ), _hAuditFile );
				fflush(_hAuditFile);
				//free ( (LPVOID)record );
				//printf( "xlogger::write OK\n" );
				record = NULL;
				result = true;
				ResetEvent(hEvent);
			//	Sleep(10);
			}

			while ( ( !m_errorLogList.empty() ) &&  _hErrorFile )
			{
				//printf( "xlogger::write.file OK\n" );
			//	lock();
				ResetEvent(hEvent);
				LPCTSTR record = m_errorLogList.front();
				m_errorLogList.pop_front();
			    fwrite( record, sizeof(TCHAR), _tcslen( record ), _hErrorFile );
				fflush(_hErrorFile);
			//	free ( (LPVOID)record );
				record = NULL;
				result  = true;
			//	unlock();
			//	Sleep(10);
			}
		}
	}
	catch (...)
	{
		//printf( "xlogger::write.ex\n" );
	}

	//printf( "xlogger::write\n" );
	return result;
}

bool stl::log::xlogger::append( UINT group, const std::string& log ) throw()
{
	try
	{
		
		SYSTEMTIME dt;
		::GetLocalTime(&dt);
	/*	if( m_errorLogList.size()>0) 
		{
				Sleep(1500);
		}
	*/	

		//m_HiResTime.current(&m_rST);  
		
		int pos = _stprintf( m_pBuffer
							, _T("%02d:%02d:%02d_%03d_%X: ")
							, dt.wHour
							, dt.wMinute
							, dt.wSecond
							, m_rST.wMilliseconds
							, m_nThreadId );

		pos = _stprintf(m_pBuffer + pos, _T("%s\n"), log.c_str());

		
		//TCHAR * record = (TCHAR*)malloc( ( _tcslen( m_pBuffer ) + 1 ) * sizeof(TCHAR) ); 
		
		memset(record,0,( _tcslen( m_pBuffer ) + 1 ) * sizeof(TCHAR));
	
		int iError = strcpy_s( record, ( _tcslen( m_pBuffer ) + 1 ) * sizeof(TCHAR) , m_pBuffer);
		
		switch( group )
		{
			case LOG_GROUP_AUDIT:
			{
			m_auditLogList.push_back( record );
			stl::log::xlogger::write();
			break;
			}

			case LOG_GROUP_ERROR:
			{
			m_errorLogList.push_back( record );
			stl::log::xlogger::write();
			break;
			}
		}

	//	SetEvent( hEvent );
		
		return true;
		

	}
	catch (...)
	{
		return false;
	}
	
	return false;
}



void stl::log::xlogger::setlogfolder(LPCTSTR logfolder)
{
	if ( logfolder && _tcslen( logfolder ) )
	if ( !_tcscmp( _logfolder ,logfolder ) )
	if ( _hAuditFile!=NULL )
	{
		//If the log file is already open and the name has not changed - do nothing
		return;
	}

	closefile();

	_tcscpy( _logfolder, logfolder );
	_tmkdir( _logfolder );
}





	// set the current trace level
void stl::log::xlogger::SetTraceLevel(UINT level)
{
	_level = level > 0 ? level : 0;
}





	// set the trace file name prefix
void stl::log::xlogger::setlogfileprefix( LPCTSTR prefix )
{
	if ( _logfileprefix && _tcslen( _logfileprefix ) )
	if ( !_tcscmp( _logfileprefix, prefix ) )
	if ( _hAuditFile!=NULL )
	{
		//If the log file is already open and the name has not changed - do nothing
		return;
	}

	// close existing trace file first
	closefile();

	_tcscpy(_logfileprefix, prefix );
}





void stl::log::xlogger::lock()			// set lock to gain exclusive access to trace functions
{
	EnterCriticalSection(&_cs);

	m_nThreadId = ::GetCurrentThreadId();
}





void stl::log::xlogger::unlock()		// release lock so that other threads can access trace functions
{
	LeaveCriticalSection(&_cs);
}




#ifdef COMMENTED

//************************************************************************
//				CRulesManager and CMediaRules implementation				 //
// Method Name:			Initialise
//
// Remarks:				Initialises the rules collection by extracting them from a 'Rules Source'
//						The source can be anything - registry, config file, xml data. However, 
//						the rules are hard-coded now within the application.
//************************************************************************
void stl::log::CRulesManager::CMediaRules::Initialise()
{
	// Add a simple rule
	Rule aRule;
	aRule.m_ruleFieldOperation = Rule::RuleFieldOperationsFileNameContains;
	aRule.m_ruleField = LOG_FIELD_NOOFDAYS;
	aRule.m_strValue = _T("7");

	m_rules.push_back(aRule);
}


/*****************************************************************************/
bool stl::log::CRulesManager::CMediaRules::CanApplyRules(const CString& strFileName)
{
	bool bResult = false;
	Rule aRule = m_rules[0];
	switch(aRule.m_ruleFieldOperation)
	{
	case Rule::RuleFieldOperationsFileNameContains:
		{
			if(aRule.m_ruleField == LOG_FIELD_NOOFDAYS)
			{
				COleDateTime filedate = ParseDateTimeFromString(strFileName);
				COleDateTime currentdate( COleDateTime::GetCurrentTime());
				CString strCurrentDate = currentdate.Format(VAR_DATEVALUEONLY);
				currentdate.ParseDateTime(strCurrentDate, VAR_DATEVALUEONLY);
				if ( currentdate.GetStatus() == COleDateTime::valid &&  filedate.GetStatus() == COleDateTime::valid )
				{
					int nDaysElapsed = int(currentdate - filedate);
					if ( nDaysElapsed >= 7 /*aRule.m_strValue*/)
					{
						bResult = true;
					}
				}
			}
		}
		break;;
	}

	return bResult;
}

/*****************************************************************************/
void stl::log::CRulesManager::CMediaRules::PrepareDateTimeString(CString& strFileName)
{
	CString strLocal = strFileName;

	if ( -1 == strLocal.Find(_T("-")) )
	{
		strLocal.Insert(4, _T("-"));
		strLocal.Insert(7, _T("-"));
		strFileName = strLocal;
	}
}

/*****************************************************************************/
COleDateTime stl::log::CRulesManager::CMediaRules::ParseDateTimeFromString(const CString& strDate)
{
	CString strDelimiter( _T("_"));
	return ParseDateTimeFromString( strDate, strDelimiter);
}

/*****************************************************************************/
COleDateTime stl::log::CRulesManager::CMediaRules::ParseDateTimeFromString(const CString& strDate, const CString& strDelimiter)
{
	COleDateTime dateFromString;
	CString strFileName = strDate;
	strFileName = strFileName.Left( strFileName.GetLength() - 4); // remove extension
	char* token, *next_token;
	token = strtok_s(strFileName.GetBuffer(), strDelimiter , &next_token);
	if(NULL != token)
	{
		token = strtok_s(NULL, strDelimiter , &next_token);
		if(NULL != token)
		{
			strFileName = token;
			PrepareDateTimeString(strFileName);
			dateFromString.ParseDateTime(strFileName, VAR_DATEVALUEONLY);
		}
	}
	strFileName.ReleaseBuffer();

	return dateFromString;
}

/*****************************************************************************/
bool stl::log::CRulesManager::IsFileValid(const CString& strFileName)
{
	return m_MediaRules.CanApplyRules(strFileName);
}

#endif


void stl::log::xlogger::housekeeping()
{
	housekeeping( true );
	housekeeping( false );
}

void stl::log::xlogger::housekeeping( bool isAudit )
{
	HANDLE Delete_FileHandle; 
	WIN32_FIND_DATA Delete_FindData; 
	BOOL Delete_EndOfFiles = FALSE;

	TCHAR strFindFiles[MAX_PATH]; 
	_tcscpy( strFindFiles, _logfolder );
	_tcscat( strFindFiles, _T("\\" )  );
	
	if( isAudit )
	{
		_tcscat( strFindFiles, AUDIT_FOLDER_NAME );
	}
	else
	{
		_tcscat( strFindFiles, ERROR_FOLDER_NAME );
	}

	_tcscat( strFindFiles, _T("\\*.*" )  );
	
	//strFindFiles += );

	Delete_FileHandle = ::FindFirstFile(strFindFiles, &Delete_FindData);

	if ( Delete_FileHandle!=INVALID_HANDLE_VALUE) 
	{
		do 
		{ 
			if ( ! ::FindNextFile(Delete_FileHandle,&Delete_FindData)) 
			{ 
				if ( GetLastError()==ERROR_NO_MORE_FILES) 
				{ 
					Delete_EndOfFiles = TRUE; 
					::FindClose(Delete_FileHandle); 
				} 
			}

			// Delete file 
			if ( Delete_FindData.dwFileAttributes!=FILE_ATTRIBUTE_DIRECTORY && !Delete_EndOfFiles)
			{
				LPCTSTR strFileName = Delete_FindData.cFileName;
				//if ( m_RulesMgr.IsFileValid(strFileName) )
				{
					TCHAR strDir[MAX_PATH];
					_tcscpy( strDir, _logfolder );
					_tcscat( strDir,  strFileName );;
					//strFileName += _T("\n");
					//TRACE0(strFileName);
					_tremove(strDir);
				}
			}
		}
		while ( ! Delete_EndOfFiles); 
	}
}





std::string stl::log::xlogger::tostring(bool v) const throw()
{
	return v ? "true" : "false";
}





std::string stl::log::xlogger::tostring(double v) const throw()
{
	///if ( XData::valid(v) )
	{
		TCHAR formatBuffer[20];
		_stprintf( formatBuffer, "%g", v );
		std::string result = formatBuffer;
		return result;
	}
	///return "null";
}





stl::log::xlogger& stl::log::xlogger::operator<<(bool b)
{
	trace( tostring(b), LOG_GROUP_AUDIT );
	return *this;
}





stl::log::xlogger& stl::log::xlogger::operator<<(double d)
{
	trace( tostring(d), LOG_GROUP_AUDIT );
	return *this;
}





stl::log::xlogger& stl::log::xlogger::operator<<(std::string& str)
{
	trace(str, LOG_GROUP_AUDIT);
	return *this;
}

void CleanXLogger()
{

}




#ifdef COMMENTED
stl::log::xlogger& stl::log::xlogger::operator<<(std::wstring& str)
{
	trace(stl::wstring2string(str));
	return *this;
}
#endif