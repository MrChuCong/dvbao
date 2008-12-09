var a = new Array(9);
var b = new Array(9);
var sol = new Array(9);
var col = new Array(9);
var row = new Array(9);
var block = new Array(9);
var c_step = 0;
var max_step = 0;
var steps = new Array();
var games = new Array();
var ValidZCellColor = "#0000FF";
var InvalidZCellColor = "#FFFFFF";
var ValidVCellColor = "#000000";
var InvalidVCellColor = "#FF0000";
var level = "EasyLevel";
var timer;
var hh = 0;
var mm = 0;
var ss = 0;
var onc = false;
var ons = false;
var SaveFormRequestSent = false;
var RemoveSelectedGamesSent = false;

function DisplayPlayGamePage()
{
	CreatePlayGameMenu();
	document.getElementById("content").style.height = "500px";	
	NewGame();
}

function NewGame()
{
	onc = false;
	ons = false;
	document.getElementById("content").innerHTML = '<div id="board"></div>';
	if (document.getElementById("EasyLevel").checked)
	{
		level = "EasyLevel";
		CreateSudokuBoard(0);//25
	}
	if (document.getElementById("NormalLevel").checked)
	{
		level = "NormalLevel";
		CreateSudokuBoard(35);
	}
	if (document.getElementById("HardLevel").checked)
	{
		level = "HardLevel";
		CreateSudokuBoard(45);
	}
	CreatePlayGameMenu();
	CreatePlayGameSubMenu();
	DisplaySudokuBoard();
	clearTimeout(timer);
	hh = 0;
	mm = 0;
	ss = 0;
	UpdateTimer();
}

function UpdateTimer()
{
	ShowTime();
	ss++;
	if (ss == 60)
	{
		ss = 0;
		mm++;
		if (mm == 60)
		{
			mm = 0;
			hh++;
		}
	}
	timer = setTimeout("UpdateTimer()", 1000);
}

function ShowTime()
{
	var time = "";
	if (hh < 10) time += "0";
	time += hh + " : ";
	if (mm < 10) time += "0";
	time += mm + " : ";
	if (ss < 10) time += "0";
	time += ss;
	var div = document.getElementById("GameTime");
	if (div == null) clearTimeout(timer);
	else div.innerHTML = time;
}

function CreatePlayGameMenu()
{
	if (document.getElementById("EasyLevel") != null)
	{
		if (document.getElementById("EasyLevel").checked)
		{
			level = "EasyLevel";
		}
		if (document.getElementById("NormalLevel").checked)
		{
			level = "NormalLevel";
		}
		if (document.getElementById("HardLevel").checked)
		{
			level = "HardLevel";
		}
	}
	var html = "";
	html += CreateMenuItem(120, "New", "NewGame");	
	if (!onc && !ons)
	{
		html += CreateMenuItem(120, "Solution", "ShowSolution");
		html += CreateMenuItem(120, "Complete", "CompleteGame");
	}
	html += CreateMenuItem(120, "Main Menu", "DisplayHomePage");
	if (username != "")
	{
		html += CreateMenuItem(120, "Save / Load", "SaveLoadGame");
	}
	html += '<div class="level">';
	html += '<input type="radio" name="radLevel" id="EasyLevel" checked="checked" /> Easy<br />';
	html += '<input type="radio" name="radLevel" id="NormalLevel" /> Normal<br />';
	html += '<input type="radio" name="radLevel" id="HardLevel" /> Hard<br />';
	html += '</div>';
	document.getElementById("menu").innerHTML = html;
	document.getElementById(level).checked = true;
}

