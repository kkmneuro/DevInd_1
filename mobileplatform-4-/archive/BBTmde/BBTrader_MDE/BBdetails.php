<?php
session_start();
//print_r($_SESSION);
error_reporting(0);
ini_set("display_errors", 1);
$userId=2365;
$token="gu8lsuwnff";
?>
<?php include("inc/header_trade.php");
include("config.php");

?>
<?php
echo '<script type="text/javascript">var mytoken = "'.$token.'";</script>';
?>
<?php echo '<script type="text/javascript">var mytoken= "'.$token.'";</script>'; ?>



<!-- Bootstrap Core CSS -->
    <link href="bb-trader/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="bb-trader/css/agency.css" rel="stylesheet">    
    <!-- Custom Fonts -->
    <link href="bb-trader/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href='http://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

<link rel="stylesheet" href="bb-trader/custom.css">


<script type="text/javascript" src="bb-trader/websocktest.js"></script>



<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie.min.js"></script>

<script>
////////
window.onload = function(){
	login();
   	//connect();
}
 /*$(window).load(function () {
 	$("#login_send").trigger('click');
	//$('#login_send').click();
})*/
////////
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
                /*$('#mquantity').val(mtdOrderQty);
                $('#mprice').val(mtdPrice);*/
                
                
                $("#modifyOrderform").css({ display: "block" });    
                $("#orderform").css({ display: "none" });                
                $("#acountinfo").css({ display: "none" });
                $("#posinfo").css({ display: "none" });    
                $("#span4").css({ display: "none" });                
                $("#ordrhisinfo").css({ display: "none" });
                $("#trdhisinfo").css({ display: "none" });
 
            };
        }
        
    }
</script>
<script type="text/javascript">
   $(document).ready(function(){
    $('#LowerDiv').sortable({ axis: "y",
       placeholder: "sortable-placeholder", update:updateSymbolOrder
    });
    
    $('#market').change(function() {
    $('#trigpric').css('display', ($(this).val() == 'STOP'||$(this).val() == 'STOPLIMIT') ? 'block' : 'none');
    });
    
    //$('#LowerDiv').click(function(e){
   // alert($(e.target).text()); // using jQuery
   //});
   $(".context-menu-one").click(function() { 
   var $row = $(this).closest("tr");        // Finds the closest row <tr> 
   var $tdsymb = $row.find("td:nth-child(1)");
   var $tdgateway = $row.find("td:nth-child(2)"); // Finds the 2nd <td> element
   var $tdproduct = $row.find("td:nth-child(5)");
   var $tddigit = $row.find("td:nth-child(6)");
   var $tdbid = $row.find("td:nth-child(8)"); // Finds the 2nd <td> element
   var $tdask = $row.find("td:nth-child(9)");
   var $tdcntsize = $row.find("td:nth-child(11)");
   var $tdstopllmt = $row.find("td:nth-child(12)");
   
    $.each($tdcntsize, function() {                // Visits every single <td> element
    var tdcontsize=$(this).text();         // Prints out the text within the <td>
    sessionStorage.setItem("contsize", tdcontsize);
    });
    
    $.each($tdstopllmt, function() {                // Visits every single <td> element
    var tdstoplblmt=$(this).text();         // Prints out the text within the <td>
    sessionStorage.setItem("stoplblmt", tdstoplblmt);
    });
    
     $.each($tdbid, function() {                // Visits every single <td> element
    var bidpr=$(this).text();         // Prints out the text within the <td>
    sessionStorage.setItem("bidpr", bidpr);
    });
    $.each($tdgateway, function() {                // Visits every single <td> element
    var tdgway=$(this).text();         // Prints out the text within the <td>
     sessionStorage.setItem("tdgtwy", tdgway);
    });
    $.each($tddigit, function() {                // Visits every single <td> element
    var tddgit=$(this).text();         // Prints out the text within the <td>
     sessionStorage.setItem("tddgt", tddgit);
    });
    $.each($tdproduct, function() {                // Visits every single <td> element
    var tdprduct=$(this).text();         // Prints out the text within the <td>
     sessionStorage.setItem("tdprdct", tdprduct);
    });
    $.each($tdask, function() {                // Visits every single <td> element
    var askpr=$(this).text();         // Prints out the text within the <td>
     sessionStorage.setItem("askpr", askpr);
    });
    
    $.each($tdsymb, function() {                // Visits every single <td> element
    var tdsymbol=$(this).text();         // Prints out the text within the <td>
    sessionStorage.setItem("tdsymbol", tdsymbol);
    });

        
   });
   

});

