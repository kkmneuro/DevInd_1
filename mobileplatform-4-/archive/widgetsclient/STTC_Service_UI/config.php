<?php

//$connection = mysqli_connect('localhost', 'root', '', 'newtr');
//@mysql_set_charset('utf8',$connection);

	$host="localhost"; // Host name 
	$username="root"; // Mysql username 
	$password=""; // Mysql password 
	$db_name="test"; // Database name 



	//Connect to server and select database.
	@$link = mysql_connect("$host", "$username", "$password")or die("cannot connect to server"); 
	mysql_select_db("$db_name")or die("cannot select DB");
	mysql_set_charset('utf8',$link);
	
	
	
	
	
?>