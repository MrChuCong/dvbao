var SignInFormRequestSent = false;

function DisplaySignInPage()
{
	CreateMainMenu();
	var html = "";
	html += '<div class="title"><img src="images/signin.jpg" /></div>';
	html += '<div class="instruction">Don\'t you have an account, yet? Register <a href="javascript:DisplayRegisterPage()">here</a>!</div>';
	html += '<div id="error"></div>';
	html += CreateInputBlock('Username<input class="field" id="txtUsername" maxlength="100" type="text" />');
	html += CreateInputBlock('Password<input class="field" id="txtPassword" maxlength="100" type="password" />');
	html += '<div style="text-align:right; padding-right:55px;">' + CreateButton(80, "Sign In", "SubmitSignInForm") + '</div>';
	document.getElementById("content").style.height = "500px";
	document.getElementById("content").innerHTML = html;
	document.getElementById("game_info").innerHTML = "";
	document.getElementById("txtUsername").focus();
}

function SubmitSignInForm()
{
	if (!SignInFormRequestSent)
	{
		var txtUsername = document.getElementById("txtUsername");
		txtUsername.value = trim(txtUsername.value);
		var error = "";
		if (txtUsername.value == "")
		{
			error += "<li>Please insert your username!</li>";
		}
		var txtPassword = document.getElementById("txtPassword");
		txtPassword.value = trim(txtPassword.value);
		if (txtPassword.value == "")
		{
			error += "<li>Please insert your password!</li>";
		}
		if (error == "")
		{
			SignInFormRequestSent = true;
			Request("signin", "username=" + txtUsername.value + "&password=" + txtPassword.value, "ReceiveSignInFormResponse");
		}
		else
		{
			document.getElementById("error").innerHTML = CreateErrorBoard(error);
			document.getElementById("txtUsername").focus();
		}
	}
}

function Welcome()
{
	if (username == "")
	{
		document.getElementById("welcome").innerHTML = "(Guest)";
	}
	else
	{
		document.getElementById("welcome").innerHTML = '(<a href="#" onClick="DisplayProfilePage(); return false;">' + username + '</a>)';
	}
}

function ReceiveSignInFormResponse(response)
{
	SignInFormRequestSent = false;
	if (response == "invalid")
	{
		var error = "<li>Wrong username or password!</li>";
		document.getElementById("error").innerHTML = CreateErrorBoard(error);
		document.getElementById("txtUsername").focus();
	}
	else
	{
		var array = response.split(":");
		user_id = array[0];
		username = array[1];
		Welcome();
		document.cookie = "username=" + escape(username);
		document.cookie = "user_id=" + escape(user_id);
		DisplayHomePage();
	}
}

function SignOut()
{
	username = "";
	user_id = -1;
	document.cookie = "username=" + escape(username);
	document.cookie = "user_id=" + escape(user_id);
	Welcome();
	DisplayHomePage();
}