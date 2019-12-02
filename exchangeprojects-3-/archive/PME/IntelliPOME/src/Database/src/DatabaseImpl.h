#pragma once

#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>

#include "DatabaseInterface.h"
#include <vector>
#include <atlcomtime.h>
#include <map>
#include <string>
//#import "c:\Program Files\Common Files\System\ADO\msado25.tlb"   rename("EOF", "EndOfFile")
//typedef ADODB::_RecordsetPtr	RECORD_PTR;
//typedef ADODB::_ConnectionPtr	CONNECTION_PTR;

#import "c:\Program Files\Common Files\System\ADO\msado15.dll"   no_namespace rename("EOF", "EndOfFile")
typedef _RecordsetPtr	RECORD_PTR;
typedef _ConnectionPtr	CONNECTION_PTR;
using namespace std;
#define BUFF_SIZE 8000

typedef void (*p_Db_CallBack_Events)(char * mssg,int * ivalue);

class CRstEvent;
class Parameter: public IParameter
{
private:
	enum VALUE_TYPE 
	{
		CHAR,
		INTEGER,
		UNSNIGNED_INT,
		FLOAT_PREC,
		DOUBLE_PREC,
		UNSIGNED_LG_LG,
		STRING,
		DATE_TIME,
		UNSIGNED_LG
	//	LONG_PREC,
	//	INT64_PREC
	};
	typedef union
	{
		char						charParam;
		int							intParam;
		unsigned int				unIntParam;
		float						flParam;
		double						dbParam;
		unsigned long long			unLgLgParam;
		char*						chParam;
		unsigned long				LgParam;
	//	long						lngParam;
	//	__int64						int64Param;
	}								VALUE;
	typedef struct
	{
		VALUE						valParam;
		unsigned int				size;
		VALUE_TYPE					valType;
		char*						paramName;
		int							paramType;// By Deepak
	}								PARAM;

	typedef vector<PARAM>			PARAMS;
	typedef vector<PARAM>::iterator PARAMS_ITER;
	PARAMS							m_params;
	Parameter(const Parameter&){};
	void operator =(const Parameter&){};
	void CopyFieldName(char* fieldName,char** dest);
	void CopyCharString(char* sour,char** dest,unsigned int size);
	CRITICAL_SECTION m_cs;

public:
	friend class Database;
	Parameter();
	virtual ~Parameter();
	virtual void AddParam (char* fieldName,char param);
	virtual void AddParam (char* fieldName,unsigned int param);
	virtual void AddParam (char* fieldName,unsigned long param);
	virtual void AddParam (char* fieldName,int param);
	virtual void AddParam (char* fieldName,unsigned long long param);
	virtual void AddParam (char* fieldName,float param);
	virtual void AddParam (char* fieldName,double param);
	virtual void AddParam (char* fieldName,char* param,unsigned int bufSize);
    virtual void AddDateTimeParam (char* fieldName,double param);

// By Deepak

	virtual void AddParam (char* fieldName,char param,int paramType);
	virtual void AddParam (char* fieldName,unsigned int param,int paramType);
	virtual void AddParam (char* fieldName,int param,int paramType);
	virtual void AddParam (char* fieldName,unsigned long long param,int paramType);
	virtual void AddParam (char* fieldName,float param,int paramType);
	virtual void AddParam (char* fieldName,double param,int paramType);
	//virtual void AddParam(char* fieldName,__int64 param);
	//virtual void AddParam(char* fieldName,long param);
	virtual void AddParam (char* fieldName,char* param,unsigned int bufSize,int paramType);
	
};

class Table : public ITable
{
private:
	RECORD_PTR m_recordPtr;
	char m_errStr[BUFF_SIZE];
	Table(const Table&){};
	void operator =(const Table&){};
	CRITICAL_SECTION m_cs;

public:
	Table();
	void operator =(RECORD_PTR recPtr);
	virtual ~Table(){};
	virtual void GetErrorErrStr(char* err, unsigned int bufSize);
	virtual bool IsEOF();
	virtual bool MoveNext();
	virtual bool MovePrev();
	virtual bool MoveFirst();
	virtual bool MoveLast();

