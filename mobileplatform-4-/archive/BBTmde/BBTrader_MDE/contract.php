<?php
		try{
		$client = new
		SoapClient("http://78.47.54.100:8041/ExchangeInstrumentService.svc?wsdl");
		$param=array('participantsId'=>54);
		//$webService = $client->GetInstrumentInfo($param);
		$webService = $client->GetInstrumentSpec($param);
		
		//echo"<pre>";
		//print_r($webService);
		//$test = get_object_vars($webService);
		//$Arr = (array)$webService;
		
		//var_dump(json_decode($webService, true));
		} catch (Exception $e) {
		
		print  'Caught exception: '.  $e->getMessage(). "\n";		
		}   
	

	function objectToArray($d) {
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