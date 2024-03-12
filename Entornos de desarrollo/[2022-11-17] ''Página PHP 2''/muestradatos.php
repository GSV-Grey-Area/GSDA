<!DOCTYPE html>
<html>
	<head>
		<title>Muestradatos</title>
	</head>
	<body>
		<?php
			$nombre=$_POST["nombre_del_usuario"];
			$apellido=$_POST["apellido_del_usuario"];
			echo "Hola, $nombre $apellido";
		?>
	</body>
</html>
