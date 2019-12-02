<?php 
//session_unset();
session_start(); 
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<!-- Template by html.am -->
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<title>MT4 Trader Room</title>
		<link rel="stylesheet" type="text/css" href="fadedtab.css" />
<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.8.18.custom.min.js"></script>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
		
<script src="SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
<link href="SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
<!--<link href="css/modal.css" rel="stylesheet" type="text/css" />-->

		
	</head>
	<body  onload="doLoad()">
		<div id="page">
			<header id="header">
				<div id="header-inner">	
					<div id="logo">
						<h1><a href="#">MT4<span>PUSH API</span></a></h1>
					</div>
					<div id="top-nav">
						<ul>
						<li><a href="index.php">Home</a></li>
						<li><a href="#">Contact</a></li>
						<li><a href="#">FAQ</a></li>
						<li><a href="#">Help</a></li>
						</ul>
					</div>
					<div class="clr"></div>
				</div>
			</header>
			<div class="feature">
				<div class="feature-inner">
				<h1>MT4 PUSH API</h1>
				</div>
			</div>
		
	
			<div id="content">
				<div id="content-inner">
				
					<main id="contentbar">
						
						<!-- Start --->
						
<table width="100%" style="margin-top:0px;    background-color: aliceblue;border: 1px solid black; height:500px;"><tr><td>

<script>

function doLoad()
{
   //alert("Page is loaded");
	sessionStorage.setItem("order_CL", '');
	sessionStorage.setItem("login_CL", '');
	sessionStorage.setItem("symbol_CL", '');
	sessionStorage.setItem("volume_CL", '');
	sessionStorage.setItem("price_CL", '');

	sessionStorage.setItem("symbol_values", '');
	sessionStorage.setItem("bid_values", '');
	sessionStorage.setItem("ask_values", '');
}

function GetValues(symname,bid,ask){
	//alert(symname.innerText+bid.innerText+ask.innerText);
	
    if (confirm("Are You sure Open New Trade!") == true) {
        $("#showhideno").toggle();
		var loginval=sessionStorage.getItem("login_value");
		var symbolval=sessionStorage.getItem("symbol_values");
		var askval=sessionStorage.getItem("ask_values");
		var bidval=sessionStorage.getItem("bid_values");
		//alert(loginval);
		$('#loginid2').val(loginval);
		$('#symbol').val(symname.innerText);
		$('#price').val(bid.innerText);
		$('#volume').val(1);
		
    } else {
        //alert("You pressed Cancel!");
    }
	
		
	sessionStorage.setItem("symbol_values", symname.innerText);
	sessionStorage.setItem("bid_values", bid.innerText);
	sessionStorage.setItem("ask_values", ask.innerText);
			};

			
function Getclval(login,order,symbol,volume,price){
	
	//alert(login+'=='+order+'=='+symbol.innerText+'=='+volume+'=='+price);
	sessionStorage.setItem("login_CL", login);
	sessionStorage.setItem("order_CL", order);
	sessionStorage.setItem("symbol_CL", symbol.innerText);
	sessionStorage.setItem("volume_CL", volume);
	sessionStorage.setItem("price_CL", price);
	
	if (confirm("Are You sure Close Trade!") == true) {
        $("#showhidecl").toggle();
		var login_CLval=sessionStorage.getItem("login_CL");
		var order_CLval=sessionStorage.getItem("order_CL");
		var symbol_CLval=sessionStorage.getItem("symbol_CL");
		var volume_CLval=sessionStorage.getItem("volume_CL");
		var price_CLval=sessionStorage.getItem("price_CL");
		
		//alert(login_CLval+order_CLval+symbol_CLval);
		
				
		$('#orderid').val(order_CLval);
		$('#loginid3').val(login_CLval);
		$('#symbol3').val(symbol_CLval);
		$('#volume3').val(volume_CLval);
		$('#price3').val(price_CLval);
		
		
    } else {
        //alert("You pressed Cancel!");
    }
		
	};		

$(function() {
	$( "#datepicker" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	
	$( "#datepicker1" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker7" ).datepicker({
	changeMonth: true,
	changeYear: true,
	minDate: -0, 
	maxDate:30000
	});


});

