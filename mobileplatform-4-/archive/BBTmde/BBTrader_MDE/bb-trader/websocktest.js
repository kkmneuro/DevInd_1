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

$("#msg").hide();

//$('#login_send').click(function(){
window.login = function login(){

			$("#msg").show();
			
			var username = $('#username').val();
			var password = $('#password').val();   
			var remember = $('#remember').val(); 		
		
			//alert(username+password+remember);
			connect();			
			    
	}; 

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
                //var Price=Price*Math.pow(10, Digit);
                var StopLabelLimit1 = $('#stoplbllimit').val();
                var StopLabelLimit=parseFloat(StopLabelLimit1);
                StopLabelLimit=StopLabelLimit/Math.pow(10, Digit);
                var trigerPrice1 = $('#trigger').val();
                var trigerPrice=parseFloat(trigerPrice1);
                var OrderType =$('#market').val(); //user input
                if(OrderType=="MARKET")
                {
                OrderType=ORDER_TYPE_MARKET_ORDER;
                Price=Price*Math.pow(10, Digit);
                }
                else if(OrderType=="LIMIT")
                {
                 if(side=="1"){
                        if(Price >(AskPrice-StopLabelLimit)){
                        alert("Wrong buy Price");
                        return;                    
                        }
                    //Price=Price*Math.pow(10, Digit);
                    }
                    else
                    {
                        if(Price <(BidPrice+StopLabelLimit)){
                            //console.log(BidPrice+StopLabelLimit);
                            //console.log(BidPrice);
                        alert("Wrong Sell Price");
                        return;                
                        }
                    
                    }
                Price=Price*Math.pow(10, Digit);    
                OrderType=ORDER_TYPE_LIMIT_ORDER;    
                }
                else if(OrderType=="STOP")
                {
                    if(side=="1"){
                        if(Price <(AskPrice+StopLabelLimit)){
                        alert("Wrong buy stop Limit");
                        return;                    
                        }                        
                    }
                    else
                        {
                        if(Price >(BidPrice-StopLabelLimit)){                        
                        alert("Wrong Sell Price");
                        return;                
                        }
                    }
               OrderType=ORDER_TYPE_STOP_ORDER;
               StopPx =trigerPrice;
                StopPx=StopPx*Math.pow(10, Digit);
                Price=0;
                }
                else
                {
                    if(side=="1"){
                        if(Price >(AskPrice+StopLabelLimit+1)){
                        alert("Wrong buy Price");
                        return;                    
                        }                        
                    }
                    else
                    {
                        if(Price <(BidPrice-StopLabelLimit-1)){
                            //console.log(BidPrice+StopLabelLimit);
                            //console.log(BidPrice);
                        alert("Wrong Sell Price");
                        return;                
                        }
                    }
                OrderType=ORDER_TYPE_STOP_LIMIT_ORDER;    
                StopPx =trigerPrice;
                StopPx=StopPx*Math.pow(10, Digit);
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
				//location.reload();
                });
                


