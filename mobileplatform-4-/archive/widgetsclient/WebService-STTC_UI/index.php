<?php session_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>MT4 PHP API</title>
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

	$( "#datepicker5" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker6" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker7" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker8" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker9" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker10" ).datepicker({
	changeMonth: true,
	changeYear: true
	});

	$( "#datepicker11" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker12" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker13" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker14" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker15" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker16" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker17" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker18" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker19" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker20" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker21" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker22" ).datepicker({
	changeMonth: true,
	changeYear: true
	});
	$( "#datepicker50" ).datepicker({
	changeMonth: true,
	changeYear: true,
	minDate: -0, 
	maxDate:30000
	});

});


 
</script>


</head>
<body>
<table border="0" width="100%">
<tr style="height:100px; background-image:url(images/header6.jpg);background-size: 1330px 90px; color:#0e09c1;font-family: cursive;">
<td><p style="font-size:40px; text-align:center">STTS PHP API </p></td></tr>
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
	<div>Get Account Groups</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>GroupId.</label> <input type="text" name="GroupId"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
					<input type="submit" name="GetAccountGroups"  value="GetAccountGroups" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Get AccountGroups By ConnId</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>Gateway Connection Id.</label> <input type="text" name="ConnId"  value="" required><br />
					<input type="submit" name="GetAccountGroupsConnId"  value="GetAccountGroupsConnId" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Add Account Groups</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>GroupName.</label> <input type="text" name="GroupName"  value="" required><br />
					<label>Hedging.</label> <input type="text" name="Hedging"  value="" required><br />
					<label>Spread_Diff.</label> <input type="text" name="Spread_Diff"  value="" required><br />
					<label>Active.</label> <input type="text" name="Active"  value="" required><br />
					<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker1" value="" ><br />
					<input type="submit" name="AddAccountGroups"  value="AddAccountGroups" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Update Account Groups</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<label>GroupName.</label> <input type="text" name="GroupName"  value="" required><br />
					<label>Hedging.</label> <input type="text" name="Hedging"  value="" required><br />
					<label>Spread_Diff.</label> <input type="text" name="Spread_Diff"  value="" required><br />
					<label>Active.</label> <input type="text" name="Active"  value="" required><br />
					<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker2" value="" ><br />
					<input type="submit" name="UpdateAccountGroups"  value="Update Account Groups" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Get Accounts</div>
	<ul>
		<li>
			<div class="row">
				<form method="post" action="action.php"  name="myform" target="blank">
					<input type="submit" name="GetAccounts"  value="GetAccounts" class="submit" >
				</form>
			</div>
		</li>
	</ul>
</li>

        
<li>
	<div>Add Accounts</div>
	<ul>
		<li>
			<div class="row">
			<form method="post" action="action.php" name="myform7" target="blank">
				<label>AccountID.</label> <input type="number" name="AccountID"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
				<label>ExternalID.</label> <input type="text" name="ExternalID"  value="" required><br />
				<label>Password.</label> <input type="password" name="Password"  value="" required ><br />
				<label>Gateway.</label> <input type="text" name="Gateway"  value="" required><br />
				<label>TCInstanceName.</label> <input type="text" name="TCInstanceName"  value="" required><br />
				<label>AccountGroup.</label> <input type="text" name="AccountGroup"  value="" required><br />
				<label>Connection.</label> <input type="text" name="Connection"  value="" required><br />
				<label>ParticipantLoginID.</label> <input type="text" name="ParticipantLoginID"  value="" required><br />
				<label>ParticipantPassword.</label> <input type="text" name="ParticipantPassword"  value="" required><br />
				<label>RootToMT4Server.</label> <input type="text" name="RootToMT4Server"  value="" required><br />
				<label>PStype.</label> <input type="text" name="PStype"  value="" required><br />
				<label>PSShare.</label> <input type="text" name="PSShare"  value="" required><br />
				<label>ShareInProfitOnly.</label> <input type="text" name="ShareInProfitOnly"  value="" required><br />
				<label>InstantDeduction.</label> <input type="text" name="InstantDeduction"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker3" value="" ><br />
				<input type="submit" name="AddAccounts"  value="Add Accounts" class="submit"  >
			</form>
			</div>
		</li>
	</ul>
