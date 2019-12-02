<?php
header("Expires: Tue, 01 jan 2000 00:00:00 GMT");
header("Last-Modified:".gmdate("D,d M Y h:i:s"). " GMT");
header("Cache-Control: no-store,must-revalidate,max-age=0");
header("Cache-Control: post-check=0,pre-check=0",false);
header("Pragma: no-cache");
//error_reporting(0);
//date_default_timezone_set("America/Los_Angeles");

	class AccountGroupAssetClassMapping 
		{
			Public $AssetClassId;   // AssetClassId
			Public $Prefix;  	// Prefix
			Public $Suffix;   	// Suffix

		}
		
	class AccountGroup
    {
		public $GroupID;                        // Group ID
		public $GroupName;                      // Group Name
		public $Hedging;                        // Hedging
		public $Spread_Diff;                    // Spread_Diff
		public $Active;                         // Manager Status
		public $LastUpdatedtime;                // Last Updated Time
		public $lstAssetClassDetails;
		
	
		//public function __construct(AccountGroupAssetClassMapping $AccGrpAsst) {
			//$this->lstAssetClassDetails = $AccGrpAsst;
		//}
		
	}

	
	class Symbol
    {
		public $SymbolId;       				// Symbol ID
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
		public $InstanceID;                     // InstanceID
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
		public $GatewayId;                        // Login
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
		public $TCInstance;               	    // TCInstance
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
		public $Currency;                         // Currency
		public $LastUpdatedtime;                // Last Updated Time
    }

	class GroupSymbolMapping
    {
		public $GroupId;                      // Group ID
		public $SymbolId;                      // SymbolId
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
		public $SLAmount;                       // Slippage
		public $LastUpdatedtime;                // Last Updated Time

    }

	class UpdatePHPserviceURL
	{
		public $TCconnId;                    // TCconnId
		public $ServiceURL;                     // ServiceURL	
	}
	
	class UDPComponent
	{
		public $UDPComponetId;                   // Gateway Id  
		public $Name;                            // Component name        
		public $IP;                              // IP
		public $Port;                            // port
		public $Active;                          // Status
		public $LastUpdatedtime;                 // Last Updated Time
	}
	
	
	try
	{
		$Login		= 'admin';
		$Password	= '123';
		$webURL		= "http://185.62.85.23:9090/STTCservice.svc?wsdl&".rand(1,10000);
		//$webURL		= "http://192.168.2.84:9090/STTCservice.svc?wsdl&".rand(1,10000);
		
		
		$client = new SoapClient($webURL);

		if(count($_POST>0) && isset($_POST['GetAccountGroups']))
		{
			$GroupId = $_POST['GroupId'];
			$param_GetAccountGroups=array('Login'=>$Login,'Password'=>$Password,'GroupId'=>$GroupId);
		    $webService = $client->GetAccountGroups($param_GetAccountGroups);
		   //print_r($_POST); die;
		}

		if(count($_POST>0) && isset($_POST['GetAccountGroupsByConnId']))
		{
			$ConnId = $_POST['ConnId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ConnId'=>$ConnId);
		    $webService = $client->GetAccountGroupsByConnId($param);
		   //print_r($_POST); die;
		}

		if(count($_POST>0) && isset($_POST['AddAccountGroups']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$GroupId = (int)$_POST['GroupId'];
			$Hedging = (int)$_POST['Hedging'];
			$Spread_Diff = (int)$_POST['Spread_Diff'];
			$Active = (int)$_POST['Active'];

			$a = array(1, 2, 3);
			$b = array("1#", "2#", "3$");
			$c = array("1&", "2$", "3$");
//print_r($a);
$objAGAC = new AccountGroupAssetClassMapping();
			echo $n = count($a);

		
		
			/*
			$objAGAC = new AccountGroupAssetClassMapping();
			$objAGAC->AssetClassId = 1;
			$objAGAC->Prefix = '#';
			$objAGAC->Suffix = '$';
			//print_r($objAGAC);*/	
			
			$TestDetails = array();
			$objAG = new AccountGroup();//($objAGAC);
			//$objAG->GroupId = $GroupId;
			$objAG->GroupName = $_POST['GroupName'];
			$objAG->Hedging =$Hedging;
			$objAG->Spread_Diff = $Spread_Diff;
			$objAG->Active= $Active;
			
			for($i=0;$i<$n;$i++)
			{
	
					$objAGAC->AssetClassId = $a[$i];
					$objAGAC->Prefix = $b[$i];
					$objAGAC->Suffix = $c[$i];
					//echo '<pre>'; print_r($objAGAC);	
					array_push($TestDetails,array("AssetClassId" => $a[$i],"Prefix" => $b[$i],"Suffix" => $c[$i]));
					//$lstAssetClassDetails= array_push($lstAssetClassDetails,$objAGAC);
					
			}
			$objAG->lstAssetClassDetails=$TestDetails;
			//$objAG->lstAssetClassDetails[]=$objAGAC;
			
			//echo '<pre>';print_r($TestDetails);
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T00:00:00';
			
			echo '<pre>';print_r($objAG);
			$param_AddAccountGroups=array('Login'=>$Login,'Password'=>$Password,'objAccountGroup'=>$objAG);
			@$webService = $client->AddAccountGroups($param_AddAccountGroups);
		}

		if(count($_POST>0) && isset($_POST['UpdateAccountGroups']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$GroupId = (int)$_POST['GroupId'];
			$Hedging = (int)$_POST['Hedging'];
			$Spread_Diff = (int)$_POST['Spread_Diff'];
			$Active = (int)$_POST['Active'];

			$a = array(1, 2, 3,4,5);
			$b = array("#", "#", "$", "$", "$");
			$c = array("1&", "2$", "3$", "$", "$");
//print_r($a);
$objAGAC = new AccountGroupAssetClassMapping();
			$n = count($a);
			
			$TestDetails = array();
			$objAG = new AccountGroup();
			$objAG->GroupId = $GroupId;
			$objAG->GroupName = $_POST['GroupName'];
			$objAG->Hedging =$Hedging;
			$objAG->Spread_Diff = $Spread_Diff;
			$objAG->Active= $Active;
			for($i=0;$i<$n;$i++)
			{
	
					$objAGAC->AssetClassId = $a[$i];
					$objAGAC->Prefix = $b[$i];
					$objAGAC->Suffix = $c[$i];
					//echo '<pre>'; print_r($objAGAC);	
					array_push($TestDetails,array("AssetClassId" => $a[$i],"Prefix" => $b[$i],"Suffix" => $c[$i]));
					//$lstAssetClassDetails= array_push($lstAssetClassDetails,$objAGAC);
					
			}
			$objAG->lstAssetClassDetails=$TestDetails;
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T00:00:00';
			echo '<pre>';print_r($objAG);
			$param_UpdateAccountGroups=array('Login'=>$Login,'Password'=>$Password,'objAccountGroup'=>$objAG);
			@$webService = $client->UpdateAccountGroups($param_UpdateAccountGroups);
		}


		if(count($_POST>0) && isset($_POST['GetAccounts']))
		{
			$AccountId = (int)$_POST['AccountId'];
			$param_GetAccounts=array('Login'=>$Login,'Password'=>$Password,'AccountId'=>$AccountId);
			@$webService = $client->GetAccounts($param_GetAccounts);
		}

		if(count($_POST>0) && isset($_POST['AddAccounts']))
		{
			//print_r($_POST); die;
			//$today =  date("Y-m-d");
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			//$AccountID = (int)$_POST['AccountID'];
			$RootToMT4Server = (int)$_POST['RootToMT4Server'];
			$PStype = (int)$_POST['PStype'];
			$PSShare = (int)$_POST['PSShare'];
			$ShareInProfitOnly = (int)$_POST['ShareInProfitOnly'];
			$InstantDeduction = (int)$_POST['InstantDeduction'];
			$Active = (int)$_POST['Active'];

			$objAG = new AccountInfo();
			$objAG->AccountID = 0;
			$objAG->ExternalID = $_POST['ExternalID'];
			$objAG->Password =$_POST['Password'];
			//$objAG->Gateway = (int)$_POST['Gateway'];
			//$objAG->TCInstance= (int)$_POST['TCInstance'];
			$objAG->Gateway = 0;
			$objAG->TCInstance= 0;
			$objAG->AccountGroup= (int)$_POST['AccountGroup'];
			$objAG->Connection = (int)$_POST['Connection'];
			$objAG->ParticipantLoginID = $_POST['ParticipantLoginID'];
			$objAG->ParticipantPassword = $_POST['ParticipantPassword'];
			$objAG->RootToMT4Server = $RootToMT4Server;
			$objAG->PStype = $PStype;
			$objAG->PSShare = $PSShare;
			$objAG->ShareInProfitOnly = $ShareInProfitOnly;
			$objAG->InstantDeduction = $InstantDeduction;
			$objAG->Active = $Active;
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T10:12:10';
		


			$param_AddAccounts=array('Login'=>$Login,'Password'=>$Password,'objAccountInfo'=>$objAG);
			$webService = $client->AddAccounts($param_AddAccounts);
		}

		if(count($_POST>0) && isset($_POST['UpdateAccount']))
		{
			//print_r($_POST); die;
			//$today =  date("Y-m-d");
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$AccountID = (int)$_POST['AccountID'];
			$RootToMT4Server = (int)$_POST['RootToMT4Server'];
			$PStype = (int)$_POST['PStype'];
			$PSShare = (int)$_POST['PSShare'];
			$ShareInProfitOnly = (int)$_POST['ShareInProfitOnly'];
			$InstantDeduction = (int)$_POST['InstantDeduction'];
			$Active = (int)$_POST['Active'];

			$objAG = new AccountInfo();
			$objAG->AccountID = $AccountID;
			$objAG->ExternalID = $_POST['ExternalID'];
			$objAG->Password =$_POST['Password'];
			//$objAG->Gateway = (int)$_POST['Gateway'];
			//$objAG->TCInstance= (int)$_POST['TCInstance'];
			$objAG->Gateway = 0;
			$objAG->TCInstance= 0;
			$objAG->AccountGroup= (int)$_POST['AccountGroup'];
			$objAG->Connection = (int)$_POST['Connection'];
			$objAG->ParticipantLoginID = $_POST['ParticipantLoginID'];
			$objAG->ParticipantPassword = $_POST['ParticipantPassword'];
			$objAG->RootToMT4Server = $RootToMT4Server;
			$objAG->PStype = $PStype;
			$objAG->PSShare = $PSShare;
			$objAG->ShareInProfitOnly = $ShareInProfitOnly;
			$objAG->InstantDeduction = $InstantDeduction;
			$objAG->Active = $Active;
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T10:12:10';


			$param_UpdateAccount=array('Login'=>$Login,'Password'=>$Password,'objAccountInfo'=>$objAG);
			$webService = $client->UpdateAccount($param_UpdateAccount);
		}


		if(count($_POST>0) && isset($_POST['GetGatewaysList']))
		{
			$GatewayId = (int)$_POST['GatewayId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'GatewayId'=>$GatewayId);
			//print_r($param);
			@$webService = $client->GetGatewaysList($param);

		}

		if(count($_POST>0) && isset($_POST['AddGateway']))
		{
			//$today =  date("Y-m-d");
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$Port = (int)$_POST['Port'];

			$objAG = new Gateway();
			$objAG->GatewayId = (int)$_POST['GatewayId'];
			$objAG->GTLogin = $_POST['GTLogin'];
			$objAG->GTPassword =$_POST['GTPassword'];
			$objAG->GatewayType = $_POST['GatewayType'];
			$objAG->Platform= $_POST['Platform'];
			$objAG->IP= $_POST['IP'];
			$objAG->Port= $Port;
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T19:37:20';

			$param_AddGateway=array('Login'=>$Login,'Password'=>$Password,'objGateway'=>$objAG);
			@$webService = $client->AddGateway($param_AddGateway);

		}

		if(count($_POST>0) && isset($_POST['UpdateGateway']))
		{
			//$today =  date("Y-m-d");
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$Port = (int)$_POST['Port'];

			$objAG = new Gateway();
			$objAG->GatewayId = (int)$_POST['GatewayId'];
			$objAG->GTLogin = $_POST['GTLogin'];
			$objAG->GTPassword =$_POST['GTPassword'];
			$objAG->GatewayType = $_POST['GatewayType'];
			$objAG->Platform= $_POST['Platform'];
			$objAG->IP= $_POST['IP'];
			$objAG->Port= $Port;
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T19:37:20';

			$param_UpdateGateway=array('Login'=>$Login,'Password'=>$Password,'objGateway'=>$objAG);
			@$webService = $client->UpdateGateway($param_UpdateGateway);

		}


		if(count($_POST>0) && isset($_POST['GetGatewayType']))
		{
			$GatewayTypeId = $_POST['GatewayTypeId'];
						
			$param_GetAllTCInstances=array('Login'=>$Login,'Password'=>$Password,'GatewayTypeId'=>$GatewayTypeId);
			@$webService = $client->GetGatewayType($param_GetAllTCInstances);

		}
		
		if(count($_POST>0) && isset($_POST['AddGatewayType']))
		{
			$GatewayType = $_POST['GatewayType'];
						
			$param_GetAllTCInstances=array('Login'=>$Login,'Password'=>$Password,'GatewayType'=>$GatewayType);
			@$webService = $client->AddGatewayType($param_GetAllTCInstances);

		}
		



		if(count($_POST>0) && isset($_POST['GetAllTCInstances']))
		{
			$param_GetAllTCInstances=array('Login'=>$Login,'Password'=>$Password);
			@$webService = $client->GetAllTCInstances($param_GetAllTCInstances);

		}

		if(count($_POST>0) && isset($_POST['AddTCInstance']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$Active = (int)$_POST['Active'];
			$Port = (int)$_POST['Port'];

			$objAG = new TCInstance();
			$objAG->InstanceID = 0;
			$objAG->InstanceName = $_POST['InstanceName'];
			$objAG->Login =$_POST['Login'];
			$objAG->Password = $_POST['Password'];
			$objAG->Active= $Active;
			$objAG->Port= $Port;
			$objAG->IP= $_POST['IP'];
			$objAG->LastUpdatedTime= $LastUpdatedtime.'T19:37:20';

			$param_AddTCInstance=array('Login'=>$Login,'Password'=>$Password,'objTCInstance'=>$objAG);
			@$webService = $client->AddTCInstance($param_AddTCInstance);

		}

		if(count($_POST>0) && isset($_POST['UpdateTCInstance']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$Active = (int)$_POST['Active'];
			$Port = (int)$_POST['Port'];

			$objAG = new TCInstance();
			$objAG->InstanceID = (int)$_POST['InstanceID'];
			$objAG->InstanceName = $_POST['InstanceName'];
			$objAG->Login =$_POST['Login'];
			$objAG->Password = $_POST['Password'];
			$objAG->Active= $Active;
			$objAG->Port= $Port;
			$objAG->IP= $_POST['IP'];
			$objAG->LastUpdatedTime= $LastUpdatedtime.'T19:37:20';

			$param_UpdateTCInstance=array('Login'=>$Login,'Password'=>$Password,'objTCInstance'=>$objAG);
			@$webService = $client->UpdateTCInstance($param_UpdateTCInstance);

		}

		if(count($_POST>0) && isset($_POST['GetAllSymbols']))
		{
			$SymbolId = (int)$_POST['SymbolId'];
			$param_GetAllSymbols=array('Login'=>$Login,'Password'=>$Password,'SymbolId'=>$SymbolId);
			@$webService = $client->GetAllSymbols($param_GetAllSymbols);
		}

		if(count($_POST>0) && isset($_POST['GetAllSymbolsByAssetClass']))
		{
			$AssetId = (int)$_POST['AssetId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'AssetId'=>$AssetId);
			@$webService = $client->GetAllSymbolsByAssetClass($param);

		}
		if(count($_POST>0) && isset($_POST['AddSymbol']))
		{
			//$today =  date("Y-m-d");
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$ContractSize = (int)$_POST['ContractSize'];
			$Active = (int)$_POST['Active'];
			$Digits = (int)$_POST['Digits'];
			$Spread = (int)$_POST['Spread'];
			$TickSize = (int)$_POST['TickSize'];
			$TickValue = (int)$_POST['TickValue'];
			$AssetClass = (int)$_POST['AssetClass'];

			$objAG = new Symbol();
			$objAG->SymbolName = $_POST['SymbolName'];
			$objAG->AssetClass =$AssetClass;
			$objAG->ContractSize = $ContractSize;
			$objAG->Active= $Active;
			$objAG->Digits= $Digits;
			$objAG->Spread= $Spread;
			$objAG->TickSize= $TickSize;
			$objAG->TickValue= $TickValue;
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T10:12:20';

			$param_AddSymbol=array('Login'=>$Login,'Password'=>$Password,'objSymbol'=>$objAG);
			@$webService = $client->AddSymbol($param_AddSymbol);
		}

		if(count($_POST>0) && isset($_POST['UpdateSymbol']))
		{
			//$today =  date("Y-m-d");
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$ContractSize = (int)$_POST['ContractSize'];
			$Active = (int)$_POST['Active'];
			$Digits = (int)$_POST['Digits'];
			$Spread = (int)$_POST['Spread'];
			$TickSize = (int)$_POST['TickSize'];
			$TickValue = (int)$_POST['TickValue'];
			$SymbolId = (int)$_POST['SymbolId'];
			$AssetClass = (int)$_POST['AssetClass'];

			$objAG = new Symbol();
			$objAG->SymbolId = $SymbolId;
			$objAG->SymbolName = $_POST['SymbolName'];
			$objAG->AssetClass =$AssetClass;
			$objAG->ContractSize = $ContractSize;
			$objAG->Active= $Active;
			$objAG->Digits= $Digits;
			$objAG->Spread= $Spread;
			$objAG->TickSize= $TickSize;
			$objAG->TickValue= $TickValue;
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T10:12:20';

			$param_UpdateSymbol=array('Login'=>$Login,'Password'=>$Password,'objSymbol'=>$objAG);
			@$webService = $client->UpdateSymbol($param_UpdateSymbol);
		}

		
		
		if(count($_POST>0) && isset($_POST['GetGatewayConnectionList']))
		{
			$ConnId = (int)$_POST['ConnId'];
			$param_GetGatewayConnectionList=array('Login'=>$Login,'Password'=>$Password,'ConnId'=>$ConnId);
			@$webService = $client->GetGatewayConnectionList($param_GetGatewayConnectionList);

		}

		if(count($_POST>0) && isset($_POST['AddGatewayConnection']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$ConnID = (int)$_POST['ConnID'];
			$Port = (int)$_POST['Port'];
			$Active = (int)$_POST['Active'];
			$ServerAPIPort = (int)$_POST['ServerAPIPort'];
			$BrokerID = (int)$_POST['BrokerID'];
			$WalletAccount = (int)$_POST['WalletAccount'];


			$objAG = new GatewayConnection();
			$objAG->ConnID = $ConnID;
			$objAG->GCLogin = $_POST['GCLogin'];
			$objAG->GCPassword =$_POST['GCPassword'];
			$objAG->IP = $_POST['IP'];
			$objAG->Port= $Port;
			$objAG->ServerName= $_POST['ServerName'];
			$objAG->Active= $Active;
			$objAG->TargetCompID= $_POST['TargetCompID'];
			$objAG->SenderCompID= $_POST['SenderCompID'];
			$objAG->SenderSubID= $_POST['SenderSubID'];
			$objAG->TradeIP= $_POST['TradeIP'];
			$objAG->TradePort= $_POST['TradePort'];
			$objAG->ServerAPIIP= $_POST['ServerAPIIP'];
			$objAG->ServerAPIPort= $ServerAPIPort;
			$objAG->BrokerID= $BrokerID;
			$objAG->WalletAccount= $WalletAccount;
			$objAG->Gateway= $_POST['Gateway'];
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T10:12:20';

			$param_AddGatewayConnection=array('Login'=>$Login,'Password'=>$Password,'objGatewayConnection'=>$objAG);
			@$webService = $client->AddGatewayConnection($param_AddGatewayConnection);

		}

		if(count($_POST>0) && isset($_POST['UpdateGatewayConnection']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$ConnID = (int)$_POST['ConnID'];
			$Port = (int)$_POST['Port'];
			$Active = (int)$_POST['Active'];
			$ServerAPIPort = (int)$_POST['ServerAPIPort'];
			$BrokerID = (int)$_POST['BrokerID'];
			$WalletAccount = (int)$_POST['WalletAccount'];


			$objAG = new GatewayConnection();
			$objAG->ConnID = $ConnID;
			$objAG->GCLogin = $_POST['GCLogin'];
			$objAG->GCPassword =$_POST['GCPassword'];
			$objAG->IP = $_POST['IP'];
			$objAG->Port= $Port;
			$objAG->ServerName= $_POST['ServerName'];
			$objAG->Active= $Active;
			$objAG->TargetCompID= $_POST['TargetCompID'];
			$objAG->SenderCompID= $_POST['SenderCompID'];
			$objAG->SenderSubID= $_POST['SenderSubID'];
			$objAG->TradeIP= $_POST['TradeIP'];
			$objAG->TradePort= $_POST['TradePort'];
			$objAG->ServerAPIIP= $_POST['ServerAPIIP'];
			$objAG->ServerAPIPort= $ServerAPIPort;
			$objAG->BrokerID= $BrokerID;
			$objAG->WalletAccount= $WalletAccount;
			$objAG->Gateway= $_POST['Gateway'];
			$objAG->LastUpdatedtime= $LastUpdatedtime.'T10:12:20';

			$param_UpdateGatewayConnection=array('Login'=>$Login,'Password'=>$Password,'objGatewayConnection'=>$objAG);
			@$webService = $client->UpdateGatewayConnection($param_UpdateGatewayConnection);

		}

		if(count($_POST>0) && isset($_POST['UpdateGatewayConnectionWallet']))
		{
			$ConnId = $_POST['ConnId'];
			$Wallet = $_POST['Wallet'];
			
			$param_GetPlatformDetails=array('Login'=>$Login,'Password'=>$Password,'ConnId'=>$ConnId,'Wallet'=>$Wallet);
			$webService = $client->UpdateGatewayConnectionWallet($param_GetPlatformDetails);
		}
		
		if(count($_POST>0) && isset($_POST['GetPlatformDetails']))
		{
			$PlatformId = (int)$_POST['PlatformId'];
			$param_GetPlatformDetails=array('Login'=>$Login,'Password'=>$Password,'PlatformId'=>$PlatformId);
			$webService = $client->GetPlatformDetails($param_GetPlatformDetails);
		}

		if(count($_POST>0) && isset($_POST['AddPlatform']))
		{
			$Platform = $_POST['Platform'];
			$param_AddPlatform=array('Login'=>$Login,'Password'=>$Password,'Platform'=>$Platform);
			$webService = $client->AddPlatform($param_AddPlatform);
		}

		if(count($_POST>0) && isset($_POST['GetTCInstanceGatewayMapping']))
		{
			$param_GetTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password);
			@$webService = $client->GetTCInstanceGatewayMapping($param_GetTCInstanceGatewayMapping);
		}

		if(count($_POST>0) && isset($_POST['AddTCInstanceGatewayMapping']))
		{
			$TCInstanceId = (int)$_POST['TCInstanceId'];
			$GatewayId = (int)$_POST['GatewayId'];
			$param_AddTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password,'TCInstanceId'=>$TCInstanceId,'GatewayId'=>$GatewayId);
			@$webService = $client->AddTCInstanceGatewayMapping($param_AddTCInstanceGatewayMapping);
		}

		if(count($_POST>0) && isset($_POST['UpdateTCInstanceGatewayMapping']))
		{
			$TCInstanceId = (int)$_POST['TCInstanceId'];
			$GatewayId = (int)$_POST['GatewayId'];
			$OldGatewayId = (int)$_POST['OldGatewayId'];
			$param_UpdateTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password,'TCInstanceId'=>$TCInstanceId,'GatewayId'=>$GatewayId,'OldGatewayId'=>$OldGatewayId);
			//print_r($param_UpdateTCInstanceGatewayMapping); die;
			@$webService = $client->UpdateTCInstanceGatewayMapping($param_UpdateTCInstanceGatewayMapping);
		}

		if(count($_POST>0) && isset($_POST['DeleteTCInstanceGatewayMapping']))
		{
			$TCInstanceId = (int)$_POST['TCInstanceId'];
			$GatewayId = (int)$_POST['GatewayId'];
			$param_DeleteTCInstanceGatewayMapping=array('Login'=>$Login,'Password'=>$Password,'TCInstanceId'=>$TCInstanceId,'GatewayId'=>$GatewayId);
			@$webService = $client->DeleteTCInstanceGatewayMapping($param_DeleteTCInstanceGatewayMapping);
		}

		if(count($_POST>0) && isset($_POST['GetAccountGroupConnectionMapping']))
		{
			$ConnId = (int)$_POST['ConnId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ConnId'=>$ConnId);
			@$webService = $client->GetAccountGroupConnectionMapping($param);
		}

		if(count($_POST>0) && isset($_POST['AddAccountGroupConnectionMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$GroupID = (int)$_POST['GroupID'];
			$ConnID = (int)$_POST['ConnID'];
			$Active = (int)$_POST['Active'];
			

			$objAG = new AccountGroupConMapping();
			$objAG->ConnGroupName = $_POST['ConnGroupName'];
			$objAG->GroupID = $GroupID;
			$objAG->ConnID = $ConnID;
			$objAG->Active = $Active;
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';

			$param=array('Login'=>$Login,'Password'=>$Password,'objAccountGroupConMapping'=>$objAG);
			@$webService = $client->AddAccountGroupConnectionMapping($param);
		}

		if(count($_POST>0) && isset($_POST['UpdateAcountGroupConnectionMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$GroupID = (int)$_POST['GroupID'];
			$ConnID = (int)$_POST['ConnID'];
			$Active = (int)$_POST['Active'];
			
			$objAG = new AccountGroupConMapping();
			$objAG->ConnGroupName = $_POST['ConnGroupName'];
			$objAG->GroupID = $GroupID;
			$objAG->ConnID = $ConnID;
			$objAG->Active = $Active;
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';

			$param=array('Login'=>$Login,'Password'=>$Password,'objAccountGroupConMapping'=>$objAG);
			@$webService = $client->UpdateAcountGroupConnectionMapping($param);
		}

		if(count($_POST>0) && isset($_POST['GetGroupSymbolMapping']))
		{
			$GroupId = (int)$_POST['GroupId'];
			$param_GetGroupSymbolMapping=array('Login'=>$Login,'Password'=>$Password,'GroupId'=>$GroupId);
			$webService = $client->GetGroupSymbolMapping($param_GetGroupSymbolMapping);
		}

		if(count($_POST>0) && isset($_POST['GetGroupSymbolMappingByConn']))
		{
			$ConnId = (int)$_POST['ConnId'];
			$MT4GroupName = $_POST['MT4GroupName'];
			$param3=array('Login'=>$Login,'Password'=>$Password,'ConnId'=>$ConnId,'MT4GroupName'=>$MT4GroupName);
			$webService = $client->GetGroupSymbolMappingByConn($param3);
		}

		
		if(count($_POST>0) && isset($_POST['AddGroupSymbolMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");

			$objAG = new GroupSymbolMapping();
			$objAG->GroupId = (int)$_POST['GroupId'];
			$objAG->SymbolId = (int)$_POST['SymbolId'];
			$objAG->GroupName = $_POST['GroupName'];
			$objAG->SymbolName =$_POST['SymbolName'];
			$objAG->AliasName = $_POST['AliasName'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';

			$param=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG);
			@$webService = $client->AddGroupSymbolMapping($param);
		}

		if(count($_POST>0) && isset($_POST['UpdateGroupSymbolMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");

			$objAG = new GroupSymbolMapping();
			$objAG->GroupId = (int)$_POST['GroupId'];
			$objAG->SymbolId = (int)$_POST['SymbolId'];
			$objAG->GroupName = $_POST['GroupName'];
			$objAG->SymbolName =$_POST['SymbolName'];
			$objAG->AliasName = $_POST['AliasName'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';

			$param=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG);
			@$webService = $client->UpdateGroupSymbolMapping($param);
		}

		if(count($_POST>0) && isset($_POST['DeleteGroupSymbolMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");

			$objAG = new GroupSymbolMapping();
			$objAG->GroupId = (int)$_POST['GroupId'];
			$objAG->SymbolId = (int)$_POST['SymbolId'];
			$objAG->GroupName = $_POST['GroupName'];
			$objAG->SymbolName =$_POST['SymbolName'];
			$objAG->AliasName = $_POST['AliasName'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';

			$param=array('Login'=>$Login,'Password'=>$Password,'objGroupSymbolMapping'=>$objAG);
			@$webService = $client->DeleteGroupSymbolMapping($param);
		}

		if(count($_POST>0) && isset($_POST['GetMasterSlaveMapping']))
		{
			$TCMasterId = (int)$_POST['TCMasterId'];
			$TCSlaveId = (int)$_POST['TCSlaveId'];
			
			$param_GetMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'TCMasterId'=>$TCMasterId,'TCSlaveId'=>$TCSlaveId);
			@$webService = $client->GetMasterSlaveMapping($param_GetMasterSlaveMapping);
		}

		if(count($_POST>0) && isset($_POST['AddMasterSlaveMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$MasterAccount = (int)$_POST['MasterAccount'];
			$SlaveAccount = (int)$_POST['SlaveAccount'];
			$CopyMode = (int)$_POST['CopyMode'];
			$CloseOrders = (int)$_POST['CloseOrders'];
			$CopyTrade = (int)$_POST['CopyTrade'];
			$Slippage = (int)$_POST['Slippage'];

			$objAG = new MasterSlaveMapping();
			$objAG->MasterAccount = $MasterAccount;
			$objAG->SlaveAccount =$SlaveAccount;
			$objAG->CopyMode = $CopyMode;
			$objAG->CloseOrders = $CloseOrders;
			$objAG->CopyMethod = $_POST['CopyMethod'];
			$objAG->CopyValue = $_POST['CopyValue'];
			$objAG->CopyTrade = $CopyTrade;
			$objAG->Slippage  = $Slippage;
			$objAG->SLAmount  = (int)$_POST['SLAmount'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';


			$param_AddMasterSlaveMapping=array('Login'=>$Login,'Password'=>$Password,'objMasterSlaveMapping'=>$objAG);
			@$webService = $client->AddMasterSlaveMapping($param_AddMasterSlaveMapping);
		}

		if(count($_POST>0) && isset($_POST['UpdateMasterSlaveMapping']))
		{
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			$MasterAccount = (int)$_POST['MasterAccount'];
			$SlaveAccount = (int)$_POST['SlaveAccount'];
			$CopyMode = (int)$_POST['CopyMode'];
			$CloseOrders = (int)$_POST['CloseOrders'];
			$CopyTrade = (int)$_POST['CopyTrade'];
			$Slippage = (int)$_POST['Slippage'];

			$objAG = new MasterSlaveMapping();
			$objAG->MasterAccount = $MasterAccount;
			$objAG->SlaveAccount =$SlaveAccount;
			$objAG->CopyMode = $CopyMode;
			$objAG->CloseOrders = $CloseOrders;
			$objAG->CopyMethod = $_POST['CopyMethod'];
			$objAG->CopyValue = $_POST['CopyValue'];
			$objAG->CopyTrade = $CopyTrade;
			$objAG->Slippage  = $Slippage;
			$objAG->SLAmount  = (int)$_POST['SLAmount'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';


			$param=array('Login'=>$Login,'Password'=>$Password,'objMasterSlaveMapping'=>$objAG);
			@$webService = $client->UpdateMasterSlaveMapping($param);
		}

		if(count($_POST>0) && isset($_POST['DeleteMasterSlaveMapping']))
		{
			$MasterAccount = (int)$_POST['MasterAccount'];
			$SlaveAccount = (int)$_POST['SlaveAccount'];

			$param=array('Login'=>$Login,'Password'=>$Password,'MasterAccount'=>$MasterAccount,'SlaveAccount'=>$SlaveAccount);
			$webService = $client->DeleteMasterSlaveMapping($param);
		}
		
		if(count($_POST>0) && isset($_POST['UpdateMasterSlaveSL']))
		{
			$MasterAccount = (int)$_POST['MasterAccount'];
			$SlaveAccount = (int)$_POST['SlaveAccount'];
			$SL = (int)$_POST['SL'];

			$param=array('Login'=>$Login,'Password'=>$Password,'MasterAccount'=>$MasterAccount,'SlaveAccount'=>$SlaveAccount,'SL'=>$SL);
			$webService = $client->UpdateMasterSlaveSL($param);
		}
		

		if(count($_POST>0) && isset($_POST['GetOpenTrades']))
		{

			$dateconvert1 =  date_create($_POST['FromDate']);
			$FromDate = date_format($dateconvert1,"Y-m-d");

			$dateconvert2 =  date_create($_POST['ToDate']);
			$ToDate = date_format($dateconvert2,"Y-m-d");
			$AccountId = (int)$_POST['AccountId'];
			
			$param_GetOpenTrades=array('FromDate'=>$FromDate.'T00:00:00','ToDate'=>$ToDate.'T23:59:59','Login'=>$Login,'Password'=>$Password,'AccountId'=>$AccountId);
			@$webService = $client->GetOpenTrades($param_GetOpenTrades);
		}

		if(count($_POST>0) && isset($_POST['GetClosedTrades']))
		{
			$dateconvert1 =  date_create($_POST['FromDate']);
			$FromDate = date_format($dateconvert1,"Y-m-d");

			$dateconvert2 =  date_create($_POST['ToDate']);
			$ToDate = date_format($dateconvert2,"Y-m-d");
			$AccountId = (int)$_POST['AccountId'];

			$param=array('FromDate'=>$FromDate.'T00:00:00','ToDate'=>$ToDate.'T23:59:59','Login'=>$Login,'Password'=>$Password,'AccountId'=>$AccountId);
			$webService = $client->GetClosedTrades($param);
		}


		if(count($_POST>0) && isset($_POST['GetActivityLog']))
		{
			$dateconvert1 =  date_create($_POST['FromDate']);
			$FromDate = date_format($dateconvert1,"Y-m-d");

			$dateconvert2 =  date_create($_POST['ToDate']);
			$ToDate = date_format($dateconvert2,"Y-m-d");

			$param_GetActivityLog=array('FromDate'=>$FromDate.'T00:00:00','ToDate'=>$ToDate.'T23:59:59','Login'=>$Login,'Password'=>$Password);
			$webService = $client->GetActivityLog($param_GetActivityLog);
		}

		if(count($_POST>0) && isset($_POST['GetAllAssetClass']))
		{
			$AssetId = $_POST['AssetId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'AssetId'=>$AssetId);
		    $webService = $client->GetAllAssetClass($param);
		   //print_r($_POST); die;
		}
		

		if(count($_POST>0) && isset($_POST['AddAssetClass']))
		{
			$AssetClass = $_POST['AssetClass'];
			$param=array('Login'=>$Login,'Password'=>$Password,'AssetClass'=>$AssetClass);
		    $webService = $client->AddAssetClass($param);
		   //print_r($_POST); die;
		}
		
		
		if(count($_POST>0) && isset($_POST['GetSlaveMasterRejetedOrders']))
		{
			$SlaveTCid = $_POST['SlaveTCid'];
			$param=array('Login'=>$Login,'Password'=>$Password,'SlaveTCid'=>$SlaveTCid);
		    $webService = $client->GetSlaveMasterRejetedOrders($param);
		   //print_r($_POST); die;
		}
		
		if(count($_POST>0) && isset($_POST['GetSlaveMasterFilledOrders']))
		{
			$SlaveTCid = $_POST['SlaveTCid'];
			$param=array('Login'=>$Login,'Password'=>$Password,'SlaveTCid'=>$SlaveTCid);
		    $webService = $client->GetSlaveMasterFilledOrders($param);
			
		}
		
		if(count($_POST>0) && isset($_POST['StartCopy']))
		{
			$TCSlaveId = $_POST['TCSlaveId'];
			$TCMasterId = $_POST['TCMasterId'];
			$TCID = $_POST['TCID'];
			
			$param=array('Login'=>$Login,'Password'=>$Password,'TCSlaveId'=>$TCSlaveId,'TCMasterId'=>$TCMasterId,'TCID'=>$TCID);
		    $webService = $client->StartCopy($param);
		   //print_r($_POST); die;
		}
		
		if(count($_POST>0) && isset($_POST['StopCopy']))
		{
			$TCSlaveId = $_POST['TCSlaveId'];
			$TCMasterId = $_POST['TCMasterId'];
			$TCID = $_POST['TCID'];
			
			$param=array('Login'=>$Login,'Password'=>$Password,'TCSlaveId'=>$TCSlaveId,'TCMasterId'=>$TCMasterId,'TCID'=>$TCID);
		    $webService = $client->StopCopy($param);
		    //print_r($_POST); die;
		}
		
		if(count($_POST>0) && isset($_POST['UpdatePHPserviceURL']))
		{
			
			$TCconnId = $_POST['TCconnId'];
			$ServiceURL = $_POST['ServiceURL'];
			
			$objAG = new UpdatePHPserviceURL();
			$objAG->TCconnId = $TCconnId;
			$objAG->ServiceURL =$ServiceURL;
			
			$param=array('Login'=>$Login,'Password'=>$Password,'objURLupdateRequest'=>$objAG);
			$webService = $client->UpdatePHPserviceURL($param);
		
			//echo"<pre>"; print_r(@$webService); die;
				
		}
		
		if(count($_POST>0) && isset($_POST['GetUDPComponentsList']))
		{
			//print_r($_POST);
			$ComponentId = $_POST['ComponentId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ComponentId'=>$ComponentId);
		    $webService = $client->GetUDPComponentsList($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['GetUDPComponentDetails']))
		{
			//print_r($_POST);
			$ComponentName = $_POST['ComponentName'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ComponentName'=>$ComponentName);
		    $webService = $client->GetUDPComponentDetails($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['AddUDPComponent']))
		{
			//print_r($_POST);
			
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			
			$objAG = new UDPComponent();
			$objAG->UDPComponetId = (int)$_POST['UDPComponetId'];
			$objAG->Name =$_POST['Name'];
			$objAG->IP = $_POST['IP'];
			$objAG->Port =(int)$_POST['Port'];
			$objAG->Active = (int)$_POST['Active'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';
			
			$param=array('Login'=>$Login,'Password'=>$Password,'objUDPComponent'=>$objAG);
		    $webService = $client->AddUDPComponent($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['UpdateUDPComponent']))
		{
			//print_r($_POST);
			
			$dateconvert =  date_create($_POST['LastUpdatedtime']);
			$LastUpdatedtime = date_format($dateconvert,"Y-m-d");
			
			$objAG = new UDPComponent();
			$objAG->UDPComponetId = (int)$_POST['UDPComponetId'];
			$objAG->Name =$_POST['Name'];
			$objAG->IP = $_POST['IP'];
			$objAG->Port =(int)$_POST['Port'];
			$objAG->Active = (int)$_POST['Active'];
			$objAG->LastUpdatedtime = $LastUpdatedtime.'T19:37:20';
			
			$param=array('Login'=>$Login,'Password'=>$Password,'objUDPComponent'=>$objAG);
		    $webService = $client->UpdateUDPComponent($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['DeleteUDPComponentById']))
		{
			//print_r($_POST);
			$ComponentId = $_POST['ComponentId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ComponentId'=>$ComponentId);
		    $webService = $client->DeleteUDPComponentById($param);
		   
		}
		if(count($_POST>0) && isset($_POST['DeleteUDPComponentByName']))
		{
			//print_r($_POST);
			$ComponentName = $_POST['ComponentName'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ComponentName'=>$ComponentName);
		    $webService = $client->DeleteUDPComponentByName($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['SendAddManagerUDPMessage']))
		{
			//print_r($_POST);
			$ComponentName = $_POST['ComponentName'];
			$ManagerId = $_POST['ManagerId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ComponentName'=>$ComponentName,'ManagerId'=>$ManagerId);
		    $webService = $client->SendAddManagerUDPMessage($param);
		   
		}
		if(count($_POST>0) && isset($_POST['SendAddManagerUDPMessageToAll']))
		{
			//print_r($_POST);
			$ManagerId = $_POST['ManagerId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ManagerId'=>$ManagerId);
		    $webService = $client->SendAddManagerUDPMessageToAll($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['SendAddAccountUDPMessage']))
		{
			//print_r($_POST);
			$AccountId = $_POST['AccountId'];
			$ComponentName = $_POST['ComponentName'];
			$param=array('Login'=>$Login,'Password'=>$Password,'ComponentName'=>$ComponentName,'AccountId'=>$AccountId);
		    $webService = $client->SendAddAccountUDPMessage($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['SendAddAccountUDPMessageToAll']))
		{
			//print_r($_POST);
			$AccountId = $_POST['AccountId'];
			$param=array('Login'=>$Login,'Password'=>$Password,'AccountId'=>$AccountId);
		    $webService = $client->SendAddAccountUDPMessageToAll($param);
		   
		}
		
		if(count($_POST>0) && isset($_POST['GetSlaveProfitLots']))
		{
			//print_r($_POST);
			
			$dateconvert1 =  date_create($_POST['FromDate']);
			$FromDate = date_format($dateconvert1,"Y-m-d");

			$dateconvert2 =  date_create($_POST['ToDate']);
			$ToDate = date_format($dateconvert2,"Y-m-d");

			$TCSlaveAccountId = $_POST['TCSlaveAccountId'];
			$TCMasterAccountId = $_POST['TCMasterAccountId'];
			$param=array('FromDate'=>$FromDate.'T00:00:00','ToDate'=>$ToDate.'T23:59:59','Login'=>$Login,'Password'=>$Password,'TCSlaveAccountId'=>$TCSlaveAccountId,'TCMasterAccountId'=>$TCMasterAccountId);
		    $webService = $client->GetSlaveProfitLots($param);
		   
		}
		
		
		////// Out Put //////
		//echo"<pre>"; print_r(@$webService); //die;
		echo json_encode($webService);
		
		$Arr=objectToArray($webService);
        foreach ($Arr as $innerArray) {
            if (is_array($innerArray)){
                foreach ($innerArray as $value) {
                    if (is_array($value)){
                        foreach ($value as $WSListInArray[]) {
								echo"<pre>"; print_r(@$WSListInArray); //die;
							}

					}
				}
			}
		}
	

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