function SaveLoadGame()
{
	var html = "";
	html += '<div class="title"><img src="images/savegame.jpg" /></div>';
	html += '<div class="instruction">Please give the name you want to save, then click "Save". If you want to continue playing, click "Continue".</div>';
	html += '<div id="error"></div>';
	html += CreateInputBlock('Game Name<input class="field" id="txtGameName" maxlength="100" type="text" />');
	html += '<div style="text-align:right; padding-right:55px;">' + CreateButton(80, "Save", "SubmitSaveGameForm") + CreateButton(80, "Continue", "ContinueGame") + '</div>';
	html += '<div class="title"><img src="images/loadgame.jpg" /></div>';
	html += '<div class="instruction">Remove game(s) from list, or select one saved game to play. If you want to continue playing, click "Continue".</div>';
	html += '<div id="games"></div>';
	document.getElementById("content").style.height = "auto";	
	document.getElementById("content").innerHTML = html;
	document.getElementById("txtGameName").focus();
	Request("load", "user_id=" + user_id, "ReceiveGameListsResponse");
}

function SubmitSaveGameForm()
{
	if (document.getElementById("error1") != null)
	{
		document.getElementById("error1").innerHTML = "";
	}
	if (!SaveFormRequestSent)
	{
		var error = "";
		var txtGameName = document.getElementById("txtGameName");
		txtGameName.value = trim(txtGameName.value);
		if (txtGameName.value == "")
		{
			error += "<li>Please insert the name you want to save!</li>";
		}
		else
		{
			if (txtGameName.value.length < 3)
			{
				error += "<li>The game name must be at least 3 characters!</li>";
			}
		}
		var exist = false;
		for (var i=0; i<games.length; i++)
		{
			if (games[i].name == txtGameName.value)
			{
				exist = true;
				break;
			}
		}
		var ans_confirm;
		if (exist)
		{
			ans_confirm = confirm("The game name already exists. Do you want to replace the existing game?");
		}
		if (error == "")
		{
			document.getElementById("error").innerHTML = "";
			if (exist && !ans_confirm)
			{
				document.getElementById("txtGameName").focus();
				return;
			}
			var cmd = "insert";
			if (exist && ans_confirm) cmd = "update";
			var _board = "";
			var _current = "";
			var _answer = "";
			for (var i=0; i<9; i++)
			{
				for (var j=0; j<9; j++)
				{
					_board += b[i][j];
					_current += a[i][j];
					_answer += sol[i][j];
				}
			}			
			SaveFormRequestSent = true;
			Request("save", "user_id=" + user_id + "&name=" + txtGameName.value + "&board=" + _board + "&current=" + _current + "&answer=" + _answer + "&hh=" + hh + "&mm=" + mm + "&ss=" + ss + "&cmd=" + cmd, "ReceiveSaveFormResponse");
		}
		else
		{
			document.getElementById("error").innerHTML = CreateErrorBoard(error);
			document.getElementById("txtGameName").focus();
		}
	}
}

function ReceiveSaveFormResponse(response)
{
	SaveFormRequestSent = false;
	ReceiveGameListsResponse(response);
	document.getElementById("txtGameName").value = "";
	document.getElementById("txtGameName").focus();
}

function Game(game_id, name, board, current, answer, hh, mm, ss, time)
{
	this.game_id = game_id;
	this.name = name;
	this.board = board;
	this.current = current;
	this.answer = answer;
	this.hh = hh;
	this.mm = mm;
	this.ss = ss;
	this.time = time;
}

function ReceiveGameListsResponse(response)
{
	var array = response.split("&");
	games.length = array[0];
	var index = 1;
	for (var i=0; i<games.length; i++)
	{
		games[i] = new Game(array[index++], array[index++], array[index++],
							array[index++], array[index++], array[index++],
							array[index++], array[index++], array[index++]);
	}
	DisplayGamesList();
}

