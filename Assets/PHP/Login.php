<?PHP
    //variable for connection
    $servername = "wonderwominh.com.mysql";
    $server_username = "wonderwominh_com";
    $server_password = "abc123";
    $dbName = "wonderwominh_com";
    
    //Variable from the user    
    $username = $_POST['username'];
    $password = $_POST['password'];
    
    
    //Make connection
    $con = mysqli_connect($servername,$server_username,$server_password,$dbName);
    //Check connection
    if(!$con) {
    die("Could not connect: ".mysqli_connect_error());
    }
    //else echo("Connection Success");
    
    $sql = "SELECT password FROM users WHERE username = '".$username."' " ;
    $result = mysqli_query($conn,$sql);
    
    if(mysqli_num_rows($result> 0) {
       //show data for each row
       while ($row = mysqli_fetch_assoc($result)) {
            if($row['password'] == $password) {
                echo "Login success!";
            }
            else {
                echo "Password incorrect!";
            }
        }
       else {
       echo "user not found";
       }
}
    
?>
