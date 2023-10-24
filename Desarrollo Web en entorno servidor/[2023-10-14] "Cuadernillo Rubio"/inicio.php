<!DOCTYPE html>
<html>
	<head>
		  <meta name="viewport" content="width=device-width, initial-scale=1.0">

		<style>
			input, select, button
			{
				width: 50px;
				margin: 2px;
				box-sizing: border-box;
			}
			
			form
			{
				width: 100%;
				margin: auto;
				text-align: left;
			}
			
			input[type="radio"], input[type="checkbox"], label
			{
				width: 13px;
				margin-right: 0;
			}
		</style>
	</head>
	<body>
		<div>
			<form action="recogedatos.php" method="POST">
				<?php
					echo '<input type="number" id="num1" name="num1" value="';
					echo rand(0, 100);
					echo '" readonly="readonly">';
					
					echo '<input type="number" id="num2" name="num2" value="';
					echo rand(0, 100);
					echo '" readonly="readonly">';
				?>
				=
				<input type="number" id="num3" name="num3">
				
				<input type="submit" value="Enviar"></input>
			</form>
		</div>
	</body>
</html>
