<?php

// Autores: Jose Luis Madrigal, Cesar Emiliano Palome, Jose Angel Garcia y Erika Marlene
// Codigo para obtener datos de forma y mandarlos con un query a la BD (con valor de hora inicio)
include 'conexion.php';
    if ($_POST) {
        $usuario = $_POST["usuario"];
        $nombre = $_POST["nombre"];
        $ciudad = $_POST["ciudad"];
        $mail = $_POST["mail"];
        $contrasena = $_POST["contrasena"];
        $fechaNaci = $_POST["fechaNaci"];
        $nacionalidad = $_POST["nacionalidad"];
        
        $sql_agregar1 = "INSERT INTO `jugador` (`Id_usuario`, `nombre`, `ciudad`, `pais`, `email`, `contraseña`, `fecha_nacimiento`, `pais`) VALUES (?, ?, ?, ?, ?, ?, ?);";
        $sentencia_agregar1 = $pdo->prepare($sql_agregar1);
        $resultado1 = $sentencia_agregar1->execute(array($usuario,$nombre,$ciudad,$mail,$contrasena,$fechaNaci,$nacionalidad));
        if ($resultado1==true) {
            $sentencia_agregar1 = null;
            $pdo = null;
            echo "User: " . $usuario . "\n";
            echo "Name: " . $nombre . "\n";
            echo "City: " . $ciudad . "\n";
            echo "Mail: " . $mail . "\n";
            echo "Password: " . $contrasena . "\n";
            echo "Date of birth: " . $fechaNaci . "\n";
            echo "Nationality: " . $nacionalidad . "\n";
            } else {
            echo "Error al insertar en la BD: ";
            echo $pdo->errorInfo();
            }
            
        
        
    } else {
        echo "No hay método POST";
    }

?>