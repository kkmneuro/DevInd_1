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
changeYear: true,
minDate: -0, 
maxDate:30000
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

});


 
</script>




<script>
/*function popUp(strURL,strType,strHeight,strWidth) {
var strOptions="";
if (strType=="console") strOptions="resizable,height="+strHeight+",width="+strWidth;
if (strType=="fixed") strOptions="status,height="+strHeight+",width="+strWidth;
if (strType=="elastic") strOptions="toolbar,menubar,scrollbars,resizable,location,height="+strHeight+",width="+strWidth;
window.open(strURL, 'newWin', strOptions);
}*/
</script>

</head>
<body>
<table border="0" width="100%">
<tr style="height:100px; background-image:url(images/header2.jpg);background-size: 1330px 90px; color:#F9285F"><td><p style="font-size:36px; text-align:center">MT4 PHP API </p></td></tr>
<tr><td style="background-color:#D3DFD7;"> 

<div class="container" id="main_container">

        
<!--<a id="opn" class="btn btn-warning more-info" href="#">View Result</a>-->
<?php
error_reporting(1);
$token='';
$token=$_GET['token'];
if(isset($token)!="") {?>
<script> $(document).ready(function () { $("#my-tree").hide(); }); </script>
<div id="bkg" class="blockbkg" style="display: block;">
<div id="dlg" class="cont" style="display: block;">
<div id="closebtn" class="closebtn" title="Close"></div>
<h2 style="text-align:center;color: blue;">MT4 Response</h2>
<?php	
		$i=1;
		if (file_exists('C:\wamp\www\mt4ui_local_webservice\xmlfile\mt4response.xml')) 
			{
				$xml=simplexml_load_file("C:\wamp\www\mt4ui_local_webservice\xmlfile\mt4response.xml");
		
				echo "<div style='color: blue;font-size: 22px;'>".$xml->getName()."</div>";
				echo "<br><hr>";
				foreach($xml->children() as $child)
				   {
				   echo "<div style='background-color: rgb(180, 228, 228);padding-left: 30px;font-size: 19px;'>";
					//echo "S.No.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: ".$i."<br>";
					echo $child->getName() . "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " . $child . "<br>";
				   
					   foreach($child->children() as $child)
					   {
						echo $child->getName() . "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " . $child . "<br>";
						
						foreach($child->children() as $child)
						   {
							echo $child->getName() . "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : " . $child . "<br>";
						   }
					   }
					   echo "</div>";
					   echo "<hr>";
					   $i++;
					   
				   } 
				
			} 
		else 
			{
				exit('Failed to open mt4response.xml.');
			}
            ?>
            </div>
</div>

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
			<!--<li><div> Account  history and Active Trade</div>
            <ul><li>
            
<div class="row">
<form method="post" action="MT4Details.php">

<label>Account No.</label> <input type="text" name="accountno"  value="" ><br />
		<input type="submit" name="AccountHistory"  value="Login Details" class="submit" >
		</form></div>
        
        </li></ul></li>-->
  
<!--  
<li> <div> Bulk bonus credit change</div>
<ul><li>
            
<div class="row">
<form method="post" action="MT4Details.php" >

<label>Account No.</label> <input type="text" name="accountno"  value="" ><br />
<label>Amount.</label> <input type="text" name="amount"  value="" ><br />

		<input type="submit" name="BulkChangeCredit"  value="Bulk credit change" class="submit">
     
		</form></div>
        
        </li></ul></li>
-->
<!--
<li><div> Change agent commission</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Account No.</label> <input type="text" name="accountno"  value="" ><br />
<label>Commission </label><input type="text" name="commission"  value="" ><br />
		<input type="submit" name="ChangeAgentCommission"  value="Change Commission"  class="submit">
        </form></div></li></ul></li>
  -->
  <li><div>Set Server</div>
<ul><li>
<div class="row">
<form method="post" action="mt4ui.php"  name="myform">
<label>Server name.</label>  <?php
///////////       Start get and start MT4 Groups    /////////// 
		/*$ch = curl_init();
		curl_setopt($ch, CURLOPT_URL,"MT4Details.php");
		curl_setopt($ch, CURLOPT_POST, 1);
		curl_setopt($ch, CURLOPT_POSTFIELDS,   http_build_query(array('GetServers' => 'GetServers')));
		// receive server response ...
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
		$server_output = curl_exec ($ch);
		curl_close ($ch);
		// further processing ....
		if ($server_output == "OK") { echo 'ok'; } else { echo ''; }

		$xml=simplexml_load_file("mt4response.xml") or die("Error: Cannot create object");
		 $servername1=$xml->Server[0];
		 $servername2=$xml->Server[1];*/
		/*print_r($xml); 
			foreach ($xml as $syn) 
			{
				echo '='.$Server=$syn->Server; 
				 
			}die;*/
///////////       End get and start MT4 Groups    /////////// 
?>
        <select name="server" style="border: 1px solid; height: 25px;  width: 200px;">
        <!--<option value="">Select Server </option>-->
        <option value="<?php echo $servername1; ?>"><?php echo $servername1; ?></option>
        <option value="<?php echo $servername2; ?>"><?php echo $servername2; ?></option>
        </select>
        <br /><br />
		 <input type="submit" name="SetServer"  value="Set Server" class="submit" >
		</form></div></li></ul></li>
        
<li><div> Get Servers</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
		<input type="submit" name="GetServers"  value="Get Servers" class="submit">
		</form></div></li></ul></li>        
<li><div> Change Balance</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php"  name="myform">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Balance </label><input type="text" name="balance" value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
		 <input type="submit" name="ChangeBalance"  value="Change Balance" class="submit" onclick="return validate_ChangeBalance()">
		</form></div></li></ul></li>
        
<li><div>Change Credit</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform7">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Credit </label><input type="text" name="credit"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Expiry</label> <input type="text" name="expiry"  id="datepicker7" value="" >&nbsp;&nbsp;*&nbsp;(e.g. MM/DD/YYYY)<br />
		<input type="submit" name="ChangeCredit"  value="Change Credit" class="submit" onclick="return validate_changecredit()" >
		</form></div></li></ul></li>
        
<li><div>Change Password</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform5">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Password </label><input type="text" name="oldpass"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. pAss321)<br />
<label>New Password</label><input type="text" name="newpass"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. pAss321)<br />
<input type="submit" name="ChangePassword"  value="Change Passwprd" class="submit" onclick="return validate_changepassword()" >
		</form></div></li></ul></li>
