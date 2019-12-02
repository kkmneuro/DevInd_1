<?php 

			
			$today = date("Y-m-d H:i:s"); 
			error_reporting(0);
			$dt2 = date("YmdHis");
			
			ini_set('display_errors',false);
			define("MT4_URL", "http://108.175.9.76:81/mt4ui-chak/MT4Details.php");
			define("XML_Name", 'pks_'.$dt2);
			define("XML_URL", "http://108.175.9.76:81/mt4ui-chak/xmlfile/".XML_Name.".xml");
			define("SERVER_NAME1", '1'); // for demo A/c
			define("SERVER_NAME2", '2'); // for Live A/c
			
			
			function CurrentXml()
			{
				$dt3 = date("YmdHis");
				define("XML_Name", '100_'.$dt3);
			}


            
			
			/// Create Demo account from MT4 ///////
			$username = 'pkstest';
			$email = 'test@gmail.com';
			$contactno = 0;
			$groups = 'demoOBROKER-USD';
			$country = 'India';
			$balance = '1000';
			CurrentXml(); 
			$ch = curl_init();
			curl_setopt($ch, CURLOPT_URL,MT4_URL);
			curl_setopt($ch, CURLOPT_POST, 1);
			//curl_setopt($ch, CURLOPT_POSTFIELDS,          "login=8190170&name=prabhat&group=democDMA");
			
			// in real life you should use something like:
			curl_setopt($ch, CURLOPT_POSTFIELDS, 
			  http_build_query(array('xmlname' => XML_Name,'servername' => SERVER_NAME1, 'name' => $username,'group' => $groups,'enable' => '1', 'email' => $email, 'phone'=>$contactno,'country'=> $country, 'balance' => $balance, 'CreateAccount' => 'CreateAccount')));
			
			// receive server response ...
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
			$server_output = curl_exec ($ch);
			curl_close ($ch);
			for ($i=0; $i <= 10; $i++)
			{
				$xml = simplexml_load_file(XML_URL);
				$Login = $xml->Account->Login;
				$Password = $xml->Account->Password;
				$InvesterPassword = $xml->Account->InvesterPassword;
		    sleep(1);
			}
echo 'XML file name: '.XML_Name;			
echo '<br><br>';
print_r($xml);						
			///////// End ////////////
