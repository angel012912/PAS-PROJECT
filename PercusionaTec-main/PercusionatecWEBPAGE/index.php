<?php
error_reporting(1);
$usuario = $_POST["user"];
$contra = $_POST["contra"];

$us_correct = "PAS";
$contra_correct = "admin";

$alerta;

if(isset($usuario)){
    if($usuario == $us_correct && $contra == $contra_correct){
        echo '<script type="text/javascript">
        setTimeout( function() { window.location.href = "http://localhost/PERCUSIONATEC/dashboard.html"; }, 1000 )
    </script>';
    }else{
        $alerta = '<svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
        <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
            <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
        </symbol>
    </svg>
    <div class="alert alert-danger alert-dismissible d-flex align-items-center mb-0" style = "height: 50px;"role="alert">
        <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Danger:"><use xlink:href="#exclamation-triangle-fill"/></svg>
        <div>
            ERROR - Incorrect username or password
        </div>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>';
    }
}

?>
<!doctype html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors">
    <meta name="generator" content="Jekyll v4.0.1">
    <title>PERCUSIONATEC</title>

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" rel="stylesheet">
<!-- Bootstrap v5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>

    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        
        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
    <!-- Custom styles for this template -->
    <link href="cover.css" rel="stylesheet">
</head>

<body class="text-center">
    <div class="cover-container d-flex w-100 h-100 p-3 mx-auto flex-column">
        <header class="masthead mb-auto">
            <div class="inner">
                <h3 class="masthead-brand"><a href="index.php">PERCUSIONATEC</a></h3>
            </div>
           
        </header>

        <div class="card" style="width: 20%; height: 350px; position: absolute; left: 100px; top: 200px;">
            <div class="card-header" style="color: black;">
                Log-In
            </div>
            <?php echo $alerta;?>

            <div class="card-body">
                <form action="index.php" method="post">
                    <div class="mb-1" style="color: black;">
                        <label for="exampleInputEmail1" class="form-label">Email address</label>
                        <input type="text" class="form-control" name="user" required>
                    </div>
                    <div class="mb-3" style="color: black;">
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1" name="contra" required>
                    </div>
                    <button type="submit" class="btn btn-outline-primary">Log-In</button>
                </form>
            </div>
        </div>

        <footer class="mastfoot mt-auto">
            <div class="inner">
                <p>
                </p>
            </div>
        </footer>
    </div>
</body>

</html>