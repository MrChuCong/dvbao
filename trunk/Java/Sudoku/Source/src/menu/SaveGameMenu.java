package menu;

import java.util.Vector;
import javax.microedition.lcdui.*;
import sudoku.*;

public class SaveGameMenu implements CommandListener {
    
    private SudokuMidlet midlet;
    private Form form;
    private TextField tfName;
    
    public SaveGameMenu(SudokuMidlet midlet) {
        this.midlet = midlet;
        tfName = new TextField("Sudoku name:", "", 20, TextField.ANY);
        form = new Form("Save");
        form.append(tfName);
        form.addCommand(SudokuCommand.commandOK);
        form.addCommand(SudokuCommand.commandBack);
        form.setCommandListener(this);
    }
    
    public Displayable getDisplayable() {
        tfName.setString("Sudoku ");
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
            midlet.setCurrentGameMenu();
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
            Vector records = BoardRecord.Create().getRecords();
            for (int i=0; i<records.size(); i++) {
                String[] record = (String[])records.elementAt(i);
                if (record[0].equals(name)) {
                    midlet.getSudokuAlert().setAlert(
                        SudokuImages.NameExistedImage,
                        form);
                    midlet.setCurrentSudokuAlert();
                    return;
                }
            }
            midlet.getSudokuCanvas().getBoard().save(name,
                midlet.getSudokuCanvas().getCurrentTime());
            midlet.getSudokuCanvas().resume();
            midlet.setCurrentSudokuCanvas();
            return;
        }
    }
}
