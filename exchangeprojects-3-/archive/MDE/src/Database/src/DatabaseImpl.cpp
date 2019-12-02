#include "stdafx.h"
#include <stdio.h>
#include <comdef.h>
#include "DatabaseImpl.h"
#include <iostream>
#include <fstream>
#include "xlogger.h"
#include "UtilitiesAPI.h"
#include <strsafe.h> ///buffer overruns
#include <atlconv.h>


void callback_Db_Conn_close(void * pt2Object,char * mssg,int * ivalue,void (*p_Db_CallBack_Events)(char * mssg,int * ivalue))
{
     if(pt2Object!=NULL) p_Db_CallBack_Events(mssg,ivalue);  
}

 _variant_t varLiReturn;
void ErrorHandler(_com_error &e, char* errStr)
{
	///buffer overruns

	int iError;

	iError = _snprintf(errStr,BUFF_SIZE,"Error:\n");
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error:\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sCode = %08lx\n",errStr ,e.Error());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sCode meaning = %s\n", errStr, (char*) e.ErrorMessage());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sSource = %s\n", errStr, (char*) e.Source());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
	
	iError =_snprintf(errStr,BUFF_SIZE-strlen(errStr),"%sDescription = %s",errStr, (char*) e.Description());
	if(iError==-1) 
	{
		_snprintf(errStr,BUFF_SIZE,"Error: Buffer Overrun\n");
		return;
	}
}
// Implement each connection method

void CConnEvent::set_p_mDatabase(Database * p_mDtbase)
{
		p_mDatabase = p_mDtbase;
}
STDMETHODIMP CConnEvent::raw_InfoMessage( struct Error *pError, 
                                         EventStatusEnum *adStatus,
                                         struct _Connection *pConnection) {

		BSTR bstrError;
		_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}

     switch (*adStatus)
	{
		
	case 1:
		 p_mDatabase->fnc_Event_Status("raw_InfoMessage",*adStatus);	
	   break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_InfoMessage",*adStatus);	
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_InfoMessage",*adStatus);	
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_InfoMessage",*adStatus);	
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_InfoMessage",*adStatus);	
		break;
	default:
		break;
	}
	 ::SysFreeString(bstrError);
	 ::SysFreeString(bstr_t_error);
   return S_OK;
};

STDMETHODIMP CConnEvent::raw_BeginTransComplete( LONG TransactionLevel,
                                                 struct Error *pError,
                                                 EventStatusEnum *adStatus,
                                                 struct _Connection *pConnection) {

		 BSTR bstrError;
		_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}

     switch (*adStatus)
	{
   case 1:
	    p_mDatabase->fnc_Event_Status("raw_BeginTransComplete",*adStatus);	
		break;
	case 2:
	    p_mDatabase->fnc_Event_Status("raw_BeginTransComplete",*adStatus);	
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_BeginTransComplete",*adStatus);	
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_BeginTransComplete",*adStatus);	
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_BeginTransComplete",*adStatus);	
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CConnEvent::raw_CommitTransComplete( struct Error *pError,
                                                  EventStatusEnum *adStatus,
                                                  struct _Connection *pConnection) {


		 BSTR bstrError;
		_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}

	   switch (*adStatus)
		{
	   case 1:
            p_mDatabase->fnc_Event_Status("raw_CommitTransComplete",*adStatus);	
			break;
		case 2:
			p_mDatabase->fnc_Event_Status("raw_CommitTransComplete",*adStatus);	
			break;
		case 3:
			p_mDatabase->fnc_Event_Status("raw_CommitTransComplete",*adStatus);	
			break;
		case 4:
			p_mDatabase->fnc_Event_Status("raw_CommitTransComplete",*adStatus);	
			break;
		case 5:
			p_mDatabase->fnc_Event_Status("raw_CommitTransComplete",*adStatus);	
			break;
		default:
			break;
		}
	   return S_OK;
};

STDMETHODIMP CConnEvent::raw_RollbackTransComplete( struct Error *pError,
                                                    EventStatusEnum *adStatus,
                                                    struct _Connection *pConnection) 
{
		BSTR bstrError;
		_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
	
	   switch (*adStatus)
		{
	   case 1:
		    p_mDatabase->fnc_Event_Status("raw_RollbackTransComplete",*adStatus);	
			break;
		case 2:
			p_mDatabase->fnc_Event_Status("raw_RollbackTransComplete",*adStatus);
			break;
		case 3:
			p_mDatabase->fnc_Event_Status("raw_RollbackTransComplete",*adStatus);
			break;
		case 4:
			p_mDatabase->fnc_Event_Status("raw_RollbackTransComplete",*adStatus);
			break;
		case 5:
			p_mDatabase->fnc_Event_Status("raw_RollbackTransComplete",*adStatus);
			break;
		default:
			break;
		}
	   return S_OK;
};

