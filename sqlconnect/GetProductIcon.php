<?php 

$con = mysqli_connect('localhost','root','','test');

if ($con->connect_error){
	die ("Connection failed: " . $con->connect_error);
}

$productList = $_POST["id"];

$path = "http://localhost/sqlconnect/product/" . $productList . ".png";

$image = file_get_contents($path);

echo $image;

$con->close();

?>