$('#Modifyorder').click(function(){    
                                 
                alert("Welcome to Modify Order");                
                var oldAccount = $('#oldAccount').val();
                   oldAccount=oldAccount.trim();
                    oldAccount =parseInt(oldAccount);
                var oldOrderQty = $('#oldquantity').val();
                   oldOrderQty=oldOrderQty.trim();
                    oldOrderQty =parseInt(oldOrderQty);
                var oldClOrdId = $('#oldclorderid').val();
                   oldClOrdId=oldClOrdId.trim();
                var oldProductType = $('#oldproducttype').val();
                   oldProductType=oldProductType.trim();
                var oldProduct = $('#oldproduct').val(); 
                   oldProduct=oldProduct.trim();
                var oldContract = $('#oldcontract').val();
                   oldContract=oldContract.trim();
                var oldGateway = $('#oldgateway').val();
                   oldGateway=oldGateway.trim();
                var oldOrderType = $('#oldordertype').val();
                   oldOrderType=oldOrderType.trim();
                var oldPrice = $('#oldprice').val();
                   oldPrice=oldPrice.trim();
                    oldPrice =parseFloat(oldPrice);
                var oldSide = $('#oldside').val();
                   oldSide=oldSide.trim();
                var oldTimeinforce = $('#oldtimeinforce').val();
                   oldTimeinforce=oldTimeinforce.trim();
                var oldStopPx = $('#oldstoppx').val(); 
                   oldStopPx=oldStopPx.trim();
                    oldStopPx =parseInt(oldStopPx);
                var oldOrderID = $('#oldorderid').val();
                   oldOrderID=oldOrderID.trim();
                    oldOrderID =parseInt(oldOrderID);
                var oldorigClOrdId = $('#oldorignalclordid').val();
                   oldorigClOrdId=oldorigClOrdId.trim();
                //var oldpositioneffect = $('#oldpositioneffect').val();
                 
                // $("#orderform").css({ display: "none" });
                var BidPrice = parseFloat(sessionStorage.getItem("bidpr"));                
                var AskPrice=parseFloat(sessionStorage.getItem("askpr"));
                var AcontID=parseInt(sessionStorage.getItem("AcctID"));
                //console.log(BidPrice);
                //console.log(AskPrice);
                var StopPx=0;
                var Account =AcontID;
                var OrderQty1 = $('#mquantity').val();
                var ContractSize = $('#mcontractsize').val();
                var OrderQty=parseFloat(OrderQty1*ContractSize);
                var ClOrdId ='701';
                //var ProductType =$('#product').val();//// get from contract

                var Product =oldProduct;//// get from contract
                var Contract =$('#msymble').val();// get from contract
                var Gateway ='ECX';// get from contract
                var Side1 =$('#mside').val();//user
                var side=Side1;
                var Price1 = $('#mprice').val();
                var Price = parseFloat(Price1);
                //console.log(Price)
                var Digit1 = $('#mdigit').val();
                var Digit =parseInt(Digit1);
                //var Price=Price*Math.pow(10, Digit);
                
                var StopLabelLimit1 = $('#mstoplbllimit').val();
                var StopLabelLimit=parseFloat(StopLabelLimit1);
                StopLabelLimit=StopLabelLimit/Math.pow(10, Digit);
                var trigerPrice1 = $('#mtrigger').val();
                var trigerPrice=parseFloat(trigerPrice1);
                var OrderType =$('#mmarket').val(); //user input
                if(OrderType=="MARKET")
                {
                OrderType=ORDER_TYPE_MARKET_ORDER;
                Price=Price*Math.pow(10, Digit);
                }
                else if(OrderType=="LIMIT")
                {
                 if(side=="1"){
                        if(Price >(AskPrice-StopLabelLimit)){
                        alert("Wrong buy Price");
                        return;                    
                        }
                    //Price=Price*Math.pow(10, Digit);
                    }
                    else
                    {
                        if(Price <(BidPrice+StopLabelLimit)){
                            //console.log(BidPrice+StopLabelLimit);
                            //console.log(BidPrice);
                        alert("Wrong Sell Price");
                        return;                
                        }
                    
                    }
                Price=Price*Math.pow(10, Digit);    
                OrderType=ORDER_TYPE_LIMIT_ORDER;    
                }
                else if(OrderType=="STOP")
                {
                    if(side=="1"){
                        if(Price <(AskPrice+StopLabelLimit)){
                        alert("Wrong buy stop Limit");
                        return;                    
                        }                        
                    }
                    else
                        {
                        if(Price >(BidPrice-StopLabelLimit)){                        
                        alert("Wrong Sell Price");
                        return;                
                        }
                    }
                OrderType=ORDER_TYPE_STOP_ORDER;
               StopPx =trigerPrice;
                StopPx=StopPx*Math.pow(10, Digit);
                Price=0;
                }
                else
                {
                    if(side=="1"){
                        if(Price >(AskPrice+StopLabelLimit+1)){
                        alert("Wrong buy Price");
                        return;                    
                        }                        
                    }
                    else
                    {
                        if(Price <(BidPrice-StopLabelLimit-1)){
                            //console.log(BidPrice+StopLabelLimit);
                            //console.log(BidPrice);
                        alert("Wrong Sell Price");
                        return;                
                        }
                    }
                OrderType=ORDER_TYPE_STOP_LIMIT_ORDER;    
                StopPx =trigerPrice;
                StopPx=StopPx*Math.pow(10, Digit);
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
                StopPx:0,
                ExpireDate:ExpireDate,
                TransactTime:TransactTime,
                OrderID:OrderID,
                origClOrdId:origClOrdId,
                PositionEffect:"O",
                OldAccount:oldAccount,
                OldOrderQty:oldOrderQty,
                OldClOrdId:oldClOrdId,
                OldProductType:SECURITY_TYPE_FUT,
                OldProduct:oldProduct,
                OldContract:oldContract,
                OldGateway:oldGateway,
                OldOrderType:oldOrderType,
                OldPrice:oldPrice,
                OldSide:oldSide,
                OldTimeInForce:TIF_DAY,
                OldStopPx:oldStopPx,                
                OldOrderID:oldOrderID,
                OldorigClOrdId:'',
                OldPositionEffect:"O"

                
                
                //LnkdOrdId:LnkdOrdId,
                //MinOrDisclosedQty:MinOrDisclosedQty,
                //Slipage:Slipage,
                //OCOOrder:OCOOrder                                    
                };
                                
                var msg=JSON.stringify(msg1);
                console.log("send Modify order");
                console.log(msg1);                
                socket.send(msg);
				//location.reload();
                });


