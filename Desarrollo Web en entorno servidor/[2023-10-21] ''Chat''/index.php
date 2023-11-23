<?php
	session_start();
?>
<!DOCTYPE html>
<html>
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link rel="stylesheet" href="styles.css">
	</head>
	<body>
		<div>
			<h2>Registro</h2>
			<form class="FormAt" action="usercheck.php" method="POST" autocomplete="off">
				<label for="username">Nombre: </label>
				<input type="text" id="username" name="username" placeholder="Nombre..." required>
        <br>
				
				<label for="password">Contraseña: </label>
				<input type="password" id="password" name="password" placeholder="Contraseña..." required>
				<br>
				
				<input type="submit" value="Registro">
			</form>
		</div>
	</body>
</html>
