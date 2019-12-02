<?php
//header( 'Content-type: text/html; charset=utf-8' );
echo "Testing time out in seconds\n<br>";
for ($i = 0; $i < 11; $i++) {
    echo $i."<br>";
    flush();
    ob_flush();
	sleep(5);
}

/*ini_set("soap.wsdl_cache_enabled", "0");  
		try{
		$client = new SoapClient("ws://108.175.9.76:9051/test"); // web (WCF) service 
		//$param=array('participantsId'=>115); // 54
		$param2=array('request'=>1,'msgtype'=>83); // 54
		//$param3=array('UserName'=>'bbt','Password'=>'bbt','Symbols'=>'SILVERJUL2015,SILVERMAUG2015,COPPERAUG2015,COPPERMAUG2015,GOLDAUG2015'); // 54
		
		 
@$user = $client->checkVat($param2);
		
		   $Arr=objectToArray($user);        
                        foreach ($Arr as $innerArray) {
			
			             $alluser=$innerArray;
			
						}
		//print_r($alluser); 
		print_r($user); 
						  
		
		
/////////////
		} catch (Exception $e) {
		
		print  'Caught exception: '.  $e->getMessage(). "\n";		
		}   
	

	function objectToArray($d) {
		if (is_object($d)) {
			$d = get_object_vars($d);
		}
		
		if (is_array($d)) {
			return array_map(__FUNCTION__, $d);
		}
		else {
			// Return array
			return $d;
		}
	}*/



?>