<!--
<li><div>Change Investor Password</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Account No.</label> <input type="text" name="accountno"  value="" ><br />
<label>Password </label><input type="text" name="oldpass"  value="" ><br />
<label>New Password</label><input type="text" name="newpass"  value="" ><br />
<input type="submit" name="ChangeInvestorPassword"  value="Change Passwprd" class="submit" >
		</form></div></li></ul></li>
	-->	
<li><div>Check Password</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform4">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Password </label><input type="text" name="pass"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. pAss321)<br />

<input type="submit" name="CheckPAssword"  value="Check password" class="submit" onclick="return validate_checkpassword()" >
		</form></div></li></ul></li>

<!--
<li><div> Close Order</div>
-->
<div class="row"></div></li>
<li><div> Create Account</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform1">
<label>Login</label> <input type="text" name="login"  value="" ><br />
<label>Group </label><input type="text" name="group"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. Groupname)<br />
<label>password </label><input type="text" name="password"  value="" ><br />
<label>enable</label> <input type="text" name="enable"  value="" ><br />
<label>enable_change_password </label><input type="text" name="enable_change_password"  value="" ><br />
<label>enable_read_only </label><input type="text" name="enable_read_only"  value="" ><br />
<label>password_investor</label> <input type="text" name="password_investor"  value="" ><br />
<label>password_phone </label><input type="text" name="password_phone"  value="" ><br />
<label>name</label><input type="text" name="name"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. prabhat)<br />
<label>country</label> <input type="text" name="country"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. India)<br />
<label>city </label><input type="text" name="city"  value="" ><br />
<label>state </label><input type="text" name="state"  value="" ><br />
<label>zipcode</label> <input type="text" name="zipcode"  value="" ><br />
<label>address </label><input type="text" name="address"  value="" ><br />
<label>phone </label><input type="text" name="phone"  value="" ><br />
<label>email</label> <input type="text" name="email"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>id </label><input type="text" name="id"  value="" ><br />
<label>status</label> <input type="text" name="status"  value="" ><br />
<label>leverage </label><input type="text" name="leverage"  value="" ><br />
<label>agent_account </label><input type="text" name="agent_account"  value="" ><br />
<label>balance</label> <input type="text" name="balance"  value="" ><br />
<label>prevmonthbalance </label><input type="text" name="prevmonthbalance"  value="" ><br />
<label>prevbalance </label><input type="text" name="prevbalance"  value="" ><br />
<label>credit</label> <input type="text" name="credit"  value="" ><br />
<label>interestrate </label><input type="text" name="interestrate"  value="" ><br />
<label>taxes </label><input type="text" name="taxes"  value="" ><br />
<label>prevmonthequity</label> <input type="text" name="prevmonthequity"  value="" ><br />
<label>prevequity </label><input type="text" name="prevequity"  value="" ><br />
<label>publickey </label><input type="text" name="publickey"  value="" ><br />
<label>send_reports</label> <input type="text" name="send_reports"  value="" ><br />
<label>mqid </label><input type="text" name="mqid"  value="" ><br />