$(document).ready(function(){
    $("#NewTradePlace").click(function(){
        $("#showhideno").toggle();
		var loginval=sessionStorage.getItem("login_value");
		var symbolval=sessionStorage.getItem("symbol_values");
		var askval=sessionStorage.getItem("ask_values");
		var bidval=sessionStorage.getItem("bid_values");
		//alert(loginval);
		//$('#loginid2').val(loginval);
		$('#symbol').val(symbolval);
		$('#price').val(bidval);
		$('#volume').val(1);
    });
	
	/*$("#closeTradePlace").click(function(){
        $("#showhidecl").toggle();
	});*/	
		
	$("#closeTradePlace").click(function(){
        $("#showhidecl").toggle();
		var login_CLval=sessionStorage.getItem("login_CL");
		var order_CLval=sessionStorage.getItem("order_CL");
		var symbol_CLval=sessionStorage.getItem("symbol_CL");
		var volume_CLval=sessionStorage.getItem("volume_CL");
		var price_CLval=sessionStorage.getItem("price_CL");
		
		
		$('#orderid').val(order_CLval);
		$('#loginid3').val(login_CLval);
		$('#symbol3').val(symbol_CLval);
		$('#volume3').val(volume_CLval);
		$('#price3').val(price_CLval);
		
    });
});


