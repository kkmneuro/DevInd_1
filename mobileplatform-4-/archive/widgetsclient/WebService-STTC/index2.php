<?php

	class AccountInfo
    {
		public $ExternalID;                   	// Account login
		public $Password;                     	// Password
		public $Gateway;                      	// Gateway Name
		public $TCInstanceName;               	// TCInstance Name
		public $AccountGroup;                 	// Account Group Name
		public $Connection;                   	// Connection Name        
		public $ParticipantLoginID;           	// Participant LoginID
		public $ParticipantPassword;          	// Participant Password
		public $RootToMT4Server;                // Root To MT4Server
		public $PStype;                         // PStype
		public $PSShare;                     	// PSShare
		public $ShareInProfitOnly;              // ShareInProfitOnly
		public $InstantDeduction;               // InstantDeduction
		public $Active;                         // Account Status
		public $LastUpdatedtime;            	// Last Updated Time        

    }

	class AccountGroupConMapping
    {
		public $ConnGroupName;                  // Conn Group Name
		public $GroupName;                      // Group Name
		public $ConnectionLogin;                // Connection Login
		public $Active;                         // Account Group Con Mapping Status
		public $LastUpdatedtime;                // Last Updated Time                
    }

	class GroupSymbolMapping
    {
		public $GroupName;                      // Group Name
		public $SymbolName;                     // Symbol Name
		public $AliasName;                      // AliasName                  
		public $LastUpdatedtime;                // Last Updated Time                
    }

	class MasterSlaveMapping
    {
		public $MasterLogin;                    // Master Login
		public $SlaveLogin;                     // Slave Login         
		public $CopyMode;                       // Copy Mode
		public $CloseOrders;                    // Close Orders
		public $CopyMethod;                     // Manage Lots
		public $CopyValue;                      // Money Mgmt Rules  
		public $CopyTrade;                      // Copy Trade  
		public $Slippage;                       // Slippage    
		public $LastUpdatedtime;                // Last Updated Time                

    }

		
	try{
		$Login = 'admin';
		$Password = '123';
		
		$client = new
				
		SoapClient("http://192.168.1.84:9090/STTCservice.svc?wsdl");
		
		// For GetAccounts //
		$param_GetAccounts=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAccounts($param_GetAccounts);
		
		// For AddAccounts //
		/*$objAG = new AccountInfo();
		$objAG->ExternalID = '124';
		$objAG->Password ='pks';
		$objAG->Gateway = 'PKSTEST';
		$objAG->TCInstanceName= 'TC1';
		$objAG->AccountGroup= 'demoforex';
		$objAG->Connection = '0';
		$objAG->ParticipantLoginID = 'mt4tc1';
		$objAG->ParticipantPassword = 'mt4tc1';
		$objAG->RootToMT4Server = 0;
		$objAG->PStype = 0;
		$objAG->PSShare = 0;
		$objAG->ShareInProfitOnly = 0;
		$objAG->InstantDeduction = 0;
		$objAG->Active = 1;
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_AddAccounts=array('Login'=>$Login,'Password'=>$Password,'objAccountInfo'=>$objAG); 
		@$webService = $client->AddAccounts($param_AddAccounts);*/
		
		// For UpdateAccount //
		/*$objAG = new AccountInfo();
		$objAG->ExternalID = '124';
		$objAG->Password ='pks';
		$objAG->Gateway = 'PKSTEST';
		$objAG->TCInstanceName= 'TC1';
		$objAG->AccountGroup= 'demoforex';
		$objAG->Connection = '0';
		$objAG->ParticipantLoginID = 'mt4tc2';
		$objAG->ParticipantPassword = 'mt4tc2';
		$objAG->RootToMT4Server = 0;
		$objAG->PStype = 0;
		$objAG->PSShare = 0;
		$objAG->ShareInProfitOnly = 0;
		$objAG->InstantDeduction = 0;
		$objAG->Active = 1;
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_UpdateAccount=array('Login'=>$Login,'Password'=>$Password,'objAccountInfo'=>$objAG); 
		@$webService = $client->UpdateAccount($param_UpdateAccount);*/		
		
		// For GetAccountGroupConnectionMapping //
		/*$param_GetAccountGroupConnectionMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAccountGroupConnectionMapping($param_GetAccountGroupConnectionMapping);*/
		
		// For AddAccountGroupConnectionMapping //
		/*$objAG = new AccountGroupConMapping();
		$objAG->ConnGroupName = 'LIVEPKS';
		$objAG->GroupName ='demoforex';
		$objAG->ConnectionLogin = '1';
		$objAG->Active = 1;
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_AddAccountGroupConnectionMapping=array('Login'=>$Login,'Password'=>$Password,'objAccountGroupConMapping'=>$objAG); 
		@$webService = $client->AddAccountGroupConnectionMapping($param_AddAccountGroupConnectionMapping);*/
		
		// For UpdateccountGroupConnectionMapping //
		/*$objAG = new AccountGroupConMapping();
		$objAG->ConnGroupName = 'LIVEPKS';
		$objAG->GroupName ='demoforex';
		$objAG->ConnectionLogin = '1';
		$objAG->Active = 1;
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_UpdateccountGroupConnectionMapping=array('Login'=>$Login,'Password'=>$Password,'objAccountGroupConMapping'=>$objAG); 
		@$webService = $client->UpdateccountGroupConnectionMapping($param_UpdateccountGroupConnectionMapping);*/
		
		// For GetGroupSymbolMapping //
		/*$param_GetGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetGroupSymbolMapping($param_GetGroupSymbolMapping);*/
		
		// For AddGroupSymbolMapping //
		/*$objAG = new GroupSymbolMapping();
		$objAG->GroupName = 'testwebservice';
		$objAG->SymbolName ='GBPAUD';
		$objAG->AliasName = 'GBPAUD';
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_AddGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG); 
		@$webService = $client->AddGroupSymbolMapping($param_AddGroupSymbolMapping);*/
		
		// For UpdateGroupSymbolMapping //
		/*$objAG = new GroupSymbolMapping();
		$objAG->GroupName = 'testwebservice';
		$objAG->SymbolName ='GBPAUD';
		$objAG->AliasName = 'GBPAUD2';
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_UpdateGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG); 
		@$webService = $client->UpdateGroupSymbolMapping($param_UpdateGroupSymbolMapping);*/
		
		
		// For DeleteGroupSymbolMapping //
		/*$objAG = new GroupSymbolMapping();
		$objAG->GroupName = 'testwebservice';
		$objAG->SymbolName ='GBPAUD';
		$objAG->AliasName = 'GBPAUD2';
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';
		
		$param_DeleteGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG); 
		@$webService = $client->DeleteGroupSymbolMapping($param_DeleteGroupSymbolMapping);*/
		
		
		// For GetMasterSlaveMapping //
		/*$param_GetMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetMasterSlaveMapping($param_GetMasterSlaveMapping);*/
		
		// For ManageMasterSlaveMapping //
		/*$objAG = new MasterSlaveMapping();
		$objAG->MasterLogin = '11';
		$objAG->SlaveLogin ='8';
		$objAG->CopyMode = 0;
		$objAG->CloseOrders = 0;
		$objAG->CopyMethod = 'FIX_LOTS';
		$objAG->CopyValue = '100';
		$objAG->CopyTrade = 1;
		$objAG->Slippage  = 0;
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';
		
		$MasterGatewayConn = 3;
		$SlaveGatewayConn = 3;
		
		$param_ManageMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'objMasterSlaveMapping'=>$objAG,'MasterGatewayConn'=>$MasterGatewayConn,'SlaveGatewayConn'=>$SlaveGatewayConn); 
		@$webService = $client->ManageMasterSlaveMapping($param_ManageMasterSlaveMapping);*/
		
		// For DeleteMasterSlaveMapping //
		/*$objAG = new MasterSlaveMapping();
		$objAG->MasterLogin = '3';
		$objAG->SlaveLogin ='4';
		$objAG->CopyMode = 0;
		$objAG->CloseOrders = 0;
		$objAG->CopyMethod = 'PERCENTAGE';
		$objAG->CopyValue = '100';
		$objAG->CopyTrade = 1;
		$objAG->Slippage = 0;
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';
		
		
		$MasterGatewayConn = 3;
		$SlaveGatewayConn = 4;
		
		$param_DeleteMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'objMasterSlaveMapping'=>$objAG,'MasterGatewayConn'=>$MasterGatewayConn,'SlaveGatewayConn'=>$SlaveGatewayConn); 
		@$webService = $client->DeleteMasterSlaveMapping($param_DeleteMasterSlaveMapping);*/
		
		// For GetOpenTrades //
		
		/*$FromDate = '2001-08-08';
		$ToDate   = '2016-09-15';
		$param_GetOpenTrades=array('FromDate'=>$FromDate,'ToDate'=>$ToDate,'Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetOpenTrades($param_GetOpenTrades);*/
		
		
		////////// For Get And Print Result   //////////
		
		echo"<pre>";
		print_r($webService); //die;
		
	} catch (Exception $e) {
		
		print  '<br>Caught exception: '.  $e->getMessage(). "\n";		
		}   
	

	function objectToArray($d) 
	{
		if (is_object($d)) {
			// Gets the properties of the given object
			// with get_object_vars function
			$d = get_object_vars($d);
		}
		if (is_array($d)) {
			/*
			* Return array converted to object
			* Using __FUNCTION__ (Magic constant)
			* for recursive call
			*/
			return array_map(__FUNCTION__, $d);
		}
		else {
			// Return array
			return $d;
		}
	}



?>