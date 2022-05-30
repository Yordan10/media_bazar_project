<?php
require '../includes/init.php';
require '../DBConnection/DBConnect.php';

?>


<!DOCTYPE html>
<html>

<head>

  <link href="../css/StyleSheet.css" rel="StyleSheet" type="text/css" />
  <style>
    body {
      background-image: url("../images/pic.jpg");

    }
  </style>

</head>

<body>

  <img src="../images/logo.png" class="img-fluid" alt="Responsive image" style="width:210px;height:210px;margin-left:500px">



  <div class="topnav" style="margin-top:15px;">
    <a href="index.php">Home</a>
    <a href="Schedule.php">Schedule</a>
    <a href="logout.php">Logout</a><br>

  </div>
  <div id="schedule_week">
    <form action="../formHandler/workWeek.php" method="POST">
      <label class="schedule_label">Choose week:</label>
      <select class="custom-select" id="week" name="week" size="1">
        <?php
        $db = new Database();
        $weeks = $db->GetAllWorkWeeks();
        foreach ($weeks as $weeks_key => $weeks_value) {
          echo  '<option value="';
          echo $weeks_value['ID'];
          echo '">Year : ';
          echo $weeks_value['Year'];
          echo ' Week : ';
          echo $weeks_value['Week'];
          echo '</option>';
        }
        ?>

      </select>
      <br><br>
      <input type="submit" value="Choose">

      <label class="schedule_label">Working hours for this week:
       <?php
       if(!isset($_SESSION['week']))
       {
        $workingHours= $db->GetWorkingHoursPerWeek($_SESSION['ID'],1);
       }
       else
       {
        $workingHours= $db->GetWorkingHoursPerWeek($_SESSION['ID'],$_SESSION['week']);
       }

        echo $workingHours;
       ?>

        </label>

  </div>

  </form>
  <div id="shift_table">
    <?php

    echo '<br></br>';
    echo '<table class="styled-table">';
    echo '<thead>';
    echo '<tr>';
    echo '<th>Username</th>';
    echo '<th>Day</th>';
    echo '<th>Date</th>';
    echo '<th>Month</th>';
    echo '<th>Department</th>';
    echo '<th>Shift Type</th>';
    echo '</tr>';
    echo '</thead>';

    $employee_id = $_SESSION['ID'];
    if(!isset($_SESSION['week']))
    {
      $shifts = $db->GetShiftEmployee($employee_id,1); 
    }
    else
    {
      $shifts = $db->GetShiftEmployee($employee_id, $_SESSION['week']); 
    }
   // $shifts = $db->GetShiftEmployee($employee_id, $_SESSION['week']); 
    echo '<tbody>';
    foreach ($shifts as $shift_key => $shift_value) {
      echo '<tr>';
      echo '<td>';
      echo $shift_value['Username'];
      echo '</td>';

      echo '<td>';
      echo $shift_value['Day'];
      echo '</td>';

      echo '<td>';
      echo $shift_value['Date'];
      echo '</td>';

      echo '<td>';
      echo $shift_value['Month'];
      echo '</td>';

      echo '<td>';
      echo $shift_value['Department'];
      echo '</td>';

      echo '<td>';
      echo $shift_value['Shift type'];
      echo '</td>';

      echo '</tr>';
    }
    echo '</tbody>';
    echo '</table>';
    $weeks = $db->GetAllWorkWeeks();
    //var_dump($weeks);


    ?>
  </div>

</body>

</html>