function DisplayGamesList()
{
	var html = "";
	if (games.length == 0)
	{
		html += '<div align="center" style="padding-bottom:20px;">';
		html += CreateErrorBoard("<li>There\'s no saved game in database!</li>");
		html += '</div>';
	}
	else
	{
		html += '<div id="error1"></div>';
		html += '<div align="center" style="padding-top:10px; padding-bottom:20px;"><table border="0" cellpadding="0" cellspacing="0" class="games_list">';
		html += '<tr>';
		html += '<th>Game ID</th>';
		html += '<th>Name</th>';
		html += '<th>Time</th>';
		html += '</tr>';
		for (var i=0; i<games.length; i++)
		{
			html += '<tr>';
			html += '<td><input type="checkbox" id="sel' + i + '" /> ' + games[i].game_id + '</td>';
			html += '<td>' + games[i].name + '</td>';
			html += '<td>' + games[i].time + '</td>';
			html += '</tr>';
		}
		html += '</table>';
		html += '<div style="text-align:center; padding-top:20px;">' + CreateButton(80, "Play", "PlaySelectedGame") + CreateButton(80, "Remove", "RemoveSelectedGames") + CreateButton(80, "Continue", "ContinueGame") + '</div>';
		html += '</div>';
	}
	document.getElementById("games").innerHTML = html;
}

function PlaySelectedGame()
{
	
}

function RemoveSelectedGames()
{
	if (!RemoveSelectedGamesSent)
	{
		document.getElementById("error").innerHTML = "";
		document.getElementById("error1").innerHTML = "";
		var list = "";
		for (var i=0; i<games.length; i++)
		{
			if (document.getElementById("sel" + i).checked)
			{
				list += games[i].game_id + ",";
			}
		}
		if (list == "")
		{
			document.getElementById("error1").innerHTML = CreateErrorBoard("<li>Please select at least one game to remove!</li>");
		}
		else
		{
			list = list.substr(0, list.length - 1);
			RemoveSelectedGamesSent = true;
			Request("remove", "user_id=" + user_id + "&list=" + list, "ReceiveRemoveSelectedGamesResponse");
		}
	}
}

function ReceiveRemoveSelectedGamesResponse(response)
{
	RemoveSelectedGamesSent = false;
	ReceiveGameListsResponse(response);
	document.getElementById("txtGameName").value = "";
	document.getElementById("txtGameName").focus();
}

function CreatePlayGameSubMenu()
{
	var html = ""
	html += '<div class="sub_block"><div><strong id="GameTime">00 : 00 : 00</strong></div></div>';
	html += '<a href="#" onClick="Undo(); return false;"><img border="0" src="images/undo.png" /></a>';
	html += '<a href="#" onClick="Redo(); return false;"><img border="0" src="images/redo.png" /></a>';
	document.getElementById("game_info").innerHTML = html;
}

function GameStep(x, y, pv, nv)
{
	this.x = x;
	this.y = y;
	this.pv = pv;
	this.nv = nv;
}

function CreateSudokuBoard(nc)
{
	for (var i=0; i<9; i++)
	{
		a[i] = new Array(9);
		b[i] = new Array(9);
		sol[i] = new Array(9);
		for (var j=0; j<9; j++)
		{
			a[i][j] = 0;
		}
		col[i] = new Array(10);
		row[i] = new Array(10);
		block[i] = new Array(10);
		for (var j=0; j<10; j++)
		{
			col[i][j] = 0;
			row[i][j] = 0;
			block[i][j] = 0;
		}
	}
	FindRandom(0, 0);
	for (var i=0; i<9; i++)
	{
		for (var j=0; j<9; j++)
		{
			sol[i][j] = a[i][j];
		}
	}
	nc += Math.floor(Math.random() * 5);
	var c = new Array();
	for (var i=0; i<81; i++)
	{
		c.push(i);
	}	
	for (var i=0; i<nc; i++)
	{
		var j = Math.floor(Math.random() * c.length);
		a[parseInt(c[j] / 9)][c[j] % 9] = 0;
		c.splice(j, 1);
	}
	for (var i=0; i<9; i++)
	{
		for (var j=0; j<9; j++)
		{
			b[i][j] = a[i][j];
		}
	}
	c_step = 0;
	max_step = 0;
}

