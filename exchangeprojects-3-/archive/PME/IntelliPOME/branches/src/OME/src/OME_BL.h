#pragma once
#include "OME_Interface.h"

class GatewayClient;
class  OME_BL : public IServerBL
{
public:
	IConnectionMgr*					m_connnetionMgr;
	IConnectionMgr*					m_connnetionMgrMDE;
	IOrderHandler*					m_orderHandler;
	IDatabase*						m_databaseMgr;
	IDatabase*						m_DatabaseOME;
	unsigned int					m_clientID;
	unsigned int					m_clientIDMDE;

	std::string						m_strConnStringBO;
	std::string						m_strUserNameBO;
	std::string						m_strPasswordBO;

	std::string						m_strConnStringOME;
	std::string						m_strUserNameOME;
	std::string						m_strPasswordOME;

	GatewayClient*					m_pClient;
	
public:
	OME_BL(IConnectionMgr* pIConnectionMgr,IConnectionMgr* pIConnectionMgrMDE);
	virtual		~OME_BL();
	virtual		IRequest*			getIRequestPointer(MESSAGE msg) ;
	virtual		void				onNewClientAdded(unsigned int clientID, IConnectionMgr *ptrMgr = NULL);
	virtual		void				onNewClientAdded(IClientSession *clientID) {};
	virtual		void				onClientDisconnected(unsigned int clientID);	
	virtual		void				setConnectionMgr(IConnectionMgr* ptrIConnectionMgr) ;
	virtual		unsigned int		GetClientID();
	virtual		unsigned int		GetClientIDMDE();
	virtual     void				InitializeSystem();
				

	void							ReadConfig();
	void							SendBusinessReject(char reqType,
														int BusinessRejectReason,
														char *BusinessRejectRefID,
														char *reason);
};




