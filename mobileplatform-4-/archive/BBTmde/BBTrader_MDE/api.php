<?php
session_start();
include("config.php");
include("contract.php");
date_default_timezone_set("Asia/Kolkata");
$d2=date("Y-m-d H:i:s");
$username1 = $_REQUEST['var11'];
$password1 = $_REQUEST['var12'];
?>
<script>
Market();
</script> 
<div id="outer" style="border:none;">
      <div class="span4" style="display:none;" id="span4">
          <div class="market_watch">
        <!--<div class="table_haeding_row">Market Watch <span id="market-watch-status" style="float:right; padding:0"> </span></div>-->
         <table class="table table-hover table-responsive" border="1" width="100%" id="myTable">
            <thead>
      <tr class="danger bg-danger">
        <th class="responsive2">
        
 Currency Pair</th><th class="responsive1">Bid</th><th class="responsive1">Ask</th><th class="responsive1">Ltp</th>
      </tr>
</thead>
<tbody id="LowerDiv" class="scrollContent">

      
                <?php
//echo "SELECT * FROM users where username='".$username1."' and password='".$password1."' and symbols!=''";
				$qty12=mysql_query("SELECT * FROM users where username='".$username1."' and password='".$password1."' and symbols!=''");
				$res12=mysql_fetch_array($qty12);
				
				$num4=mysql_num_rows($qty12);
				if($num4>0)
				{
					$sym2=explode(",",$res12['symbols']);
					//print_r($sym2);
					
					$num=count($sym2);
					for($i=0;$i<$num;$i++){
					
						$query8=mysql_query("select * from symbols where Symbol='".$sym2[$i]."'");
						$result8=mysql_fetch_array($query8);
					?>
                    
                    <script>
                    sessionStorage.setItem("<?php echo $sym2[$i]; ?>", <?php echo $result8['ContractSize'];?>);
                    sessionStorage.setItem("<?php echo $sym2[$i]; ?>#digit", <?php echo $result8['Digits'];?>);
                    symboleContSize["<?php echo $sym2[$i]; ?>"] = "<?php echo $result8['ContractSize'];?>";
                    symboles.push("<?php echo $sym2[$i]; ?>");
                    //document.getElementById("totalsambolPur").val = symboles;
                    $('#totalsambolPur').val(symboles);
                    </script>

					<tr id="tr_<?php echo $sym2[$i]; ?>" class="info bg-info" >
                       <td class="responsive2"><div id="<?php echo $sym2[$i]; ?>#Symbol" class="context-menu-one box menu-1"><?php echo $sym2[$i];?></div></td>
                       
                        <td class="responsive1"><div id="<?php echo $sym2[$i];?>Bid" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>Ask" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>Mid" ></div></td>
                       <td style="display:none;"><div id="<?php echo $sym2[$i]; ?>#Size"><?php echo trim($result8['ContractSize'])?></div></td>
                       
                    </tr>
                    
                    <tr id="tr_<?php echo $sym2[$i];?>" class="info bg-info" > 
                    	<td class="responsive2">&nbsp;</td>
                        <td style="display:none;"><div id="<?php echo $sym2[$i]; ?>open1" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>high" ></div></td>
                        <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>low" ></div></td>
                         <td class="responsive1"><div id="<?php echo $sym2[$i]; ?>close1" ></div></td>
                      
                    </tr>
					
				<?php  } // for loop end
			
 				
					} else{ 
					
				$queryEmpty=mysql_query("TRUNCATE TABLE symbols");
                    // For Getting All Symbols from Contract
                    $Arr=objectToArray($webService);        
                        foreach ($Arr as $innerArray) {
                        //  Check type
                        if (is_array($innerArray)){
                        //  Scan through inner loop
                        foreach ($innerArray as $value) {
                        
                          if (is_array($value)){
                         
                          foreach ($value as $explodeSYB) {  
						  
						  $query=mysql_query("insert into symbols(Symbol,ContractSize,Digits)values('".trim($explodeSYB['Symbol'])."','".trim($explodeSYB['ContractSize'])."','".trim($explodeSYB['Digits'])."')");                   
                    
					
                    ?>
                    <script>
                    sessionStorage.setItem("<?php echo $explodeSYB['Symbol'];?>", <?php echo $explodeSYB['ContractSize'];?>);
                    sessionStorage.setItem("<?php echo $explodeSYB['Symbol'];?>#digit", <?php echo $explodeSYB['Digits'];?>);
                    symboleContSize["<?php echo $explodeSYB['Symbol'];?>"] = "<?php echo $explodeSYB['ContractSize'];?>";
                    symboles.push("<?php echo $explodeSYB['Symbol'];?>");
                    //document.getElementById("totalsambolPur").val = symboles;
                    $('#totalsambolPur').val(symboles);
                    </script>
                    <tr id="tr_<?php echo trim($explodeSYB['Symbol'])?>" class="info bg-info" >
                       <td class="responsive2"><div id="<?php echo trim($explodeSYB['Symbol']); ?>#Symbol" class="context-menu-one box menu-1"><?php echo $explodeSYB['Symbol'];?></div></td>
                       <td style="display:none;"><?php echo trim($explodeSYB['TradingGateway'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['Symbol'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['SecurityTypeID'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['Source'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['Digits'])?></td>
                        <td style="display:none;"><?php echo trim($explodeSYB['InstruementID'])?></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>Bid" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>Ask" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>Mid" ></div></td>
                       <td style="display:none;"><div id="<?php echo trim($explodeSYB['Symbol'])?>#Size"><?php echo trim($explodeSYB['ContractSize'])?></div></td>
                       <td style="display:none;"><?php echo trim($explodeSYB['LimitAndStopLevel'])?></td>
                    </tr>
                    
                    <tr id="tr_<?php echo trim($explodeSYB['Symbol'])?>" class="info bg-info" > 
                    	<td class="responsive2">&nbsp;</td>
                        <td style="display:none;"><div id="<?php echo trim($explodeSYB['Symbol'])?>open1" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>high" ></div></td>
                        <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>low" ></div></td>
                         <td class="responsive1"><div id="<?php echo trim($explodeSYB['Symbol'])?>close1" ></div></td>
                      
                    </tr>
                    
                    <?php
									} // for if condition
                               } // for each
                             }
                          }
                       }
                    }
                    ?>
					               
</tbody>               
            <input type="hidden" name="totalsambolPur" id="totalsambolPur" value="" />
         </table>
        
        </div>
        
      </div>
      <!--<div class="span8  context-menu-two box menu-1">-->
     
  <!-- container end -->
</div>

           