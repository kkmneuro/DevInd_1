<?php
error_reporting(0);
include_once('db_config.php');

$method = $_GET['method'];
switch($method){
		case "currency":
		$to = $_GET['to'];
		$from = $_GET['from'];
		$currency = $_GET['currency'];
		$currencyname = $_GET['currencyname'];
		if(empty($method)){
			$data = array("result" => 0, "message" => "Wrong Parameter Let ‘s try once again!");

		} else {
			// get user data
			$sql = "SELECT * FROM ohlc_1min WHERE Symbol ='$currencyname' AND (Timestamp BETWEEN '$from' AND '$to') ";
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
			}

			$data = array("result" => 0, "data" => $result);
		}

		
		//print_r($data);
		
		/* JSON Response */
		header("Content-type: application/json");
		echo json_encode($data);
	
		mysql_close($conn);
	
		break;
		
		case "spread":
		$to = $_GET['to'];
		$from = $_GET['from'];
		if(empty($method)){
			$data = array("result" => 0, "message" => "Wrong Parameter Let ‘s try once again!");

		} else {
			// get user data
			$sql = "SELECT Symbol,AVG(AvgrageSpread) as AvgrageSpread,AVG(London) as London,AVG(NY) as NY,AVG(Tokyo) as Tokyo,AVG(Sydney) as Sydney FROM `avgspreadonsessionclose` WHERE (Timestamp BETWEEN '$from' AND '$to') group by Symbol"; 
			
			//echo $sql = "SELECT * FROM `avgspreadonsessionclose` WHERE (Timestamp BETWEEN '$from' AND '$to') group by Symbol "; 
			
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
			}

			$data = array("result" => 0, "data" => $result);
		}

		
		//print_r($data);
		
		/* JSON Response */
		header("Content-type: application/json");
		echo json_encode($data);
	
		mysql_close($conn);
		break;
		
		default:
			$data = array("result" => 0, "message" => "Wrong Parameter Let's try once again!");
			header("Content-type: application/json");
			echo json_encode($data);
		break;
	}
	
		

?>
