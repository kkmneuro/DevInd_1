<?php
session_start();
error_reporting(0);
ini_set("display_errors", 1);
$userId=2365;
$token="gu8lsuwnff";

include("inc/header_trade.php");
include("config.php");
?>

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

function msg4(){
$("#msg").show();
}
</script>

<form name="login-form" action="contract_users.php" method="post" >

<div class="logins" id="login"  style="margin-top:50px; margin-left:15px;">       
               
        <div class="header">
            <?php if(@$_GET['lg']=='BT'){ ?>
			<div>BT&nbsp;<span>Trader</span></div>
			
			<?php } else if(@$_GET['lg']=='RS'){ ?>
			<div> RAJ&nbsp;<span>SILK</span></div>
			<?php } else {?>
            
            <div>BB&nbsp;<span>Trader</span></div>
			<?php } ?>
        </div>
        
        <table border="0">
                <tr>
               <!-- <p><b>Sign In</b></p>-->
        <td>
<?php if(isset($_GET['wrong'])) { ?>
	 <div class="col-lg-1" style="color:#ff0000;font-size:14px;"><p>Invalid Username or Password</p></div>
 <?php } ?> 
        <hr>
<br>
        </td>
        </tr>
        
        <tr>
       
        <div id="msg"><h4 style="margin-left:8px;">connecting...</h4></div>
      
        <td>
                <input type="text"  name="username" id="username" placeholder="Username" value="<?php if(isset($_COOKIE['username'])) echo $_COOKIE['username']; ?>"><br>
                </td>
                </tr>
<tr>
<td>
                <input type="password"  name="password" id="password" placeholder="Password"  value="<?php if(isset($_COOKIE['password'])) echo $_COOKIE['password']; ?>"><br>
                </td>
                </tr>
<tr><td><p style="padding-left:0px;">Remember Password:</p> 
				 <input type="checkbox" id="remember" name="remember" <?php if(isset($_COOKIE['username'])){echo "checked='checked'"; } ?> value="1"   style="float:right; margin-right:20px; margin-top: -30px;  width: 20px; height: 20px;" /> 
                <br></td></tr>
                
               


<tr>
<td>
                <input type="submit" value="Login" id="login_send" name="submit" class="button50" onclick="msg4();">
                </td>
                </tr>
                </table>
 </div>
 </form>