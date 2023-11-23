<?php
	session_start();
?>
<!DOCTYPE html>
<html>
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link rel="stylesheet" href="styles2.css">
	</head>
	<body>
		<?php
			$username = $_SESSION["username"] ?? NULL;
			$password = $_SESSION["password"] ?? NULL;
			
			if ($username == null || $password == null)
			{
				echo '<div class="Center">';
				echo '<p>Forma de acceso incorrecta.</p>';
				echo '<form action="./index.php">';
					echo '<input type="submit" value="Vale"></input>';
				echo '</form>';
				echo '</div>';
			}
			else
			{
				echo '<div class="Right">';
					echo '<form action="./logout.php" method="POST">';
						echo '<label for="close"><b>' . $username . ' </b></label>';
						echo '<input type="submit" id="close" value="Cerrar sesión">';
					echo '</form>';
				echo '</div>';
				
				echo '<h2>Chat</h2>';
				
				echo '<div>';
				$fq = fopen("comentarios.csv", "r");
				while ($data = fgetcsv($fq, 1000, ","))
				{
					echo '<div>';
						echo '<p>';
							echo '<span>';
							echo '[';
							echo utf8_decode(utf8_encode($data[0]));
							echo ']';
							echo '</span>';
							echo ' ';
							echo utf8_decode(utf8_encode($data[1]));
							echo ':';
							echo ' ';
						echo '</p>';
					echo '</div>';
					echo '<div>';
						echo '<p>';
							echo utf8_decode(utf8_encode($data[2]));
						echo '</p>';
					echo '</div>';
					echo '<br>';
				}
				fclose($fq);
				echo '</div>';
				
				echo '<div>';
					echo '<form action="./send.php" method="POST">';
						echo '<input type="text" id="message" name="message" required>';
						echo '<input type="submit" class="Send" value="Enviar">';
					echo '</form>';
				echo '</div>';
			}
		?>
	</body>
</html>
