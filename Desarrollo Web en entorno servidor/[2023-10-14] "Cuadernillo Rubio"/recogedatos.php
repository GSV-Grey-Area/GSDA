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
						
			$num4 = $num1 + $num2;
			
			echo "</p>El resultado es ".$num4.". ";
			if ($num4 != $num3)
			{
				echo "<span class='red'>Has calculado mal.</span></p>";
				echo "<form action='inicio.php' method='POST'></form>";
			}
			else if ($num4 = $num3)
			{
				echo "<span class='green'>Has calculado bien.</span></p>";
			}
			else
			{
				echo "<p>Algo ha ido mal.</p>";
			}
		?>
	</body>
</html>
