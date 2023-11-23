<?php
	session_start();
	echo '<!DOCTYPE html>';
	echo '<html>';
		echo '<head>';
			echo '<meta name="viewport" content="width=device-width, initial-scale=1.0">';
			echo '<link rel="stylesheet" href="styles.css">';
		echo '</head>';
		echo '<body>';
			echo '<div class="Center">';
				$username = $_POST['username'] ?? NULL;
				$password = $_POST['password'] ?? NULL;
				
				$_SESSION["username"] = $username;
				$_SESSION["password"] = $password;
				
				$check = false;
				
				$fq = fopen("usuarios.csv", "r");
				fgetcsv($fq);
				while (($line = fgetcsv($fq)) !== FALSE)
				{
					// If the username is found:
					if ($line[0] === $username)
					{
						$check = true;		
						
						// If password correct:
						if ($line[1] === $password)
						{
							echo '<span><p>Contraseña correcta.</p></span>';
							echo '<form action="./chat.php">';
						}
						else
						{
							echo '<span><p>Contraseña incorrecta.</p></span>';
							echo '<form action="./index.php">';	
						}
					}
				}
				fclose($fq);
				
				// If the username is not found:
				if ($check === false)
				{
					include('input.php');
					echo '<span><p>Datos no encontrados en el registro.</p></span>';
					echo '<span><p>Usuario creado.</p></span>';
					echo '<form action="./index.php">';
				}
					echo '<span><input type="submit" value="Vale"></span>';
				echo '</form>';
			echo '</div>';
		echo '</body>';
	echo '</html>';
?>
