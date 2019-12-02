/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if !defined _DataBaseManagerImpl_H_
#define _DataBaseManagerImpl_H_

#pragma once


//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "ServerInterface.h"

//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================





//*************************************************************************************************
// class DataBaseManagerImpl
//
//*************************************************************************************************
class DataBaseManagerImpl	: public IDataBaseManager
{

//METHODS-------
public:
	DataBaseManagerImpl();
	void	InitDatabase( char* UserName, char* Password, char* ConnString ); 
	virtual ~DataBaseManagerImpl();
	virtual  IDatabase* getDatabase();

private:
	IDatabase*   m_Database;

};//class DataBaseManagerImpl


#endif //_DataBaseManagerImpl_H_

