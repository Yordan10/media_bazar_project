<?php

class Employee{

private $Id;
private $firstname;
private $birthdate;
private $gender;
private $married;
private $address;
private $phone;
private $BSN;
private $email;
private $role;
private $salary;


public function __construct($id,$firstname,$birthdate,$gender,$married,$address,$phone,$BSN,$email,$role,$salary){
 $this->Id=$id;
 $this->firstname=$firstname;
 $this->birthdate=$birthdate;
 $this->gender=$gender;
 $this->married=$married;
 $this->address=$address;
 $this->phone=$phone;
 $this->BSN=$BSN;
 $this->email=$email;
 $this->role=$role;
 $this->salary=$salary;

}

public function getFirstName(){
  return $this->firstname;
}

public function getbirthdate(){
  return $this->birthdate;
}

public function getGender(){
  return $this->gender;
}


public function getIsMarried(){
  return $this->married;
}


public function getMarried(){
  if($this->married=='Yes')
    return 1;
  else {
    return 0;
  }
}

public function getgen(){
  if($this->gender=='Male')
    return 1;
  else {
    return 0;
  }
}


public function getAddress(){
  return $this->address;
}

public function getPhone(){
  return $this->phone;
}

public function getBSN(){
  return $this->BSN;
}


public function getEmail(){
  return $this->email;
}

public function getRole(){
  return $this->role;
}

public function getSalary(){
  return $this->salary;
}



public function getID(){
  return $this->Id;
}
public function setID(int $id){
  $this->Id=$id;
}

}

?>
