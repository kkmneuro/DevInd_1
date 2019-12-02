<?php
session_start();
?>
<!DOCTYPE html>
<html>
<script type="text/javascript" src="js/jquery-1.9.1.js"></script>   
<script type="text/javascript" src="js/jquery.h5validate.js"></script>
<!--<script>
$(document).ready(function () {
    $('form').h5Validate();
	});
</script>-->
	
<script>	
function Market() // no ';' here
{

   //alert('market');
	$("#login").css({ display: "none" });                
	$("#Market").css({ display: "block" });  
                    
}
	
</script>

  <?php include("head.php");  ?>
<body style="background-color:#444750">
  
<div id="login">
   <div class="login-page" style="background-color:#444750">
     <div class="login-box">
      <div class="login-logo" style="color:#FFFFFF">
        <b>Web</b>Trading
      </div><!-- /.login-logo -->
      
      <div class="login-box-body">
        <p class="login-box-msg">Sign in</p>
         
      <form name="login-form" action="contract_users.php" method="post" >
            <input type="email" name="email" id="email" class="form-control" placeholder="Email" required/>
           <br>
            <input type="password" name="password" id="password" class="form-control" placeholder="Password" required/>
            <br>
              <input type="submit" name="submit" value="Sign In"  onClick="Market()" style="margin-left:120px;" class="btn btn-primary" >  
     </form>        
            <!-- /.col -->
          </div>

        
      </div><!-- /.login-box-body -->
     
    </div>
</div> 

<div id="Market" style="display:none;">

    <div class="wrapper">
       <?php include("main-header.php"); ?>
       <?php include("main-sidebar.php"); ?>
      <div class="content-wrapper">
         <section class="content-header">
          <h1>Market Watch</h1>
          
         </section>
        <!-- Main content -->
        <section class="content">
        <!--<iframe id='iframe2' src="http://localhost/websocketclient/half_symbols.php" frameborder="0" style="overflow: hidden; height: 100%; width: 100%; position: absolute;" height="100%" width="100%"></iframe> -->
        
        <table border="0" width="50%">
        <tr><th>Currency</th><th>Bid</th><th>Ask</th></tr>
        <tr><td>AUAUAU</td><td>12.67</td><td>45.12</td></tr>
        </table>
        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
      
      <?php include("main-footer.php"); ?>
      
     
    </div><!-- ./wrapper -->

</div><!-- ./Market -->

    <!-- jQuery 2.1.4 -->
 
  </body>
</html>