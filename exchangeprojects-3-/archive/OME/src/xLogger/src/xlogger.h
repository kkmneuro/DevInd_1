#ifndef _STL_LOGGER_H
#define _STL_LOGGER_H

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================


#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>

#include <windows.h>
#include <tchar.h>
#include <stdio.h>
#include <string>

#include <list>



//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================






namespace stl
{
	namespace system
	{
		TCHAR*				getdir() throw();
	}


	namespace log
	{
			
		enum TraceLevel
		{
			TraceNone,				// no trace
			TraceError,				// only trace error
			TraceInfo,				// some extra info
			TraceVerbose,			// detailed info
			TraceDebug,				// detailed debugging info
			TraceAlways				// always
		};


		enum LOG_LEVEL
		{
		   LOG_LEVEL_DEBUG			= TraceDebug,
		   LOG_LEVEL_VERBOSE		= TraceVerbose,
		   LOG_LEVEL_NORMAL			= TraceInfo,
		   LOG_LEVEL_SHORT			= TraceError,
		   LOG_LEVEL_ALWAYS			= TraceAlways,
		   LOG_LEVEL_NONE			= TraceNone
		};

		enum LOG_GROUP
		{
		   LOG_GROUP_AUDIT
		   , LOG_GROUP_ERROR
		};


#define LOG_FIELD_FILENAME "FileName"
#define LOG_FIELD_NOOFDAYS "NumberOfDays"

		

		/*class CRulesManager
		{
		public:

			CRulesManager(){}
			~CRulesManager(){}
			
			bool					IsFileValid(const CString& strFileName);


		protected:

			CRulesManager(const CRulesManager& rhs);
			CRulesManager*			operator=(const CRulesManager& rhs);


		public:

			struct Rule
			{
				enum RuleFieldOperations
				{
					RuleFieldOperationsFileNameContains,
					RuleFieldOperationsFileNameNotContains
				};

				RuleFieldOperations	m_ruleFieldOperation;
				CString				m_ruleField;
				CString				m_strValue;
			};

			typedef std::vector<Rule> Rules;


			class CMediaRules
			{
			public:

				CMediaRules()		{ Initialise();	}
				~CMediaRules(){}

				bool				CanApplyRules(const CString& strFileName);


			private:

				void 				Initialise();
				void 				PrepareDateTimeString(CString& strFileName);
				bool				IsNumeric(const char* pData);
				COleDateTime		ParseDateTimeFromString(const CString& strDate);
				COleDateTime		ParseDateTimeFromString(const CString& strDate, const CString& strDelimiter);

				Rules				m_rules;
			};


		private:

			CMediaRules				m_MediaRules;
		};





		class CMediaManager
		{
		public:

			CMediaManager(){}
			~CMediaManager(){}


		protected:

			CMediaManager(const CMediaManager& rhs);
			CMediaManager*			operator=(const CMediaManager& rhs);

			std::vector<CString>	GetFileNames(CString strFromDir);
			void					RemoveFile(CString strFile);
			void					MoveFile(CString strFile);
		};



*/

		class xlogger
		{
		public:

			xlogger();
			xlogger( LPCTSTR logfolder, LPCTSTR prefix );
			~xlogger();

			void					housekeeping();

			std::string				tostring(bool b) const throw();
			std::string				tostring(double d) const throw();

			xlogger&				operator<<(bool b);
			xlogger&				operator<<(double d);
			xlogger&				operator<<(std::string& str);

#ifdef COMMENTED
			xlogger&				operator<<(std::wstring& str);
#endif

		protected:

			bool					openfile();		// open a new trace file
			void					closefile();

			bool					append( UINT group, const std::string& log);
			bool					write() throw();
			bool					close();
			bool					isActive();

			void 					lock();			// set lock to gain exclusive access to trace functions
			void 					unlock();		// release lock so that other threads can access trace functions

			void 					setlogfolder(LPCTSTR logfolder);
			void 					SetTraceLevel(UINT level);		// set the current trace level
			void 					setlogfileprefix(LPCTSTR prefix);


		private:

			void					housekeeping(bool isAudit);

			friend bool				getlogfilename(std::wstring& logfilename);
			friend bool				getlogfolder(std::wstring& logfolder);
			friend bool				getlogfile(std::wstring& logfile);
			friend void				setlogfolder( LPCTSTR logfolder );
			friend void 			setlogfileprefix( LPCTSTR fileprefix );
			friend void 			setLogLevel(UINT nLevel);
			__declspec(dllexport) friend bool 			trace(const std::string& log, UINT group, UINT level=TraceDebug );
			__declspec(dllexport) friend bool 			trace( UINT group, UINT level, LPCTSTR format, ... );
			friend bool 			write();
			__declspec(dllexport) friend bool 			close();
			friend bool 			isActive();

#ifdef COMMENTED
			friend void				trace(const stl::xerror& error, std::wstring& loggedfile);
#endif
			// All these functions will write to the std output window, and append a carriage return
			friend void 			setDebugStringOn();
			friend void 			setDebugStringOff();
			friend void 			debugString(const char* szMsg);
			friend void 			debugString(const std::string& szMsg);
			

#ifdef COMMENTED			
			friend void 			debugString(const CString& szMsg);
#endif

		public:

			static std::string		comma;


		protected:

			TCHAR			_logfolder[MAX_PATH];
			TCHAR			_logfile[MAX_PATH];
			TCHAR			_logfileprefix[MAX_PATH];
			FILE*					_hAuditFile;
			FILE*					_hErrorFile;
			UINT					_level;

			long					m_nThreadId;
			SYSTEMTIME				m_timeStart;
			SYSTEMTIME				m_rST;
			//xdatetime__				m_HiResTime;

			TCHAR					m_pBuffer[8000];
			TCHAR					record[8000];
			//CRulesManager			m_RulesMgr;
			// max allowed log file size in KB
			UINT					m_MaxSizeKB;


		private:

			CRITICAL_SECTION		_cs;
			HANDLE  m_hWriterThread; 
			DWORD   m_dwWriterThreadId;
 
			std::list<LPCTSTR> m_auditLogList;
			std::list<LPCTSTR> m_errorLogList;

			bool isActiveFlag;

			// initial record count 32k, also used while increasing the size
			static const int MAX_RECORDS = 32*1024;
		};
	}
}


#endif // _STL_LOGGER_H