function DisplayHomePage()
{
	document.getElementById("content").style.height = "500px";
	document.getElementById("content").innerHTML = '<img src="images/intro.jpg" />';
	document.getElementById("game_info").innerHTML = "";
	username = GetCookie("username");
	user_id = GetCookie("user_id");
	if (user_id == "")
	{
		user_id = -1;
	}
	Welcome();
	CreateMainMenu();
}

function CreateMainMenu()
{
	var html = "";
	html += CreateMenuItem(120, "Home", "DisplayHomePage");
	if (username == "")
	{
		html += CreateMenuItem(120, "Sign In", "DisplaySignInPage");
		html += CreateMenuItem(120, "Register", "DisplayRegisterPage");
	}
	else
	{
		html += CreateMenuItem(120, "Sign Out", "SignOut");
	}
	html += CreateMenuItem(120, "Play Game", "DisplayPlayGamePage");
	if (username != "")
	{
		html += CreateMenuItem(120, "Who's Online", "DisplayWhosOnlinePage");
	}
	document.getElementById("menu").innerHTML = html;
}