</li>
        
<li>
	<div>Update Account</div>
	<ul>
		<li>
			<div class="row">
			<form method="post" action="action.php" name="myform7" target="blank">
				<label>AccountID.</label> <input type="number" name="AccountID"  value="" required>&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
				<label>ExternalID.</label> <input type="text" name="ExternalID"  value="" required><br />
				<label>Password.</label> <input type="password" name="Password"  value="" required ><br />
				<label>Gateway.</label> <input type="text" name="Gateway"  value="" required><br />
				<label>TCInstanceName.</label> <input type="text" name="TCInstanceName"  value="" required><br />
				<label>AccountGroup.</label> <input type="text" name="AccountGroup"  value="" required><br />
				<label>Connection.</label> <input type="text" name="Connection"  value="" required><br />
				<label>ParticipantLoginID.</label> <input type="text" name="ParticipantLoginID"  value="" required><br />
				<label>ParticipantPassword.</label> <input type="text" name="ParticipantPassword"  value="" required><br />
				<label>RootToMT4Server.</label> <input type="text" name="RootToMT4Server"  value="" required><br />
				<label>PStype.</label> <input type="text" name="PStype"  value="" required><br />
				<label>PSShare.</label> <input type="text" name="PSShare"  value="" required><br />
				<label>ShareInProfitOnly.</label> <input type="text" name="ShareInProfitOnly"  value="" required><br />
				<label>InstantDeduction.</label> <input type="text" name="InstantDeduction"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker4" value="" ><br />
				<input type="submit" name="UpdateAccount"  value="Update Account" class="submit"  >
			</form>
			</div>
		</li>
	</ul>
</li>

<li>
	<div>Get Gateways List</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetGatewaysList"  value="GetGatewaysList" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>AddGateway</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GTLogin.</label> <input type="text" name="GTLogin"  value="" required><br />
				<label>GTPassword.</label> <input type="password" name="GTPassword"  value="" required><br />
				<label>GatewayType.</label> <input type="text" name="GatewayType"  value="" required><br />
				<label>Platform.</label> <input type="text" name="Platform"  value="" required><br />
				<label>IP.</label> <input type="text" name="IP"  value="" required><br />
				<label>Port.</label> <input type="text" name="Port"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker5" value="" ><br />

				<input type="submit" name="AddGateway"  value="AddGateway" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>UpdateGateway</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GTLogin.</label> <input type="text" name="GTLogin"  value="" required><br />
				<label>GTPassword.</label> <input type="password" name="GTPassword"  value="" required><br />
				<label>GatewayType.</label> <input type="text" name="GatewayType"  value="" required><br />
				<label>Platform.</label> <input type="text" name="Platform"  value="" required><br />
				<label>IP.</label> <input type="text" name="IP"  value="" required><br />
				<label>Port.</label> <input type="text" name="Port"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker6" value="" ><br />

				<input type="submit" name="UpdateGateway"  value="UpdateGateway" class="submit" >
			</form>
		</div>
	</li></ul>
</li>


<li>
	<div>Get All TCInstances</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetAllTCInstances"  value="GetAllTCInstances" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add TCInstance</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>InstanceName.</label> <input type="text" name="InstanceName"  value="" required><br />
				<label>Login.</label> <input type="text" name="Login"  value="" required><br />
				<label>Password.</label> <input type="password" name="Password"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Port.</label> <input type="text" name="Port"  value="" required><br />
				<label>IP.</label> <input type="text" name="IP"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker7" value="" ><br />
				<input type="submit" name="AddTCInstance"  value="AddTCInstance" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Update TCInstance</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>InstanceName.</label> <input type="text" name="InstanceName"  value="" required><br />
				<label>Login.</label> <input type="text" name="Login"  value="" required><br />
				<label>Password.</label> <input type="password" name="Password"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Port.</label> <input type="text" name="Port"  value="" required><br />
				<label>IP.</label> <input type="text" name="IP"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker8" value="" ><br />
				<input type="submit" name="UpdateTCInstance"  value="UpdateTCInstance" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get All Symbols</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetAllSymbols"  value="GetAllSymbols" class="submit" >
			</form>
		</div>
	</li></ul>
