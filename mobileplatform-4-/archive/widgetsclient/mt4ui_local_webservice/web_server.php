<?php
//call library 
require_once ('lib/nusoap.php'); 
//using soap_server to create server object 
$server = new soap_server; 
//register a function that works on server 
$server->register('GetServers');
$server->register('ChangeBalance');
$server->register('ChangeCredit');
$server->register('ChangePassword');
$server->register('CreateAccount');
$server->register('GetAccountBalance');
$server->register('GetAccountInfo');
$server->register('GetAccounts');
$server->register('GetBalancesOperations');
$server->register('GetGroupRecord');
$server->register('GetGroups');
$server->register('GetHistory');
$server->register('Getjournal');
$server->register('GetLeverageOfGroup');
$server->register('GetAllLeverage');
$server->register('GetMarginInfo');
$server->register('GetOpenedTrades');
$server->register('SymbolsGetAll');
$server->register('ModifyAccount');
$server->register('ModifyOrder');
$server->register('ModifyPendingOrder');
$server->register('OpenOrder');
$server->register('OpenPendingOrder');
$server->register('SendMail');
$server->register('TransferBalance');
$server->register('GetExposure');
$server->register('DeleteAccount');
$server->register('CloseOrder');
$server->register('DeleteOrder');
$server->register('GetAccountsPnlCommissionSawp');
$server->register('AccountHistory');
$server->register('DeleteFile');


function DeleteFile($parameter) 
{ 
	SocketClient2('DeleteFile,'.$parameter);
} 



function GetServers($parameter) 
{ 
	SocketClient('GetServers,');
} 

function ChangeBalance($parameter) 
{ 
	SocketClient('ChangeBalance,'.$parameter.',');
}


function ChangeCredit($parameter) 
{ 
	SocketClient('ChangeCredit,'.$parameter.',');
} 

function ChangePassword($parameter) 
{ 
	SocketClient('ChangePassword,'.$parameter.',');
} 

function CreateAccount($parameter) 
{ 
	SocketClient('CreateAccount,'.$parameter.',');
} 

function GetAccountBalance($parameter) 
{ 
	SocketClient('GetAccountBalance,'.$parameter.',');
} 

function GetAccountInfo($parameter) 
{ 
	SocketClient('GetAccountInfo,'.$parameter.',');
}

function GetAccounts($parameter) 
{ 
	SocketClient('GetAccounts,');
}

function GetBalancesOperations($parameter) 
{ 
	SocketClient('GetBalancesOperations,'.$parameter.',');
}

function GetGroupRecord($parameter) 
{ 
	SocketClient('GetGroupRecord,'.$parameter.',');
}

function GetGroups($parameter) 
{ 
	SocketClient('GetGroups,'.$parameter.',');
}

function GetHistory($parameter) 
{ 
	SocketClient('GetHistory,'.$parameter.',');
}

function Getjournal($parameter) 
{ 
	SocketClient('Getjournal,'.$parameter.',');
}

function GetLeverageOfGroup($parameter) 
{ 
	SocketClient('GetLeverageOfGroup,'.$parameter.',');
}

function GetAllLeverage($parameter) 
{ 
	SocketClient('GetAllLeverage,');
}

function GetMarginInfo($parameter) 
{ 
	SocketClient('GetMarginInfo,'.$parameter.',');
}

function GetOpenedTrades($parameter) 
{ 
	SocketClient('GetOpenedTrades,');
}

function SymbolsGetAll($parameter) 
{ 
	SocketClient('SymbolsGetAll,');
} 

function ModifyAccount($parameter) 
{ 
	SocketClient('ModifyAccount,'.$parameter.',');
}

function ModifyOrder($parameter) 
{ 
	SocketClient('ModifyOrder,'.$parameter.',');
}

function ModifyPendingOrder($parameter) 
{ 
	SocketClient('ModifyPendingOrder,'.$parameter.',');
}

function OpenOrder($parameter) 
{ 
	SocketClient('OpenOrder,'.$parameter.',');
}

function OpenPendingOrder($parameter) 
{ 
	SocketClient('OpenPendingOrder,'.$parameter.',');
}

function SendMail($parameter) 
{ 
	SocketClient('SendMail,'.$parameter.',');
}

function TransferBalance($parameter) 
{ 
	SocketClient('TransferBalance,'.$parameter.',');
}

function GetExposure($parameter) 
{ 
	SocketClient('GetExposure,'.$parameter.',');
}

function DeleteAccount($parameter) 
{ 
	SocketClient('DeleteAccount,'.$parameter.',');
}

function CloseOrder($parameter) 
{ 
	SocketClient('CloseOrder,'.$parameter.',');
}

function DeleteOrder($parameter) 
{ 
	SocketClient('DeleteOrder,'.$parameter.',');
}

function GetAccountsPnlCommissionSawp($parameter) 
{ 
	SocketClient('GetAccountsPnlCommissionSawp,'.$parameter.',');
}

function AccountHistory($parameter) 
{ 
	SocketClient('AccountHistory,'.$parameter.',');
}




	

function SocketClient($strVal)
	{

	$server = '192.168.1.55';
	$port = 8888;

	/*$server = '108.175.9.76';
	$port = 7878;*/
	
	$strVal = '1,mt4response,'.$strVal; 
	
	if(!($sock = socket_create(AF_INET, SOCK_DGRAM, 0)))
	{
		$errorcode = socket_last_error();
		$errormsg = socket_strerror($errorcode);
		 
		die("Couldn't create socket: [$errorcode] $errormsg \n");
	}
	 
	echo "Socket created \n";
		if( ! socket_sendto($sock, $strVal , strlen($strVal) , 0 , $server , $port))
		{
			$errorcode = socket_last_error();
			$errormsg = socket_strerror($errorcode);
			 
			die("Could not send data: [$errorcode] $errormsg \n");
		}
		
		$r = socket_recvfrom($sock, $buf, 512, 0, $remote_ip, $remote_port);
		
		if($r!=""){
		echo("<script>location.href='mt4ui.php?token=1'</script>");
		
		}
	}
	
function SocketClient2($strVal)
	{

/*	$server = '192.168.1.55';
	$port = 8888;
*/
	$server = '108.175.9.76';
	$port = 7878;
	
	$strVal = $strVal; 
	
	if(!($sock = socket_create(AF_INET, SOCK_DGRAM, 0)))
	{
		$errorcode = socket_last_error();
		$errormsg = socket_strerror($errorcode);
		 
		die("Couldn't create socket: [$errorcode] $errormsg \n");
	}
	 
	echo "Socket created \n";
		if( ! socket_sendto($sock, $strVal , strlen($strVal) , 0 , $server , $port))
		{
			$errorcode = socket_last_error();
			$errormsg = socket_strerror($errorcode);
			 
			die("Could not send data: [$errorcode] $errormsg \n");
		}
		
		$r = socket_recvfrom($sock, $buf, 512, 0, $remote_ip, $remote_port);
		
		if($r!=""){
		echo("<script>location.href='mt4ui.php?token=1'</script>");
		
		}
	}	
	
if ( !isset( $HTTP_RAW_POST_DATA ) )
   $HTTP_RAW_POST_DATA =file_get_contents( 'php://input' );
// create HTTP listener
$server->service($HTTP_RAW_POST_DATA);
exit(); 
?>  