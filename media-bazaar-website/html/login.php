<?php
require '../includes/init.php';
?>
<!DOCTYPE html>
<html>
<head>

<link href="../css/StyleSheet.css" rel="StyleSheet" type="text/css"/>
<style>
body  {
  background-image: url("../images/pic.jpg");

}
</style>

</head>
<body>
  <img src="../images/logo.png" class="img-fluid" alt="Responsive image" style="width:210px;height:210px;margin-left:500px">

<div class="Login">
  <form action="User.php" method="POST">
    <label for="username" style="width:100px;">User Name</label>
    <input type="text" class="InputText" id="username" name="username" placeholder="UserName"><br>

    <label for="pwd"  style="width:100px;">Password</label>
  <input type="password" class="InputText" id="pwd" name="pwd" minlength="8"  placeholder="Password"><br><br>



    <input type="submit" value="Login">
  </form>
</div>

</body>
</html>
