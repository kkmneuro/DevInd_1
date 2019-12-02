$(document).ready(function() {
/*var username=sessionStorage.getItem("UserName", UserName);
if(username)
{
$("#login").css({ display: "none" });
$("#acinfo").css({ display: "block" });
//connect();
}*/
//Message Type
var FirstTime="FALSE";
const LOGON_REQUEST=1;
const LOGON_RESPONSE=2;
const LOGOUT_REQUEST=3;
const NEW_ORDER_REQUEST=4;
const ORDER_CANCEL_REQUEST=5;
const ORDER_REPLACE_REQUEST=6;
const ORDER_STATUS_REQUEST=7;
const ACCOUNT_REQUEST=8;
const POSITION_REQUEST=9;
const ORDER_HISTORY_REQUEST= 10;
const PARTICIPANT_LIST_REQUEST=11;
const EXECUTION_REPORT_RESPONSE=12;
const ORDER_STATUS_RESPONSE=13;
const REJECT_MESSAGE_RESPONSE=14;
const ORDER_CANCEL_REJECT_RESPONSE=15;
const ACCOUNT_RESPONSE=16;
const PARTICIPANT_LIST_RESPONSE=17;
const POSITION_RESPONSE=18;
const BUSINESS_LEVEL_REJECT=19;
const QUOTE_SUBSCRIPTION_REQUEST=20;
const QUOTES_UNSUBSCRIPTION_REQUEST=21;
const QUOTE_SNAP_SHOT_RESPONSE=22;
const QUOTES_STREAM=23;
const NEWS_SUBSCRIPTION=24;
const NEWS_STREAM=25;
const TOP_GAINERS_LOSERS=26;
const ORDER_HISTORY_RESPONSE=27;
const QUOTE__REQUEST=28;
const QUOTE__SNAPSHOT_REQUEST=29;
const QUOTE__DOM_REQUEST=30;
const NEWS__REQUEST=31;
const LOGOUT_RESPONSE=32;
const TRADE_HISTORY_REQUEST=33;
const TRADE_HISTORY_RESPONSE=34;
const HEARTBEAT=35;
const BUFFER=36;
const MATCHED_ORDER_REQUEST=37;
const MATCHED_ORDER_RESPONSE=38;
const ORDER_BOOK_REQUEST=39;
const STOP_ORDER_REQUEST=40;
const ORDER_BOOK_RESPONSE=41;
const STOP_ORDER_RESPONSE=42;
const MATCHING_ORDER_REQUEST=43;
const TRADEREPORT_REQUEST=44;
const CHANGE_PASSWORD=45;
const CHANGE_PASSWORD_RESPONSE =46;
const ALERT_REQUEST=47;
const ALERT_STREAM =48;
const OCO_ORDER_REQUEST =49;
const LINKED_ORDER_REQUEST =50;
const MAIL_DELIVERY=51;
const ACCOUNT_UPDATE_REQUEST=52;
const ACCOUNT_UPDATE_RESPONSE=53
const TRADE_MGMT_REQUEST=54;
const RELOAD_CONFIG =55;
const MODIFY_ACCOUNT_OF_TRADE=56;

// Order Type
const ORDER_TYPE_MARKET_ORDER='1';
const ORDER_TYPE_LIMIT_ORDER='2';
const ORDER_TYPE_STOP_ORDER='3';
const ORDER_TYPE_STOP_LIMIT_ORDER='4';
// Side
const SIDE_BUY='1'; 
const SIDE_SELL='2';
//Time in Force
const TIF_DAY='0';
const TIF_GOOD_TILL_CANCEL='1';
const TIF_FOK='3';
const TIF_GOOD_TILL_DATE='6';

//Security Type or Product Type
const SECURITY_TYPE_FUT='1';
const SECURITY_TYPE_OPT=2;
const SECURITY_TYPE_EQ=3;
const SECURITY_TYPE_SP=4;
const SECURITY_TYPE_BON=5;
const SECURITY_TYPE_FX=0;
const SECURITY_TYPE_PH=6;
const SECURITY_TYPE_AU=7;
const SECURITY_TYPE_IND=8;
const SECURITY_TYPE_CFD=9;

//Order Status Type
const ORDER_STATUS_NEW='0'; 
const ORDER_STATUS_PARTIALLY_FILLED='1';
const ORDER_STATUS_FILLED='2';
const ORDER_STATUS_CANCEL='4';
const ORDER_STATUS_REPLACED='5';
const ORDER_STATUS_PENDING_CANCEL='6';
const ORDER_STATUS_REJECTED='8';
const ORDER_STATUS_PENDINGNEW='A';
const ORDER_STATUS_EXPIRED='C';
const ORDER_STATUS_PENDINGREPLACE='E';
const ORDER_STATUS_UNDEFINED='U';
const ORDER_STATUS_ORDER_NOT_FOUND='Y';

						   
var socket;
//var username='mithlesh';
//connect();
$('#connect').click(function(){
			var text = $('#pseudo').val();
				if(text==""){
					alert("Please input a pseudonym !");
					return ;	
				}
			// connect();
			});


$('#login_send').click(function(){

				var username = $('#username').val();
				var password = $('#password').val();		
				
				if(username=="" || password == ""){
				alert("Please enter username and Password !");
				return ;	
				}				
				 connect();
				// Login(username, pwd, serverIp, hostIp, port, BrokerGroupId);
				/* var msg1 = {
				    msgtype:LOGON_REQUEST,
					UserName: username,
					Password: password,
					Version:1.15,
					SenderID:'2'				 
				};		
				
				var msg=JSON.stringify(msg1);  */
				
				//socket.send('2' + sender + '|' + msg);
				//socket.send(msg);
				});


$('#neworder').click(function(){				
				  
				// $("#orderform").css({ display: "none" });
                var BidPrice = parseFloat(sessionStorage.getItem("bidpr"));				
				var AskPrice=parseFloat(sessionStorage.getItem("askpr"));
				var AcontID=parseInt(sessionStorage.getItem("AcctID"));
				//console.log(BidPrice);
				//console.log(AskPrice);
				var StopPx=0;
				var Account =AcontID;
				var OrderQty1 = $('#quantity').val();
				var ContractSize = $('#contractsize').val();
				var OrderQty=parseFloat(OrderQty1*ContractSize);
				var ClOrdId ='701';
				//var ProductType =$('#product').val();//// get from contract

				var Product ='GOLD';//// get from contract
				var Contract =$('#symble').val();// get from contract
				var Gateway ='ECX';// get from contract
				var Side1 =$('#side').val();//user
				var side=Side1;
				var Price1 = $('#price').val();
				var Price =parseFloat(Price1);
				var Digit1 = $('#digit').val();
				var Digit =parseInt(Digit1);
				var StopLabelLimit1 = $('#stoplbllimit').val();
                var StopLabelLimit=parseFloat(StopLabelLimit1);
				var trigerPrice1 = $('#trigger').val();
                var trigerPrice=parseFloat(trigerPrice1);
				var OrderType =$('#market').val(); //user input
				if(OrderType=="MARKET")
				{
				OrderType=ORDER_TYPE_MARKET_ORDER;	
				}else if(OrderType=="LIMIT")
				{
				  if(side=="1"){
					if(Price >(AskPrice-StopLabelLimit)){
					alert("Wrong buy Price");
                    return;					
					}						
					}else{
					if(Price <(BidPrice+StopLabelLimit)){
						//console.log(BidPrice+StopLabelLimit);
						//console.log(BidPrice);
					alert("Wrong Sell Price");
                    return;				
					}}
				OrderType=ORDER_TYPE_LIMIT_ORDER;	
				}else if(OrderType=="STOP")
				{
					if(side=="1"){
					if(Price <(AskPrice+StopLabelLimit)){
					alert("Wrong buy stop Limit");
                    return;					
					}						
					}else{
					if(Price >(BidPrice-StopLabelLimit)){						
					alert("Wrong Sell Price");
                    return;				
					}}
				OrderType=ORDER_TYPE_STOP_ORDER;
			    StopPx =trigerPrice;
				Price=0;
				}else
				{
					if(side=="1"){
					if(Price >(AskPrice+StopLabelLimit+1)){
					alert("Wrong buy Price");
                    return;					
					}						
					}else{
					if(Price <(BidPrice-StopLabelLimit-1)){
						//console.log(BidPrice+StopLabelLimit);
						//console.log(BidPrice);
					alert("Wrong Sell Price");
                    return;				
					}}
				OrderType=ORDER_TYPE_STOP_LIMIT_ORDER;	
				StopPx =trigerPrice;
				}
				
							
				
				//var TimeInForce = 0; //time
				//blank
				var ExpireDate =0;  //0
				var TransactTime =0; //time
				var OrderID =701;//

				var origClOrdId ='';//blank
				var PositionEffect = 0;//0
				var LnkdOrdId ='';//blank
				var MinOrDisclosedQty = 0;//0
				var Slipage =0;//0
				var OCOOrder ='false';//false
				
				
				var msg1 = {
				msgtype:NEW_ORDER_REQUEST,
				Account:Account,
				OrderQty:OrderQty,
				ClOrdId:ClOrdId,
				ProductType:SECURITY_TYPE_FUT,
				Product:Product,
				Contract:Contract,
				Gateway:Gateway,
				OrderType:OrderType,
				Price:Price,
				Side:side,
				TimeInForce:TIF_DAY,
				StopPx:StopPx,
				ExpireDate:ExpireDate,
				TransactTime:TransactTime,
				OrderID:OrderID,
				origClOrdId:origClOrdId,
				PositionEffect:"O",
				LnkdOrdId:LnkdOrdId
				
				//LnkdOrdId:LnkdOrdId,
				//MinOrDisclosedQty:MinOrDisclosedQty,
				//Slipage:Slipage,
				//OCOOrder:OCOOrder									
				};
								
				var msg=JSON.stringify(msg1);
                console.log("send new order");
                console.log(msg1);				
				socket.send(msg);				
				});
				


$('#modifyOrder').click(function(){				
				  
				// $("#orderform").css({ display: "none" });
                var BidPrice = parseFloat(sessionStorage.getItem("bidpr"));				
				var AskPrice=parseFloat(sessionStorage.getItem("askpr"));
				//console.log(BidPrice);
				//console.log(AskPrice);
				var StopPx=0;
				var Account =269;
				var OrderQty1 = $('#quantity').val();
				var ContractSize = $('#contractsize').val();
				var OrderQty=parseFloat(OrderQty1*ContractSize);
				var ClOrdId ='701';
				//var ProductType =$('#product').val();//// get from contract

				var Product ='GOLD';//// get from contract
				var Contract =$('#symble').val();// get from contract
				var Gateway ='ECX';// get from contract
				var Side1 =$('#side').val();//user
				var side=Side1;
				var Price1 = $('#price').val();
				var Price =parseFloat(Price1);
				var Digit1 = $('#digit').val();
				var Digit =parseInt(Digit1);
				var StopLabelLimit1 = $('#stoplbllimit').val();
                var StopLabelLimit=parseFloat(StopLabelLimit1);
				var trigerPrice1 = $('#trigger').val();
                var trigerPrice=parseFloat(trigerPrice1);
				var OrderType =$('#market').val(); //user input
				if(OrderType=="MARKET")
				{
				OrderType=ORDER_TYPE_MARKET_ORDER;	
				}else if(OrderType=="LIMIT")
				{
				  if(side=="1"){
					if(Price >(AskPrice-StopLabelLimit)){
					alert("Wrong buy Price");
                    return;					
					}						
					}else{
					if(Price <(BidPrice+StopLabelLimit)){
						//console.log(BidPrice+StopLabelLimit);
						//console.log(BidPrice);
					alert("Wrong Sell Price");
                    return;				
					}}
				OrderType=ORDER_TYPE_LIMIT_ORDER;	
				}else if(OrderType=="STOP")
				{
					if(side=="1"){
					if(Price <(AskPrice+StopLabelLimit)){
					alert("Wrong buy stop Limit");
                    return;					
					}						
					}else{
					if(Price >(BidPrice-StopLabelLimit)){						
					alert("Wrong Sell Price");
                    return;				
					}}
				OrderType=ORDER_TYPE_STOP_ORDER;
			    StopPx =trigerPrice;
				Price=0;
				}else
				{
					if(side=="1"){
					if(Price >(AskPrice+StopLabelLimit+1)){
					alert("Wrong buy Price");
                    return;					
					}						
					}else{
					if(Price <(BidPrice-StopLabelLimit-1)){
						//console.log(BidPrice+StopLabelLimit);
						//console.log(BidPrice);
					alert("Wrong Sell Price");
                    return;				
					}}
				OrderType=ORDER_TYPE_STOP_LIMIT_ORDER;	
				StopPx =trigerPrice;
				}
				
							
				
				//var TimeInForce = 0; //time
				//blank
				var ExpireDate =0;  //0
				var TransactTime =0; //time
				var OrderID =701;//

				var origClOrdId ='';//blank
				var PositionEffect = 0;//0
				var LnkdOrdId ='';//blank
				var MinOrDisclosedQty = 0;//0
				var Slipage =0;//0
				var OCOOrder ='false';//false
				
				
				var msg1 = {
				msgtype:ORDER_REPLACE_REQUEST,
				Account:Account,
				OrderQty:OrderQty,
				ClOrdId:ClOrdId,
				ProductType:SECURITY_TYPE_FUT,
				Product:Product,
				Contract:Contract,
				Gateway:Gateway,
				OrderType:OrderType,
				Price:Price,
				Side:side,
				TimeInForce:TIF_DAY,
				StopPx:StopPx,
				ExpireDate:ExpireDate,
				TransactTime:TransactTime,
				OrderID:OrderID,
				origClOrdId:origClOrdId,
				PositionEffect:"O",
				OldAccount:Account,
				OldOrderQty:OrderQty,
				OldClOrdId:ClOrdId,
				OldProductType:SECURITY_TYPE_FUT,
				OldProduct:Product,
				OldContract:Contract,
				OldGateway:Gateway,
				OldOrderType:OrderType,
				OldPrice:Price,
				OldSide:side,
				OldTimeInForce:TIF_DAY,
				OldStopPx:StopPx,				
				OldOrderID:OrderID,
				OldorigClOrdId:origClOrdId,
				OldPositionEffect:"O"

				
				
				//LnkdOrdId:LnkdOrdId,
				//MinOrDisclosedQty:MinOrDisclosedQty,
				//Slipage:Slipage,
				//OCOOrder:OCOOrder									
				};
								
				var msg=JSON.stringify(msg1);
                console.log("send new order");
                console.log(msg1);				
				socket.send(msg);				
				});



					//  Cancel Order Request

$('#replaceOrder').click(function(){									 
		alert("Cancel Order");						 
		var $orow = $(this).closest("tr");        // Finds the closest row <tr> 
		var $tdAccount = $orow.find("td:nth-child(1)");
		var $tdOrderQty = $orow.find("td:nth-child(2)"); // Finds the 2nd <td> element
		var $tdClOrdId = $orow.find("td:nth-child(3)");
		var $tdProductType = $orow.find("td:nth-child(4)");
		var $tdproduct = $orow.find("td:nth-child(5)");
		//var $tdProduct = $orow.find("td:nth-child(6)");
		var $tdContract = $orow.find("td:nth-child(6)");
		var $tdGateway = $orow.find("td:nth-child(7)"); 
		var $tdOrderType = $orow.find("td:nth-child(8)");
		var $tdPrice = $orow.find("td:nth-child(9)");
		var $tdSide = $orow.find("td:nth-child(10)");
		var $tdTimeInForce = $orow.find("td:nth-child(11)");
		var $tdStopPx = $orow.find("td:nth-child(12)");
		var $tdOrderID = $orow.find("td:nth-child(13)");
		var $tdorigClOrdId = $orow.find("td:nth-child(14)");
		var $PositionEffect = $orow.find("td:nth-child(15)");

   
		$.each($tdAccount, function() {                // Visits every single <td> element
		var tdAccount=$(this).text();         // Prints out the text within the <td>
		//sessionStorage.setItem("contsize", tdcontsize);
		});	
		$.each($tdOrderQty, function() { var tdOrderQty=$(this).text(); });
		$.each($tdClOrdId, function() { var tdClOrdId=$(this).text(); });
		$.each($tdProductType, function() { var tdProductType=$(this).text();});
		$.each($tdproduct, function() { var tdproduct=$(this).text(); });	
		$.each($tdContract, function() { var tdContract=$(this).text(); });
		$.each($tdGateway, function() { var tdGateway=$(this).text();});
		$.each($tdOrderType, function() { var tdOrderType=$(this).text();});
		$.each($tdPrice, function() { var tdPrice=$(this).text(); });	
		$.each($tdSide, function() { var tdSide=$(this).text(); });
		$.each($tdTimeInForce, function() {var tdTimeInForce=$(this).text(); });	
		$.each($tdStopPx, function() { var tdStopPx=$(this).text();});	
		$.each($tdOrderID, function() { var tdOrderID=$(this).text(); });	
		$.each($tdorigClOrdId, function() { var tdorigClOrdId=$(this).text(); });	
		$.each($PositionEffect, function() { var PositionEffect=$(this).text(); });					  
});	


$('.cancelorder').click(function(){									 
								 
		var $orow = $(this).closest("tr");        // Finds the closest row <tr> 
		var $tdAccount = $orow.find("td:nth-child(1)");
		var $tdOrderQty = $orow.find("td:nth-child(2)"); // Finds the 2nd <td> element
		var $tdClOrdId = $orow.find("td:nth-child(3)");
		var $tdProductType = $orow.find("td:nth-child(4)");
		var $tdproduct = $orow.find("td:nth-child(5)");
		//var $tdProduct = $orow.find("td:nth-child(6)");
		var $tdContract = $orow.find("td:nth-child(6)");
		var $tdGateway = $orow.find("td:nth-child(7)"); 
		var $tdOrderType = $orow.find("td:nth-child(8)");
		var $tdPrice = $orow.find("td:nth-child(9)");
		var $tdSide = $orow.find("td:nth-child(10)");
		var $tdTimeInForce = $orow.find("td:nth-child(11)");
		var $tdStopPx = $orow.find("td:nth-child(12)");
		var $tdOrderID = $orow.find("td:nth-child(13)");
		var $tdorigClOrdId = $orow.find("td:nth-child(14)");
		var $PositionEffect = $orow.find("td:nth-child(15)");

   
		$.each($tdAccount, function() {                // Visits every single <td> element
		var tdAccount=$(this).text();         // Prints out the text within the <td>
		//sessionStorage.setItem("contsize", tdcontsize);
		});	
		$.each($tdOrderQty, function() { var tdOrderQty=$(this).text(); });
		$.each($tdClOrdId, function() { var tdClOrdId=$(this).text(); });
		$.each($tdProductType, function() { var tdProductType=$(this).text();});
		$.each($tdproduct, function() { var tdproduct=$(this).text(); });	
		$.each($tdContract, function() { var tdContract=$(this).text(); });
		$.each($tdGateway, function() { var tdGateway=$(this).text();});
		$.each($tdOrderType, function() { var tdOrderType=$(this).text();});
		$.each($tdPrice, function() { var tdPrice=$(this).text(); });	
		$.each($tdSide, function() { var tdSide=$(this).text(); });
		$.each($tdTimeInForce, function() {var tdTimeInForce=$(this).text(); });	
		$.each($tdStopPx, function() { var tdStopPx=$(this).text();});	
		$.each($tdOrderID, function() { var tdOrderID=$(this).text(); });	
		$.each($tdorigClOrdId, function() { var tdorigClOrdId=$(this).text(); });	
		$.each($PositionEffect, function() { var PositionEffect=$(this).text(); });					  
				
				var StopPx=0;
				var Account =269;
				var OrderQty1 = $('#quantity').val();
				var ContractSize = $('#contractsize').val();
				var OrderQty=parseFloat(OrderQty1*ContractSize);
				var ClOrdId ='701';
				var Product ='GOLD';//// get from contract
				var Contract =$('#symble').val();// get from contract
				var Gateway ='ECX';// get from contract
				var Side1 =$('#side').val();//user
				var side=Side1;
				var Price1 = $('#price').val();
				var Price =parseFloat(Price1);
				var Digit1 = $('#digit').val();
				var Digit =parseInt(Digit1);
				var StopLabelLimit1 = $('#stoplbllimit').val();
                var StopLabelLimit=parseFloat(StopLabelLimit1);
				var trigerPrice1 = $('#trigger').val();
                var trigerPrice=parseFloat(trigerPrice1);
				var OrderType =$('#market').val(); //user input
				var ExpireDate =0;  //0
				var TransactTime =0; //time
				var OrderID =701;//

				var origClOrdId ='';//blank
				var PositionEffect = 0;//0
				var LnkdOrdId ='';//blank
				var MinOrDisclosedQty = 0;//0
				var Slipage =0;//0
				var OCOOrder ='false';//false
				
				
				var msg1 = {
				msgtype:ORDER_CANCEL_REQUEST,
				Account:Account,
				OrderQty:OrderQty,
				ClOrdId:ClOrdId,
				ProductType:SECURITY_TYPE_FUT,
				Product:Product,
				Contract:Contract,
				Gateway:Gateway,
				OrderType:OrderType,
				Price:Price,
				Side:side,
				TimeInForce:TIF_DAY,
				StopPx:StopPx,
				//ExpireDate:ExpireDate,
				//TransactTime:TransactTime,
				OrderID:OrderID,
				origClOrdId:origClOrdId,
				PositionEffect:"O"
				//LnkdOrdId:LnkdOrdId,
				//MinOrDisclosedQty:MinOrDisclosedQty,
				//Slipage:Slipage,
				//OCOOrder:OCOOrder									
				};
								
				var msg=JSON.stringify(msg1);
                console.log("Cancel order");
                console.log(msg1);				
				//socket.send(msg);				
				});


			
function OutputLog(msg){
				var content = '<p>' + msg + '</p>';
				$('#consolebox').append(content);
			};
		
function connect(){
				
			  // var hostname = "148.251.187.214";	
                //var hostname = "192.168.1.19";
				var hostname = "176.9.35.6";
			try{
				//var hostname = window.location.hostname;
	            socket = new WebSocket("ws://" + hostname + ":9022/test");
				OutputLog('Socket Status: '+socket.readyState);				
				socket.onopen = function(e){					
					OutputLog('Socket Status: '+socket.readyState+' (open)');
					//var pseudoName = $('#pseudo').val();
				var username = $('#username').val();
				var password = $('#password').val();
				sessionStorage.setItem("UserName", username);
				//var username='sanjay1';
				//var password='ram';
					var msg1 = {
				    msgtype:LOGON_REQUEST,
					UserName: username,
					Password: password,
					Version:1.15,
					SenderID:'2'				 
				};
				console.log("welcome");
				console.log(msg1);
				var msg=JSON.stringify(msg1);
					socket.send(msg);
				}
				
				socket.onmessage = function(msg){
					var str = "";
					str = msg.data;	
					//console.log(str);
					var arg2 = "";
					var msgtype="";
					var ordSide="";
					var ordStat="";
				
					arg2=JSON.parse(str);
					msgtype=arg2.msgtype;
		           // console.log(arg2);
					
					switch(msgtype)
					{
					case LOGON_RESPONSE:
					     console.log("logon response");
						 console.log(arg2)
						 LogonResponse(arg2);
						// OrderHistoryRequest();
						// tradeHistoryRequest();
					break;
					case PARTICIPANT_LIST_RESPONSE:
					     console.log("Participant list response");
						 console.log(arg2)
                          for(i=0;i<1;i++)
						 {
							 var test=arg2.accountInfo[i];
							 console.log(test);			 
						// var content =;
						 $("#accountinfo > tbody").find("tr:gt(0)").remove();
				         $('#accountinfo > tbody:last').append('<tr class=\"info\"><td class=\"responsive\"><b>Name</b></td><td class=\"responsive\">'+test.TraderName+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Leverage</b></td><td class=\"responsive\">'+test.Leverage+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Balance</b></td><td class=\"responsive\">'+test.Balance+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Used Margin</b></td><td class=\"responsive\">'+test.UsedMargin+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Free Margin</b></td><td class=\"responsive\">'+test.FreeMargin+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Equity</b></td><td id=\"equitibal\" class=\"responsive\">0</td></tr>');
						 //ParticipantListResponse(arg2);
						 sessionStorage.setItem("acBalance", test.Balance);
						 sessionStorage.setItem("AcctID", test.AccountID);
						 if(FirstTime=="FALSE"){
						 OrderHistoryRequest();
						 tradeHistoryRequest();
						 }
						 FirstTime="TRUE"
						 }					 
						 
					break;
					case EXECUTION_REPORT_RESPONSE:					    
						 //console.log("execution report response");
						// console.log(arg2)
						 //ExecutionReportResponse(arg2);
					break;
					case ORDER_STATUS_RESPONSE:
					
					    // var content = '<p>' + str + '</p>';
				         //$('#orderstatus').append(content);
						console.log("order status response");
						console.log(arg2);
						ordStat=checkOrderStatus(arg2.OrderStatus);
						var BidPric = parseFloat(sessionStorage.getItem("bidpr"));
						 console.log(BidPric);
				        var AskPric = parseFloat(sessionStorage.getItem("askpr"));
						 console.log(AskPric);
						var Contsize=parseFloat(sessionStorage.getItem("contsize"));
						 console.log(Contsize);
						var AvgPrice=arg2.Price;
						var Qty=arg2.OrderQty/Contsize;
						 console.log(Qty);
						 
						if(arg2.Side==1)
						{	
						ordSide='BUY';
					    
						var equityBalance=Qty*(BidPric-AvgPrice)*Contsize;
						console.log(equityBalance);
						}
						else 
						{	
						ordSide='SELL';
						var equityBalance=Qty*(AvgPrice-AskPric)*Contsize;
						}
						//if(arg2.QtyFilled>0)
					    if(ordStat=='FILLED')		
						{ 
						var hashOrder = arg2.OrderID + "#stat";
                        //if(arg2.OrderStatus=="2")ordStat='FILLED';else ordSide='PENDING';						
						 $("#span4").css({ display: "none" });
						 $("#orderform").css({ display: "none" });
						 $("#posinfo").css({ display: "none" });
						 $("#ordrhisinfo").css({ display: "none" });
						 $("#trdhisinfo").css({ display: "block" });
						  $('#tradehistry > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b>'+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'</td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+arg2.AvgPx+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr>');
						 //if(document.getElementById(hashOrder)){						
						// document.getElementById(hashOrder).innerHTML=ordStat;							 
						 //}
								 
						 }else {
							 
						   if(arg2.OrderType=="1"||arg2.OrderType=="2")
						   {
						 $("#span4").css({ display: "none" });
						 $("#orderform").css({ display: "none" });
						 $("#ordrhisinfo").css({ display: "block" });
						 $("#trdhisinfo").css({ display: "none" });
						 $("#posinfo").css({ display: "none" });
						 //$('#positioninfo > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> </br>'+arg2.OrderID+'</td><td class=\"responsive\"><b>Side</b> </br>'+ordSide+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> </br>'+arg2.Price+'</td><td class=\"responsive\"><b>Status</b></br>'+ordStat+'</td></tr>');
					    $('#orderhistry > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+arg2.Price+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr>');						 			
						 }else{
						 $("#span4").css({ display: "none" });
						 $("#orderform").css({ display: "none" });
						 $("#ordrhisinfo").css({ display: "block" });
						 $("#trdhisinfo").css({ display: "none" });
						 $("#posinfo").css({ display: "none" });
						 
						 //$('#positioninfo > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> </br>'+arg2.OrderID+'</td><td class=\"responsive\"><b>Side</b> </br>'+ordSide+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> </br>'+arg2.Price+'</td><td class=\"responsive\"><b>Status</b></br>'+ordStat+'</td></tr>');
					    $('#orderhistry > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+arg2.Price+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr>');						 			
						 } 
						 
						 }				
						 
						 var balance=parseFloat(sessionStorage.getItem("acBalance"));
						 console.log(balance);
						 var Equity=balance+equityBalance;
						 console.log( 'Equity: '+Equity);
						 $( "#equitibal" ).text( Equity );
						// console.log(arg2);						
					break;
					case BUSINESS_LEVEL_REJECT:
						  $("#orderform").css({ display: "block" })
						   var content = 'Order Rejected,Error Code '+arg2.Text;
				         //$('#orderError').append(content);
						  $('#orderError').text(content);
					break;
					case ORDER_HISTORY_RESPONSE:
						 //console.log("Order history response");
						 							 
						 for(i=0;i<arg2.NoOfOrders;i++)
						 {
							 var test=arg2.orderHistory[i];
							 console.log(test);	
                         	if(test.Side==1)
						{	 
						ordSide='BUY';
					    
						var equityBalance=Qty*(BidPric-AvgPrice)*Contsize;
						//console.log(equityBalance);
						}
						else 
						{	
						ordSide='SELL';
						var equityBalance=Qty*(AvgPrice-AskPric)*Contsize;
						}						 
						var Contsize1=parseInt(sessionStorage.getItem(test.Contract));
						var hashdigit = test.Contract + "#digit";
						var Digit=parseInt(sessionStorage.getItem(hashdigit));
						console.log(Digit);
						//console.log("contractsize");
						//console.log(Contsize1);
						var OrdQty=parseInt(test.OrderQty);
						//console.log(OrdQty);
						var Qty1=OrdQty/Contsize1;
						//console.log(Qty1);						//console.log(Contsize1);
						ordStat1=checkOrderStatus(test.OrderStatus);
						if(ordStat1=="WORKING"){
						

				       $('#orderhistry > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> '+test.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+test.Contract+'  </td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty1+' <b>@</b> '+test.Price+'</td><td class=\"responsive\" id=\"'+test.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat1+'</td></tr>');
						}				 
						 }
						 //}
						  
					break;
					case TRADE_HISTORY_RESPONSE:
					     console.log("Trade history response");
						  							 
						 for(i=0;i<arg2.NoOfOrders;i++)
						 {
							 var test1=arg2.executionReport[i];
							 console.log(test1);	
                         	if(test1.Side==1)
						{	
						ordSide='BUY';
					    
						var equityBalance=Qty*(BidPric-AvgPrice)*Contsize;
						//console.log(equityBalance);
						}
						else 
						{	
						ordSide='SELL';
						var equityBalance=Qty*(AvgPrice-AskPric)*Contsize;
						}
						
						var Contsize2=sessionStorage.getItem(test1.Contract);						
						var OrdQty1=parseInt(test1.OrderQty);
						var CloseQty=parseInt(test1.ClosedQty);						
						var Qty2=OrdQty1/Contsize2;																	
						var SettelQty=OrdQty1-CloseQty;		
						
						
						ordStat2=checkOrderStatus(test1.OrderStatus);
						if(ordStat2=="FILLED" && SettelQty >'0' ){
				        $('#tradehistry > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b>'+test1.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+test1.Contract+'</td></tr><tr class=\"info\"style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty2+' <b>@</b> '+test1.AvgPx+'</td><td class=\"responsive\" id=\"'+test1.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat2+'</td></tr>');
						}				 
						 }
						 //}
						
					break;
					case LOGOUT_RESPONSE:
						 console.log(arg2)
						
					break;
					default:
					break;
				}
																
				}
				
				socket.onclose = function(){
					OutputLog('Socket Status: '+socket.readyState+' (Closed)');
				}			
					
			} catch(exception){
				OutputLog('Error'+exception);
			}
			
		}





function LogonResponse(data)
{	
		var AccountType=data.AccountType;
		var Reason=data.Reason;
		var BrokerName=data.BrokerName;
		//var UserName='sanjay1';
		var IsLive=data.IsLive;
		
		
			if(Reason=='VALID')
			{				
		    var UserName1 = sessionStorage.getItem("UserName");
			ParticipantListRequest(UserName1);
			
			$("#login").css({ display: "none" });
			$("#span4").css({ display: "block" });
			$("#acinfo").css({ display: "block" });	            		
			}else{			
			alert("Invalid Username or Password");
			return;
			}
}

function ParticipantListRequest(UserName)
{     
	
	var msg1 = {
		        msgtype:PARTICIPANT_LIST_REQUEST,
				UserName:UserName								 
				};
				console.log("Participant list request");
				console.log(msg1);
				var msg=JSON.stringify(msg1);				
				socket.send(msg);
				
	 
	// structureHeader         Header;
    //  char                   UserName[8];
}
function OrderHistoryRequest()
{     
	var AccntID=parseInt(sessionStorage.getItem("AcctID"));
	var msg1 = {
		        msgtype:ORDER_HISTORY_REQUEST,
				Account:AccntID,
		        Filter:'Y',
		        SenderID:'2'												 
				};
				console.log("Order History Request");
				console.log(msg1);
				var msg=JSON.stringify(msg1);				
				socket.send(msg);
				
	 
	// structureHeader         Header;
    //  char                   UserName[8];
}
function  tradeHistoryRequest()
{    
//alert("Trade History"); 
	//console.log("Trade History Request");
	var AccontID=parseInt(sessionStorage.getItem("AcctID"));
	var msg1 = {
		        msgtype:TRADE_HISTORY_REQUEST,
				Account:AccontID,
		        Filter:'Y',
		        SenderID:'2'												 
				};
				console.log("Trade History Request");
				console.log(msg1);
				var msg=JSON.stringify(msg1);				
				socket.send(msg);
				
	 
	// structureHeader         Header;
    //  char                   UserName[8];
}


function checkOrderStatus(stat)
{
var ostatus="";
switch(stat)
		{
		case ORDER_STATUS_NEW:
			 ostatus="WORKING";
			 return ostatus;
		break;
		case ORDER_STATUS_PARTIALLY_FILLED:
			 ostatus="PARTIALLY_FILLED";
			 return ostatus;						 
			
		break;
		case ORDER_STATUS_FILLED:					    
			 ostatus="FILLED";
			 return ostatus;
		break;
		case ORDER_STATUS_CANCEL:
			ostatus="CANCEL";
			 return ostatus;						
		break;
		case ORDER_STATUS_REPLACED:
			 ostatus="REPLACED";
			 return ostatus;						 
			
		break;
		case ORDER_STATUS_PENDING_CANCEL:					    
			 ostatus="PENDING_CANCEL";
			 return ostatus;
		break;
		case ORDER_STATUS_REJECTED:
			 ostatus="REJECTED";
			 return ostatus;						
		break;
		case ORDER_STATUS_PENDINGNEW:
			ostatus="PENDINGNEW";
			return ostatus;
			
		break;
		case ORDER_STATUS_EXPIRED:
			 ostatus="EXPIRED";
			 return ostatus;						 
			
		break;
		case ORDER_STATUS_PENDINGREPLACE:					    
			 ostatus="PENDINGREPLACE";
			 return ostatus;
		break;
		case ORDER_STATUS_UNDEFINED:
			ostatus="UNDEFINED";
			 return ostatus;						
		break;
		case ORDER_STATUS_ORDER_NOT_FOUND:
			ostatus="ORDER_NOT_FOUND";
			return ostatus;
			

		break;
		
		default:
		break;
		}	
	
	
	
}

function TradeHistoryRequest()
{
    //  structureHeader         Header;
     // unsigned long           Account;
    //  char                    Filter;
}

function ParticipantListResponse(data)
{
	    //document.getElementById("accountinfo").innerHTML = data.Balance;
       	//sessionStorage.setItem("AcountData", data); 
		var UserName = data.UserName;
		var Account = data.Account;
		var NoOfParticipants = data.NoOfParticipants;
		var AccountType = data.AccountType;
		//var IsLive = data.IsLive;

		var Balance = data.Balance;
		var Leverage = data.Leverage;
		var Group = data.Group;
		var FreeMargin = data.FreeMargin;
		var Margin = data.Margin;
		var UsedMargin = data.UsedMargin;
		var HedgingType = data.HedgingType;
		var Active = data.Active;
		var ReservedMargin = data.ReservedMargin;
		var BuySideTurnOver = data.BuySideTurnOver;
		var SellSideturnOver = data.SellSideturnOver;

		var MarginCall1 = data.MarginCall1;
		var MarginCall2 = data.MarginCall2;
		var MarginCall3 = data.MarginCall3;
		var TraderName = data.TraderName;
		var AccountType = data.AccountType;
		var LotSize = data.LotSize;
		
}


function AccountInfo(data)
{

		var Balance = data.Balance;
		var Leverage = data.Leverage;
		var Group = data.Group;
		var FreeMargin = data.FreeMargin;
		var Margin = data.Margin;
		var UsedMargin = data.UsedMargin;
		var HedgingType = data.HedgingType;
		var Active = data.Active;
		var ReservedMargin = data.ReservedMargin;
		var BuySideTurnOver = data.BuySideTurnOver;
		var SellSideturnOver = data.SellSideturnOver;

		var MarginCall1 = data.MarginCall1;
		var MarginCall2 = data.MarginCall2;
		var MarginCall3 = data.MarginCall3;
		var TraderName = data.TraderName;
		var AccountType = data.AccountType;
		var LotSize = data.LotSize;
}

function ExecutionReportResponse(data)
{
		var Account = data.Account;
		var OrderQty = data.OrderQty;
		var ClOrdId = data.ClOrdId;
		var ProductType = data.ProductType;

		var Product = data.Product;
		var Contract = data.Contract;
		var Gateway = data.Gateway;

		var OrderType = data.OrderType;
		var Price = data.Price;
		var Side = data.Side;
		var TimeInForce = data.TimeInForce;
		var StopPx = data.StopPx;
		var ExpireDate = data.ExpireDate;
		var TransactTime = data.TransactTime;
		var OrderID = data.OrderID;

		var origClOrdId = data.origClOrdId;
		var PositionEffect = data.PositionEffect;
		var LnkdOrdId = data.LnkdOrdId;
		//var MinOrDisclosedQty = data.MinOrDisclosedQty;
		//var Slipage = data.Slipage;
		var Profit = data.Profit;     
}
function LogoutRequest()
{
     // structureHeader         Header;
   //   char                    UserName[8];                        
    //  char                    Password[15];                       //Password for the account     TRDBO.Account. MasterPassword
    //  char                    ReasonForLogout[150];         //Reason for logout
}


});



