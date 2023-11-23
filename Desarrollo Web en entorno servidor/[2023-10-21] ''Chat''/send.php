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
		<?php
			$username = $_SESSION["username"] ?? NULL;
			$password = $_SESSION["password"] ?? NULL;
			
			if ($username == NULL || $password == NULL)
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
				$date = date("Y-m-d H:i:s");
				$message = $_POST["message"] ?? NULL;
				
				if (isset($message) && $message != NULL)
				{
					$fp = fopen("comentarios.csv", "a");
					$txt = $date . ',' . $username . ',' . $message . PHP_EOL;
					fwrite($fp, $txt);
					fclose($fp);
				}
				$message = NULL;
				
				header("Location: chat.php");
			}
		?>
	</body>
</html>
