package menu;

import java.util.Vector;
import javax.microedition.lcdui.*;
import sudoku.*;

public class LoadHighScoreMenu implements CommandListener{
    
    private SudokuMidlet midlet;
    private List list;
    private Vector records;
    
    public LoadHighScoreMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        list = new List("High Score", Choice.IMPLICIT);
        list.addCommand(SudokuCommand.commandBack);
        list.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        list.deleteAll();
        records = HighScoreRecord.Create().getRecords();
        for (int i=0; i<records.size(); i++) {
            String[] record = (String[])records.elementAt(i);
            list.append((i+1) + ". " + record[0] + " (" + record[1] + ")", null);
        }
        return list;
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandBack) {
            midlet.setCurrentGameMenu();
            return;
        }
    }
}
