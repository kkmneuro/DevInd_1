<?php
session_start();
include("config.php");
date_default_timezone_set("Asia/Kolkata");
$d1=date("Y-m-d H:i:s");

$username = $_SESSION['username'];
$password = $_SESSION['password'];
$symbols = $_POST['var3'];

$allsymbols = implode(",",$symbols);
////////
/*$client = new
		SoapClient("http://78.47.54.100:8041/ExchangeInstrumentService.svc?wsdl");
		$param=array('participantsId'=>115); // 54

$param3=array('UserName'=>$username,'Password'=>$password,'Symbols'=>$allsymbols); // 54
$symbolsupdate = $client->UpdatePortfolio($param3);
*/
////////

//$querySYM=mysql_query("UPDATE users set symbols = '".$allsymbols."',date_time='".$d1."' where username = '".$username."' and password = '".$password."'");

$qty2=mysql_query("delete from users where username = '".$username."' and password = '".$password."'");

	$querySYM=mysql_query("INSERT INTO users(username,password,symbols,date_time)values('".$username."','".$password."','".$allsymbols."','".$d1."')");
session_destroy();

?>