<input type="submit" name="CreateAccount"  value="Create Account" class="submit" onclick="return validate_createaccount();" >


		</form></div></li></ul></li>
<!--
	<li> <div> Create  group</div>
-->
<!--
<div class="row"></div></li>
<li><div> Delete  account</div>
-->
<div class="row"></div></li>
<li><div> Get  Account Balance</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform6">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />


		<input type="submit" name="GetAccountBalance"  value="Get Balance" class="submit" onclick="return validate_getaccountbalance()" >
		</form>
</div></li></ul></li>

<div class="row"></div></li>
<li><div> Get  Account Info</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform3">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />


		<input type="submit" name="GetAccountInfo"  value="Account Info" class="submit" onclick="return validate_getaccountinfo()">
		</form>
</div></li></ul></li>

<li><div>Get Accounts</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
		<input type="submit" name="GetAccounts"  value="Get Accounts" class="submit">
		</form></div></li></ul></li>
<!--
<div class="row"></div></li>
<li><div> Get  all balances</div>
-->
<div class="row"></div></li>
<li><div> Get  balances operations</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Account No.</label> <input type="text" name="accountno"  value="" ><br />
<label>From Time </label><input type="text" name="fromtime" id="datepicker3"  value="" ><br />
<label>To Time </label><input type="text" name="totime" id="datepicker4"  value="" ><br />

		<input type="submit" name="GetBalancesOperations"  value="Get Balances Operations" class="submit">
		</form>
</div></li></ul></li>

<li><div> Get  group</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform8">
<label>Group ID</label> <input type="text" name="groupid"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 3299N)<br />
		<input type="submit" name="GetGroupRecord"  value="Get Group" class="submit" onclick="return validate_getgroup()">
		</form></div></li></ul></li>
        
<li><div> Get  groups</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Group ID</label> <input type="text" name="groupid"  value="" ><br />
		<input type="submit" name="GetGroups"  value="Get Groups" class="submit">
		</form></div></li></ul></li>
        
<li><div> Get  history</div>
<ul><li><div class="row">
<form method="post" action="MT4Details.php" name="myform9">
<label>Account No.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>From</label> <input type="text" name="fromtime" id="datepicker"  value="" ><br />
<label>To time</label> <input type="text" name="totime"  id="datepicker1" value="" ><br />
<input type="submit" name="GetHistory"  value="Get history" class="submit" onclick="return validate_gethistory()">
		</form></div></li></ul></li>
        
        

<li><div> Get  journal</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Filter</label> <input type="text" name="filter"  value="" ><br />
<label>From</label> <input type="text" name="fromtime" id="datepicker5"  value="" ><br />
<label>To time</label> <input type="text" name="totime"  id="datepicker6" value="" ><br />
		<input type="submit" name="Getjournal"  value="Get journal" class="submit" >
		</form></div></li></ul></li>
        
        
<li><div> Get  leverage of group</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform16">
       <label>Group ID</label> <input type="text" name="groupid"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 3299N)<br />
		<input type="submit" name="GetLeverageOfGroup"  value="Get leverage" class="submit" onclick="return validate_getleverageofgroup()" >
		</form></div></li></ul></li>
		
<li><div> Get All leverage</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
       	<input type="submit" name="GetAllLeverage"  value="Get leverage" class="submit" >
		</form></div></li></ul></li>


