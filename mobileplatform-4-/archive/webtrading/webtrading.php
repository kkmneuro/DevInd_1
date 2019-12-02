<?php
session_start();
if(!$_SESSION){
	//header("location:weblogin.php");
}
?>
<!DOCTYPE html>

<script type="text/javascript" src="js/jquery-1.9.1.js"></script>   
<script type="text/javascript" src="js/jquery.h5validate.js"></script>
<!--<script type="text/javascript" src="websocktest.js"></script>-->
<script type="text/javascript" src="js/jquery_popup.js"></script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie.min.js"></script>

<script>
function silentErrorHandler() {return true;}
window.onerror=silentErrorHandler;


$(document).ready(function(){
    $('#LowerDiv').sortable({ axis: "y",
       placeholder: "sortable-placeholder", update:updateSymbolOrder
    });
    
   
});

   
function buyOrder()
{    
    var tdsymbol = sessionStorage.getItem("tdsymbol");
	alert(tdsymbol);
    var bidpr = sessionStorage.getItem("bidpr");
    var askpr = sessionStorage.getItem("askpr");
    var tddigit = sessionStorage.getItem("tddgt");
    var tdproduct = sessionStorage.getItem("tdprdct");
    var tdgateway = sessionStorage.getItem("tdgtwy");
    var contrctsize = sessionStorage.getItem("contsize");
    var stoplbllmt = sessionStorage.getItem("stoplblmt");
    
    var bSide=1;
    $('#symble').val(tdsymbol);
    $('#digit').val(tddigit);
    $('#price').val(askpr); 
    $('#side').val(bSide);
    $('#contractsize').val(contrctsize);
    $('#stoplbllimit').val(stoplbllmt);
    $("#span4").css({ display: "none" });
    $("#orderform").css({ display: "block" });
    $("#neworder").css({ background:"green"});
    $("#modifyOrderform").css({ display: "none" });
    
}

function MarketWatch()
{

    //alert('MarketWatch');
	$("#Market").css({ display: "block" });  
	$("#Opentrade").css({ display: "none" });                
	$("#Openorder").css({ display: "none" });                
	$("#History").css({ display: "none" });                
	$("#Account").css({ display: "none" });
	$("#Chart").css({ display: "none" });
	$("#login").css({ display: "none" });  
	
	$("#HeadMarket").css({ display: "block" });
	$("#HeadOpentrade").css({ display: "none" });
	$("#HeadOpenOrders").css({ display: "none" });
	$("#HeadHistory").css({ display: "none" });                
    $("#HeadAccount").css({ display: "none" }); 
	$("#HeadChart").css({ display: "none" });                 
}

function Opentrade()
{
	$("#Market").css({ display: "none" });  
	$("#Opentrade").css({ display: "block" });                
	$("#Openorder").css({ display: "none" });                
	$("#History").css({ display: "none" });                
	$("#Account").css({ display: "none" });
	$("#Chart").css({ display: "none" });
	$("#login").css({ display: "none" });  
	
	$("#HeadMarket").css({ display: "none" });
	$("#HeadOpentrade").css({ display: "block" });
	$("#HeadOpenOrders").css({ display: "none" });
	$("#HeadHistory").css({ display: "none" });                
    $("#HeadAccount").css({ display: "none" });                
	$("#HeadChart").css({ display: "none" });                 
                    
}

function Openorders()
{
	$("#Market").css({ display: "none" });  
	$("#Opentrade").css({ display: "none" });                
	$("#Openorder").css({ display: "block" });                
	$("#History").css({ display: "none" });                
	$("#Account").css({ display: "none" });
	$("#Chart").css({ display: "none" });
	$("#login").css({ display: "none" });  
	 
	$("#HeadMarket").css({ display: "none" });
	$("#HeadOpentrade").css({ display: "none" });
	$("#HeadOpenOrders").css({ display: "block" });
	$("#HeadHistory").css({ display: "none" });                
    $("#HeadAccount").css({ display: "none" }); 
	$("#HeadChart").css({ display: "none" });                 
                    
}

