/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//=================================================================================================
// INCLUDE FILES
//=================================================================================================
#include "DataBaseManagerImpl.h"


//=================================================================================================
// FORWARD REFERENCES
//=================================================================================================


//=================================================================================================
// DEFINES
//=================================================================================================
#ifdef _this
#undef _this
#endif
#define _this "DataBaseManagerImpl"




DataBaseManagerImpl::DataBaseManagerImpl()
:m_Database(NULL)
{
}




DataBaseManagerImpl::~DataBaseManagerImpl()
{
	if( m_Database != NULL )
	{
		ReleaseDatabase( m_Database );
	}
	m_Database = NULL;
}

void DataBaseManagerImpl::InitDatabase( char* UserName, char* Password, char* ConnString )
{
	if( m_Database == NULL )
	{
		m_Database = CreateDatabase(); 
		if( ! m_Database->Open( UserName , Password , ConnString ) )
		{
			ReleaseDatabase( m_Database );
			m_Database = NULL;
			//throw std::exception("Unable to connect database");
		}
	}
}


IDatabase* DataBaseManagerImpl::getDatabase()
{
	return m_Database;
}