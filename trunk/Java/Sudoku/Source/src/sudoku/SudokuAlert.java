package sudoku;

import javax.microedition.lcdui.*;

public class SudokuAlert extends Canvas implements CommandListener {
    
    private Image image = null;
    private SudokuMidlet midlet;
    private Displayable displayable;
    
    public SudokuAlert(SudokuMidlet midlet) {
        this.midlet = midlet;
        addCommand(SudokuCommand.commandDone);
        setCommandListener(this);
    }
    
    public void setAlert(Image image, Displayable displayable) {
        this.image = image;
        this.displayable = displayable;
        repaint();
    }
    
    public void paint(Graphics graphics) {
        if (image == null) return;
        int width = getWidth();
        int height = getHeight();
        graphics.setColor(255, 255, 255);
        graphics.fillRect(0, 0, width, height);
        graphics.drawImage(image,
            (width - image.getWidth()) / 2,
            (height - image.getHeight()) / 2,
            Graphics.TOP | Graphics.LEFT);
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandDone) {
            if (image == SudokuImages.Congratulations && midlet.checkHighScore()) {
                midlet.setCurrentSaveHighScoreMenu();
            }
            else {
                if (image == SudokuImages.Congratulations)
                    midlet.getSudokuCanvas().resume();
                Display.getDisplay(midlet).setCurrent(this.displayable);
            }
        }
    }
}
