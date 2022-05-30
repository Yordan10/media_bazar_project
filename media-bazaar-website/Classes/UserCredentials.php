<?php

class User{

  private $username;
  private $password;

  public function __construct($Username,$Password){

    $this->username=$Username;
    $this->password=$Password;
  }

  public function getUserName(){
    return $this->username;
  }

  public function getPassword(){
    return $this->password;
  }
}


?>
