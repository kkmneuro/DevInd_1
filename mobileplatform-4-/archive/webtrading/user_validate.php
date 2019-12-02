<?php
session_start();
//print_r($_POST); die;
$username=$_POST['username'];
$password=$_POST['password'];
@$remember=$_POST['remember'];
@$servername=$_POST['servername'];


$_SESSION['username']=$username;
$_SESSION['password']=$password;
$_SESSION['remember']=$remember;
$_SESSION['servername']=$servername;

$number_of_days = 365 ;
$date_of_expiry = time() + 60 * 60 * 24 * $number_of_days ;
if(@$remember==1){
setcookie("username", $username, $date_of_expiry );
setcookie("password", $password, $date_of_expiry );
}

?>
<script type="text/javascript" src="js/jquery-1.9.1.js"></script>   
<script type="text/javascript" src="js/jquery.h5validate.js"></script>

<script>
//var websocket=sessionStorage.getItem("websocketobject");
var senddata2 = {"AccountCredentials":[{"login":2042,"password":"testing1","Server":"12"}],"NoOfRecords":1,"msgtype":61};
	websocket.send(JSON.stringify(senddata2));
	console.log('login2');
	
	
/*$(document).ready(function() {
	websocket = new WebSocket("ws://108.175.9.76:9051/test"); //uri;
	sessionStorage.setItem("websocketobject", websocket);
    websocket.onopen = function () {
        $('#messages').prepend('<div>Connected.</div>');
		console.log('Connected');

	var senddata = {"AccountCredentials":[{"login":<?php echo $username; ?>,"password":"<?php echo $password; ?>","Server":"<?php echo $servername; ?>"}],"NoOfRecords":1,"msgtype":61};
       websocket.send(JSON.stringify(senddata));
       console.log('Send');

    };            
    websocket.onmessage = function (event) {onmsg(event); }
});*/

					
						/*function onmsg(event){
							var str1 = event.data;
							str=JSON.parse(str1);
							console.log(str.LoginAuthentic[0].message);
							var valid = str.LoginAuthentic[0].message;
							if(valid=='OK'){
							window.location.href='webtrading.php';
							}
							else {
							window.location.href='weblogin.php?wrong';
							}	
							
							}*/
							
                        </script> 
                        
