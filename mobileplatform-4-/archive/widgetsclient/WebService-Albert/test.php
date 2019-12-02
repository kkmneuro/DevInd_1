<?php
error_reporting(0);
include_once('db_config.php');


/*$filename = "toy_csv.csv";
$fp = fopen('php://output', 'w');

header('Content-type: application/csv');
header('Content-Disposition: attachment; filename='.$filename);
fputcsv($fp, $header);*/

 $filename = 'test.html';
 header("Cache-Control: public");
 header("Content-Description: File Transfer");
 header("Content-Disposition: attachment; filename=$filename");
 header("Content-Type: application/octet-stream; ");
 header("Content-Transfer-Encoding: binary");
 $fh = fopen($filename, 'w'); // or die("error");  

$xmlString = '<?xml version="1.0" encoding="UTF-8"?>';
$xmlString .= '<spreaddata>';

$sql = "SELECT * FROM avgspreadonsessionclose ";
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
				
				//fputcsv($fp, $data);
				$stringData = "you html code php code goes here"; 
				fwrite($fh, $stringData);
				fopen($fh, $stringData);
				
				
			}
$xmlString .= '</spreaddata>';	

$dom = new DOMDocument;
$dom->preserveWhiteSpace = FALSE;
$dom->loadXML($xmlString);

//Save XML as a file
$dom->save('XML/spread.xml');

/*$dom->formatOutput = TRUE;
echo $dom->saveXml();*/

$doc = new DOMDocument('1.0');
// we want a nice output
$doc->formatOutput = true;

$root = $doc->createElement('html');
$root = $doc->appendChild($root);

$head = $doc->createElement('head');
$head = $root->appendChild($head);

$title = $doc->createElement('title');
$title = $head->appendChild($title);

$text = $doc->createTextNode('This is the title');
$text = $title->appendChild($text);

echo 'Wrote: ' . $doc->saveHTMLFile("XML/test2.html") . ' bytes'; // Wrote: 129 bytes

 
?>
