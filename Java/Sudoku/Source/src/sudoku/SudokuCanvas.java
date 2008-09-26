package sudoku;

import javax.microedition.lcdui.*;

public class SudokuCanvas extends Canvas implements Runnable, CommandListener {
    
    private Board board;
    private SudokuMidlet midlet;
    private int minute = 0;
    private int second = 0;
    private boolean pause;
    
    public Board getBoard() {
        return board;
    }
    
    public SudokuCanvas(SudokuMidlet midlet) {
        this.midlet = midlet;
        this.board = new Board(midlet);
        addCommand(SudokuCommand.commandExit);
        addCommand(SudokuCommand.commandMenu);
        setCommandListener(this);
    }
    
    public void init() {
        pause = false;
        (new Thread(this)).start();
    }
    
    public synchronized void run() {
        while (!pause) {
            repaint();
            try {
                Thread.sleep(1000);
            }
            catch (InterruptedException ex) {
            }
            second++;
            if (second == 60) {
                minute++;
                if (minute == 60) minute = 0;
                second = 0;
            }
        }
    }
    
    public void pause() {
        if (board.getMode() == Board.CREATEMODE) return;
        pause = true;
    }
    
    public void resume() {
        if (board.getMode() == Board.CREATEMODE) return;
        if (pause) {
            pause = false;
            (new Thread(this)).start();
        }
    }
    
    public void resetTime() {
        minute = 0;
        second = 0;
    }
    
    public void paint(Graphics graphics) {
        int width = getWidth();
        int height = getHeight();
        graphics.drawImage(board.getImage(), 0, 0,
            Graphics.TOP | Graphics.LEFT);
        graphics.setColor(0, 0, 0);
        graphics.fillRect(0, 10, width, 28);
        int dx = (width - 130) / 2;
        String time = getCurrentTime();
        for (int i=0; i<time.length(); i++) {
            Image image;
            if (time.charAt(i) == ':') image = SudokuImages.Div;
            else image = SudokuImages.Digits[time.charAt(i) - '0'];
            graphics.drawImage(image, dx, 10,
                Graphics.TOP | Graphics.LEFT);
            dx += image.getWidth();
        }
        board.paint(graphics, width, height);
    }
    
    public String getCurrentTime() {
        String time = "";
        if (minute < 10) time += "0";
        time += minute + ":";
        if (second < 10) time += "0";
        time += second;
        return time;
    }
    
    public void setCurrentTime(String time) {
        minute = Integer.parseInt(time.substring(0, 2));
        second = Integer.parseInt(time.substring(3));
    }
    
    public void commandAction(Command command, Displayable displayable) {
        if (command == SudokuCommand.commandExit) {
            midlet.exit();
            return;
        }
        if (command == SudokuCommand.commandMenu) {
            pause();
            midlet.setCurrentMainMenu();
            return;
        }
    }
    
    protected  void keyPressed(int keyCode) {
        processKey(keyCode);
        repaint();
    }
    
    protected  void keyRepeated(int keyCode) {
        processKey(keyCode);
        repaint();
    }
    
    private void processKey(int keyCode) {
        String keyName = getKeyName(keyCode);
        Cell cell = board.getCurrentCell();
        if (keyName.equals("LEFT")) {
            if (cell.getColumn() - 1 >= 0) {
                board.setCurrentCell(cell.getRow(), cell.getColumn() - 1);
            }
            else {
                board.setCurrentCell(cell.getRow(), 8);
            }
            return;
        }
        if (keyName.equals("RIGHT")) {
            if (cell.getColumn() + 1 < 9) {
                board.setCurrentCell(cell.getRow(), cell.getColumn() + 1);
            }
            else {
                board.setCurrentCell(cell.getRow(), 0);
            }
            return;
        }
        if (keyName.equals("UP")) {
            if (cell.getRow() - 1 >= 0) {
                board.setCurrentCell(cell.getRow() - 1, cell.getColumn());
            }
            else {
                board.setCurrentCell(8, cell.getColumn());
            }
            return;
        }
        if (keyName.equals("DOWN")) {
            if (cell.getRow() + 1 < 9) {
                board.setCurrentCell(cell.getRow() + 1, cell.getColumn());
            }
            else {
                board.setCurrentCell(0, cell.getColumn());
            }
            return;
        }
        if (keyName.equals("1")) {
            board.setCellValue(1);
            return;
        }
        if (keyName.equals("2")) {
            board.setCellValue(2);
            return;
        }
        if (keyName.equals("3")) {
            board.setCellValue(3);
            return;
        }
        if (keyName.equals("4")) {
            board.setCellValue(4);
            return;
        }
        if (keyName.equals("5")) {
            board.setCellValue(5);
            return;
        }
        if (keyName.equals("6")) {
            board.setCellValue(6);
            return;
        }
        if (keyName.equals("7")) {
            board.setCellValue(7);
            return;
        }
        if (keyName.equals("8")) {
            board.setCellValue(8);
            return;
        }
        if (keyName.equals("9")) {
            board.setCellValue(9);
            return;
        }
        if (keyName.equals("0") || keyName.equals("SELECT")) {
            board.setCellValue(0);
            return;
        }
        if (keyName.equals("ASTERISK")) {
            board.undo();
            return;
        }
        if (keyName.equals("POUND")) {
            board.redo();
            return;
        }
    }
}