function FindRandom(x, y)
{
	if (y == 9)
	{
		x++;
		y = 0;
		if (x == 9) return true;
	}
	if (a[x][y] > 0) return FindRandom(x, y + 1);
	var b = parseInt(x / 3) * 3 + parseInt(y / 3);
	var nums = new Array();
	for (var num=1; num<=9; num++)
	{
		if (!row[x][num] && !col[y][num] && !block[b][num])
		{
			nums.push(num);
		}
	}
	while (nums.length > 0)
	{
		var i = Math.floor(Math.random() * nums.length);
		var num = nums[i];
		a[x][y] = num;
		row[x][num] = 1;
		col[y][num] = 1;
		block[b][num] = 1;
		if (FindRandom(x, y + 1))
		{
			return true;
		}
		block[b][num] = 0;
		col[y][num] = 0;
		row[x][num] = 0;
		a[x][y] = 0;
		nums.splice(i, 1);
	}
	return false;
}

function DisplaySudokuBoard()
{
	var html = '<table cellpadding="0" cellspacing="1" border="0">';
	for (var i=0; i<3; i++)
	{
		html += '<tr>';
		for (var j=0; j<3; j++)
		{
			html += '<td>';
			html += '<table cellpadding="0" cellspacing="3" border="0">';
			for (var u=0; u<3; u++)
			{
				html += '<tr>';
				for (var v=0; v<3; v++)
				{
					var x = (i * 3) + u;
					var y = (j * 3) + v;
					html += '<td class="w_cell" id="d' + (x * 9 + y) + '">';
					if (a[x][y] == 0)
					{
						html += '<input class="z_cell" autocomplete="off" type="text" size="1" maxlength="1" id="c' + (x * 9 + y) + '" onKeyUp="UpdateSudokuBoard(this.id)" value=""/>';
					}
					else
					{
						html += '<input class="v_cell" autocomplete="off" type="text" size="1" readonly="readonly" id="c' + (x * 9 + y) + '" value="' + a[x][y] + '"/>';
					}
					html += '</td>';
				}
				html += '</tr>';
			}
			html += '</table>';
			html += '</td>';
		}
		html += '</tr>';
	}
	html += '</table>';
	document.getElementById("board").innerHTML = html;
}

function CompleteGame()
{
	onc = true;
	CreatePlayGameMenu();
	var complete = ValidateSudokuBoard();
	if (complete)
	{
		clearTimeout(timer);
		ShowTime();
	}
	else
	{	
		var html = '<div align="center" style="padding-top:50px;"><img src="images/fun.jpg" /></div>';
		html += '<div class="instruction">You have not completed the Sudoku board. Do you want to continue playing on this board or create a new board?</div>';
		html += '<div style="text-align:right; padding-right:55px;">' + CreateButton(100, "Continue", "ContinueGame") + CreateButton(100, "Create New", "DisplayPlayGamePage") + '</div>';
		document.getElementById("content").innerHTML = html;
	}
}

function ContinueGame()
{
	onc = false;
	CreatePlayGameMenu();
	document.getElementById("content").style.height = "500px";
	document.getElementById("content").innerHTML = '<div id="board"></div>';
	for (var i=0; i<9; i++)
	{
		for (var j=0; j<9; j++)
		{
			var t = -1;
			if (a[i][j] != 0 && b[i][j] == 0)
			{
				t = a[i][j];
			}
			a[i][j] = b[i][j];
			if (t > 0)
			{
				b[i][j] = t;
			}
		}
	}
	DisplaySudokuBoard();
	for (var i=0; i<9; i++)
	{
		for (var j=0; j<9; j++)
		{
			if (b[i][j] != 0 && a[i][j] == 0)
			{
				document.getElementById("c" + (i * 9 + j)).value = b[i][j];
				a[i][j] = b[i][j];
				b[i][j] = 0;
			}
		}
	}
	ValidateSudokuBoard();
}

