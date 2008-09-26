package menu;

import java.util.Vector;
import javax.microedition.lcdui.*;
import sudoku.*;

public class LoadGameMenu implements CommandListener{
    
    private SudokuMidlet midlet;
    private List menu;
    private Vector records;
    
    public LoadGameMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        menu = new List("Load", Choice.IMPLICIT);
        menu.addCommand(SudokuCommand.commandErase);
        menu.addCommand(SudokuCommand.commandDelete);
        menu.addCommand(SudokuCommand.commandSelect);
        menu.addCommand(SudokuCommand.commandBack);
        menu.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        menu.deleteAll();
        records = BoardRecord.Create().getRecords();
        for (int i=0; i<records.size(); i++) {
            menu.append(((String[])records.elementAt(i))[0], null);
        }
        return menu;
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandBack) {
            midlet.setCurrentGameMenu();
            return;
        }
        if (command == SudokuCommand.commandSelect) {
            if (menu.size() <= 0) return;
            String item = menu.getString(menu.getSelectedIndex());
            for (int i=0; i<records.size(); i++) {
                if (item.equals(((String[])records.elementAt(i))[0])) {
                    midlet.getSudokuCanvas().resetTime();
                    midlet.getSudokuCanvas().getBoard().reset(
                        ((String[])records.elementAt(i))[1],
                        ((String[])records.elementAt(i))[2]);
                    midlet.getSudokuCanvas().resume();
                    midlet.setCurrentSudokuCanvas();
                    return;
                }
            }
        }
        if (command == SudokuCommand.commandDelete) {
            if (menu.size() <= 0) return;
            String item = menu.getString(menu.getSelectedIndex());
            menu.delete(menu.getSelectedIndex());
            BoardRecord.Create().delete(item);
            return;
        }
        if (command == SudokuCommand.commandErase) {
            if (menu.size() <= 0) return;
            menu.deleteAll();
            BoardRecord.Create().deleteAll();
            return;
        }
    }
}
