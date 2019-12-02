<?php
error_reporting(E_STRICT);
date_default_timezone_set("Asia/Calcutta");
include("class.phpmailer.php");

$cEmail           = "prabhat@ltecindia.com";
$cName            = "Prabhat";  


$mail             = new PHPMailer();

$mail->IsSMTP();
$mail->SMTPAuth   = true;                  // enable SMTP authentication
$mail->SMTPSecure = "ssl";                 // sets the prefix to the servier
$mail->Host       = "smtp.gmail.com";      // sets GMAIL as the SMTP server
$mail->Port       = 465;                   // set the SMTP port for the GMAIL server

$mail->Username   = "nirajkumarok@gmail.com";  // GMAIL username
$mail->Password   = "9580052899";            // GMAIL password

$mail->AddReplyTo("nirajkumarok@gmail.com","nirajkumarok@gmail.com");

$mail->From       = "nirajkumarok@gmail.com";
$mail->FromName   = "Prabhat";

$mail->Subject    = "INVITE COMPANIONS";

$mail->Body       = "Hi,<br>This is a message  from User Name________through Vault of Logs.com.
                     User Name_______has requested you to become a companion to his LifeBook at Vault of Logs.com <br>";                      //HTML Body

$mail->WordWrap   = 50; // set word wrap

$mail->AddAddress($cEmail, $cName);

$mail->IsHTML(true); // send as HTML

if(!$mail->Send()) {
  echo "Mailer Error: " . $mail->ErrorInfo;
} else {
  echo "Message sent!";
}

?>
