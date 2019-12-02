<?php
//session_start();
error_reporting(0);
$token='';
$token=$_GET['token'];
$WEbS=$_SESSION['WEbS'];
if(isset($token)!="") { ?>
<script> $(document).ready(function () { $("#my-tree").hide(); }); </script>
<div id="bkg" class="blockbkg" style="display: block;">
<div id="dlg" class="cont" style="display: block;">
<div id="closebtn" class="closebtn" title="Close"></div>
<h2 style="text-align:center;color: blue;">MT4 Web service Response</h2>
<?php	
		function objectToArray($d)
		{
			if (is_object($d)) {
				$d = get_object_vars($d);
			}
			if (is_array($d)) {
				return array_map(__FUNCTION__, $d);
			}
			else {
				return $d;
			}
		}
	
			if($token==1){
				echo 'Massage : '.$tockeniddecodelist = $WEbS; 
				
			}
			
			if($token==2){
				$tockeniddecodelist = json_decode($WEbS); 
				$tockenidconvertarray = objectToArray($tockeniddecodelist[0]); 
				//echo '<pre>'; print_r($tockenidconvertarray['AccountDetails']);
				?>
					<table width=120%>
					
					<tr style="background-color:#cfd0d2">
						<th>login  </th>
						<th>name  </th>
						<th>email  </th>
						<th>address </th>
						<th>balance</th>
						<th>city  </th>
						<th>country  </th>
						<th>credit  </th>
						<th>equity  </th>
						<th>group </th>
						<th>leverage  </th>
						<th>phone  </th>
						<th>regdate  </th>
						<th>state  </th>
						<th>zipcode  </th>
					
					</tr>
					
					<?php foreach($tockenidconvertarray['AccountDetails'] as $row): ?>
					<tr>
						<td><?php echo $row['login']; ?></td>
						<td><?php echo $row['name']; ?></td>
						<td><?php echo $row['email']; ?></td>
						<td><?php echo $row['address']; ?></td>
						<td width="20px;"><?php echo $row['balance']; ?></td>
						<td width="20px;"><?php echo $row['city']; ?></td>
						<td><?php echo $row['country']; ?></td>
						<td><?php echo $row['credit']; ?></td>
						<td><?php echo $row['equity']; ?></td>
						<td><?php echo $row['group']; ?></td>
						<td><?php echo $row['leverage']; ?></td>
						<td><?php echo $row['phone']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($row['regdate'])); //echo $row['regdate']; ?></td>
						<td width="10px;"><?php echo $row['state']; ?></td>
						<td><?php echo $row['zipcode']; ?></td>
					
					</tr>
					
					<?php endforeach; ?>
					
					</table>
			<?php
			}

			if($token==3){
				$CheckPasswordV = json_decode($WEbS); 
				$CheckPasswordArray = objectToArray($CheckPasswordV);
				//echo '<pre>'; print_r($CheckPasswordArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>login  </th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $CheckPasswordArray['login']; ?></td>
						<td><?php echo $CheckPasswordArray['message']; ?></td>
						<td><?php echo $CheckPasswordArray['msgtype']; ?></td>
						<td><?php echo $CheckPasswordArray['requestId']; ?></td>
						<td><?php echo $CheckPasswordArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			
			if($token==4){
				$CheckPasswordV = json_decode($WEbS); 
				$CheckPasswordArray = objectToArray($CheckPasswordV);
				//echo '<pre>'; print_r($CheckPasswordArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>login  </th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $CheckPasswordArray['login']; ?></td>
						<td><?php echo $CheckPasswordArray['message']; ?></td>
						<td><?php echo $CheckPasswordArray['msgtype']; ?></td>
						<td><?php echo $CheckPasswordArray['requestId']; ?></td>
						<td><?php echo $CheckPasswordArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			
			if($token==5){
				//echo '<pre>'; print_r($WEbS);
				$AccountInfoV = json_decode($WEbS); 
				$AccountInfoArray = objectToArray($AccountInfoV); 
				 ?>
					
					<table width=130%>
					
					<tr style="background-color:#cfd0d2">
						<th>login  </th>
						<th>name  </th>
						<th>email  </th>
						<th>address </th>
						<th>balance</th>
						<th>city  </th>
						<th>country  </th>
						<th>credit  </th>
						<th>equity  </th>
						<th>group </th>
						<th>leverage  </th>
						<th>phone  </th>
						<th>regdate  </th>
						<th>state  </th>
						<th>zipcode  </th>
					
					</tr>
					
					
					<tr>
						<td><?php echo $AccountInfoArray['login']; ?></td>
						<td><?php echo $AccountInfoArray['name']; ?></td>
						<td><?php echo $AccountInfoArray['email']; ?></td>
						<td><?php echo $AccountInfoArray['address']; ?></td>
						<td width="20px;"><?php echo $AccountInfoArray['balance']; ?></td>
						<td width="20px;"><?php echo $AccountInfoArray['city']; ?></td>
						<td><?php echo $AccountInfoArray['country']; ?></td>
						<td><?php echo $AccountInfoArray['credit']; ?></td>
						<td><?php echo $AccountInfoArray['equity']; ?></td>
						<td><?php echo $AccountInfoArray['group']; ?></td>
						<td><?php echo $AccountInfoArray['leverage']; ?></td>
						<td><?php echo $AccountInfoArray['phone']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AccountInfoArray['regdate'])); //echo $AccountInfoArray['regdate']; ?></td>
						<td width="10px;"><?php echo $AccountInfoArray['state']; ?></td>
						<td><?php echo $AccountInfoArray['zipcode']; ?></td>
					
					</tr>
					
					
					
					</table>
				<?php	
				
			}
			if($token==6){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>Deal ID  </th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $ValueArray['deal']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			
			if($token==7){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>Deal ID  </th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $ValueArray['deal']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			
			if($token==8){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>Deal ID1  </th>
						<th>Deal ID2  </th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $ValueArray['deal1']; ?></td>
						<td><?php echo $ValueArray['deal2']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			
			if($token==9){
				
				$tockeniddecodelist = json_decode($WEbS); 
				$tockenidconvertarray = objectToArray($tockeniddecodelist); 
				//echo '<pre>'; print_r($tockenidconvertarray[0]['Symbols']);
				?>
					<table width=100%>
					
					<tr style="background-color:#cfd0d2">
						<th>contract_size  </th>
						<th>currency  </th>
						<th>description  </th>
						<th>digits </th>
						<th>source</th>
						<th>spread  </th>
						<th>symbol  </th>
						<th>trade  </th>
						<th>type  </th>
						
					
					</tr>
					
					<?php foreach($tockenidconvertarray[0]['Symbols'] as $row): ?>
					<tr>
						<td><?php echo $row['contract_size']; ?></td>
						<td><?php echo $row['currency']; ?></td>
						<td><?php echo $row['description']; ?></td>
						<td><?php echo $row['digits']; ?></td>
						<td><?php echo $row['source']; ?></td>
						<td><?php echo $row['spread']; ?></td>
						<td><?php echo $row['symbol']; ?></td>
						<td><?php echo $row['trade']; ?></td>
						<td><?php echo $row['type']; ?></td>
						
					</tr>
					
					<?php endforeach; ?>
					
					</table>
			<?php
			}
			if($token==10){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>invester_password </th>
						<th>login</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>password  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $ValueArray['invester_password']; ?></td>
						<td><?php echo $ValueArray['login']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['password']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			
			if($token==11){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						
						<th>login</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						
						<td><?php echo $ValueArray['login']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			if($token==12){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						
						<th>login</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						
						<td><?php echo $ValueArray['login']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			if($token==13){
				
				?>
				<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>Login</th>
						<th>order</th>
						<th>symbol  </th>
						<th>open_price  </th>
						<th>open_time </th>
						<th>digits</th>
						<th>volume</th>
					</tr>
					<?php 	
						$search = array('[{"TradeDetails":[', ',]}]');
						$replace = array('', '');
						$STRALL = str_replace($search, $replace, $WEbS);

						$AllData_new = str_replace("},{","}~{",$STRALL);
						$Data2 = explode('~',$AllData_new); // string to array 
						//echo '<pre>'; print_r($WEbS);
						$num = count($Data2);
						for($i=0;$i<$num;$i++){
							$Data3 = get_object_vars(json_decode($Data2[$i]));
							//echo '<pre>'; print_r($Data2);
					?>
					<tr>
						
						<td><?php echo $Data3['login']; ?></td>
						<td><?php echo $Data3['order']; ?></td>
						<td><?php echo $Data3['symbol']; ?></td>
						<td><?php echo $Data3['open_price']; ?></td>
						<td><?php echo $Data3['open_time']; ?></td>
						<td><?php echo $Data3['digits']; ?></td>
						<td><?php echo $Data3['volume']; ?></td>
					</tr>
						<?php } ?>
					</table>
				
					
			<?php
			}
			if($token==14){
				//echo '<pre>'; print_r($WEbS);
				?>
				<table width=160%>
					<tr style="background-color:#cfd0d2">
						<th>Login</th>
						<th>order</th>
						<th>symbol  </th>
						<th>open_price  </th>
						<th>open_time </th>
						<th>close_price </th>
						<th>close_time </th>
						<th>cmd </th>
						<th>digits</th>
						<th>volume</th>
						<th>Profit</th>
						<th>comment</th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>expiration</th>
						<th>magic</th>
						<th>sl</th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp</th>
					</tr>
					<?php 	
						$search = array('[{"TradeDetails":[', ']}]');
						$replace = array('', '');
						$STRALL = str_replace($search, $replace, $WEbS);

						$AllData_new = str_replace("},{","}~{",$STRALL);
						$Data2 = explode('~',$AllData_new); // string to array 
						//echo '<pre>'; print_r($WEbS);
						$num = count($Data2);
						for($i=0;$i<$num;$i++){
							$Data3 = get_object_vars(json_decode($Data2[$i]));
							//echo '<pre>'; print_r($Data2);
					?>
					<tr>
						
						<td><?php echo $Data3['login']; ?></td>
						<td><?php echo $Data3['order']; ?></td>
						<td><?php echo $Data3['symbol']; ?></td>
						<td><?php echo $Data3['open_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($Data3['open_time'])); //echo $Data3['open_time']; ?></td>
						<td><?php echo $Data3['close_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($Data3['close_time'])); //echo $Data3['close_time']; ?></td>
						<td><?php echo $Data3['cmd']; ?></td>
						<td><?php echo $Data3['digits']; ?></td>
						<td><?php echo $Data3['volume']; ?></td>
						<td><?php echo $Data3['profit']; ?></td>
						<td><?php echo $Data3['comment']; ?></td>						
						<td><?php echo $Data3['commission']; ?></td>
						<td><?php echo $Data3['commission_agent']; ?></td>
						<td><?php echo $Data3['expiration']; ?></td>
						<td><?php echo $Data3['magic']; ?></td>
						<td><?php echo $Data3['sl']; ?></td>
						<td><?php echo $Data3['taxes']; ?></td>
						<td><?php echo $Data3['timestamp']; ?></td>
						<td><?php echo $Data3['tp']; ?></td>
					</tr>
						<?php } ?>
					</table>
				
					
			<?php
			}
			
			if($token==15){
				//echo '<pre>'; print_r($WEbS);
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>Login</th>
						<th>order</th>
						<th>symbol  </th>
						<th>CMD  </th>
						<th>open_price  </th>
						<th>close_price  </th>
						<th>open_time </th>
						<th>close_time </th>
						<th>digits</th>
						<th>profit</th>
						<th>volume</th>
						<th>comment</th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>expiration</th>
						<th>magic</th>
						<th>sl</th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp</th>
					</tr>
					<?php 	
						$search = array('[{"TradeDetails":[', ']}]');
						$replace = array('', '');
						$STRALL = str_replace($search, $replace, $WEbS);

						$AllData_new = str_replace("},{","}~{",$STRALL);
						$Data2 = explode('~',$AllData_new); // string to array 
						//echo '<pre>'; print_r($WEbS);
						$num = count($Data2);
						for($i=0;$i<$num;$i++){
							$Data3 = get_object_vars(json_decode($Data2[$i]));
							//echo '<pre>'; print_r($Data2);
					?>
					<tr>
						
						<td><?php echo $Data3['login']; ?></td>
						<td><?php echo $Data3['order']; ?></td>
						<td><?php echo $Data3['symbol']; ?></td>
						<td><?php echo $Data3['cmd']; ?></td>
						<td><?php echo $Data3['open_price']; ?></td>
						<td><?php echo $Data3['close_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($Data3['open_time'])); //echo $Data3['open_time']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($Data3['close_time'])); //$Data3['close_time']; ?></td>
						<td><?php echo $Data3['digits']; ?></td>
						<td><?php echo $Data3['profit']; ?></td>
						<td><?php echo $Data3['volume']; ?></td>
						<td><?php echo $Data3['comment']; ?></td>						
						<td><?php echo $Data3['commission']; ?></td>
						<td><?php echo $Data3['commission_agent']; ?></td>
						<td><?php echo $Data3['expiration']; ?></td>
						<td><?php echo $Data3['magic']; ?></td>
						<td><?php echo $Data3['sl']; ?></td>
						<td><?php echo $Data3['taxes']; ?></td>
						<td><?php echo $Data3['timestamp']; ?></td>
						<td><?php echo $Data3['tp']; ?></td>
					</tr>
						<?php } ?>
					</table>
				
					
			<?php
			}
			if($token==16){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				
				$AllData = $ValueArray[0]['TradeDetails'];
				//echo '<pre>'; print_r($AllData);
				$num = count($AllData);
				
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					<?php 
					for($i=0;$i<$num;$i++)
					{ ?>
					<tr>
						<td><?php echo $AllData[$i]['close_price']; ?></td>
						<td><?php echo $AllData[$i]['close_time']; ?></td>
						<td><?php echo $AllData[$i]['cmd']; ?></td>
						<td><?php echo $AllData[$i]['comment']; ?></td>
						<td><?php echo $AllData[$i]['commission']; ?></td>
						<td><?php echo $AllData[$i]['commission_agent']; ?></td>
						<td><?php echo $AllData[$i]['digits']; ?></td>
						<td><?php echo $AllData[$i]['expiration']; ?></td>
						<td><?php echo $AllData[$i]['login']; ?></td>
						<td><?php echo $AllData[$i]['magic']; ?></td>
						<td><?php echo $AllData[$i]['open_price']; ?></td>
						<td><?php  echo date("Y-m-d h:i:s",trim($AllData[$i]['open_time'])); //echo $AllData[$i]['open_time']; ?></td>
						<td><?php echo $AllData[$i]['order']; ?></td>
						<td><?php echo $AllData[$i]['profit']; ?></td>
						<td><?php echo $AllData[$i]['sl']; ?></td>
						<td><?php echo $AllData[$i]['symbol']; ?></td>
						<td><?php echo $AllData[$i]['taxes']; ?></td>
						<td><?php echo $AllData[$i]['timestamp']; ?></td>
						<td><?php echo $AllData[$i]['tp']; ?></td>
						<td><?php echo $AllData[$i]['volume']; ?></td>
						
						
					</tr>
					<?php } ?>	
					</table>
			<?php
			}
			if($token==17){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						
						<th>login</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						
						<td><?php echo $ValueArray['login']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			if($token==18){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				echo '<pre>'; print_r($WEbS);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						
						<th>credit</th>
						<th>currency  </th>
						<th>default_leverage  </th>
						<th>group </th>
						<th>NoOfGroups</th>
						<th>isLast</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
						
					</tr>
					<tr>
						
						<td><?php echo $ValueArray['credit']; ?></td>
						<td><?php echo $ValueArray['currency']; ?></td>
						<td><?php echo $ValueArray['default_leverage']; ?></td>
						<td><?php echo $ValueArray['group']; ?></td>
						<td><?php echo $ValueArray['NoOfGroups']; ?></td>
						<td><?php echo $ValueArray['isLast']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
						
					</tr>
					</table>
			<?php
			}
			if($token==19){
				//echo '<pre>'; print_r($WEbS);
				?>
				<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>credit</th>
						<th>currency</th>
						<th>default_leverage  </th>
						<th>group  </th>
						
					</tr>
					<?php 	
						$search = array('[{"GroupDetails":[', ']}]');
						$replace = array('', '');
						$STRALL = str_replace($search, $replace, $WEbS);

						$AllData_new = str_replace("},{","}~{",$STRALL);
						$Data2 = explode('~',$AllData_new); // string to array 
						//echo '<pre>'; print_r($WEbS);
						$num = count($Data2);
						for($i=0;$i<$num;$i++){
							$Data3 = get_object_vars(json_decode($Data2[$i]));
							//echo '<pre>'; print_r($Data2);
					?>
					<tr>
						
						<td><?php echo $Data3['credit']; ?></td>
						<td><?php echo $Data3['currency']; ?></td>
						<td><?php echo $Data3['default_leverage']; ?></td>
						<td><?php echo $Data3['group']; ?></td>
						
					</tr>
						<?php } ?>
					</table>
				
					
			<?php
			}
			if($token==20){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($WEbS);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						
						<th>login</th>
						<th>balance</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
					</tr>
					<tr>
						<td><?php echo $ValueArray['login']; ?></td>
						<td><?php echo $ValueArray['balance']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
					</tr>
					</table>
			<?php
			}
			if($token==21){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($ValueArray);
				$AllData = $ValueArray['TradeDetails'][0];
				?>
				<table width=100%>
					<tr style="background-color:#cfd0d2">
						<th>message</th>
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					
					<tr>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $AllData['close_price']; ?></td>
						<td><?php echo $AllData['close_time']; ?></td>
						<td><?php echo $AllData['cmd']; ?></td>
						<td><?php echo $AllData['comment']; ?></td>
						<td><?php echo $AllData['commission']; ?></td>
						<td><?php echo $AllData['commission_agent']; ?></td>
						<td><?php echo $AllData['digits']; ?></td>
						<td><?php echo $AllData['expiration']; ?></td>
						<td><?php echo $AllData['login']; ?></td>
						<td><?php echo $AllData['magic']; ?></td>
						<td><?php echo $AllData['open_price']; ?></td>
						<td><?php echo $AllData['open_time']; ?></td>
						<td><?php echo $AllData['order']; ?></td>
						<td><?php echo $AllData['profit']; ?></td>
						<td><?php echo $AllData['sl']; ?></td>
						<td><?php echo $AllData['symbol']; ?></td>
						<td><?php echo $AllData['taxes']; ?></td>
						<td><?php echo $AllData['timestamp']; ?></td>
						<td><?php echo $AllData['tp']; ?></td>
						<td><?php echo $AllData['volume']; ?></td>
						
						
					</tr>
						
					</table>
				
					
			<?php
			}
			
			if($token==22){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($WEbS);
				$AllData = $ValueArray['TradeDetails'][0];
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>message</th>
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					
					<tr>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $AllData['close_price']; ?></td>
						<td><?php echo $AllData['close_time']; ?></td>
						<td><?php echo $AllData['cmd']; ?></td>
						<td><?php echo $AllData['comment']; ?></td>
						<td><?php echo $AllData['commission']; ?></td>
						<td><?php echo $AllData['commission_agent']; ?></td>
						<td><?php echo $AllData['digits']; ?></td>
						<td><?php echo $AllData['expiration']; ?></td>
						<td><?php echo $AllData['login']; ?></td>
						<td><?php echo $AllData['magic']; ?></td>
						<td><?php echo $AllData['open_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['open_time'])); //echo $AllData['open_time']; ?></td>
						<td><?php echo $AllData['order']; ?></td>
						<td><?php echo $AllData['profit']; ?></td>
						<td><?php echo $AllData['sl']; ?></td>
						<td><?php echo $AllData['symbol']; ?></td>
						<td><?php echo $AllData['taxes']; ?></td>
						<td><?php echo $AllData['timestamp']; ?></td>
						<td><?php echo $AllData['tp']; ?></td>
						<td><?php echo $AllData['volume']; ?></td>
						
						
					</tr>
						
					</table>
				
					
			<?php
			}
			
			if($token==23){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($WEbS);
				$AllData = $ValueArray['TradeDetails'][0];
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>message</th>
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					
					<tr>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $AllData['close_price']; ?></td>
						<td><?php echo $AllData['close_time']; ?></td>
						<td><?php echo $AllData['cmd']; ?></td>
						<td><?php echo $AllData['comment']; ?></td>
						<td><?php echo $AllData['commission']; ?></td>
						<td><?php echo $AllData['commission_agent']; ?></td>
						<td><?php echo $AllData['digits']; ?></td>
						<td><?php echo $AllData['expiration']; ?></td>
						<td><?php echo $AllData['login']; ?></td>
						<td><?php echo $AllData['magic']; ?></td>
						<td><?php echo $AllData['open_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['open_time'])); //echo $AllData['open_time']; ?></td>
						<td><?php echo $AllData['order']; ?></td>
						<td><?php echo $AllData['profit']; ?></td>
						<td><?php echo $AllData['sl']; ?></td>
						<td><?php echo $AllData['symbol']; ?></td>
						<td><?php echo $AllData['taxes']; ?></td>
						<td><?php echo $AllData['timestamp']; ?></td>
						<td><?php echo $AllData['tp']; ?></td>
						<td><?php echo $AllData['volume']; ?></td>
						
						
					</tr>
						
					</table>
				
					
			<?php
			}
			if($token==24){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				echo '<pre>'; print_r($WEbS);
				$AllData = $ValueArray['TradeDetails'][0];
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>message</th>
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					
					<tr>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $AllData['close_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['close_time'])); //echo $AllData['close_time']; ?></td>
						<td><?php echo $AllData['cmd']; ?></td>
						<td><?php echo $AllData['comment']; ?></td>
						<td><?php echo $AllData['commission']; ?></td>
						<td><?php echo $AllData['commission_agent']; ?></td>
						<td><?php echo $AllData['digits']; ?></td>
						<td><?php echo $AllData['expiration']; ?></td>
						<td><?php echo $AllData['login']; ?></td>
						<td><?php echo $AllData['magic']; ?></td>
						<td><?php echo $AllData['open_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['open_time'])); //echo $AllData['open_time']; ?></td>
						<td><?php echo $AllData['order']; ?></td>
						<td><?php echo $AllData['profit']; ?></td>
						<td><?php echo $AllData['sl']; ?></td>
						<td><?php echo $AllData['symbol']; ?></td>
						<td><?php echo $AllData['taxes']; ?></td>
						<td><?php echo $AllData['timestamp']; ?></td>
						<td><?php echo $AllData['tp']; ?></td>
						<td><?php echo $AllData['volume']; ?></td>
						
						
					</tr>
						
					</table>
				
					
			<?php
			}
			if($token==25){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($WEbS);
				$AllData = $ValueArray['TradeDetails'][0];
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>message</th>
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					
					<tr>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $AllData['close_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['close_time'])); //echo $AllData['close_time']; ?></td>
						<td><?php echo $AllData['cmd']; ?></td>
						<td><?php echo $AllData['comment']; ?></td>
						<td><?php echo $AllData['commission']; ?></td>
						<td><?php echo $AllData['commission_agent']; ?></td>
						<td><?php echo $AllData['digits']; ?></td>
						<td><?php echo $AllData['expiration']; ?></td>
						<td><?php echo $AllData['login']; ?></td>
						<td><?php echo $AllData['magic']; ?></td>
						<td><?php echo $AllData['open_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['open_time'])); //echo $AllData['open_time']; ?></td>
						<td><?php echo $AllData['order']; ?></td>
						<td><?php echo $AllData['profit']; ?></td>
						<td><?php echo $AllData['sl']; ?></td>
						<td><?php echo $AllData['symbol']; ?></td>
						<td><?php echo $AllData['taxes']; ?></td>
						<td><?php echo $AllData['timestamp']; ?></td>
						<td><?php echo $AllData['tp']; ?></td>
						<td><?php echo $AllData['volume']; ?></td>
						
						
					</tr>
						
					</table>
				
					
			<?php
			}
			
			if($token==26){
				//echo '<pre>'; print_r($WEbS);
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				$AllData = $ValueArray['TradeDetails'][0];
				?>
				<table width=150%>
					<tr style="background-color:#cfd0d2">
						<th>message</th>
						<th>close_price</th>
						<th>close_time</th>
						<th>cmd  </th>
						<th>comment  </th>
						<th>commission</th>
						<th>commission_agent</th>
						<th>digits  </th>
						<th>expiration  </th>
						<th>login</th>
						<th>magic</th>
						<th>open_price  </th>
						<th>open_time  </th>
						<th>order</th>
						<th>profit</th>
						<th>sl  </th>
						<th>symbol  </th>
						<th>taxes</th>
						<th>timestamp</th>
						<th>tp  </th>
						<th>volume  </th>
						
					</tr>
					
					<tr>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $AllData['close_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['close_time'])); //echo $AllData['close_time']; ?></td>
						<td><?php echo $AllData['cmd']; ?></td>
						<td><?php echo $AllData['comment']; ?></td>
						<td><?php echo $AllData['commission']; ?></td>
						<td><?php echo $AllData['commission_agent']; ?></td>
						<td><?php echo $AllData['digits']; ?></td>
						<td><?php echo $AllData['expiration']; ?></td>
						<td><?php echo $AllData['login']; ?></td>
						<td><?php echo $AllData['magic']; ?></td>
						<td><?php echo $AllData['open_price']; ?></td>
						<td><?php echo date("Y-m-d h:i:s",trim($AllData['open_time'])); //echo $AllData['open_time']; ?></td>
						<td><?php echo $AllData['order']; ?></td>
						<td><?php echo $AllData['profit']; ?></td>
						<td><?php echo $AllData['sl']; ?></td>
						<td><?php echo $AllData['symbol']; ?></td>
						<td><?php echo $AllData['taxes']; ?></td>
						<td><?php echo $AllData['timestamp']; ?></td>
						<td><?php echo $AllData['tp']; ?></td>
						<td><?php echo $AllData['volume']; ?></td>
						
						
					</tr>
						
					</table>
				
					
			<?php
			}
			if($token==27){
				$Valuejson = json_decode($WEbS); 
				$ValueArray = objectToArray($Valuejson);
				//echo '<pre>'; print_r($WEbS);
				?>
					<table width=100%>
					<tr style="background-color:#cfd0d2">
						
						<th>Login</th>
						<th>message  </th>
						<th>msgtype  </th>
						<th>requestId </th>
						<th>result</th>
						
					</tr>
					<tr>
						
						<td><?php echo $ValueArray['login']; ?></td>
						<td><?php echo $ValueArray['message']; ?></td>
						<td><?php echo $ValueArray['msgtype']; ?></td>
						<td><?php echo $ValueArray['requestId']; ?></td>
						<td><?php echo $ValueArray['result']; ?></td>
						
					</tr>
					</table>
			<?php
			}
	
?>
</div>
</div>

</td></tr></table>
<?php	


}?>
