<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8"/>
		<style>
			table, tr, td, th
			{
				border: 1px solid black;
				border-collapse: collapse;
			}
			
			span
			{
				color: #CCCCCC;
			}
		</style>
	</head>
	<body>
		<h1>Accidentes de bicicleta</h1>
		<?php
			echo '<table>';
			$fp = fopen("AccidentesBicicletas_2023.csv", "r");
			echo '<tr>';
				echo '<th>Fecha</th>';
				echo '<th>Lesividad</th>';
				echo '<th>Tipo de vehículo</th>';
			echo '</tr>';
			
			fgetcsv($fp);
			while ($data = fgetcsv($fp, 1000, ";"))
			{
				echo '<tr>';
					echo '<td>' . $data[1] . '</td>';
					if ($data[14] == "NULL")
					{
						echo '<td><span>Ninguna</span></td>';
					}
					else
					{
						echo '<td>' . utf8_encode(utf8_decode($data[14])) . '</td>';
					}
					echo '<td>' . utf8_encode($data[9]) . '</td>';
				echo '<tr>';
			}
			fclose($fp);
			echo '</table>';
		?>
	</body>
</html>