function updateSymbolOrder(){
    var newstr="";
    var xx=0;
    $('#myTable tr').each(function() {
      //var customerId = $(this).find(".customerIDCell").html();
       if($(this).find('td:eq(0)').text()!=""){
           if(xx==0){
               newstr=$(this).find('td:eq(0)').text();
           }
           else{
               newstr=newstr+","+$(this).find('td:eq(0)').text();
           }
           xx++;
         }
     });

     $("#totalsambolPur").val(newstr);
        /* $.ajax({
                url: "userhistory.php",
                type: 'POST',
                data: {id: <?php echo $userId;?>,sub_id:<?php echo $subsDetail['level_id'];?>,symbol_str:newstr, action: 'ChangeOrder'},
                dataType: 'html',
                success: function(data) {
                    //alert(data+newstr);
                }
          });*/
     //alert(newstr);
}
function buyOrder()
{    
    var tdsymbol = sessionStorage.getItem("tdsymbol");
	//alert(tdsymbol);
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
function sellOrder()
{    
    var tdsymbol = sessionStorage.getItem("tdsymbol");
    var bidpr = sessionStorage.getItem("bidpr");
    var askpr = sessionStorage.getItem("askpr");
    var tddigit = sessionStorage.getItem("tddgt");
    var tdproduct = sessionStorage.getItem("tdprdct");
    var tdgateway = sessionStorage.getItem("tdgtwy");
    var contrctsize = sessionStorage.getItem("contsize");
    var stoplbllmt = sessionStorage.getItem("stoplblmt");
    var sSide=2;
    $('#side').val(sSide);
    $('#symble').val(tdsymbol);
    $('#digit').val(tddigit);
    $('#price').val(bidpr);
    $('#side').val("2"); 
    $('#contractsize').val(contrctsize);
    $('#stoplbllimit').val(stoplbllmt);
    $("#span4").css({ display: "none" });     
    $("#orderform").css({ display: "block" });
    $("#neworder").css({ background: "red"});
    $("#modifyOrderform").css({ display: "none" });
}
</script>
<script>
// For header heading text on all pages
$(document).ready(function(){
	//Market();
$("#account").click(function(){
$(".test1").text("Account Info");
});

$("#orderhis").click(function(){
$(".test2").text("Order Info");
});

$("#tradeHis").click(function(){
$(".test3").text("Positions");
});

$("#protFL").click(function(){
$(".test5").text("Portfolio");
});

$("#Intraday").click(function(){
$(".test6").text("Intraday");
});

});
</script>
</head>
<script type="text/javascript">
$(window).load(function() {
    $(".loader").fadeOut("slow");
})

function checkDec(el,ln){
 var ex = /^[0-9]+\.?[0-9]*$/;
 if(ex.test(el.value)==false){
   el.value = el.value.substring(0,el.value.length - 1);
  }else{
    var arr = el.value.split('.');
    var length = 0;
    if(arr.length > 1)
    {
        length = arr[1].length;
    }
    if(length > ln)
    {
        el.value = el.value.substring(0,el.value.length - 1);
        //alert("Max 2 decimal place");
    }
  }
}

function decimalpoint(id,valuew)
{
    if(valuew!='')
    {
        var arr = valuew.split('.');
        if(arr.length == 1)
        {
            $('#'+id).val(valuew+'.00');
        }
        else if(arr.length > 1)
        {
            if(arr[1].length == 1)
            {
                $('#'+id).val(valuew+'0');
            }
        }
    }
}

<!-- function for Account Info -->
function Account() // no ';' here
{
    var acount = document.getElementById("account");
        
        $("#span4").css({ display: "none" });
        $("#posinfo").css({ display: "none" });
        $("#orderform").css({ display: "none" });
        $("#acountinfo").css({ display: "block" });
        $("#trdhisinfo").css({ display: "none" });
        $("#ordrhisinfo").css({ display: "none" });        
        $("#modifyOrderform").css({ display: "none" });
		$("#Portfolioinfo").css({ display: "none" });
		$("#intradayinfo").css({ display: "none" });          
                    
}

<!-- function for display Market view-->
function Market() // no ';' here
{
    var market = document.getElementById("marketview");
   
    $(".test4").text("Market Watch");
	$("#orderform").css({ display: "none" });                
    $("#acountinfo").css({ display: "none" });
    $("#posinfo").css({ display: "none" });    
    $("#span4").css({ display: "block" });
    $("#trdhisinfo").css({ display: "none" });
    $("#ordrhisinfo").css({ display: "none" });    
    $("#modifyOrderform").css({ display: "none" });
	$("#Portfolioinfo").css({ display: "none" }); 
	$("#intradayinfo").css({ display: "none" });                    
                    
}
function orderPosition() // no ';' heretradeHis
{
    var market = document.getElementById("position");
    
    $("#orderform").css({ display: "none" });                
    $("#acountinfo").css({ display: "none" });
    $("#posinfo").css({ display: "block" });    
    $("#span4").css({ display: "none" });
    $("#trdhisinfo").css({ display: "none" });
    $("#ordrhisinfo").css({ display: "none" });
    $("#modifyOrderform").css({ display: "none" });
	$("#Portfolioinfo").css({ display: "none" });     
    $("#intradayinfo").css({ display: "none" });                
                    
}

function tradeHis() // no ';' here
{
    var market = document.getElementById("tradehis");
    
    $("#orderform").css({ display: "none" });                
    $("#acountinfo").css({ display: "none" });
    $("#posinfo").css({ display: "none" });    
    $("#span4").css({ display: "none" });
    $("#trdhisinfo").css({ display: "block" });
    $("#ordrhisinfo").css({ display: "none" });
    $("#modifyOrderform").css({ display: "none" });
	$("#Portfolioinfo").css({ display: "none" }); 
    $("#intradayinfo").css({ display: "none" });
}
function orderHis() // no ';' here
{
    var market = document.getElementById("orderhis");
    
    $("#orderform").css({ display: "none" });                
    $("#acountinfo").css({ display: "none" });
    $("#posinfo").css({ display: "none" });    
    $("#span4").css({ display: "none" });                
    $("#ordrhisinfo").css({ display: "block" });
    $("#trdhisinfo").css({ display: "none" });
    $("#modifyOrderform").css({ display: "none" }); 
	$("#Portfolioinfo").css({ display: "none" });       
    $("#intradayinfo").css({ display: "none" });                
}

function Portfolio() // no ';' here
{
    var protfl = document.getElementById("protfl");
    
    $("#orderform").css({ display: "none" });                
    $("#acountinfo").css({ display: "none" });
    $("#posinfo").css({ display: "none" });    
    $("#span4").css({ display: "none" });                
    $("#ordrhisinfo").css({ display: "none" });
    $("#trdhisinfo").css({ display: "none" });
    $("#modifyOrderform").css({ display: "none" });        
    $("#Portfolioinfo").css({ display: "block" });
	$("#intradayinfo").css({ display: "none" });                 
}

function intraday() // no ';' here
{
    var protfl = document.getElementById("protfl");
    
    $("#orderform").css({ display: "none" });                
    $("#acountinfo").css({ display: "none" });
    $("#posinfo").css({ display: "none" });    
    $("#span4").css({ display: "none" });                
    $("#ordrhisinfo").css({ display: "none" });
    $("#trdhisinfo").css({ display: "none" });
    $("#modifyOrderform").css({ display: "none" });        
    $("#Portfolioinfo").css({ display: "none" });
	$("#intradayinfo").css({ display: "block" });                
}





var UN = sessionStorage.getItem("UserName");
var PS = sessionStorage.getItem("PASS");
function logout()
{
		    var favorite = [];
            $.each($("input[name='port']:checked"), function(){            
                favorite.push($(this).val());
            });
			
				$.ajax({
						url: 'insert_symbol.php',
						type: 'POST',
						data: {var1: UN, var2: PS, var3: favorite},
						success: function(data) {
						//alert(data);
							console.log("success");
						}
    			});
websocket.onclose = function () {
        $('#messages').prepend('<div>Closed.</div>');
    };			
//alert('hi');
window.location.href = "http://78.47.54.100/BBTrader.php";
//window.location.href = "http://localhost/BBTrader_MDE/BBTrader.php";
//window.location.reload();	
}


var symboleContSize = {},symboles=[];


</script>
<html>
<body>
<center>

<script>
$(window).load(function(){
  $('#dvLoading');
  //Market();
});

</script>
<style>
#dvLoading
{
   background:#000 url(loading.gif) no-repeat center center;
   height: 200px;
   width: 200px;
   position: fixed;
   z-index: 1000;
   left: 20%;
   top: 20%;
   margin: -25px 0 0 -25px;
}
</style>
<!--<div id="dvLoading"></div>-->


<!-- for webtrader login window-->

<!-- Login panel Start-->
<input type="hidden" name="username" id="username" value="<?php echo $_SESSION['username']; ?>" />
<input type="hidden" name="password" id="password" value="<?php echo $_SESSION['password']; ?>" />
<input type="hidden" name="remember" id="remember" value="<?php echo $_SESSION['remember']; ?>" />

        

<!--login panel end-->
 <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" id="acinfo" style="display:none;">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
               <a class="navbar-brand page-scroll test1 test2 test3 test4 test5 test6" href="#page-top">Market Watch</a>
               
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a href="#page-top"></a>

                    </li>
                   <li>
                        <a class="page-scroll" href="#index" name="market" id="marketview" onClick="Market()" >Market View</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#Account" name="account" id="account" onClick="Account()">Account Info</a>
                    </li>                   
                    <li>
                        <a class="page-scroll" href="#OrderBook" name="orderhis" id="orderhis" onClick="orderHis()">Order Info</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#OrderBook1" name="tradehis" id="tradeHis" onClick="tradeHis()">Positions</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#intraday" name="Intraday" id="Intraday" onClick="intraday()">Intraday</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#portfolio" name="protfl" id="protFL" onClick="Portfolio()">Portfolio</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#logout" name="log" id="log" onClick="logout()">Save Portfolio</a>
                    </li>
                    
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
<!--Order entry form panel start -->
<section id="orderform" class="bg-light-gray" style="display:none;">

<div class="container-fluid"  style="min-height:350px;">
<div class="col-lg-1" id="orderError" style="color:#ff0000;font-size:14px;">
<p></p>
</div>
<form role="form">
    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="name">Contract Name:</label>
      <input type="text" class="form-control" name="symble" id="symble" placeholder="Enter Contract Name">
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />

    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="order">Order Type:</label>
      
     <select class="form-control" name="market" id="market">
        <option value="MARKET">Market</option> 
        <option value="LIMIT">Limit</option>
        <option value="STOP">Stop</option>
        <option value="STOPLIMIT">Stop Limit</option>        
      </select>      
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />


    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="Quantity">Quantity:</label>
      <input type="text" class="form-control" name="quantity" id="quantity" placeholder="Enter Quantity" value="1">
      </div>
          <div class="col-lg-4"></div>
    </div><br />

    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="Price">Price:</label>
      <input type="text" class="form-control" name="price" id="price" placeholder="Enter Price">
    <input type="hidden" name="side" id="side" />
    <input type="hidden" name="contractsize" id="contractsize" />
    <input type="hidden" name="stoplbllimit" id="stoplbllimit" />
    <input type="hidden" name="digit" id="digit" />

    
    
    
    
    
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />

    <div class="row" id="trigpric" style="display:none;">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="Triger">Trigger Price:</label>
      <input type="text" class="form-control" name="trigger" id="trigger" placeholder="Enter Triger Price">
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />
    <div class="row">
    <div class="col-lg-5"></div>
    <div class="col-lg-2">
      <input type="button" id="neworder" class="btn btn-success bg-success" value="Place Order">
      </div>
          <div class="col-lg-5"></div>
    </div>
</form>

</div>
<!----------- end here second row-->
</section>
<!-- Order entry form panel end  -->

<!--Modify Order entry form panel start -->
<section id="modifyOrderform" class="bg-light-gray" style="display:none;">

<div class="container-fluid"  style="min-height:350px;">
<div class="col-lg-1" id="morderError" style="color:#ff0000;font-size:14px;">
<p></p>
</div>
<form role="form">
    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="name">Contract Name:</label>
      <input type="text" class="form-control" name="msymble" id="msymble" readonly="readonly">
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />

    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="order">Order Type:</label>
       <input type="text" class="form-control" name="mmarket" id="mmarket" readonly="readonly" >
    <!-- <select class="form-control" name="mmarket" id="mmarket">
        <option value="MARKET">Market</option> 
        <option value="LIMIT">Limit</option>
        <option value="STOP">Stop</option>
        <option value="STOPLIMIT">Stop Limit</option>        
      </select> -->     
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />

    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="Quantity">Quantity:</label>
      <input type="text" class="form-control" name="mquantity" id="mquantity" value="1" >
      </div>
          <div class="col-lg-4"></div>
    </div><br />

    <div class="row">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="Price">Price:</label>
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
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />

    <div class="row" id="trigpric" style="display:none;">
    <div class="col-lg-4"></div>
    <div class="col-lg-4">
      <label for="Triger">Trigger Price:</label>
      <input type="text" class="form-control" name="mtrigger" id="mtrigger" placeholder="Enter Triger Price">
      </div>
          <div class="col-lg-4"></div>
    </div>
<br />
    <div class="row">
    <div class="col-lg-5"></div>
    <div class="col-lg-2">
      <input type="button" id="Modifyorder" class="btn btn-success bg-success" value="Place Order">
      </div>
          <div class="col-lg-5"></div>
    </div>
</form>

</div>
<!----------- end here second row-->
</section>
<!-- Modify Order entry form panel end  -->






<!----------- end here second row-->
<!--Display Account info start -->
<section style="display:none;" id="acountinfo">
<div class="container-fluid">
<div class="row">
<div class="col-lg-12">
<table class="table table-hover table-responsive" border="1" width="100%" id="accountinfo">
 <tbody>
      <tr class="bg-warning">
        <td colspan="2" class="responsive" style="display:none;">Account Information</td> 
      </tr>     
</tbody>
  </table>
  
  </div>
  </div>
  </div>
  </section>
<!--Display Account info End -->

<!--Display position info start -->
 <section style="display:none;" id="posinfo">
<div class="container-fluid" style="min-height:200px;" >
<div class="row">
<div class="col-lg-12">

<table class="table table-hover table-responsive" border="1" width="100%" id="positioninfo">
 <tbody>
      <tr class="bg-warning">
        <td colspan="2" class="responsive" style="display:none;">Order Information</td>  
      </tr>     
</tbody>
  </table>
  
  </div>
  </div>
  </div>
  </section>
<!--Display Account info End -->
<!--Display Order History info start -->
<section style="display:none;" id="ordrhisinfo">
<div class="container-fluid"  >
<div class="row">
<div class="col-lg-12">

<table class="table table-hover table-responsive" border="1" width="100%" id="orderhistry"  >
 <tbody>
      <tr class="info">
        <td colspan="3" class="responsive" style="display:none;">Order History</td> 
      </tr>     
</tbody>
  </table>  
  </div>
  </div>
  </div>
   </section>
<!--Display Order History info End 

<!--Display Trade History info start -->
<section style="display:none;" id="trdhisinfo">
<div class="container-fluid" >
<div class="row">
<div class="col-lg-12">
<table class="table table-hover table-responsive" border="1" width="100%" id="tradehistry" >
 <tbody>
      <tr class="info">
        <td colspan="2" class="responsive" style="display:none;">Trade History</td> 
      </tr>     
</tbody>
  </table>
  
  </div>
  </div>
  </div>
  </section>
<!--Display Trade History info End -->


<!--Display Intraday start -->
<section style="display:none;" id="intradayinfo">
<div class="container-fluid" >
<div class="row">
<div class="col-lg-12">
<table class="table table-hover table-responsive" border="1" width="100%" id="infradayhistry" >
 <tbody>
      <tr class="info">
        <td colspan="2" class="responsive" style="display:none;">Intraday</td> 
      </tr>     
</tbody>
  </table>
  
  </div>
  </div>
  </div>
  </section>
<!--Display Intraday End -->


<!--Display Portfolio info start -->
<section style="display:none;" id="Portfolioinfo">
<div class="container-fluid" >
<div class="row">
<div class="col-lg-12">
<!---->


    <table class="table table-hover table-responsive" border="1" width="80%" id="myTable">
            <thead>
      <tr class="danger bg-danger">
        
        <th style="width:25%;">Assign</th><th width="75%">Symbols Name</th>
      </tr>
</thead>
		<?php
		
		/*echo "SELECT * FROM users where username='".$user1."' and password='".$pass1."' and symbols!=''";
        $qty13=mysql_query("SELECT * FROM users where username='".$user1."' and password='".$pass1."' and symbols!=''");
        $res13=mysql_fetch_array($qty13);*/
        //print_r($res13['symbols']);

        //$selectsymbol=explode(',',$res13['symbols']);
		 $selectsymbol=explode(',',$_SESSION['AllSymbols']);
       
	    //print_r($selectsymbol);
        
            $query6=mysql_query("select * from symbols");
            while($result=mysql_fetch_array($query6)){
            if(in_array($result['Symbol'],$selectsymbol)){
            ?>
            <tr id="tr_<?php echo trim($result['Symbol'])?>" class="info bg-info3" >
            <td  width="25%"> <input type="checkbox" checked="checked" name="port" value="<?php echo $result['Symbol']; ?>" style="width:15px; height: 15px; float:right;" /></td>
            <td width="75%"><?php echo $result['Symbol'];?></td>
              
            </tr>
            <?php } else { ?>
              
            <tr id="tr_<?php echo trim($result['Symbol'])?>" class="info bg-info3" >
            <td  width="25%"> <input type="checkbox" name="port" value="<?php echo $result['Symbol']; ?>" style="width:15px; height: 15px; float:right;" /></td>
              <td width="75%"><?php echo $result['Symbol'];?></td>
            </tr>
              
          <?php }
                } 
		?>
           
            
         </table>
         <!--<button type="button">Save Symbols</button>-->
 <!----> 
  </div>
  </div>
  </div>
  </section>
<!--Display Portfolio info End -->

<!--<div class="loader"></div>-->
<!-- wrapper star -->

<div id="wrapper">
 
 <?php
// include("contract.php");
//include("contract_users.php");
 ?>
  <!-- nav end -->
  <!-- container start -->
  <div id="container" style="padding-top:50px;">
 <!---->

<div id="outer" style="border:none;">
      <div class="span4" style="display:none;" id="span4">
          <div class="market_watch">
        <!--<div class="table_haeding_row">Market Watch <span id="market-watch-status" style="float:right; padding:0"> </span></div>-->
         <table class="table table-hover table-responsive" border="1" width="100%" id="myTable">
            <thead>
      <tr class="danger bg-danger">
        <th class="responsive2">
        
 Currency Pair</th><th class="responsive1">Bid</th><th class="responsive1">Ask</th><th class="responsive1">Ltp</th>
      </tr>
</thead>
<tbody id="LowerDiv" class="scrollContent">

             <?php
				$queryEmpty=mysql_query("TRUNCATE TABLE symbols");
                    // For Getting All Symbols from Contract
                    
					//$Arr=objectToArray($webService); 
					$Arr=$_SESSION['Arr'];       
                    
					    foreach ($Arr as $innerArray) {
                        //  Check type
                        if (is_array($innerArray)){
                        //  Scan through inner loop
                        foreach ($innerArray as $value) {
                        
                          if (is_array($value)){
                         
                          foreach ($value as $explodeSYB) { 
						  
						 /* echo '<pre>';
						  print_r($explodeSYB); 
						  echo '</pre>';*/
						  
						  $query=mysql_query("insert into symbols(Symbol,ContractSize,Digits,TradingGateway,SecurityTypeID,Source,InstruementID,LimitAndStopLevel)values('".trim($explodeSYB['Symbol'])."','".trim($explodeSYB['ContractSize'])."','".trim($explodeSYB['Digits'])."','".trim($explodeSYB['TradingGateway'])."','".trim($explodeSYB['SecurityTypeID'])."','".trim($explodeSYB['Source'])."','".trim($explodeSYB['InstruementID'])."','".trim($explodeSYB['LimitAndStopLevel'])."')"); 
						  } } } } }

						  
				/*$qty12=mysql_query("SELECT * FROM users where username='".$user1."' and password='".$pass1."' and symbols!=''");
				$res12=mysql_fetch_array($qty12);
				
				$num4=mysql_num_rows($qty12);*/
				//if($num4>0)
				if($_SESSION['AllSymbols']!='')
				{
					$sym2=explode(",",$_SESSION['AllSymbols']);
					//print_r($sym2);
					
					$num=count($sym2);
					for($i=0;$i<$num;$i++){
					
						$query8=mysql_query("select * from symbols where Symbol='".$sym2[$i]."'");
						$result8=mysql_fetch_array($query8);
					?>
                    
                    <script>
                    sessionStorage.setItem("<?php echo $sym2[$i]; ?>", <?php echo $result8['ContractSize'];?>);
                    sessionStorage.setItem("<?php echo $sym2[$i]; ?>#digit", <?php echo $result8['Digits'];?>);
                    symboleContSize["<?php echo $sym2[$i]; ?>"] = "<?php echo $result8['ContractSize'];?>";
                    symboles.push("<?php echo $sym2[$i]; ?>");
                    //document.getElementById("totalsambolPur").val = symboles;
                    $('#totalsambolPur').val(symboles);
                    </script>

					<tr id="tr_<?php echo $sym2[$i]; ?>" class="info bg-info" >
                       <td class="responsive2"><div id="<?php echo $sym2[$i]; ?>#Symbol" class="context-menu-one"><?php echo $sym2[$i];?></div></td>
                        
                        <td style="display:none;"><?php echo trim($result8['TradingGateway'])?></td>
                        <td style="display:none;"><?php echo $sym2[$i]; ?></td>
                        <td style="display:none;"><?php echo trim($result8['SecurityTypeID'])?></td>
                        <td style="display:none;"><?php echo trim($result8['Source'])?></td>
                        <td style="display:none;"><?php echo trim($result8['Digits'])?></td>
                        <td style="display:none;"><?php echo trim($result8['InstruementID'])?></td>

                        <td class="responsive1"><div id="<?php echo $sym2[$i];?>Bid" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>Ask" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>Mid" ></div></td>
                       <td style="display:none;"><div id="<?php echo $sym2[$i]; ?>#Size"><?php echo trim($result8['ContractSize'])?></div></td>
                       <td style="display:none;"><?php echo trim($result8['LimitAndStopLevel'])?></td>
                    </tr>
                    
                    <tr id="tr_<?php echo $sym2[$i];?>" class="info bg-info" > 
                    	<td class="responsive2">&nbsp;</td>
                        <td style="display:none;"><div id="<?php echo $sym2[$i]; ?>open1" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>high" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>low" ></div></td>
                         <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>close1" ></div></td>
						<td style="display:none;"><div id="<?php echo trim($explodeSYB['Symbol'])?>closeval" ></div></td>
                    </tr>
					
				<?php  } // for loop end
			
 				
					} else {
					
				//$queryEmpty=mysql_query("TRUNCATE TABLE symbols");
                    // For Getting All Symbols from Contract
                    //$Arr=objectToArray($webService);    
					$Arr=$_SESSION['Arr'];     
                        foreach ($Arr as $innerArray) {
                        //  Check type
                        if (is_array($innerArray)){
                        //  Scan through inner loop
                        foreach ($innerArray as $value) {
                        
                          if (is_array($value)){
                         
                          foreach ($value as $explodeSYB) { 
						  /*echo '<pre>';
						  print_r($explodeSYB); 
						  echo '</pre>';*/	
						  
					
                    ?>
                    <script>
                    sessionStorage.setItem("<?php echo $explodeSYB['Symbol'];?>", <?php echo $explodeSYB['ContractSize'];?>);
                    sessionStorage.setItem("<?php echo $explodeSYB['Symbol'];?>#digit", <?php echo $explodeSYB['Digits'];?>);
                    symboleContSize["<?php echo $explodeSYB['Symbol'];?>"] = "<?php echo $explodeSYB['ContractSize'];?>";
                    symboles.push("<?php echo $explodeSYB['Symbol'];?>");
                    //document.getElementById("totalsambolPur").val = symboles;
                    $('#totalsambolPur').val(symboles);
                    </script>
                    <tr id="tr_<?php echo trim($explodeSYB['Symbol'])?>" class="info bg-info" >
                       <td class="responsive2"><div id="<?php echo trim($explodeSYB['Symbol']); ?>#Symbol" class="context-menu-one"><?php echo $explodeSYB['Symbol'];?></div></td>
                       <td style="display:none;"><?php echo trim($explodeSYB['TradingGateway'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['Symbol'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['SecurityTypeID'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['Source'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['Digits'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['InstruementID'])?></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>Bid" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>Ask" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>Mid" ></div></td>
                       <td style="display:none;"><div id="<?php echo trim($explodeSYB['Symbol'])?>#Size"><?php echo trim($explodeSYB['ContractSize'])?></div></td>
                       <td style="display:none;"><?php echo trim($explodeSYB['LimitAndStopLevel'])?></td>
                    </tr>
                    
                    <tr id="tr_<?php echo trim($explodeSYB['Symbol'])?>" class="info bg-info" > 
                    	<td class="responsive2">&nbsp;</td>
                        <td style="display:none;"><div id="<?php echo trim($explodeSYB['Symbol'])?>open1" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>high" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>low" ></div></td>
                         <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>close1" ></div></td>
						 <td style="display:none;"><div id="<?php echo trim($explodeSYB['Symbol'])?>closeval" ></div></td>
                      
                    </tr>
                    <div  style="display:none;" id="<?php echo trim($explodeSYB['Symbol'])?>Digitval" ><?php echo trim($explodeSYB['Digits'])?></div>
                    <?php
									} // for if condition
                               } // for each
                             }
                          }
                       }
                    }
                    ?>
</tbody>               
            <input type="hidden" name="totalsambolPur" id="totalsambolPur" value="" />
         </table>
        
        </div>
        
      </div>
      <!--<div class="span8  context-menu-two box menu-1">-->
     
  <!-- container end -->
</div>             
            
<!---->

<!-- wrapper end
<!-- wrapper end -->
<script>

var tabTemplate = "";
var tabs;
var chartObjArr = new Array();
// actual addTab function: adds new tab using the input from the form above
var lblCount = 30, timer = 40, interval, isAdding = false;
var lblCount2 = 30;
function OpenChartForTicks(str,def)
{
    //var arr = id.split("_");
    var arr = $("li.tab.active").attr("id");
    //var id0 = 'txtticknumber_' + arr[0];
    //var getTick_Type=document.getElementById("ddldatadecision_" + arr).value;

    var getTick_Type=str;
    var valuesplit = getTick_Type.split(" ");
    var tickNo = valuesplit[0];
    var tickType = valuesplit[1];

    /*Here update the indicator in db*/
    //alert("userhistory.php?symbol_str"+arr+"&timer="+getTick_Type+"&action=indicatorchart_time");
    //return false;
    if(def=='')
    {
        var newIndicator=document.getElementById("mySelectindicator").value;
        document.getElementById("indicatorChart_"+arr).value=newIndicator+"_"+getTick_Type;

        $.ajax({
            url: "userhistory.php",
            type: 'POST',
            data: {symbol_str:arr,timer:getTick_Type, action: 'indicatorchart_time'},
            dataType: 'html',
            success: function(data) {
                //alert(data);
            }
        });
    }
    /*End Here*/
    //alert(tickNo+"=="+tickType);
    /*var arr = id.split("_");
    var id0 = 'txtticknumber_' + arr[0];
    var tickNo = document.getElementById(id0).value;
    var tickType = document.getElementById("ddldatadecision_" + arr[0]).value;*/
    var dateTodayStr = getTodayDateInString();
    //if (! (arr[0] in chartObjArr))
    //{
        //alert(arr[0]+" "+dateTodayStr+" "+tickNo+" "+tickType);
        var obj = new myChart_newtab(arr, dateTodayStr, tickNo, tickType);
        chartObjArr[arr] = obj;
        obj.OpenChartForTick();
        //$('#ddldatadecision_' + obj._symbolName).attr({"disabled":"disabled"});
        //$('#txtticknumber_' + obj._symbolName).attr({"disabled":"disabled"});
        //$('#' + obj._symbolName + '_btngettickdata').attr({"disabled":"disabled"});
    //}
}

function SubscribeSymbol(){
			<?php
			$queryG=mysql_query("select * from symbols");
			while ($result = mysql_fetch_array($queryG))
			{ ?>
			var msg1 ={"NoOfSymbols":1,"isForSubscribe":1,
			"Symbol":
			[
			
			{"Contract":"<?php echo $result['Symbol']; ?>","ProductType":"1","Product":"<?php echo $result['Source']; ?>","Gateway":"<?php echo $result['TradingGateway']; ?>"},
			
			],
			"msgtype":28};
			
			var msg1Send=JSON.stringify(msg1);
				websocket.send(msg1Send);	
			<?php }	?>
			
};
$xxxx=1;
$(document).ready(function ()
{
   
       /*var uri = 'ws://' + window.location.hostname + window.location.pathname.replace('StockHandler.aspx', '') + 'StockHandler.ashx?stockname=EURUSD&token=' + mytoken;
    console.log('Connecting to: ' + uri);
    var hostname = window.location.hostname;
    var hostname = "78.47.54.100";
	websocket = new WebSocket("ws://" + hostname + ":80/StockHandler.ashx?stockname=EURUSD&token="+ mytoken); //uri;
console.log('Connecting to: ' + "ws://" + hostname + ":80/StockHandler.ashx?stockname=EURUSD&token="+ mytoken);
 */ 
//var host = "ws://108.175.9.76:9034/test";
var host = "ws://78.47.54.100:9034/test";

				websocket = new WebSocket(host);
				console.log('websocket Status: '+websocket.readyState);
				
    websocket.onopen = function () {
        $('#messages').prepend('<div>Connected.</div>');
        $('#chatform').submit(function (event) {
        websocket.send($('#inputbox').val());
        $('#inputbox').val('');
        event.preventDefault();
        });
        $('#closeButton').click(function () {
            websocket.close();
        });
		SubscribeSymbol();
    };
    websocket.onclose = function () {
        $('#messages').prepend('<div>Closed.</div>');
    };

    websocket.onerror = function (event) {
        $('#messages').prepend('<div>ERROR</div>');
    };
    // this method is called when chart is first inited as we listen for "dataUpdated" event
    // NZDUSD,0.791,0.805,08/14/2013 13:17:48.421
    websocket.onmessage = function (event) {onmsg(event); }
	
});

function onmsg(event){
    var str = event.data.toString();
  var jsondt = JSON.parse(str);
  //console.log(jsondt);
  //alert(jsondt);
//document.write(str);
    /*var newstr = str.split(',');
    //alert(newstr[2]);
	var FindSymbol = newstr[newstr.length - 1].indexOf('Min');
    if (FindSymbol == -1)
    //{
        var newstr = str.split(",");
        var name = newstr[4];
        var Bid1 = newstr[1].split("/");
        var Bid= Bid1[0];        
        var Ask1 = newstr[3].split("/");
        var Ask  = Ask1[0];

        var Tohlc = newstr[2].split("~");
       
	    var Mid = parseFloat(Tohlc[0]);
		
		var OPEN = parseFloat(Tohlc[0])-parseFloat(Tohlc[4]);
		var HIGH = Tohlc[2];
		var LOW = Tohlc[3];
		var CLOSE = (parseFloat(Tohlc[0])-parseFloat(Tohlc[4])).toFixed(2);
       
	    var dttm = newstr[0];
		*/
		
		if(jsondt['msgtype']==22)
		{
			//console.log(jsondt['msgtype']);
			var name = jsondt['OHLC'][0].Contract;
			
			var digitval = $("#"+name+"Digitval").text();
			var powDigitval=Math.pow(10, digitval);
			
			var Bid  = (jsondt['OHLC'][0].MarketDepth[0].BidPrice/powDigitval);
			var Ask  = (jsondt['OHLC'][0].MarketDepth[0].AskPrice/powDigitval); 
			var Mid  = (jsondt['OHLC'][0].LastPrice/powDigitval);
			var OPEN = (jsondt['OHLC'][0].Open/powDigitval);
			var HIGH  = (jsondt['OHLC'][0].High/powDigitval);
			var LOW  = (jsondt['OHLC'][0].Low/powDigitval);
			var CLOSEPRICE  = jsondt['OHLC'][0].Close;
			//var CLOSE  = parseFloat(Mid)-parseFloat(CLOSEPRICE);
			var CLOSE  = ((parseFloat(Mid)-parseFloat(CLOSEPRICE))/powDigitval).toFixed(2);
			console.log('digitval='+digitval+'powDigitval='+powDigitval+'LastPrice='+Mid+'CLOSEPRICE='+CLOSEPRICE+'Net changes='+CLOSE);
			
			var hashSymbol = name + "#Symbol";
			var hashBid = name + "Bid";
			var hashMid = name + "Mid";
			var hashAsk = name + "Ask";
			var hashDate = name + "DateTime";
			var hashcontr = name + "#cnt";
		 
			var hashopen1 =  name + "open1";
			var hashhigh =  name + "high";
			var hashlow =  name + "low";
			var hashclose1 =  name + "close1";
			
			var closeval2 =  name + "closeval";
			document.getElementById(closeval2).innerHTML = CLOSEPRICE;
		}
		if(jsondt['msgtype']==23)
		{
			
			var name = jsondt['QuotesItem'][0].Contract;
			var QuotesStreamType = jsondt['QuotesItem'][0].QuotesStreamType;
			var Price = jsondt['QuotesItem'][0].Price;
			var MarketLevel = jsondt['QuotesItem'][0].MarketLevel;
			var closeval2 =  name + "closeval";
			var CLOSEPRICE = document.getElementById(closeval2).innerHTML;
			
			var digitval = $("#"+name+"Digitval").text();
			var powDigitval=Math.pow(10, digitval);   
			//console.log('jsondtPKS='+name+'#digit='+powDigitval);
			
			if(MarketLevel=='0')
			{
				if(QuotesStreamType=='A'){
				var Ask = (Price/powDigitval);
				var hashAsk = name + "Ask";
				//console.log('Ask='+name+' Value='+Ask);
				} 
				else if(QuotesStreamType=='B'){
				var Bid = (Price/powDigitval);
				var hashBid = name + "Bid";
				//console.log('Bid='+name+' Value='+Bid);
				}
				else if(QuotesStreamType=='M'){
				var LOW = (Price/powDigitval);
				var hashlow =  name + "low";
				}
				else if(QuotesStreamType=='H'){
				var HIGH = (Price/powDigitval);
				var hashhigh =  name + "high";
				}
				else if(QuotesStreamType=='O'){
				var OPEN = (Price/powDigitval);
				var hashopen1 =  name + "open1";
				}
				
				else if(QuotesStreamType=='L'){
				var Mid = Price;
				var hashMid = name + "Mid";		
				var CLOSE  = ((parseFloat(Mid)-parseFloat(CLOSEPRICE))/powDigitval).toFixed(2);
				console.log('digitval2='+digitval+'powDigitval2='+powDigitval+'LastPrice2='+Mid+'CLOSEPRICE2='+CLOSEPRICE+'Net changes='+CLOSE);
				var hashclose1 =  name + "close1";
						/// Start For Color changes ///
						var buy_price = document.getElementById(hashclose1).innerHTML;
						buy_price=parseFloat(buy_price);
						var v_Buy = buy_price * 100;
						var v2_buy = CLOSE * 100;
						//alert('Closed'+v_Buy+" "+ v2_buy);
						if (v_Buy > v2_buy)
						{
							document.getElementById(hashclose1).style.color = '#FFFFFF';
							document.getElementById(hashclose1).style.background = '#FF0000';
						}
						else if (v_Buy < v2_buy)
						{
							
							document.getElementById(hashclose1).style.color = '#FFFFFF';
							document.getElementById(hashclose1).style.background = '#0000FF';
						}
						else if (v_Buy == v2_buy)
						{
							
							document.getElementById(hashclose1).style.color = '#000000';
							document.getElementById(hashclose1).style.background = '#FFFFFF';
						}
						/// End For Color changes ///
				document.getElementById(hashclose1).innerHTML = CLOSE;
								
				}
				else if(QuotesStreamType=='C'){
				
				}
				var hashSymbol = name + "#Symbol";
			
			
			}
		
		}
		
			
            if(document.getElementById(hashMid))
            {
                var buy_price = document.getElementById(hashMid).innerHTML;
                buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = Mid * 100;
                //alert(v_Buy+" "+ v2_buy);
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashMid).style.color = '#FFFFFF';
					document.getElementById(hashMid).style.background = '#FF0000';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
                else if (v_Buy < v2_buy)
                {
                    
                    document.getElementById(hashMid).style.color = '#FFFFFF';
					document.getElementById(hashMid).style.background = '#0000FF';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
                else if (v_Buy == v2_buy)
                {
                    
					document.getElementById(hashMid).style.color = '#000000';
					document.getElementById(hashMid).style.background = '#FFFFFF';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
            }
			// for Bid Price
			 if(document.getElementById(hashBid))
            {
              var buy_price = document.getElementById(hashBid).innerHTML;
                buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = Bid * 100;
                //alert(v_Buy+" "+ v2_buy);
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashBid).style.color = '#FFFFFF';
					document.getElementById(hashBid).style.background = '#FF0000';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
                else if (v_Buy < v2_buy)
                {
                    
                    document.getElementById(hashBid).style.color = '#FFFFFF';
					document.getElementById(hashBid).style.background = '#0000FF';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
                else if (v_Buy == v2_buy)
                {
                    
					document.getElementById(hashBid).style.color = '#000000';
					document.getElementById(hashBid).style.background = '#FFFFFF';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
            }
			// for Ask Price
			if(document.getElementById(hashAsk))
            {
                var buy_price = document.getElementById(hashAsk).innerHTML;
                buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = Ask * 100;
                //alert(v_Buy+" "+ v2_buy);
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashAsk).style.color = '#FFFFFF';
					document.getElementById(hashAsk).style.background = '#FF0000';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
                else if (v_Buy < v2_buy)
                {
                    
                    document.getElementById(hashAsk).style.color = '#FFFFFF';
					document.getElementById(hashAsk).style.background = '#0000FF';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
                else if (v_Buy == v2_buy)
                {
                    
					document.getElementById(hashAsk).style.color = '#000000';
					document.getElementById(hashAsk).style.background = '#FFFFFF';
                    document.getElementById(hashSymbol).style.color = '#000000';
					document.getElementById(hashSymbol).style.background = '#FFFFFF';
                }
            }
			
            if(document.getElementById(hashSymbol))
            {
                document.getElementById(hashSymbol).innerHTML = name;
                document.getElementById(hashBid).innerHTML = Bid;
                document.getElementById(hashMid).innerHTML = Mid;
                document.getElementById(hashAsk).innerHTML = Ask;
                
				document.getElementById(hashopen1).innerHTML = OPEN.toFixed(2);
				document.getElementById(hashhigh).innerHTML = HIGH;
				document.getElementById(hashlow).innerHTML = LOW;
				document.getElementById(hashclose1).innerHTML = CLOSE;
            }
			
			// for Open Price
			 if(document.getElementById(hashclose1))
            {
                var buy_price = document.getElementById(hashclose1).innerHTML;
                buy_price=parseFloat(buy_price);
                //alert(buy_price);
                var v_Buy = buy_price * 100;
                var v2_buy = CLOSE * 100;
                //alert('Closed'+v_Buy+" "+ v2_buy);
                if (v_Buy > v2_buy)
                {
					document.getElementById(hashclose1).style.color = '#FFFFFF';
					document.getElementById(hashclose1).style.background = '#FF0000';
                }
                else if (v_Buy < v2_buy)
                {
                    
                    document.getElementById(hashclose1).style.color = '#FFFFFF';
					document.getElementById(hashclose1).style.background = '#0000FF';
                }
                else if (v_Buy == v2_buy)
                {
                    
					document.getElementById(hashclose1).style.color = '#000000';
					document.getElementById(hashclose1).style.background = '#FFFFFF';
                }
            }
			
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
			   console.log('PKS=='+ordContract);
			   var Contsize2=parseInt(sessionStorage.getItem(name));
			   console.log(Contsize2);
			   if(ordSidetrd="BUY"){
			   var eqtyBlanc=Qty1*(Bid-AvgPriceeq)*Contsize2;
			   }if(ordSidetrd="SELL"){
			   var eqtyBlanc=Qty1*(AvgPriceeq-Ask)*Contsize2;
			   }
			   //console.log('Prabhat1='+eqtyBlanc);
			  //  var balnc=document.getElementById(equitibal1).innerHTML;
			  // console.log(balnc);
			   var blnce = parseFloat(sessionStorage.getItem("acBalance"));
			   var Eqtybl=blnce+eqtyBlanc;
			   
			   console.log('blnce='+blnce+'eqtyBlanc='+eqtyBlanc);
			   
			   var totolupn = totolupn + eqtyBlanc;
				
			}

			setTimeout(	function() 
				{
				var UsedMarginval=sessionStorage.getItem("usedMargin");
				var v1=UsedMarginval;
				var v2=Eqtybl;
				var useMr=(parseFloat(v2)-parseFloat(v1));

				if(isNaN(useMr)){ useMr=UsedMarginval; }
				if(isNaN(Eqtybl)){ Eqtybl=blnce; }

				$('#equitibal1').text(Eqtybl);
				$('#frmargin').text(parseFloat(useMr));
				$('#upnid').text(totolupn);
				}, 10000);
				
        //}
   // }
	$('#dvLoading').fadeOut(1);

}

</script>
<script type="text/javascript" class="showcase">
function trim(str)
{
    return str.replace(/^\s+|\s+$/g,"");
}
$(function(){
    $.contextMenu({
        selector: '.context-menu-one',
        trigger: 'left',
        callback: function(key, options) {
            var m = key;
            if(m=='BUY')
            {
                //window.open("Order Entry.html");        
                buyOrder();
                return;
                
            }
            else if(m=='SELL')
            {
                sellOrder();
                return;
                
            }
            
            else if(m=='Hide')
            {}
            else if(m=='Hide All')
            {}
            else if(m=='Show All')
            {}
            else if(m=='Ascending')
            {}
            else if(m=='Descending')
            {}
            else if(m=='Ascending2')
            {}
            else if(m=='Descending2')
            {}
            //window.console && console.log(m) || alert(m);
        },
        items: {
           "BUY": {name: "Buy Order"},
            "sep1": "---------",            
            "SELL": {name: "Sell Order"}
        }



    });

    $('.context-menu-one').on('click', function(e){
        console.log('clicked', this);
        
    })

});

</script>
<script type="text/javascript" src="src/jquery.tablesorter.min.js"></script>
<script type="text/javascript" src="src/jquery.tablesorter_half.js"></script>

  <!-- Bootstrap Core JavaScript -->
<script src="bb-trader/js/bootstrap.min.js"></script>   
<script src="bb-trader/js/agency.js"></script> 
   
</center>
