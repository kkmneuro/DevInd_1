<?php
$host="localhost"; // Host name 
$username="root"; // Mysql username 
$password=""; // Mysql password 
$db_name="testdb"; // Database name 



//Connect to server and select database.
@$link = mysql_connect("$host", "$username", "$password"); 
mysql_select_db("$db_name");

mysql_set_charset('utf8',$link);
if(!$link) {
		//echo('Not Connection');
    } else{
		//echo('Connection Successful!');
	}
echo "<h2>Welcome to webservice</h2>";

if(isset($_GET['key']) and isset($_GET['auth']))
{
	if($_GET['key']!='' && $_GET['auth']!='')
	{
		//$query = mysql_query("insert into testkeyauth(keyname,authname)values('".$_GET['key']."','".$_GET['auth']."')");
		
		$query1 = mysql_query("select * from testkeyauth where keyname ='".$_GET['key']."' and authname == ''");
		$numrows1 = mysql_num_rows($query1);
		if($numrows1>0){
			$update = mysql_query("update testkeyauth SET authname='".$_GET['auth']."' where keyname='".$_GET['key']."'");
		}
		
		$query = mysql_query("select * from testkeyauth where keyname ='".$_GET['key']."' and authname = '".$_GET['auth']."'");
		$result = mysql_fetch_array($query);
		$numrows = mysql_num_rows($query);
		if($numrows>0){
			echo '<h1>Successful</h1>';
		} else {
			echo '<h1>Error : 404 Page</h1>';
			
		}
	}
	//echo '<h1>Error : 404 Page</h1>';	
}
?>











