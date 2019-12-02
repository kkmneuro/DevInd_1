<!DOCTYPE html>
<html>
<?php include("head.php"); ?>
    <body class="skin-black">
        <?php include "layout/header.php" ?>
        <div class="wrapper row-offcanvas row-offcanvas-left">
            <?php //include "layout/left_sidebar.php" ?>
            <aside class="right-side">
                <section class="content-header">
                    <h1>
                      How to create Dynamic modal dialog form bootstrap
                    </h1>
                </section>
                <section class="content" >
                    <div class="box box-primary">
                <div class="row">
                    <div class="col-md-2">
                        <select class="form-control" id="mysize">
                          <option value="small">Small</option>
                          <option value="standart">Standart</option>
                          <option value="large">Large</option>
                        </select>
                    </div>
                </div><br/>
 
                 <div class="row">
                    <div class="col-md-4">
<button type="button" class="btn btn-primary btn-lg" onClick="open_container();" > Launch demo modal</button>
                    </div>
                </div>
                <!-- Modal form-->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div class="modal-dialog ">
                    <div class="modal-content">
                      <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel"></h4>
                      </div>
                      <div class="modal-body" id="modal-bodyku">
                      </div>
                      <div class="modal-footer" id="modal-footerq">
                      </div>
                    </div>
                  </div>
                </div>
                <!-- end of modal ------------------------------>
                    </div> 
 
                </section><!-- /.content -->
            </aside><!-- /.right-side -->
        </div><!-- ./wrapper -->
    </body>
</html>