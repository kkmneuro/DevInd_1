<?php
//error_reporting(0);
//date_default_timezone_set("America/Los_Angeles");



	try
	{
		$Login		= 'admin';
		$Password	= '123';
		$webURL		= "http://192.168.1.84:9090/STTCservice.svc?wsdl";
		

		$client = new SoapClient($webURL);

			$GroupId = 0;
			$param_GetAccountGroups=array('Login'=>$Login,'Password'=>$Password);
		    $webService = $client->GetAccountGroupConnectionMapping($param_GetAccountGroups);
		    //print_r($_POST); die;
		
		
		
		
		//echo"<pre>"; print_r(@$webService); //die;
		//echo json_encode($webService);
		
		///////// Start For Testing /////////
		$Arr=objectToArray($webService);
        foreach ($Arr as $innerArray) {
            if (is_array($innerArray)){
                foreach ($innerArray as $value) {
                    if (is_array($value)){
                        foreach ($value as $GAGMwebSListE) {

							}

					}
				}
			}
		}
		
		$pids = array();
		foreach ($GAGMwebSListE as $h) {
			//$pids[] = $h['Active'];
			//$pids[] = $h['ConnGroupName'];
			$pids[] = $h['ConnID'];
			//$pids[] = $h['GroupID'];
			//$pids[] = $h['LastUpdatedtime'];
		}
		$uniquePids = array_unique($pids);

		
		echo"<pre>"; print_r($uniquePids); //die;
		echo"<pre>"; print_r($GAGMwebSListE); //die;

		
		
		/*$param_GetAccountGroups=array('Login'=>$Login,'Password'=>$Password,'GroupId'=>0);
		 $GAGwebService = $client->GetAccountGroups($param_GetAccountGroups);

$Arr=objectToArray($GAGwebService);
        foreach ($Arr as $innerArray) {
            if (is_array($innerArray)){
                foreach ($innerArray as $value) {
                    if (is_array($value)){
                        foreach ($value as $GAGMwebSList) {

							}

					}
				}
			}
		}
//echo"<pre>"; print_r($GAGMwebSList);	*/	
		///////// End For Testing /////////
		

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

<select name="">
<?php 
/* foreach ($GAGMwebSListE as $value) { 
		
?>
	
		<option value="<?php echo $value['ConnID']; ?>"><?php echo $value['ConnID']; ?></option>
		
		
<?php } */ ?>


</select>












