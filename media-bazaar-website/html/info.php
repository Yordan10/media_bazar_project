
<?php
require_once("..\Classes\Employee.php");
require_once('..\DBConnection\DBConnect.php');
 if(session_id() == '') {session_start();}
$userID = $_SESSION["ID"];
$db = new Database();
if(isset($_GET['route']) && $_GET['route']=="edit")
{
$Address = $_POST['Address'];
$Phone = $_POST['Phone'];
$Email = $_POST['Email'];
$Married=$_POST['Married'];
$Gender=$_POST['Gender'];

$employee=new Employee($userID,"","",$Gender,$Married,$Address,$Phone,"",$Email,"","");
$result=$db->EditEmployee($employee);
$employee= $db->GetEmployee($userID);
header('Location: index.php');
}
else {
  $employee= $db->GetEmployee($userID);
}


















?>
