<?php
session_start();
Define("ApiURL","http://192.168.2.84:82/RestServiceImpl.svc/");
//Define("ApiURL","http://108.175.9.76:82/RestServiceImpl.svc/");
//Define("ApiURL","http://173.228.132.248/RestServiceImpl.svc/");
//Define("ApiURL","http://74.208.228.33:82/RestServiceImpl.svc/");


//echo ApiURL; 
//echo file_get_contents("http://192.168.1.84:82/RestServiceImpl.svc/AuthenticateUser/test/password");

	$dolorsign = "$";
	$tockenidfind = file_get_contents(ApiURL."AuthenticateUser/test/password"); // for 33 server
	//$tockenidfind = file_get_contents(ApiURL."AuthenticateUser/lqd3192/g1JNDDr".$dolorsign."mOE"); // for 33 server
	
	$tockeniddecodelist = json_decode($tockenidfind); 

	$tockenidconvertarray = objectToArray($tockeniddecodelist); 
	$tockenid=	$tockenidconvertarray['AuthenticateUserResult'];
			
if(count($_POST>0) && isset($_POST['AuthenticateUser']))
		{
			//print_r($_POST); die;
			$username = $_POST['username']; 
			$password = $_POST['password'];
			
			$WebserviceDetails = file_get_contents(ApiURL."AuthenticateUser/".$username."/".$password);
			$tockeniddecodelist = json_decode($WebserviceDetails); 

			$tockenidconvertarray = objectToArray($tockeniddecodelist); 
			$Gettockenid=	$tockenidconvertarray['AuthenticateUserResult'];
			
			$_SESSION['WEbS']= $Gettockenid;
			header("Location:index2.php?token=1");
			
		}
		
if(count($_POST>0) && isset($_POST['GetAccounts']))
		{
			$managerId = $_POST['managerId']; 
			
			$HitURL = ApiURL."GetAccounts/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetAccountsResult'];
			header("Location:index2.php?token=2");

				
		}

