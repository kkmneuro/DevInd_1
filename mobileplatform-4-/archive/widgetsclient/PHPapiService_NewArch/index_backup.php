<!DOCTYPE HTML>
<html> 
<body>
<?php
error_reporting(E_ALL);
//ini_set('display_errors', '1');
try 
	{
		$username 	= 'test2';
		$password 	= 'password2';
		$webURL		= "http://192.168.1.84:83/RestServiceImpl.svc?wsdl";
		//$webURL		= "http://192.168.1.77:82/?wsdl";
		//$webURL		= "http://108.175.9.76:82/?wsdl";
		
		

		$client = new SoapClient($webURL);
		
		$param_AuthenticateUser=array('username'=>$username,'password'=>$password,'TCInstanceId'=>'4');
		$webService = $client->AuthenticateUser($param_AuthenticateUser);

		$Arr=objectToArray($webService);
		echo 'Token ID = '.$tokenid= (string)$Arr['AuthenticateUserResult'];	
									
		//$param2=array('tokenid'=>$tokenid,'managerId'=>'1','TCInstanceId'=>'1','TCGatewayId'=>'1','accountId'=>'1','password'=>'1','comment'=>'1');
		//$webService = $client->CheckPassword($param2);
		
		//$param3=array('tokenid'=>$tokenid,'managerId'=>'1','TCInstanceId'=>'1','TCGatewayId'=>'1','accountId'=>'1');
		//$webService = $client->GetAccountInfo($param3);
		
		//$param3=array('tokenid'=>$tokenid,'managerId'=>'1','TCInstanceId'=>'1','TCGatewayId'=>'1','accountId'=>'1','balance'=>'1','comment'=>'1');
		//$webService = $client->changeBalance($param3); 
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>'1','TCInstanceId'=>'1','TCGatewayId'=>'1','login'=>'1','group'=>'1','password'=>'1','enable'=>'1','enable_change_password'=>'1','enable_read_only'=>'1','password_investor'=>'1','password_phone'=>'1','name'=>'1','country'=>'1','city'=>'1','state'=>'1','zipcode'=>'1','address'=>'1','phone'=>'1','email'=>'1','comment'=>'1','id'=>'1','status'=>'1','leverage'=>'1','agent_account'=>'1','balance'=>'1','prevmonthbalance'=>'1','prevbalance'=>'1','credit'=>'1');
		//$webService = $client->CreateAccount($param2); 
		
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>'1','TCInstanceId'=>'1','TCGatewayId'=>'1','Ordertype'=>'1','Side'=>'1','PositionEffect'=>'1','OrigOrdId'=>'1','Account'=>'1','symbol'=>'1','volume'=>'1','Price'=>'1','SL'=>'1','TP'=>'1','RootToMT4Svr'=>'1','comment'=>'1','expiration'=>'1','MinOrDisclosedQty'=>'1');
		//$webService = $client->PlacePHPOrder($param2);
		

		
echo"<pre>"; print_r($webService); //die;				
	
	//echo $webService['webService'];	

	
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
</body>
</html>