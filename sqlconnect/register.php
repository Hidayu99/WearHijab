<?php 

	$con = mysqli_connect('localhost','root','','test');
	
	if (mysqli_connect_errno())
	{
		echo "1 : Connection failed";
		exit();
	}
	
	$username = $_POST["username"];
	$password = $_POST["password"];
	$name = $_POST["fullname"];
	$address = $_POST["address"];
	$phoneno = $_POST["phone"];
	
	$namecheckquery = "SELECT username FROM userbill WHERE username='" . $username . "';";
	$namecheck = mysqli_query($con, $namecheckquery) or die("2 : Name check query failed");
	
	if(mysqli_num_rows($namecheck) > 0)
	{
		echo "3: Name already exists";
		exit();
	}
	
	$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
	$hash = crypt($password, $salt);
	$insertuserquery = "INSERT INTO userbill (username,name,hash,salt,phoneno,address) VALUES ('" . $username . "','" . $name . "','" . $hash . "','" . $salt . "','" . $phoneno . "','" . $address . "');";
	
	mysqli_query($con, $insertuserquery) or die ("4: Insert user query failed");
	
	echo ("0");
	
?>