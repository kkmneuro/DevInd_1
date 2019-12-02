<!DOCTYPE HTML>
<html> 
<body>
<?php

try 
	{
		$username 	= 'test';
		$password 	= 'password';
		//$webURL		= "http://192.168.1.84:50697/RestServiceImpl.svc?wsdl";
		//$webURL		= "http://192.168.1.77:82/?wsdl";
		$webURL		= "http://108.175.9.76:82/?wsdl";
		

		$client = new SoapClient($webURL);
		
		$param_AuthenticateUser=array('username'=>$username,'password'=>$password);
		$webService = $client->AuthenticateUser($param_AuthenticateUser);

		$Arr=objectToArray($webService);
		echo 'Token ID = '.$tokenid= (string)$Arr['AuthenticateUserResult'];	
									
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1);
		//$webService = $client->GetAccounts($param2);
		
		//$param3=array('tokenid'=>$tokenid,'managerId'=>1,'accountId'=>1017,'balance'=>500,'comment'=>'Test');
		//$webService = $client->changeBalance($param3);
		
		//$param3=array('tokenid'=>$tokenid,'managerId'=>1);
		//$webService = $client->SymbolsGetAll($param3); // Error : Caught exception: Error Fetching http headers // Solved
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1);
		//$webService = $client->GetOpenOrders($param2); // Error : Caught exception: Error Fetching http headers
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1);
		//$webService = $client->GetGroups($param2);
		

		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'group'=>'ADM-DEMO');
		//$webService = $client->GetGroupRecord($param2);
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'accountId'=>101);
		//$webService = $client->GetAccountInfo($param2);	
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'accountId'=>101,'password'=>'101','comment'=>'test');
		//$webService = $client->CheckPassword($param2);	 // "message":"Invalid account"
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'accountId'=>101,'balance'=>100.10,'time'=>'2016-09-28T17:40:29','comment'=>'test');
		//$webService = $client->ChangeCredit($param2);	 // "message":""message":"Invalid parameters""
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'fromaccountId'=>101,'ToaccountId'=>102,'balance'=>100,'comment'=>'test');
		//$webService = $client->TransferBalance($param2);	 
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'accountId'=>1017);
		//$webService = $client->GetOpenedTradesForAccountId($param2);	
		
		//$param2=array('tokenid'=>$tokenid,'managerId'=>1,'accountId'=>101,'FromTime'=>'2016-01-28T17:40:29','TillTime'=>'2016-11-11T17:40:29');
		//$webService = $client->GetTradeHistory($param2);	// Loading Page  
		
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