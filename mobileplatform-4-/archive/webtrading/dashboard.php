<!DOCTYPE html>
<html>
   <?php include("head.php"); ?>
  <body class="skin-blue sidebar-mini">
    <div class="wrapper">
      
      <?php include("main-header.php"); ?>
      <!-- Left side column. contains the logo and sidebar -->
      <?php include("main-sidebar.php"); ?>

      <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Dashboard
            <small>Control panel</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Dashboard</a></li>
            
          </ol>
        </section>

        <!-- Main content -->
        <section class="content">
          <!-- Small boxes (Stat box) -->
          <div class="row">
          <!-- 1st Row-->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3>Profile <br>Manager</h3>
                </div>
                <div class="icon">
                  <img src="images/pm.png" style="width:80px; height: 90px;">
                  <!--<i class="pion pion-pbag"></i>-->
                </div>
                <a href="profile_manager.php" class="small-box-footer">Profile Manager <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3>Add<br> Account</h3>
                </div>
                <div class="icon">
                  <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="add_account.php" class="small-box-footer">Add Account <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3>	Account<br> Manager</h3>
                 </div>
                <div class="icon">
                  <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="account_manager.php" class="small-box-footer">Account Manager <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>Account<br> Settings</h3>
                </div>
                <div class="icon">
                  <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="account_settings.php" class="small-box-footer">Settings <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            
             <!-- 2nd Row-->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3>Trade  <br>Report</h3>
                </div>
                <div class="icon">
                 <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="closed_trades_report.php" class="small-box-footer">Trade Report <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3>Partner<br> Area</h3>
                </div>
                <div class="icon">
                  <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="partner_area.php" class="small-box-footer">Partner Area <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3>	&nbsp;<br>Statistics </h3>
                 </div>
                <div class="icon">
                  <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="statistics.php" class="small-box-footer">Statistics <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>&nbsp;<br>Download</h3>
                </div>
                <div class="icon">
                 <img src="images/pm.png" style="width:80px; height: 90px;">
                </div>
                <a href="#" class="small-box-footer">Download <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            
                        
          </div><!-- /.row -->
          <!-- Main row -->
           <br><br><br><br><br><br><br><br>
           <?php //include("main-row.php"); ?>
          <!-- /.row (main row) -->

        </section><!-- /.content -->
      </div><!-- /.content-wrapper -->
      
      <?php include("main-footer.php"); ?>
      
      <!-- Control Sidebar -->      
  
      
      <!-- /.control-sidebar -->
      <!-- Add the sidebar's background. This div must be placed
           immediately after the control sidebar -->
      <!--<div class='control-sidebar-bg'></div>-->
    </div><!-- ./wrapper -->

   
  </body>
</html>