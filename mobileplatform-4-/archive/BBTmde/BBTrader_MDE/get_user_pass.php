<?php
session_start();

$username3 = $_POST['var102'];
$password3 = $_POST['var103'];

	
echo $_SESSION['user3']=$username3;
echo $_SESSION['pass3']=$password3;
session_destroy();
?>