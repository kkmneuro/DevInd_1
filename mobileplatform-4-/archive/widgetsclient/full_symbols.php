<!-- $Id: example.html,v 1.4 2006/03/27 02:44:36 pat Exp $ -->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Websocket Client</title>


<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.8.18.custom.min.js"></script>
<link href="css/style.css" rel="stylesheet" type="text/css">

</head>
<body>

<!--<script>
var count = 8 * 60;
var counter = setInterval(timer, 1000); //1000 will  run it every 1 second

function timer() {
    count = count - 1;
    if (count == -1) {
        clearInterval(counter);
        return;
    }

    var seconds = count % 60;
    var minutes = Math.floor(count / 60);
    var hours = Math.floor(minutes / 60);
    minutes %= 60;
    hours %= 60;

    document.getElementById("timer").innerHTML = hours + "hours " + minutes + "minutes and" + seconds + " seconds left on this Sale!"; // watch for spelling
}
</script>
<div id="timer"></div>-->
<table border="0" style="background-color:#FFF; color:#BFBBBB; width:1020px;font-size: 13px;border-collapse: collapse;">
<tr height="30px" style="border: #dae0e8 1px solid;">
<th width="425px">Live quotes</th>
<th width="100px">Average spread</th>
<th width="400px">Trading Sessions Average Pip</th>
<th width="112px" style="color:#000000">Trading Clock</th>
</tr>
<tr height="30px">
<th></th>
<th></th>
<th></th>
<th style="border: #dae0e8 1px solid;">
<div id="traidingClock">
<div class="difTime">
            <div class="difTimeLeft">
                <div class="diftitle">Broker</div>
                <div id="brokerClock" data-bind="text: brokerClock"><div id="clockshowGTC"></div></div>
            </div>
            <div class="difTimeRight">
                <div class="diftitle">My time</div>
                <div id="localClock" data-bind="text: localClock"><div id="clockshow"></div></div>
            </div>
            <div class="clockIcon"></div>
</div>

<ul id="openClose">

            <li class="trClosed">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">Tokyo</span><br>
                <div id="clockTokyo"></div><div id="clockTokyo2"></div>
            </li>
            <li class="trClosed">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">Sydney</span><br>
                <div id="clockSydney"></div><div id="clockSydney2"></div>
            </li>
            <li class="trClosed">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">London<br></span>
                <div id="clocklondon"></div><div id="clocklondon2"></div>
            </li>
            <li class="trClosedB" style="border-bottom: #FFF 1px solid;">
                <span style="font-size: 14px; font-weight:bold;" data-bind="text: name">NY</span><br>
                <div id="clockNY"></div><div id="clockNY2"></div>
            </li>

</ul>
</div>                
    
</th>
</tr>
</table>

<table border="0" id="widgetQoutes">
<tr height="30px">
<th class="headSym">Symbol</th>
<th></th>
<th class="headBd">Bid</th>
<th class="headAsk">Ask</th>
<th class="headBd">Spread</th>
<th class="head2">Average</th>
<th class="head2">Tokyo</th>
<th class="head2">Sydney</th>
<th class="head2">London</th>
<th class="headNY">NY</th>

</tr>

