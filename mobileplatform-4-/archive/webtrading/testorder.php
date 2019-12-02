<!DOCTYPE html>  <meta charset="utf-8" />  
<title>WebSocket For Feed</title> 
 <script type="text/javascript" src="js/jquery-1.9.1.js"></script>   
<script type="text/javascript" src="js/jquery.h5validate.js"></script>

<script type="text/javascript">
$(document).ready(function() {
	websocket = new WebSocket("ws://108.175.9.76:9051/test"); //uri;
    websocket.onopen = function () {   $('#messages').prepend('<div>Connected.</div>');
		console.log('Connected');

	var senddata = {"AccountCredentials":[{"login":2042,"password":"testing1","Server":"12"}],"NoOfRecords":1,"msgtype":61};
       websocket.send(JSON.stringify(senddata));
     websocket.send(JSON.stringify(senddata));
	 console.log('Send');

	};
	
    websocket.onmessage = function (event) {onmsg(event); }
	

});
						function onmsg(event){
							var str1 = event.data;
							str=JSON.parse(str1);
							console.log(str);
							$("#output").html(str);
							}



$(document).ready(function() {
//websocket.close();	
	websocket = new WebSocket("ws://108.175.9.76:9051/test"); //uri;
    websocket.onopen = function () {   $('#messages').prepend('<div>Connected.</div>');
		console.log('Connected2');

	var senddata2 = {"TradeTransInfo":[{"type":"O","reserved":"0","cmd":1,"order":0,"orderby":2042,"symbol":"EURUSD","volume":1,"price":1.09388,"sl":0,"tp":0,"ie_deviation":0,"comment":"0.5 % 1.00, ReqId:3","expiration":0,"crc":0,"bPlaced":0,"MT4RespnseMSG":"","isreal":0,"Server":"12","close_time":0,"commission":0,"profit":0,"taxes":0,"magic":0}],"NoOfRecords":1,"msgtype":67};
	websocket.send(JSON.stringify(senddata2));
	console.log('Send2');

	};
	
    websocket.onmessage = function (event) {onmsg2(event); }
	
});

						function onmsg2(event){
							var str1 = event.data;
							str=JSON.parse(str1);
							console.log(str);
							$("#output").html(str);

							}


	
						
                        </script> 
                        

sss <div id="output"></div> 
 

