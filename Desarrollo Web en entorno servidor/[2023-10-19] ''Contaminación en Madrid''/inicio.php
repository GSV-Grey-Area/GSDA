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
		<?php
			echo '<table>';
			$fp = fopen("horario2.csv", "r");
			echo '<tr>';
				echo '<th>Estación</th>';
				echo '<th>Magnitud</th>';
				for ($i = 1; $i < 25; $i++)
				{
					echo '<th>H';
					if ($i < 10)
					{
						echo '0';
					}
					echo $i . '</th>';
				}
			echo '</tr>';
			
			fgetcsv($fp);
			while ($data = fgetcsv($fp, 1000, ";"))
			{
				echo '<tr>';
				
				echo '<td>';
				$fq = fopen("estaciones.csv", "r");
				fgetcsv($fq);
				while ($data2 = fgetcsv($fq, 1000, ";"))
				{
					if ($data[2] == $data2[0])
					{
						echo utf8_encode($data2[1]);
					}
				}
				echo '</td>';
				fclose($fq);
				
				echo '<td>';
				$fr = fopen("magnitudes.csv", "r");
				fgetcsv($fr);
				while ($data3 = fgetcsv($fr, 1000, ";"))
				{
					if ($data[3] == $data3[0])
					{
						echo utf8_encode($data3[1]);
						echo '<span> (' . utf8_encode($data3[2]) . ')</span>';
					}
				}
				echo '</td>';
				fclose($fr);
				
				for ($i = 8; $i < 56; $i = $i + 2)
				{
					echo '<td>';
					if ($data[$i] == 0)
					{
						echo '<span>'.$data[$i].'</span>';
					}
					else
					{
						echo $data[$i];
					}
					echo '</td>';
				}
				
				echo '<tr>';
			}
			fclose($fp);
			echo '</table>';
		?>
	</body>
</html>
