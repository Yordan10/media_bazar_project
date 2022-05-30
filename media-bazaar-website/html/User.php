<?php
require_once("..\DBConnection\DBConnect.php");
require_once("..\Classes\UserCredentials.php");
require '../includes/init.php';

$db = new Database();


$Username = $_POST['username'];
$Password = $_POST['pwd'];
$user= new User($Username,$Password);
$result=$db->Login($user);

if($result!=null)
{
  $_SESSION["ID"]=$result;
  header('Location: index.php');
}
else {
  echo 'failed Login';
}
?>
