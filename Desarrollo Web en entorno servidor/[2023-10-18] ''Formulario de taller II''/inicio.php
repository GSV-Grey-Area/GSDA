<!DOCTYPE html>
<html>
	<head>
		  <meta name="viewport" content="width=device-width, initial-scale=1.0">

		<style>
			input, select
			{
				width: 150px;
				margin: 2px;
				box-sizing: border-box;
			}
			
			form
			{
				width: 60%;
				margin: auto;
				text-align: right;
			}
			
			input[type="radio"], input[type="checkbox"], label
			{
				width: 13px;
				margin-right: 0;
			}
			
			.container
			{
				display: inline-block;
			}
			
			.left
			{
				width: 20%;
			}
			
			.right
			{
				text-align: left;
				width: 80%;
				align: right;
			}
		</style>
	</head>
	<body>
		<div>
			<form action="recogedatos.php" method="POST">
				<label for="name">Nombre: </label>
				<input type="text" id="name" name="name" placeholder="Nombre..." required><br>
				
				<label for="plate">Matr&iacutecula: </label>
				<input type="text" id="plate" name="plate" pattern="[0-9]{4}[A-Za-z]{3}" placeholder="1234ABC" required><br>
				
				<label for="phone">Tel&eacutefono: </label>
				<input type="tel" id="phone" name="phone" pattern="[0-9]{9}" placeholder="123456789" required><br>
				
				<label for="email">Correo: </label>
				<input type="email" id="email" name="email" placeholder="dirección@correo.tal" required><br>
				
				<label for="maker">Marca: </label>
				<?php
					echo '<select name="maker" id="maker">';
						$fp = fopen("coches.csv", "r");
						while ($data = fgetcsv($fp, 1000, ","))
						{
							echo '<option value="' . $data[1] . '">';
							echo $data[0];
							echo '</option>';
						}
						fclose($fp);
					echo '</select><br>';
				?>
				
				<div class="container">
					<div class="left">
					</div>
					<div class="right">
					<input type="radio" id="yes" name="seguro" value="Usa seguro" required>
					<label for="yes">Usa seguro</label><br>
					<input type="radio" id="no" name="seguro" value="No usa seguro" required>
					<label for="no">No usa seguro</label><br>
					
					<input type="checkbox" id="hora1" name="hora1" value="Mañana">
					<label for="hora1">Ma&ntildeana</label><br>
					<input type="checkbox" id="hora2" name="hora2" value="Tarde">
					<label for="hora2">Tarde</label><br>
					<input type="checkbox" id="hora3" name="hora3" value="Noche">
					<label for="hora3">Noche</label></br>
					<input type="submit" value="Enviar">
					</div>
				</div>
			</form>
		</div>
	</body>
</html>
