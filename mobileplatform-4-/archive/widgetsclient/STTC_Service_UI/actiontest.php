<?php

$a = '{"changeBalanceResult":"{\"deal\":3101048,\"message\":\"OK\",\"msgtype\":65,\"requestId\":19,\"result\":0}"}';
$webService = json_decode($a);
$Arr=objectToArray($webService);

echo $Arr['changeBalanceResult'];
$json = json_decode($Arr['changeBalanceResult'], true);
echo $json['message'];

	class AccountInfo
    {
		public $GatewayId;                   	// Account ID
	}

	try
	{
		$Login		= 'admin';
		$Password	= '123';
		$webURL		= "http://192.168.1.84:9090/STTCservice.svc?wsdl";
		//$webURL		= "http://192.168.1.77:9090/STTCservice.svc?wsdl";

		$client = new SoapClient($webURL);

		if(count($_POST>0) && isset($_POST['GetGatewaysList']))
		{
			$GatewayId = (int)$_POST['GatewayId'];

			/*$objAG = new AccountInfo();
			$objAG->GatewayId = $GatewayId;*/



			$param=array('Login'=>$Login,'Password'=>$Password,'GatewayId'=>$GatewayId);
			//print_r($param);
			@$webService = $client->GetGatewaysList($param);

		}


		//echo"<pre>"; print_r($webService); //die;


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