function DisplaySolutionBoard()
{
	var html = '<table cellpadding="0" cellspacing="1" border="0">';
	for (var i=0; i<3; i++)
	{
		html += '<tr>';
		for (var j=0; j<3; j++)
		{
			html += '<td>';
			html += '<table cellpadding="0" cellspacing="3" border="0">';
			for (var u=0; u<3; u++)
			{
				html += '<tr>';
				for (var v=0; v<3; v++)
				{
					var x = (i * 3) + u;
					var y = (j * 3) + v;
					html += '<td class="w_cell" id="d' + (x * 9 + y) + '">';
					if (b[x][y] == 0)
					{
						html += '<input class="z_cell" autocomplete="off" type="text" size="1" readonly="readonly" id="c' + (x * 9 + y) + '" value="' + sol[x][y] + '"/>';
					}
					else
					{
						html += '<input class="v_cell" autocomplete="off" type="text" size="1" readonly="readonly" id="c' + (x * 9 + y) + '" value="' + b[x][y] + '"/>';
					}
					html += '</td>';
				}
				html += '</tr>';
			}
			html += '</table>';
			html += '</td>';
		}
		html += '</tr>';
	}
	html += '</table>';
	document.getElementById("board").innerHTML = html;
}

function ShowSolution()
{
	ons = true;
	CreatePlayGameMenu();
	DisplaySolutionBoard();
	clearTimeout(timer);
	ShowTime();
	c_step = 0;
	max_step = 0;
}

function Undo()
{
	document.getElementById("game_info").innerHTML = document.getElementById("game_info").innerHTML;
	if (onc || ons) return;
	if (c_step == 0) return;
	c_step--;
	var x = steps[c_step].x;
	var y = steps[c_step].y;
	var value = steps[c_step].pv;
	a[x][y] = value;
	if (value == 0) value = "";
	var cell = document.getElementById("c" + (x * 9 + y));
	cell.value = value;
	cell.focus();
	ValidateSudokuBoard();
}

function Redo()
{
	document.getElementById("game_info").innerHTML = document.getElementById("game_info").innerHTML;
	if (onc || ons) return;
	if (c_step >= max_step) return;
	var x = steps[c_step].x;
	var y = steps[c_step].y;
	var value = steps[c_step].nv;
	c_step++;
	a[x][y] = value;
	if (value == 0) value = "";
	var cell = document.getElementById("c" + (x * 9 + y));
	cell.value = value;
	cell.focus();
	ValidateSudokuBoard();
}

function UpdateSudokuBoard(id)
{
	var cell = document.getElementById(id);
	if (cell.value < '1' || cell.value > '9')
	{
		cell.value = "";
	}
	id = id.substr(1);
	var x = parseInt(id / 9);
	var y = id % 9;
	var v = a[x][y];
	if (cell.value == "")
	{
		a[x][y] = 0;
	}
	else
	{
		a[x][y] = parseInt(cell.value);
	}
	if (v != a[x][y])
	{
		steps[c_step++] = new GameStep(x, y, v, a[x][y]);
		max_step = c_step;
	}
	ValidateSudokuBoard();
}

function ValidateSudokuBoard()
{
	var valid = true;
	for (var x=0; x<9; x++)
	{
		for (var y=0; y<9; y++)
		{
			var color = ValidZCellColor;
			var background = "w_cell";
			if (a[x][y] != 0)
			{
				if (b[x][y] == 0)
				{
					color = ValidZCellColor;
					if (!ValidateCell(x, y))
					{
						valid = false;
						color = InvalidZCellColor;
						background = "p_cell";
					}
				}
				else
				{
					color = ValidVCellColor;
					if (!ValidateCell(x, y))
					{
						valid = false;
						color = InvalidVCellColor;
					}
				}
			}
			else
			{
				valid = false;
			}
			document.getElementById("c" + (x * 9 + y)).style.color = color;
			document.getElementById("d" + (x * 9 + y)).className = background;
		}
	}
	return valid;
}

function ValidateCell(x, y)
{
	for (var i=0; i<9; i++)
	{
		if (i != y && a[x][i] == a[x][y]) return false;
		if (i != x && a[i][y] == a[x][y]) return false;
	}
	var u = parseInt(x / 3) * 3;
	var v = parseInt(y / 3) * 3;
	for (var i=u; i<u+3; i++)
	{
		for (var j=v; j<v+3; j++)
		{
			if ((i != x || j != y) && a[i][j] == a[x][y]) return false;
		}
	}
	return true;
}