</li>
		
<li>
	<div>Add Symbol</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>SymbolName.</label> <input type="text" name="SymbolName"  value="" required><br />
				<label>AssetClass.</label> <input type="text" name="AssetClass"  value="" required><br />
				<label>ContractSize.</label> <input type="text" name="ContractSize"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Digits.</label> <input type="text" name="Digits"  value="" required><br />
				<label>Spread.</label> <input type="text" name="Spread"  value="" required><br />
				<label>TickSize.</label> <input type="text" name="TickSize"  value="" required><br />
				<label>TickValue.</label> <input type="text" name="TickValue"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker9" value="" ><br />
				<input type="submit" name="AddSymbol"  value="AddSymbol" class="submit" >
			</form>
		</div>
	</li></ul>
</li>
     
<li>
	<div>Update Symbol</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>SymbolName.</label> <input type="text" name="SymbolName"  value="" required><br />
				<label>AssetClass.</label> <input type="text" name="AssetClass"  value="" required><br />
				<label>ContractSize.</label> <input type="text" name="ContractSize"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Digits.</label> <input type="text" name="Digits"  value="" required><br />
				<label>Spread.</label> <input type="text" name="Spread"  value="" required><br />
				<label>TickSize.</label> <input type="text" name="TickSize"  value="" required><br />
				<label>TickValue.</label> <input type="text" name="TickValue"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker10" value="" ><br />
				<input type="submit" name="UpdateSymbol"  value="Update Symbol" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get Gateway Connection List</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetGatewayConnectionList"  value="Get Gateway Connection List" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add GatewayConnection</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>ConnID.</label> <input type="text" name="ConnID"  value="" required><br />
				<label>GCLogin.</label> <input type="text" name="GCLogin"  value="" required><br />
				<label>GCPassword.</label> <input type="password" name="GCPassword"  value="" required><br />
				<label>IP.</label> <input type="text" name="IP"  value="" required><br />
				<label>Port.</label> <input type="text" name="Port"  value="" required><br />
				<label>ServerName.</label> <input type="text" name="ServerName"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>TargetCompID.</label> <input type="text" name="TargetCompID"  value="" required><br />
				<label>SenderCompID.</label> <input type="text" name="SenderCompID"  value="" ><br />
				<label>SenderSubID.</label> <input type="text" name="SenderSubID"  value="" required><br />
				<label>TradeIP.</label> <input type="text" name="TradeIP"  value="" required><br />
				<label>TradePort.</label> <input type="text" name="TradePort"  value="" required><br />
				<label>ServerAPIIP.</label> <input type="text" name="ServerAPIIP"  value="" required><br />
				<label>ServerAPIPort.</label> <input type="text" name="ServerAPIPort"  value="" required><br />
				<label>BrokerID.</label> <input type="text" name="BrokerID"  value="" required><br />
				<label>WalletAccount.</label> <input type="text" name="WalletAccount"  value="" required><br />
				<label>Gateway.</label> <input type="text" name="Gateway"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker11" value="" ><br />
				<input type="submit" name="AddGatewayConnection"  value="Add GatewayConnection" class="submit" >
			</form>
		</div>
	</li></ul>
</li>
	 
