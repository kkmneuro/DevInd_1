<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>PHP API Service-Old Architecture</title>
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
<td><p style="font-size:40px; text-align:center">PHP API Service-Old Architecture</p></td></tr>
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
					<input type="submit" name="AuthenticateUser"  value="AuthenticateUser" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetAccounts</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<input type="submit" name="GetAccounts"  value="GetAccounts" class="submit" >
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
					<label>AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<label>password.</label> <input type="password" name="password"  value="" required><br>
					<label>comment.</label> <input type="text" name="comment"  value="" >
					<input type="submit" name="CheckPassword"  value="CheckPassword" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>



<li>
	<div>ChangePassword</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<label>password.</label> <input type="password" name="password"  value="" required><br>
					<label>newpassword.</label> <input type="password" name="newpassword"  value="" >
					<input type="submit" name="ChangePassword"  value="ChangePassword" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetAccountInfo</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<input type="submit" name="GetAccountInfo"  value="GetAccountInfo" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>changeBalance</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<label>balance.</label> <input type="text" name="balance"  value="" required><br>
					<label>comment.</label> <input type="text" name="comment"  value="" >
					<input type="submit" name="changeBalance"  value="changeBalance" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>ChangeCredit</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>AccountId.</label> <input type="text" name="accountId"  value="" required><br>
					<label>balance.</label> <input type="text" name="balance"  value="" required><br>
					<label>time.</label> <input type="text" name="time"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<input type="submit" name="ChangeCredit"  value="ChangeCredit" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>	

<li>
	<div>TransferBalance</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>fromaccountId.</label> <input type="text" name="fromaccountId"  value="" required><br>
					<label>ToaccountId.</label> <input type="text" name="ToaccountId"  value="" required><br>
					<label>balance.</label> <input type="text" name="balance"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<input type="submit" name="TransferBalance"  value="TransferBalance" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>SymbolsGetAll</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<input type="submit" name="SymbolsGetAll"  value="SymbolsGetAll" class="submit" >
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
					<label>login.</label> <input type="text" name="login"  value="" required><br>
					<label>group.</label> <input type="text" name="group"  value="" required><br>
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
					
					<input type="submit" name="CreateAccount"  value="Create Account" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>ModifyAccount</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>login.</label> <input type="text" name="login"  value="" required><br>
					<label>group.</label> <input type="text" name="group"  value="" required><br>
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
					
					<input type="submit" name="ModifyAccount"  value="ModifyAccount" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>DeleteAccount</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<input type="submit" name="DeleteAccount"  value="DeleteAccount" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetOpenedTradesForAccountId</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<input type="submit" name="GetOpenedTradesForAccountId"  value="GetOpenedTradesForAccountId" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetOpenOrders</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<input type="submit" name="GetOpenOrders"  value="GetOpenOrders" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetTradeHistory</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<label>FromTime.</label> <input type="text" name="FromTime"  id="datepicker" value="" ><br>
					<label>TillTime.</label> <input type="text" name="TillTime"  id="datepicker1"  value="" ><br>
					<input type="submit" name="GetTradeHistory"  value="GetTradeHistory" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>


<li>
	<div>AccountHaveTrades</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<label>FromTime.</label> <input type="text" name="FromTime"  id="datepicker2"  value="" ><br>
					<label>TillTime.</label> <input type="text" name="TillTime"  id="datepicker3"  value="" ><br>
					<input type="submit" name="AccountHaveTrades"  value="AccountHaveTrades" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>UpdateLeverage</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<label>leverage.</label> <input type="text" name="leverage"  value="" ><br>
					<input type="submit" name="UpdateLeverage"  value="UpdateLeverage" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetGroupRecord</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>group.</label> <input type="text" name="group"  value="" ><br>
					<input type="submit" name="GetGroupRecord"  value="GetGroupRecord" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetGroups</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<input type="submit" name="GetGroups"  value="GetGroups" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>GetAccountBalance</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<input type="submit" name="GetAccountBalance"  value="GetAccountBalance" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>


<li>
	<div>OpenOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>Type.</label> <input type="text" name="Type"  value="" ><br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" ><br>
					<label>cmd.</label> <input type="text" name="cmd"  value="" ><br>
					<label>order.</label> <input type="number" name="order"  value="" ><br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" ><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" ><br>
					<label>volume.</label> <input type="number" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="number" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="number" name="crc"  value="" ><br>
					<input type="submit" name="OpenOrder"  value="OpenOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>ModifyOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>Type.</label> <input type="text" name="Type"  value="" ><br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" ><br>
					<label>cmd.</label> <input type="text" name="cmd"  value="" ><br>
					<label>order.</label> <input type="number" name="order"  value="" ><br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" ><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" ><br>
					<label>volume.</label> <input type="number" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="number" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="number" name="crc"  value="" ><br>
					<input type="submit" name="ModifyOrder"  value="ModifyOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>OpenPendingOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>Type.</label> <input type="text" name="Type"  value="" ><br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" ><br>
					<label>cmd.</label> <input type="text" name="cmd"  value="" ><br>
					<label>order.</label> <input type="number" name="order"  value="" ><br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" ><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" ><br>
					<label>volume.</label> <input type="number" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="number" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>expiration.</label> <input type="text" name="expiration"  value="" ><br>
					<label>crc.</label> <input type="number" name="crc"  value="" ><br>
					<input type="submit" name="OpenPendingOrder"  value="OpenPendingOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>ModifyPendingOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>Type.</label> <input type="text" name="Type"  value="" ><br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" ><br>
					<label>cmd.</label> <input type="text" name="cmd"  value="" ><br>
					<label>order.</label> <input type="number" name="order"  value="" ><br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" ><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" ><br>
					<label>volume.</label> <input type="number" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="number" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>expiration.</label> <input type="text" name="expiration"  value="" ><br>
					<label>crc.</label> <input type="number" name="crc"  value="" ><br>
					<input type="submit" name="ModifyPendingOrder"  value="ModifyPendingOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>CloseOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>Type.</label> <input type="text" name="Type"  value="" ><br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" ><br>
					<label>cmd.</label> <input type="text" name="cmd"  value="" ><br>
					<label>order.</label> <input type="number" name="order"  value="" ><br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" ><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" ><br>
					<label>volume.</label> <input type="number" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="number" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="number" name="crc"  value="" ><br>
					<input type="submit" name="CloseOrder"  value="CloseOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>DeleteOrder</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>Type.</label> <input type="text" name="Type"  value="" ><br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" ><br>
					<label>cmd.</label> <input type="text" name="cmd"  value="" ><br>
					<label>order.</label> <input type="number" name="order"  value="" ><br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" ><br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" ><br>
					<label>volume.</label> <input type="number" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="number" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="number" name="crc"  value="" ><br>
					<input type="submit" name="DeleteOrder"  value="DeleteOrder" class="submit" >
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