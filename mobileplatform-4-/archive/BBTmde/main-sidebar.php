<aside class="main-sidebar">
        <!-- sidebar: style can be found in sidebar.less -->
        <section class="sidebar" style="height:680px;">
         <div class="user-panel">
            <div class="pull-left image">
              <img src="images/nouserimage.jpg" class="user-image" alt="User Image"/>
              
            </div>
            <div class="pull-left info">
              <p style="color:#FFFFFF"><?php echo strtoupper($_SESSION['username']); ?></p>

              <a href="#"><i class="fa fa-circle text-success"></i> PRACTIVE MODE</a>
            </div>
          </div>
          <ul class="sidebar-menu">
            <!--<li class="header">MAIN NAVIGATION</li>-->
            
            <!--<li class="active treeview">
              <a href="#">
                <i class="fa fa-dashboard"></i> <span>The Dashboard</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
              
              <ul class="treeview-menu">-->
                              
                <li><a href="#" onclick="MarketWatch()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>Market Watch </a></li>
                <li><a href="#" onclick="Opentrade()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>Open Trades</a></li>
                <li><a href="#" onclick="Openorders()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>Open Orders</a></li>
                <li><a href="#" onclick="TradeHistory()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>History</a></li>
                <li><a href="#" onclick="Account()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>Accounts </a></li>
                <li><a href="#" onclick="Chart()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>Chart </a></li>
                <li><a href="#" onclick="connectionclose()" class="sidebar-toggle" data-toggle="offcanvas" ><i class="fa fa-circle-o"></i>Log Out</a></li>
               
                
             <!-- </ul>
            </li>-->
          
          
          </ul>
        </section>
        <!-- /.sidebar -->
      </aside>