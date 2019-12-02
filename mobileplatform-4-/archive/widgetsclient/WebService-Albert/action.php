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
			$fdate = $fdate.' 00:00:00';
			
			$tdateconvert =  date_create($to);
			$tdate = date_format($tdateconvert,"Y-m-d");
			$tdate = $tdate.' 23:59:59';
			
			$filename = $symbolname.".csv";
			$fp = fopen('php://output', 'w');

			header('Content-type: application/csv');
			header('Content-Disposition: attachment; filename='.$filename);
			fputcsv($fp, $header);
			
			if($symbolname==''){
				$sql = "SELECT DATE_FORMAT(Timestamp, '%Y.%m.%d %h:%i:%s') as Timestamp ,Ask,Bid,High,Low,Volume FROM ohlc_1min WHERE  (Timestamp BETWEEN '$fdate' AND '$tdate') "; 
			} else {
				$sql = "SELECT DATE_FORMAT(Timestamp, '%Y.%m.%d') as Timestamp ,DATE_FORMAT(Timestamp, '%h:%i:%s') as Time,Ask,Bid,High,Low,Volume FROM ohlc_1min WHERE Symbol ='$symbolname' AND (Timestamp BETWEEN '$fdate' AND '$tdate') "; 
			}
			
			$select = mysql_query($sql);
			$result = array();
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				fputcsv($fp, $data);
				
			}

			$data = array("result" => 0, "data" => $result);
		}
		
	
	if(count($_POST>0) && isset($_POST['spread']))
		{
			$from = $_POST['fdate'];
			$to = $_POST['tdate'];
			
			$fdateconvert =  date_create($from);
			$fdate = date_format($fdateconvert,"Y-m-d"); 
			
			
			$tdateconvert =  date_create($to);
			$tdate = date_format($tdateconvert,"Y-m-d");
			
			
			
			/*$to = '2016-10-4';
			$from = '2016-08-4'; */
			
			//print_r($_POST); die;
			
			
			$filename = "Average Spreads.csv";
			$fp = fopen('php://output', 'w');

			header('Content-type: application/csv');
			header('Content-Disposition: attachment; filename='.$filename);
			fputcsv($fp, $header);
			
			fputcsv($fp, array('From : ',$from));
			fputcsv($fp, array('To : ',$to));
			fputcsv($fp, array('Symbol','AvgrageSpread','London','NY','Tokyo','Sydney'));
			
			$sql = "SELECT Symbol,AVG(AvgrageSpread) as AvgrageSpread,AVG(London) as London,AVG(NY) as NY,AVG(Tokyo) as Tokyo,AVG(Sydney) as Sydney FROM `avgspreadonsessionclose` WHERE (Timestamp BETWEEN '$fdate' AND '$tdate') group by Symbol";
			
			//$sql = "SELECT Symbol,AVG(AvgrageSpread) as AvgrageSpread,AVG(London) as London,AVG(NY) as NY,AVG(Tokyo) as Tokyo,AVG(Sydney) as Sydney FROM `avgspreadonsessionclose` group by Symbol";
			
			$select = mysql_query($sql);
			$result = array();
			
			while($data = mysql_fetch_assoc($select)) 
			{
				$result[] = $data;
				fputcsv($fp, $data);
				
			}
			
			
			$data = array("result" => 0, "data" => $result);
		}
		
		
?>
