<?php
error_reporting(1);
include_once('db_config.php');

	if(count($_POST>0) && isset($_POST['OHLC']))
		{
			//print_r($_POST); die;
			$to = $_POST['tdate'];
			$from = $_POST['fdate'];
			$symbolname = $_POST['symbolname'];
			
			$fdateconvert =  date_create($from);
			$fdate = date_format($fdateconvert,"Y-m-d"); 
			
			
			$tdateconvert =  date_create($to);
			$tdate = date_format($tdateconvert,"Y-m-d");
			
			$sql = "SELECT DATE_FORMAT(Timestamp, '%Y.%m.%d') as Timestamp ,Ask,Bid,High,Low FROM ohlc_1min WHERE Symbol ='$symbolname' AND (Timestamp BETWEEN '$fdate' AND '$tdate') ";
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				fputcsv($fp, $data);
				
			}

			$data = array("result" => 0, "data" => $result);
			header("Content-type: application/json");
			echo json_encode($data);
			mysql_close($conn);
			break;
		
		}
		
	
	if(count($_POST>0) && isset($_POST['spread']))
		{
			$from = $_POST['fdate'];
			$to = $_POST['tdate'];
			
			$fdateconvert =  date_create($from);
			$fdate = date_format($fdateconvert,"Y-m-d"); 
			
			
			$tdateconvert =  date_create($to);
			$tdate = date_format($tdateconvert,"Y-m-d");
			
						
			//fputcsv($fp, array('Symbol,AvgrageSpread,London,NY,Tokyo,Sydney'));
			
			$sql = "SELECT Symbol,AVG(AvgrageSpread) as AvgrageSpread,AVG(London) as London,AVG(NY) as NY,AVG(Tokyo) as Tokyo,AVG(Sydney) as Sydney FROM `avgspreadonsessionclose` WHERE (Timestamp BETWEEN '$fdate' AND '$tdate') group by Symbol";
			
			
			$select = mysql_query($sql);
			$result = array();
			
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				fputcsv($fp, $data);
				
			}
			
			
			$data = array("result" => 0, "data" => $result);
			header("Content-type: application/json");
			echo json_encode($data);
	
			mysql_close($conn);
	
			break;
		}
		
		
?>
