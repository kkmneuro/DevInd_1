<?php
/*session_start();
include "functions.php";
$db = new PHP_function;
//print_r($_SESSION);die;
define("MT4URL", "http://148.251.187.214:8877/");
ini_set('display_errors',false);
	
if(!$_SESSION){
	header("location:index.php");
}



	$query=mysql_query("select * from profile where ProfileID='".$_SESSION["ProfileID"]."'");
	$result=mysql_fetch_array($query);
	//print_r($result);*/
				
?>
<header class="main-header" style="color:#FFFFFF; background-color:#367fa9">
        <!-- Logo -->
   <div id="title_message">
        <a href="#" class="logo">
          <!-- mini logo for sidebar mini 50x50 pixels -->
          <span class="logo-mini"><b>T</b>R</span>
          <!-- logo for regular state and mobile devices -->
          <span class="logo-lg"><b>Web</b>Trading</span>
        
        </a>
   </div>
        <!-- Header Navbar: style can be found in header.less -->
        <nav class="navbar navbar-static-top" role="navigation">
        
          <!-- Sidebar toggle button-->
          <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
            <span class="sr-only">Toggle navigation</span>
          </a>
          
          <div id="HeadMarket"><h4 style="margin-top: 14px;margin-left: 50px;">Market Watch</h4></div>
          <div id="HeadOpentrade" style="display:none"><h4 style="margin-top: 14px;margin-left: 50px;" >Open Trades</h4></div>
          <div id="HeadOpenOrders" style="display:none"><h4 style="margin-top: 14px;margin-left: 50px;" >Open Orders</h4></div>
          <div id="HeadHistory" style="display:none"><h4 style="margin-top: 14px;margin-left: 50px;" >History</h4></div>
          <div id="HeadAccount" style="display:none"><h4 style="margin-top: 14px;margin-left: 50px;" >Accounts</h4></div>
          <div id="HeadChart" style="display:none"><h4 style="margin-top: 14px;margin-left: 50px;" >Chart</h4></div>
          
          <div class="navbar-custom-menu">
            <ul class="nav navbar-nav">
              <!-- Messages: style can be found in dropdown.less-->
              
              <!-- Notifications: style can be found in dropdown.less -->
              
              <!-- Tasks: style can be found in dropdown.less -->
              
              <!-- User Account: style can be found in dropdown.less -->
              
              <!-- Control Sidebar Toggle Button -->
              <!--<li>
                <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
              </li>-->
            </ul>
          </div>
        </nav>
      </header>