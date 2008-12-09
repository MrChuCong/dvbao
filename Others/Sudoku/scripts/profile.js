var ProfileFormRequestSent = false;

function DisplayProfilePage()
{
	Request("profile", "user_id=" + user_id, "ReceiveProfileResponse");
}

function ReceiveProfileResponse(response)
{
	if (response == "failed")
	{
		DisplayHomePage();
		return;
	}
	var array = response.split(":");
	CreateMainMenu();
	var html = "";
	html += '<div class="title"><img src="images/profile.jpg" /></div>';
	html += '<div class="instruction">Update your profile here</div>';
	html += '<div id="error"></div>';
	html += CreateInputBlock('Username<input class="field" id="txtUsername" style="background-color:#454547; color:#FFFFFF;" readonly="readonly" type="text" value="' + array[0] + '" />');
	html += CreateInputBlock('Old Password<input class="field" id="txtOldPassword" maxlength="100" type="password" />');
	html += CreateInputBlock('New Password<input class="field" id="txtNewPassword" maxlength="100" type="password" />');
	html += CreateInputBlock('Confirm Password<input class="field" id="txtConfirmPassword" maxlength="100" type="password" />');
	html += CreateInputBlock('Email Address<input class="field" id="txtEmail" maxlength="100" type="text" value="' + array[1] + '" />');
	html += '<div style="text-align:right; padding-right:55px;">' + CreateButton(80, "Update", "SubmitProfileForm") + '</div>';
	document.getElementById("content").style.height = "680px";
	document.getElementById("content").innerHTML = html;
	document.getElementById("game_info").innerHTML = "";
	document.getElementById("txtOldPassword").focus();
}

function SubmitProfileForm()
{
	if (!ProfileFormRequestSent)
	{
		var error = "";
		var txtOldPassword = document.getElementById("txtOldPassword");
		txtOldPassword.value = trim(txtOldPassword.value);
		var txtNewPassword = document.getElementById("txtNewPassword");
		txtNewPassword.value = trim(txtNewPassword.value);
		var txtConfirmPassword = document.getElementById("txtConfirmPassword");
		txtConfirmPassword.value = trim(txtConfirmPassword.value);
		var txtEmail = document.getElementById("txtEmail");
		txtEmail.value = trim(txtEmail.value);
		if (txtNewPassword.value != "")
		{
			if (txtOldPassword.value == "")
			{
				error += "<li>Please insert your old password!</li>";
			}
			else
			{
				if (txtOldPassword.value.length < 5)
				{
					error += "<li>Your old password must be at least 5 characters!</li>";
				}
				else
				{
					if (ValidateText(txtOldPassword.value) == false)
					{
						error += "<li>Your old password is invalid!</li>";
					}
				}
			}
			if (txtNewPassword.value.length < 5)
			{
				error += "<li>Your new password must be at least 5 characters!</li>";
			}
			else
			{
				if (ValidateText(txtNewPassword.value) == false)
				{
					error += "<li>Your new password is invalid!</li>";
				}
				else
				{
					if (txtConfirmPassword.value != txtNewPassword.value)
					{
						error += "<li>The new passwords do not match!</li>";
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
			ProfileFormRequestSent = true;
			Request("update_profile", "user_id=" + user_id + "&old_password=" + txtOldPassword.value + "&new_password=" + txtNewPassword.value + "&email=" + txtEmail.value, "ReceiveProfileFormResponse");
		}
		else
		{
			document.getElementById("error").innerHTML = CreateErrorBoard(error);
			document.getElementById("txtOldPassword").focus();
		}
	}
}

function ReceiveProfileFormResponse(response)
{
	ProfileFormRequestSent = false;
	var array = response.split(":");
	if (array[0] == "failed")
	{
		var error = "";
		for (var i=1; i<array.length; i++)
		{
			error += "<li>" + array[i] + "</li>";
		}
		document.getElementById("error").innerHTML = CreateErrorBoard(error);
		document.getElementById("txtOldPassword").focus();
	}
	else
	{
		DisplayHomePage();
	}
}