<li>
	<div>Update GatewayConnection</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>ConnID.</label> <input type="text" name="ConnID"  value="" required><br />
				<label>GCLogin.</label> <input type="text" name="GCLogin"  value="" required><br />
				<label>GCPassword.</label> <input type="password" name="GCPassword"  value="" required><br />
				<label>IP.</label> <input type="text" name="IP"  value="" required><br />
				<label>Port.</label> <input type="text" name="Port"  value="" required><br />
				<label>ServerName.</label> <input type="text" name="ServerName"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>TargetCompID.</label> <input type="text" name="TargetCompID"  value="" required><br />
				<label>SenderCompID.</label> <input type="text" name="SenderCompID"  value="" ><br />
				<label>SenderSubID.</label> <input type="text" name="SenderSubID"  value="" required><br />
				<label>TradeIP.</label> <input type="text" name="TradeIP"  value="" required><br />
				<label>TradePort.</label> <input type="text" name="TradePort"  value="" required><br />
				<label>ServerAPIIP.</label> <input type="text" name="ServerAPIIP"  value="" required><br />
				<label>ServerAPIPort.</label> <input type="text" name="ServerAPIPort"  value="" required><br />
				<label>BrokerID.</label> <input type="text" name="BrokerID"  value="" required><br />
				<label>WalletAccount.</label> <input type="text" name="WalletAccount"  value="" required><br />
				<label>Gateway.</label> <input type="text" name="Gateway"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker12" value="" ><br />
				<input type="submit" name="UpdateGatewayConnection"  value="Update GatewayConnection" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get Platform Details</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetPlatformDetails"  value="Get Platform Details" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add Platform</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>Platform.</label> <input type="text" name="Platform"  value="" required><br />
				<input type="submit" name="AddPlatform"  value="AddPlatform" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get TCInstance GatewayMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetTCInstanceGatewayMapping"  value="Get TCInstanceGatewayMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add TCInstanceGatewayMapping</div><!--DATABSE_SP_ERROR -->
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GatewayId.</label> <input type="text" name="GatewayId"  value="" required><br />
				<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br />
				<input type="submit" name="AddTCInstanceGatewayMapping"  value="AddTCInstanceGatewayMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Update TCInstanceGatewayMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GatewayId.</label> <input type="text" name="GatewayId"  value="" required><br />
				<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br />
				<input type="submit" name="UpdateTCInstanceGatewayMapping"  value="UpdateTCInstanceGatewayMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Delete TCInstanceGatewayMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GatewayId.</label> <input type="text" name="GatewayId"  value="" required><br />
				<label>TCInstanceId.</label> <input type="text" name="TCInstanceId"  value="" required><br />
				<input type="submit" name="DeleteTCInstanceGatewayMapping"  value="DeleteTCInstanceGatewayMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get AccountGroupConnection Mapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetAccountGroupConnectionMapping"  value="Get AccountGroup Mapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add AccountGroupConnectionMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>ConnGroupName.</label> <input type="text" name="ConnGroupName"  value="" required><br />
				<label>GroupID.</label> <input type="text" name="GroupID"  value="" required><br />
				<label>ConnID.</label> <input type="text" name="ConnID"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker13" value="" ><br />
				<input type="submit" name="AddAccountGroupConnectionMapping"  value="Add AccountGroup Mapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>
	 


