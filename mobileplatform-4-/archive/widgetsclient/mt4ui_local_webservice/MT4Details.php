<!DOCTYPE HTML>
<html> 
<body>
<?php
//session_start();
error_reporting(E_ALL);
ini_set('display_errors', '1');
echo "<pre>";
//die;

include('lib/nusoap.php');
$client = new nusoap_client('http://localhost/mt4ui_local_webservice/web_server.php'); 
	
		if(count($_POST>0) && isset($_POST['AccountHistory']))
		{   
		    $accountno=$_POST['accountno'];	
			$paramvalue = array('fieldsvalue' => $accountno);
			$response = $client->call('AccountHistory'.$paramvalue.','); 		
			//SocketClient('AccountHistory,'.$accountno.',');
		}
		echo nl2br("\n");
		

		if(count($_POST>0) && isset($_POST['BulkChangeCredit']))
		{   
		    $accountno=$_POST['accountno'];	
			$amount=$_POST['amount'];				
			
			$param = $accountno.','.$amount.',';
			$paramvalue = array('fieldsvalue' => $param);
			$response = $client->call('BulkChangeCredit'.$paramvalue.','); 		

			//SocketClient('BulkChangeCredit,'.$param);
			
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['ChangeAgentCommission']))
		{
		   $accountno=$_POST['accountno'];
		   $commission=$_POST['commission'];
		   	
		   $param = $accountno.','.$commission.',';	
			SocketClient('TradeHistory,'.$param);
		}
		echo nl2br("\n");
		
				
		if(count($_POST>0) && isset($_POST['ChangeBalance']))
		{
		   $accountno=$_POST['accountno'];
		   $balance=$_POST['balance'];
		   $abc=$accountno.','.$balance.','; 
		   
		   $paramvalue = array('fieldsvalue' => $abc);
		   $response = $client->call('ChangeBalance',$paramvalue);  
		   //SocketClient('ChangeBalance,'.$abc);
		}
		echo nl2br("\n");
		
		
		
		if(count($_POST>0) && isset($_POST['ChangeCredit']))
		{
		
		   $accountno=$_POST['accountno'];
		   $credit=$_POST['credit'];
		   $expiry=$_POST['expiry'];
		   $expiryTm = strtotime($expiry);
		   
		   $param = $accountno.','.$credit.','.$expiryTm.',';
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('ChangeCredit',$paramvalue);  
		   //SocketClient('ChangeCredit,'.$param);
		}
		echo nl2br("\n");
		
		
		
		if(count($_POST>0) && isset($_POST['ChangePassword']))
		{
		   $accountno=$_POST['accountno'];
		   $oldpass=$_POST['oldpass'];
		   $newpass=$_POST['newpass'];
		   
		   $param = $accountno.','.$oldpass.','.$newpass.',';
   		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('ChangePassword',$paramvalue);  

		   //SocketClient('ChangePassword,'.$param);
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['ChangeInvestorPassword']))
		{
		   $accountno=$_POST['accountno'];
		   $oldpass=$_POST['oldpass'];
		   $newpass=$_POST['newpass'];
		   
		   $param = $accountno.','.$oldpass.','.$newpass.',';
   		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('ChangeInvestorPassword',$paramvalue);  

		   //SocketClient('ChangeInvestorPassword,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['CheckPAssword']))
		{
		
		   $accountno=$_POST['accountno'];
		   $pass=$_POST['pass'];	   
		   
		   $param = $accountno.','.$pass.',';
   		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('CheckPAssword',$paramvalue);  
		//	SocketClient('CheckPAssword,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['CreateAccount']))
		{
		    $login=$_POST['login'];	
			$group=$_POST['group'];	
			$password =$_POST['password'];
			$enable=$_POST['enable'];	
			$enable_change_password=$_POST['enable_change_password'];	
			$enable_read_only=$_POST['enable_read_only'];
			$password_investor=$_POST['password_investor'];	
			$password_phone=$_POST['password_phone'];	
			$name=$_POST['name'];	
			$country=$_POST['country'];	
			$city=$_POST['city'];	
			$state=$_POST['state'];	
			$zipcode=$_POST['zipcode'];	
			$address=$_POST['address'];	
			$phone=$_POST['phone'];	
			$email=$_POST['email'];	
			$comment=$_POST['comment'];	
			$id=$_POST['id'];
			$status=$_POST['status'];
			$leverage=$_POST['leverage'];	
			$agent_account=$_POST['agent_account'];	
			$balance=$_POST['balance'];	
			$prevmonthbalance=$_POST['prevmonthbalance'];	
			$prevbalance=$_POST['prevbalance'];	
			$credit=$_POST['credit'];	
			$interestrate=$_POST['interestrate'];	
			$taxes=$_POST['taxes'];	
			$prevmonthequity=$_POST['prevmonthequity'];
			$prevequity=$_POST['prevequity'];	
			$publickey=$_POST['publickey'];	
			$send_reports=$_POST['send_reports'];	
			$mqid=$_POST['mqid'];
		    $param=$login.','.$group.','.$password.','.$enable.','.$enable_change_password.','.$enable_read_only.','.$password_investor.','.$password_phone.','.$name.','.$country.','.$city.','.$state.','.$zipcode.','.$address.','.$phone.','.$email.','.$comment.','.$id.','.$status.','.$leverage.','.$agent_account.','.$balance.','.$prevmonthbalance.','.$prevbalance.','.$credit.','.$interestrate.','.$prevmonthequity.','.$prevequity.','.$publickey.','.$send_reports.','.$mqid.',';
		
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('CreateAccount',$paramvalue);  
		   //SocketClient('CreateAccount,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['GetAccountBalance']))
		
		{
		    $accountno=$_POST['accountno'];
		   $paramvalue = array('fieldsvalue' => $accountno);
		   $response = $client->call('GetAccountBalance',$paramvalue);  
		   //SocketClient('GetAccountBalance,'.$accountno.',');
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['GetAccountInfo']))
		{
		
		   $accountno=$_POST['accountno'];
		   $paramvalue = array('fieldsvalue' => $accountno);
		   $response = $client->call('GetAccountInfo',$paramvalue);  
		//SocketClient('GetAccountInfo,'.$accountno.',');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetAccounts']))
		{
		   $response = $client->call('GetAccounts');  
			//SocketClient('GetAccounts,');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetBalancesOperations']))
		  {
		  
			   $accountno=$_POST['accountno'];
			   $fromtime=$_POST['fromtime'];
			   $totime=$_POST['totime'];
			   $test=strtotime($fromtime);
			   $test1=strtotime($totime);
			   
			   $param = $accountno.','.$test.','.$test1.',';
	   		   $paramvalue = array('fieldsvalue' => $param);
			   $response = $client->call('GetBalancesOperations',$paramvalue);  
			  // SocketClient('GetBalancesOperations,'.$param);
		  }
		  echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['GetGroupRecord']))
		{
		
		    $groupid=$_POST['groupid'];
	   		   $paramvalue = array('fieldsvalue' => $groupid);
			   $response = $client->call('GetGroupRecord',$paramvalue);  
			//SocketClient('GetGroupRecord,'.$groupid.',');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetGroups']))
		{
		
		    $groupid=$_POST['groupid'];
	   		   $paramvalue = array('fieldsvalue' => $groupid);
			   $response = $client->call('GetGroups',$paramvalue);  
			//SocketClient('GetGroups,'.$groupid.',');
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['GetHistory']))
	  {   
			$accountno=$_POST['accountno'];
			$fromtime=$_POST['fromtime'];
			$totime=$_POST['totime'];   
			$test=strtotime($fromtime);
			$test1=strtotime($totime);  
			
			$param = $test.','.$test1.','.$accountno.',';
   	   		   $paramvalue = array('fieldsvalue' => $param);
			   $response = $client->call('GetHistory',$paramvalue);  
		   //SocketClient('GetHistory,'.$param);
	  }
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetLeverageOfGroup']))
		{
		
		    $groupid=$_POST['groupid'];
   	   		   $paramvalue = array('fieldsvalue' => $groupid);
			   $response = $client->call('GetLeverageOfGroup',$paramvalue);  
			//SocketClient('GetLeverageOfGroup,'.$groupid.',');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetAllLeverage']))
		{
		    $response = $client->call('GetAllLeverage');  
			//SocketClient('GetAllLeverage,');
			
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetMarginInfo']))
		{
		
		    $groupid=$_POST['groupid'];
		   $paramvalue = array('fieldsvalue' => $groupid);
		   $response = $client->call('GetMarginInfo',$paramvalue);  
			//SocketClient('GetMarginInfo,'.$groupid.',');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetOpenedTrades']))
		{
		$response = $client->call('GetOpenedTrades');  
		  // SocketClient('GetOpenedTrades,');
		}
		echo nl2br("\n");
		
		
		
		if(count($_POST>0) && isset($_POST['ModifyAccount']))
		{
		
		    $login=$_POST['login'];	
			$group=$_POST['group'];	
			$password =$_POST['password'];			
			$enable=$_POST['enable'];	
			$enable_change_password=$_POST['enable_change_password'];	
			$enable_read_only=$_POST['enable_read_only'];
			$password_investor=$_POST['password_investor'];	
			$password_phone=$_POST['password_phone'];	
			$name=$_POST['name'];	
			$country=$_POST['country'];	
			$city=$_POST['city'];	
			$state=$_POST['state'];	
			$zipcode=$_POST['zipcode'];	
			$address=$_POST['address'];	
			$phone=$_POST['phone'];	
			$email=$_POST['email'];	
			$comment=$_POST['comment'];	
			$id=$_POST['id'];
			$staus=$_POST['staus'];
			$leverage=$_POST['leverage'];	
			$agent_account=$_POST['agent_account'];	
			$balance=$_POST['balance'];	
			$prevmonthbalance=$_POST['prevmonthbalance'];	
			$prevbalance=$_POST['prevbalance'];	
			$credit=$_POST['credit'];	
			$interestrate=$_POST['interestrate'];	
			$taxes=$_POST['taxes'];	
			$prevmonthequity=$_POST['prevmonthequity'];
			$prevequity=$_POST['prevequity'];	
			$publickey=$_POST['publickey'];	
			$send_reports=$_POST['send_reports'];	
			$mqid=$_POST['mqid'];
			$param=$login.','.$group.','.$password.','.$enable.','.$enable_change_password.','.$enable_read_only.','.$password_investor.','.$password_phone.','.$name.','.$country.','.$city.','.$state.','.$zipcode.','.$address.','.$phone.','.$email.','.$comment.','.$id.','.$staus.','.$leverage.','.$agent_account.','.$balance.','.$prevmonthbalance.','.$prevbalance.','.$credit.','.$interestrate.','.$prevmonthequity.','.$prevequity.','.$publickey.','.$send_reports.','.$mqid.',';

   		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('ModifyAccount',$paramvalue);  
			//SocketClient('ModifyAccount,'.$param);
		}
		echo nl2br("\n");	
				
		
		if(count($_POST>0) && isset($_POST['ModifyOrder']))
		{
			$type=$_POST['type'];	
			$reserved=$_POST['reserved'];				
			$cmd=$_POST['cmd'];	
			$order=$_POST['order'];	
			$orderby=$_POST['orderby'];
			$symbol=$_POST['symbol'];	
			$volume=$_POST['volume'];	
			$price=$_POST['price'];	
			$sl=$_POST['sl'];	
			$tp=$_POST['tp'];	
			$ie_deviation=$_POST['ie_deviation'];	
			$comment=$_POST['comment'];	
			$expiration=$_POST['expiration'];	
			$crc=$_POST['crc'];
		$param=$type.','.$reserved.','.$cmd.','.$order.','.$orderby.','.$symbol.','.$volume.','.$price.','.$sl.','.$tp.','.$ie_deviation.','.$comment.','.$expiration.','.$crc.',';
		  
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('ModifyOrder',$paramvalue);  
		//	SocketClient('ModifyOrder,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['ModifyPendingOrder']))
		{
			$type=$_POST['type'];	
			$reserved=$_POST['reserved'];				
			$cmd=$_POST['cmd'];	
			$order=$_POST['order'];	
			$orderby=$_POST['orderby'];
			$symbol=$_POST['symbol'];	
			$volume=$_POST['volume'];	
			$price=$_POST['price'];	
			$sl=$_POST['sl'];	
			$tp=$_POST['tp'];	
			$ie_deviation=$_POST['ie_deviation'];	
			$comment=$_POST['comment'];	
			$expiration=$_POST['expiration'];	
			$crc=$_POST['crc'];
		$param=$type.','.$reserved.','.$cmd.','.$order.','.$orderby.','.$symbol.','.$volume.','.$price.','.$sl.','.$tp.','.$ie_deviation.','.$comment.','.$expiration.','.$crc.',';	
			
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('ModifyPendingOrder',$paramvalue);  
			//SocketClient('ModifyPendingOrder,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['OpenOrder']))
		{
		    $type=$_POST['type'];	
			$reserved=$_POST['reserved'];				
			$cmd=$_POST['cmd'];	
			$order=$_POST['order'];	
			$orderby=$_POST['orderby'];
			$symbol=$_POST['symbol'];	
			$volume=$_POST['volume'];	
			$price=$_POST['price'];	
			$sl=$_POST['sl'];	
			$tp=$_POST['tp'];	
			$ie_deviation=$_POST['ie_deviation'];	
			$comment=$_POST['comment'];	
			$expiration=$_POST['expiration'];	
			$crc=$_POST['crc'];
		$param=$type.','.$reserved.','.$cmd.','.$order.','.$orderby.','.$symbol.','.$volume.','.$price.','.$sl.','.$tp.','.$ie_deviation.','.$comment.','.$expiration.','.$crc.',';
			
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('OpenOrder',$paramvalue);  
			//SocketClient('OpenOrder,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['OpenPendingOrder']))
		
		{
		    $type=$_POST['type'];	
			$reserved=$_POST['reserved'];				
			$cmd=$_POST['cmd'];	
			$order=$_POST['order'];	
			$orderby=$_POST['orderby'];
			$symbol=$_POST['symbol'];	
			$volume=$_POST['volume'];	
			$price=$_POST['price'];	
			$sl=$_POST['sl'];	
			$tp=$_POST['tp'];	
			$ie_deviation=$_POST['ie_deviation'];	
			$comment=$_POST['comment'];	
			$expiration=$_POST['expiration'];   
			$temp=strtotime($expiration);
			$crc=$_POST['crc'];	
		$param=$type.','.$reserved.','.$cmd.','.$order.','.$orderby.','.$symbol.','.$volume.','.$price.','.$sl.','.$tp.','.$ie_deviation.','.$comment.','.$temp.','.$crc.',';
		
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('OpenPendingOrder',$paramvalue);  
		   //SocketClient('OpenPendingOrder,'.$param);
		}
		echo nl2br("\n");
		
		
		if(count($_POST>0) && isset($_POST['SendMail']))
		{
		   $tologinid=$_POST['ToLoginId'];
		   $senderloginid=$_POST['SenderloginId'];
		   $sendername=$_POST['SenderName'];
		   $subject=$_POST['Subject'];
		   $message=$_POST['Message'];
		   
		   $param = $tologinid.','.$senderloginid.','.$sendername.','.$subject.','.$message.',';
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('SendMail',$paramvalue);  
		   //SocketClient('SendMail,'.$param);
		}
		echo nl2br("\n");
		

		
		
		if(count($_POST>0) && isset($_POST['TransferBalance']))
		{
		   $fromac=$_POST['fromac'];
		   $toac=$_POST['toac'];
		   $balance=$_POST['balance'];
		
		$param = $fromac.','.$toac.','.$balance.',';
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('TransferBalance',$paramvalue);  
			//SocketClient('TransferBalance,'.$param);
		}
		echo nl2br("\n");
		
			
		if(count($_POST>0) && isset($_POST['SymbolsGetAll']))
		{
			$response = $client->call('SymbolsGetAll'); 
			//SocketClient('SymbolsGetAll,');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['Getjournal']))
		{
		   $filter=$_POST['filter'];
		   $fromtime=$_POST['fromtime'];
		   $totime=$_POST['totime'];
		   $test=strtotime($fromtime);
		   $test1=strtotime($totime);
		
			$param = $filter.','.$test.','.$test1.',';
		   $paramvalue = array('fieldsvalue' => $param);
		   $response = $client->call('GetJournal',$paramvalue);  
			//SocketClient('GetJournal,'.$param);
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetTradingVolume']))
		{
			$accountno=$_POST['accountno'];	
		   $paramvalue = array('fieldsvalue' => $accountno);
		   $response = $client->call('GetTradingVolume',$paramvalue);  
			//SocketClient('GetTradingVolume,'.$accountno.',');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['GetExposure']))
		{
		
		    $currency=$_POST['currency'];
			$paramvalue = array('fieldsvalue' => $currency);
		    $response = $client->call('GetExposure',$paramvalue);  
			//SocketClient('GetExposure,'.$currency.',');
		}
		echo nl2br("\n");
		
		if(count($_POST>0) && isset($_POST['DeleteAccount']))
		{
		
		    $account=$_POST['accountno'];
			$paramvalue = array('fieldsvalue' => $account);
		    $response = $client->call('DeleteAccount',$paramvalue);  
			//SocketClient('DeleteAccount,'.$account.',');
		}
		echo nl2br("\n");

		if(count($_POST>0) && isset($_POST['CloseOrder']))
		{
		    $type=$_POST['type'];	
			$reserved=$_POST['reserved'];				
			$cmd=$_POST['cmd'];	
			$order=$_POST['order'];	
			$orderby=$_POST['orderby'];
			$symbol=$_POST['symbol'];	
			$volume=$_POST['volume'];	
			$price=$_POST['price'];	
			$sl=$_POST['sl'];	
			$tp=$_POST['tp'];	
			$ie_deviation=$_POST['ie_deviation'];	
			$comment=$_POST['comment'];	
			$expiration=$_POST['expiration'];	
			$crc=$_POST['crc'];
		$param=$type.','.$reserved.','.$cmd.','.$order.','.$orderby.','.$symbol.','.$volume.','.$price.','.$sl.','.$tp.','.$ie_deviation.','.$comment.','.$expiration.','.$crc.',';
			
			$paramvalue = array('fieldsvalue' => $param);
		    $response = $client->call('CloseOrder',$paramvalue);  
			//SocketClient('CloseOrder,'.$param);
		}
		echo nl2br("\n");

		if(count($_POST>0) && isset($_POST['DeleteOrder']))
		{
		    $type=$_POST['type'];	
			$reserved=$_POST['reserved'];				
			$cmd=$_POST['cmd'];	
			$order=$_POST['order'];	
			$orderby=$_POST['orderby'];
			$symbol=$_POST['symbol'];	
			$volume=$_POST['volume'];	
			$price=$_POST['price'];	
			$sl=$_POST['sl'];	
			$tp=$_POST['tp'];	
			$ie_deviation=$_POST['ie_deviation'];	
			$comment=$_POST['comment'];	
			$expiration=$_POST['expiration'];	
			$crc=$_POST['crc'];
		$param=$type.','.$reserved.','.$cmd.','.$order.','.$orderby.','.$symbol.','.$volume.','.$price.','.$sl.','.$tp.','.$ie_deviation.','.$comment.','.$expiration.','.$crc.',';
			
			$paramvalue = array('fieldsvalue' => $param);
		    $response = $client->call('DeleteOrder',$paramvalue);  
			//SocketClient('DeleteOrder,'.$param);
		}
		echo nl2br("\n");


		if(count($_POST>0) && isset($_POST['GetAccountsPnlCommissionSawp']))
	  {   
			
			$fromtime=$_POST['fromtime'];
			$totime=$_POST['totime'];   
			$test=strtotime($fromtime);
			$test1=strtotime($totime);  
			$accountno=$_POST['accountno'];
			$param = $test.','.$test1.','.$accountno.',';
			
   			$paramvalue = array('fieldsvalue' => $param);
		    $response = $client->call('GetAccountsPnlCommissionSawp',$paramvalue);  
		   //SocketClient('GetAccountsPnlCommissionSawp,'.$param);
	  }


	if(count($_POST>0) && isset($_POST['GetServers']))
		{
			$response = $client->call('GetServers'); 		
			//SocketClient('GetServers,');
		}
		echo nl2br("\n");
 
		if(count($_POST>0) && isset($_POST['DeleteFile']))
		{
		   $filename = $_POST['filename']; 
		   $paramvalue = array('fieldsvalue' => $filename); 
		   $response = $client->call('DeleteFile',$paramvalue);
		   //SocketClient('DeleteFile,'.$filename);
		}
		echo nl2br("\n");


echo("<script>location.href='mt4ui.php?token=1'</script>");

	
?>
</body>
</html>