<script>
$(document).ready(function() {
var socket;
var sender='Prabhat';
$('#connect').click(function(){
			var text = $('#pseudo').val();

				if(text==""){
					alert("Please input a pseudonym !");
					return ;
				}
			 connect();
			});
/* clock TImw start */

var today=new Date();
var UTCH=today.getUTCHours();
var UTCM=today.getUTCMinutes();
var countSc = ((UTCH * 60) + UTCM) * 60;

/// Start For London Timer ///
var lonHsOp = 08 * 60 * 60;
var lonHsCl = 17 * 60 * 60;
if(countSc > lonHsOp){
	var londontimer = lonHsCl - countSc;
	    document.getElementById('clocklondon').style.display = 'none';
	    document.getElementById('clocklondon2').style.display = 'block';
		document.getElementById('clocklondon2').style.color = "#DC5B44";

} else {
	var londontimer = lonHsOp - countSc;
	    document.getElementById('clocklondon').style.display = 'block';
	    document.getElementById('clocklondon2').style.display = 'none';
		document.getElementById('clocklondon').style.color = "#56C76A";

}

/// Start For Tokyo Timer ///
var TokHsOp = 24 * 60 * 60;
var TokHsCl = 9 * 60 * 60;
if(countSc < TokHsCl){
	var Tokyotimer = TokHsCl - countSc;
	    document.getElementById('clockTokyo').style.display = 'none';
	    document.getElementById('clockTokyo2').style.display = 'block';
		document.getElementById('clockTokyo2').style.color = "#DC5B44";

} else {
	var Tokyotimer = TokHsOp - countSc;
	    document.getElementById('clockTokyo').style.display = 'block';
	    document.getElementById('clockTokyo2').style.display = 'none';
		document.getElementById('clockTokyo').style.color = "#56C76A";

}

/// Start For Sydney Timer ///
var SyHsOp = 22 * 60 * 60;
var SyHsCl = 07 * 60 * 60;
if(countSc < SyHsCl){
	var Sydneytimer = SyHsCl - countSc;
	    document.getElementById('clockSydney').style.display = 'none';
	    document.getElementById('clockSydney2').style.display = 'block';
		document.getElementById('clockSydney2').style.color = "#DC5B44";

} else {
	var Sydneytimer = SyHsOp - countSc;
	    document.getElementById('clockSydney').style.display = 'block';
	    document.getElementById('clockSydney2').style.display = 'none';
		document.getElementById('clockSydney').style.color = "#56C76A";

}
/// Start For NY Timer ///
var NYHsOp = 13 * 60 * 60;
var NYHsCl = 22 * 60 * 60;
if(countSc > NYHsOp){
	var NYtimer = NYHsCl - countSc;
	    document.getElementById('clockNY').style.display = 'none';
	    document.getElementById('clockNY2').style.display = 'block';
		document.getElementById('clockNY2').style.color = "#DC5B44";

} else {
	var NYtimer = NYHsOp - countSc;
	    document.getElementById('clockNY').style.display = 'block';
	    document.getElementById('clockNY2').style.display = 'none';
		document.getElementById('clockNY').style.color = "#56C76A";

}



	function startTime() {
		var today=new Date();
		var h=today.getHours();
		var m=today.getMinutes();
		var s=today.getSeconds();
		
		var UTCH=today.getUTCHours();
		var UTCM=today.getUTCMinutes();
		var UTCS=today.getUTCSeconds();		

		m = checkTime(m);
		s = checkTime(s);
		document.getElementById('clockshowGTC').innerHTML = (UTCH + 2)+":"+UTCM+":"+UTCS;
		document.getElementById('clockshow').innerHTML = h+":"+m+":"+s;
		
		//document.getElementById('clocklondon').innerHTML = "Open at "+UTCH+":"+UTCM;
		
		/// For London Timer ///
		londontimer = londontimer - 1;
		var Lseconds = londontimer % 60;
		var Lminutes = Math.floor(londontimer / 60);
		var Lhours = Math.floor(Lminutes / 60);
		Lminutes %= 60;
		Lhours %= 60;

		document.getElementById('clocklondon').innerHTML = "Open at "+Lhours + ":" + Lminutes + ":" + Lseconds; 
		document.getElementById('clocklondon2').innerHTML = "Close at "+Lhours + ":" + Lminutes + ":" + Lseconds;

		/// For Tokyo Timer ///
		Tokyotimer = Tokyotimer - 1;
		var Tseconds = Tokyotimer % 60;
		var Tminutes = Math.floor(Tokyotimer / 60);
		var Thours = Math.floor(Tminutes / 60);
		Tminutes %= 60;
		Thours %= 60;

		document.getElementById('clockTokyo').innerHTML = "Open at "+Thours + ":" + Tminutes + ":" + Tseconds; 
		document.getElementById('clockTokyo2').innerHTML = "Close at "+Thours + ":" + Tminutes + ":" + Tseconds;

		/// For Sydney Timer ///
		Sydneytimer = Sydneytimer - 1;
		var Sseconds = Sydneytimer % 60;
		var Sminutes = Math.floor(Sydneytimer / 60);
		var Shours = Math.floor(Sminutes / 60);
		Sminutes %= 60;
		Shours %= 60;

		document.getElementById('clockSydney').innerHTML = "Open at "+Shours + ":" + Sminutes + ":" + Sseconds; 
		document.getElementById('clockSydney2').innerHTML = "Close at "+Shours + ":" + Sminutes + ":" + Sseconds;

		
		/// For NY Timer ///
		NYtimer = NYtimer - 1;
		var NYseconds = NYtimer % 60;
		var NYminutes = Math.floor(NYtimer / 60);
		var NYhours = Math.floor(NYminutes / 60);
		NYminutes %= 60;
		NYhours %= 60;

		document.getElementById('clockNY').innerHTML = "Open at "+NYhours + ":" + NYminutes + ":" + NYseconds; 
		document.getElementById('clockNY2').innerHTML = "Close at "+NYhours + ":" + NYminutes + ":" + NYseconds;

		var t = setTimeout(function(){startTime()},1000);
	}
	
	function checkTime(i) {
		if (i<10) {i = "0" + i};  // add zero in front of numbers < 10
		return i;
	}
	
	
		
	
/* clock TImw End */

function send(){

				var symbol = $('#symbol').val();
				var msg1 = {
								  requesttype: 0,
							      language: "English",
        						  msgtype: 83
		  		 };

			   var msg=JSON.stringify(msg1);
				socket.send(msg);
}

function OutputLog(msg){
				var newmsg = msg.split(',');
				
				var ask4 = newmsg[0];
				var ask3 = ask4.split(':');
				var ask2 = parseFloat(ask3[1]);
				var ask = ask2.toFixed(5);
				 
				var average4 = newmsg[1];
				var average3 = average4.split(':');
				var average2 = parseFloat(average3[1]);
				var average =average2.toFixed(2);

				var bid4 = newmsg[2];
				var bid3 = bid4.split(':');
				var bid2 = parseFloat(bid3[1]);
				var bid = bid2.toFixed(5);
				
				var msgtype3 = newmsg[3];
				var msgtype2 = msgtype3.split(':');
				var msgtype = msgtype2[1];

				var session3 = newmsg[4];
				var session2 = session3.split(':');
				var session = session2[1];

				var spread4 = newmsg[5];
				var spread3 = spread4.split(':');
				var spread2 = parseFloat(spread3[1]);
				var spread = spread2.toFixed(1);
				
				var symbol4 = newmsg[6];
				var symbol3 = symbol4.split(':');
				var symbo2 = symbol3[1];
				
				var symbol = symbo2.substring(1, symbo2.length-2);
				
				console.log(msg);
 				
				var ss = symbol.split('.');
				var ss3 = ss[0]+''+ss[1];
				
				var ss2 = ss3.toLowerCase();
				//  for Update //
			if(document.getElementById(ss2)){

				///////// test color change//////
				
				/// 1st ///
				var b1 = document.getElementById(ss2+'_bid').innerHTML;
                var b2 = bid2;
                if (b1 > b2)
                {
					document.getElementById(ss2+'_bid').style.color = '#00FF00';
					//document.getElementById(ss2+'_bid').style.background = '#819A1C'; 
                }
				else if (b1 < b2)
                {
                    
                    document.getElementById(ss2+'_bid').style.color = '#FF0000';
					//document.getElementById(ss2+'_bid').style.background = '#CB0808';
                }
                else if (b1 == b2)
                {
                    
					document.getElementById(ss2+'_bid').style.color = '#FFFFFF';
					document.getElementById(ss2+'_bid').style.background = '#19304e';
                }
				/// 2nd ///
				var a1 = document.getElementById(ss2+'_ask').innerHTML;
                var a2 = ask2;
                if (a1 > a2)
                {
					document.getElementById(ss2+'_ask').style.color = '#00FF00';
					//document.getElementById(ss2+'_ask').style.background = '#819A1C'; 
                }
				else if (a1 < a2)
                {
                    
                    document.getElementById(ss2+'_ask').style.color = '#FF0000';
					//document.getElementById(ss2+'_ask').style.background = '#CB0808';
                }
                else if (a1 == a2)
                {
                    
					document.getElementById(ss2+'_ask').style.color = '#FFFFFF';
					document.getElementById(ss2+'_ask').style.background = '#0c203a';
                }
				/// 3rd ///
				var sp1 = document.getElementById(ss2+'_spread').innerHTML;
                var sp2 = spread2;
                if (sp1 > sp2)
                {
					document.getElementById(ss2+'_spread').style.color = '#00FF00';
					//document.getElementById(ss2+'_spread').style.background = '#819A1C'; 
                }
				else if (sp1 < sp2)
                {
                    
                    document.getElementById(ss2+'_spread').style.color = '#FF0000';
					//document.getElementById(ss2+'_spread').style.background = '#CB0808';
                }
                else if (sp1 == sp2)
                {
                    
					document.getElementById(ss2+'_spread').style.color = '#FFFFFF';
					document.getElementById(ss2+'_spread').style.background = '#19304e';
                }

				////////
				//alert($('#'+symbol+'_bid').html());
				$('#'+ss2+'_bid').html(bid);
				$('#'+ss2+'_ask').html(ask);
				$('#'+ss2+'_spread').html(spread);
				//$('#'+ss2+'_average').html(average);
				
				if(session=='"SERVER"'){
				$('#'+ss2+'_average').html(average);
				}
				else if(session=='"Sydney"'){
				$('#'+ss2+'_Sydney').html(average);
				}
				else if(session=='"Tokyo"'){
				$('#'+ss2+'_Tokyo').html(average);
				}
				else if(session=='"London"'){
				$('#'+ss2+'_London').html(average);
				}
				else if(session=='"NY"'){
				$('#'+ss2+'_NY').html(average);
				}
				
				} else {
 				average = '0.00';
				var content = '<tr class=\"trcssstyle\"><td class=\"sym\" id="'+ss2+'" >' + symbol + '</td><td  class=\"bd\" id="'+ss2+'_bid">' + bid + '</td><td class=\"as\" id="'+ss2+'_ask">' + ask + '</td><td class=\"sp\" id="'+ss2+'_spread">' + spread  + '</td><td class=\"av\" id="'+ss2+'_average">' + average + '</td><td class=\"tok\" id="'+ss2+'_Tokyo">' + average + '</td><td class=\"sy\" id="'+ss2+'_Sydney">' + average + '</td><td class=\"lon\" id="'+ss2+'_London">' + average + '</td><td class=\"ny\" id="'+ss2+'_NY">' + average + '</td><tr>';
				
				$('#consolebox').append(content);
				}
				
			};
			
startTime();

function connect(){
			
			//var host = "ws://192.168.1.84:9051/test";
			var host = "ws://54.148.43.241:9021";

			try{

				socket = new WebSocket(host);
				//OutputLog('Socket Status: '+socket.readyState);
				socket.onopen = function(){
					send();
					//OutputLog('Socket Status: '+socket.readyState+' (open)');
					
				}

				socket.onmessage = function(msg){
					var str = "";
					str = msg.data;
					OutputLog(str);
					//console.log('='+ str);
					//alert(str);
					var id  = str.substr(0, 1);
					var separator = str.indexOf("|");
					var arg1 = "";
					var arg2 = "";
					

				}

				socket.onclose = function(){
					OutputLog('Socket Status: '+socket.readyState+' (Closed)');
					window.onload = connect;
				}

			} catch(exception){
				OutputLog('Error'+exception);
				window.onload = connect;
			}

		} 
window.onload = connect;	

});

</script>

</table>


<!--<div id="headmenu2"></div>-->
<div id="consolebox" style="width:1000px;"></div>


</body>
</html>
