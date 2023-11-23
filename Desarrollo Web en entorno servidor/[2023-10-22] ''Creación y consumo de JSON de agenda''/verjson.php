<?php
	class Contacto
	{
		public $nombre;
		public $telefono;
	}
	
	$agenda = [];
	
	$c = new Contacto();
  	$c->nombre = "Minombre";
  	$c->telefono = "123456789";
	$agenda[] = $c;
	
	$c = new Contacto();
  	$c->nombre = "Nombremio";
  	$c->telefono = "987654321";
	$agenda[] = $c;
	
	$json = json_encode($agenda);
	echo $json;
?>
