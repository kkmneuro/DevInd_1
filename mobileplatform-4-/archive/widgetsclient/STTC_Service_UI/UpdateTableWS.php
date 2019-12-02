<?php
header("Expires: Tue, 01 jan 2000 00:00:00 GMT");
header("Last-Modified:".gmdate("D,d M Y h:i:s"). " GMT");
header("Cache-Control: no-store,must-revalidate,max-age=0");
header("Cache-Control: post-check=0,pre-check=0",false);
header("Pragma: no-cache");
//error_reporting(0);
//date_default_timezone_set("America/Los_Angeles");

	

	try
	{
		$Login		= 'admin';
		$Password	= '123';
		$webURL		= "http://185.62.85.23:9090/STTCservice.svc?wsdl&".rand(1,10000);
		
		$client = new SoapClient($webURL);

		
			$GroupId = $_POST['GroupId'];
			$param_GetAccountGroups=array('Login'=>$Login,'Password'=>$Password,'GroupId'=>$GroupId);
		    $webService = $client->GetAccountGroups($param_GetAccountGroups);
		   //print_r($_POST); die;
		
		echo '<pre>'; print_r($webService);
		
	

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
