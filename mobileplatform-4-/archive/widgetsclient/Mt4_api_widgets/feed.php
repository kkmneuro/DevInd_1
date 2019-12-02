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


<table border="0">

<script>

			
$(document).ready(function() {
connectMAM();	
var socket1;
var sender='Prabhat';

function send(){

				var symbol = $('#symbol').val();
				var msgfeed1 = {
								  requesttype: 0,
							      language: "English",
        						  msgtype: 83
		  		 };

			   var msgfeed=JSON.stringify(msgfeed1);
				socket1.send(msgfeed);
}


$('#consoleboxFeed').append('<tr class=\"trcssstyle\"><td class=\"sym\" >SYMBOL</td><td class=\"bd\"> BID</td><td class=\"as\" >ASK</td></tr>');
function OutputLog(msgfeed){
	
				var JSONObject = JSON.parse(msgfeed);
				//console.log(msgfeed);
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
				
				$('#'+symbol+'_bid').html(bid.toFixed(5));
				$('#'+symbol+'_ask').html(ask.toFixed(5));
				
				} else {
 				
				
				
				var content = '<tr class=\"trcssstyle\"  onclick=\"GetValues('+symbol+','+symbol+'_bid,'+symbol+'_ask)\"><td class=\"sym\" id="'+symbol+'" >' + symbol + '</td><td  class=\"bd\" id="'+symbol+'_bid">' + bid.toFixed(5) + '</td><td class=\"as\" id="'+symbol+'_ask">' + ask.toFixed(5) + '</td></tr>';
				
				
				$('#consoleboxFeed').append(content);
				
				}
				
			};
					


function connectMAM(){
			
			var host = "ws://54.148.43.241:9021";
			
			try{

				socket1 = new WebSocket(host);
				console.log('Socket Status: '+socket1.readyState);
				socket1.onopen = function(){
					send();
					//console.log('Socket Status: '+socket1.readyState+' (open)');
					
				}

				socket1.onmessage = function(msgfeed){
					var str = "";
					str = msgfeed.data;
					OutputLog(str);
					//console.log('='+ str);
					//alert(str);
					var id  = str.substr(0, 1);
					var separator = str.indexOf("|");
					var arg1 = "";
					var arg2 = "";
					

				}

				socket1.onclose = function(){
					OutputLog('Socket Status: '+socket1.readyState+' (Closed)');
					console.log('Socket Status:Closed'+socket1.readyState);
					//window.onload = connectMAM;
				}

			} catch(exception){
				OutputLog('Error'+exception);
				console.log('Socket Status:Closed'+exception);
				//window.onload = connectMAM;
			}

		} 
//window.onload = connectMAM;	

});

</script>

</table>


<div id="consoleboxFeed" style="width:154%;overflow: auto; height: 490px;"></div>


</body>
</html>
