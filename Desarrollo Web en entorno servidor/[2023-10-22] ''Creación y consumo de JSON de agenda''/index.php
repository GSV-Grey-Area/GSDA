<!DOCTYPE html>
<html>
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
	</head>
	<body>
		<h3>Agenda</h3>
		<?php
			//$url = "192.168.4.215/Servidor/verjson.php";
      $url = "localhost/verjson.php";

			$curl = curl_init($url);
			curl_setopt($curl, CURLOPT_RETURNTRANSFER, TRUE);
			$json = curl_exec($curl);
			curl_close($curl);

			$objeto_json=json_decode($json);
			for ($i = 0; $i<count($objeto_json); $i++)
			{
				echo $objeto_json[$i]->nombre;
				echo "<br>";
				echo $objeto_json[$i]->telefono;
				echo "<br>";
				echo "<br>";
			}
		?>
	</body>
</html>