function TradeHistory()
{
	$("#Market").css({ display: "none" });  
	$("#Opentrade").css({ display: "none" });                
	$("#Openorder").css({ display: "none" });                
	$("#History").css({ display: "block" });                
	$("#Account").css({ display: "none" });
	$("#Chart").css({ display: "none" });
	$("#login").css({ display: "none" });  
	 
	$("#HeadMarket").css({ display: "none" });
	$("#HeadOpentrade").css({ display: "none" });
	$("#HeadOpenOrders").css({ display: "none" });
	$("#HeadHistory").css({ display: "block" });                
    $("#HeadAccount").css({ display: "none" }); 
	$("#HeadChart").css({ display: "none" });                 
                    
}

function Account()
{
//alert('Account');
	$("#Market").css({ display: "none" });  
	$("#Opentrade").css({ display: "none" });                
	$("#Openorder").css({ display: "none" });                
	$("#History").css({ display: "none" });                
	$("#Account").css({ display: "block" });
	$("#Chart").css({ display: "none" });
	$("#login").css({ display: "none" });  
	 
	$("#HeadMarket").css({ display: "none" });
	$("#HeadOpentrade").css({ display: "none" });
	$("#HeadOpenOrders").css({ display: "none" });
	$("#HeadHistory").css({ display: "none" });                
    $("#HeadAccount").css({ display: "block" }); 
	$("#HeadChart").css({ display: "none" });                
                    
}

function Chart()
{
	$("#Market").css({ display: "none" });  
	$("#Opentrade").css({ display: "none" });                
	$("#Openorder").css({ display: "none" });                
	$("#History").css({ display: "none" });                
	$("#Account").css({ display: "none" });
	$("#Chart").css({ display: "block" });
	$("#login").css({ display: "none" });  
	 
	$("#HeadMarket").css({ display: "none" });
	$("#HeadOpentrade").css({ display: "none" });
	$("#HeadOpenOrders").css({ display: "none" });
	$("#HeadHistory").css({ display: "none" });                
    $("#HeadAccount").css({ display: "none" });
	$("#HeadChart").css({ display: "block" });                
                    
}

<!-- Order Buy-->	

</script>
	

<?php 
include("head.php");
include("websocketfunction.php");
?>
<body style="background-color:#444750">

<!--Start Login  -->
<div id="login">
<script>
$("#allwrapper").css({ display: "none" }); 
</script>
  <div class="content-wrapper" style="background-color:#444750">
    
        <section class="content" style="margin-top:-15px;">
 		 <div class="login-page" style="background-color:#444750">
     <div class="login-box"><div class="login-logo" style="color:#FFFFFF"><b>BB</b>Trader</div><!-- /.login-logo -->
      <div class="login-box-body">
        <p class="login-box-msg">Sign in</p> 
      <?php if(isset($_GET['wrong'])) { ?>
	  <div class="col-lg-1" style="color:#ff0000;font-size:16px; text-align: center; width:100%"><p>Invalid Username or Password</p></div>
      <?php }?>  
    <input type="text" name="username" id="username" class="form-control" placeholder="Username" value="<?php if(isset($_COOKIE['username'])) echo $_COOKIE['username']; ?>" />
    <br>
    <input type="password" name="password" id="password" class="form-control" placeholder="Password" value="<?php if(isset($_COOKIE['password'])) echo $_COOKIE['password']; ?>"/>
    <br>
    <select  class="form-control" name="servername" required id="Allserver">
    <!--<option value="" selected>Select server name</option>-->
    </select>
    <br>
    <p style="padding-left:0px;">Remember Password:</p> 
		 <input type="checkbox" id="remember" name="remember" <?php if(isset($_COOKIE['username'])){echo "checked='checked'"; } ?> value="1"   style="float: left;
    margin-left: 150px; margin-top: -25px; width: 20px; height: 15px;" /> 
    <br>    
    <input type="submit" name="submit"  id="login_send" value="Sign In" style="margin-left:120px;" class="btn btn-primary" >  
    </div>
