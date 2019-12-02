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
			$xmlString = '<?xml version="1.0" encoding="UTF-8"?>';
			$xmlString .= '<ohlcdata>';
			
			$sql = "SELECT * FROM ohlc_1min WHERE Symbol ='$currencyname' AND (Timestamp BETWEEN '$from' AND '$to') ";
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				$xmlString .= '<Symbols>';
				$xmlString .= '<Symbol>';$xmlString .= $data['Symbol'];$xmlString .= '</Symbol>';
				$xmlString .= '<Timestamp>';$xmlString .= $data['Timestamp'];$xmlString .= '</Timestamp>';
				$xmlString .= '<Ask>';$xmlString .= $data['Ask'];$xmlString .= '</Ask>';
				$xmlString .= '<Bid>';$xmlString .= $data['Bid'];$xmlString .= '</Bid>';
				$xmlString .= '<High>';$xmlString .= $data['High'];$xmlString .= '</High>';
				$xmlString .= '<Low>';$xmlString .= $data['Low'];$xmlString .= '</Low>';
				$xmlString .= '</Symbols>';
			}

			$data = array("result" => 0, "data" => $result);
			$xmlString .= '</ohlcdata>';	
		}

		
		//print_r($data);
		
		/* JSON Response */
		header("Content-type: application/json");
		echo json_encode($data);
	
		/* XML Response */
		$dom = new DOMDocument;
		$dom->preserveWhiteSpace = FALSE;
		$dom->loadXML($xmlString);

		//Save XML as a file
		$dom->save('XML/ohlc.xml');
		
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
			$xmlString = '<?xml version="1.0" encoding="UTF-8"?>';
			$xmlString .= '<spreaddata>';
			
			$sql = "SELECT * FROM avgspreadonsessionclose WHERE (Timestamp BETWEEN '$from' AND '$to') ";
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				$xmlString .= '<Symbols>';
				$xmlString .= '<Session>';$xmlString .= $data['Session'];$xmlString .= '</Session>';
				$xmlString .= '<Symbol>';$xmlString .= $data['Symbol'];$xmlString .= '</Symbol>';
				$xmlString .= '<Timestamp>';$xmlString .= $data['Timestamp'];$xmlString .= '</Timestamp>';
				$xmlString .= '<AvgSpread>';$xmlString .= $data['AvgSpread'];$xmlString .= '</AvgSpread>';
				$xmlString .= '</Symbols>';
			}

			$data = array("result" => 0, "data" => $result);
			$xmlString .= '</spreaddata>';	

		}
		
		//print_r($data);
		
		/* JSON Response */
		header("Content-type: application/json");
		echo json_encode($data);
		
		/* XML Response */
		$dom = new DOMDocument;
		$dom->preserveWhiteSpace = FALSE;
		$dom->loadXML($xmlString);

		//Save XML as a file
		$dom->save('XML/spread.xml');
	
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
