<!DOCTYPE html>  <meta charset="utf-8" />  
<title>WebSocket For Feed</title> 
 
<script language="javascript" type="text/javascript"> 
var wsUri = "ws://108.175.9.76:9061/test"; 
var output;  
function init() { output = document.getElementById("output"); testWebSocket(); }  
function testWebSocket() { websocket = new WebSocket(wsUri); websocket.onopen = function(evt) { onOpen(evt) }; websocket.onclose = function(evt) { onClose(evt) }; websocket.onmessage = function(evt) { onMessage(evt) }; websocket.onerror = function(evt) { onError(evt) }; }  

var senddata = {"request":1,"msgtype":75};
function onOpen(evt) { writeToScreen("CONNECTED"); doSend(JSON.stringify(senddata)); }  
function onClose(evt) { writeToScreen("DISCONNECTED"); }  
function onMessage(evt) { writeToScreen('<span style="color: blue;">RESPONSE: ' + evt.data.toString()+'</span>'); 
//websocket.close(); 
}  

function onError(evt) { writeToScreen('<span style="color: red;">ERROR:</span> ' + evt.data); }  
function doSend(message) { writeToScreen("SENT: " + message);  websocket.send(message); }  
function writeToScreen(message) { var pre = document.createElement("p"); pre.style.wordWrap = "break-word"; pre.innerHTML = message; output.appendChild(pre); } 
 window.addEventListener("load", init, false);  
 
 
 </script>  <h2>WebSocket For Feed</h2>  <div id="output"></div>
 
 
 
 
 <!-- For Get Server name-->

<!--<script language="javascript" type="text/javascript"> 
var wsUri = "ws://108.175.9.76:9051/test"; 
var output;  
function init() { output = document.getElementById("output"); testWebSocket(); }  
function testWebSocket() { websocket = new WebSocket(wsUri); websocket.onopen = function(evt) { onOpen(evt) }; websocket.onclose = function(evt) { onClose(evt) }; websocket.onmessage = function(evt) { onMessage(evt) }; websocket.onerror = function(evt) { onError(evt) }; }  

var senddata = {"request":1,"msgtype":83};
function onOpen(evt) { writeToScreen("CONNECTED"); doSend(JSON.stringify(senddata)); }  
function onClose(evt) { writeToScreen("DISCONNECTED"); }  
function onMessage(evt) { writeToScreen('<span style="color: blue;">RESPONSE: ' + evt.data.toString()+'</span>'); 
//websocket.close(); 
}  

function onError(evt) { writeToScreen('<span style="color: red;">ERROR:</span> ' + evt.data); }  
function doSend(message) { writeToScreen("SENT: " + message);  websocket.send(message); }  
function writeToScreen(message) { var pre = document.createElement("p"); pre.style.wordWrap = "break-word"; pre.innerHTML = message; output.appendChild(pre); } 
 window.addEventListener("load", init, false);  
 
 
 </script>  <h2>For Get Server name</h2>  <div id="output"></div>-->
 
 
 
 
 
  <!-- For Get Symbol name with server name-->

<!--<script language="javascript" type="text/javascript"> 
var wsUri = "ws://108.175.9.76:9061/test"; 
var output;  
function init() { output = document.getElementById("output"); testWebSocket(); }  
function testWebSocket() { websocket = new WebSocket(wsUri); websocket.onopen = function(evt) { onOpen(evt) }; websocket.onclose = function(evt) { onClose(evt) }; websocket.onmessage = function(evt) { onMessage(evt) }; websocket.onerror = function(evt) { onError(evt) }; }  

var senddata = {"request":1,"msgtype":75};
function onOpen(evt) { writeToScreen("CONNECTED"); doSend(JSON.stringify(senddata)); }  
function onClose(evt) { writeToScreen("DISCONNECTED"); }  
function onMessage(evt) { writeToScreen('<span style="color: blue;">RESPONSE: ' + evt.data.toString()+'</span>'); 
//websocket.close(); 
}  

function onError(evt) { writeToScreen('<span style="color: red;">ERROR:</span> ' + evt.data); }  
function doSend(message) { writeToScreen("SENT: " + message);  websocket.send(message); }  
function writeToScreen(message) { var pre = document.createElement("p"); pre.style.wordWrap = "break-word"; pre.innerHTML = message; output.appendChild(pre); } 
 window.addEventListener("load", init, false);  
 
 
 </script>  <h2>For Get Symbol name with server name</h2>  <div id="output"></div>-->
 
 
 <!--////// For Get Symbol  ////////-->
 