STDMETHODIMP CConnEvent::raw_WillExecute( BSTR *Source,
                                          CursorTypeEnum *CursorType,
                                          LockTypeEnum *LockType,
                                          long *Options,
                                          EventStatusEnum *adStatus,
                                          struct _Command *pCommand,
                                          struct _Recordset *pRecordset,
                                          struct _Connection *pConnection) {
      switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_WillExecute",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_WillExecute",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_WillExecute",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_WillExecute",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_WillExecute",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CConnEvent::raw_ExecuteComplete( LONG RecordsAffected,
                                              struct Error *pError,
                                              EventStatusEnum *adStatus,
                                              struct _Command *pCommand,
                                              struct _Recordset *pRecordset,
                                              struct _Connection *pConnection) {

		BSTR bstrError;
		_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
	   
		switch (*adStatus)
		{
	    case 1:
		    p_mDatabase->fnc_Event_Status("raw_ExecuteComplete",*adStatus);
			break;
		case 2:
			p_mDatabase->fnc_Event_Status("raw_ExecuteComplete",*adStatus);
			break;
		case 3:
			p_mDatabase->fnc_Event_Status("raw_ExecuteComplete",*adStatus);
			break;
		case 4:
			p_mDatabase->fnc_Event_Status("raw_ExecuteComplete",*adStatus);
			break;
		case 5:
			p_mDatabase->fnc_Event_Status("raw_ExecuteComplete",*adStatus);
			break;
		default:
			break;
		}

	   return S_OK;
};

STDMETHODIMP CConnEvent::raw_WillConnect( BSTR *ConnectionString,
                                          BSTR *UserID,
                                          BSTR *Password,
                                          long *Options,
                                          EventStatusEnum *adStatus,
                                          struct _Connection *pConnection) {
     switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_WillConnect",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_WillConnect",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_WillConnect",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_WillConnect",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_WillConnect",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CConnEvent::raw_ConnectComplete( struct Error *pError,
                                              EventStatusEnum *adStatus,
                                              struct _Connection *pConnection) {

		BSTR bstrError;
		_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
		switch (*adStatus)
		{
	   case 1:
		   p_mDatabase->fnc_Event_Status("raw_ConnectComplete",*adStatus);
			break;
		case 2:
			p_mDatabase->fnc_Event_Status("raw_ConnectComplete",*adStatus);
			break;
		case 3:
			p_mDatabase->fnc_Event_Status("raw_ConnectComplete",*adStatus);
			break;
		case 4:
			p_mDatabase->fnc_Event_Status("raw_ConnectComplete",*adStatus);
			break;
		case 5:
			p_mDatabase->fnc_Event_Status("raw_ConnectComplete",*adStatus);
			break;
		default:
			break;
		}
	   return S_OK;
};

STDMETHODIMP CConnEvent::raw_Disconnect( EventStatusEnum *adStatus, struct _Connection *pConnection) {
      switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_Disconnect",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_Disconnect",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_Disconnect",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_Disconnect",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_Disconnect",*adStatus);
		break;
	default:
		break;
	}
  
   return S_OK;
};

// Implement each recordset method

void CRstEvent::set_p_mDatabase(Database * p_mDtbase)
{
		p_mDatabase = p_mDtbase;
}

