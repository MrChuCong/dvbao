package menu;

import javax.microedition.lcdui.*;
import sudoku.*;

public class GameMenu implements CommandListener{
    
    private SudokuMidlet midlet;
    private List menu;    
    
    public GameMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        menu = new List("Game", Choice.IMPLICIT);
        menu.append("New", null);
        menu.append("Load", null);
        menu.append("Save", null);
        menu.append("High Score", null);
        menu.append("Reset", null);
        menu.append("Solve", null);
        menu.addCommand(SudokuCommand.commandSelect);
        menu.addCommand(SudokuCommand.commandBack);        
        menu.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        return menu;
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandBack) {
            midlet.setCurrentMainMenu();
            return;
        }
        if (command == SudokuCommand.commandSelect) {
            String item = menu.getString(menu.getSelectedIndex());
            if (item.equals("New")) {
                midlet.setCurrentNewGameMenu();
                return;
            }
            if (item.equals("Load")) {
                if (BoardRecord.Create().getRecords().size() > 0) {
                    midlet.setCurrentLoadGameMenu();
                }
                else {
                    midlet.getSudokuAlert().setAlert(
                        SudokuImages.NoRecordImage,
                        midlet.getGameMenu().getDisplayable());
                    midlet.setCurrentSudokuAlert();
                }
                return;
            }
            if (item.equals("Save")) {
                midlet.setCurrentSaveGameMenu();
                return;
            }
            if (item.equals("High Score")) {
                if (HighScoreRecord.Create().getRecords().size() > 0) {
                    midlet.setCurrentLoadHighScoreMenu();
                }
                else {
                    midlet.getSudokuAlert().setAlert(
                        SudokuImages.NoRecordImage,
                        midlet.getGameMenu().getDisplayable());
                    midlet.setCurrentSudokuAlert();
                }
                return;
            }
            if (item.equals("Reset")) {
                midlet.getSudokuCanvas().resetTime();
                midlet.getSudokuCanvas().getBoard().reset();
                midlet.getSudokuCanvas().resume();
                midlet.setCurrentSudokuCanvas();
                return;
            }
            if (item.equals("Solve")) {
                if (!midlet.getSudokuCanvas().getBoard().solve()) {
                    midlet.getSudokuAlert().setAlert(
                        SudokuImages.NoSolutionImage,
                        midlet.getSudokuCanvas());
                    midlet.setCurrentSudokuAlert();
                }
                else {
                    midlet.setCurrentSudokuCanvas();
                }
                midlet.getSudokuCanvas().resume();
                return;
            }
        }
    }
}
