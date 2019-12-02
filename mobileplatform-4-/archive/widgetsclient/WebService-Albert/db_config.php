<?php
// for Local Server db details    // 
$db_host = "localhost"; //hostname
$db_user = "root"; // username
$db_password = ""; // password
$db_name = "test"; //database name

// for online db details 52.10.81.27    // 
/*$db_host = "localhost"; //hostname
$db_user = "root"; // username
$db_password = ""; // password
$db_name = "marketdb"; //database name*/


$conn = mysql_connect($db_host, $db_user, $db_password );
mysql_select_db($db_name, $conn);

	if(!$conn) {
		//echo('Not Connection');
    } else{
		//echo('Connection Successful!');
	}
	
?>