STDMETHODIMP CRstEvent::raw_WillChangeField( LONG cFields,
                                             VARIANT Fields,
                                             EventStatusEnum *adStatus,
                                             struct _Recordset *pRecordset) {
   switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_WillChangeField",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_WillChangeField",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_WillChangeField",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_WillChangeField",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_WillChangeField",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_FieldChangeComplete( LONG cFields,
                                                 VARIANT Fields,
                                                 struct Error *pError,
                                                 EventStatusEnum *adStatus,
                                                 struct _Recordset *pRecordset) {

	BSTR bstrError;
	_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
    
	switch (*adStatus)
	{
    case 1:
	    p_mDatabase->fnc_Event_Status("raw_FieldChangeComplete",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_FieldChangeComplete",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_FieldChangeComplete",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_FieldChangeComplete",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_FieldChangeComplete",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_WillChangeRecord( EventReasonEnum adReason,
                                              LONG cRecords,
                                              EventStatusEnum *adStatus,
                                              struct _Recordset *pRecordset) {
      switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_WillChangeRecord",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecord",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecord",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecord",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecord",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_RecordChangeComplete( EventReasonEnum adReason,
                                                  LONG cRecords,
                                                  struct Error *pError,
                                                  EventStatusEnum *adStatus,
                                                  struct _Recordset *pRecordset) {

	BSTR bstrError;
	_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
    
	switch (*adStatus)
	 {
    case 1:
	    p_mDatabase->fnc_Event_Status("raw_RecordChangeComplete",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_RecordChangeComplete",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_RecordChangeComplete",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_RecordChangeComplete",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_RecordChangeComplete",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_WillChangeRecordset( EventReasonEnum adReason,
                                                 EventStatusEnum *adStatus,
                                                 struct _Recordset *pRecordset) {
     switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_WillChangeRecordset",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecordset",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecordset",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecordset",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_WillChangeRecordset",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_RecordsetChangeComplete( EventReasonEnum adReason,
                                                     struct Error *pError,
                                                     EventStatusEnum *adStatus,
                                                     struct _Recordset *pRecordset) {
    BSTR bstrError;
	_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
	
	switch (*adStatus)
	 {
    case 1:
	    p_mDatabase->fnc_Event_Status("raw_RecordsetChangeComplete",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_RecordsetChangeComplete",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_RecordsetChangeComplete",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_RecordsetChangeComplete",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_RecordsetChangeComplete",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_WillMove( EventReasonEnum adReason, 
                                      EventStatusEnum *adStatus,
                                      struct _Recordset *pRecordset) {
   switch (*adStatus)
	{
   case 1:
	   p_mDatabase->fnc_Event_Status("raw_WillMove",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_WillMove",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_WillMove",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_WillMove",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_WillMove",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_MoveComplete( EventReasonEnum adReason,
                                          struct Error *pError,
                                          EventStatusEnum *adStatus,
                                          struct _Recordset *pRecordset) {

	BSTR bstrError;
	_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
    
	switch (*adStatus)
	 {
    case 1:
	    p_mDatabase->fnc_Event_Status("raw_MoveComplete",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_MoveComplete",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_MoveComplete",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_MoveComplete",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_MoveComplete",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_EndOfRecordset( VARIANT_BOOL *fMoreData,
                                            EventStatusEnum *adStatus,
                                            struct _Recordset *pRecordset) {
   switch (*adStatus)
	{
   case 1:
	    p_mDatabase->fnc_Event_Status("raw_EndOfRecordset",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_EndOfRecordset",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_EndOfRecordset",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_EndOfRecordset",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_EndOfRecordset",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_FetchProgress( long Progress,
                                           long MaxProgress,
                                           EventStatusEnum *adStatus,
                                           struct _Recordset *pRecordset) {
   switch (*adStatus)
	{
   case 1:
	    p_mDatabase->fnc_Event_Status("raw_FetchProgress",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_FetchProgress",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_FetchProgress",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_FetchProgress",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_FetchProgress",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::raw_FetchComplete( struct Error *pError,
                                           EventStatusEnum *adStatus,
                                           struct _Recordset *pRecordset) {

	BSTR bstrError;
	_bstr_t bstr_t_error;
		if(pError!=NULL)
		{
			pError->get_Description(&bstrError);
			bstr_t_error=bstrError ;
		}
    
	switch (*adStatus)
	{
    case 1:
	    p_mDatabase->fnc_Event_Status("raw_FetchComplete",*adStatus);
		break;
	case 2:
		p_mDatabase->fnc_Event_Status("raw_FetchComplete",*adStatus);
		break;
	case 3:
		p_mDatabase->fnc_Event_Status("raw_FetchComplete",*adStatus);
		break;
	case 4:
		p_mDatabase->fnc_Event_Status("raw_FetchComplete",*adStatus);
		break;
	case 5:
		p_mDatabase->fnc_Event_Status("raw_FetchComplete",*adStatus);
		break;
	default:
		break;
	}
   return S_OK;
};

STDMETHODIMP CRstEvent::QueryInterface(REFIID riid, void ** ppv) {
   *ppv = NULL;
   if (riid == __uuidof(IUnknown) || riid == __uuidof(RecordsetEventsVt)) 
      *ppv = this;

   if (*ppv == NULL)
      return ResultFromScode(E_NOINTERFACE);

   AddRef();
   return NOERROR;
}

STDMETHODIMP_(ULONG) CRstEvent::AddRef() { 
   return ++m_cRef; 
};

STDMETHODIMP_(ULONG) CRstEvent::Release() { 
   if (0 != --m_cRef) 
      return m_cRef;
   delete this;
   return 0;
}

STDMETHODIMP CConnEvent::QueryInterface(REFIID riid, void ** ppv) {
   *ppv = NULL;
   if (riid == __uuidof(IUnknown) || riid == __uuidof(ConnectionEventsVt)) 
      *ppv = this;

   if (*ppv == NULL)
      return ResultFromScode(E_NOINTERFACE);

   AddRef();
   return NOERROR;
}

STDMETHODIMP_(ULONG) CConnEvent::AddRef() { 
   return ++m_cRef; 
};

STDMETHODIMP_(ULONG) CConnEvent::Release() { 
   if (0 != --m_cRef) 
      return m_cRef;
   delete this;
   return 0;
}
Database::Database()
{
	m_connectionPtr=NULL;
	sprintf_s(m_errStr,BUFF_SIZE,"NULL POINTER");
	InitializeCriticalSection(&m_cs);
//	pObject =NULL;
}


void Database::operator =(CONNECTION_PTR conPtr)
{
	m_connectionPtr=conPtr;
}

void Database::GetErrorErrStr(char* err, unsigned int bufSize)
{
	int iError;

	iError = _snprintf(err,bufSize,"%s",m_errStr);
	if(iError==-1) 
	{
		_snprintf(err,bufSize,"Database:Error: GetErrorErrStr\n");
		return;
	}
}

void Table::GetErrorErrStr(char* err, unsigned int bufSize)
{
	//sprintf_s(err,bufSize,"%s",m_errStr);

	int iError;

	iError = _snprintf(err,bufSize,"%s",m_errStr);
	if(iError==-1) 
	{
		_snprintf(err,bufSize,"Table:Error: GetErrorErrStr\n");
		return;
	}
}

bool Database::Open(const char* userName,const char* pwd,const char* cnnStr)
{
	try
	{
	   HRESULT hr;
	   DWORD dwConnEvt;
	   DWORD dwRstEvt;
	   IConnectionPointContainer *pCPC = NULL;
	   IConnectionPoint *pCP = NULL;
	   IUnknown *pUnk = NULL;
	   CConnEvent *pConnEvent= NULL;
		
		hr    = m_connectionPtr.CreateInstance( __uuidof( Connection ) );
		if (FAILED(hr)) 
			 {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Open, error = m_connectionPtr.CreateInstance hr = failed");
				 return false;
			 }

	
	   // Start using the Connection events
	   hr = m_connectionPtr->QueryInterface(__uuidof(IConnectionPointContainer), (void **)&pCPC);

	   if (FAILED(hr)) 
			 {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Open, error = m_connectionPtr->QueryInterface hr = failed");
				 return false;
			 }
	   
	   hr = pCPC->FindConnectionPoint(__uuidof(ConnectionEvents), &pCP);
	   pCPC->Release();

	   if (FAILED(hr)) 
			{
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Open, error = pCPC->FindConnectionPoint hr = failed");
				 return false;
			 }

	   pConnEvent = new CConnEvent();
	   pRstEvent = new CRstEvent();
	   hr = pConnEvent->QueryInterface(__uuidof(IUnknown), (void **) &pUnk);

	   if (FAILED(hr)) 
		    {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Open, error = pConnEvent->QueryInterface hr = failed");
				 return false;
			 }
	   
	   pConnEvent->set_p_mDatabase(this);

	   hr = pCP->Advise(pUnk, &dwConnEvt);
	   pCP->Release();

	   if (FAILED(hr)) 
			 {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Open, error = pCP->Advise hr = failed");
				 return false;
			 }
	 
		m_connectionPtr->Open(cnnStr, userName, pwd, NULL);
		}
		catch(_com_error &e)
		{
			ErrorHandler(e,m_errStr);
			return false;
		}
		sprintf_s(m_errStr,BUFF_SIZE,"Success");
		return true;
}

void Database::ExitDataBaseLib()

{
		CoUninitialize();
}

void Database::CloseDBConnection()
{
	try
	{
		m_connectionPtr->Close();
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"DB Close");
	return;
}

void Database::fnc_Event_Status(std::string stEvent,int iEvent)

{
	try
	{
		
		if(mapEvent.size()>0)
		{
			itrmapEvent = mapEvent.find(stEvent);
			if(itrmapEvent!=mapEvent.end())
			{
				if((stEvent.compare(itrmapEvent->first))==0)
				{
					callback_Db_Conn_close(*(itrmapEvent->second),(char *)stEvent.c_str(),&iEvent,*(itrmapEvent->second));
				}
			}
		}
	}
	catch(exception e)
	{
		return;
	}
	return;
}

void Database::callback(void * pt2Object,p_Db_CallBack_Events pt2fnc,char * eventName)
{
	mapEvent[eventName]=pt2fnc;
}


bool Database::fnc_BeginTransaction()
{
	
	try
	{
			m_connectionPtr->BeginTrans();
	}
	catch(_com_error &e)
	{
			ErrorHandler(e,m_errStr);
			return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"BeginTransaction Success");
	return true;
}

bool Database::fnc_CommitTransaction()
{
	
	try
	{
			m_connectionPtr->CommitTrans();
	}
	catch(_com_error &e)
	{
			ErrorHandler(e,m_errStr);
			return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Commit Success");
	return true;
}

bool Database::fnc_RollBackTransaction()
{
	
	try
	{
			m_connectionPtr->RollbackTrans();
	}
	catch(_com_error &e)
	{
			ErrorHandler(e,m_errStr);
			return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Rollback Success");
	return true;
}

bool Database::OpenTable(char* cmdStr,ITable& tbl)
{
	if(m_connectionPtr==NULL)
	{
		sprintf_s(m_errStr,BUFF_SIZE,"Invalid Connection");
		return false;
	}
	RECORD_PTR t_Rec=NULL;
	try
	{
		HRESULT hr =  t_Rec.CreateInstance( __uuidof( Recordset ) );
		if (FAILED(hr)) 
		 {
			 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::OpenTable, error = t_Rec.CreateInstance hr = failed");
				 return false;
		}
		t_Rec->Open(cmdStr,_variant_t((IDispatch *) m_connectionPtr, true),adOpenStatic,adLockOptimistic,adCmdTable);
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	dynamic_cast< Table&>(tbl)=t_Rec;
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return false;
}

bool Database::Execute(char* cmdStr,ITable& tbl,IParameter& prm)
{
		RECORD_PTR recPtr=NULL;
		AcquireLock(&m_cs);
		HRESULT hr;
		DWORD dwConnEvt;
	    DWORD dwRstEvt;
	    IConnectionPointContainer *pCPC = NULL;
	    IConnectionPoint *pCP = NULL;
	    IUnknown *pUnk = NULL;
	  //  CRstEvent *pRstEvent = NULL;
	 //   CConnEvent *pConnEvent= NULL;
		try
		{
			

			Parameter& params=dynamic_cast<Parameter&>(prm);
	        
			_ParameterPtr parameterPtr = NULL; 
			//_ParameterPtr parameterPtr = NULL; 
			//commandPtr.CreateInstance(__uuidof(Command)); 
			commandPtr.CreateInstance(__uuidof(Command));
	  
			if(m_connectionPtr && commandPtr) 
			{ 
				commandPtr->ActiveConnection = m_connectionPtr; 
				//commandPtr->CommandType = adCmdStoredProc; 
				commandPtr->CommandType = adCmdStoredProc; 
				commandPtr->CommandText = _bstr_t(cmdStr); 
				//commandPtr->NamedParameters = true; 
				HRESULT hr;

				for(Parameter::PARAMS_ITER iter= params.m_params.begin();iter!=params.m_params.end();iter++)
				{
					_bstr_t strParamName1("@");
					_bstr_t strParamName2(iter->paramName);
					_bstr_t strParamName=strParamName1+strParamName2;

					if(iter->valType==Parameter::DATE_TIME)
					{
						COleDateTime oleDateTime( /*(time_t)*/iter->valParam.dbParam);
						_variant_t vt(oleDateTime);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDBTimeStamp, adParamInput, sizeof(vt), vt)); 

						//COleDateTime oleDateTime( (time_t)iter->valParam.dbParam);
						//_variant_t vt(oleDateTime);
						//hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDBTimeStamp, adParamInput, sizeof(vt), vt)); 

					}
					else if(iter->valType==Parameter::CHAR)
					{
						_variant_t vt(iter->valParam.charParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adChar, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::INTEGER)
					{
						_variant_t vt(iter->valParam.intParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adInteger, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::UNSNIGNED_INT)
					{
						_variant_t vt(iter->valParam.unIntParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adUnsignedInt, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::UNSIGNED_LG)
					{
						_variant_t vt(iter->valParam.LgParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adUnsignedInt, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::UNSIGNED_LG_LG)
					{
						DECIMAL dec;
						memset(&dec,0,sizeof(DECIMAL));
						dec.wReserved=14;
						dec.sign=0;
						dec.scale=0;
						dec.Lo64=iter->valParam.unLgLgParam;
						_variant_t vt(dec);
						_ParameterPtr p= commandPtr->CreateParameter(strParamName, adDecimal, adParamInput, sizeof(vt), vt);
						p->PutPrecision(12);
						p->PutNumericScale(0);
						hr=commandPtr->Parameters->Append(p); 
					}
					else if(iter->valType==Parameter::FLOAT_PREC)
					{
						_variant_t vt(iter->valParam.flParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adSingle, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::DOUBLE_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}
				/*	else if(iter->valType==Parameter::LONG_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::INT64_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}*/
					else if(iter->valType==Parameter::STRING)
					{
						bstr_t str(iter->valParam.chParam);
						_variant_t vt(str);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adVarChar, adParamInput, str.length() + 1, vt)); 
						
					}
			}
			//recPtr = commandPtr->Execute(NULL, NULL, adAsyncExecute); 
			recPtr = commandPtr->Execute(NULL, NULL, adCmdStoredProc); 
			
			//recPtr.CreateInstance( __uuidof( Recordset ) );
			
		    hr = recPtr->QueryInterface(__uuidof(IConnectionPointContainer), (void **)&pCPC);

		     if (FAILED(hr)) 
			 {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Execute, error = recPtr->QueryInterface hr = failed");
				 return false;
			 }

		    hr = pCPC->FindConnectionPoint(__uuidof(RecordsetEvents), &pCP);
		    pCPC->Release();

		    if (FAILED(hr)) 
			   {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Execute, error = pCPC->FindConnectionPoint hr = failed");
				 return false;
			 }

		    
		    hr = pRstEvent->QueryInterface(__uuidof(IUnknown), (void **) &pUnk);
 
			if (FAILED(hr)) 
			  {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Execute, error = pRstEvent->QueryInterface hr = failed");
				 return false;
			 }
			pRstEvent->set_p_mDatabase(this);

		    hr = pCP->Advise(pUnk, &dwRstEvt);
		    pCP->Release();
			
			if (FAILED(hr)) 
			  {
				 ReleaseLock(&m_cs);
				 stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Execute, error = pCP->Advise hr = failed");
				 return false;
			 }
       } 
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		ReleaseLock(&m_cs);

		stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Database::Execute, error = %s", m_errStr);
		return false;
	}
	dynamic_cast<Table&>(tbl)=recPtr;
	sprintf_s(m_errStr,BUFF_SIZE,"Success");

	ReleaseLock(&m_cs);
	return true;
}


bool Database::Execute(char* cmdStr,ITable& tbl,IParameter& prm,int OutPut)
{
	AcquireLock(&m_cs);
	RECORD_PTR recPtr=NULL;
	try
	{
		Parameter& params=dynamic_cast<Parameter&>(prm);
        
        _ParameterPtr parameterPtr = NULL; 
        commandPtr.CreateInstance(__uuidof(Command)); 
  
        if(m_connectionPtr && commandPtr) 
        { 
            commandPtr->ActiveConnection = m_connectionPtr; 
            commandPtr->CommandType = adCmdStoredProc; 
            commandPtr->CommandText = _bstr_t(cmdStr); 
            //commandPtr->NamedParameters = true; 
			HRESULT hr;

			for(Parameter::PARAMS_ITER iter= params.m_params.begin();iter!=params.m_params.end();iter++)
			{
				_bstr_t strParamName1("@");
				_bstr_t strParamName2(iter->paramName);
				_bstr_t strParamName=strParamName1+strParamName2;

				_variant_t vtParamType(iter->paramType);
				if(vtParamType.intVal==1) 
				
				{
				
					if(iter->valType==Parameter::DATE_TIME)
					{
						COleDateTime oleDateTime( iter->valParam.dbParam);
						_variant_t vt(oleDateTime);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDBTimeStamp, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::CHAR)
					{
						_variant_t vt(iter->valParam.charParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adChar, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::INTEGER)
					{
						_variant_t vt(iter->valParam.intParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adInteger, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::UNSNIGNED_INT)
					{
						_variant_t vt(iter->valParam.unIntParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adUnsignedInt, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::UNSIGNED_LG_LG)
					{
						DECIMAL dec;
						memset(&dec,0,sizeof(DECIMAL));
						dec.wReserved=14;
						dec.sign=0;
						dec.scale=0;
						dec.Lo64=iter->valParam.unLgLgParam;
						_variant_t vt(dec);
						_ParameterPtr p= commandPtr->CreateParameter(strParamName, adDecimal, adParamInput, sizeof(vt), vt);
						p->PutPrecision(12);
						p->PutNumericScale(0);
						hr=commandPtr->Parameters->Append(p); 
					}
					else if(iter->valType==Parameter::FLOAT_PREC)
					{
						_variant_t vt(iter->valParam.flParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adSingle, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::DOUBLE_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}
				/*	else if(iter->valType==Parameter::LONG_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::INT64_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}*/
					else if(iter->valType==Parameter::STRING)
					{
						bstr_t str(iter->valParam.chParam);
						_variant_t vt(str);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adVarChar, adParamInput, sizeof(vt), vt)); 
						
					}
				}

				else if(vtParamType.intVal==2) 

				{
				
				if(iter->valType==Parameter::DATE_TIME)
					{
						COleDateTime oleDateTime( iter->valParam.dbParam);
						_variant_t vt(oleDateTime);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDBTimeStamp, adParamOutput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::CHAR)
					{
						_variant_t vt(iter->valParam.charParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adChar, adParamOutput, sizeof(char), vt)); 
					}
					else if(iter->valType==Parameter::INTEGER)
					{
						_variant_t vt(iter->valParam.intParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adInteger, adParamOutput, sizeof(int), varLiReturn)); 
					}
					else if(iter->valType==Parameter::UNSNIGNED_INT)
					{
						_variant_t vt(iter->valParam.unIntParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adUnsignedInt, adParamOutput, sizeof(unsigned int), varLiReturn)); 
					}
					else if(iter->valType==Parameter::UNSIGNED_LG_LG)
					{
						DECIMAL dec;
						memset(&dec,0,sizeof(DECIMAL));
						dec.wReserved=14;
						dec.sign=0;
						dec.scale=0;
						dec.Lo64=iter->valParam.unLgLgParam;
						_variant_t vt(dec);
						_ParameterPtr p= commandPtr->CreateParameter(strParamName, adDecimal, adParamOutput, sizeof(vt), vt);
						p->PutPrecision(12);
						p->PutNumericScale(0);
						hr=commandPtr->Parameters->Append(p); 
					}
					else if(iter->valType==Parameter::FLOAT_PREC)
					{
						_variant_t vt(iter->valParam.flParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adSingle, adParamOutput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::DOUBLE_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamOutput, sizeof(double), varLiReturn)); 
					}
				/*	else if(iter->valType==Parameter::LONG_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}
					else if(iter->valType==Parameter::INT64_PREC)
					{
						_variant_t vt(iter->valParam.dbParam);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adDouble, adParamInput, sizeof(vt), vt)); 
					}*/
					else if(iter->valType==Parameter::STRING)
					{
						bstr_t str(iter->valParam.chParam);
						_variant_t vt(str);
						hr=commandPtr->Parameters->Append(commandPtr->CreateParameter(strParamName, adVarChar, adParamOutput, sizeof(vt), vt)); 
						
					}
				
				}

			}

		//	commandPtr->Parameters->Append ( commandPtr->CreateParameter(_T("ReturnVal1"),adInteger,adParamOutput,sizeof(int),varLiReturn));
		//	commandPtr->Parameters->Append ( commandPtr->CreateParameter(_T("ReturnVal2"),adInteger,adParamOutput,sizeof(int),varLiReturn));
			recPtr = commandPtr->Execute(NULL, NULL, adCmdStoredProc); 

       } 
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		ReleaseLock(&m_cs);
		return false;
	}
	dynamic_cast<Table&>(tbl)=recPtr;
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	ReleaseLock(&m_cs);
	return true;
}


Table::Table()
{
	m_recordPtr=NULL;
}

void Table::operator =(RECORD_PTR recPtr)
{
	m_recordPtr=recPtr;
}

bool Table::IsEOF()
{
	bool ret=true;
	if(m_recordPtr==NULL)
	{
		sprintf_s(m_errStr,BUFF_SIZE,"Invalid Record");
		return true;
	}
	try
	{
		ret=(m_recordPtr->EndOfFile==VARIANT_TRUE);
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return true;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return ret;
}

bool Table::Get(char* fieldName, std::string* fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1)
		{
		
		std::string t((char*)((_bstr_t)vtValue.bstrVal));

		std::string::iterator i;
		bool flag = false;
        for (i = t.begin(); i != t.end(); i++)
		{
            if (!isspace(*i)) {
                break;
            }
        }
		if (i == t.end()) 
		{
			t.clear();
			flag = false;
		} 
		else 
		{
			flag = true;;
			t.erase(t.begin(), i);
		}
		if( flag ) 
		{
			for (i = t.end() - 1; ;i--) {
			if (!isspace(*i)) {
				t.erase(i + 1, t.end());
				break;
			}
			if (i == t.begin()) {
				t.clear();
				break;
			}
		}
		}
		*fieldValue = t;
		
		}
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::Get(char* fieldName, char* fieldValue, unsigned int bufSize)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1) sprintf_s(fieldValue,bufSize,"%s",(LPCSTR)((_bstr_t)vtValue.bstrVal));
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::Get(char* fieldName,unsigned int& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1) fieldValue=vtValue.uintVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;

}

bool Table::Get(char* fieldName,bool& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1) fieldValue=vtValue.boolVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;

}

bool Table::Get(char* fieldName,unsigned long long& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1) fieldValue=vtValue.ullVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
	
}
bool Table::GetDateTime(char* fieldName,double& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1) 
		{
			COleDateTime oleDate(vtValue);

			
			/*tm myTime;

			myTime.tm_year = oleDate.GetYear () - 1900;
			myTime.tm_hour = oleDate.GetHour ();
			myTime.tm_mday = oleDate.GetDay ();
			myTime.tm_min = oleDate.GetMinute ();
			myTime.tm_mon = oleDate.GetMonth ();
			myTime.tm_sec = oleDate.GetSecond ();*/

			//time_t myTimeT = mktime (&myTime);
			
			fieldValue=oleDate.m_dt;
		}
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::Get(char* fieldName,int& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1) fieldValue=vtValue.intVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
  	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}


bool Table::Get(char* fieldName,float& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1)fieldValue=vtValue.fltVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::Get(char* fieldName,double& fieldValue)
{
	try
	{
	
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1)fieldValue = vtValue.operator double();
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::Get(char* fieldName,unsigned long& fieldValue)
{
	try
	{
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1)fieldValue=vtValue.ulVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
	
}

bool Table::Get(char* fieldName,char& fieldValue)
{
	try
	{
		
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
	
		if(vtValue.vt!=1)fieldValue=vtValue.cVal;
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
	
}
/*
bool Table::Get(char* fieldName,__int64& fieldValue)
{
	try
	{
	
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1)fieldValue = vtValue.operator __int64();
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}
bool Table::Get(char* fieldName,long& fieldValue)
{
	try
	{
	
		_variant_t  vtValue;
		vtValue = m_recordPtr->Fields->GetItem(fieldName)->GetValue();
		
		if(vtValue.vt!=1)fieldValue = vtValue.operator long();
		else {
				sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURN");
				return false;
		}
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}
*/

bool Table::MoveNext()
{
	try
	{
		m_recordPtr->MoveNext();
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::MovePrev()
{
	try
	{
		m_recordPtr->MovePrevious();
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::MoveFirst()
{
	try
	{
		m_recordPtr->MoveFirst();
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}

bool Table::MoveLast()
{
	try
	{
		m_recordPtr->MoveLast();
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE, "Success");
	return true;
}


bool Table::MoveNextRecord()
{
	try
	{
		long lngRec = 0;
		m_recordPtr->NextRecordset((VARIANT *)lngRec);
	}
	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}
	sprintf_s(m_errStr,BUFF_SIZE, "Success");
	return true;
}

/*
bool Table::GetOutPut(char* fieldName,int& fieldValue)
{
	try
	{
		_bstr_t str="@";
		_bstr_t strfieldName=str+fieldName;
		_variant_t  vtValue;
		vtValue = commandPtr->Parameters->Item[ strfieldName]->Value;
		if(vtValue.vt!=1) fieldValue = vtValue.intVal;
		else
		{
			sprintf_s(m_errStr,BUFF_SIZE,"NULL VALUE RETURNED");
			return true;
		}
	}
  	catch(_com_error &e)
	{
		ErrorHandler(e,m_errStr);
		return false;
	}

	sprintf_s(m_errStr,BUFF_SIZE,"Success");
	return true;
}*/

Parameter::Parameter()
{
}

Parameter::~Parameter()
{
	for(PARAMS_ITER iter=m_params.begin();iter!=m_params.end(); iter++)
	{
		free(iter->paramName);
		if(iter->valType==STRING)
		{
			free(iter->valParam.chParam);
		}
	}
	m_params.clear();
}

void Parameter::CopyFieldName(char* fieldName,char** dest)
{
	*dest=(char*)malloc(strlen(fieldName)+1);
	memcpy(*dest,fieldName,strlen(fieldName));
	(*dest)[strlen(fieldName)]=0;
}

void Parameter::CopyCharString(char* sour,char** dest,unsigned int size)
{
	*dest=(char*)malloc(size+1);
	memcpy(*dest,sour,size);
	(*dest)[size]=0;
}

void Parameter::AddParam (char* fieldName,unsigned long param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.LgParam=param;
	pr.valType=UNSIGNED_LG;
	m_params.push_back(pr);
}


void Parameter::AddParam (char* fieldName,char param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	CopyCharString(&param,&pr.valParam.chParam,1);
	pr.size=1;
	pr.valType=STRING;
	m_params.push_back(pr);
}

void Parameter::AddParam (char* fieldName,unsigned int param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.unIntParam=param;
	pr.valType=UNSNIGNED_INT;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,int param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.intParam=param;
	pr.valType=INTEGER;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,unsigned long long param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.unLgLgParam=param;
	pr.valType=UNSIGNED_LG_LG;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,float param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.flParam=param;
	pr.valType=FLOAT_PREC;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,double param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.dbParam=param;
	pr.valType=DOUBLE_PREC;
	m_params.push_back(pr);
}

void Parameter::AddParam(char* fieldName,char* param,unsigned int bufSize)

{
		int ival = strlen(param);
		if(bufSize>=ival)
		{
			PARAM pr;
			CopyFieldName(fieldName,&pr.paramName);
			CopyCharString(param,&pr.valParam.chParam,bufSize);
			pr.size=bufSize;
			pr.valType=STRING;
			m_params.push_back(pr);
		}
		else 
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Parameter::AddParam (char* fieldName,char* param,unsigned int bufSize):: bufSize size is less than param.");
		}

}



void Parameter::AddParam (char* fieldName,char param,int prType)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.charParam=param;
	pr.valType=CHAR;
	pr.paramType = prType;
	m_params.push_back(pr);
}

void Parameter::AddParam (char* fieldName,unsigned int param,int prType)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.unIntParam=param;
	pr.valType=UNSNIGNED_INT;
	pr.paramType = prType;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,int param,int prType)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.intParam=param;
	pr.valType=INTEGER;
	pr.paramType = prType;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,unsigned long long param,int prType)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.unLgLgParam=param;
	pr.valType=UNSIGNED_LG_LG;
	pr.paramType = prType;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,float param,int prType)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.flParam=param;
	pr.valType=FLOAT_PREC;
	pr.paramType = prType;
	m_params.push_back(pr);
}
void Parameter::AddParam (char* fieldName,double param,int prType)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.dbParam=param;
	pr.valType=DOUBLE_PREC;
	pr.paramType = prType;
	m_params.push_back(pr);
}
/*
void Parameter::AddParam (char* fieldName,char* param,unsigned int bufSize)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	CopyCharString(param,&pr.valParam.chParam,bufSize);
	pr.size=bufSize;
	pr.valType=STRING;
	m_params.push_back(pr);
}*/

void Parameter::AddParam(char* fieldName,char* param,unsigned int bufSize,int prType)

{
		int ival = strlen(param);
		if(bufSize>=ival)
		{
		PARAM pr;
		CopyFieldName(fieldName,&pr.paramName);
		CopyCharString(param,&pr.valParam.chParam,bufSize);
		pr.size=bufSize;
		pr.valType=STRING;
		pr.paramType = prType;
		m_params.push_back(pr);
		}
		else 
		{
			stl::log::trace(stl::log::LOG_GROUP_ERROR, stl::log::LOG_LEVEL_ALWAYS, "Parameter::AddParam (char* fieldName,char* param,unsigned int bufSize):: bufSize size is less than param.");
		}
}


/*
void Parameter::AddParam(char* fieldName,__int64 param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.dbParam=param;
	pr.valType=INT64_PREC;
	m_params.push_back(pr);
}
void Parameter::AddParam(char* fieldName,long param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.dbParam=param;
	pr.valType=LONG_PREC;
	m_params.push_back(pr);
}*/

void Parameter::AddDateTimeParam (char* fieldName,double param)
{
	PARAM pr;
	CopyFieldName(fieldName,&pr.paramName);
	pr.valParam.dbParam=param;
	pr.valType=DATE_TIME;
	m_params.push_back(pr);
}


DATABASEAPI IDatabase* CreateDatabase()
{
	return new Database();
}
DATABASEAPI void ReleaseDatabase(IDatabase* database )
{
	delete database;
}
DATABASEAPI ITable* CreateTable()
{
	return new Table();
}
DATABASEAPI void ReleaseTable(ITable* table)
{
	delete table;
}
DATABASEAPI IParameter* CreateParameter()
{
	return new Parameter();
}
DATABASEAPI void ReleaseParameter(IParameter* parameter)
{
	delete parameter;
}
