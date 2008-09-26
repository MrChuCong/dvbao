package menu;

import javax.microedition.lcdui.*;
import sudoku.*;

public class NewGameMenu implements CommandListener{
    
    private SudokuMidlet midlet;
    private List menu;    
    
    public NewGameMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        menu = new List("New", Choice.IMPLICIT);
        menu.append("Easy", null);
        menu.append("Normal", null);
        menu.append("Hard", null);
        menu.append("Manual", null);
        menu.addCommand(SudokuCommand.commandSelect);
        menu.addCommand(SudokuCommand.commandBack);
        menu.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        return menu;
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandBack) {
            midlet.setCurrentGameMenu();
            return;
        }
        if (command == SudokuCommand.commandSelect) {
            String item = menu.getString(menu.getSelectedIndex());
            if (item.equals("Easy")) {
                midlet.getSudokuCanvas().resetTime();
                midlet.getSudokuCanvas().getBoard().create(3);
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
            if (item.equals("Normal")) {
                midlet.getSudokuCanvas().resetTime();
                midlet.getSudokuCanvas().getBoard().create(2);
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
            if (item.equals("Hard")) {
                midlet.getSudokuCanvas().resetTime();
                midlet.getSudokuCanvas().getBoard().create(1);
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
            if (item.equals("Manual")) {
                midlet.getSudokuCanvas().resetTime();
                midlet.getSudokuCanvas().getBoard().create(0);
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
        }
    }
}
