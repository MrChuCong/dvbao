package menu;

import javax.microedition.lcdui.*;
import sudoku.*;

public class MainMenu implements CommandListener{
    
    private SudokuMidlet midlet;
    private List menu;    
    
    public MainMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        menu = new List("Menu", Choice.IMPLICIT);
        menu.append("Game", null);
        menu.append("Undo", null);
        menu.append("Redo", null);
        menu.append("Exit", null);
        menu.addCommand(SudokuCommand.commandSelect);
        menu.addCommand(SudokuCommand.commandBack);
        menu.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        return menu;
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandBack) {
            midlet.getSudokuCanvas().resume();
            midlet.setCurrentSudokuCanvas();
            return;
        }
        if (command == SudokuCommand.commandSelect) {
            String item = menu.getString(menu.getSelectedIndex());
            if (item.equals("Game")) {
                midlet.setCurrentGameMenu();
                return;
            }
            if (item.equals("Undo")) {
                midlet.getSudokuCanvas().getBoard().undo();
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
            if (item.equals("Redo")) {
                midlet.getSudokuCanvas().getBoard().redo();
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
            if (item.equals("Exit")) {
                midlet.exit();
                return;
            }
        }
    }
}