<li>
	<div>Update AcountGroupConnectionMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>ConnGroupName.</label> <input type="text" name="ConnGroupName"  value="" required><br />
				<label>GroupID.</label> <input type="text" name="GroupID"  value="" required><br />
				<label>ConnID.</label> <input type="text" name="ConnID"  value="" required><br />
				<label>Active.</label> <input type="text" name="Active"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker15" value="" ><br />
				<input type="submit" name="UpdateAcountGroupConnectionMapping"  value="Update AcountGroup Mapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get GroupSymbolMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetGroupSymbolMapping"  value="GetGroupSymbolMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add GroupSymbolMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GroupName.</label> <input type="text" name="GroupName"  value="" required><br />
				<label>SymbolName.</label> <input type="text" name="SymbolName"  value="" required><br />
				<label>AliasName.</label> <input type="text" name="AliasName"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker16" value="" ><br />
				<input type="submit" name="AddGroupSymbolMapping"  value="Add GroupSymbolMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Update GroupSymbolMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GroupName.</label> <input type="text" name="GroupName"  value="" required><br />
				<label>SymbolName.</label> <input type="text" name="SymbolName"  value="" required><br />
				<label>AliasName.</label> <input type="text" name="AliasName"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker17" value="" ><br />
				<input type="submit" name="UpdateGroupSymbolMapping"  value="UpdateGroupSymbolMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Delete GroupSymbolMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>GroupName.</label> <input type="text" name="GroupName"  value="" required><br />
				<label>SymbolName.</label> <input type="text" name="SymbolName"  value="" required><br />
				<label>AliasName.</label> <input type="text" name="AliasName"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker18" value="" ><br />
				<input type="submit" name="DeleteGroupSymbolMapping"  value="DeleteGroupSymbolMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get MasterSlaveMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<input type="submit" name="GetMasterSlaveMapping"  value="Get MasterSlaveMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Add MasterSlaveMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>MasterAccount.</label> <input type="text" name="MasterAccount"  value="" required><br />
				<label>SlaveAccount.</label> <input type="text" name="SlaveAccount"  value="" required><br />
				<label>CopyMode.</label> <input type="text" name="CopyMode"  value="" required><br />
				<label>CloseOrders.</label> <input type="text" name="CloseOrders"  value="" required><br />
				<label>CopyMethod.</label> <input type="text" name="CopyMethod"  value="" required><br />
				<label>CopyValue.</label> <input type="text" name="CopyValue"  value="" required><br />
				<label>CopyTrade.</label> <input type="text" name="CopyTrade"  value="" required><br />
				<label>Slippage.</label> <input type="text" name="Slippage"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker19" value="" ><br />
				<input type="submit" name="AddMasterSlaveMapping"  value="Add MasterSlaveMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Update MasterSlaveMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>MasterAccount.</label> <input type="text" name="MasterAccount"  value="" required><br />
				<label>SlaveAccount.</label> <input type="text" name="SlaveAccount"  value="" required><br />
				<label>CopyMode.</label> <input type="text" name="CopyMode"  value="" required><br />
				<label>CloseOrders.</label> <input type="text" name="CloseOrders"  value="" required><br />
				<label>CopyMethod.</label> <input type="text" name="CopyMethod"  value="" required><br />
				<label>CopyValue.</label> <input type="text" name="CopyValue"  value="" required><br />
				<label>CopyTrade.</label> <input type="text" name="CopyTrade"  value="" required><br />
				<label>Slippage.</label> <input type="text" name="Slippage"  value="" required><br />
				<label>Date.</label> <input type="text" name="LastUpdatedtime" id="datepicker20" value="" ><br />
				<input type="submit" name="UpdateMasterSlaveMapping"  value="Update MasterSlaveMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Delete MasterSlaveMapping</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>MasterAccount.</label> <input type="text" name="MasterAccount"  value="" required><br />
				<label>SlaveAccount.</label> <input type="text" name="SlaveAccount"  value="" required><br />
				<input type="submit" name="DeleteMasterSlaveMapping"  value="Delete MasterSlaveMapping" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get OpenTrades</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>FromDate.</label> <input type="text" name="FromDate"  value=""  id="datepicker21" required><br />
				<label>ToDate.</label> <input type="text" name="ToDate"  value=""  id="datepicker22" required><br />
				<input type="submit" name="GetOpenTrades"  value="Get OpenTrades" class="submit" >
			</form>
		</div>
	</li></ul>
</li>


</ul> <!--End UI -->       
        
</div>

</td></tr></table>



<br /><br />
<div style="float:left; margin-left:-177px; width:136%;height:50px;background-image:url(images/header6.jpg); background-color:#337F95; color:#0e09c1;font-family: cursive;">
<div style="text-align:center; font-size:36px">2016</div> </div>

</body>


  

</html>