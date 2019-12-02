<?php
session_start();
include("config.php");
date_default_timezone_set("Asia/Kolkata");
$d2=date("Y-m-d H:i:s");
$username1 = $_POST['var100'];
$password1 = $_POST['var101'];


 $_SESSION['user1']=$username1;
 $_SESSION['pass1']=$password1;

$qty13=mysql_query("SELECT * FROM users where username='".$username1."' and password='".$password1."' and symbols!=''");
        $res13=mysql_fetch_array($qty13);
        //print_r($res13['symbols']);

        echo $res13['symbols'];
		$selectsymbol=explode(',',$res13['symbols']);
        //print_r($selectsymbol);
		



$query2="INSERT INTO username(name,password,date_times)values('".$username1."','".$password1."','".$d2."')";
$queryIN=mysql_query($query2);

?>