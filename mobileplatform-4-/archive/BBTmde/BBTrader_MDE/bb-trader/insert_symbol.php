<?php
include("config.php");
date_default_timezone_set("Asia/Kolkata");
$d1=date("Y-m-d H:i:s");

$username = $_POST['var1'];
$password = $_POST['var2'];
$symbols = $_POST['var3'];

$allsymbols = implode(",",$symbols);


			//$querySYM=mysql_query("UPDATE users set symbols = '".$allsymbols."',date_time='".$d1."' where username = '".$username."' and password = '".$password."'");

$qty2=mysql_query("delete from users where username = '".$username."' and password = '".$password."'");

	$querySYM=mysql_query("INSERT INTO users(username,password,symbols,date_time)values('".$username."','".$password."','".$allsymbols."','".$d1."')");
?>
