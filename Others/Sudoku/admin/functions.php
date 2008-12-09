<?php
	function GetTable(&$result, &$row, &$column, $sql)
	{
		$temp_result = mysql_query($sql);
		$row = mysql_num_rows($temp_result);
		$column = mysql_num_fields($temp_result);
		if ($temp_result)
		{
			for ($i=0; $i<$row; $i++)
			{
				$row_array = mysql_fetch_array($temp_result, MYSQL_BOTH);
				$result[$i] = $row_array;
			}
			mysql_free_result($temp_result);
		}
	}
	
	function CheckSignIn()
	{
		$check = "invalid";
		if (isset($_POST["username"]) && isset($_POST["password"]))
		{
			$username = addslashes($_POST["username"]);
			$password = addslashes($_POST["password"]);
			$sql = "select * from users where username='$username' and password='$password'";
			GetTable($res, $row, $col, $sql);
			if ($row > 0) $check = $res[0]["user_id"] . ":" . $res[0]["username"];
		}
		echo $check;
	}
	
	function Register()
	{
		$username = addslashes($_POST["username"]);
		$password = addslashes($_POST["password"]);
		$email = addslashes($_POST["email"]);
		$sql = "select * from users where username='$username'";
		GetTable($res, $row, $col, $sql);
		if ($row > 0)
		{
			echo "failed:The username $username is not available!";
			return;
		}
		$sql = "insert into users(username, password, email) values ('$username', '$password', '$email')";
		mysql_query($sql);
		$sql = "select * from users where username='$username'";
		GetTable($res, $row, $col, $sql);
		echo $res[0]["user_id"] . ":" . $res[0]["username"];
	}
	
	function Profile()
	{
		$user_id = addslashes($_POST["user_id"]);
		$sql = "select * from users where user_id=$user_id";
		GetTable($res, $row, $col, $sql);
		if ($row == 0)
		{
			echo "failed";
			return;
		}
		echo $res[0]["username"] . ":" . $res[0]["email"];
	}
	
	function UpdateProfile()
	{
		$user_id = addslashes($_POST["user_id"]);
		$old_password = addslashes($_POST["old_password"]);
		$new_password = addslashes($_POST["new_password"]);
		$email = addslashes($_POST["email"]);
		if ($new_password != "")
		{
			$sql = "select * from users where user_id=$user_id and password='$old_password'";
			GetTable($res, $row, $col, $sql);
			if ($row == 0)
			{
				echo "failed:The old password you gave is incorrect!";
				return;
			}
			$sql = "update users set password='$new_password' where user_id=$user_id";
			mysql_query($sql);
		}
		$sql = "update users set email='$email' where user_id=$user_id";
		mysql_query($sql);
		echo "success";
	}
	
	function SaveGame()
	{
		$user_id = addslashes($_POST["user_id"]);
		$name = addslashes($_POST["name"]);
		$board = addslashes($_POST["board"]);
		$current = addslashes($_POST["current"]);
		$answer = addslashes($_POST["answer"]);
		$hh = addslashes($_POST["hh"]);
		$mm = addslashes($_POST["mm"]);
		$ss = addslashes($_POST["ss"]);
		$cmd = addslashes($_POST["cmd"]);
		if ($cmd == "insert")
		{
			$sql = "insert into games (user_id, name, board, current, answer, hh, mm, ss, time) values ($user_id, '$name', '$board', '$current', '$answer', $hh, $mm, $ss, now() )";
		}
		else
		{
			$sql = "update games set board='$board', current='$current', answer='$answer', hh=$hh, mm=$mm, ss=$ss, time=now() where user_id=$user_id and name='$name'";
		}
		mysql_query($sql);
		LoadGame();
	}
	
	function LoadGame()
	{
		$user_id = addslashes($_POST["user_id"]);
		$sql = "select * from games where user_id=$user_id";
		GetTable($res, $row, $col, $sql);
		echo $row;
		for ($i = 0; $i < $row; $i++)
		{
			echo "&" . $res[$i]["game_id"] . "&" . $res[$i]["name"] . "&" . $res[$i]["board"] . "&" . $res[$i]["current"] . "&" . $res[$i]["answer"] . "&" . $res[$i]["hh"] . "&" . $res[$i]["mm"] . "&" . $res[$i]["ss"] . "&" . $res[$i]["time"];
		}
	}
	
	function RemoveGame()
	{
		$user_id = addslashes($_POST["user_id"]);
		$list = addslashes($_POST["list"]);
		$sql = "delete from games where user_id=$user_id and game_id in ($list)";
		mysql_query($sql);
		LoadGame();
	}
?>