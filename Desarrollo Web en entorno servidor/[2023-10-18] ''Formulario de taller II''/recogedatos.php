<!DOCTYPE html>
<html>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<head>
		<?php
			echo "<style>";
				echo "div";
					echo "{";
						echo "border: 1px solid black;";
						echo "display: inline-block;";
					echo "}";
					
				echo "td, tr, table";
					echo "{";
						echo "border: 1px solid #DDDDDD;";
						echo "border-collapse: collapse;";
						echo "padding: 2px 10px;";
					echo "}";
			echo "</style>";
		?>
	</head>
	<body>
		<?php
			$name = $_POST["name"];
			$plate = $_POST["plate"];
			$phone = $_POST["phone"];
			$email = $_POST["email"];
			$maker = $_POST["maker"];
			$seguro = $_POST["seguro"] ?? null;

			$hora1 = $_POST["hora1"] ?? null;
			$hora2 = $_POST["hora2"] ?? null;
			$hora3 = $_POST["hora3"] ?? null;
			
			echo "<div>";
				echo "<table>";
					echo "<tr>";
						echo "<td>Nombre</td>";
						echo "<td>".$name."</td>";
					echo "</tr>";
					echo "<tr>";
						echo "<td>Matrícula</th>";
						echo "<td>".$plate."</td>";
					echo "</tr>";
					echo "<tr>";
						echo "<td>Número de teléfono</td>";
						echo "<td>".$phone."</td>";
					echo "</tr>";
					echo "<tr>";
						echo "<td>Correo</td>";
						echo "<td>".$email."</td>";
					echo "</tr>";
					echo "<tr>";
						echo "<td>Fabricante</td>";
						echo "<td>";
							$fp = fopen("coches.csv", "r");
							while ($data = fgetcsv($fp, 1000, ","))
							{
								if($data[1] == $maker)
								{
									echo $data[0];
								}
							}
							fclose($fp);
						echo "</td>";
					echo "</tr>";
					echo "<tr>";
						echo "<td>Seguro</td>";
						echo "<td>".$seguro."</td>";
					echo "</tr>";
					echo "<tr>";
						echo "<td>Horas de llamada</td>";
						echo "<td>";
							if (!empty($hora1)){echo $hora1."<br>";}
							if (!empty($hora2)){echo $hora2."<br>";}
							if (!empty($hora3)){echo $hora3."<br>";}
						echo "</td>";
					echo "</tr>";
				echo "</table>";
			echo "</div>";
		?>
	</body>
</html>
