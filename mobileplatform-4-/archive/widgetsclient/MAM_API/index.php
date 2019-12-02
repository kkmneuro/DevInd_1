<!-- $Id: example.html,v 1.4 2006/03/27 02:44:36 pat Exp $ -->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="en">
<head>
<!--<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">-->
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<title>Websocket Client</title>


<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.8.18.custom.min.js"></script>


<link href="http://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>


<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>

<script>
$(function() {
	$( "#datepicker" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker2" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
});
</script>

</head>
<body>
<?php session_start(); ?>
<h2>MAM API </h2>
<table border="1" width="60%" >
<tr height="30px">
<th width="50px" >User Name <input type="text" value="" name="username" id="username"></th>
<th width="50px">Password <input type="password" value="" name="password" id="password"></th>
<th width="20px"><button id="Login">Submit</button></th>
</tr>

<tr height="30px">
<th width="50px" >Feeder </th><th></th><th><button id="Feed">Submit</button></th>
</tr>

<tr height="30px">
<th width="50px" >Trade History </th>

<th>
<table align="center">

<tr><td>Account No </td><td> <input type="text" value="" name="accountno" id="accountno"></td></tr>
<tr><td>To </td><td><input type="text" name="fromtime" id="datepicker"  value="" ></td></tr>
<tr><td>From </td><td><input type="text" name="totime" id="datepicker2"  value="" ></td></tr>

</table>
</th>
<th><button id="Trade_History">Submit</button></th>


</tr>

<tr height="30px">
<th width="50px" >Symbol Details</th><th></th><th> <button id="Symbol">Submit</button></th>
</tr>

<tr height="30px">
<th width="50px" >Get Account Details :</th><th>Account No <input type="text" value="" name="account_no" id="account_no"></th><th><button id="GetAccount">Submit</button></th>
</tr>

<tr height="30px">

<th width="50px" >Opened Trades :</th><th>Account No <input type="text" value="" name="accountno" id="accountno"></th><th><button id="OpenedTrades">Submit</button></th>

</tr>
<tr height="30px">
<th width="50px" >Place New Trade </th>
<th>
<table align="center">

<!--<tr><td>orderby <input type="text" value="" name="orderby" id="orderby"></td></tr>-->
<tr><td>symbol </td><td><input type="text" value="" name="symbol" id="symbol"></td></tr>
<tr><td>volume</td><td> <input type="text" value="" name="volume" id="volume"></td></tr>
<tr><td>price</td><td> <input type="text" value="" name="price" id="price"></td></tr>
<tr><td>sl </td><td><input type="text" value="" name="sl" id="sl"></td></tr>
<tr><td>tp </td><td><input type="text" value="" name="tp" id="tp"></td></tr>
<tr><td>comment</td><td> <input type="text" value="" name="comment" id="comment"></td></tr>
</table>
</th>
<th><button id="PlaceNewTrade">Submit</button></th>
</tr>
	

<tr height="30px">
<th width="50px" >Margin Response :</th><th>Account No <input type="text" value="" name="accountMno" id="accountMno"></th><th><button id="MarginResponse">Submit</button></th>
</tr>


</table>




<script>



$(document).ready(function() {
	var host = "ws://108.175.9.76:9053";
	
	$('#Login').click(function(){
		$('#consolebox').empty();
		var username1 = $('#username').val();
		var useranme = parseInt(username1);
		var password = $('#password').val();
		
		sessionStorage.setItem("Session_login1", useranme);
		sessionStorage.setItem("Session_password1", password);
		
			try{
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 ={"AccountCredentials":[{"login":useranme,"password":password,"Server":"1"}],"NoOfRecords":1,"msgtype":61};
				
				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

			} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
			}
			
	});
	
	$('#Feed').click(function(){
			//alert('Feed');
		$('#consolebox').empty();	
		var host = "ws://108.175.9.76:9063";	
		try{
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 = {"request":1,"msgtype":75};

				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});

	$('#Trade_History').click(function(){
			//alert('Trade_History');
		$('#consolebox').empty();
		
		try{
				var accountno1 = $('#accountno').val();
				var accountno = parseInt(accountno1);
				var todt = $('#datepicker').val();
				var fromdt = $('#datepicker2').val();
				//alert(todt+' 00:00:00');
				
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 = {"login":accountno,"fromdate":todt+' 00:00:00',"tilldate":fromdt+' 23:59:59',"msgtype":72,"Server":"1"};

				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});
	
	$('#Symbol').click(function(){
			//alert('Symbol');
			$('#consolebox').empty();
		try{
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 = {"Server":"1","msgtype":81};

				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});
	
	$('#GetAccount').click(function(){
			//alert('GetAccount');
			$('#consolebox').empty();
		try{
				var account_no1 = $('#account_no').val();
				var account_no = parseInt(account_no1);
		
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 = {"Account":[{"login":account_no,"Server":"1"}],"NoOfRecords":1,"msgtype":63};

				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});
	
	$('#OpenedTrades').click(function(){
			//alert('OpenedTrades');
			$('#consolebox').empty();
		try{
				var accountno1 = $('#accountno').val();
				var accountno = parseInt(accountno1);
		
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 = {"Account":[{"login":accountno,"Server":"1"}],"NoOfRecords":1,"msgtype":63};

				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});

	$('#PlaceNewTrade').click(function(){
			
			$('#consolebox').empty();
			var Session_login2 = sessionStorage.getItem("Session_login1");
			var Session_login = parseInt(Session_login2);
			var Session_password = sessionStorage.getItem("Session_password1");
			
		try{
				var orderby1 = $('#orderby').val();
				var orderby = parseInt(orderby1);
				var symbol = $('#symbol').val();
				var volume1 = $('#volume').val();
				var volume = parseInt(volume1);
				var price1 = $('#price').val();
				var price = parseInt(price1);
				var sl1 = $('#sl').val();
				var sl = parseInt(sl1);
				var tp1 = $('#tp').val();
				var tp = parseInt(tp1);
				var comment = $('#comment').val();
				
		//alert('PlaceNewTrade');
		
				socket = new WebSocket(host);
				socket.onopen = function(){
				
				var msg3 ={"AccountCredentials":[{"login":Session_login,"password":Session_password,"Server":"1"}],"NoOfRecords":1,"msgtype":61};
				
				var msg1 = {"TradeTransInfo":[{"type":"O","reserved":"0","cmd":0,"order":0,"orderby":Session_login,"symbol":symbol,"volume":1,"price":price,"sl":sl,"tp":tp,"ie_deviation":0,"comment":comment,"expiration":0,"crc":0,"Server":"1"}],"NoOfRecords":1,"msgtype":67};
				
				//var msg1 = {"TradeTransInfo":[{"type":"O","reserved":"0","cmd":0,"order":0,"orderby":Session_login,"symbol":"EURUSD","volume":1,"price":1.13169,"sl":0,"tp":0,"ie_deviation":0,"comment":"comments","expiration":0,"crc":0,"Server":"1"}],"NoOfRecords":1,"msgtype":67}; // For Testing 
				
				var msg3=JSON.stringify(msg3);
				socket.send(msg3);
				
				var msg=JSON.stringify(msg1);
				socket.send(msg);
				
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});
	
	$('#MarginResponse').click(function(){
			//alert('GetAccount');
			$('#consolebox').empty();
		try{
				var accountMno1 = $('#accountMno').val();
				var accountMno = parseInt(accountMno1);
		
				socket = new WebSocket(host);
				socket.onopen = function(){
				var msg1 = {"Account":[{"login":accountMno,"Server":"1"}],"NoOfRecords":1,"msgtype":63};

				var msg=JSON.stringify(msg1);
				socket.send(msg);
			}
			socket.onmessage = function(msg){
				var str = "";
				str = msg.data;
				OutputLog(str);
			}

		} catch(exception){
			OutputLog('Error'+exception);
			console.log('Socket Status:Closed'+exception);
			
		}
	});
	
		function OutputLog(msg){
				var content = '<p>' + msg + '</p>';
				$('#consolebox').append(content);
				console.log(msg);
			}	


});


</script>

<div id="consolebox">
</div>




</body>
</html>
