<head>
 <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script data-require="jquery@*" data-semver="2.0.3" src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script data-require="bootstrap@*" data-semver="3.1.1" src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <link data-require="bootstrap-css@3.1.1" data-semver="3.1.1" rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" />
    
</head>
<script>
$(document).ready(function() {
	$('#submitBtn').click(function() {
		 
		 $('#accountno1html').text($('#accountno1').val());
		 $('#accountno2html').text($('#accountno2').val());
		 $('#Passwordhtml').text($('#Password').val());
		 $('#balancehtml').text($('#balance').val());
		 
		 var ac1 = $('#accountno1').val();
		 document.getElementById("ac1val").value = ac1;
		 var ac2 = $('#accountno2').val();
		 document.getElementById("ac2val").value = ac2;
		 var bal = $('#balance').val();
		 document.getElementById("acbal").value = bal;
		 
	});

	$('#submit').click(function(){
		alert('submitting');
		$('#formfield').submit();
	});

});

</script>

<style>
.login-form {
    //margin: 11% auto 4%;
	    margin-top: 75px;
		
    width: 100%;
	background-color: #FFF5E6;
	border: 1 solid;
	box-shadow: 1px 2px 20px rgba(0, 0, 0, .5);
	border-radius: 15px;
	height:400px;
}

.head img {
	//width: 40%;
	margin-top: -54px;
	}
.head {
	top: -15%;
	left: 34%;
	text-align: center;
	}
	
.NewBTn {
	background: #5997D3 none repeat scroll 0 0;
    border: medium none;
    border-radius: 5px;
    box-shadow: 0 0 10px #666464 inset;
    color: #FFF;
    cursor: pointer;
    font-family: "Open Sans",sans-serif;
    font-size: 20px;
    font-weight: 500;
    margin-bottom: 8%;
    outline: medium none;
    padding: 1%;
    transition: all 0.5s ease 0s;
    width: 50%;	
}	

</style>

<input type="button" name="btn" value="Pay" id="submitBtn" data-toggle="modal" data-target="#confirm-submit" class="NewBTn"  />

<div class="modal fade" id="confirm-submit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                Confirm Submit
            </div>
            <div class="modal-body">
                Are you sure you want to submit the following details?
                <table class="table">
                    <tr>
                        <th>Transfer From Account No</th>
                        <td id="accountno2html"></td>
						
                    </tr>
                    <tr>
                        <th>Transfer To Account No</th>
                        <td id="accountno1html"></td>
                    </tr>
					<tr>
                        <th>Transfer Amount</th>
                        <td id="balancehtml"></td>
                    </tr>
					<tr>
                        <th>Transfer Amount</th>
                        <td id="balancehtml"></td>
                    </tr><tr>
                        <th>Transfer Amount</th>
                        <td id="balancehtml"></td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal" style="float: left;">Cancel</button>
				<!--<a href="" id="submit" class="btn btn-success success">Submit</a>-->
				
				<form action="" method="post">
                <input type="hidden" name="ac1val" id="ac1val" >
				<input type="hidden" name="ac2val" id="ac2val" >
				<input type="hidden" name="acbal" id="acbal" >
				<input type="submit" name="ChangeBalance"  value="submit" class="btn btn-success success" >
				
				</form>
            </div>
        </div>
    </div>
</div>		
		
		