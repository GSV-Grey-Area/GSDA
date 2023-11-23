<?php
	$username = $_POST['username'] ?? null;
	$password = $_POST['password'] ?? null;
	$data = array($username, $password);
	
	$fq = fopen('usuarios.csv', 'a');
	fputcsv($fq, array_values($data));
	fclose($fq);
?>