<!--<div id="login" class="btn btn-primary">login </div>
<div id="NewOreder" class="btn btn-primary">NewOreder </div>-->
      </div><!-- /.login-box-body -->
    </div>
    </section><!-- /.content -->
  </div>
</div><!-- ./Login -->  

<style>
@media screen and (max-width:470px) {
.content{
margin-top:100px;
}
}
</style>

    <div class="wrapper" id="allwrapper">
       

<!-- Start Market -->
<div id="Market" style="display:none">      
      <?php include("main-header.php"); ?>
      <?php include("main-sidebar.php"); ?>
      <div class="content-wrapper">
         <section class="content-header">
         <!-- <h1>Market Watch</h1>-->
          
         </section>
        <!-- Main content -->
        <section class="content" style="margin-top:-22px;">
  
	<script type="text/javascript" src="dist/js/jquery-ui-1.8.18.custom.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie.min.js"></script>

    <div id="SymFeed"></div>
                 
                
 <input type="hidden" name="totalsambolPur" id="totalsambolPur" value="" />
<script>

$(document).ready(function() {
	websocket3 = new WebSocket("ws://108.175.9.76:9061/test"); //uri;
	console.log('Connecting to: ' + "ws://108.175.9.76:9061/test");

    websocket3.onopen = function () {
        $('#messages').prepend('<div>Connected.</div>');
		console.log('Connected');

	var senddata = {"request":1,"msgtype":75};
       websocket3.send(JSON.stringify(senddata));
       console.log('Send');

    };            

		websocket3.onclose = function () {
			$('#messages').prepend('<div>Closed.</div>');
			console.log('Closed');
		};
	
    websocket3.onerror = function (event) {
        $('#messages').prepend('<div>ERROR</div>');
    };
    // this method is called when chart is first inited as we listen for "dataUpdated" event
    // NZDUSD,0.791,0.805,08/14/2013 13:17:48.421
    websocket3.onmessage = function (event) {onmsg(event); }
	

});

function connectionclose()
{
//alert('ccccccc');
 //if (websocket) {
	//websocket.close();
	console.log("Connection Closed");
	window.location.href='logout.php';
	//}
} 



function onmsg(event){
//    var str = event.data.toString();
    var str1 = event.data;
	str=JSON.parse(str1);
 // alert(str);
//console.log('Server='+str.Server);
//if(str.Server==<?php //echo $_SESSION['servername']; ?>){
if(str.Server==12){
//console.log('Serverif='+str.Server);

for(i=0;i<str.NoOfRecords;i++)
{
    //console.log(str.DataFeed[i]);  


        var symbol = str.DataFeed[i].symbol;
        var Bid= str.DataFeed[i].bid;        
        var Ask  = str.DataFeed[i].ask;
		var HIGH = str.DataFeed[i].high;
		var LOW = str.DataFeed[i].low;

        var hashSymbol = symbol + "#Symbol";
        var hashBid = symbol + "Bid";
        var hashMid = symbol + "Mid";
        var hashAsk = symbol + "Ask";
        var hashDate = symbol + "DateTime";
		var hashcontr = symbol + "#cnt";
 		var hashopen1 =  symbol + "open1";
		var hashhigh =  symbol + "high";
		var hashlow =  symbol + "low";
		var hashclose =  symbol + "close";
		//console.log('Bid='+hashBid+'Value='+Bid); 
//console.log(hashBid+'Value='+Bid); 

document.getElementById(hashhigh).innerHTML = HIGH.toFixed(3);
document.getElementById(hashlow).innerHTML = LOW.toFixed(3);

 if(document.getElementById(hashBid))
            {
				var buy_price = document.getElementById(hashBid).innerHTML;
			    buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = Bid * 100;
				//console.log('Prabhat='+v_Buy+" "+ v2_buy); 
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashBid).style.color = '#FFFFFF';
					document.getElementById(hashBid).style.backgroundColor = '#FF0000';
				}
                else if (v_Buy < v2_buy)
                {
                    document.getElementById(hashBid).style.color = '#FFFFFF';
					document.getElementById(hashBid).style.backgroundColor = '#2FC72F';
                }
                else if (v_Buy == v2_buy)
                {
					document.getElementById(hashBid).style.color = '#FFFFFF';
					document.getElementById(hashBid).style.backgroundColor = '#4E5761';
                }
            }
			
 if(document.getElementById(hashAsk))
            {
				var buy_price = document.getElementById(hashAsk).innerHTML;
				//$('#price').val(buy_price);
			    //console.log('buy_price='+buy_price);
				buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = Ask * 100;
				//console.log('Prabhat='+v_Buy+" "+ v2_buy); 
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashAsk).style.color = '#FFFFFF';
					document.getElementById(hashAsk).style.backgroundColor = '#FF0000';
				}
                else if (v_Buy < v2_buy)
                {
                    document.getElementById(hashAsk).style.color = '#FFFFFF';
					document.getElementById(hashAsk).style.backgroundColor = '#2FC72F';
                }
                else if (v_Buy == v2_buy)
                {
					document.getElementById(hashAsk).style.color = '#FFFFFF';
					document.getElementById(hashAsk).style.backgroundColor = '#4E5761';
                }
            }
			
 if(document.getElementById(hashMid))
            {
				var buy_price = document.getElementById(hashMid).innerHTML;
			    buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = Mid * 100;
				//console.log('Prabhat='+v_Buy+" "+ v2_buy); 
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashMid).style.color = '#FF0000';
				}
                else if (v_Buy < v2_buy)
                {
                    document.getElementById(hashMid).style.color = '#00FF00';
                }
                else if (v_Buy == v2_buy)
                {
					document.getElementById(hashMid).style.color = '#FFFFFF';
					document.getElementById(hashMid).style.backgroundColor = '#4E5761';
                }
            }

			