window.cancelOrder = function (tdAccount,tdOrderQty,tdClOrdId,tdProductType,tdProduct,tdContract,tdGateway,tdOrderType,tdPrice,tdSide,tdTimeInForce,tdStopPx,tdOrderID,tdorigClOrdId,tdPositionEffect)
{    

                tdAccount=tdAccount.trim();
                tdAccount =parseInt(tdAccount);
                tdOrderQty=tdOrderQty.trim();
                tdOrderQty =parseInt(tdOrderQty);
                tdClOrdId=tdClOrdId.trim();
                tdProductType=tdProductType.trim();
                tdProduct=tdProduct.trim();
                tdContract=tdContract.trim();
                tdGateway=tdGateway.trim();
                tdOrderType=tdOrderType.trim();
                tdPrice=tdPrice.trim();
                tdPrice =parseFloat(tdPrice);
                tdSide=tdSide.trim();
                tdTimeInForce=tdTimeInForce.trim();
                tdStopPx=tdStopPx.trim();
                tdStopPx =parseInt(tdStopPx);
                tdOrderID=tdOrderID.trim();
                tdOrderID =parseInt(tdOrderID);
                tdorigClOrdId=tdorigClOrdId.trim();
                tdPositionEffect=tdPositionEffect.trim();                
               console.log("Welcome to Cancel Order");        
                                
                tdorigClOrdId="";
                var msg1 = {
                msgtype:ORDER_CANCEL_REQUEST,
                Account:tdAccount,
                OrderQty:tdOrderQty,
                ClOrdId:tdClOrdId,
                ProductType:SECURITY_TYPE_FUT,
                Product:tdProduct,
                Contract:tdContract,
                Gateway:tdGateway,
                OrderType:tdOrderType,
                Price:tdPrice,
                Side:tdSide,
                TimeInForce:TIF_DAY,
                StopPx:tdStopPx,                
                OrderID:tdOrderID,
                origClOrdId:tdorigClOrdId,
                PositionEffect:tdPositionEffect                                                
                };
                                
                var msg=JSON.stringify(msg1);
                console.log("Cancel order");
                console.log(msg1);                
                socket.send(msg);                
                } 
                    //  Cancel Order Request

            
function OutputLog(msg){
                var content = '<p>' + msg + '</p>';
                $('#consolebox').append(content);
            };
        