<li><div> Get  margin info</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform10">
 <label>Group ID</label> <input type="text" name="groupid"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 3299N)<br />
		<input type="submit" name="GetMarginInfo"  value="Get Margin" class="submit" onclick="return validate_getmagicinfo()" >
		</form></div></li></ul></li>
        
<li><div> Get  opened trades</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
		<input type="submit" name="GetOpenedTrades"  value="Open Trades" class="submit" >
		</form></div></li></ul></li>

<!--
<li><div> All  open trades</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
		<input type="submit" name="opentrades"  value="Open Trades" class="submit" >
		</form></div></li></ul></li>
-->
<!--
<li><div> Get  open orders</div></li>
-->
<!--
<li><div> Get  plugin</div></li>
-->
<li><div> Get  symbols</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
		<input type="submit" name="SymbolsGetAll"  value="Get Symbols" class="submit">
		</form></div></li></ul></li>
<!--        
<li><div> Get  trading volume</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Account No.</label> <input type="text" name="accountno"  value="" ><br />
		<input type="submit" name="GetTradingVolume"  value="Trading Volume" class="submit" >
		</form></div></li>
        </ul></li>
-->
<!--
<li><div> Get  version</div></li>
-->
<li><div> Modify  account</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform2">

<label>Login</label> <input type="text" name="login"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Group </label><input type="text" name="group"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 3299N)<br />
<label>password </label><input type="text" name="password"  value="" ><br />
<label>enable</label> <input type="text" name="enable"  value="" ><br />
<label>enable_change_password </label><input type="text" name="enable_change_password"  value="" ><br />
<label>enable_read_only </label><input type="text" name="enable_read_only"  value="" ><br />
<label>password_investor</label> <input type="text" name="password_investor"  value="" ><br />
<label>password_phone </label><input type="text" name="password_phone"  value="" ><br />
<label>name</label><input type="text" name="name"  value="" ><br />
<label>country</label> <input type="text" name="country"  value="" ><br />
<label>city </label><input type="text" name="city"  value="" ><br />
<label>state </label><input type="text" name="state"  value="" ><br />
<label>zipcode</label> <input type="text" name="zipcode"  value="" ><br />
<label>address </label><input type="text" name="address"  value="" ><br />
<label>phone </label><input type="text" name="phone"  value="" ><br />
<label>email</label> <input type="text" name="email"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>id </label><input type="text" name="id"  value="" ><br />
<label>status</label> <input type="text" name="status"  value="" ><br />
<label>leverage </label><input type="text" name="leverage"  value="" ><br />
<label>agent_account </label><input type="text" name="agent_account"  value="" ><br />
<label>balance</label> <input type="text" name="balance"  value="" ><br />
<label>prevmonthbalance </label><input type="text" name="prevmonthbalance"  value="" ><br />
<label>prevbalance </label><input type="text" name="prevbalance"  value="" ><br />
<label>credit</label> <input type="text" name="credit"  value="" ><br />
<label>interestrate </label><input type="text" name="interestrate"  value="" ><br />
<label>taxes </label><input type="text" name="taxes"  value="" ><br />
<label>prevmonthequity</label> <input type="text" name="prevmonthequity"  value="" ><br />
<label>prevequity </label><input type="text" name="prevequity"  value="" ><br />
<label>publickey </label><input type="text" name="publickey"  value="" ><br />
<label>send_reports</label> <input type="text" name="send_reports"  value="" ><br />
<label>mqid </label><input type="text" name="mqid"  value="" ><br />

<input type="submit" name="ModifyAccount"  value="Modify Account" class="submit" onclick="return validate_modifyaccount()" >


		</form></div></li></ul></li>

<!--		
<li><div> Modify  group</div></li>
-->
<li><div> Modify  order</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform12">
<label>type</label> <input type="text" name="type"  value="" ><br />
<label>reserved</label> <input type="text" name="reserved"  value="" ><br />
<label>cmd </label><input type="text" name="cmd"  value="" ><br />
<label>order </label><input type="text" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>orderby</label> <input type="text" name="orderby"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>symbol </label><input type="text" name="symbol"  value="" ><br />
<label>volume </label><input type="text" name="volume"  value="" ><br />
<label>price</label> <input type="text" name="price"  value="" ><br />
<label>sl </label><input type="text" name="sl"  value="" ><br />
<label>tp</label><input type="text" name="tp"  value="" ><br />
<label>ie_deviation</label> <input type="text" name="ie_deviation"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>expiration </label><input type="text" name="expiration"  value="" ><br />
<label>crc</label> <input type="text" name="crc"  value="" ><br />

