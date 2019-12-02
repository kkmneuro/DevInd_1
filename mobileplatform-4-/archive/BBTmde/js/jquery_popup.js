$(document).ready(function() {

$(".popupopen").click(function() {
							  
//$("#contactdiv").css("display", "block");
   var row1 = $(this).closest("tr");        // Finds the closest row <tr> 
   var prev = row1.prev();
   var tdsymb = prev.find("td:nth-child(1)");
   var tdgateway = prev.find("td:nth-child(2)");
   var tdproduct = prev.find("td:nth-child(4)");
   var tddigit = prev.find("td:nth-child(5)");

   var tdBid = row1.find("td:nth-child(1)");
   var tdAsk = row1.find("td:nth-child(2)");
   var tdMid = row1.find("td:nth-child(3)");
   var row2 = row1.next();
   var td1 = row2.find("td:nth-child(1)");
   var td2 = row2.find("td:nth-child(2)");
   var td3 = row2.find("td:nth-child(3)");
   var tdcntsize = row2.find("td:nth-child(4)");
   var tdstopllmt = row2.find("td:nth-child(5)");
   //alert(tdsymb[0].innerText);
    $('#symble').val(tdsymb[0].textContent);
	$('#price').val(tdAsk[0].textContent);
	$('#digit').val(tddigit[0].textContent);
	$('#contractsize').val(tdcntsize[0].textContent);
	$('#stoplbllimit').val(tdstopllmt[0].textContent);

sessionStorage.setItem("bidpr", tdBid[0].textContent);
sessionStorage.setItem("askpr", tdAsk[0].textContent);
sessionStorage.setItem("contsize", tdcntsize[0].textContent);

});


$('#market').change(function() {
	 $('#trigpric').css('display', ($(this).val() == 'STOP'||$(this).val() == 'STOPLIMIT') ? 'block' : 'none');
    });

/*$("#contact #cancel").click(function() {
$(this).parent().parent().hide();
});*/

$("#contact #cancel").click(function() {
$("#contactdiv").css("display", "none");
});


});





	