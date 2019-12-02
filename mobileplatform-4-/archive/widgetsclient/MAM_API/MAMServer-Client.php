<!-- $Id: example.html,v 1.4 2006/03/27 02:44:36 pat Exp $ -->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Websocket Client</title>

<link type="text/css" href="websocket_client.css" rel="stylesheet" />
<link type="text/css" href="css/ui-lightness/jquery-ui-1.8.18.custom.css" rel="stylesheet" />
<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.8.18.custom.min.js"></script>
<script>
$(document).ready(function() {

var socket;
var sender='mithlesh';
$('#connect').click(function(){
			var text = $('#pseudo').val();

				if(text==""){
					alert("Please input a pseudonym !");
					return ;
				}
			 connect();
			});


function symbol_send(){
				//$date=date_create("01-01-2015");
				//echo date_timestamp_get($date);

				var symbol = $('#symbol').val();
				//var msg1 = {"request":1,"msgtype":75};

			var msg2 ={"AccountCredentials":[{"login":9871,"password":"test123","Server":"1"}],"NoOfRecords":1,"msgtype":61};
			   var msg3=JSON.stringify(msg2);
				socket.send(msg3);

			var msg4 ={"Account":[{"login":9871,"Server":"1"}],"NoOfRecords":1,"msgtype":63};
			   var msg5=JSON.stringify(msg4);
				socket.send(msg5);


			var msg1 ={"login":9871,"fromdate":"03/08/2016 00:00:00","tilldate":"03/10/2016 				23:59:59","msgtype":72,"Server":"1"};
			   var msg=JSON.stringify(msg1);
				socket.send(msg);
			//});
};

function OutputLog(msg){
				var content = '<p>' + msg + '</p>';
				$('#consolebox').append(content);
			};

function connect(){
			
			
			//var host = "ws://127.0.0.1:9061";
			var host = "ws://108.175.9.76:9053";
			//var host = "ws://216.75.21.45:28000";
			//var host = "ws://192.168.1.13:9053";
			//var host = "ws://mamfeeder-fxprimus.tradesocio.com:28003";

			//var host = "wss://tcstaging.tradesocio.com:9053/test";
			//var host = "wss://149.5.84.151:28006/test"
			try{

				socket = new WebSocket(host);
				OutputLog('Socket Status: '+socket.readyState);
				socket.onopen = function(){

					OutputLog('Socket Status: '+socket.readyState+' (open)');
					//var msg1 = {content_type:1,client_id:1,screen_name:'test'};

				   //var msg=JSON.stringify(msg1);
					//var pseudoName = $('#pseudo').val();
					//socket.send(msg);

					symbol_send();
				}

				

				socket.onmessage = function(msg){
					var str = "";
					str = msg.data;
					OutputLog(str);
					//alert(str);
					var id  = str.substr(0, 1);
					var separator = str.indexOf("|");
					var arg1 = "";
					var arg2 = "";
					if(separator != -1)
					{
						arg1 = str.substr(1, separator-1);
						arg21 = str.substr(separator+1);
						//	alert(arg21);
						arg2=JSON.parse(arg21);
						//arg2=JSON.parse(arg22);
						alert(arg2);
						var id1=arg2.id;
						var name=arg2.name;
						var sport=arg2.sport;

						alert(id1);
						alert(name);
						alert(sport);

					}
					else
						arg1 = str.substr(1);

					if(id == "0"){
						OutputLog('Server reply : '+arg1);
					}
					if(id == "1"){
						OutputLog('Server echo msg : '+arg1);
					}
					if(id == "2"){
					    OutputLog(arg1 + ' said : ' + arg2.name);
						//OutputLog(arg1 + ' said : ' + ' name ' + arg2.name +'sport'+ arg2.sport);
					}
					if(id == "3"){
						OutputLog(arg1 + ' broadcasted : ' + arg2);
					}
					if(id == "4"){
						OutputLog('Server streamed : '+arg1);
					}

				}

				socket.onclose = function(){
					OutputLog('Socket Status: '+socket.readyState+' (Closed)');
					window.location.reload();
				}

			} catch(exception){
				OutputLog('Error'+exception);

				window.location.reload();
			}

		}
window.onload = connect;

});
</script>

</head>
<body>
Pseudo : <input id="pseudo" type="text" /><button id="connect">Connect</button><br/>
<div class="demo">

      	<div class="getebook">Log In</div>

                   	<input type="text" name="username" id="username" placeholder="Username" value="">

                    <input type="password" name="password" id="password" placeholder="Password" value="">

				   <label>From</label> <input type="text" name="fromtime" id="dt"  value="" >
				     <button id="login_send">Login</button>

				   <input type="text" name="symbol" id="symbol" placeholder="Symbol" value="">

				   <button id="symbol_send">Symbol</button>




<div id="consolebox">


</div>
</div><!-- End demo -->
</body>
</html>