<input type="submit" name="ModifyOrder"  value="Modify Order" class="submit"  onclick="return validate_modifyorder()">


		</form></div></li></ul></li>

<li><div> Modify  pending order</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform14">
<label>type</label> <input type="text" name="type"  value="" ><br />
<label>reserved</label> <input type="text" name="reserved"  value="" ><br />
<label>cmd </label><input type="text" name="cmd"  value="" ><br />
<label>order </label><input type="text" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>orderby</label> <input type="text" name="orderby"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>symbol </label><input type="text" name="symbol"  value="" ><br />
<label>volume </label><input type="text" name="volume"  value="" ><br />
<label>price</label> <input type="text" name="price"  value="" ><br />
<label>sl </label><input type="text" name="sl"  value="" ><br />
<label>tp</label><input type="text" name="tp"  value="" ><br />
<label>ie_deviation</label> <input type="text" name="ie_deviation"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>expiration </label><input type="text" name="expiration"  value="" ><br />
<label>crc</label> <input type="text" name="crc"  value="" ><br />

<input type="submit" name="ModifyPendingOrder"  value="Modify Order" class="submit" onclick="return validate_modifypendingorder()" >


		</form></div></li></ul></li>



<li><div> Open  order</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform11">
<label>type</label> <input type="text" name="type"  value="" ><br />
<label>reserved</label> <input type="text" name="reserved"  value="" ><br />
<label>cmd </label><input type="text" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g.  BUY=0,SELL=1<br />
<label>order </label><input type="text" name="order"  value="" ><br />
<label>orderby (LoginId) </label> <input type="text" name="orderby"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>symbol </label><input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br />
<label>volume </label><input type="text" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>price</label> <input type="text" name="price"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>sl </label><input type="text" name="sl"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>tp</label><input type="text" name="tp"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>ie_deviation</label> <input type="text" name="ie_deviation"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>expiration </label><input type="text" name="expiration"  value="" ><br />
<label>crc</label> <input type="text" name="crc"  value="" ><br />

<input type="submit" name="OpenOrder"  value="Open Order" class="submit"  onclick="return validate_openorder()">


		</form></div></li></ul></li>

<li><div> Open  pending order</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform13">
<label>type</label> <input type="text" name="type"  value="" ><br />
<label>reserved</label> <input type="text" name="reserved"  value="" ><br />
<label>cmd </label><input type="text" name="cmd"  value="" >&nbsp;&nbsp;*&nbsp;(e.g.  BUY=0,SELL=1)<br />
<label>order </label><input type="text" name="order"  value="" ><br />
<label>orderby</label> <input type="text" name="orderby"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>symbol </label><input type="text" name="symbol"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. EURUSD)<br />
<label>volume </label><input type="text" name="volume"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>price</label> <input type="text" name="price"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>sl </label><input type="text" name="sl"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>tp</label><input type="text" name="tp"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>ie_deviation</label> <input type="text" name="ie_deviation"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. comments)<br />
<label>expiration </label><input type="text" name="expiration" id="datepicker8" value="" ><br />
<label>crc</label> <input type="text" name="crc"  value="" ><br />

<input type="submit" name="OpenPendingOrder"  value="Open Order" class="submit" onclick="return validate_openpendingorder()" >


		</form></div></li></ul></li>

<!--<li><div> Pumping </div></li>-->

<li><div> Send  email</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform15">
<label>Mail To(LoginId)</label> <input type="text" name="ToLoginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Sender LoginId</label> <input type="text" name="SenderloginId"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>Sender Name</label> <input type="text" name="SenderName"  value="" ><br />
<label>Subject</label> <input type="text" name="Subject"  value="" ><br />
<label>Body </label><textarea name="Message" ></textarea><br /><br />

		<input type="submit" name="SendMail"  value="Send email" class="submit" onclick="return validate_sendemail()">
		</form></div></li></ul></li>
        

