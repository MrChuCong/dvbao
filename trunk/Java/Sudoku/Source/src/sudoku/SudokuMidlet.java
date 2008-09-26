package sudoku;

import java.io.*;
import java.util.Vector;
import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import javax.microedition.media.*;
import menu.*;

public class SudokuMidlet extends MIDlet {
    
    private IntroCanvas introCanvas;
    private SudokuCanvas sudokuCanvas;
    private MainMenu mainMenu;
    private GameMenu gameMenu;
    private NewGameMenu newGameMenu;
    private LoadGameMenu loadGameMenu;
    private SaveGameMenu saveGameMenu;
    private SudokuAlert sudokuAlert;
    private SaveHighScoreMenu saveHighScoreMenu;
    private LoadHighScoreMenu loadHighScoreMenu;
    private Player player;
    private Display display = null;
    
    public SudokuCanvas getSudokuCanvas() {
        return sudokuCanvas;
    }
    
    public GameMenu getGameMenu() {
        return gameMenu;
    }
    
    public SudokuAlert getSudokuAlert() {
        return sudokuAlert;
    }
    
    public boolean checkHighScore() {
        Vector records = HighScoreRecord.Create().getRecords();
        if (records.size() == 0 || records.size() < HighScoreRecord.MAXHS)
            return true;
        String currentTime = sudokuCanvas.getCurrentTime();
        String lastTime = ((String[])records.elementAt(records.size() - 1))[1];
        return (currentTime.compareTo(lastTime) < 0);
    }
    
    public SudokuMidlet() {
        SudokuImages.init();
        BoardRecord.Create().init();
        HighScoreRecord.Create().init();
        sudokuCanvas = new SudokuCanvas(this);
        mainMenu = new MainMenu(this);
        gameMenu = new GameMenu(this);
        newGameMenu = new NewGameMenu(this);
        loadGameMenu = new LoadGameMenu(this);
        saveGameMenu = new SaveGameMenu(this);
        introCanvas = new IntroCanvas();
        sudokuAlert = new SudokuAlert(this);
        saveHighScoreMenu = new SaveHighScoreMenu(this);
        loadHighScoreMenu = new LoadHighScoreMenu(this);
    }
    
    public void startApp() {
        try {
            InputStream is = this.getClass().getResourceAsStream("/song.mid");
            player = Manager.createPlayer(is, "audio/midi");
            player.setLoopCount(-1);
            player.start();
        }
        catch (IOException ioex) {
        }
        catch (MediaException mex) {
        }
        Display.getDisplay(this).setCurrent(introCanvas);
        try {
            Thread.sleep(IntroCanvas.timeSleep);
        } catch (InterruptedException ex) {
        }
        display = Display.getDisplay(this);
        sudokuCanvas.init();
        setCurrentSudokuCanvas();
    }

    public void pauseApp() {
    }

    public void destroyApp(boolean unconditional) {
        try {
            player.stop();
            player.close();
        } catch (MediaException ex) {
            ex.printStackTrace();
        }
    }
    
    public void setCurrentSudokuCanvas() {
        display.setCurrent(sudokuCanvas);
    }
    
    public void setCurrentMainMenu() {
        display.setCurrent(mainMenu.getDisplayable());
    }
    
    public void setCurrentGameMenu() {
        display.setCurrent(gameMenu.getDisplayable());
    }
    
    public void setCurrentNewGameMenu() {
        display.setCurrent(newGameMenu.getDisplayable());
    }
    
    public void setCurrentLoadGameMenu() {
        display.setCurrent(loadGameMenu.getDisplayable());
    }
    
    public void setCurrentSaveGameMenu() {
        display.setCurrent(saveGameMenu.getDisplayable());
    }
    
    public void setCurrentSudokuAlert() {
        display.setCurrent(sudokuAlert);
    }
    
    public void setCurrentSaveHighScoreMenu() {
        display.setCurrent(saveHighScoreMenu.getDisplayable());
    }
    
    public void setCurrentLoadHighScoreMenu() {
        display.setCurrent(loadHighScoreMenu.getDisplayable());
    }
    
    public void exit() {
        destroyApp(true);
        notifyDestroyed();
    }
}