document.getElementById(hashBid).innerHTML = Bid.toFixed(3);
document.getElementById(hashAsk).innerHTML = Ask.toFixed(3);
document.getElementById(hashMid).innerHTML = Mid.toFixed(3);

document.getElementById(hashclose).innerHTML = CLOSE.toFixed(5);

 var totolupn=0;
			if(document.getElementById(hashcontr))
            {
			   // var hashcontr = name + "#cnt";			  
			   var row = document.getElementById(hashcontr);			  
			   var Cells = row.getElementsByTagName("td");               
			  
			   var Qty1=Cells[2].innerText;  
			   var AvgPriceeq=Cells[0].innerText;
			   var ordSidetrd=Cells[1].innerText;
			   var ordContract=Cells[3].innerText;
			   console.log('1='+ordContract);
			   var Contsize2=parseInt(sessionStorage.getItem(symbol));
			   console.log('2='+Contsize2);
			   if(ordSidetrd="BUY"){
			   var eqtyBlanc=Qty1*(Bid-AvgPriceeq)*Contsize2;
			   }if(ordSidetrd="SELL"){
			   var eqtyBlanc=Qty1*(AvgPriceeq-Ask)*Contsize2;
			   }
			   // console.log('Prabhat1='+eqtyBlanc);
			   // var balnc=document.getElementById(equitibal1).innerHTML;
			   // console.log(balnc);
			   var blnce = parseFloat(sessionStorage.getItem("acBalance"));
			   var Eqtybl=blnce+eqtyBlanc;
			   
			   console.log('balance='+blnce+' eqtyBalaance='+eqtyBlanc);
			   var totolupn = totolupn + eqtyBlanc;
			   //var totolupn =  eqtyBlanc;
				
			}
setTimeout(	function() 
				{
				var UsedMarginval=sessionStorage.getItem("usedMargin");
				var v1=UsedMarginval;
				var v2=Eqtybl;
				var useMr=(parseFloat(v2)-parseFloat(v1));

				if(isNaN(useMr)){ useMr=UsedMarginval; }
				if(isNaN(Eqtybl)){ Eqtybl=blnce; }
				if(Eqtybl=='null'){ Eqtybl=blnce; }

				$('#equitibal1').text(Eqtybl);
				$('#frmargin').text(parseFloat(useMr));
				$('#upnid').text(totolupn);
				}, 1000);	 
    }
} // End For loop
} // End If Loop
</script>

       
<script src="dist/js/app.min.js" type="text/javascript"></script>
  
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
</div><!-- ./Market -->  