$(document).ready(function() {
var socket;
var sender='Prabhat';
var loginid;
var frmdate;
var todate;

	$('#connection').click(function()
	{
		loginid = $('#loginid').val();
		frmdate = $('#datepicker').val();
		todate = $('#datepicker1').val();
		
		sessionStorage.setItem("login_value", loginid);
		// After clicked text box is empty //
		$(':text').val('');
		if(loginid==""){
				alert("Please input a loginid !");
				return ;
			}
		
		 connect();
		 
	});

			
	$('#newtrade').click(function()
		{
			loginid = $('#loginid2').val();
			symbol = $('#symbol').val();
			volume = $('#volume').val();
			price = $('#price').val();
			//alert(loginid2);
			
			connect();
			 
		});
	
		function NewOrder() 
		{	
			loginid = $('#loginid2').val();
			symbol = $('#symbol').val();
			volume = $('#volume').val();
			price = $('#price').val();
			//alert(symbol+'ppp');

			// After clicked text box is empty // 
			$('#symbol').val('');
			$('#price').val('');
			$('#volume').val('');	
			
			var msg51 = {"TradeTransInfo":[{"type":"O","reserved":"0","cmd":0,"order":0,"orderby":parseFloat(loginid),"symbol":symbol,"volume":parseFloat(volume),"price":parseFloat(price),"sl":0,"tp":0,"ie_deviation":0,"comment":"test","expiration":0,"crc":0,"Server":"1"}],"NoOfRecords":1,"msgtype":67}
				
				var msg52=JSON.stringify(msg51);
				console.log("send new order");
				console.log(msg51);                
				//socket.send(msg52);
					
		};
		
	$('#closetrade').click(function()
			{
				orderid = $('#orderid').val();
				loginid = $('#loginid3').val();
				symbol = $('#symbol3').val();
				volume = $('#volume3').val();
				price = $('#price3').val();
				connect();
				 
			});
		
		function CloseOrder() {	

			orderid = $('#orderid').val();
			loginid = $('#loginid3').val();
			symbol = $('#symbol3').val();
			volume = $('#volume3').val();
			price = $('#price3').val();
			
			// After clicked text box is empty // 
			$('#orderid').val('');
			
			var msg55 = {"TradeTransInfo":[{"type":"C","reserved":"0","cmd":0,"order":parseFloat(orderid),"orderby":parseFloat(loginid),"symbol":symbol,"volume":parseFloat(volume),"price":parseFloat(price),"sl":0,"tp":0,"ie_deviation":0,"comment":"","expiration":0,"crc":0,"Server":"1"}],"NoOfRecords":1,"RootToMT4Server":0,"msgtype":69}
			
				
				var msg56=JSON.stringify(msg55);
				console.log("Close order");
				console.log(msg55);                
				socket.send(msg56);
		};


	function Send_request(){

		var msg2 ={"AccountCredentials":[{"login":parseInt(loginid),"password":"MAMLTecH2*1SVR","Server":"1"}],"NoOfRecords":1,"msgtype":61};
		var msg3=JSON.stringify(msg2);
		socket.send(msg3);
		//	setTimeout (1000);

		var msg1 ={"login":parseInt(loginid),"fromdate":frmdate+' 00:00:00',"tilldate":todate+' 23:59:59',"msgtype":72,"Server":"1"};
		var msg=JSON.stringify(msg1);
		socket.send(msg);

		//setTimeout (10000);
		//var msg4 ={"Account":[{"login":996022823,"Server":"1"}],"NoOfRecords":1,"msgtype":63};
		var msg4 ={"Account":[{"login":parseInt(loginid),"Server":"1"}],"NoOfRecords":1,"msgtype":63};
		var msg5=JSON.stringify(msg4);
		socket.send(msg5);
		
		NewOrder();
		CloseOrder();
		
		
};

function OutputLog(msg){
				var content = '<p>' + msg + '</p>';
				$('#consolebox').append(content);
				console.log(msg);
				//$('#consolebox').val(content); 
			};



function connect(){
			//var host = "ws://127.0.0.1:9051";
			var host = "ws://185.62.85.23:9051";
			
			$("#consolebox").html("");
			$("#consoleboxAD").html("");
			$("#consoleboxOR").html("");
			$("#consoleboxMargin").html("");
			$("#consoleboxNewOR").html("");
			//$(':text').val('');
			try{

				socket = new WebSocket(host);
				//OutputLog('Socket Status: '+socket.readyState);
				socket.onopen = function(){

					//OutputLog('Socket Status: '+socket.readyState+' (open)');
					
					Send_request();
					
				}
				socket.onmessage = function(msg){
					var str = "";
					var msgtype="";
					str = msg.data;
					//OutputLog(str);
					
					var JSONObject = JSON.parse(str);
					msgtype=JSONObject.msgtype;
					console.log(str);
					switch(msgtype)
                    {
                    case 62:
                        console.log("logon response");
                        console.log(JSONObject);
						//OutputAc(str);	
                        /////
                       
                    break;
					
					case 68:
                        console.log("New Trade Response");
                        console.log(str);
						var repeatcon = [];
						for(i=0;i<JSONObject.NoOfRecords;i++)
                        {
                            var NewOOrder=JSONObject.TradeRecords[i];
                            //console.log(NewOOrder); 
							
							var NewOOHistory = "<tr style='height: 25px;'><td width='104px'>" + NewOOrder['login'] + "</td><td width='104px'>" + NewOOrder['order'] + "</td><td width='104px'>" + NewOOrder['storage'] + "</td><td width='104px'>" + NewOOrder['symbol'] + "</td><td width='140px'>" + NewOOrder['open_price'] + "</td><td width='104px'>" + NewOOrder['digits'] + "</td><td width='104px'>" + NewOOrder['sl'] + "</td><td width='104px'>" + NewOOrder['tp'] + "</td><td width='104px'>" + NewOOrder['volume'] + "</td><td width='104px'>" + NewOOrder['Server'] + "</td><td width='104px'>" + NewOOrder['comment'] + "</td></tr>";
							
						 repeatcon.push(NewOOrder['order']);
							var found = $.inArray(NewOOrder['order'], repeatcon);
								//$('#consoleboxNewOR').append(found+'=');
							if(found == 0)
							{
								$('#consoleboxNewOR').append(NewOOHistory);
							}
							//$('#consoleboxNewOR').append(NewOOHistory);
								
						}
						
						                       
                    break;
					
					case 70:
                        console.log("Close Trade Response");
                        console.log(str);
						                       
                    break;
					
					case 73:
                        console.log("History response");
						
						//var Historytable = "<table><tr style='background-color: cornsilk;'><td width='100px'>LOGIN</td><td width='100px'>ORDER</td><td width='100px'>STORAGE</td><td width='100px'>SYMBOL</td><td width='135px'>OPEN PRICE</td><td width='100px'>CLOSE PRICE </td><td width='100px'>DIGITS</td><td width='100px'>PROFIT</td><td width='100px'>VOLUME</td></tr>";
								
						//$('#consolebox').append(Historytable);
						
                        for(i=0;i<JSONObject.NoOfRecords;i++)
                        {
                            var ALLHistory=JSONObject.TradeRecords[i];
                            console.log(ALLHistory);
							//var myDate = new Date( ALLHistory['open_time'] * 1000);		
							//document.write(myDate.toGMTString());
							var History = "<tr style='height: 25px;'><td width='104px'>" + ALLHistory['login'] + "</td><td width='104px'>" + ALLHistory['order'] + "</td><td width='104px'>" + ALLHistory['storage'] + "</td><td width='104px'>" + ALLHistory['symbol'] + "</td><td width='140px'>" + ALLHistory['open_price'] + "</td><td width='104px'>" + ALLHistory['close_price'] + "</td><td width='104px'>" + ALLHistory['digits'] + "</td><td width='104px'>" + ALLHistory['profit'] + "</td><td width='104px'>" + ALLHistory['volume'] + "</td></tr>";
							
							//OutputLog(History);	
							$('#consolebox').append(History);
							
								
						}	
						//OutputLog('</table>');
						//$('#consolebox').append('</table>');
                        /////
                       
                    break;
					
					case 66:
                        console.log("Open Order response");
						
                        for(i=0;i<JSONObject.NoOfRecords;i++)
                        {
                            var ALLHistoryOO=JSONObject.TradeRecords[i];
                            console.log(ALLHistoryOO); 
							
							var OOHistory = "<tr style='height: 25px;'><td width='104px'>" + ALLHistoryOO['login'] + "</td><td width='104px'>" + ALLHistoryOO['order'] + "</td><td width='104px'>" + ALLHistoryOO['storage'] + "</td><td width='104px'>" + ALLHistoryOO['symbol'] + "</td><td width='140px'>" + ALLHistoryOO['open_price'] + "</td><td width='104px'>" + ALLHistoryOO['digits'] + "</td><td width='104px'>" + ALLHistoryOO['sl'] + "</td><td width='104px'>" + ALLHistoryOO['tp'] + "</td><td width='104px'>" + ALLHistoryOO['volume'] + "</td><td width='104px'>" + ALLHistoryOO['Server'] + "</td><td width='104px'>" + ALLHistoryOO['comment'] + "</td><td><div onclick=\"Getclval(" + ALLHistoryOO['login'] + "," + ALLHistoryOO['order'] + "," + ALLHistoryOO['symbol'] + "," + ALLHistoryOO['volume'] + "," + ALLHistoryOO['open_price'] + ")\">Close Order</div></td></tr>";
							
							//var OOHistory = "<tr style='height: 25px;'><td width='104px'>" + ALLHistoryOO['login'] + "</td><td width='104px'>" + ALLHistoryOO['order'] + "</td><td width='104px'>" + ALLHistoryOO['storage'] + "</td><td width='104px'>" + ALLHistoryOO['symbol'] + "</td><td width='140px'>" + ALLHistoryOO['open_price'] + "</td><td width='104px'>" + ALLHistoryOO['digits'] + "</td><td width='104px'>" + ALLHistoryOO['sl'] + "</td><td width='104px'>" + ALLHistoryOO['tp'] + "</td><td width='104px'>" + ALLHistoryOO['volume'] + "</td><td width='104px'>" + ALLHistoryOO['Server'] + "</td><td width='104px'>" + ALLHistoryOO['comment'] + "</td></tr>";
							
							$('#consoleboxOR').append(OOHistory);
								
						}	
						
                        /////
                       
                    break;
					
					case 64:
                        console.log("Account Details");
						
												
						for(i=0;i<JSONObject.NoOfRecords;i++)
                        {
                            var ALLAD=JSONObject.UserRecords[i];
                            console.log(ALLAD['balance']); 
							
							var History = "<tr style='height: 25px;'><td width='104px'>" + ALLAD['login'] + "</td><td width='104px'>" + ALLAD['balance'] + "</td><td width='104px'>" + ALLAD['credit'] + "</td><td width='104px'>" + ALLAD['currency'] + "</td><td width='140px'>" + ALLAD['groupname'] + "</td><td width='104px'>" + ALLAD['leverage'] + "</td><td width='104px'>" + ALLAD['name'] + "</td><td width='104px'>" + ALLAD['Server'] + "</td><td width='104px'>" + ALLAD['status'] + "</td><td width='104px'>" + ALLAD['taxes'] + "</td><td width='104px'>" + ALLAD['enable'] + "</td></tr>";
							
							$('#consoleboxAD').append(History);
						}
						//$('#consoleboxAD').append('</table>');
                        
                    break;
					
					case 76:
                        console.log("Margin");
						
						for(i=0;i<JSONObject.NoOfRecords;i++)
                        {
                            var ALLMargin=JSONObject.Margin[i];
                            console.log('Margin='+ALLMargin['balance']); 
							
							var MarginHistory = "<tr style='height: 25px;'><td width='104px'>" + ALLMargin['login'] + "</td><td width='104px'>" + ALLMargin['balance'] + "</td><td width='104px'>" + ALLMargin['equity'].toFixed(2) + "</td><td width='104px'>" + ALLMargin['margin'].toFixed(2) + "</td><td width='140px'>" + ALLMargin['group'] + "</td><td width='104px'>" + ALLMargin['leverage'] + "</td><td width='104px'>" + ALLMargin['margin_free'].toFixed(2) + "</td><td width='104px'>" + ALLMargin['margin_level'].toFixed(2) + "</td><td width='104px'>" + ALLMargin['margin_type'].toFixed(2) + "</td><td width='104px'>" + ALLMargin['volume'] + "</td><td width='104px'>" + ALLMargin['level_type'].toFixed(2) + "</td></tr>";
							
							$('#consoleboxMargin').append(MarginHistory);
						}
						
                    break;
					
					
					}
				}

				socket.onclose = function(){
					OutputLog('Socket Status: '+socket.readyState+' (Closed)');
					//window.location.reload();
				}

			} catch(exception){
				OutputLog('Error'+exception);
				//window.location.reload();
			}

		}
//window.onload = connect;

});
</script>

