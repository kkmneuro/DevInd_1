<?php
include("config.php");
echo $username = $_REQUEST['var1'];
echo $password = $_REQUEST['var2'];

$qty2=mysql_query("select * from users where username = '".$username."' and password = '".$password."'");
$result2=mysql_num_rows($qty2);

if($result2 <= 0){
	$queryIN=mysql_query("INSERT INTO users(username,password)values('".$username."','".$password."')");
}
?>