<!--Start Opentrade -->
<div id="Opentrade" style="display:none">
      <?php include("main-header.php"); ?>
      <?php include("main-sidebar.php"); ?>

<div class="content-wrapper">
         <section class="content-header">
          <h1>Trade History</h1>
         </section>
        <!-- Main content -->
        <section class="content" style="margin-top:-15px;">
 		<!--<h1>Opentrade</h1>-->
		  <!--<p id="onclick">Popup</p>-->
          <!--<div id="tradehistry"></div>-->   
              
        <table class="OpenOrdersCSS" border="0" width="100%" id="tradehistry" >
            <tbody><tr class="info"><td colspan="2" class="responsive" style="display:none;">Trade History</td></tr></tbody>
            </table>
      </section><!-- /.content -->
      </div>
</div><!-- ./Opentrade -->  

<!--Start Open order -->
<div id="Openorder" style="display:none">
      <?php include("main-header.php"); ?>
      <?php include("main-sidebar.php"); ?>

<div class="content-wrapper">
         <section class="content-header">
         
         </section>
        
        <section class="content" style="margin-top:-15px;">
 		<!--<h1>Order History</h1>-->
        <table class="OpenOrdersCSS" border="0" width="100%" id="orderhistry"  >
 			<tbody><tr class="info"><td colspan="3" class="responsive" style="display:none;">Order History</td></tr></tbody>
  		</table>  
  
        	 <!--<div id="orderhistry"></div>-->
             
		</section>
      </div>
</div><!-- ./Opentrade -->  
 

<!--Start History  -->
<div id="History" style="display:none">
      <?php include("main-header.php"); ?>
      <?php include("main-sidebar.php"); ?>

<div class="content-wrapper">
         <section class="content-header">
         <!-- <h1>Order History</h1>-->
         </section>
        <!-- Main content -->
        <section class="content" style="margin-top:-15px;">
 		<!--<h1>History</h1>-->
        <table class="OpenOrdersCSS" border="0" width="100%" id="infradayhistry"  >
 			<tbody><tr class="info"><td colspan="3" class="responsive" style="display:none;">Order History</td></tr></tbody>
  		</table> 
        <!--<div id="infradayhistry"></div>-->
		
        </section><!-- /.content -->
      </div>
</div><!-- ./Opentrade -->  





<!--Start Accounts -->
<div id="Account" style="display:none">
      <?php include("main-header.php"); ?>
      <?php include("main-sidebar.php"); ?>

<div class="content-wrapper">
         <section class="content-header">
         <!-- <h1>Market Watch</h1>-->
          
         </section>
        <!-- Main content -->
        <section class="content" style="margin-top:-15px;">
 		<!--<h1>Account Info</h1>-->
	<table class="OpenTradeAccountsCSS" border="0" width="100%" id="accountinfo">
		<tbody><tr class="bg-warning"><td colspan="2" class="responsive" style="display:none;">Account Information</td></tr></tbody>
    </table>
  
        </section><!-- /.content -->
      </div>
</div>

<div id="Chart" style="display:none">
      <?php include("main-header.php"); ?>
      <?php include("main-sidebar.php"); ?>

<div class="content-wrapper">
         <section class="content-header">
          <!--<h1>Chart</h1>-->
          
         </section>
        <!-- Main content -->
        <section class="content" style="margin-top:-15px;">
 		<!--<h1>Chart</h1>-->
<script language="javascript" type="text/javascript"> 

