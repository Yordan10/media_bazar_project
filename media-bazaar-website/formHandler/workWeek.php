<?php
require '../includes/init.php';
$week = $_POST['week'];
$_SESSION['week']=$week;
header('Location: ../html/Schedule.php');
?>