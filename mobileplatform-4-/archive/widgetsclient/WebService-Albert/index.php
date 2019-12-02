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
<td><p style="font-size:40px; text-align:center">Albert Web Service </p></td></tr>
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
	<div>Get OHLC List</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>From Date.</label> <input type="text" name="fdate" id="datepicker1" value="" required ><br />
				<label>To Date.</label> <input type="text" name="tdate" id="datepicker2" value="" required ><br />
				<label>Symbol Name.</label> <input type="text" name="symbolname" value="" required ><br />
				<input type="submit" name="OHLC"  value="submit" class="submit" >
			</form>
		</div>
	</li></ul>
</li>

<li>
	<div>Get Spread</div>
	<ul><li>
		<div class="row">
			<form method="post" action="action.php"  name="myform" target="blank">
				<label>From Date.</label> <input type="text" name="fdate" id="datepicker3" value="" required ><br />
				<label>To Date.</label> <input type="text" name="tdate" id="datepicker4" value="" required ><br />
				<input type="submit" name="spread"  value="submit" class="submit" >
			</form>
		</div>
	</li></ul>
</li>




</ul> <!--End UI -->       
        
</div>

</td></tr></table>



<br /><br /><br /><br /><br /><br />
<br /><br /><br /><br /><br /><br />
<br /><br /><br /><br />
<div style="float:left; margin-left:-177px; width:136%;height:50px;background-image:url(images/header6.jpg); background-color:#337F95; color:#0e09c1;font-family: cursive;">
<div style="text-align:center; font-size:36px">2016</div> </div>

</body>


  

</html>