/*$(document).ready(function() {
	websocket2 = new WebSocket("ws://108.175.9.76:9051/test"); //uri;
    websocket2.onopen = function () {
	var senddata = {"Server":'12',"msgtype":81};
       websocket2.send(JSON.stringify(senddata));
       console.log('Send');
    };            
    websocket2.onmessage = function (event) {	onmsg2(event); }
});

function onmsg2(event){
    var str1 = event.data;
	str2=JSON.parse(str1);
	//console.log(str2);
	for(i=0;i<str2.NoOfRecords;i++)
	{
		console.log(str2.SymbolInfo[i].symbol);  
		var sy2 = str2.SymbolInfo[i].symbol;
		
	}	
} */
</script>  <h2>WebSocket For Send Order</h2>  
	<!--<img src="images/chartimage.png" width="100%" height="100%">-->
        </section><!-- /.content -->
      </div>
</div>


<!-- ./POP UP Start -->

 <!-- Modal Feed-->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
      <div class="modal-content" style="margin-top:60px;">
      <div class="modal-header">
      <form role="form" action="weblogin.php">
     <div id="m2" style="display:none;">Sent</div>
    <div style="text-align:center">
       <label>BUY:&nbsp;&nbsp;&nbsp;</label><input type="radio"  name="side" class="side" value="1" checked>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <label>SELL:&nbsp;&nbsp;&nbsp;</label><input type="radio"  name="side" class="side" value="2">
         </div>
   
       <label>Contract Name:</label>
      <input type="text" class="form-control"  name="symble" value="" id="symbol2" placeholder="Enter Contract Name">
       
	<br />
      <label>Order Type:</label>
     <select  class="form-control" name="market" id="market">
        <option value="MARKET">Market</option> 
        <option value="LIMIT">Limit</option>
        <option value="STOP">Stop</option>
        <option value="STOPLIMIT">Stop Limit</option>        
      </select>      
	<br />

      <label for="Quantity">Quantity:</label>
      <input type="text" class="form-control" name="quantity" id="quantity" placeholder="Enter Quantity" value="1">
    <br />

      <label for="Price">Price:</label><br>
      
    <input type="button" id="minus" value="-" onClick="price.value = (price.value-1)" style="float:left; width:10%;height: 34px;">
  	<div  style="width:75%;margin-left:12.5%;"> <input type="text" class="form-control" name="price" id="price" > </div>
    <input type="button" value="+"  onClick="price.value = (+price.value+1)" style="float:right; margin-top:-34px; width:10%;height: 34px;" >
    
   <!-- <input type="hidden" name="side" id="side" />-->
    <input type="hidden" name="contractsize" id="contractsize" />
    <input type="hidden" name="stoplbllimit" id="stoplbllimit" />
    <input type="hidden" name="digit" id="digit" />
    <input type="hidden" name="Bitprice" id="Bitprice" />
<br />

	<div id="trigpric" style="display:none;">
    <label for="Triger">Trigger Price:</label>
    <input type="text" class="form-control" name="trigger" id="trigger" placeholder="Enter Triger Price">
    </div>
<br>      
<div align="center">
      <input type="button" id="neworder" class="btn btn-success bg-success" value="Place Order">
      <input type="button" id="closepopup"  class="btn btn-success bg-success" data-dismiss="modal" value="Cancel" style=" margin-left:50px;background-color: #9E401B; color:#FFFFFF;">
</div>
</form>
        </div>
      </div>
    </div>
  </div>
  <!--End Model -->
  <!-- Start Modify --> 