<li><div> Transfer  balance</div>
<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>From Account No.</label> <input type="text" name="fromac"  value="" ><br />
<label>to Account No.</label> <input type="text" name="toac"  value="" ><br />
<label>Balance </label><input type="text" name="balance"  value="" ><br />

		<input type="submit" name="TransferBalance"  value="Transfer" class="submit">
		</form></div></li></ul></li>
 
 <li><div> Get Expouser</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Currency.</label> <input type="text" name="currency"  value="" ><br />


		<input type="submit" name="GetExposure"  value="Get Exposure" class="submit">
		</form>
</div></li></ul></li>


<li><div> Delete Account</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php">
<label>Account</label> <input type="text" name="accountno"  value="" ><br />


		<input type="submit" name="DeleteAccount"  value="Delete Account" class="submit">
		</form>
</div></li></ul></li>

<li><div> Close  order</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform11">
<label>type</label> <input type="text" name="type"  value="" ><br />
<label>reserved</label> <input type="text" name="reserved"  value="" ><br />
<label>cmd </label><input type="text" name="cmd"  value="" ><br />
<label>order </label><input type="text" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>orderby (LoginId) </label> <input type="text" name="orderby"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>symbol </label><input type="text" name="symbol"  value="" ><br />
<label>volume </label><input type="text" name="volume"  value="" ><br />
<label>price</label> <input type="text" name="price"  value="" ><br />
<label>sl </label><input type="text" name="sl"  value="" ><br />
<label>tp</label><input type="text" name="tp"  value="" ><br />
<label>ie_deviation</label> <input type="text" name="ie_deviation"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>expiration </label><input type="text" name="expiration"  value="" ><br />
<label>crc</label> <input type="text" name="crc"  value="" ><br />

<input type="submit" name="CloseOrder"  value="CloseOrder" class="submit" >


		</form></div></li></ul></li>

<li><div> Delete  order</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform11">
<label>type</label> <input type="text" name="type"  value="" ><br />
<label>reserved</label> <input type="text" name="reserved"  value="" ><br />
<label>cmd </label><input type="text" name="cmd"  value="" ><br />
<label>order </label><input type="text" name="order"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>orderby (LoginId) </label> <input type="text" name="orderby"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<label>symbol </label><input type="text" name="symbol"  value="" ><br />
<label>volume </label><input type="text" name="volume"  value="" ><br />
<label>price</label> <input type="text" name="price"  value="" ><br />
<label>sl </label><input type="text" name="sl"  value="" ><br />
<label>tp</label><input type="text" name="tp"  value="" ><br />
<label>ie_deviation</label> <input type="text" name="ie_deviation"  value="" ><br />
<label>comment </label><input type="text" name="comment"  value="" ><br />
<label>expiration </label><input type="text" name="expiration"  value="" ><br />
<label>crc</label> <input type="text" name="crc"  value="" ><br />

<input type="submit" name="DeleteOrder"  value="DeleteOrder" class="submit" >


		</form></div></li></ul></li>
		
		
		<li><div> Get PNL Comm and Swap </div>
<ul><li><div class="row">
<form method="post" action="MT4Details.php" name="myform9">
<label>From</label> <input type="text" name="fromtime" id="datepicker9"  value="" ><br />
<label>To time</label> <input type="text" name="totime"  id="datepicker10" value="" ><br />
<label>Account NOs.</label> <input type="text" name="accountno"  value="" >&nbsp;&nbsp;*&nbsp;(e.g. 0 to 9)<br />
<input type="submit" name="GetAccountsPnlCommissionSawp"  value="Get PCS" class="submit" onclick="return validate_GetAccountsPnlCommissionSawp()">
		</form></div></li></ul></li>


<li><div> Delete File</div>

<ul><li>
<div class="row">
<form method="post" action="MT4Details.php" name="myform3">
<label>File Name.</label> <input type="text" name="filename"  value="" ><br />
		<input type="submit" name="DeleteFile"  value="Delete File" class="submit">
		</form>
</div></li></ul></li>



      
</ul>        
        
</div>

</td></tr></table>



<br />
<div style="float:left; margin-left:-177px; width:136%;height:50px; background-color:#337F95; color:#000000">
<div style="text-align:center; font-size:36px">2015</div> </div>

</body>


  

</html>
