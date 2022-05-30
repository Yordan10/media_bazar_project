<?php
session_start();

spl_autoload_register(function ($className) { 
    // Replace <path_to_classes> with the actual path
	$path = sprintf( dirname(__FILE__) .'/../Classes/%s.php', $className); 
	if (file_exists($path)) { 
		include $path; 
	} 
}); 
?>