<div class="modal fade" id="ModifyModal" role="dialog">
    <div class="modal-dialog">
      <div class="modal-content" style="margin-top:60px;">
      <div class="modal-header">
      <form role="form">
    
   <div style="text-align:center;font-size: 20px;">Modify Order</div>
       <label>Contract Name:</label>
      <input type="text" class="form-control" name="msymble" id="msymble" readonly="readonly">
       
	<br />
      <label>Order Type:</label>
     <input type="text" class="form-control" name="mmarket" id="mmarket" readonly="readonly" >
    <!-- <select class="form-control" name="mmarket" id="mmarket">
        <option value="MARKET">Market</option> 
        <option value="LIMIT">Limit</option>
        <option value="STOP">Stop</option>
        <option value="STOPLIMIT">Stop Limit</option>        
      </select> -->       
	<br />

      <label for="Quantity">Quantity:</label>
      <input type="text" class="form-control" name="mquantity" id="mquantity" value="1" >
    <br />

      <label for="Price">Price:</label><br>
      
    <input type="text" class="form-control" name="mprice" id="mprice" >
     <input type="hidden" name="mside" id="mside" />
    <input type="hidden" name="mcontractsize" id="mcontractsize" />
    <input type="hidden" name="mstoplbllimit" id="mstoplbllimit" />
    <input type="hidden" name="mdigit" id="mdigit" />
    <input type="hidden" name="oldAccount" id="oldAccount" />
    <input type="hidden" name="oldsymble" id="oldsymble" />
    <input type="hidden" name="oldquantity" id="oldquantity" />
    <input type="hidden" name="oldclorderid" id="oldclorderid" />
    <input type="hidden" name="oldproducttype" id="oldproducttype" />
    <input type="hidden" name="oldproduct" id="oldproduct" />
    <input type="hidden" name="oldcontract" id="oldcontract" />
    <input type="hidden" name="oldgateway" id="oldgateway" />
    <input type="hidden" name="oldordertype" id="oldordertype" />
    <input type="hidden" name="oldprice" id="oldprice" />
    <input type="hidden" name="oldside" id="oldside" />
    <input type="hidden" name="oldtimeinforce" id="oldtimeinforce" />
    <input type="hidden" name="oldstoppx" id="oldstoppx" />
    <input type="hidden" name="oldorderid" id="oldorderid" />
    <input type="hidden" name="oldorignalclordid" id="oldorignalclordid" />
    <input type="hidden" name="oldpositioneffect" id="oldpositioneffect" />
    
   <br />

	<div id="trigpric" style="display:none;">
    <label for="Triger">Trigger Price:</label>
     <input type="text" class="form-control" name="mtrigger" id="mtrigger" placeholder="Enter Triger Price">
    </div>
<br>      
<div align="center">
<input type="button" id="Modifyorder" class="btn btn-success bg-success" value="Modify Order">
<input type="button" id="closepopup2"  class="btn btn-success bg-success" data-dismiss="modal" value="Cancel" style=" margin-left:50px;background-color: #9E401B; color:#FFFFFF;">
</div>
</form>
        </div>
      </div>
    </div>
  </div>
<!-- ./Modify End -->     
<!-- ./POP UP End --> 
 
<script>
function Corder(OrdId) {
        var t = document.getElementById('orderhistry');
        var rows = t.rows; //rows collection - https://developer.mozilla.org/en-US/docs/Web/API/HTMLTableElement
        for (var i=0; i<rows.length; i++) {
            rows[i].onclick = function (event) {
                //event = event || window.event; // for IE8 backward compatibility
                //console.log(event, this, this.outerHTML);
                if (this.parentNode.nodeName == 'THEAD') {
                    return;
                } 
                var cells = this.cells; //cells collection
                var tdAccount = cells[2].innerHTML;
                //console.log(tdAccount);
                var tdOrderQty = cells[3].innerHTML;                                
                var tdClOrdId = cells[4].innerHTML;
                var tdProductType = cells[5].innerHTML;
                var tdProduct  = cells[6].innerHTML;
                var tdContract = cells[7].innerHTML;
                var tdGateway = cells[8].innerHTML;
                var tdOrderType = cells[9].innerHTML;                
                var tdPrice = cells[10].innerHTML;
                var tdSide = cells[11].innerHTML;
                var tdTimeInForce = cells[12].innerHTML;
                var tdStopPx = cells[13].innerHTML;
                var tdOrderID = cells[14].innerHTML;
                var tdorigClOrdId = cells[15].innerHTML;                
                var tdPositionEffect = cells[16].innerHTML;            
            //alert(tdContract);    
			cancelOrder(tdAccount,tdOrderQty,tdClOrdId,tdProductType,tdProduct,tdContract,tdGateway,tdOrderType,tdPrice,tdSide,tdTimeInForce,tdStopPx,tdOrderID,tdorigClOrdId,tdPositionEffect);
            };
        }
        
    }
