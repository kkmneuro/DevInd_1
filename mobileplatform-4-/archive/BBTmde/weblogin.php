<!DOCTYPE html>
<html>
<script type="text/javascript" src="js/jquery-1.9.1.js"></script>   
<script type="text/javascript" src="js/jquery.h5validate.js"></script>


  <?php include("head.php");  ?>
<body style="background-color:#444750">
  
<div id="login">
   <div class="login-page" style="background-color:#444750">
     <div class="login-box">
      <div class="login-logo" style="color:#FFFFFF">
        <b>BB</b>Trader
       <!--<img src="images/logo.png">-->
      </div><!-- /.login-logo -->
      
      <div class="login-box-body">
        <p class="login-box-msg">Sign in</p>
       <?php if(isset($_GET['wrong'])) { ?>
	 <div class="col-lg-1" style="color:#ff0000;font-size:16px; text-align: center; width:100%"><p>Invalid Username or Password</p></div>
 <?php }?>  
 
      <form name="login-form" action="contract_users.php" method="post" >
            <input type="text" name="username" id="username" class="form-control" placeholder="Username" value="<?php if(isset($_COOKIE['username'])) echo $_COOKIE['username']; ?>" />
           <br>
            <input type="password" name="password" id="password" class="form-control" placeholder="Password" value="<?php if(isset($_COOKIE['password'])) echo $_COOKIE['password']; ?>"/>
            <br>
            <p style="padding-left:0px;">Remember Password:</p> 
				 <input type="checkbox" id="remember" name="remember" <?php if(isset($_COOKIE['username'])){echo "checked='checked'"; } ?> value="1"   style="float: left;
    margin-left: 150px; margin-top: -25px; width: 20px; height: 15px;" /> 
               <br>    
              <input type="submit" name="submit"  id="login_send" value="Sign In" style="margin-left:120px;" class="btn btn-primary" >  
            
             
     </form>        
            <!-- /.col -->
          </div>

        
      </div><!-- /.login-box-body -->
     
    </div>
</div> 

<!-- ./Market -->

    <!-- jQuery 2.1.4 -->
 
  </body>
</html>