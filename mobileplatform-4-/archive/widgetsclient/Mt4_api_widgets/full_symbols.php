<!-- $Id: example.html,v 1.4 2006/03/27 02:44:36 pat Exp $ -->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Websocket Client</title>


<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.8.18.custom.min.js"></script>
<link href="css/style.css" rel="stylesheet" type="text/css">

</head>
<body>


<table border="0" style="background-color:#FFF; color:#BFBBBB; width:100%;font-size: 13px;border-collapse: collapse; margin-top: -37px;">

<tr height="30px">
<th></th>


<th style="border: #dae0e8 1px solid;display: none;">
<div id="traidingClock">
<div class="difTime">
            <div class="difTimeLeft">
                <div class="diftitle">Broker</div>
                <div id="brokerClock" data-bind="text: brokerClock"><div id="clockshowGTC"></div></div>
            </div>
            <div class="difTimeRight">
                <div class="diftitle">My time</div>
                <div id="localClock" data-bind="text: localClock"><div id="clockshow"></div></div>
            </div>
            <div class="clockIcon"></div>
</div>

<ul id="openClose">

            <li class="trClosed">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">Tokyo</span><br>
                <div id="clockTokyo"></div><div id="clockTokyo2"></div>
            </li>
            <li class="trClosed">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">Sydney</span><br>
                <div id="clockSydney"></div><div id="clockSydney2"></div>
            </li>
            <li class="trClosed">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">London<br></span>
                <div id="clocklondon"></div><div id="clocklondon2"></div>
            </li>
            <li class="trClosedB" style="border-bottom: #FFF 1px solid;">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">NY</span><br>
                <div id="clockNY"></div><div id="clockNY2"></div>
            </li>

</ul>
</div>                
    
</th>

</tr>
</table>

<table border="0" id="widgetQoutes">
<!--<tr height="30px">
<th class="headSym">Symbol</th>
<th></th>
<th class="headBd">Bid</th>
<th class="headAsk">Ask</th>
</tr>-->

<tr class="trcssstyle"><td class="sym">SYMBOL</td><td class="bd"> BID</td><td class="as" >ASK</td></tr>

<script>
$(document).ready(function() {
var socket;
var sender='Prabhat';
$('#connect').click(function(){
			var text = $('#pseudo').val();

				if(text==""){
					alert("Please input a pseudonym !");
					return ;
				}
			 connect();
			});

	$("td.sym1").click(function(){
		alert('sym');
	});

function send(){

				var symbol = $('#symbol').val();
				var msg1 = {
								  requesttype: 0,
							      language: "English",
        						  msgtype: 83
		  		 };

			   var msg=JSON.stringify(msg1);
				socket.send(msg);
}


function OutputLog(msg){
	
				var JSONObject = JSON.parse(msg);
				//console.log(msg);
				console.log(JSONObject);
				
				var ask = JSONObject.ask;
				var bid = JSONObject.bid;
				var symbol = JSONObject.symbol;
				
				//  for Update //
			if(document.getElementById(symbol)){

				///////// test color change//////
				
				/// 1st ///
				var b1 = document.getElementById(symbol+'_bid').innerHTML;
                var b2 = bid;
                if (b1 > b2)
                {
					document.getElementById(symbol+'_bid').style.color = '#00FF00';
				}
				else if (b1 < b2)
                {
                    document.getElementById(symbol+'_bid').style.color = '#FF0000';
				}
                else if (b1 == b2)
                {
                	document.getElementById(symbol+'_bid').style.color = '#FFFFFF';
					document.getElementById(symbol+'_bid').style.background = '#19304e';
                }
				/// 2nd ///
				var a1 = document.getElementById(symbol+'_ask').innerHTML;
                var a2 = ask;
                if (a1 > a2)
                {
					document.getElementById(symbol+'_ask').style.color = '#00FF00';
				}
				else if (a1 < a2)
                {
                    document.getElementById(symbol+'_ask').style.color = '#FF0000';
				}
                else if (a1 == a2)
                {
                	document.getElementById(symbol+'_ask').style.color = '#FFFFFF';
					document.getElementById(symbol+'_ask').style.background = '#0c203a';
                }
				/// 3rd ///
				

				////////
				
				$('#'+symbol+'_bid').html(bid);
				$('#'+symbol+'_ask').html(ask);
				
				} else {
 				
				var content = '<tr class=\"trcssstyle\"><td class=\"sym\" id="'+symbol+'" >' + symbol + '</td><td  class=\"bd\" id="'+symbol+'_bid">' + bid.toFixed(5) + '</td><td class=\"as\" id="'+symbol+'_ask">' + ask.toFixed(5) + '</td></tr>';
				
				
				$('#consolebox').append(content);
				
				}
				
			};
					


function connect(){
			
			//var host = "ws://192.168.1.84:9051/test";
			//var host = "ws://192.168.1.7:9021";
			var host = "ws://54.148.43.241:9021";

			try{

				socket = new WebSocket(host);
				//OutputLog('Socket Status: '+socket.readyState);
				socket.onopen = function(){
					send();
					//OutputLog('Socket Status: '+socket.readyState+' (open)');
					
				}

				socket.onmessage = function(msg){
					var str = "";
					str = msg.data;
					OutputLog(str);
					//console.log('='+ str);
					//alert(str);
					var id  = str.substr(0, 1);
					var separator = str.indexOf("|");
					var arg1 = "";
					var arg2 = "";
					

				}

				socket.onclose = function(){
					OutputLog('Socket Status: '+socket.readyState+' (Closed)');
					console.log('Socket Status:Closed'+socket.readyState);
					window.onload = connect;
				}

			} catch(exception){
				OutputLog('Error'+exception);
				console.log('Socket Status:Closed'+exception);
				window.onload = connect;
			}

		} 
window.onload = connect;	

});

</script>

</table>

<div id="consolebox" style="width:100%;"></div>


</body>
</html>