function Modify(OrdId) {
        var tm = document.getElementById('orderhistry');
        var rowsm = tm.rows; //rows collection - https://developer.mozilla.org/en-US/docs/Web/API/HTMLTableElement
        for (var i=0; i<rowsm.length; i++) {
            rowsm[i].onclick = function (event) {
                //event = event || window.event; // for IE8 backward compatibility

                //console.log(event, this, this.outerHTML);
                if (this.parentNode.nodeName == 'THEAD') {
                    return;
                }
                var mcells = this.cells; //cells collection
                var mtdAccount = mcells[2].innerHTML;
                console.log(mtdAccount);
                var mtdOrderQty = mcells[3].innerHTML;                                
                var mtdClOrdId = mcells[4].innerHTML;
                var mtdProductType = mcells[5].innerHTML;
                var mtdProduct  = mcells[6].innerHTML;
                var mtdContract = mcells[7].innerHTML;
                   mtdContract=mtdContract.trim();
                var mtdGateway = mcells[8].innerHTML;
                var mtdOrderType = mcells[9].innerHTML;
                    mtdOrderType=mtdOrderType.trim();
                var mtdPrice = mcells[10].innerHTML;
                var mtdSide = mcells[11].innerHTML;
                mtdSide=mtdSide.trim();
                var mtdTimeInForce = mcells[12].innerHTML;
                var mtdStopPx = mcells[13].innerHTML;
                var mtdOrderID = mcells[14].innerHTML;
                var mtdorigClOrdId = mcells[15].innerHTML;                
                var mtdPositionEffect = mcells[16].innerHTML;    
                var mContsize=parseInt(sessionStorage.getItem(mtdContract));
                var mDigi=mtdContract+ "#digit";
                mDigi=parseInt(sessionStorage.getItem(mDigi));
				var hash1Bid = mtdContract + "Bid";                
                var hash1Ask = mtdContract + "Ask";
				/*var bid_price1 = document.getElementById(hash1Bid).innerHTML;
				var ask_price1 = document.getElementById(hash1Ask).innerHTML;
				console.log(bid_price1);
				console.log(ask_price1);*/
				
                var ordType='';
                if(mtdOrderType==1)
                   {
                   ordType="MARKET";
                   } 
                   else if(mtdOrderType==2)
                   {
                    ordType="LIMIT";
                   }
                   else if(mtdOrderType==3)
                   {
                     ordType="STOP";
                   }
                   else
                   {
                     ordType="STOPLIMIT";
                   }
                
                $('#oldAccount').val(mtdAccount);
                $('#oldquantity').val(mtdOrderQty);
                $('#oldclorderid').val(mtdClOrdId);
                $('#oldproducttype').val(mtdProductType);
                $('#oldproduct').val(mtdProduct); 
                $('#oldcontract').val(mtdContract);
                $('#oldgateway').val(mtdGateway);
                $('#oldordertype').val(mtdOrderType);
                $('#oldprice').val(mtdPrice);
                $('#oldside').val(mtdSide);
                $('#oldtimeinforce').val(mtdTimeInForce);
                $('#oldstoppx').val(mtdStopPx); 
                $('#oldorderid').val(mtdOrderID);
                $('#oldorignalclordid').val(mtdorigClOrdId);
                $('#oldpositioneffect').val(mtdPositionEffect);
                $('#mside').val(mtdSide); 
                $('#mcontractsize').val(mContsize); 
                $('#msymble').val(mtdContract);
                $('#mmarket').val(ordType);
                $('#mdigit').val(mDigi);
				/*$('#mprice').val(mtdPrice);
                $('#mquantity').val(mtdOrderQty);*/
                

                /*$("#modifyOrderform").css({ display: "block" });    
                $("#orderform").css({ display: "none" });                
                $("#acountinfo").css({ display: "none" });
                $("#posinfo").css({ display: "none" });    
                $("#span4").css({ display: "none" });                
                $("#ordrhisinfo").css({ display: "none" });
                $("#trdhisinfo").css({ display: "none" });*/
 
            };
        }
        
    }

</script>  
      <?php //include("main-footer.php"); ?>
     
    </div><!-- ./wrapper -->
  </body>
</html>