window.connect = function connect(){
             
			 // var hostname = "176.9.35.6";  
              var hostname = "78.47.54.100";    
                       
            try{
				
               socket = new WebSocket("ws://" + hostname + ":9022/test");
			   //socket = new WebSocket("ws://" + hostname + ":9034/test");
                OutputLog('Socket Status: '+socket.readyState); 
			    socket.onopen = function(e){                    
                    OutputLog('Socket Status: '+socket.readyState+' (open)');
                    //var pseudoName = $('#pseudo').val();


				var username = $('#username').val();
                var password = $('#password').val();
                sessionStorage.setItem("UserName", username);
                sessionStorage.setItem("PASS", password);
              
				/*$.ajax({
							url: 'insert_user.php',
							type: 'POST',
							data: {var100: username, var101: password},
							success: function(data) {
								
								$('#pks').html(data);
								console.log("success");
							}
    					});
				*/	


				/*$.ajax({
						url: 'api.php',
						type: 'POST',
						data: {var11: username, var12: password},
						success: function(data5) {
						//alert(data5);
						$('#pks').html(data5);
						}
						
				});	
				*/
				
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
                        console.log(arg2);
                        /////
                        /*if(arg2.Reason=='User already logged in from another location'){
							document.write(arg2.Reason);
						}*/
                        /////
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
                             
                        var Equityval=sessionStorage.getItem("Equitysession");
                        var UsedMarginval=sessionStorage.getItem("usedMargin");
                        //var sessionBalance=sessionStorage.getItem("acBalance");
                        var Eq1;
                        var Um2;
                        if(Equityval==''){    Eq1=test.Balance;    } else { Eq1=Equityval; }        
                        if(test.UsedMargin==''){ Um2=test.Balance;    } else { Um2=Eq1-test.UsedMargin; }
                        
                        $("#accountinfo > tbody").find("tr:gt(0)").remove();
                        $('#accountinfo > tbody:last').append('<tr class=\"info\"><td class=\"responsive\"><b>Name</b></td><td class=\"responsive\">'+test.TraderName+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Leverage</b></td><td class=\"responsive\">'+test.Leverage+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Balance</b></td><td class=\"responsive\">'+test.Balance+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Used Margin</b></td><td class=\"responsive\">'+test.UsedMargin+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Free Margin</b></td><td class=\"responsive\"><div id=\"frmargin\">'+Um2+'</div></td></tr><tr class=\"info\"><td class=\"responsive\"><b>Equity</b></td><td id=\"equitibal\" class=\"responsive\"><div id=\"equitibal1\">'+Eq1+'</div> </td></tr>');
                        //ParticipantListResponse(arg2);
                        sessionStorage.setItem("acBalance", test.Balance);
                        sessionStorage.setItem("AcctID", test.AccountID);
						sessionStorage.setItem("usedMargin", test.UsedMargin);
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
                        var hashdigit1 = arg2.Contract + "#digit";
                        var Digit=parseInt(sessionStorage.getItem(hashdigit1));                        
                        var powDigit=Math.pow(10, Digit);                        
                        
                        if(ordStat=='CANCEL'){
                        
                        var hashOrdId = arg2.OrderID + "#ord";
                        var hashOrdId1 = arg2.OrderID + "#ord1";
						var hashOrdId2 = arg2.OrderID + "#ord2";
                        var row2 = document.getElementById(hashOrdId);                         
                        row2.parentElement.removeChild(row2);
                        var row3 = document.getElementById(hashOrdId1);                         
                        row3.parentElement.removeChild(row3);
						 var row4 = document.getElementById(hashOrdId2);                         
                        row4.parentElement.removeChild(row4);
                        }
                        
                        
                        
                       //if(arg2.QtyFilled>0)
                       if(ordStat=='FILLED' && arg2.ExecType!="I")        
                        { 
                        var AvgPric=arg2.AvgPx/powDigit;
                        
                        var hashOrder = arg2.OrderID + "#stat";
                        var hashOrderId = arg2.OrderID + "#ord";
                        var hashOrderId1 = arg2.OrderID + "#ord1";
						var hashOrderId2 = arg2.OrderID + "#ord2";
                        
                        //if(arg2.OrderStatus=="2")ordStat='FILLED';else ordSide='PENDING';                        
                        $("#span4").css({ display: "none" });
                        $("#orderform").css({ display: "none" });
                        $("#posinfo").css({ display: "none" });
                        $("#ordrhisinfo").css({ display: "none" });
                        $("#modifyOrderform").css({ display: "none" });
                        $("#trdhisinfo").css({ display: "block" });                        
                        var row = document.getElementById(hashOrderId);                         
                        row.parentElement.removeChild(row);
                        var row1 = document.getElementById(hashOrderId1);                         
                        row1.parentElement.removeChild(row1);
						var row11 = document.getElementById(hashOrderId2);                         
                        row11.parentElement.removeChild(row11);
                         
                        $("#orderhistry > tbody").find("tr#hashOrderId").remove();
                        $('table#orderhistry  tbody  tr#hashOrderId1').remove();
                        $('table#orderhistry > tbody > tr#hashOrderId1').remove();
                       // $('#tradehistry > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b>'+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'</td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+AvgPric+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr>');
					 $('#tradehistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+arg2.Contract+'#cnt\"><td class=\"responsive\" style="display:none;">'+AvgPrice+'</td><td class=\"responsive\" style="display:none;">'+ordSide+'</td><td class=\"responsive\" style="display:none;">'+Qty+'</td><td class=\"responsive\"><b>OrderId:</b>'+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'</td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+AvgPric+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr>');   
					   
                        //if(document.getElementById(hashOrder)){                        
                        // document.getElementById(hashOrder).innerHTML=ordStat;                             
                        //}
                                 
                        }else {
                             
                        if(ordStat=='WORKING'){
                             
                          if(arg2.OrderType=="1"||arg2.OrderType=="2")
                          {                        
                        var AvgPric1=arg2.Price/powDigit;
                        $("#span4").css({ display: "none" });
                        $("#orderform").css({ display: "none" });
                        $("#ordrhisinfo").css({ display: "block" });
                        $("#trdhisinfo").css({ display: "none" });
                        $("#posinfo").css({ display: "none" });
                        $("#modifyOrderform").css({ display: "none" });
                        //$('#positioninfo > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> </br>'+arg2.OrderID+'</td><td class=\"responsive\"><b>Side</b> </br>'+ordSide+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> </br>'+arg2.Price+'</td><td class=\"responsive\"><b>Status</b></br>'+ordStat+'</td></tr>');
                     $('#orderhistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+arg2.OrderID+'#ord\"><td class=\"responsive\"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td></tr><tr class=\"info\" id=\"'+arg2.OrderID+'#ord1\" ><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+AvgPric1+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr><tr class=\"info\" id=\"'+arg2.OrderID+'#ord2\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\" style="display:none;"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\" style="display:none;">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Account+' </td><td class=\"responsive\" style="display:none;"> '+arg2.OrderQty+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.ClOrdId+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.ProductType+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Product+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Contract+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Gateway+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.OrderType+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Price+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Side+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.TimeInForce+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.StopPx+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.OrderID+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.origClOrdId+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.PositionEffect+'  </td><td class=\"responsive\"><a href="javascript:void(0)" onClick="Corder()"class="abCorder" >Cancel</a> </td><td class=\"responsive\"> <a href="javascript:void(0)" onClick="Modify('+arg2.OrderID+')" class=\"abCorder\" >Modify</a> </td></tr>');                                
                        }else{
                             
                        var AvgPric2=arg2.StopPx/powDigit; 
                         
                        $("#span4").css({ display: "none" });
                        $("#orderform").css({ display: "none" });
                        $("#ordrhisinfo").css({ display: "block" });
                        $("#trdhisinfo").css({ display: "none" });
                        $("#posinfo").css({ display: "none" });
                        $("#modifyOrderform").css({ display: "none" });
                         
                        //$('#positioninfo > tbody > tr:first').after('<tr class=\"info\"><td class=\"responsive\"><b>OrderId:</b> </br>'+arg2.OrderID+'</td><td class=\"responsive\"><b>Side</b> </br>'+ordSide+'</td></tr><tr class=\"info\"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> </br>'+arg2.Price+'</td><td class=\"responsive\"><b>Status</b></br>'+ordStat+'</td></tr>');
                         $('#orderhistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+arg2.OrderID+'#ord\"><td class=\"responsive\"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td></tr><tr class=\"info\" id=\"'+arg2.OrderID+'#ord1\" ><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+AvgPric2+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr><tr class=\"info\" id=\"'+arg2.OrderID+'#ord2\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\" style="display:none;"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\" style="display:none;">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Account+' </td><td class=\"responsive\" style="display:none;"> '+arg2.OrderQty+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.ClOrdId+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.ProductType+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Product+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Contract+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Gateway+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.OrderType+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Price+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Side+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.TimeInForce+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.StopPx+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.OrderID+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.origClOrdId+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.PositionEffect+'  </td><td class=\"responsive\" ><a href="javascript:void(0)" onClick="Corder()"class="abCorder" >Cancel</a></td><td class=\"responsive\"> <a href="javascript:void(0)" onClick="Modify('+arg2.OrderID+')" class=\"abCorder\" >Modify</a></td></tr>');                                
                            } 
                         
                           }
                        }                
                         
                        var balance=parseFloat(sessionStorage.getItem("acBalance"));
                        console.log(balance);
                        var Equity=balance+equityBalance;
                       //  sessionStorage.setItem("Equitysession", Equity);
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
                        //console.log("contractsize");
                        //console.log(Contsize1);
                        var OrdQty=parseInt(test.OrderQty);
                        //console.log(OrdQty);
                        var Qty1=OrdQty/Contsize1;
                        //console.log(Qty1);                        //console.log(Contsize1);
                        ordStat1=checkOrderStatus(test.OrderStatus);
                        var hashdigit = test.Contract + "#digit";
                        var Digit=parseInt(sessionStorage.getItem(hashdigit));                        
                        var powDigit=Math.pow(10, Digit);                        
                        var AvgPrice1=test.Price/powDigit;
                        console.log(AvgPrice1);
                        if(ordStat1=="WORKING"){                        

                       $('#orderhistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+test.OrderID+'#ord\"><td class=\"responsive\"><b>OrderId:</b> '+test.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+test.Contract+' </td></tr><tr class=\"info\" id=\"'+test.OrderID+'#ord1\" ><td class=\"responsive\"><b>Qty </b> '+Qty1+' <b>@</b> '+AvgPrice1+'</td><td class=\"responsive\" id=\"'+test.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat1+'</td></tr><tr class=\"info\" id=\"'+test.OrderID+'#ord2\"style="border-bottom:solid 1px #666666;"><td class=\"responsive\" style="display:none;"><b>OrderId:</b> '+test.OrderID+'</td><td class=\"responsive\" style="display:none;">'+ordSide+' &nbsp;&nbsp; '+test.Contract+' </td><td class=\"responsive\" style="display:none;"> '+test.Account+' </td><td class=\"responsive\" style="display:none;"> '+test.OrderQty+'  </td><td class=\"responsive\" style="display:none;"> '+test.ClOrdId+'  </td><td class=\"responsive\" style="display:none;"> '+test.ProductType+'  </td> <td class=\"responsive\" style="display:none;"> '+test.Product+'  </td><td class=\"responsive\" style="display:none;"> '+test.Contract+'  </td> <td class=\"responsive\" style="display:none;"> '+test.Gateway+'  </td> <td class=\"responsive\" style="display:none;"> '+test.OrderType+'  </td><td class=\"responsive\" style="display:none;"> '+test.Price+'  </td> <td class=\"responsive\" style="display:none;"> '+test.Side+'  </td> <td class=\"responsive\" style="display:none;"> '+test.TimeInForce+'  </td><td class=\"responsive\" style="display:none;"> '+test.StopPx+'  </td><td class=\"responsive\" style="display:none;"> '+test.OrderID+'  </td><td class=\"responsive\" style="display:none;"> '+test.origClOrdId+'  </td> <td class=\"responsive\" style="display:none;"> '+test.PositionEffect+'  </td> <td class=\"responsive\" ><a href="javascript:void(0)" onClick="Corder('+test.OrderID+')" class=\"abCorder\" >Cancel</a></td><td class=\"responsive\"> <a href="javascript:void(0)" onClick="Modify('+test.OrderID+')" class=\"abCorder\" >Modify</a> </td></tr>');
                        }                 
                        }
                        //}
                         
                    break;
                    case TRADE_HISTORY_RESPONSE:
                        console.log("Trade history response");
                            
							var epoch = new Date(1899, 11, 30); // 1899-12-30T00:00:00
							var now = new Date();               // 2013-03-22T<current time>
							now.setHours(0,0,0,0)               // 2013-03-22T00:00:00
							var oaDate  = Math.abs((epoch - now) / 8.64e7); // 41355 for 2013-03-22
							console.log('pks'+oaDate);
								
                        for(i=0;i<arg2.NoOfOrders;i++)
                        {
                            var test1=arg2.executionReport[i];
                            console.log(test1); 
							
							var tddate = parseInt(test1.TransactTime);
							console.log('Mukesh='+tddate);
							
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
                        
						var SettelQty2=SettelQty/Contsize2;                                                                    

                        var hashdigit = test1.Contract + "#digit";
                        var Digit=parseInt(sessionStorage.getItem(hashdigit));                        
                        var powDigit=Math.pow(10, Digit);
                        //console.log(powDigit);
                        var AvgPrice2=test1.AvgPx/powDigit;
                        console.log(AvgPrice2);
                        
                        ordStat2=checkOrderStatus(test1.OrderStatus);
                        if(ordStat2=="FILLED" && SettelQty >'0'){ // for 
                       //$('#tradehistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+test1.Contract+'#cnt\"><td class=\"responsive\"><b>OrderId:</b>'+test1.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+test1.Contract+'</td></tr><tr class=\"info\"style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty2+' <b>@</b> '+AvgPrice2+'</td><td class=\"responsive\" id=\"'+test1.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat2+'</td></tr>');
					   
					   
					   $('#tradehistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+test1.Contract+'#cnt\"><td class=\"responsive\" style="display:none;">'+AvgPrice2+'</td><td class=\"responsive\" style="display:none;">'+ordSide+'</td><td class=\"responsive\" style="display:none;">'+Qty2+'</td><td class=\"responsive\" style="display:none;">'+test1.Contract+'</td><td class=\"responsive\"><b>OrderId : </b>'+test1.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+test1.Contract+'</td></tr><tr class=\"info\"style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+SettelQty2+' <b>@</b> '+AvgPrice2+'</td><td class=\"responsive\" id=\"'+test1.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat2+'</td></tr>');
                        } 
					
					if(ordStat2=="FILLED" && (oaDate == tddate)){ // for Intrady
                       $('#infradayhistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+test1.Contract+'#cnt\"><td class=\"responsive\" style="display:none;">'+AvgPrice2+'</td><td class=\"responsive\" style="display:none;">'+ordSide+'</td><td class=\"responsive\" style="display:none;">'+Qty2+'</td><td class=\"responsive\" style="display:none;">'+test1.Contract+'</td><td class=\"responsive\"><b>OrderId : </b>'+test1.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+test1.Contract+'</td></tr><tr class=\"info\"style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty2+' <b>@</b> '+AvgPrice2+'</td><td class=\"responsive\" id=\"'+test1.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat2+'</td></tr>');
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
			var content2 = 'Invalid Username or Password';
			$("#msg").hide();
			$('#logError').text(content2);
			//alert("Invalid Username or Password");
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

function LogoutRequest()
{

}


});