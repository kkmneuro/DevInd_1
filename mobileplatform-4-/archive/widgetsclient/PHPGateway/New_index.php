<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
 <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script data-require="jquery@*" data-semver="2.0.3" src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script data-require="bootstrap@*" data-semver="3.1.1" src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <link data-require="bootstrap-css@3.1.1" data-semver="3.1.1" rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" />
 
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script> 
<link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>

</head>

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

<script>
$(document).ready(function() {
	$('#submitBtn').click(function() {
		 
		 $('#accountno1html').text($('#accountno1').val());
		 $('#accountno2html').text($('#accountno2').val());
		 $('#Passwordhtml').text($('#Password').val());
		 $('#balancehtml').text($('#balance').val());
		 
		 var ac1 = $('#accountno1').val();
		 document.getElementById("ac1val").value = ac1;
		 var ac2 = $('#accountno2').val();
		 document.getElementById("ac2val").value = ac2;
		 var bal = $('#balance').val();
		 document.getElementById("acbal").value = bal;
		 
	});

	$('#submit').click(function(){
		alert('submitting');
		$('#formfield').submit();
	});

});

</script>

<body>

<table border="0" width="100%">
<tr style="height:100px; background-image:url(images/header7.jpg);background-size: 1330px 90px; color:#0e09c1;font-family: cursive;">
<td><p style="font-size:40px; text-align:center">Manager API </p></td></tr>
<tr><td style="background-color:#D9DFD7;">

<div class="container" id="main_container">

<table border="2" width="60%" style="margin-top:50px;">
<tr><th> 1:</th><th>AuthenticateUser</th>
<td><input type="button" name="btn" value="AuthenticateUser" data-toggle="modal" data-target="#AuthenticateUser"  /></td></tr>

<tr><th> 2:</th><th>GetAccounts</th>
<td><input type="button" name="btn" value="GetAccounts" data-toggle="modal" data-target="#GetAccounts"  /></td></tr>

<tr><th> 3:</th><th>Check Password</th>
<td><input type="button" name="btn" value="CheckPassword" data-toggle="modal" data-target="#CheckPassword"  /></td></tr>

<tr><th> 4:</th><th>GetAccounts</th>
<td><input type="button" name="btn" value="GetAccounts" data-toggle="modal" data-target="#GetAccounts"  /></td></tr>

<tr><th> 5:</th><th>GetAccounts</th>
<td><input type="button" name="btn" value="GetAccounts" data-toggle="modal" data-target="#GetAccounts"  /></td></tr>

</table>

<!-- AuthenticateUser -->
<div class="modal fade" id="AuthenticateUser" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
		<form method="post" action="New_action.php"  name="myform" target="blank" id="formfield">	
            <div class="modal-body">
			<?php
			Define("ApiURL","http://74.208.228.33:82/RestServiceImpl.svc/");
			
			//print_r($_POST); die;
			//$username = $_POST['username']; 
			//$password = $_POST['password'];
			$dolorsign = "$";
			$WebserviceDetails = file_get_contents(ApiURL."AuthenticateUser/lqd3192/g1JNDDr".$dolorsign."mOE");
			//$WebserviceDetails = file_get_contents(ApiURL."AuthenticateUser/".$username."/".$password);
			$tockeniddecodelist = json_decode($WebserviceDetails); 
			echo '<pre>'; print_r(json_decode($tockeniddecodelist));
				
		   ?>
                Are you sure you want to submit the following details?
                <table class="table">
                    <tr>
                        <th>Username</th>
                        <td><input type="text" name="username"  value="" required></td>
					</tr>
					<tr>
						<th>Password</th>
                        <td><input type="password" name="password"  value="" required></td>
					</tr>
				</table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal" style="float: left;">Cancel</button>
				<input type="submit" name="AuthenticateUser"  value="submit" class="btn btn-success success" >
			</div>
		</form>	
        </div>
    </div>
</div>

<!-- GetAccounts -->
<div class="modal fade" id="GetAccounts" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
		<form method="post" action="New_action.php"  name="myform" target="blank" id="formfield">	
            <div class="modal-body">
                Are you sure you want to submit the following details?
                <table class="table">
                    <tr>
                        <th>ManagerId/Conn ID</th>
                        <td><input type="text" name="managerId"  value="" required></td>
					</tr>
					
				</table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal" style="float: left;">Cancel</button>
				<input type="submit" name="GetAccounts"  value="submit" class="btn btn-success success" >
			</div>
		</form>	
        </div>
    </div>
</div>

<!-- CheckPassword -->
<div class="modal fade" id="CheckPassword" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
		<form method="post" action="New_action.php"  name="myform" target="blank" id="formfield">	
            <div class="modal-body">
                Are you sure you want to submit the following details?
                <table class="table">
                    <tr>
                        <th>ManagerId/Conn ID</th>
                        <td><input type="text" name="managerId"  value="" required></td>
					</tr>
					<tr>
                        <th>AccountId</th>
                        <td><input type="text" name="accountId"  value="" required></td>
					</tr>
					<tr>
                        <th>password</th>
                        <td><input type="password" name="password"  value="" required></td>
					</tr>
					<tr>
                        <th>comment</th>
                        <td><input type="text" name="comment"  value="" ></td>
					</tr>
					
				</table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal" style="float: left;">Cancel</button>
				<input type="submit" name="CheckPassword"  value="submit" class="btn btn-success success" >
			</div>
		</form>	
        </div>
    </div>
</div>


<table border="5" width="100%" style="margin-top:50px;"><tr><td>



<ol id="my-tree">




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
					<label>groupname.</label> <input type="text" name="groupname"  value="" ><br>
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
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="text" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="text" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="text" name="crc"  value="" ><br>
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
					<label>volume.</label> <input type="text" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="text" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="text" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="text" name="crc"  value="" ><br>
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
					<label>volume.</label> <input type="text" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="text" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="text" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>expiration.</label> <input type="text" name="expiration"  value="" ><br>
					<label>crc.</label> <input type="text" name="crc"  value="" ><br>
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
					<label>volume.</label> <input type="text" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="text" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="text" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>expiration.</label> <input type="text" name="expiration"  value="" ><br>
					<label>crc.</label> <input type="text" name="crc"  value="" ><br>
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
					<label>volume.</label> <input type="text" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="text" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="text" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="text" name="crc"  value="" ><br>
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
					<label>volume.</label> <input type="text" name="volume"  value="" ><br>
					<label>tradeprice.</label> <input type="text" name="tradeprice"  value="" ><br>
					<label>stoploss(SL).</label> <input type="text" name="stoploss"  value="" ><br>
					<label>takeprofit(TP).</label> <input type="text" name="takeprofit"  value="" ><br>
					<label>deviation.</label> <input type="text" name="deviation"  value="" ><br>
					<label>comment.</label> <input type="text" name="comment"  value="" ><br>
					<label>crc.</label> <input type="text" name="crc"  value="" ><br>
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
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>ManagerId/Conn ID.</label> <input type="text" name="managerId"  value="" required><br>
					<label>accountId.</label> <input type="text" name="accountId"  value="" ><br>
					<label>status.</label> <input type="text" name="state"  value="" ><br>
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