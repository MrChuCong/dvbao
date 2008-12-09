var RegisterFormRequestSent = false;

function DisplayRegisterPage()
{
	CreateMainMenu();
	var html = "";
	html += '<div class="title"><img src="images/register.jpg" /></div>';
	html += '<div class="instruction">Create a free Sudoku Master account</div>';
	html += '<div id="error"></div>';
	html += CreateInputBlock('Username<input class="field" id="txtUsername" maxlength="20" type="text" />');
	html += CreateInputBlock('Password<input class="field" id="txtPassword" maxlength="100" type="password" />');
	html += CreateInputBlock('Confirm Password<input class="field" id="txtConfirmPassword" maxlength="100" type="password" />');
	html += CreateInputBlock('Email Address<input class="field" id="txtEmail" maxlength="100" type="text" />');
	html += '<div style="text-align:right; padding-right:55px;">' + CreateButton(80, "Register", "SubmitRegisterForm") + '</div>';
	document.getElementById("content").style.height = "600px";
	document.getElementById("content").innerHTML = html;
	document.getElementById("game_info").innerHTML = "";
	document.getElementById("txtUsername").focus();
}

function SubmitRegisterForm()
{
	if (!RegisterFormRequestSent)
	{
		var error = "";
		var txtUsername = document.getElementById("txtUsername");
		txtUsername.value = trim(txtUsername.value);
		var txtPassword = document.getElementById("txtPassword");
		txtPassword.value = trim(txtPassword.value);
		var txtConfirmPassword = document.getElementById("txtConfirmPassword");
		txtConfirmPassword.value = trim(txtConfirmPassword.value);
		var txtEmail = document.getElementById("txtEmail");
		txtEmail.value = trim(txtEmail.value);
		if (txtUsername.value == "")
		{
			error += "<li>Please insert your username!</li>";
		}
		else
		{
			if (txtUsername.value.length < 5)
			{
				error += "<li>Your username must be at least 5 characters!</li>";
			}
			else
			{
				if (ValidateText(txtUsername.value) == false)
				{
					error += "<li>Your username is invalid!</li>";
				}
			}
		}
		if (txtPassword.value == "")
		{
			error += "<li>Please insert your password!</li>";
		}
		else
		{
			if (txtPassword.value.length < 5)
			{
				error += "<li>Your password must be at least 5 characters!</li>";
			}
			else
			{
				if (ValidateText(txtPassword.value) == false)
				{
					error += "<li>Your password is invalid!</li>";
				}
				else
				{
					if (txtConfirmPassword.value != txtPassword.value)
					{
						error += "<li>The passwords do not match!</li>";
					}
				}
			}
		}
		if (ValidateEmail(txtEmail.value) == false)
		{
			error += "<li>Invalid email address!</li>";
		}
		if (error == "")
		{
			RegisterFormRequestSent = true;
			Request("register", "username=" + txtUsername.value + "&password=" + txtPassword.value + "&email=" + txtEmail.value, "ReceiveRegisterFormResponse");
		}
		else
		{
			document.getElementById("error").innerHTML = CreateErrorBoard(error);
			document.getElementById("txtUsername").focus();
		}
	}
}

function ReceiveRegisterFormResponse(response)
{
	RegisterFormRequestSent = false;
	var array = response.split(":");
	if (array[0] == "failed")
	{
		var error = "";
		for (var i=1; i<array.length; i++)
		{
			error += "<li>" + array[i] + "</li>";
		}
		document.getElementById("error").innerHTML = CreateErrorBoard(error);
		document.getElementById("txtUsername").focus();
	}
	else
	{
		user_id = array[0];
		username = array[1];
		Welcome();
		document.cookie = "username=" + escape(username);
		document.cookie = "user_id=" + escape(user_id);
		DisplayHomePage();
	}
}