<table border='0' width="60%">
<tr><td width="25%"><h4>For History :</h4></td><td>Please select between 3 days only</td></tr>
<tr><th>From Date :</th><td><input type="text" name="fromtime" id="datepicker"  value="" ></td></tr>
<tr><th>To Date :</th><td><input type="text" name="totime"  id="datepicker1" value="" ></td></tr>
<tr><th>Login ID :</th><td><input type="text" name="loginid" id="loginid" placeholder="login id" value=""> Example Login : 11841</td></tr>

<tr><td></td><td><button id="connection">Connect</button></td></tr>
</table>

<button id="NewTradePlace">Place New Trade :</button>

<table border='0' width="60%" id="showhideno" style="display:none">

<tr><th>Login id:</th><td><input type="number" name="loginid2" id="loginid2"  value="" > Example Login : 11841</td></tr>
<tr><th>Symbol:</th><td><input type="text" name="symbol"  id="symbol" value="" > Example Login : EURUSD</td></tr>
<tr><th>volume :</th><td><input type="text" name="volume" id="volume"  value="1"> Example volume : 1</td></tr>
<tr><th>Price :</th><td><input type="text" name="price" id="price" placeholder="price" value=""> Example price : 1.13160</td></tr>

<tr><td></td><td><input type="button" id="newtrade"  value="Place Order" ></td></tr>
<!--<tr><td></td><td><input type="button" id="newtrade"  value="Place Order" onclick="NewOrder()" ></td></tr>-->
</table>