	virtual bool MoveNextRecord(); //By Deepak 
	//virtual bool GetOutPut(char* fieldName,int& fieldValue);//By Deepak 

	virtual bool Get(char* fieldName, std::string* fieldValue);
	virtual bool Get(char* fieldName, char* fieldValue, unsigned int bufSize);
	virtual bool Get(char* fieldName,int& fieldValue);
	virtual bool Get(char* fieldName,float& fieldValue);
	virtual bool Get(char* fieldName,double& fieldValue);
	virtual bool Get(char* fieldName,unsigned int& fieldValue); 
	virtual bool Get(char* fieldName,unsigned long long& fieldValue); 
	virtual bool Get(char* fieldName,unsigned long& f4ieldValue); // By Mr. Roy
	virtual bool Get(char* fieldName,char& fieldValue); // By Mr. Roy
//	virtual bool Get(char* fieldName,__int64& fieldValue);
//	virtual bool Get(char* fieldName,long& fieldValue);
	virtual bool Get(char* fieldName,bool& fieldValue);
	virtual bool GetDateTime(char* fieldName,double& fieldValue);
	
};

class Database : public IDatabase
{
private:
	CONNECTION_PTR m_connectionPtr;
	char m_errStr[BUFF_SIZE];
	Database(const Database&){};
	void operator =(const Database&){};
	CRITICAL_SECTION m_cs;
	p_Db_CallBack_Events pfnc;
	_CommandPtr commandPtr; 
	CRstEvent *pRstEvent;
	std::map<std::string,p_Db_CallBack_Events> mapEvent;
	std::map<std::string,p_Db_CallBack_Events>::iterator itrmapEvent;
	
public:


	Database();
	void operator =(CONNECTION_PTR recPtr);
	virtual ~Database(){};
	virtual void GetErrorErrStr(char* err, unsigned int bufSize);
	virtual bool Open(const char* userName,const char* pwd,const char* cnnStr);
	virtual bool OpenTable(char* cmdStr,ITable& tbl );
	virtual bool Execute(char* cmdStr,ITable& tbl,IParameter& prm);
	virtual bool Execute(char* cmdStr,ITable& tbl,IParameter& prm,int OutPut); //By Deepak
	virtual void CloseDBConnection();
	virtual void callback(void * pt2Object,p_Db_CallBack_Events,char * eventName);
	virtual void ExitDataBaseLib();
	virtual void fnc_Event_Status(std::string eventName,int ival);
	virtual bool fnc_BeginTransaction();
	virtual bool fnc_CommitTransaction();
	virtual bool fnc_RollBackTransaction();
//	virtual char * fnc_Get_Envent_Name();
//	virtual int fnc_Get_Event_Status();
};


class CConnEvent : public ConnectionEventsVt {
private:
   ULONG m_cRef;
   Database * p_mDatabase;

public:
   CConnEvent() { m_cRef = 0; };
   ~CConnEvent() {};
	void set_p_mDatabase(Database * p_mDtbase);

   STDMETHODIMP QueryInterface(REFIID riid, void ** ppv);
   STDMETHODIMP_(ULONG) AddRef();
   STDMETHODIMP_(ULONG) Release();

   STDMETHODIMP raw_InfoMessage( struct Error *pError, 
                                 EventStatusEnum *adStatus, 
                                 struct _Connection *pConnection);

   STDMETHODIMP raw_BeginTransComplete( LONG TransactionLevel,
                                        struct Error *pError,
                                        EventStatusEnum *adStatus,
                                        struct _Connection *pConnection);

   STDMETHODIMP raw_CommitTransComplete( struct Error *pError, 
                                         EventStatusEnum *adStatus,
                                         struct _Connection *pConnection);

