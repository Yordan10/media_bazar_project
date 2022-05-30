<?php
require '../includes/init.php';
include("../html/info.php");

?>
<html>
<head>
<link href="../css/StyleSheet.css" rel="styleSheet" type="text/css"/>
<style>
body  {
  background-image: url("../images/pic.jpg");

}
</style>

</head>
<body>



  <img src="../images/logo.png" class="img-fluid" alt="Responsive image" style="width:210px;height:210px;margin-left:500px">

  <div class="topnav" style="margin-top:20px;">
    <a href="index.php">Home</a>
    <a href="Schedule.php">Schedule</a>
    <a href="logout.php">Logout</a>
  </div>

  <div class="container" style="padding-left:70px;" >
<form class="" action="info.php?route=edit" method="POST">
    <label   for="Employee ID">ID: </label>
    <input  type="text" class="InputText" name="Employee ID" id="id" value="<?php echo $userID ?>" disabled ><br>
    <label   for="Name">Name: </label>
    <input  type="text" class="InputText" name="Name" id="name" value="<?php echo $employee->getFirstName()?>"  ><br>
    <label  for="DateofBirth">DateofBirth: </label>
    <input  type="text" class="InputText" name="DateofBirth" id="dateofBirth" value="<?php echo $employee->getbirthdate()?>" disabled><br>
    <label  for="Gender">Gender: </label>
    <input  type="text" class="InputText" name="Gender" id="gender" value="<?php echo $employee->getGender()?>" ><br>


    <label  for="Married">Married: </label>
    <input  type="text" class="InputText" name="Married" id="married" value="<?php echo $employee->getIsMarried()?>" ><br>



    <label  for="Address">Address:</label>
    <input  type="text" class="InputText" name="Address" id="address" value="<?php echo $employee->getAddress()?>"><br>
    <label  for="Phone">Phone:</label>
    <input  type="text" class="InputText" name="Phone" id="phone" value="<?php echo $employee->getPhone()?>"><br>

    <label  for="BSN">BSN:</label>
    <input  type="text" class="InputText" name="BSN" id="BSN" value="<?php echo $employee->getBSN()?>" disabled><br>

    <label  for="Email">Email:</label>
    <input  type="text" class="InputText" name="Email" id="email" value="<?php echo $employee->getEmail()?>"><br>
    <label  for="Role">Role:</label>
    <input  type="text" class="InputText" name="Role" id="role" value="<?php echo $employee->getRole()?>" disabled ><br>
    <label  for="Salary">Salary:</label>
    <input  type="text" class="InputText" name="Salary" id="salary" value="<?php echo $employee->getSalary()?>" disabled><br>
    <input  type="submit" value="Edit">
</form>
  </div>


</body>
</html>
