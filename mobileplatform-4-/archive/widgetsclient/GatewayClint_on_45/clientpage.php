<?php

class Test{
	private $serviceURL = "http://74.208.228.33:82/RestServiceImpl.svc/";
	private $managerId = 1;
	private $tokenid;
	public $debug = array();

	private function request($url){
		$ch = curl_init();
		curl_setopt($ch, CURLOPT_URL, $url);
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, TRUE);
		curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 4); 
		curl_setopt($ch, CURLOPT_TIMEOUT, 4);
		$response = curl_exec($ch);
		curl_close($ch);

		if(!empty($response)){
			// $d = preg_replace("/([{,])([a-zA-Z][^: ]+):/", "$1\"$2\":", $response);
			// return $d;
			return json_decode($response,true);
		}
		return false;
	}

	public function AuthenticateUser(){
		$url = $this->serviceURL.'AuthenticateUser/lqd3192/g1JNDDr$mOE';
		$res = $this->request($url);
		$this->tokenid = $res['AuthenticateUserResult'];
		if ($this->tokenid === false){
			$this->debug[] = array("message"=>"Couldn't get token");
		}
		return $this->tokenid;
	}
	public function GetAccounts(){
		$url = $this->serviceURL."GetAccounts/".$this->tokenid."/".$this->managerId;
		return $this->request($url)["GetAccountsResult"];
	}
	public function CheckPassword($accountId,$password,$comment){
		$url = $this->serviceURL."CheckPassword/".$this->tokenid."/".$this->managerId."/".$accountId."/".$password."/".$comment;
		return $this->request($url)["CheckPasswordResult"];
	}
	public function ChangePassword($accountId,$password,$newpassword){
		$url = $this->serviceURL."ChangePassword/".$this->tokenid."/".$this->managerId."/".$accountId."/".$password."/".$newpassword;
		return $this->request($url)["ChangePasswordResult"];
	}
	public function GetAccountInfo($accountId){
		$url = $this->serviceURL."GetAccountInfo/".$this->tokenid."/".$this->managerId."/".$accountId;
		return $this->request($url)["GetAccountInfoResult"];
	}
	public function changeBalance($accountId,$balance,$comment){
		$url = $this->serviceURL."changeBalance/".$this->tokenid."/".$this->managerId."/".$accountId."/".$balance."/".$comment;
		return $this->request($url)["changeBalanceResult"];
	}
	public function ChangeCredit($accountId,$balance,$time,$comment){
		$url = $this->serviceURL."ChangeCredit/".$this->tokenid."/".$this->managerId."/".$accountId."/".$balance."/".$time."/".$comment;
		return $this->request($url)["ChangeCreditResult"];
	}
	public function TransferBalance($fromaccountId,$ToaccountId,$balance,$comment){
		$url = $this->serviceURL."TransferBalance/".$this->tokenid."/".$this->managerId."/".$fromaccountId."/".$ToaccountId."/".$balance."/".$comment;
		return $this->request($url)["TransferBalanceResult"];
	}
	public function SymbolsGetAll(){
		$url = $this->serviceURL."SymbolsGetAll/".$this->tokenid."/".$this->managerId;
		return $this->request($url)["SymbolsGetAllResult"];
	}
	public function CreateAccount($login,$group,$password,$enable,$enable_change_password,$enable_read_only,$password_investor,$password_phone,$name,$country,$city,$state,$zipcode,$address,$phone, $email,$comment,$id,$status,$leverage,$agent_account,$balance,$prevmonthbalance,$prevbalance,$credit){
		$url = $this->serviceURL."CreateAccount/".$this->tokenid."/".$this->managerId."/".$login."/".$group."/".$password."/".$enable."/".$enable_change_password."/".$enable_read_only."/".$password_investor."/".$password_phone."/".$name."/".$country."/".$city."/".$state."/".$zipcode."/".$address."/".$phone."/". $email."/".$comment."/".$id."/".$status."/".$leverage."/".$agent_account."/".$balance."/".$prevmonthbalance."/".$prevbalance."/".$credit;
		return $this->request($url)["CreateAccountResult"];
	}
	public function ModifyAccount($login,$group,$password,$enable,$enable_change_password,$enable_read_only,$password_investor,$password_phone,$name,$country,$city,$state,$zipcode,$address,$phone, $email,$comment,$id,$status,$leverage,$agent_account,$balance,$prevmonthbalance,$prevbalance,$credit){
		$url = $this->serviceURL."ModifyAccount/".$this->tokenid."/".$this->managerId."/".$login."/".$group."/".$password."/".$enable."/".$enable_change_password."/".$enable_read_only."/".$password_investor."/".$password_phone."/".$name."/".$country."/".$city."/".$state."/".$zipcode."/".$address."/".$phone."/". $email."/".$comment."/".$id."/".$status."/".$leverage."/".$agent_account."/".$balance."/".$prevmonthbalance."/".$prevbalance."/".$credit;
		return $this->request($url)["ModifyAccountResult"];
	}
	public function DeleteAccount($accountId,$comment){
		$url = $this->serviceURL."DeleteAccount/".$this->tokenid."/".$this->managerId."/".$accountId."/".$comment;
		return $this->request($url)["DeleteAccountResult"];
	}
	public function GetOpenedTradesForAccountId($accountId){
		$url = $this->serviceURL."GetOpenedTradesForAccountId/".$this->tokenid."/".$this->managerId."/".$accountId;
		return $this->request($url)["GetOpenedTradesForAccountIdResult"];
	}
	public function GetOpenOrders(){
		$url = $this->serviceURL."GetOpenOrders/".$this->tokenid."/".$this->managerId;
		return $this->request($url)["GetOpenOrdersResult"];
	}
	public function GetTradeHistory($accountId,$FromTime,$TillTime){
		$url = $this->serviceURL."GetTradeHistory/".$this->tokenid."/".$this->managerId."/".$accountId."/".$FromTime."/".$TillTime;
		return $this->request($url)["GetTradeHistoryResult"];
	}
	public function AccountHaveTrades($accountId,$FromTime,$TillTime){
		$url = $this->serviceURL."AccountHaveTrades/".$this->tokenid."/".$this->managerId."/".$accountId."/".$FromTime."/".$TillTime;
		return $this->request($url)["AccountHaveTradesResult"];
	}
	public function UpdateLeverage($accountId,$leverage){
		$url = $this->serviceURL."UpdateLeverage/".$this->tokenid."/".$this->managerId."/".$accountId."/".$leverage;
		return $this->request($url)["UpdateLeverageResult"];
	}
	public function GetGroupRecord($group){
		$url = $this->serviceURL."GetGroupRecord/".$this->tokenid."/".$this->managerId."/".$group;
		return $this->request($url)["GetGroupRecordResult"];
	}
	public function GetGroups(){
		$url = $this->serviceURL."GetGroups/".$this->tokenid."/".$this->managerId;
		return $this->request($url)["GetGroupsResult"];
	}
	public function GetAccountBalance($accountId,$comment){
		$url = $this->serviceURL."GetAccountBalance/".$this->tokenid."/".$this->managerId."/".$accountId."/".$comment;
		return $this->request($url)["GetAccountBalanceResult"];
	}
	public function OpenOrder($Type,$reserved,$cmd,$order,$LoginId,$symbol,$volume,$tradeprice,$stoploss,$takeprofit,$deviation,$comment,$crc){
		$url = $this->serviceURL."OpenOrder/".$this->tokenid."/".$this->managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
		return $this->request($url)["OpenOrderResult"];
	}
	public function ModifyOrder($Type,$reserved,$cmd,$order,$LoginId,$symbol,$volume,$tradeprice,$stoploss,$takeprofit,$deviation,$comment,$crc){
		$url = $this->serviceURL."ModifyOrder/".$this->tokenid."/".$this->managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
		return $this->request($url)["ModifyOrderResult"];
	}
	public function OpenPendingOrder($Type,$reserved,$cmd,$order,$LoginId,$symbol,$volume,$tradeprice,$stoploss,$takeprofit,$deviation,$comment,$expiration,$crc){
		$url = $this->serviceURL."OpenPendingOrder/".$this->tokenid."/".$this->managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$expiration."/".$crc;
		return $this->request($url)["OpenPendingOrderResult"];
	}
	public function ModifyPendingOrder($Type,$reserved,$cmd,$order,$LoginId,$symbol,$volume,$tradeprice,$stoploss,$takeprofit,$deviation,$comment,$expiration,$crc){
		$url = $this->serviceURL."ModifyPendingOrder/".$this->tokenid."/".$this->managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$expiration."/".$crc;
		return $this->request($url)["ModifyPendingOrderResult"];
	}
	public function CloseOrder($Type,$reserved,$cmd,$order,$LoginId,$symbol,$volume,$tradeprice,$stoploss,$takeprofit,$deviation,$comment,$crc){
		$url = $this->serviceURL."CloseOrder/".$this->tokenid."/".$this->managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
		return $this->request($url)["CloseOrderResult"];
	}
	public function DeleteOrder($Type,$reserved,$cmd,$order,$LoginId,$symbol,$volume,$tradeprice,$stoploss,$takeprofit,$deviation,$comment,$crc){
		$url = $this->serviceURL."DeleteOrder/".$this->tokenid."/".$this->managerId."/".$Type."/".$reserved."/".$cmd."/".$order."/".$LoginId."/".$symbol."/".$volume."/".$tradeprice."/".$stoploss."/".$takeprofit."/".$deviation."/".$comment."/".$crc;
		return $this->request($url)["DeleteOrderResult"];
	}
}


$tconn = new Test;
$tconn->AuthenticateUser(); // working
//$res = $tconn->GetAccounts();// working
// $res = $tconn->GetGroups();// working
// $res = $tconn->GetOpenOrders(); // working
//$res = $tconn->GetAccountInfo("50356487"); // working
//$res = $tconn->GetAccountBalance("50356487",1); // working
//$res = $tconn->GetGroupRecord("manager"); // not 
$res = $tconn->SymbolsGetAll();// working


//var_dump($tconn->AuthenticateUser());
//var_dump($res);
 echo '<pre>';
 print_r($res);
 echo '</pre>';
// var_dump($tconn->debug);