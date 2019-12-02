<?php
session_start();
session_unset();
session_destroy();
header("location:webtrading.php");
//header("location:weblogin.php");
exit();
?>