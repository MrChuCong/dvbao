package menu;

import javax.microedition.lcdui.*;
import sudoku.*;

public class IntroCanvas extends Canvas {
    
    public static int timeSleep = 3000;
    
    public void paint(Graphics graphics) {
        graphics.drawImage(SudokuImages.IntroImage,
            0, 0, Graphics.TOP | Graphics.LEFT);
    }
}