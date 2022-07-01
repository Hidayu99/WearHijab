<?php 

	$con = mysqli_connect('localhost','root','','test');
	
	if (mysqli_connect_errno())
	{
		echo "1 : Connection failed";
		exit();
	}
	
	$username = $_POST["username"];
	$password = $_POST["password"];
	
	
	$namecheckquery = "SELECT username,salt,hash,name FROM userbill WHERE username='" . $username . "';";
	$namecheck = mysqli_query($con, $namecheckquery) or die("2 : Name check query failed");
	
	if(mysqli_num_rows($namecheck) != 1)
	{
		echo " Please register first";
		exit();
	}
	
	$existinginfo = mysqli_fetch_assoc($namecheck);
	$salt = $existinginfo["salt"];
	$hash = $existinginfo["hash"];

	$loginhash = crypt($password, $salt);
	if ($hash != $loginhash)
	{
		echo "6: Incorrect password";
		exit();
	}

	$con->close();
	
?>