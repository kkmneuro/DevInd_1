<!DOCTYPE HTML>
<html> 
<body>
<?php
Define("ApiURL","http://192.168.1.84:82/RestServiceImpl.svc/");
//echo ApiURL; 
//echo file_get_contents("http://192.168.1.84:82/RestServiceImpl.svc/AuthenticateUser/test/password");

	$tockenidfind = file_get_contents(ApiURL."AuthenticateUser/test/password");
	$tockeniddecodelist = json_decode($tockenidfind); 

	$tockenidconvertarray = objectToArray($tockeniddecodelist); 
	$tockenid=	$tockenidconvertarray['AuthenticateUserResult'];
			
if(count($_POST>0) && isset($_POST['AuthenticateUser']))
		{
			$username = $_POST['username']; 
			$password = $_POST['password'];
			
			$WebserviceDetails = file_get_contents(ApiURL."AuthenticateUser/".$username."/".$password);
			$tockeniddecodelist = json_decode($WebserviceDetails); 

			$tockenidconvertarray = objectToArray($tockeniddecodelist); 
			$Gettockenid=	$tockenidconvertarray['AuthenticateUserResult'];	
		}
		
if(count($_POST>0) && isset($_POST['GetAccounts']))
		{
			$managerId = $_POST['managerId']; 
			
			$HitURL = ApiURL."GetAccounts/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['CheckPassword']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$password = $_POST['password'];
			$comment = $_POST['comment'];
			
			$HitURL = ApiURL."CheckPassword/".$tockenid."/".$managerId."/".$accountId."/".$password."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['ChangePassword']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$password = $_POST['password'];
			$newpassword = $_POST['newpassword'];
			
			$HitURL = ApiURL."ChangePassword/".$tockenid."/".$managerId."/".$accountId."/".$password."/".$newpassword;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
		
if(count($_POST>0) && isset($_POST['GetAccountInfo']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			
			$HitURL = ApiURL."GetAccountInfo/".$tockenid."/".$managerId."/".$accountId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}


if(count($_POST>0) && isset($_POST['changeBalance']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$balance = $_POST['balance'];
			$comment = $_POST['comment'];
			
			$HitURL = ApiURL."changeBalance/".$tockenid."/".$managerId."/".$accountId."/".$balance."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['ChangeCredit']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$balance = $_POST['balance'];
			$time = $_POST['time'];
			$comment = $_POST['comment'];
			
			echo $HitURL = ApiURL."ChangeCredit/".$tockenid."/".$managerId."/".$accountId."/".$time."/".$balance."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

	if(count($_POST>0) && isset($_POST['TransferBalance']))
		{
			$managerId = $_POST['managerId']; 
			$fromaccountId = $_POST['fromaccountId'];
			$ToaccountId = $_POST['ToaccountId'];
			$balance = $_POST['balance'];
			$comment = $_POST['comment'];
			
			$HitURL = ApiURL."TransferBalance/".$tockenid."/".$managerId."/".$fromaccountId."/".$ToaccountId."/".$balance."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
		
if(count($_POST>0) && isset($_POST['SymbolsGetAll']))
		{
			$managerId = $_POST['managerId']; 
			
			$HitURL = ApiURL."SymbolsGetAll/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['CreateAccount']))
		{
			$managerId = $_POST['managerId']; 
			$login = $_POST['login']; 
			$group = $_POST['group']; 
			$password = $_POST['password']; 
			$enable = $_POST['enable']; 
			$enable_change_password = $_POST['enable_change_password']; 
			$enable_read_only = $_POST['enable_read_only']; 
			$password_investor = $_POST['password_investor']; 
			$password_phone = $_POST['password_phone']; 
			$name = $_POST['name']; 
			$country = $_POST['country']; 
			$city = $_POST['city']; 
			$state = $_POST['state']; 
			$zipcode = $_POST['zipcode']; 
			$address = $_POST['address']; 
			$phone = $_POST['phone']; 
			$email = $_POST['email']; 
			$comment = $_POST['comment']; 
			$id = $_POST['id']; 
			$status = $_POST['status']; 
			$leverage = $_POST['leverage']; 
			$agent_account = $_POST['agent_account']; 
			$balance = $_POST['balance']; 
			$prevmonthbalance = $_POST['prevmonthbalance']; 
			$prevbalance = $_POST['prevbalance'];
			$credit = $_POST['credit'];	

			$HitURL = ApiURL."CreateAccount/".$tockenid."/".$managerId."/".$login."/".$group."/".$password."/".$enable."/".$enable_change_password."/".$enable_read_only."/".$password_investor."/".$password_phone."/".$name."/".$country."/".$city."/".$state."/".$zipcode."/".$address."/".$phone."/".$email."/".$comment."/".$id."/".$status."/".$leverage."/".$agent_account."/".$balance."/".$prevmonthbalance."/".$prevbalance."/".$credit;	
			
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['ModifyAccount']))
		{
			$managerId = $_POST['managerId']; 
			$login = $_POST['login']; 
			$group = $_POST['group']; 
			$password = $_POST['password']; 
			$enable = $_POST['enable']; 
			$enable_change_password = $_POST['enable_change_password']; 
			$enable_read_only = $_POST['enable_read_only']; 
			$password_investor = $_POST['password_investor']; 
			$password_phone = $_POST['password_phone']; 
			$name = $_POST['name']; 
			$country = $_POST['country']; 
			$city = $_POST['city']; 
			$state = $_POST['state']; 
			$zipcode = $_POST['zipcode']; 
			$address = $_POST['address']; 
			$phone = $_POST['phone']; 
			$email = $_POST['email']; 
			$comment = $_POST['comment']; 
			$id = $_POST['id']; 
			$status = $_POST['status']; 
			$leverage = $_POST['leverage']; 
			$agent_account = $_POST['agent_account']; 
			$balance = $_POST['balance']; 
			$prevmonthbalance = $_POST['prevmonthbalance']; 
			$prevbalance = $_POST['prevbalance'];
			$credit = $_POST['credit'];	

			$HitURL = ApiURL."ModifyAccount/".$tockenid."/".$managerId."/".$login."/".$group."/".$password."/".$enable."/".$enable_change_password."/".$enable_read_only."/".$password_investor."/".$password_phone."/".$name."/".$country."/".$city."/".$state."/".$zipcode."/".$address."/".$phone."/".$email."/".$comment."/".$id."/".$status."/".$leverage."/".$agent_account."/".$balance."/".$prevmonthbalance."/".$prevbalance."/".$credit;	
			
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['DeleteAccount']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$comment = $_POST['comment'];			
			
			$HitURL = ApiURL."DeleteAccount/".$tockenid."/".$managerId."/".$accountId."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
		
if(count($_POST>0) && isset($_POST['GetOpenedTradesForAccountId']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			
			$HitURL = ApiURL."GetOpenedTradesForAccountId/".$tockenid."/".$managerId."/".$accountId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}		

if(count($_POST>0) && isset($_POST['GetOpenOrders']))
		{
			$managerId = $_POST['managerId'];
			$HitURL = ApiURL."GetOpenOrders/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['GetTradeHistory']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			
			$dateconvert =  date_create($_POST['FromTime']);
			$FromTime = date_format($dateconvert,"Y-m-d");
			
			$dateconvert =  date_create($_POST['TillTime']);
			$TillTime = date_format($dateconvert,"Y-m-d");
			
			//$FromTime = $_POST['FromTime'];
			//$TillTime = $_POST['TillTime'];
			
			$HitURL = ApiURL."GetTradeHistory/".$tockenid."/".$managerId."/".$accountId."/".$FromTime."/".$TillTime;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}		
		
if(count($_POST>0) && isset($_POST['AccountHaveTrades']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			//$FromTime = $_POST['FromTime'];
			//$TillTime = $_POST['TillTime'];
			
			$dateconvert =  date_create($_POST['FromTime']);
			$FromTime = date_format($dateconvert,"Y-m-d");
			$dateconvert =  date_create($_POST['TillTime']);
			$TillTime = date_format($dateconvert,"Y-m-d");
			
			$HitURL = ApiURL."AccountHaveTrades/".$tockenid."/".$managerId."/".$accountId."/".$FromTime."/".$TillTime;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
if(count($_POST>0) && isset($_POST['UpdateLeverage']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$leverage = $_POST['leverage'];
			
			$HitURL = ApiURL."UpdateLeverage/".$tockenid."/".$managerId."/".$accountId."/".$leverage;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['GetGroupRecord']))
		{
			$managerId = $_POST['managerId'];
			$group = $_POST['group'];
						
			$HitURL = ApiURL."GetGroupRecord/".$tockenid."/".$managerId."/".$group;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['GetGroups']))
		{
			$managerId = $_POST['managerId'];
						
			$HitURL = ApiURL."GetGroups/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['GetAccountBalance']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$comment = $_POST['comment'];
			
			$HitURL = ApiURL."GetAccountBalance/".$tockenid."/".$managerId."/".$accountId."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}


if(count($_POST>0) && isset($_POST['OpenOrder']))
		{
			$managerId = $_POST['managerId'];
			$Type = $_POST['Type'];
			$reserved = $_POST['reserved'];
			$cmd = $_POST['cmd'];
			$order = $_POST['order'];
			$LoginId = $_POST['LoginId'];
			$symbol = $_POST['symbol'];
			$volume = $_POST['volume'];
			$tradeprice = $_POST['tradeprice'];
			$stoploss = $_POST['stoploss'];
			$takeprofit = $_POST['takeprofit'];
			$deviation = $_POST['deviation'];
			$comment = $_POST['comment'];
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."OpenOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['ModifyOrder']))
		{
			$managerId = $_POST['managerId'];
			$Type = $_POST['Type'];
			$reserved = $_POST['reserved'];
			$cmd = $_POST['cmd'];
			$order = (int)$_POST['order'];
			$LoginId = (int)$_POST['LoginId'];
			$symbol = $_POST['symbol'];
			$volume = (int)$_POST['volume'];
			$tradeprice = (int)$_POST['tradeprice'];
			$stoploss = (int)$_POST['stoploss'];
			$takeprofit = (int)$_POST['takeprofit'];
			$deviation = (int)$_POST['deviation'];
			$comment = $_POST['comment'];
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."ModifyOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['OpenPendingOrder']))
		{
			$managerId = $_POST['managerId'];
			$Type = $_POST['Type'];
			$reserved = $_POST['reserved'];
			$cmd = $_POST['cmd'];
			$order = (int)$_POST['order'];
			$LoginId = (int)$_POST['LoginId'];
			$symbol = $_POST['symbol'];
			$volume = (int)$_POST['volume'];
			$tradeprice = (int)$_POST['tradeprice'];
			$stoploss = (int)$_POST['stoploss'];
			$takeprofit = (int)$_POST['takeprofit'];
			$deviation = (int)$_POST['deviation'];
			$comment = $_POST['comment'];
			$expiration = $_POST['expiration'];
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."OpenPendingOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$expiration."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['ModifyPendingOrder']))
		{
			$managerId = $_POST['managerId'];
			$Type = $_POST['Type'];
			$reserved = $_POST['reserved'];
			$cmd = $_POST['cmd'];
			$order = (int)$_POST['order'];
			$LoginId = (int)$_POST['LoginId'];
			$symbol = $_POST['symbol'];
			$volume = (int)$_POST['volume'];
			$tradeprice = (int)$_POST['tradeprice'];
			$stoploss = (int)$_POST['stoploss'];
			$takeprofit = (int)$_POST['takeprofit'];
			$deviation = (int)$_POST['deviation'];
			$comment = $_POST['comment'];
			$expiration = $_POST['expiration'];
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."ModifyPendingOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$expiration."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['CloseOrder']))
		{
			$managerId = $_POST['managerId'];
			$Type = $_POST['Type'];
			$reserved = $_POST['reserved'];
			$cmd = $_POST['cmd'];
			$order = $_POST['order'];
			$LoginId = $_POST['LoginId'];
			$symbol = $_POST['symbol'];
			$volume = $_POST['volume'];
			$tradeprice = $_POST['tradeprice'];
			$stoploss = $_POST['stoploss'];
			$takeprofit = $_POST['takeprofit'];
			$deviation = $_POST['deviation'];
			$comment = $_POST['comment'];
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."CloseOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['DeleteOrder']))
		{
			$managerId = $_POST['managerId'];
			$Type = $_POST['Type'];
			$reserved = $_POST['reserved'];
			$cmd = $_POST['cmd'];
			$order = $_POST['order'];
			$LoginId = $_POST['LoginId'];
			$symbol = $_POST['symbol'];
			$volume = $_POST['volume'];
			$tradeprice = $_POST['tradeprice'];
			$stoploss = $_POST['stoploss'];
			$takeprofit = $_POST['takeprofit'];
			$deviation = $_POST['deviation'];
			$comment = $_POST['comment'];
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."DeleteOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
		
echo $WebserviceDetails; // Print Records

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
</body>
</html>