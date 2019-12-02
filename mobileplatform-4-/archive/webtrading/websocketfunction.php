<?php //session_start(); ?>
<script>
$(document).ready(function() {
var websocket;
var hostname = "108.175.9.76"; 
 try{
	websocket = new WebSocket("ws://" + hostname + ":9051/test"); //uri; 
    websocket.onopen = function (e) {
        //console.log('Connected');

	var senddata = {"request":1,"msgtype":83};
       websocket.send(JSON.stringify(senddata));
       //console.log('Send');
     }  
sessionStorage.setItem("websocketobject", websocket);
	        
    websocket.onmessage = function (event) {
						var person = [];
							var str1 = event.data;
							str=JSON.parse(str1);
							console.log('msgtype='+str.msgtype);
							
							switch(str.msgtype)
							{
							case 84:
								for(i=0;i<str.NoOfRecords;i++)
								{
								var ServerName = str.ServerDetails[i].Server;
								//console.log(ServerName);
								$("#Allserver").append('<option value='+ServerName+'>Server : '+ServerName+'</option>');
								
								}
								
							break;
							case 62:
							console.log('msgtype2='+str.msgtype); 
							//alert();
							console.log(str.LoginAuthentic[0].message);
							var valid = str.LoginAuthentic[0].message;
							if(valid=='OK'){
							//window.location.href='webtrading.php';
							MarketWatch();
							}
							else {
							window.location.href='webtrading.php?wrong';
							}
							
							case 68:
								console.log(str+"New Order");	
							break;
							
							case 82:
								console.log('msgtype3='+str.msgtype); 
								for(i=0;i<str.NoOfRecords;i++)
								{
								//console.log(str2.SymbolInfo[i].symbol);  
								var sy2 = str.SymbolInfo[i].symbol;
								//$('#symbol2').append(sy2);
								$("#SymFeed").append('<table id=\"marketcss\" class=\"testuiid\" style=\"margin-top:0px\"><tr height=\"32px\" id=\"numbers\"><td class=\"headSym\" colspan=\"3\"><div id=\"'+sy2+'#Symbol\" class=\"context-menu-one\">'+sy2+'</div></td></tr><tr height=\"22px\"><td class=\"headBid\"><div data-toggle=\"modal\" data-target=\"#myModal\"><div class=\"popupopen\" id=\"'+sy2+'Bid\"></div></div></td><td class=\"headAsk\"><div data-toggle=\"modal\" data-target=\"#myModal\"><div class=\"popupopen\" id=\"'+sy2+'Ask\"></div></div></td><td class=\"headfeed\"><div id=\"'+sy2+'#Mid\"></div></td></tr><tr height=\"30px\"><td class=\"headfeed\"><div id=\"'+sy2+'high\"></div></td><td class=\"headfeed\"><div id=\"'+sy2+'low\" ></div></td><td class=\"headfeed\"><div id=\"'+sy2+'#close\" ></div></td></tr></table>');
								
								}
							break;
							
							}

	 } // End onmessage

 } catch(exception){
				//window.location = 'weblogin.php?useralready=User already logged in from another location';
                console.log('Error'+exception);
  }	


/*switch(websocket.readyState)
 {
	case 0:
	console.log(websocket.readyState+"Not CONNECTE websocket!!");
	break;
	case 1:
	console.log(websocket.readyState+"Still CONNECTED websocket!!");
	break;
}*/

$('#login_send').click(function(){
var username = $('#username').val();
var password = $('#password').val();
var Allserver = $('#Allserver').val();

sessionStorage.setItem("username", username);
var username=sessionStorage.getItem("username");

var username = parseInt(username);
//alert(typeof username)
	var senddata2 = {"AccountCredentials":[{"login":username,"password":password,"Server":Allserver}],"NoOfRecords":1,"msgtype":61};
	websocket.send(JSON.stringify(senddata2));
	console.log('senddata2='+senddata2);
	
	var senddata3 = {"Server":Allserver,"msgtype":81};
	websocket.send(JSON.stringify(senddata3));
	console.log('senddata3='+senddata3);

});						


$('#neworder').click(function(){
alert("NewOreder"); 

/*	var senddata3 = {"TradeTransInfo":[{"type":"O","reserved":"0","cmd":1,"order":0,"orderby":2042,"symbol":"EURUSD","volume":1,"price":1.09388,"sl":0,"tp":0,"ie_deviation":0,"comment":"0.5 % 1.00, ReqId:3","expiration":0,"crc":0,"bPlaced":0,"MT4RespnseMSG":"","isreal":0,"Server":"12","close_time":0,"commission":0,"profit":0,"taxes":0,"magic":0}],"NoOfRecords":1,"msgtype":67};
	var msg3=JSON.stringify(senddata3);
	websocket.send(msg3);
	console.log('Send3');
*/	 	
});						

						

}); // End For document.ready
</script>