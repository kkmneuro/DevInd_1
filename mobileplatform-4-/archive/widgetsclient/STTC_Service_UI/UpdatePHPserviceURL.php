<?php
include("config.php");
$AllData = $_REQUEST['data'];
$ArrData=objectToArray(json_decode($AllData));
//echo '<pre>'; print_r($ArrData);
$num = count($ArrData);
if($num>1)
{
	//echo '<pre>'; print_r($ArrData);
	
	echo '<br>msgtype = '.$ArrData['msgtype'];
	
	if($ArrData['msgtype']==63)
	{
		echo '<br>ConnGroupName = '.$ArrData['ConnGroupName'];
		echo '<br>GroupID = '.$ArrData['GroupID'];
		echo '<br>ConnID = '.$ArrData['ConnID'];
		echo '<br>Active = '.$ArrData['Active'];
		echo '<br>Currency = '.$ArrData['Currency'];
		//echo '<br>LastUpdatedtime = '.$ArrData['LastUpdatedtime'];
		$date2 = str_replace("/Date(","",$ArrData['LastUpdatedtime']); 
		$date3 = str_replace("000)/","",$date2); 
		$dt = new DateTime("@$date3");  // convert UNIX timestamp to PHP DateTime
		echo '<br>LastUpdatedtime ='.$lastmdate = $dt->format('Y-m-d H:i:s'); // output = 2017-01-01 00:00:00
	
	
	$sql = mysql_query("Update groupname SET ConnGroupName='".$ArrData['ConnGroupName']."' ,GroupID='".$ArrData['GroupID']."',ConnID='".$ArrData['ConnID']."',Active='".$ArrData['Active']."',Currency='".$ArrData['Currency']."',LastUpdatedtime='".$lastmdate."' where id=1 ");
	
	}
	
	
	
	if($ArrData['msgtype']==64)
	{
	
		echo '<br>balance = '.$ArrData['balance'];
		echo '<br>country = '.$ArrData['country'];
		echo '<br>equity = '.$ArrData['equity'];
		echo '<br>group = '.$ArrData['group'];
		echo '<br>leverage = '.$ArrData['leverage'];
		echo '<br>margin = '.$ArrData['margin'];
		echo '<br>margin_free = '.$ArrData['margin_free'];
		echo '<br>margin_level = '.$ArrData['margin_level'];
		
	
	$sql = mysql_query("Update accounts SET balance='".$ArrData['balance']."' ,country='".$ArrData['country']."',equity='".$ArrData['equity']."',groups='".$ArrData['group']."',leverage='".$ArrData['leverage']."',margin='".$ArrData['margin']."',margin_free='".$ArrData['margin_free']."',margin_level='".$ArrData['margin_level']."' where id=1 ");
	}
	
	// Get Data Update in db 
}
else 
{
	echo '<h3>No Data</h3>';
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
