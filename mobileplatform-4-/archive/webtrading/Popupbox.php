<!DOCTYPE html>
<html lang="en">




<body>

<div class="container">
  <h2>Modal Example</h2>

  <!--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>-->
  
  <div data-toggle="modal" data-target="#myModal">Open Modal</div>
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
      <div class="modal-header">
      <form role="form" action="weblogin.php">
    <div style="text-align:center">
       <label>BUY:&nbsp;&nbsp;&nbsp;</label><input type="radio"  name="ordertype" value="BUY" checked>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <label>SELL:&nbsp;&nbsp;&nbsp;</label><input type="radio"  name="ordertype" value="SELL">
         </div>
    
       <label>Contract Name:</label>
      <input type="text" class="form-control"  name="symble" id="symble" placeholder="Enter Contract Name">
       
	<br />
      <label>Order Type:</label>
     <select  class="form-control" name="market" id="market">
        <option value="MARKET">Market</option> 
        <option value="LIMIT">Limit</option>
        <option value="STOP">Stop</option>
        <option value="STOPLIMIT">Stop Limit</option>        
      </select>      
	<br />

      <label for="Quantity">Quantity:</label>
      <input type="text" class="form-control" name="quantity" id="quantity" placeholder="Enter Quantity" value="1">
    <br />

      <label for="Price">Price:</label>
      <input type="text" class="form-control" name="price" id="price" placeholder="Enter Price">
    <input type="hidden" name="side" id="side" />
    <input type="hidden" name="contractsize" id="contractsize" />
    <input type="hidden" name="stoplbllimit" id="stoplbllimit" />
    <input type="hidden" name="digit" id="digit" />
<br />

      <input type="button" id="neworder" class="btn btn-success bg-success" value="Place Order">
      <input type="button"  class="btn btn-default" data-dismiss="modal" value="Cancel" style="margin-left:80px;background-color: #9E401B; color:#FFFFFF;">

</form>
        </div>
        <!--
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Modal Header</h4>
        </div>
        <div class="modal-body">
          <p>Some text in the modal.</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>-->
      </div>
      
      
      
    </div>
  </div>
  
</div>
<?php include("main-footer.php");  ?>
</body>
</html>