<!DOCTYPE html>
<html>
	<head>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">

		<style>
			form
			{
				margin: auto;
				text-align: left;
			}
			
			input, select, button
			{
				width: 50px;
				margin: 2px;
				padding: 0px;
				box-sizing: border-box;
			}
			
			select
			{
				width: 30px;
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
			<form action="recogedatos.php" method="POST" autocomplete="off">
				<?php
					$num1a = $_POST["num1"] ?? null;
					$num2a = $_POST["num2"] ?? null;
					$sign = $_POST["sign"] ?? null;
					
					$signs = array("+", "-", "·", "/", "^", "V");
					$shown = array("+", "-", "·", "/", "^", "&#x2713;");

					if(isset($num1a) && isset($sign) && isset($num2a))
					{
						$ope = $sign;
						$firstNumber = $num1a;
						$secondNumber = $num2a;
					}
					else
					{
						$ope = rand(0, 5);
						$min1 = 0;
						$min2 = 0;
						$max1 = 100;
						$max2 = 100;
						switch($ope)
						{
							case 2:
								$max1 = 25;
								$max2 = 25;
								break;
								
							case 3:
								$max1 = 25;
								$min2 = 1;
								$max2 = 25;
								break;
								
							case 4:
								$max1 = 10;
								$max2 = 5;
								break;
							
							case 5:
								$min1 = 1;
								$max1 = 3;
								break;
						}
						
						$firstNumber = rand($min1, $max1);
						$secondNumber = rand($min2, $max2);
					}
				
					echo '<input type="number" id="num1" name="num1" value="';
					echo $firstNumber;
					echo '" readonly="readonly">';
					
					echo '<select name="sign" id="sign">';
					for ($i = 0; $i < count($signs); $i++)
					{
						echo '<option value="' . $i . '"';
						if ($ope == $i)
						{
							echo ' selected';
						}
						echo '>' . $shown[$i] . '</option>';
						echo $i;
					}
					echo '</select>';
					
					echo '<input type="number" id="num2" name="num2" value="';
					echo $secondNumber;
					echo '" readonly="readonly">';
				?>
				=
				<input type="number" id="num3" name="num3">
				<input type="submit" value="Enviar"></input>
			</form>
		</div>
	</body>
</html>