if(count($_POST>0) && isset($_POST['CheckPassword']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$password = $_POST['password'];
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			
			$HitURL = ApiURL."CheckPassword/".$tockenid."/".$managerId."/".$accountId."/".$password."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['CheckPasswordResult'];
			header("Location:index2.php?token=3");
				
		}

if(count($_POST>0) && isset($_POST['ChangePassword']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$password = $_POST['password'];
			$newpassword = $_POST['newpassword'];
			
			$HitURL = ApiURL."ChangePassword/".$tockenid."/".$managerId."/".$accountId."/".$password."/".$newpassword;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['ChangePasswordResult'];
			header("Location:index2.php?token=4");
				
		}
		
if(count($_POST>0) && isset($_POST['GetAccountInfo']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			
			$HitURL = ApiURL."GetAccountInfo/".$tockenid."/".$managerId."/".$accountId;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetAccountInfoResult'];
			header("Location:index2.php?token=5");
				
		}


if(count($_POST>0) && isset($_POST['changeBalance']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$balance = $_POST['balance'];
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			
			$HitURL = ApiURL."changeBalance/".$tockenid."/".$managerId."/".$accountId."/".$balance."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['changeBalanceResult'];
			header("Location:index2.php?token=6");
				
		}

if(count($_POST>0) && isset($_POST['ChangeCredit']))
		{
			$managerId = $_POST['managerId']; 
			$accountId = $_POST['accountId'];
			$balance = $_POST['balance'];
			//$time = $_POST['time'];
			$time ='1482215480';
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			
			$HitURL = ApiURL."ChangeCredit/".$tockenid."/".$managerId."/".$accountId."/".$balance."/".$time."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['ChangeCreditResult'];
			header("Location:index2.php?token=7");			
		}

	if(count($_POST>0) && isset($_POST['TransferBalance']))
		{
			$managerId = $_POST['managerId']; 
			$fromaccountId = $_POST['fromaccountId'];
			$ToaccountId = $_POST['ToaccountId'];
			$balance = $_POST['balance'];
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			
			$HitURL = ApiURL."TransferBalance/".$tockenid."/".$managerId."/".$fromaccountId."/".$ToaccountId."/".$balance."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['TransferBalanceResult'];
			header("Location:index2.php?token=8");
				
		}
		
if(count($_POST>0) && isset($_POST['SymbolsGetAll']))
		{
			$managerId = $_POST['managerId']; 
			
			$HitURL = ApiURL."SymbolsGetAll/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['SymbolsGetAllResult'];
			header("Location:index2.php?token=9");
				
		}

if(count($_POST>0) && isset($_POST['CreateAccount']))
		{
			//echo '<pre>';print_r($_POST); die;
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
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
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
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['CreateAccountResult'];
			header("Location:index2.php?token=10");
				
		}

if(count($_POST>0) && isset($_POST['ModifyAccount']))
		{
			//echo '<pre>';print_r($_POST); die;
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
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
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
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['ModifyAccountResult'];
			header("Location:index2.php?token=11");
				
		}

if(count($_POST>0) && isset($_POST['DeleteAccount']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			
			$HitURL = ApiURL."DeleteAccount/".$tockenid."/".$managerId."/".$accountId."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['DeleteAccountResult'];
			header("Location:index2.php?token=12");
				
		}
		
if(count($_POST>0) && isset($_POST['GetOpenedTradesForAccountId']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			
			$HitURL = ApiURL."GetOpenedTradesForAccountId/".$tockenid."/".$managerId."/".$accountId;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetOpenedTradesForAccountIdResult'];
			header("Location:index2.php?token=13");	
		}		

if(count($_POST>0) && isset($_POST['GetOpenOrders']))
		{
			$managerId = $_POST['managerId'];
			$HitURL = ApiURL."GetOpenOrders/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetOpenOrdersResult'];
			header("Location:index2.php?token=14");		
		}

if(count($_POST>0) && isset($_POST['GetTradeHistory']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			
			//$dateconvert =  date_create($_POST['FromTime']); 
			//$dateconvertT =  date_create($_POST['TillTime']);
			$FromTime = strtotime($_POST['FromTime']);
			$TillTime = strtotime($_POST['TillTime'].'23:59:59');
			
			$HitURL = ApiURL."GetTradeHistory/".$tockenid."/".$managerId."/".$accountId."/".$FromTime."/".$TillTime;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetTradeHistoryResult'];
			header("Location:index2.php?token=15");
				
		}		
		
if(count($_POST>0) && isset($_POST['AccountHaveTrades']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$groupname = $_POST['groupname'];
			
			$HitURL = ApiURL."AccountHaveTrades/".$tockenid."/".$managerId."/".$accountId."/".$groupname;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['AccountHaveTradesResult'];
			header("Location:index2.php?token=16");	
				
		}
if(count($_POST>0) && isset($_POST['UpdateLeverage']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$leverage = $_POST['leverage'];
			
			$HitURL = ApiURL."UpdateLeverage/".$tockenid."/".$managerId."/".$accountId."/".$leverage;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['UpdateLeverageResult'];
			header("Location:index2.php?token=17");		
		}

if(count($_POST>0) && isset($_POST['GetGroupRecord']))
		{
			$managerId = $_POST['managerId'];
			$group = $_POST['group'];
						
			echo $HitURL = ApiURL."GetGroupRecord/".$tockenid."/".$managerId."/".$group;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $WebserviceDetails;
			header("Location:index2.php?token=18");					
		}

if(count($_POST>0) && isset($_POST['GetGroups']))
		{
			$managerId = $_POST['managerId'];
						
			$HitURL = ApiURL."GetGroups/".$tockenid."/".$managerId;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetGroupsResult'];
			header("Location:index2.php?token=19");	
				
		}

if(count($_POST>0) && isset($_POST['GetAccountBalance']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			
			$HitURL = ApiURL."GetAccountBalance/".$tockenid."/".$managerId."/".$accountId."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['GetAccountBalanceResult'];
			header("Location:index2.php?token=20");	
				
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
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."OpenOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['OpenOrderResult'];
			header("Location:index2.php?token=21");
				
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
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."ModifyOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['ModifyOrderResult'];
			header("Location:index2.php?token=22");			
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
			$tradeprice = $_POST['tradeprice'];
			$stoploss = (int)$_POST['stoploss'];
			$takeprofit = (int)$_POST['takeprofit'];
			$deviation = (int)$_POST['deviation'];
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			$expiration = strtotime($_POST['expiration']); 
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."OpenPendingOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$expiration."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['OpenPendingOrderResult'];
			header("Location:index2.php?token=23");				
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
			$tradeprice = $_POST['tradeprice'];
			$stoploss = (int)$_POST['stoploss'];
			$takeprofit = (int)$_POST['takeprofit'];
			$deviation = (int)$_POST['deviation'];
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			$expiration = strtotime($_POST['expiration']); 
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."ModifyPendingOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$expiration."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['ModifyPendingOrderResult'];
			header("Location:index2.php?token=24");		
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
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."CloseOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['CloseOrderResult'];
			header("Location:index2.php?token=25");		
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
			$comment2 = $_POST['comment'];
			$comment = str_replace(" ","%20",$comment2);
			$crc = $_POST['crc'];
			
			
			$HitURL = ApiURL."DeleteOrder/".$tockenid."/".$managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['DeleteOrderResult'];
			header("Location:index2.php?token=26");		
		}
		
if(count($_POST>0) && isset($_POST['UpdateAccountState']))
		{
			$managerId = $_POST['managerId'];
			$accountId = $_POST['accountId'];
			$state = $_POST['state'];
			
			$HitURL = ApiURL."UpdateAccountState/".$tockenid."/".$managerId."/".$accountId."/".$state;
			$WebserviceDetails = file_get_contents($HitURL);
			
			$AllValue = objectToArray(json_decode($WebserviceDetails)); 
			$_SESSION['WEbS']= $AllValue['UpdateAccountStateResult'];
			header("Location:index2.php?token=27");	
				
		}
		
//print_r(json_decode($WebserviceDetails));
//echo '<pre>'; print_r(json_decode($WebserviceDetails));



/*$tockeniddecodelist = json_decode($WebserviceDetails); 

			$tockenidconvertarray = objectToArray($tockeniddecodelist); 
			$test = objectToArray(json_decode($tockenidconvertarray['GetAccountInfoResult']));
			
echo '<pre>';print_r($test['group']);*/
			
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