<!--<script language="javascript" type="text/javascript"> 
var wsUri = "ws://108.175.9.76:9051/test"; 
var output;  
function init() { output = document.getElementById("output"); testWebSocket(); }  
function testWebSocket() { websocket = new WebSocket(wsUri); websocket.onopen = function(evt) { onOpen(evt) }; websocket.onclose = function(evt) { onClose(evt) }; websocket.onmessage = function(evt) { onMessage(evt) }; websocket.onerror = function(evt) { onError(evt) }; }  

var senddata = {"Server":'12',"msgtype":81};
function onOpen(evt) { writeToScreen("CONNECTED"); doSend(JSON.stringify(senddata)); }  
function onClose(evt) { writeToScreen("DISCONNECTED"); }  
function onMessage(evt) { writeToScreen('<span style="color: blue;">RESPONSE: ' + evt.data.toString()+'</span>'); 
//websocket.close(); 
}  

function onError(evt) { writeToScreen('<span style="color: red;">ERROR:</span> ' + evt.data); }  
function doSend(message) { writeToScreen("SENT: " + message);  websocket.send(message); }  
function writeToScreen(message) { var pre = document.createElement("p"); pre.style.wordWrap = "break-word"; pre.innerHTML = message; output.appendChild(pre); } 
 window.addEventListener("load", init, false);  
 
 
 </script>  <h2>For Get Symbol </h2>  <div id="output"></div> -->
 
 
 <!--////// For Get AccountCredentials  ////////-->
 
<!--<script language="javascript" type="text/javascript"> 
var wsUri = "ws://108.175.9.76:9051/test"; 
var output;  
function init() { output = document.getElementById("output"); testWebSocket(); }  
function testWebSocket() { websocket = new WebSocket(wsUri); websocket.onopen = function(evt) { onOpen(evt) }; websocket.onclose = function(evt) { onClose(evt) }; websocket.onmessage = function(evt) { onMessage(evt) }; websocket.onerror = function(evt) { onError(evt) }; }  

var senddata2 = {"AccountCredentials":[{"login":2042,"password":"testing1","Server":"12"}],"NoOfRecords":1,"msgtype":61};
function onOpen(evt) { writeToScreen("CONNECTED"); doSend(JSON.stringify(senddata2)); }  
function onClose(evt) { writeToScreen("DISCONNECTED"); }  
function onMessage(evt) { writeToScreen('<span style="color: blue;">RESPONSE: ' + evt.data.toString()+'</span>'); 
websocket.close(); 
}  

function onError(evt) { writeToScreen('<span style="color: red;">ERROR:</span> ' + evt.data); }  
function doSend(message) { writeToScreen("SENT: " + message);  websocket.send(message); }  
function writeToScreen(message) { var pre = document.createElement("p"); pre.style.wordWrap = "break-word"; pre.innerHTML = message; output.appendChild(pre); } 
 window.addEventListener("load", init, false);  
  </script>  <h2>For Get AccountCredentials </h2>  <div id="output"></div>-->
 
 
<!--<script language="javascript" type="text/javascript"> 
var wsUri = "ws://108.175.9.76:9051/test"; 
var output;  
function init() { output = document.getElementById("output"); testWebSocket(); }  
function testWebSocket() { websocket = new WebSocket(wsUri); websocket.onopen = function(evt) { onOpen(evt) }; websocket.onclose = function(evt) { onClose(evt) }; websocket.onmessage = function(evt) { onMessage(evt) }; websocket.onerror = function(evt) { onError(evt) }; }  

var senddata = {"TradeTransInfo":[{"type":"O","reserved":"0","cmd":1,"order":0,"orderby":2042,"symbol":"EURUSD","volume":1,"price":1.09388,"sl":0,"tp":0,"ie_deviation":0,"comment":"0.5 % 1.00, ReqId:3","expiration":0,"crc":0,"bPlaced":0,"MT4RespnseMSG":"","isreal":0,"Server":"12","close_time":0,"commission":0,"profit":0,"taxes":0,"magic":0}],"NoOfRecords":1,"msgtype":67};

function onOpen(evt) { writeToScreen("CONNECTED"); doSend(JSON.stringify(senddata)); }  
function onClose(evt) { writeToScreen("DISCONNECTED"); }  
function onMessage(evt) { writeToScreen('<span style="color: blue;">RESPONSE: ' + evt.data.toString()+'</span>'); 
//websocket.close(); 
}  

function onError(evt) { writeToScreen('<span style="color: red;">ERROR:</span> ' + evt.data); }  
function doSend(message) { writeToScreen("SENT: " + message);  websocket.send(message); }  
function writeToScreen(message) { var pre = document.createElement("p"); pre.style.wordWrap = "break-word"; pre.innerHTML = message; output.appendChild(pre); } 
 window.addEventListener("load", init, false);  
 
 
</script>  <h2>WebSocket For Send Order</h2>  <div id="output"></div>
 -->