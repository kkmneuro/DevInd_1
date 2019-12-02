#pragma once

#ifdef DATABASE_EXPORTS
#define DATABASEAPI __declspec(dllexport)
#else
#define DATABASEAPI __declspec(dllimport)
#endif

#include <string>

typedef void (*p_Db_CallBack_Events)(char * mssg,int * ivalue); //By Deepak

class IParameter
{
public:
	virtual ~IParameter(){};

	virtual void AddParam (char* fieldName,char param)=0;
	virtual void AddParam (char* fieldName,unsigned int param)=0;
	virtual void AddParam (char* fieldName,int param)=0;
	virtual void AddParam (char* fieldName,unsigned long long param)=0;
	virtual void AddParam (char* fieldName,float param)=0;
	virtual void AddParam (char* fieldName,double param)=0;
	virtual void AddParam (char* fieldName,char* param,unsigned int bufSize)=0;
    virtual void AddDateTimeParam (char* fieldName,double param)=0;

	// By Deepak 

	virtual void AddParam (char* fieldName,char param,int paramType)=0;
	virtual void AddParam (char* fieldName,unsigned int param,int paramType)=0;
	virtual void AddParam (char* fieldName,int param,int paramType)=0;
	virtual void AddParam (char* fieldName,unsigned long long param,int paramType)=0;
	virtual void AddParam (char* fieldName,float param,int paramType)=0;
	virtual void AddParam (char* fieldName,double param,int paramType)=0;
	//virtual void AddParam(char* fieldName,__int64 param)=0;
	//virtual void AddParam(char* fieldName,long param)=0;
	//virtual void AddParam (char* fieldName,char* param,unsigned int bufSize)=0;
	virtual void AddParam (char* fieldName,char* param,unsigned int bufSize,int paramType)=0;
	virtual void AddParam (char* fieldName,unsigned long param) = 0;

	
};

class ITable
{
public:
	virtual ~ITable(){};
	virtual bool IsEOF()=0;
	virtual bool MoveNext()=0;
	virtual bool MovePrev()=0;
	virtual bool MoveFirst()=0;
	virtual bool MoveLast()=0;
	
	virtual bool MoveNextRecord()=0; //By Deepak 
	//virtual bool GetOutPut(char* fieldName,int& fieldValue)=0; //By Deepak 

	virtual bool Get(char* fieldName, std::string* fieldValue)=0;
	virtual bool Get(char* fieldName, char* fieldValue, unsigned int bufSize)=0;
	virtual bool Get(char* fieldName,int& fieldValue)=0;
	virtual bool Get(char* fieldName,float& fieldValue)=0;
	virtual bool Get(char* fieldName,double& fieldValue)=0;
	virtual bool Get(char* fieldName,unsigned int& fieldValue)=0;
	virtual bool Get(char* fieldName,unsigned long long& fieldValue)=0;
	virtual bool Get(char* fieldName,bool& fieldValue)=0;
	virtual bool GetDateTime(char* fieldName,double& fieldValue)=0;
	virtual void GetErrorErrStr(char* errStr, unsigned int bufSize)=0;
	virtual bool Get(char* fieldName,unsigned long& fieldValue)=0; // By Mr.Roy
	virtual bool Get(char* fieldName,char& fieldValue)=0; // By Mr.Roy

};

class IDatabase
{
public:

	virtual ~IDatabase(){};
	virtual bool Open(const char* userName,const char* pwd,const char* cnnStr)=0;
	virtual bool OpenTable(char* cmdStr,ITable& tbl )=0;
	virtual bool Execute(char* cmdStr,ITable& tbl,IParameter& prm )=0;
	virtual void GetErrorErrStr(char* errStr, unsigned int bufSize)=0;
	virtual bool Execute(char* cmdStr,ITable& tbl,IParameter& prm,int OutPut)=0; //By Deepak 
	virtual void CloseDBConnection()=0;
	virtual void callback(void * pt2Object,p_Db_CallBack_Events,char * eventName)=0;
	virtual void ExitDataBaseLib()=0;
	virtual void fnc_Event_Status(std::string eventName,int ival)=0;
	virtual bool fnc_BeginTransaction()=0;
	virtual bool fnc_CommitTransaction()=0;
	virtual bool fnc_RollBackTransaction()=0;
//	virtual char * fnc_Get_Envent_Name()=0;
//	virtual int fnc_Get_Event_Status()=0;

};

DATABASEAPI IDatabase* CreateDatabase();
DATABASEAPI void ReleaseDatabase(IDatabase* );
DATABASEAPI ITable* CreateTable();
DATABASEAPI void ReleaseTable(ITable* );
DATABASEAPI IParameter* CreateParameter();
DATABASEAPI void ReleaseParameter(IParameter* );

/*
	Sample code for database wrapper calss
	--------------------------------------

	char strConnect[1000] = _T( "Provider=sqloledb;Data Source=LTI-05;Initial Catalog=OMSExchange;" );
	IDatabase * pDatabase=CreateDatabase();
	pDatabase->Open("sa","admin123@",strConnect);//Connecting to data base
	ITable* tb=CreateTable();//create empty table used for storing return table from sp
	IParameter* param=CreateParameter();//create empty paramter list for sp
	double Qunantity=1234567.8987;
	param->AddParam("Quantity",Qunantity);//add a parametr to list of parameters
	pDatabase->Execute("TestDummy1",*tb,*param);//execute sp
	while(!tb->IsEOF())//loop the table
	{
		double Quantity=0;
		tb->Get("Quantity",Quantity);
		tb->MoveNext();
	}
	ReleaseTable(tb);//release table object
	ReleaseParameter(param);//release parameter objec
	ReleaseDatabase(pDatabase);//release database object

*/