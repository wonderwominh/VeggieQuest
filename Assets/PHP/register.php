<?PHP
    //variable for connection
    $servername = "wonderwominh.com.mysql";
    $server_username = "wonderwominh_com";
    $server_password = "123456";
    $dbName = "wonderwominh_com";
    
    //Variable from the user    
    $username = $_POST['username'];
    $email = $_POST['email'];
    $password = $_POST['password'];
    
    
    //Make connection
    $con = new mysqli($servername,$server_username,$server_password,$dbName);
    //Check connection
    if(!$con) {
    die("Could not connect: ".mysqli_connect_error());
    }
    $check = mysqli_query("SELECT * FROM users WHERE `user`='".$username."'");
    $numrows = mysqli_num_rows($check);
    if($numrows == 0) {
        
        $ins = mysqli_query("INSERT INTO `wonderwominh_com`.`users` (`id`, `username`, `email`, `password`) VALUES ('', '".$username."', '".$email."', '".$password."');");
        if($ins)
            die("Succesffuly created");
        else
            die("Error: " . mysqli_error());
        
    }
    else {
        die("User already exist!");
    }
    $sql = "INSERT INTO users (username,email,password) VALUES ('".$username."','".$email."','".$password."')";
    $result = mysqli_query($conn,$sql);
    
    if(!result)
        echo "there was an error";
    else
        echo "Everything is ok";
    
?>
