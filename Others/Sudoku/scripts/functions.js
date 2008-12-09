var username = "";
var user_id = -1;

window.onbeforeunload = function()
{
	if (username != "")
	{
		return "All unsaved data may be lost.";
	}
}

function CreateInputBlock(content)
{
	return '<div class="block_top"><div class="block_bottom">' + content + '</div></div>';
}

function CreateMenuItem(size, text, func)
{
	return '<a class="menu" href="#" onClick="' + func + '(); return false;"><span style="width:' + size + 'px; text-align:center;">' + text + '</span></a>';
}

function CreateButton(size, text, func)
{
	return '<a class="button" href="#" onClick="' + func + '(); return false;"><span style="width:' + size + 'px; text-align:center;">' + text + '</span></a>';
}

function trim(str)
{
	return str.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
}

function CreateXMLHttp()
{
	if (typeof XMLHttpRequest != "undefined")
	{
		return new XMLHttpRequest();
	}
	else
	{
		if (window.ActiveXObject)
		{
			var objs = ["Microsoft.XmlHttp", "MSXML2.XmlHttp", "MSXML2.XmlHttp.3.0", "MSXML2.XmlHttp.4.0", "MSXML2.XmlHttp.5.0"];
			for (var i=0; i<objs.length; i++)
			{
				try
				{
					var httpObj = new ActiveXObject(objs[i]);
					return httpObj;
				}
				catch(e) {}
			}
		}
	}
	throw new Error("XMLHttp (AJAX) not supported!");
}

function GetCookie(name)
{
	if (document.cookie.length > 0)
	{
		var start = document.cookie.indexOf(name + "=");
		if (start != -1)
		{
			start = start + name.length + 1;
			var end = document.cookie.indexOf(";", start);
			if (end == -1) end = document.cookie.length;
			return unescape(document.cookie.substring(start, end));
		}
	}
	return "";
}

function Request(method, params, callback)
{
	var request = CreateXMLHttp();
	var url = "admin/post.php?act=" + method;
	request.open("POST", url, true);
	request.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
	request.onreadystatechange = function()
	{
		if (this.readyState == 4)
		{
			if (this.status == 200)
			{
				eval(callback + "(request.responseText)");
			}
		}
	}
	request.send(params);
}

function CreateErrorBoard(error)
{
	return '<div class="error_block_top"><div class="error_block_bottom"><ul>' + error + '</ul></div></div>';
}

function ValidateEmail(email)
{
	var apos = email.indexOf("@");
	var dotpos = email.indexOf(".", apos);
	if (apos < 1 || dotpos - apos < 2) return false;
	return true;
}

function ValidateText(text)
{
	for (var i=0; i<text.length; i++)
	{
		var ch = text.charAt(i);
		if ('a' <= ch && ch <= 'z') continue;
		if ('A' <= ch && ch <= 'Z') continue;
		if ('0' <= ch && ch <= '9') continue;
		if (ch == '_') continue;
		return false;
	}
	return true;
}