   STDMETHODIMP raw_RollbackTransComplete( struct Error *pError, 
                                           EventStatusEnum *adStatus,
                                           struct _Connection *pConnection);

   STDMETHODIMP raw_WillExecute( BSTR *Source,
                                 CursorTypeEnum *CursorType,
                                 LockTypeEnum *LockType,
                                 long *Options,
                                 EventStatusEnum *adStatus,
                                 struct _Command *pCommand,
                                 struct _Recordset *pRecordset,
                                 struct _Connection *pConnection);

   STDMETHODIMP raw_ExecuteComplete( LONG RecordsAffected,
                                     struct Error *pError,
                                     EventStatusEnum *adStatus,
                                     struct _Command *pCommand,
                                     struct _Recordset *pRecordset,
                                     struct _Connection *pConnection);

   STDMETHODIMP raw_WillConnect( BSTR *ConnectionString,
                                 BSTR *UserID,
                                 BSTR *Password,
                                 long *Options,
                                 EventStatusEnum *adStatus,
                                 struct _Connection *pConnection);

   STDMETHODIMP raw_ConnectComplete( struct Error *pError,
                                     EventStatusEnum *adStatus,
                                     struct _Connection *pConnection);

   STDMETHODIMP raw_Disconnect( EventStatusEnum *adStatus, struct _Connection *pConnection);
};

// The Recordset events
class CRstEvent : public RecordsetEventsVt {
private:
   ULONG m_cRef;   
   Database * p_mDatabase;

public:
   CRstEvent() { m_cRef = 0; };
   ~CRstEvent() {};

   void set_p_mDatabase(Database * p_mDtbase);

   STDMETHODIMP QueryInterface(REFIID riid, void ** ppv);
   STDMETHODIMP_(ULONG) AddRef();
   STDMETHODIMP_(ULONG) Release();

   STDMETHODIMP raw_WillChangeField( LONG cFields,      
                                     VARIANT Fields,
                                     EventStatusEnum *adStatus,
                                     struct _Recordset *pRecordset);

   STDMETHODIMP raw_FieldChangeComplete( LONG cFields,
                                         VARIANT Fields,
                                         struct Error *pError,
                                         EventStatusEnum *adStatus,
                                         struct _Recordset *pRecordset);

   STDMETHODIMP raw_WillChangeRecord( EventReasonEnum adReason,
                                      LONG cRecords,
                                      EventStatusEnum *adStatus,
                                      struct _Recordset *pRecordset);

   STDMETHODIMP raw_RecordChangeComplete( EventReasonEnum adReason,
                                          LONG cRecords,
                                          struct Error *pError,
                                          EventStatusEnum *adStatus,
                                          struct _Recordset *pRecordset);

   STDMETHODIMP raw_WillChangeRecordset( EventReasonEnum adReason,
                                         EventStatusEnum *adStatus,
                                         struct _Recordset *pRecordset);

   STDMETHODIMP raw_RecordsetChangeComplete( EventReasonEnum adReason,
                                             struct Error *pError,
                                             EventStatusEnum *adStatus,
                                             struct _Recordset *pRecordset);

   STDMETHODIMP raw_WillMove( EventReasonEnum adReason,
                              EventStatusEnum *adStatus,
                              struct _Recordset *pRecordset);

   STDMETHODIMP raw_MoveComplete( EventReasonEnum adReason,
                                  struct Error *pError,
                                  EventStatusEnum *adStatus,
                                  struct _Recordset *pRecordset);

   STDMETHODIMP raw_EndOfRecordset( VARIANT_BOOL *fMoreData,
                                    EventStatusEnum *adStatus,
                                    struct _Recordset *pRecordset);

   STDMETHODIMP raw_FetchProgress( long Progress,
                                   long MaxProgress,
                                   EventStatusEnum *adStatus,
                                   struct _Recordset *pRecordset);

   STDMETHODIMP raw_FetchComplete( struct Error *pError, 
                                   EventStatusEnum *adStatus,
                                   struct _Recordset *pRecordset);
};
