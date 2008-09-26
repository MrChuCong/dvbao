package sudoku;

import java.io.IOException;
import javax.microedition.lcdui.*;

public class SudokuImages {
    
    public static Image[] Digits = new Image[10];
    public static Image[] CellDigits = new Image[10];
    public static Image[] Cells = new Image[5];
    public static Image[] Themes = new Image[5];
    public static Image Div;
    public static Image IntroImage;
    public static Image NoSolutionImage;
    public static Image NoRecordImage;
    public static Image NameExistedImage;
    public static Image NameInvalidImage;
    public static Image Congratulations;
    
    public static void init() {
        try {
            for (int i=0; i<Digits.length; i++)
                Digits[i] = Image.createImage("/ClockDigits/" + i + ".png");
            for (int i=0; i<CellDigits.length; i++)
                CellDigits[i] = Image.createImage("/Cells/" + i + ".png");
            for (int i=0; i<Cells.length; i++)
                Cells[i] = Image.createImage("/Cells/cells" + i + ".png");
            for (int i=0; i<Themes.length; i++)
                Themes[i] = Image.createImage("/Themes/theme" + i + ".png");
            Div = Image.createImage("/ClockDigits/div.png");
            IntroImage = Image.createImage("/intro.png");
            NoSolutionImage = Image.createImage("/Alerts/nosolution.png");
            NoRecordImage = Image.createImage("/Alerts/norecord.png");
            NameExistedImage = Image.createImage("/Alerts/nameexisted.png");
            NameInvalidImage = Image.createImage("/Alerts/nameinvalid.png");
            Congratulations = Image.createImage("/Alerts/congratulations.png");
        } catch (IOException ex) {
        }
    }
}
