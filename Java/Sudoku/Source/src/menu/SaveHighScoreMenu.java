package menu;

import javax.microedition.lcdui.*;
import sudoku.*;

public class SaveHighScoreMenu implements CommandListener {
    
    private SudokuMidlet midlet;
    private Form form;
    private TextField tfName;
    
    public SaveHighScoreMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        tfName = new TextField("Your name:", "", 20, TextField.ANY);
        form = new Form("High Score");
        form.append(tfName);
        form.addCommand(SudokuCommand.commandOK);
        form.addCommand(SudokuCommand.commandBack);
        form.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        return form;
    }
    
    private boolean valid(String name) {
        if (name.length() == 0) return false;
        for (int i=0; i<name.length(); i++) {
            char ch = name.charAt(i);
            if (!(ch == ' ' || ('0' <= ch && ch <= '9') ||
                ('a' <= ch && ch <= 'z') ||
                ('A' <= ch && ch <= 'Z'))) return false;
        }
        return true;
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandBack) {
            midlet.setCurrentSudokuCanvas();
            return;
        }
        if (command == SudokuCommand.commandOK) {
            String name = tfName.getString();
            if (!valid(name)) {
                midlet.getSudokuAlert().setAlert(
                    SudokuImages.NameInvalidImage,
                    form);
                midlet.setCurrentSudokuAlert();
                return;
            }
            HighScoreRecord.Create().save(name,
                midlet.getSudokuCanvas().getCurrentTime());
            midlet.getSudokuCanvas().resume();
            midlet.setCurrentSudokuCanvas();
            return;
        }
    }
}
