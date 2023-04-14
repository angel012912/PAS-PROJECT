<?php

// Autores: Jose Luis Madrigal, Cesar Emiliano Palome, Jose Angel Garcia y Erika Marlene
// Codigo para obtener datos de forma y mandarlos con un query a la BD (con valor de hora inicio)
include 'conexion.php';
    if ($_POST) {
        $usuario = $_POST["usuario"];
        $contrasena = $_POST["contrasena"];
        // Query para validad datos en la tabla jugador
        //$sql_agregar1 = "INSERT INTO `jugador` (`Id_usuario`, `nombre`, `ciudad`, `pais`, `email`, `contraseña`, `fecha_nacimiento`, `pais`) VALUES (?, ?, ?, ?, ?, ?, ?);";
        $sentencia_agregar1 = $pdo->prepare($sql_agregar1);
        $resultado1 = $sentencia_agregar1->execute(array($usuario,$contrasena));
        if ($resultado1==true) {
            $sentencia_agregar1 = null;
            $pdo = null;
            echo "User: " . $usuario . "\n";
            echo "Password: " . $contrasena . "\n";
            } else {
            echo "Error al insertar en la BD: ";
            echo $pdo->errorInfo();
            }
            
        
        
    } else {
        echo "No hay método POST";
    }

?>