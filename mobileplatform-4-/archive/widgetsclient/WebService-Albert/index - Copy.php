<?php
error_reporting(0);
include_once('db_config.php');

$method = $_GET['method'];
switch($method){
	
		// Start Currency Webservice //
		case "currency": // For case Currency Webservice
		
		$to = $_GET['to'];
		$from = $_GET['from'];
		$currency = $_GET['currency'];
		$currencyname = $_GET['currencyname'];
		if(empty($method)){
			$data = array("result" => 0, "message" => "Wrong Parameter Let ‘s try once again!");

		} else {
			// get user data
			$filename = "ohlc.csv";
			$fp = fopen('php://output', 'w');

			header('Content-type: application/csv');
			header('Content-Disposition: attachment; filename='.$filename);
			fputcsv($fp, $header);

			$sql = "SELECT DATE_FORMAT(Timestamp, '%Y.%m.%d') as Timestamp ,Ask,Bid,High,Low FROM ohlc_1min WHERE Symbol ='$currencyname' AND (Timestamp BETWEEN '$from' AND '$to') ";
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				fputcsv($fp, $data);
				
			}

			$data = array("result" => 0, "data" => $result);
			
		}

		
		//print_r($data);
		
		/* JSON Response */
		//header("Content-type: application/json");
		//echo json_encode($data);
	
		/* CSV Response */
		
		
		mysql_close($conn);
	
		break;
		// End Currency Webservice //
		
		// Start spread Webservice //
		
		case "spread":  // For case spread Webservice
		
		$to = $_GET['to'];
		$from = $_GET['from'];
		if(empty($method)){
			$data = array("result" => 0, "message" => "Wrong Parameter Let ‘s try once again!");

		} else {
			// get user data
			$filename = "spread.csv";
			$fp = fopen('php://output', 'w');

			header('Content-type: application/csv');
			header('Content-Disposition: attachment; filename='.$filename);
			fputcsv($fp, $header);
			
			//fputcsv($fp, array('Symbol,AvgrageSpread,London,NY,Tokyo,Sydney'));
			
			$sql = "SELECT Symbol,AVG(AvgrageSpread) as AvgrageSpread,AVG(London) as London,AVG(NY) as NY,AVG(Tokyo) as Tokyo,AVG(Sydney) as Sydney FROM `avgspreadonsessionclose` WHERE (Timestamp BETWEEN '$from' AND '$to') group by Symbol"; 
			$select = mysql_query($sql);
			$result = array();
			
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				fputcsv($fp, $data);
				
			}
			
			
			$data = array("result" => 0, "data" => $result);
			
		}
		
		//print_r($data);
		
		/* JSON Response */
		//header("Content-type: application/json");
		//echo json_encode($data);
		
		/* CSV Response */
		
		mysql_close($conn);
		break;
		// End spread Webservice //
		
		default:
			$data = array("result" => 0, "message" => "Wrong Parameter Let's try once again!");
			header("Content-type: application/json");
			echo json_encode($data);
		break;
	}
	
		

?>
