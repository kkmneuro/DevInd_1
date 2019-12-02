<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>PHP API Service-New Architecture</title>
<link type="text/css" rel="stylesheet" href="src/jquery.treefilter.css">
<link type="text/css" rel="stylesheet" href="src/style.css">
<link href="http://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="src/jquery.treefilter.js"></script>
<script src="src/validate.js"></script>



<script>
    $(document).ready(function () {
      $("#closebtn").click(function () {
        $("#dlg").hide('1200', "swing", function () { $("#bkg").fadeOut("500"); });
		window.location="mt4ui.php";
      });
      $("#opn").click(function () {
        if (document.getElementById('bkg').style.visibility == 'hidden') {
          document.getElementById('bkg').style.visibility = '';
          $("#bkg").hide();
		  $("#my-tree").hide();

        }
        if (document.getElementById('dlg').style.visibility == 'hidden') {
          document.getElementById('dlg').style.visibility = '';
          $("#dlg").hide();
        }
        $("#bkg").fadeIn(500, "linear", function () { $("#dlg").show(800, "swing"); });
      });

    });
</script>
<script>
$(function() {

	var tree = new treefilter($("#my-tree"), {
		searcher : $("input#my-search"),
		multiselect : false
	});
});
</script>
<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
<!--<script src="http://code.jquery.com/jquery-1.10.2.js"></script>-->
<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
<!--<link rel="stylesheet" href="/resources/demos/style.css">-->
 <script>

$(function() {
	$( "#datepicker" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker1" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker2" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker3" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker4" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	

});



</script>


</head>
<body>
<table border="0" width="100%">
<tr style="height:100px; background-image:url(images/header6.jpg);background-size: 1330px 90px; color:#0e09c1;font-family: cursive;">
<td><p style="font-size:40px; text-align:center">PHP API Service-New Architecture</p></td></tr>
<tr><td style="background-color:#D9DFD7;">

<div class="container" id="main_container">


<!--<a id="opn" class="btn btn-warning more-info" href="#">View Result</a>-->
<?php
error_reporting(1);
$token='';
$token=$_GET['token'];
if(isset($token)!="") {?>
<script> $(document).ready(function () { $("#my-tree").hide(); }); </script>
</td></tr></table>
<?php	}?>


<?php
//echo 'server name='.$_SESSION["server2"];
if(isset($_REQUEST['SetServer']))
{
	@$_SESSION["server2"] = $_POST['server'];
}
?>
<table border="5" width="100%" style="margin-top:50px;"><tr><td>
<ul id="my-tree">

<li>
	<div>AuthenticateUser</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>username.</label> <input type="text" name="username"  value="" required><br>
					<label>password.</label> <input type="text" name="password"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<input type="submit" name="AuthenticateUser"  value="AuthenticateUser" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Get AccountInfo</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="_blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<label>TC AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<input type="submit" name="GetAccountInfo"  value="GetAccountInfo" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Check Password</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<label>TC AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<label>password.</label> <input type="password" name="password"  value="" required><br>
					<label>comment.</label> <input type="text" name="comment"  value="" >
					<input type="submit" name="CheckPassword"  value="CheckPassword" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>



<li>
	<div>change Balance</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<label>TC AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<label>balance.</label> <input type="text" name="balance"  value="" required><br>
					<label>comment.</label> <input type="text" name="comment"  value="" >
					<input type="submit" name="changeBalance"  value="changeBalance" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Currency Conversion</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<label>Amount</label> <input type="text" name="Amount"  value="" required><br>
					<label>SourceCurrency.</label> <input type="text" name="SourceCurrency"  value="" required><br>
					<label>DestinationCurrency.</label> <input type="text" name="DestinationCurrency"  value="" >
					<input type="submit" name="CurrencyConversion"  value="CurrencyConversion" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Group Symbol Info</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<input type="submit" name="GroupSymbolInfo"  value="GroupSymbolInfo" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Create Account</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<label>login.</label> <input type="text" name="login"  value="" required><br>
					<label>group.</label> <input type="text" name="group"  value="" ><br>
					<label>password.</label> <input type="password" name="password"  value="" required><br>
					<label>enable.</label> <input type="text" name="enable"  value="" required><br>
					<label>enable_change_password.</label> <input type="text" name="enable_change_password"  value="" required><br>
					<label>enable_read_only.</label> <input type="text" name="enable_read_only"  value="" required><br>
					<label>password_investor.</label> <input type="text" name="password_investor"  value="" required><br>
					<label>password_phone.</label> <input type="text" name="password_phone"  value="" required><br>
					<label>name.</label> <input type="text" name="name"  value="" required><br>
					<label>country.</label> <input type="text" name="country"  value="" required><br>
					<label>city.</label> <input type="text" name="city"  value="" required><br>
					<label>state.</label> <input type="text" name="state"  value="" required><br>
					<label>zipcode.</label> <input type="text" name="zipcode"  value="" required><br>
					<label>address.</label> <input type="text" name="address"  value="" required><br>
					<label>phone.</label> <input type="text" name="phone"  value="" required><br>
					<label>email.</label> <input type="text" name="email"  value="" required><br>
					<label>comment.</label> <input type="text" name="comment"  value="" required><br>
					<label>id.</label> <input type="text" name="id"  value="" required><br>
					<label>status.</label> <input type="text" name="status"  value="" required><br>
					<label>leverage.</label> <input type="text" name="leverage"  value="" required><br>
					<label>agent_account.</label> <input type="text" name="agent_account"  value="" required><br>
					<label>balance.</label> <input type="text" name="balance"  value="" required><br>
					<label>prevmonthbalance.</label> <input type="text" name="prevmonthbalance"  value="" required><br>
					<label>prevbalance.</label> <input type="text" name="prevbalance"  value="" required><br>
					<label>credit.</label> <input type="text" name="credit"  value="" required><br>
					
					<input type="submit" name="CreateAccount"  value="Create Account" class="submit" onclick="return validate_createaccountNo()" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>PlacePHPOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br>
					<label>TCGatewayId.</label> <input type="text" name="TCGatewayId"  value="" required><br>
					<label>Ordertype.</label> <input type="text" name="Ordertype"  value="" required><br>
					<label>Side.</label> <input type="text" name="Side"  value="" required><br>
					<label>PositionEffect.</label> <input type="text" name="PositionEffect"  value="" required><br>
					<label>OrigOrdId.</label> <input type="text" name="OrigOrdId"  value="" required><br>
					<label>Account.</label> <input type="text" name="Account"  value="" required><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" required><br>
					<label>volume.</label> <input type="text" name="volume"  value="" required><br>
					<label>Price.</label> <input type="text" name="Price"  value="" required><br>
					<label>SL.</label> <input type="text" name="SL"  value="" required><br>
					<label>TP.</label> <input type="text" name="TP"  value="" required><br>
					<label>RootToMT4Svr.</label> <input type="text" name="RootToMT4Svr"  value="" required><br>
					<label>comment.</label> <input type="text" name="comment"  value="" required><br>
					<label>expiration.</label> <input type="text" name="expiration"  value="" required><br>
					<label>MinOrDisclosedQty.</label> <input type="text" name="MinOrDisclosedQty"  value="" required><br>
					
					<input type="submit" name="PlacePHPOrder"  value="PlacePHPOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>



	

</ul> <!--End UI -->

</div>

</td></tr></table>



<br /><br />
<div style="float:left; margin-left:-177px; width:136%;height:50px;background-image:url(images/header6.jpg); background-color:#337F95; color:#0e09c1;font-family: cursive;">
<div style="text-align:center; font-size:36px">2016</div> </div>

</body>




</html>