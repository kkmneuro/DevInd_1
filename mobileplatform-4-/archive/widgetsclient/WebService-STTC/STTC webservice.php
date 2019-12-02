<?php

	class AccountGroup
    {
		public $GroupName;                      // Group Name
		public $Hedging;                        // Hedging
		public $Spread_Diff;                    // Spread_Diff
		public $Active;                         // Manager Status     
		public $LastUpdatedtime;                // Last Updated Time
	}
	
	class Symbol
    {
		public $SymbolName;       				// Symbol Name
		public $AssetClass;       				// Asset Class
		public $ContractSize;    				// Contract Size
		public $Active;          			    // Symbol Status
		public $Digits;          			    // Digits
		public $Spread;          				// Spread
		public $TickSize;        				// TickSize
		public $TickValue;       				// TickValue
		public $LastUpdatedTime;				// Last Updated Time
    }
	
	class TCInstance
    {
		public $InstanceName;                   // Instance Name
		public $Login;                          // Login
		public $Password;                       // Password
		public $Active;                         // Active
		public $Port;                           // Port
		public $IP;                             // IP        
		public $LastUpdatedTime;                // Last Updated Time
    }

	class Gateway
    {
		public $GTLogin;                        // Login        
		public $GTPassword;                     // Password
		public $GatewayType;                    // Gateway Type
		public $Platform;                       // Platform
		public $IP;                             // IP
		public $Port;                           // port
		public $LastUpdatedtime;                // Last Updated Time

    }

	class GatewayConnection
    {
		public $ConnID;                        // Connection ID      
		public $GCLogin;                        // Connection Login        
		public $GCPassword;                     // Connection Password
		public $IP;                             // IP
		public $Port;                           // port
		public $ServerName;                     // Server Name
		public $Active;                         // Account Status
		public $TargetCompID;                   // Target Comp ID
		public $SenderCompID;                   // Sender Comp ID
		public $SenderSubID;                    // Sender Sub ID
		public $TradeIP;                        // Trade IP
		public $TradePort;                      // Trade Port
		public $ServerAPIIP;                    // Server API IP
		public $ServerAPIPort;                  // Server API Port
		public $BrokerID;                       // Broker ID
		public $WalletAccount;                  // Wallet Account
		public $Gateway;                        // Gateway
		public $LastUpdatedtime;                // Last Updated Time      

    }

	class AccountInfo
    {
		public $AccountID;                   	// Account ID
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
		public $GroupID;                      // Group Name
		public $ConnID;                // Connection Login
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
		public $MasterAccount;                    // Master Account
		public $SlaveAccount;                     // Slave Account         
		public $CopyMode;                       // Copy Mode
		public $CloseOrders;                    // Close Orders
		public $CopyMethod;                     // Manage Lots
		public $CopyValue;                      // Money Mgmt Rules  
		public $CopyTrade;                      // Copy Trade  
		public $Slippage;                       // Slippage    
		public $LastUpdatedtime;                // Last Updated Time                

    }
	
	try{
		$Login		= 'admin';
		$Password	= '123';
		$webURL		= "http://192.168.1.84:9090/STTCservice.svc?wsdl";
		
		$client = new SoapClient($webURL);
		
		// For GetAccountGroups //
		$GroupId = 0;
		$param_GetAccountGroups=array('Login'=>$Login,'Password'=>$Password,'GroupId'=>$GroupId); 
		@$webService = $client->GetAccountGroups($param_GetAccountGroups);
		
		// For AddAccountGroups //
		$objAG = new AccountGroup();
		$objAG->GroupName = 'testwebservice';
		$objAG->Hedging =1;
		$objAG->Spread_Diff = 0.00;
		$objAG->Active= 1;
		$objAG->LastUpdatedtime= '0001-01-01T00:00:00';

		$param_AddAccountGroups=array('Login'=>$Login,'Password'=>$Password,'objAccountGroup'=>$objAG); 
		@$webService = $client->AddAccountGroups($param_AddAccountGroups);
		
		// UpdateAccountGroups //
		$objAG = new AccountGroup();
		$objAG->GroupName = 'testwebservice';
		$objAG->Hedging =1;
		$objAG->Spread_Diff = 0.00;
		$objAG->Active= 0;
		$objAG->LastUpdatedtime= '2016-08-28T19:37:20';

		$param_UpdateAccountGroups=array('Login'=>$Login,'Password'=>$Password,'objAccountGroup'=>$objAG); 
		@$webService = $client->UpdateAccountGroups($param_UpdateAccountGroups);
		
		// For GetPlatformDetails //
		$param_GetPlatformDetails=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetPlatformDetails($param_GetPlatformDetails);*/
		
		// For AddPlatform //
		$param_AddPlatform=array('Login'=>$Login,'Password'=>$Password,'Platform'=>'TestPlatform'); 
		@$webService = $client->AddPlatform($param_AddPlatform);
		
		// For GetAllSymbols //
		$param_GetAllSymbols=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAllSymbols($param_GetAllSymbols);
		
		// For AddSymbol //
		
		$objAG = new Symbol();
		$objAG->SymbolName = 'USDCHFTEST';
		$objAG->AssetClass ='Forex';
		$objAG->ContractSize = 100000.00;
		$objAG->Active= 0;
		$objAG->Digits= 4;
		$objAG->Spread= 0.00;
		$objAG->TickSize= 0;
		$objAG->TickValue= 0;
		$objAG->LastUpdatedtime= '0001-01-01T00:00:00';
		
		$param_AddSymbol=array('Login'=>$Login,'Password'=>$Password,'objSymbol'=>$objAG); 
		@$webService = $client->AddSymbol($param_AddSymbol);
		
		
		// For UpdateSymbol //
		
		$objAG = new Symbol();
		$objAG->SymbolName = 'USDCHFTEST2';
		$objAG->AssetClass ='Forex';
		$objAG->ContractSize = 100000.00;
		$objAG->Active= 0;
		$objAG->Digits= 4;
		$objAG->Spread= 0.00;
		$objAG->TickSize= 0;
		$objAG->TickValue= 0;
		$objAG->LastUpdatedtime= '0001-01-01T00:10:10';
		
		$param_UpdateSymbol=array('Login'=>$Login,'Password'=>$Password,'objSymbol'=>$objAG); 
		@$webService = $client->UpdateSymbol($param_UpdateSymbol);
		
		// For GetAllTCInstances //
		$param_GetAllTCInstances=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAllTCInstances($param_GetAllTCInstances);
		
		
		// For AddTCInstance //
		
		$objAG = new TCInstance();
		$objAG->InstanceName = 'TCTEST';
		$objAG->Login ='TCTEST';
		$objAG->Password = 'TCTESTPASS';
		$objAG->Active= 0;
		$objAG->Port= 10051;
		$objAG->IP= '127.0.0.1';
		$objAG->LastUpdatedTime= '2016-08-30T14:05:44';
		
		$param_AddTCInstance=array('Login'=>$Login,'Password'=>$Password,'objTCInstance'=>$objAG); 
		@$webService = $client->AddTCInstance($param_AddTCInstance);
		
		// For UpdateTCInstance //
		
		$objAG = new TCInstance();
		$objAG->InstanceName = 'TCTEST';
		$objAG->Login ='TCTEST';
		$objAG->Password = 'TCTESTPASS';
		$objAG->Active= 0;
		$objAG->Port= 10052;
		$objAG->IP= '127.0.0.1';
		$objAG->LastUpdatedTime= '2016-08-30T14:10:44';
		
		$param_UpdateTCInstance=array('Login'=>$Login,'Password'=>$Password,'objTCInstance'=>$objAG); 
		@$webService = $client->UpdateTCInstance($param_UpdateTCInstance);
		
		
		// For GetGatewaysList //
		$param_GetGatewaysList=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetGatewaysList($param_GetGatewaysList);
		
		
		// For AddGateway //
		
		$objAG = new Gateway();
		$objAG->GTLogin = 'PKSTEST3';
		$objAG->GTPassword ='PKSTEST';
		$objAG->GatewayType = 'ManagerAPI';
		$objAG->Platform= 'MT4';
		$objAG->IP= '127.0.0.1';
		$objAG->Port= 10004;
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_AddGateway=array('Login'=>$Login,'Password'=>$Password,'objGateway'=>$objAG); 
		@$webService = $client->AddGateway($param_AddGateway);
		
		// For UpdateGateway //
		
		$objAG = new Gateway();
		$objAG->GTLogin = 'PKSTEST';
		$objAG->GTPassword ='PKSTEST';
		$objAG->GatewayType = 'ManagerAPI';
		$objAG->Platform= 'MT4';
		$objAG->IP= '127.0.0.1';
		$objAG->Port= 10005;
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_UpdateGateway=array('Login'=>$Login,'Password'=>$Password,'objGateway'=>$objAG); 
		@$webService = $client->UpdateGateway($param_UpdateGateway);
		
		// For GetTCInstanceGatewayMapping //
		$param_GetTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetTCInstanceGatewayMapping($param_GetTCInstanceGatewayMapping);
		
		// For AddTCInstanceGatewayMapping //
	$TCInstanceId = 1;
	$GatewayId = 5;
	$param_AddTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password,'TCInstanceId'=>$TCInstanceId,'GatewayId'=>$GatewayId); 
	@$webService = $client->AddTCInstanceGatewayMapping($param_AddTCInstanceGatewayMapping);
		
		
		// For UpdateTCInstanceGatewayMapping //
	$TCInstanceId = 1;
	$GatewayId = 3;
	$param_UpdateTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password,'TCInstanceId'=>$TCInstanceId,'GatewayId'=>$GatewayId); 
	@$webService = $client->UpdateTCInstanceGatewayMapping($param_UpdateTCInstanceGatewayMapping);
		
		// For DeleteTCInstanceGatewayMapping //
	$TCInstanceId = 1;
	$GatewayId = 3;
	$param_DeleteTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password,'TCInstanceId'=>$TCInstanceId,'GatewayId'=>$GatewayId); 
	@$webService = $client->DeleteTCInstanceGatewayMapping($param_DeleteTCInstanceGatewayMapping);
		
		
		// For GetGatewayConnectionList //
		$param_GetGatewayConnectionList=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetGatewayConnectionList($param_GetGatewayConnectionList);
		
		
		
		// For AddGatewayConnection // working
		
		$objAG = new GatewayConnection();
		$objAG->ConnID = 4;
		$objAG->GCLogin = '2';
		$objAG->GCPassword ='PKS3';
		$objAG->IP = '192.168.1.84';
		$objAG->Port= 443;
		$objAG->ServerName= 'localeserver1';
		$objAG->Active= 1;
		$objAG->TargetCompID= '0';
		$objAG->SenderCompID= '0';
		$objAG->SenderSubID= '0';
		$objAG->TradeIP= '0';
		$objAG->TradePort= '0';
		$objAG->ServerAPIIP= '192.168.1.84';
		$objAG->ServerAPIPort= 3333;
		$objAG->BrokerID= 123;
		$objAG->WalletAccount= 5000;
		$objAG->Gateway= 'PKSTEST';
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_AddGatewayConnection=array('Login'=>$Login,'Password'=>$Password,'objGatewayConnection'=>$objAG); 
		@$webService = $client->AddGatewayConnection($param_AddGatewayConnection);
		
		// For UpdateGatewayConnection //
		
		$objAG = new GatewayConnection();
		$objAG->ConnID = 4;
		$objAG->GCLogin = '2';
		$objAG->GCPassword ='PKS3';
		$objAG->IP = '192.168.1.84';
		$objAG->Port= 443;
		$objAG->ServerName= 'localeserver1';
		$objAG->Active= 1;
		$objAG->TargetCompID= '0';
		$objAG->SenderCompID= '0';
		$objAG->SenderSubID= '0';
		$objAG->TradeIP= '0';
		$objAG->TradePort= '0';
		$objAG->ServerAPIIP= '192.168.1.84';
		$objAG->ServerAPIPort= 3333;
		$objAG->BrokerID= 123;
		$objAG->WalletAccount= 5000;
		$objAG->Gateway= 'PKSTEST';
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_UpdateGatewayConnection=array('Login'=>$Login,'Password'=>$Password,'objGatewayConnection'=>$objAG); 
		@$webService = $client->UpdateGatewayConnection($param_UpdateGatewayConnection);
		
		// For GetAccounts //
		$param_GetAccounts=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAccounts($param_GetAccounts);
		
		// For AddAccounts //
		$objAG = new AccountInfo();
		$objAG->AccountID = 15;
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
		@$webService = $client->AddAccounts($param_AddAccounts);
		
		// For UpdateAccount //
		$objAG = new AccountInfo();
		$objAG->AccountID = 15;
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
		@$webService = $client->UpdateAccount($param_UpdateAccount);	
		
		// For GetAccountGroupConnectionMapping //
		$param_GetAccountGroupConnectionMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAccountGroupConnectionMapping($param_GetAccountGroupConnectionMapping);
		
		// For AddAccountGroupConnectionMapping // 
		$objAG = new AccountGroupConMapping();
		$objAG->ConnGroupName = 'LIVEPKS';
		$objAG->GroupID = 1;
		$objAG->ConnID = 3;
		$objAG->Active = 1;
		$objAG->LastUpdatedtime = '2016-09-18T19:37:20';

		$param_AddAccountGroupConnectionMapping=array('Login'=>$Login,'Password'=>$Password,'objAccountGroupConMapping'=>$objAG); 
		@$webService = $client->AddAccountGroupConnectionMapping($param_AddAccountGroupConnectionMapping);
		
		// For UpdateccountGroupConnectionMapping //
		$objAG = new AccountGroupConMapping();
		$objAG->ConnGroupName = 'LIVEPKS2';
		$objAG->GroupID = 1;
		$objAG->ConnID = 3;
		$objAG->Active = 0;
		$objAG->LastUpdatedtime = '2016-09-18T19:37:20';

		$param_UpdateAcountGroupConnectionMapping=array('Login'=>$Login,'Password'=>$Password,'objAccountGroupConMapping'=>$objAG); 
		@$webService = $client->UpdateAcountGroupConnectionMapping($param_UpdateAcountGroupConnectionMapping);
		
		// For GetGroupSymbolMapping //
		$param_GetGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetGroupSymbolMapping($param_GetGroupSymbolMapping);
		
		// For AddGroupSymbolMapping //
		$objAG = new GroupSymbolMapping();
		$objAG->GroupName = 'testwebservice';
		$objAG->SymbolName ='GBPAUD';
		$objAG->AliasName = 'GBPAUD';
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_AddGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG); 
		@$webService = $client->AddGroupSymbolMapping($param_AddGroupSymbolMapping);
		
		// For UpdateGroupSymbolMapping //
		$objAG = new GroupSymbolMapping();
		$objAG->GroupName = 'testwebservice';
		$objAG->SymbolName ='GBPAUD';
		$objAG->AliasName = 'GBPAUD2';
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';

		$param_UpdateGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG); 
		@$webService = $client->UpdateGroupSymbolMapping($param_UpdateGroupSymbolMapping);
		
		
		// For DeleteGroupSymbolMapping //
		$objAG = new GroupSymbolMapping();
		$objAG->GroupName = 'testwebservice';
		$objAG->SymbolName ='GBPAUD';
		$objAG->AliasName = 'GBPAUD2';
		$objAG->LastUpdatedtime = '2016-08-28T19:37:20';
		
		$param_DeleteGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG); 
		@$webService = $client->DeleteGroupSymbolMapping($param_DeleteGroupSymbolMapping);
		
		
		// For GetMasterSlaveMapping //
		$param_GetMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetMasterSlaveMapping($param_GetMasterSlaveMapping);
		
		// For AddMasterSlaveMapping //
		$objAG = new MasterSlaveMapping();
		$objAG->MasterAccount = 1;
		$objAG->SlaveAccount =3;
		$objAG->CopyMode = 0;
		$objAG->CloseOrders = 0;
		$objAG->CopyMethod = 'PERCENTAGE';
		$objAG->CopyValue = '100';
		$objAG->CopyTrade = 1;
		$objAG->Slippage  = 0;
		$objAG->LastUpdatedtime = '2016-09-02T05:54:08';
		
		
		$param_AddMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'objMasterSlaveMapping'=>$objAG); 
		@$webService = $client->AddMasterSlaveMapping($param_AddMasterSlaveMapping);
		
		
		// For UpdateMasterSlaveMapping // working
		$objAG = new MasterSlaveMapping();
		$objAG->MasterAccount = 1;
		$objAG->SlaveAccount =3;
		$objAG->CopyMode = 0;
		$objAG->CloseOrders = 1;
		$objAG->CopyMethod = 'PERCENTAGE';
		$objAG->CopyValue = '100';
		$objAG->CopyTrade = 1;
		$objAG->Slippage  = 0;
		$objAG->LastUpdatedtime = '2016-09-12T05:54:08';
		
		
		$param_UpdateMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'objMasterSlaveMapping'=>$objAG); 
		@$webService = $client->UpdateMasterSlaveMapping($param_UpdateMasterSlaveMapping);
		
		
		// For DeleteMasterSlaveMapping // working
		
	$MasterAccount = 1;
	$SlaveAccount = 3;
	
	$param_DeleteMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'MasterAccount'=>$MasterAccount,'SlaveAccount'=>$SlaveAccount); 
	@$webService = $client->DeleteMasterSlaveMapping($param_DeleteMasterSlaveMapping);
		
		// For GetOpenTrades //
		
		$FromDate = '2001-08-08';
		$ToDate   = '2016-08-08';
		$param_GetOpenTrades=array('FromDate'=>$FromDate,'ToDate'=>$ToDate,'Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetOpenTrades($param_GetOpenTrades);
		
		////////// For Get And Print Result   //////////
		//echo json_encode($webService);
		echo"<pre>"; print_r($webService); //die;
		
	
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