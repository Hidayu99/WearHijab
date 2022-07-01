<?php 

$con = mysqli_connect('localhost','root','','test');

if ($con->connect_error){
	die ("Connection failed: " . $con->connect_error);
}

$productList = $_POST["id"];

$sql = "SELECT name,description,price FROM product WHERE id = '". $productList ."'";

$result = $con->query($sql);

if ($result->num_rows > 0)
{
	$rows = array();
	while($row = $result->fetch_assoc()){
		$rows[] = $row;
	}

	echo json_encode($rows);
	} else {
		echo "0";
	}

	$con->close();
}
?>