<!DOCTYPE HTML>
<html> 
<body>
<?php
// Define("ApiURL","http://192.168.1.84:83/RestServiceImpl.svc/");
 Define("ApiURL","http://216.75.21.45:83/RestServiceImpl.svc/");

 //echo file_get_contents("http://192.168.1.84:83/RestServiceImpl.svc/AuthenticateUser/test2/password2/4");

	$tockenidfind = file_get_contents(ApiURL."AuthenticateUser/test/password/1");
	$tockeniddecodelist = json_decode($tockenidfind); 

	$tockenidconvertarray = objectToArray($tockeniddecodelist); 
	$tockenid=	$tockenidconvertarray['AuthenticateUserResult'];
			
if(count($_POST>0) && isset($_POST['AuthenticateUser']))
		{
			$username = $_POST['username']; 
			$password = $_POST['password'];
			$TCInstanceId = $_POST['TCInstanceId'];
			
			$WebserviceDetails = file_get_contents(ApiURL."AuthenticateUser/".$username."/".$password."/".$TCInstanceId);
			$tockeniddecodelist = json_decode($WebserviceDetails); 

			$tockenidconvertarray = objectToArray($tockeniddecodelist); 
			$Gettockenid=	$tockenidconvertarray['AuthenticateUserResult'];	
		}
		
if(count($_POST>0) && isset($_POST['GetAccountInfo']))
		{
			$managerId = $_POST['managerId']; 
			$TCInstanceId = $_POST['TCInstanceId'];
			$TCGatewayId = $_POST['TCGatewayId'];
			$accountId = $_POST['accountId'];
			
			$HitURL = ApiURL."getAccountInfo/".$tockenid."/".$managerId."/".$TCInstanceId."/".$TCGatewayId."/".$accountId;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['CheckPassword']))
		{
			$managerId = $_POST['managerId']; 
			$TCInstanceId = $_POST['TCInstanceId'];
			$TCGatewayId = $_POST['TCGatewayId'];
			$accountId = $_POST['accountId'];
			$password = $_POST['password'];
			$comment = $_POST['comment'];
			
			$HitURL = ApiURL."CheckPassword/".$tockenid."/".$managerId."/".$TCInstanceId."/".$TCGatewayId."/".$accountId."/".$password."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}

if(count($_POST>0) && isset($_POST['changeBalance']))
		{
			$managerId = $_POST['managerId']; 
			$TCInstanceId = $_POST['TCInstanceId'];
			$TCGatewayId = $_POST['TCGatewayId'];
			$accountId = $_POST['accountId'];
			$balance = $_POST['balance'];
			$comment = $_POST['comment'];
			
			$HitURL = ApiURL."changeBalance/".$tockenid."/".$managerId."/".$TCInstanceId."/".$TCGatewayId."/".$accountId."/".$balance."/".$comment;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
		
if(count($_POST>0) && isset($_POST['CreateAccount']))
		{
			$managerId = $_POST['managerId']; 
			$TCInstanceId = $_POST['TCInstanceId'];
			$TCGatewayId = $_POST['TCGatewayId'];
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

			$HitURL = ApiURL."CreateAccount/".$tockenid."/".$managerId."/".$TCInstanceId."/".$TCGatewayId."/".$login."/".$group."/".$password."/".$enable."/".$enable_change_password."/".$enable_read_only."/".$password_investor."/".$password_phone."/".$name."/".$country."/".$city."/".$state."/".$zipcode."/".$address."/".$phone."/".$email."/".$comment."/".$id."/".$status."/".$leverage."/".$agent_account."/".$balance."/".$prevmonthbalance."/".$prevbalance."/".$credit;	
			
			$WebserviceDetails = file_get_contents($HitURL);
				
		}		

if(count($_POST>0) && isset($_POST['PlacePHPOrder']))
		{
			$managerId = $_POST['managerId']; 
			$TCInstanceId = $_POST['TCInstanceId'];
			$TCGatewayId = $_POST['TCGatewayId'];
			$Ordertype = $_POST['Ordertype'];
			$Side = $_POST['Side'];
			$PositionEffect = $_POST['PositionEffect'];
			$OrigOrdId = $_POST['OrigOrdId'];
			$Account = $_POST['Account'];
			$symbol = $_POST['symbol'];
			$volume = $_POST['volume'];
			$Price = $_POST['Price'];
			$SL = $_POST['SL'];
			$TP = $_POST['TP'];
			$RootToMT4Svr = $_POST['RootToMT4Svr'];
			$comment = $_POST['comment'];
			$expiration = $_POST['expiration'];
			$MinOrDisclosedQty = $_POST['MinOrDisclosedQty'];
			
			$HitURL = ApiURL."PlacePHPOrder/".$tockenid."/".$managerId."/".$TCInstanceId."/".$TCGatewayId."/".$Ordertype."/".$Side."/".$PositionEffect."/".$OrigOrdId."/".$Account."/".$symbol."/".$volume."/".$Price."/".$SL."/".$TP."/".$RootToMT4Svr."/".$comment."/".$expiration."/".$MinOrDisclosedQty;
			$WebserviceDetails = file_get_contents($HitURL);
				
		}
		
echo $WebserviceDetails; // Print Records

echo '<pre>'; print_r(json_decode($WebserviceDetails));
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