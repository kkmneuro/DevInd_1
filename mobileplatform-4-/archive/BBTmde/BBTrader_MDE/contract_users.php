<?php
session_start();
$username=$_POST['username'];
$password=$_POST['password'];
@$remember=$_POST['remember'];

$_SESSION['username']=$username;
$_SESSION['password']=$password;
$_SESSION['remember']=$remember;

$number_of_days = 365 ;
$date_of_expiry = time() + 60 * 60 * 24 * $number_of_days ;
if(@$remember==1){
setcookie("username", $username, $date_of_expiry );
setcookie("password", $password, $date_of_expiry );
}

		try{
		$client = new
		SoapClient("http://78.47.54.100:8041/ExchangeInstrumentService.svc?wsdl");
		$param=array('participantsId'=>54); // 54
		$param2=array('UserName'=>$username,'Password'=>$password); // 54
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
						 //print_r($explodeSYB);
		}}}}}
		$_SESSION['Arr']=$Arr;      
		//$webService = $client->GetInstrumentInfo($param);
		//@$symbolsupdate = $client->UpdatePortfolio($param3);
		
		@$user = $client->IsUserAuthenticate($param2);
		
		   $Arr=objectToArray($user);        
                        foreach ($Arr as $innerArray) {
			
			             $alluser=$innerArray;
			
						}
		//print_r($alluser); 
		$_SESSION['AllSymbols'] =  $alluser['Symbols'];		
		$_SESSION['Auth'] =  $alluser['IsAuthenticate'];
						  
		if($_SESSION['Auth'] ==1 && $pks!=''){ 
		
			header("Location:BBdetails.php");
		} else {
			header("Location:BBTrader.php?wrong");
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