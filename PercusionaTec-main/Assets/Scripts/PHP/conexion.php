<?php

// Autores: Jose Luis Madrigal, Cesar Emiliano Palome, Jose Angel Garcia y Erika Marlene
// Codigo para hacer conexion con la BD

try {
    $pdo = new PDO('mysql:host=localhost;dbname=datosjuego', 'root', '');  // WARNING
    echo "Conexion exitosa". "\n";
} catch (PDOException $e) {
    echo "Error, falla al conectarse a la BD";
    echo "Error, " . $e->getMessage();
    die();
}

?>