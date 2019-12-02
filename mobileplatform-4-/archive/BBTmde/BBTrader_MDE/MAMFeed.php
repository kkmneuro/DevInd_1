<?php
session_start();
include("config.php");
$username='f003';
$password='152207';


		try{
		
		$client = new SoapClient("http://108.175.9.76:8041/ExchangeInstrumentService.svc?wsdl");
		$param=array('participantsId'=>54); // 54
		
		//$param3=array('UserName'=>'bbt','Password'=>'bbt','Symbols'=>'SILVERJUL2015,SILVERMAUG2015,COPPERAUG2015,COPPERMAUG2015,GOLDAUG2015'); // 54
		
		@$webService = $client->GetInstrumentSpec($param);
		$Arr=objectToArray($webService); 
		
                        foreach ($Arr as $innerArray) {
                        //  Check type
                        if (is_array($innerArray)){
                        //  Scan through inner loop
                        foreach ($innerArray as $value) {
                        
                          if (is_array($value)){
                         
                          foreach ($value as $explodeSYB) { 
						  $pks=$explodeSYB['Symbol']; 
						 //die;
						 echo '<pre>';print_r($explodeSYB['Symbol']);
		}}}}}
		echo '<pre>';print_r($Arr); 
		$_SESSION['Arr']=$Arr;      
		//$webService = $client->GetInstrumentInfo($param);
		//@$symbolsupdate = $client->UpdatePortfolio($param3);
		?>
		
		
		<?php
		/*$client2 = new	SoapClient("http://78.47.54.100:8041/ExchangeInstrumentService.svc?wsdl");
		$param2=array('UserName'=>$username,'Password'=>$password); // 54
		@$user = $client2->IsUserAuthenticate($param2);
		
		   $Arr=objectToArray($user);        
                        foreach ($Arr as $innerArray) {
			
			             $alluser=$innerArray;
			
						}*/
		$qty2=mysql_query("SELECT * from users where username = '".$username."' and password = '".$password."'");
		$alluser = mysql_fetch_array($qty2);
		
		print_r($alluser['symbols']); 
		$_SESSION['AllSymbols'] =  $alluser['symbols'];		
		@$_SESSION['Auth'] =  $alluser['IsAuthenticate'];
						  
		if($_SESSION['Auth'] ==1 && $pks!=''){ 
		
			//header("Location:BBdetails.php");
		} else {
			//header("Location:BBTrader.php?wrong");
		}
		
/////////////
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