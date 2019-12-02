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
connect();


            
function OutputLog(msg){
                var content = '<p>' + msg + '</p>';
                $('#consolebox').append(content);
            };
        
function connect(){
              
			 // var hostname = "176.9.35.6";  
              var hostname = "78.47.54.100";    
                           
            try{
				//var hostname = window.location.hostname;
               socket = new WebSocket("ws://" + hostname + ":9022/test");
                OutputLog('Socket Status: '+socket.readyState);                
                socket.onopen = function(e){                    
                    OutputLog('Socket Status: '+socket.readyState+' (open)');
                    //var pseudoName = $('#pseudo').val();

				var username = 'bbt1';
                var password = 'bbt1';
                sessionStorage.setItem("UserName", username);
                sessionStorage.setItem("PASS", password);
              
				
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
                    console.log(str);
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
						
						var Logintable = "<table><tr style='background-color: cornsilk;'><td width='100px'>AccountType</td><td width='100px'>BrokerName</td><td width='100px'>IsLive</td><td width='100px'>Reason</td></tr><tr><td width='104px'>" + arg2['AccountType'] + "</td><td width='104px'>" + arg2['IsLive'] + "</td><td width='104px'>" + arg2['BrokerName'] + "</td><td width='104px'>" + arg2['Reason'] + "</td></tr></table>";
						$('#consoleboxAc').append(Logintable);
												
                        LogonResponse(arg2);
                        // OrderHistoryRequest();
                        // tradeHistoryRequest();
                    break;
                    case PARTICIPANT_LIST_RESPONSE:
                        console.log("Participant list response");
                        console.log(arg2);
						
						var Participanttable = "<table><tr style='background-color: cornsilk;'><td width='100px'>AccountID</td><td width='100px'>AccountType</td><td width='100px'>Active</td><td width='100px'>Balance</td><td width='135px'>FreeMargin</td><td width='100px'>Group</td><td width='100px'>Leverage</td><td width='100px'>LotSize</td><td width='100px'>Margin</td><td width='100px'>TraderName</td><td width='100px'>UsedMargin</td></tr>";
						$('#consoleboxParticipantList').append(Participanttable);
						
                        for(i=0;i<1;i++)
                        {
                            var test=arg2.accountInfo[i];
                            console.log(test);
							
							var ParticipantLists = "<tr><td width='104px'>" + test['AccountID'] + "</td><td width='104px'>" + test['AccountType'] + "</td><td width='104px'>" + test['Active'] + "</td><td width='104px'>" + test['Balance'] + "</td><td width='140px'>" + test['FreeMargin'] + "</td><td width='104px'>" + test['Group'] + "</td><td width='104px'>" + test['Leverage'] + "</td><td width='104px'>" + test['LotSize'] + "</td><td width='104px'>" + test['Margin'] + "</td><td width='104px'>" + test['TraderName'] + "</td><td width='104px'>" + test['UsedMargin'] + "</td></tr>";
							
							$('#consoleboxParticipantList').append(ParticipantLists);			
                             
                        var Equityval=sessionStorage.getItem("Equitysession");
                        var UsedMarginval=sessionStorage.getItem("usedMargin");
                        //var sessionBalance=sessionStorage.getItem("acBalance");
                        var Eq1;
                        var Um2;
                        if(Equityval==''){    Eq1=test.Balance;    } else { Eq1=Equityval; }        
                        if(test.UsedMargin==''){ Um2=test.Balance;    } else { Um2=Eq1-test.UsedMargin; }
                        
                        
                        //ParticipantListResponse(arg2);
                        sessionStorage.setItem("acBalance", test.Balance);
                        sessionStorage.setItem("AcctID", test.AccountID);
						sessionStorage.setItem("usedMargin", test.UsedMargin);
                        if(FirstTime=="FALSE"){
                        OrderHistoryRequest();
                        tradeHistoryRequest();
                        }
                        FirstTime="TRUE";
						$('#consoleboxParticipantList').append('</table>');	
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
                     
					 $('#tradehistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+arg2.Contract+'#cnt\"><td class=\"responsive\" style="display:none;">'+AvgPrice+'</td><td class=\"responsive\" style="display:none;">'+ordSide+'</td><td class=\"responsive\" style="display:none;">'+Qty+'</td><td class=\"responsive\"><b>OrderId:</b>'+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'</td></tr><tr class=\"info\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+AvgPric+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr>');   
					   
                       
                                 
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
                      
                     $('#orderhistry > tbody > tr:first').after('<tr class=\"info\" id=\"'+arg2.OrderID+'#ord\"><td class=\"responsive\"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td></tr><tr class=\"info\" id=\"'+arg2.OrderID+'#ord1\" ><td class=\"responsive\"><b>Qty </b> '+Qty+' <b>@</b> '+AvgPric1+'</td><td class=\"responsive\" id=\"'+arg2.OrderID+'#stat\"><b>Status</b>&nbsp;&nbsp;'+ordStat+'</td></tr><tr class=\"info\" id=\"'+arg2.OrderID+'#ord2\" style="border-bottom:solid 1px #666666;"><td class=\"responsive\" style="display:none;"><b>OrderId:</b> '+arg2.OrderID+'</td><td class=\"responsive\" style="display:none;">'+ordSide+' &nbsp;&nbsp; '+arg2.Contract+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Account+' </td><td class=\"responsive\" style="display:none;"> '+arg2.OrderQty+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.ClOrdId+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.ProductType+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Product+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Contract+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Gateway+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.OrderType+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.Price+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.Side+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.TimeInForce+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.StopPx+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.OrderID+'  </td><td class=\"responsive\" style="display:none;"> '+arg2.origClOrdId+'  </td> <td class=\"responsive\" style="display:none;"> '+arg2.PositionEffect+'  </td><td class=\"responsive\"><a href="javascript:void(0)" onClick="Corder()"class="abCorder" >Cancel</a> </td><td class=\"responsive\"> <a href="javascript:void(0)" onClick="Modify('+arg2.OrderID+')" class=\"abCorder\" >Modify</a> </td></tr>');                                
                        }else{
                             
                        var AvgPric2=arg2.StopPx/powDigit; 
                         
                        $("#span4").css({ display: "none" });
                        $("#orderform").css({ display: "none" });
                        $("#ordrhisinfo").css({ display: "block" });
                        $("#trdhisinfo").css({ display: "none" });
                        $("#posinfo").css({ display: "none" });
                        $("#modifyOrderform").css({ display: "none" });
                         
                      
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
                            //console.log(test);
									
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
						
						var Historytable = "<table><tr style='background-color: cornsilk;'><td width='100px'>Account</td><td width='100px'>AvgPx</td><td width='100px'>ClOrdId</td><td width='100px'>ClosedQty</td><td width='135px'>Contract</td><td width='100px'>CumQty</td><td width='100px'>ExecID</td><td width='100px'>Gateway</td><td width='100px'>OrderID</td><td width='100px'>OrderQty</td><td width='100px'>Price</td></tr>";
						$('#consoleboxHistory').append(Historytable);		
                        
						for(i=0;i<arg2.NoOfOrders;i++)
                        {
                            var test1=arg2.executionReport[i];
                            console.log(test1);
							
							var History = "<tr><td width='104px'>" + test1['Account'] + "</td><td width='104px'>" + test1['AvgPx'] + "</td><td width='104px'>" + test1['ClOrdId'] + "</td><td width='104px'>" + test1['ClosedQty'] + "</td><td width='140px'>" + test1['Contract'] + "</td><td width='104px'>" + test1['CumQty'] + "</td><td width='104px'>" + test1['ExecID'] + "</td><td width='104px'>" + test1['Gateway'] + "</td><td width='104px'>" + test1['OrderID'] + "</td><td width='104px'>" + test1['OrderQty'] + "</td><td width='104px'>" + test1['Price'] + "</td></tr>";
								
						$('#consoleboxHistory').append(History);		
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
                        
                        var hashdigit = test1.Contract + "#digit";
                        var Digit=parseInt(sessionStorage.getItem(hashdigit));                        
                        var powDigit=Math.pow(10, Digit);
                        //console.log(powDigit);
                        var AvgPrice2=test1.AvgPx/powDigit;
                        console.log(AvgPrice2);
                        
                        ordStat2=checkOrderStatus(test1.OrderStatus);
                        if(ordStat2=="FILLED" && SettelQty >'0'){
                       
					   
					   
                        } 
					
					if(ordStat2=="FILLED" && (oaDate == tddate)){ // for Intrady
                       
                        } 
						
                        }
						$('#consoleboxHistory').append('</table>');	
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





});