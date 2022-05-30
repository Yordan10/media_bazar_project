<?php

class Database {
	private $username = 'dbi450024';
	private $password = ',marwa004';
	private $host = 'studmysql01.fhict.local';
	private $dbName = 'dbi450024';
	private $conn;

	public function __construct() {
		$this->conn = new PDO("mysql:host=$this->host;dbname=$this->dbName", $this->username, $this->password);
		$this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}

	public function __destruct() {
		$this->conn = null;
	}


public function Login(User $User){
try {
	$sql = 'SELECT ID From dbi450024.employee WHERE UserName=:UserName AND Password=:Password';
	$sth = $this->conn->prepare($sql);
	$sth->execute([
	':UserName'=>$User->getUserName(),
	':Password' =>$User->getPassword()]);
	$row = $sth->fetch();
	if(!$row)
		{
			return null;

		}
		return $row['ID'];
}
	catch (PDOException $e) {
		echo "Connection failed: " . $e->getMessage();
	}
}



public function GetEmployee(int $employeeid ){

try {
	$sql = 'SELECT Emp.ID As ID,FirstName,BirthDate,IF(Gender=1,"Male","Female") As Gender,IF(IsMarried=1,"Yes","No") As Married,Address,PhoneNumber,BSN,Email,role.Name As Role,Salary
	FROM dbi450024.employee As Emp INNER JOIN dbi450024.employee_position As role ON Emp.PositionID=role.ID
	 WHERE Emp.ID=:ID';
	$sth = $this->conn->prepare($sql);
	$sth->execute([':ID' => $employeeid]);
	$row = $sth->fetch();
	if(!$row)
		{
			return null;
		}
		$employee = new Employee( $row['ID'],$row['FirstName'], $row['BirthDate'],$row['Gender'],$row['Married'],$row['Address'],$row['PhoneNumber'],$row['BSN'],$row['Email'],$row['Role'],$row['Salary']);
    return $employee;
}
catch (PDOException $e) {
	echo "Connection failed: " . $e->getMessage();
}

}

public function EditEmployee(Employee $employee)
	{
		try
		{
		$sql = "UPDATE `dbi450024`.`employee`
		        SET `Address`=:address,`PhoneNumber`=:phone,
						     `Email`=:email,`IsMarried`=:married,`Gender`=:gender
						WHERE `ID`=:ID";
		$sth = $this->conn->prepare($sql);
		$result=$sth->execute([

		':gender'=>$employee->getgen(),
    ':married'=>$employee->getMarried(),
		':address'=>$employee->getAddress(),
		':phone' => $employee->getPhone(),
		':email' => $employee->getEmail(),
	  ':ID' => $employee->getID()]);
		echo 'edit';
		echo $result;
		return $result;
		}
		catch(PDOException $e) {
		echo "Connection failed: " . $e->getMessage();
		}
	}

	public function GetShiftEmployee(int $employeeid , int $week)
	{

	  try {

		  $result = [];
		  if($week ==null)
		  {
			$sql = 'SELECT a.UserName as Username,f.name AS Day,e.day_of_month as Date,g.name as Month, d.name  AS Department, h.name as \'Shift type\' FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND employee_id = :ID order by e.month_id , e.day_of_Month asc';
		  }
		  else
		  {
			$sql = 'SELECT a.UserName as Username,f.name AS Day,e.day_of_month as Date,g.name as Month, d.name  AS Department, h.name as \'Shift type\' FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND employee_id = :ID AND e.work_week_id = :week order by e.month_id , e.day_of_Month asc';
		  }
		  $sth = $this->conn->prepare($sql);
		  $sth->execute([':ID' => $employeeid,
		  ':week'=>$week]);
		  $resultSet= $sth->fetchAll();
		  if( $sth->rowCount() > 0 )
		  {

			  foreach($resultSet as $row_key => $row_value)
			  {
				  array_push($result, $row_value);
			  }

		  }
		  return $result;
		}
		catch (PDOException $e) {
			echo "Connection failed: " . $e->getMessage();
		}
   }

   public function GetAllWorkWeeks()
	{
	  try {

		  $result = [];
		  $sql = 'SELECT ID ,year AS Year, week AS Week FROM work_week ORDER BY year, week';
		  $sth = $this->conn->prepare($sql);
		  $sth->execute([]);
		  $resultSet= $sth->fetchAll();
		  if( $sth->rowCount() > 0 )
		  {

			  foreach($resultSet as $row_key => $row_value)
			  {
				  array_push($result, $row_value);
			  }

		  }
		  return $result;
		}
		catch (PDOException $e) {
			echo "Connection failed: " . $e->getMessage();
		}
   }
   

   public function GetWorkingHoursPerWeek(int $employeeid , int $week)
	{

	  try {
		 
		  $result = 0;
		  if($week ==null)
		  {
			return -1;
		  }
		  else
		  {
			$sql = 'SELECT COUNT(*) * 8 As Hours FROM employee a, shift b, schedule c , department d , work_day e, day_of_week f , month g , shift_type h WHERE a.ID = b.employee_id AND b.schedule_id = c.ID and d.ID=c.department_id and c.day_id = e.ID and f.id=e.day_of_week_id and g.ID=e.month_id and h.id=c.shift_type_id AND employee_id = :ID AND e.work_week_id = :week ';
		  }
		  $sth = $this->conn->prepare($sql);
		  $sth->execute([':ID' => $employeeid,
		  ':week'=>$week]);
          
		  $row = $sth->fetch();
        	if(!$row)
		{
			return -2;
			
		}
		$result= $row['Hours'];

		  return $result;
		}
		catch (PDOException $e) {
			echo "Connection failed: " . $e->getMessage();
		}
   }

  
}
