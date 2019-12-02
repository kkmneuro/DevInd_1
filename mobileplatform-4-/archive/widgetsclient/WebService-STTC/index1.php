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

	
	try{
		$Login = 'admin';
		$Password = '123';
		
		$client = new SoapClient("http://192.168.1.84:9090/STTCservice.svc?wsdl");
		//$client = new SoapClient("http://216.75.21.45:9000/STTCservice.svc?wsdl");
		
		// For GetAccountGroups //
		/*$param_GetAccountGroups=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAccountGroups($param_GetAccountGroups);*/
		
		// For AddAccountGroups //
		/*$objAG = new AccountGroup();
		$objAG->GroupName = 'testwebservice';
		$objAG->Hedging =1;
		$objAG->Spread_Diff = 0.00;
		$objAG->Active= 1;
		$objAG->LastUpdatedtime= '0001-01-01T00:00:00';

		$param_AddAccountGroups=array('Login'=>$Login,'Password'=>$Password,'objAccountGroup'=>$objAG); 
		@$webService = $client->AddAccountGroups($param_AddAccountGroups);*/
		
		// UpdateAccountGroups //
		/*$objAG = new AccountGroup();
		$objAG->GroupName = 'testwebservice';
		$objAG->Hedging =1;
		$objAG->Spread_Diff = 0.00;
		$objAG->Active= 0;
		$objAG->LastUpdatedtime= '2016-08-28T19:37:20';

		$param_UpdateAccountGroups=array('Login'=>$Login,'Password'=>$Password,'objAccountGroup'=>$objAG); 
		@$webService = $client->UpdateAccountGroups($param_UpdateAccountGroups);*/
		
		// For GetPlatformDetails //
		$param_GetPlatformDetails=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetPlatformDetails($param_GetPlatformDetails);
		
		// For AddPlatform //
		/*$param_AddPlatform=array('Login'=>$Login,'Password'=>$Password,'Platform'=>'TestPlatform'); 
		@$webService = $client->AddPlatform($param_AddPlatform);*/
		
		// For GetAllSymbols //
		/*$param_GetAllSymbols=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAllSymbols($param_GetAllSymbols);*/
		
		// For AddSymbol //
		
		/*$objAG = new Symbol();
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
		@$webService = $client->AddSymbol($param_AddSymbol);*/
		
		
		// For UpdateSymbol //
		
		/*$objAG = new Symbol();
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
		@$webService = $client->UpdateSymbol($param_UpdateSymbol);*/
		
		// For GetAllTCInstances //
		/*$param_GetAllTCInstances=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetAllTCInstances($param_GetAllTCInstances);*/
		
		
		// For AddTCInstance //
		
		/*$objAG = new TCInstance();
		$objAG->InstanceName = 'TCTEST';
		$objAG->Login ='TCTEST';
		$objAG->Password = 'TCTESTPASS';
		$objAG->Active= 0;
		$objAG->Port= 10051;
		$objAG->IP= '127.0.0.1';
		$objAG->LastUpdatedTime= '2016-08-30T14:05:44';
		
		$param_AddTCInstance=array('Login'=>$Login,'Password'=>$Password,'objTCInstance'=>$objAG); 
		@$webService = $client->AddTCInstance($param_AddTCInstance);*/
		
		// For UpdateTCInstance //
		
		/*$objAG = new TCInstance();
		$objAG->InstanceName = 'TCTEST';
		$objAG->Login ='TCTEST';
		$objAG->Password = 'TCTESTPASS';
		$objAG->Active= 0;
		$objAG->Port= 10052;
		$objAG->IP= '127.0.0.1';
		$objAG->LastUpdatedTime= '2016-08-30T14:10:44';
		
		$param_UpdateTCInstance=array('Login'=>$Login,'Password'=>$Password,'objTCInstance'=>$objAG); 
		@$webService = $client->UpdateTCInstance($param_UpdateTCInstance);*/
		
		
		// For GetGatewaysList //
		/*$param_GetGatewaysList=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetGatewaysList($param_GetGatewaysList);*/
		
		
		// For AddGateway //
		
		/*$objAG = new Gateway();
		$objAG->GTLogin = 'PKSTEST';
		$objAG->GTPassword ='PKSTEST';
		$objAG->GatewayType = 'ManagerAPI';
		$objAG->Platform= 'MT4';
		$objAG->IP= '127.0.0.1';
		$objAG->Port= 10004;
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_AddGateway=array('Login'=>$Login,'Password'=>$Password,'objGateway'=>$objAG); 
		@$webService = $client->AddGateway($param_AddGateway);*/
		
		// For UpdateGateway //
		
		/*$objAG = new Gateway();
		$objAG->GTLogin = 'PKSTEST';
		$objAG->GTPassword ='PKSTEST';
		$objAG->GatewayType = 'ManagerAPI';
		$objAG->Platform= 'MT4';
		$objAG->IP= '127.0.0.1';
		$objAG->Port= 10005;
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_UpdateGateway=array('Login'=>$Login,'Password'=>$Password,'objGateway'=>$objAG); 
		@$webService = $client->UpdateGateway($param_UpdateGateway);*/
		
		// For GetGatewayConnectionList //
		/*$param_GetGatewayConnectionList=array('Login'=>$Login,'Password'=>$Password); 
		@$webService = $client->GetGatewayConnectionList($param_GetGatewayConnectionList);*/
		
		
		// For AddGatewayConnection //
		
		/*$objAG = new GatewayConnection();
		$objAG->GCLogin = '2';
		$objAG->GCPassword ='PKS2';
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
		$objAG->ServerAPIPort= '3333';
		$objAG->BrokerID= 123;
		$objAG->WalletAccount= 5000;
		$objAG->Gateway= 'PKSTEST';
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_AddGatewayConnection=array('Login'=>$Login,'Password'=>$Password,'objGatewayConnection'=>$objAG); 
		@$webService = $client->AddGatewayConnection($param_AddGatewayConnection);*/
		
		// For UpdateGatewayConnection //
		
		/*$objAG = new GatewayConnection();
		$objAG->GCLogin = '2';
		$objAG->GCPassword ='PKS2';
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
		$objAG->ServerAPIPort= '3344';
		$objAG->BrokerID= 123;
		$objAG->WalletAccount= 5000;
		$objAG->Gateway= 'PKSTEST';
		$objAG->LastUpdatedtime= '2016-08-30T14:10:44';
		
		$param_UpdateGatewayConnection=array('Login'=>$Login,'Password'=>$Password,'objGatewayConnection'=>$objAG); 
		@$webService = $client->UpdateGatewayConnection($param_UpdateGatewayConnection);*/
		
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