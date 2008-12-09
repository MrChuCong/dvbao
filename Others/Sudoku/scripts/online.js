function DisplayWhosOnlinePage()
{
	CreateMainMenu();
	var html = "";
	html += '<div class="title"><img src="images/whosonline.jpg" /></div>';
	document.getElementById("content").innerHTML = html;
	document.getElementById("game_info").innerHTML = "";
}