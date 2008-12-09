<?php
	include("config.php");
	include("functions.php");
	@ $connect = mysql_connect($server, $username, $password);
	if (!$connect)
	{
		echo mysql_error();
		die;
	}
	if (!mysql_select_db($database_name))
	{
		echo mysql_error();
		mysql_close($connect);
		die;
	}
	mysql_query("SET NAMES 'utf8'", $connect);
	if (isset($_GET["act"]))
	{
		switch ($_GET["act"])
		{
			case "signin":
				CheckSignIn();
				break;
			case "register":
				Register();
				break;
			case "profile":
				Profile();
				break;
			case "update_profile":
				UpdateProfile();
				break;
			case "save":
				SaveGame();
				break;
			case "load":
				LoadGame();
				break;
			case "remove":
				RemoveGame();
				break;
		}
	}
	mysql_close($connect);
?>