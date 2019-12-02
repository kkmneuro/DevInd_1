///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//22-01-2012	BR			1. Class declaration and definitions. The class manages the business logic for the OMS.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


#include "stdafx.h"
#include "ServerInterface.h"

#include <string>


class TradeBOBL;


class IRoute;

class TradeBOBL : public IServerBL
{
public:
	TradeBOBL();

	~TradeBOBL(){} ;
	IRequest*			getIRequestPointer(MESSAGE msg);
	void				onNewClientAdded(unsigned clientID,IConnectionMgr * mgr = NULL);
	void				onNewClientAdded(IClientSession *clientID);
	void				onClientDisconnected(unsigned clientID);	
	void				setConnectionMgr(IConnectionMgr* ptrIConnectionMgr);
	unsigned int		GetClientID();
	unsigned int		GetClientIDMDE();
	void				ReadConfig();


private:

private:
	IConnectionMgr*		_ptrConnectionMgr;
	IAccountMgr*		_ptrAccountMgr;
	IDatabase*			m_DatabaseBO;
	IDatabase*			m_DatabaseOMS;
	IRoute*				m_pRoute;

	std::string			m_strConnStringBO;
	std::string			m_strUserNameBO;
	std::string			m_strPasswordBO;

	std::string			m_strConnStringOMS;
	std::string			m_strUserNameOMS;
	std::string			m_strPasswordOMS;

	DWORD				m_dwGitCookie;

	IContractManagerPtr	m_pContractManager;
};