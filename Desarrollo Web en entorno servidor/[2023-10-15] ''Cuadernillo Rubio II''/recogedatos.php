<!DOCTYPE html>
<html>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<head>
		<?php
			echo "<style>";
				echo ".red";
				echo "{";
					echo "color: red;";
				echo "}";
				
				echo ".green";
				echo "{";
					echo "color: green;";
				echo "}";
			echo "</style>";
		?>
	</head>
	<body>
		<?php
			$num1 = $_POST["num1"];
			$num2 = $_POST["num2"];
			$num3 = $_POST["num3"];
			$sign = $_POST["sign"];
			
			switch($sign)
			{
				case "0":
					$num4 = $num1 + $num2;
					break;
				
				case "1":
					$num4 = $num1 - $num2;
					break;
				
				case "2":
					$num4 = $num1 * $num2;
					break;
				
				case "3":
					$num4 = (int)round($num1 / $num2);
					break;
					
				case "4":
					$num4 = (int)round(pow($num1, $num2));
					break;
					
				case "5":
					$num4 = (int)round(pow($num2, 1/$num1));
					break;
			}
			
			echo "</p>El resultado es ".$num4.". ";
			if ($num4 != $num3)
			{
				echo "<span class='red'>Has calculado mal.</span></p>";
				echo '<form action="inicio.php" method="POST">';
					echo '<input type="hidden" name="num1" value="' . $num1 . '">';
					echo '<input type="hidden" name="sign" value="' . $sign . '">';
					echo '<input type="hidden" name="num2" value="' . $num2 . '">';
					echo '<button type="submit" name="button" ">Volver a intentar</button>';
				echo "</form>";
			}
			else if ($num4 == $num3)
			{
				echo "<span class='green'>Has calculado bien.</span></p>";
				echo '<form action="inicio.php" method="POST">';
					echo '<button type="submit" name="button">Otra más</button>';
				echo "</form>";
			}
			else
			{
				echo "<p>Algo ha fallado.</p>";
			}
		?>
	</body>
</html>
