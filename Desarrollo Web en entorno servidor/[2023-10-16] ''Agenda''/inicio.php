<!DOCTYPE html>
<html>
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">

		<style>
			form
			{
				margin: auto;
				text-align: right;
				width: 80%;
			}
			
			input, select, button
			{
				width: 150px;
				margin: 2px;
				padding: 0px;
				box-sizing: border-box;
			}
			
			table, tr, td, th
			{
				border: 1px solid black;
				border-collapse: collapse;
			}
			
			td, th
			{
				width: 150px;
			}
			
		</style>
	</head>
	<body>
		<h2>Contactos</h2>
		<?php
			$nombre = $_POST["nombre"] ?? null;
			$apellido = $_POST["apellido"] ?? null;
			$telefono = $_POST["telefono"] ?? null;
			if
			(
				isset($nombre) && $nombre != null &&
				isset($apellido) && $apellido != null &&
				isset($telefono) && $telefono != null
			)
			{
				$fp = fopen("csv.csv", "a");
				$txt = $nombre . ',' . $apellido . ',' . $telefono . PHP_EOL;
				fwrite($fp, $txt);
				fclose($fp);
			}
			$nombre = null;
			$apellido = null;
			$telefono = null;
		
			echo '<table>';
			$fp = fopen("csv.csv", "r");
			echo '<tr><th>Nombre</th><th>Apellido</th><th>Número de teléfono</th></tr>';
			while ($data = fgetcsv($fp, 1000, ","))
			{
				echo '<tr>';
				$num = count($data);
				print "";
				echo '<td>'.$data[0].'</td><td>'.$data[1] . '</td><td>' .$data[2] . '</td>';
				echo '<tr>';
			}
			fclose($fp);
			echo '</table>';
		?>
		<br>
		<form action="inicio.php" method="POST" autocomplete="off">
			<label for="nombre">Nombre:</label>
			<input type="text" id="nombre" name="nombre" placeholder="Nombre...">
			<br>
				
			<label for="apellido">Apellido:</label>
			<input type="text" id="apellido" name="apellido" placeholder="Apellido...">
			<br>
				
			<label for="telefono">Número de teléfono:</label>
			<input type="tel" id="telefono" name="telefono" placeholder="123456789" pattern="[0-9]{9}">
			<br>
			
			<button type="submit" name="button">Añadir nuevo contacto</button>
		</form>
	</body>
</html>