<br><br>

<button  id="closeTradePlace" >Close Trade :</button>
<table border='0' width="60%" id="showhidecl" style="display:none">
<tr><th>Order id:</th><td><input type="number" name="orderid" id="orderid"  value="" > Example Order id : 2248064</td></tr>
<tr><th>Login id:</th><td><input type="number" name="loginid3" id="loginid3"  value="" > Example Login : 11841</td></tr>
<tr><th>Symbol:</th><td><input type="text" name="symbol3"  id="symbol3" value="" > Example Login : EURUSD</td></tr>
<tr><th>volume :</th><td><input type="text" name="volume3" id="volume3"  value=""> Example volume : 1</td></tr>
<tr><th>Price :</th><td><input type="text" name="price3" id="price3"  value=""> Example price : 1.13160</td></tr>
<tr><td></td><td><input type="button" id="closetrade"  value="Close Order" ></td></tr>
</table>


</div>

</td></tr></table>
<!-- End --->
					</main>
					
					<nav id="sidebar">
						<div class="widget">
							<?php 
							include("feed.php"); 
							//include("widgets.php");
							?>
							
						</div>
					</nav>
					
					<div class="clr"></div>
				</div>
			</div>
		
			<div id="footerblurb">
				<div id="footerblurb-inner">
		
	<div id="TabbedPanels1" class="TabbedPanels">
		  <ul class="TabbedPanelsTabGroup">
			<li class="TabbedPanelsTab" tabindex="0">Account Details</li>
			<li class="TabbedPanelsTab" tabindex="0">Open Order</li>
			<li class="TabbedPanelsTab" tabindex="0">New Placed Order</li>
			<!--<li class="TabbedPanelsTab" tabindex="0">Account Info</li>-->
			<li class="TabbedPanelsTab" tabindex="0">Margin</li>
			<li class="TabbedPanelsTab" tabindex="0">History</li>
			
		  </ul>
		  
		  
		  <div class="TabbedPanelsContentGroup">
				
				<div class="TabbedPanelsContent">
				
					<table><tr style='background-color: cornsilk;height: 25px;'><td width='100px'>LOGIN</td><td width='100px'>BALANCE</td><td width='100px'>CREADIT</td><td width='100px'>CURRENCY</td><td width='135px'>GROUP NAME</td><td width='100px'>LEVERAGE</td><td width='100px'>NAME</td><td width='100px'>SERVER</td><td width='100px'>STATUS</td><td width='100px'>TAXES</td><td width='100px'>ENABLE</td></tr>
					</table>
					<div id="consoleboxAD"></div>
				</div>
				
				<div class="TabbedPanelsContent" >
					<table ><tr style='background-color: cornsilk;height: 25px;'><td width='100px'>LOGIN</td><td width='100px'>ORDER</td><td width='100px'>STORAGE</td><td width='100px'>SYMBOL</td><td width='135px'>OPEN PRICE</td><td width='100px'>DIGITS</td><td width='100px'>SL</td><td width='100px'>TP</td><td width='100px'>VOLUME</td><td width='100px'>SERVER</td><td width='100px'>COMMENTS</td><td width='100px'>ACTION</td></tr>
					</table>
					<div id="consoleboxOR"></div>
				</div>
				
				<div class="TabbedPanelsContent" >
					<table ><tr style='background-color: cornsilk;height: 25px;'><td width='100px'>LOGIN</td><td width='100px'>ORDER</td><td width='100px'>STORAGE</td><td width='100px'>SYMBOL</td><td width='135px'>OPEN PRICE</td><td width='100px'>DIGITS</td><td width='100px'>SL</td><td width='100px'>TP</td><td width='100px'>VOLUME</td><td width='100px'>SERVER</td><td width='100px'>COMMENTS</td></tr>
					</table>
					<div id="consoleboxNewOR"></div>
				</div>
				
				<div class="TabbedPanelsContent">
				<table><tr style='background-color: cornsilk;height: 25px;'><td width='100px'>LOGIN</td><td width='100px'>BALANCE</td><td width='100px'>EQUITY</td><td width='100px'>MARGIN</td><td width='135px'>GROUP NAME</td><td width='100px'>LEVERAGE</td><td width='100px'>MARGIN FREE</td><td width='100px'>MARGIN LEVEL</td><td width='100px'>MARGIN TYPE</td><td width='100px'>VOLUME</td><td width='100px'>LEVEL TYPE</td></tr>
				</table>
					<div id="consoleboxMargin"></div>
				</div>
				
				<div class="TabbedPanelsContent">
					<!--<textarea  rows="100" cols="150" name="consolebox"  id="consolebox" ></textarea>-->
					<table><tr style='background-color: cornsilk;height: 25px;'><td width='100px'>LOGIN</td><td width='100px'>ORDER</td><td width='100px'>STORAGE</td><td width='100px'>SYMBOL</td><td width='135px'>OPEN PRICE</td><td width='100px'>CLOSE PRICE </td><td width='100px'>DIGITS</td><td width='100px'>PROFIT</td><td width='100px'>VOLUME</td></tr>
					</table>
					<div id="consolebox"></div>
				</div>
				
		  </div>
	</div>

					
					<div class="clr"></div>
				</div>
			</div>

<script type="text/javascript">
	var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
</script>
			
			<footer id="footer">
				<div id="footer-inner">
					<p>&copy; Copyright <a href="#">MT4 MAM</a> &#124; <a href="#">Terms of Use</a> &#124; <a href="#">Privacy Policy</a></p>
					<div class="clr"></div>
				</div>
			</footer>
		</div>
	</body>
</html>