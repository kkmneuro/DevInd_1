<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Manager API </title>
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
		window.location="index2.php";
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
<td><p style="font-size:40px; text-align:center">Manager API </p></td></tr>
<tr><td style="background-color:#D9DFD7;">

<div class="container" id="main_container">


<!--<a id="opn" class="btn btn-warning more-info" href="#">View Result</a>-->
<?php
include("output_response.php");
?>
            


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
				<form method="post" action="action2.php"  name="myform" >
					<label>username.</label> <input type="text" name="username"  value="" required><br>
					<label>password.</label> <input type="password" name="password"  value="" required><br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>AccountId.</label> <input type="number" name="accountId"  value="" required>&nbsp;&nbsp;*&nbsp;(7999)<br>
					<label>password.</label> <input type="password" name="password"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Admin@321)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. testing)
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>AccountId.</label> <input type="text" name="accountId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>password.</label> <input type="password" name="password"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Admin@321)<br>
					<label>newpassword.</label> <input type="password" name="newpassword"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. Admin@3211)
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>AccountId.</label> <input type="number" name="accountId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
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
				<form method="post" action="action2.php"  name="myform">
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>AccountId.</label> <input type="number" name="accountId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>balance.</label> <input type="number" name="balance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. smg)
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>AccountId.</label> <input type="number" name="accountId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>balance.</label> <input type="number" name="balance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>time.</label> <input type="text" name="time"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 10)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. smg)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>fromaccountId.</label> <input type="number" name="fromaccountId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>ToaccountId.</label> <input type="number" name="ToaccountId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7998)<br>
					<label>balance.</label> <input type="number" name="balance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. smg)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>login.</label> <input type="number" name="login"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>group.</label> <input type="text" name="group"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. demoforex)<br>
					<label>password.</label> <input type="password" name="password"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Admin@34212)<br>
					<label>enable.</label> <input type="number" name="enable"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>enable_change_password.</label> <input type="text" name="enable_change_password"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>enable_read_only.</label> <input type="text" name="enable_read_only"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>password_investor.</label> <input type="text" name="password_investor"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>password_phone.</label> <input type="text" name="password_phone"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7897897898)<br>
					<label>name.</label> <input type="text" name="name"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Prabhat)<br>
					<label>country.</label> <input type="text" name="country"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. India)<br>
					<label>city.</label> <input type="text" name="city"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Noida)<br>
					<label>state.</label> <input type="text" name="state"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. UP)<br>
					<label>zipcode.</label> <input type="number" name="zipcode"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 201301)<br>
					<label>address.</label> <input type="text" name="address"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Noida 136)<br>
					<label>phone.</label> <input type="number" name="phone"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 4564564561)<br>
					<label>email.</label> <input type="email" name="email"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. prabhat@gmail.com)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. test)<br>
					<label>id.</label> <input type="number" name="id"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>status.</label> <input type="number" name="status"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>leverage.</label> <input type="number" name="leverage"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>agent_account.</label> <input type="number" name="agent_account"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>balance.</label> <input type="number" name="balance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>prevmonthbalance.</label> <input type="number" name="prevmonthbalance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>prevbalance.</label> <input type="number" name="prevbalance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>credit.</label> <input type="number" name="credit"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					
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
				<form method="post" action="action2.php"  name="myform">
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>login.</label> <input type="number" name="login"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 8010)<br>
					<label>group.</label> <input type="text" name="group"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. demoforex)<br>
					<label>password.</label> <input type="password" name="password"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Admin@34212)<br>
					<label>enable.</label> <input type="number" name="enable"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>enable_change_password.</label> <input type="text" name="enable_change_password"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>enable_read_only.</label> <input type="text" name="enable_read_only"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>password_investor.</label> <input type="text" name="password_investor"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>password_phone.</label> <input type="text" name="password_phone"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 7897897898)<br>
					<label>name.</label> <input type="text" name="name"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Prabhat)<br>
					<label>country.</label> <input type="text" name="country"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. India)<br>
					<label>city.</label> <input type="text" name="city"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Noida)<br>
					<label>state.</label> <input type="text" name="state"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. UP)<br>
					<label>zipcode.</label> <input type="number" name="zipcode"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 201301)<br>
					<label>address.</label> <input type="text" name="address"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. Noida 136)<br>
					<label>phone.</label> <input type="number" name="phone"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 4564564561)<br>
					<label>email.</label> <input type="email" name="email"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. prabhat@gmail.com)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. test)<br>
					<label>id.</label> <input type="number" name="id"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>status.</label> <input type="number" name="status"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>leverage.</label> <input type="number" name="leverage"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>agent_account.</label> <input type="number" name="agent_account"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>balance.</label> <input type="number" name="balance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>prevmonthbalance.</label> <input type="number" name="prevmonthbalance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>prevbalance.</label> <input type="number" name="prevbalance"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>credit.</label> <input type="number" name="credit"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					
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
				<form method="post" action="action2.php"  name="myform">
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7998)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. smgtest)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>groupname.</label> <input type="text" name="groupname"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. TEST1)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>leverage.</label> <input type="number" name="leverage"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>group.</label> <input type="text" name="group"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. demoforex)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. smgtest)<br>
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
				<form method="post" action="action2.php"  name="myform">
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>Type.</label> <input type="number" name="Type"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 75)<br>
					<label>reserved.</label> <input type="number" name="reserved"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>cmd.</label> <input type="number" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>order.</label> <input type="number" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br>
					<label>volume.</label> <input type="number" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1.123)<br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. smg)<br>
					<label>crc.</label> <input type="text" name="crc"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
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
				<form method="post" action="action2.php"  name="myform">
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>Type.</label> <input type="number" name="Type"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 75)<br>
					<label>reserved.</label> <input type="number" name="reserved"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>cmd.</label> <input type="number" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>order.</label> <input type="number" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7718203)<br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br>
					<label>volume.</label> <input type="number" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1.011)<br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. smg)<br>
					<label>crc.</label> <input type="text" name="crc"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>Type.</label> <input type="number" name="Type"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 75)<br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>cmd.</label> <input type="number" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 2)<br>
					<label>order.</label> <input type="number" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br>
					<label>volume.</label> <input type="number" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1.012)<br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. msgtst)<br>
					<label>expiration.</label> <input type="text" name="expiration"  id="datepicker2" value="" >&nbsp;&nbsp;*&nbsp;(e.g. select date)<br>
					<label>crc.</label> <input type="text" name="crc"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>Type.</label> <input type="number" name="Type"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 75)<br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>cmd.</label> <input type="number" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 2)<br>
					<label>order.</label> <input type="number" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7718304)<br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br>
					<label>volume.</label> <input type="number" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1.012)<br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>deviation.</label> <input type="number" name="deviation"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. msgtst)<br>
					<label>expiration.</label> <input type="text" name="expiration"  id="datepicker3" value="" >&nbsp;&nbsp;*&nbsp;(e.g. select date)<br>
					<label>crc.</label> <input type="text" name="crc"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>Type.</label> <input type="number" name="Type"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 80)<br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>cmd.</label> <input type="number" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. BUY=0,SELL=1)<br>
					<label>order.</label> <input type="number" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7718299)<br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br>
					<label>volume.</label> <input type="text" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1.0579)<br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. smg)<br>
					<label>crc.</label> <input type="text" name="crc"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
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
				<form method="post" action="action2.php"  name="myform" >
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>Type.</label> <input type="number" name="Type"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 80)<br>
					<label>reserved.</label> <input type="text" name="reserved"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>cmd.</label> <input type="number" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g.  BUY=0,SELL=1)<br>
					<label>order.</label> <input type="number" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7718306)<br>
					<label>LoginId.</label> <input type="number" name="LoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7999)<br>
					<label>symbol.</label> <input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br>
					<label>volume.</label> <input type="text" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 100)<br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1.0559)<br>
					<label>stoploss(SL).</label> <input type="number" name="stoploss"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>takeprofit(TP).</label> <input type="number" name="takeprofit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>comment.</label> <input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<label>crc.</label> <input type="text" name="crc"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0)<br>
					<input type="submit" name="DeleteOrder"  value="DeleteOrder" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>UpdateAccountState</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action2.php"  name="myform">
					<label>ManagerId/Conn ID.</label> <input type="number" name="managerId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 1)<br>
					<label>accountId.</label> <input type="number" name="accountId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 7998)<br>
					<label>status.</label> <input type="number" name="state"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 1 for enable and "0" for Disable)<br>
					<input type="submit" name="UpdateAccountState"  value="UpdateAccountState" class="submit" >
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