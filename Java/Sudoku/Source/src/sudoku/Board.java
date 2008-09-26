package sudoku;

import java.util.*;
import javax.microedition.lcdui.*;

public class Board {
    
    public static final int PLAYMODE = 0;
    public static final int CREATEMODE = 1;
    private SudokuMidlet midlet;
    private int mode = PLAYMODE;
    private int cellSize = 24;
    private int spaceSize = 5;
    private int currentStateIndex = 0;
    private Cell[][] cells = new Cell[9][9];
    private Cell currentCell = null;
    private Vector states = new Vector();
    private Random random = new Random(System.currentTimeMillis());
    private Image image;
    
    public Board(SudokuMidlet midlet) {
        this.midlet = midlet;
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                cells[i][j] = new Cell(i, j, cellSize, spaceSize);
        create(1);
    }
    
    public void paint(Graphics graphics, int width, int height) {
        int dx = (width - cellSize * 9 - spaceSize * 2) / 2;
        int dy = (height - cellSize * 9 - spaceSize * 2) / 2 + 20;
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                cells[i][j].paint(graphics, dx, dy);
    }

    public void create(int level) {
        image = SudokuImages.Themes[random.nextInt(SudokuImages.Themes.length)];
        int[][] board = SudokuSolver.generate(level);
        if (level == 0) mode = CREATEMODE;
        else mode = PLAYMODE;
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) {
                cells[i][j].setValue(board[i][j]);
                cells[i][j].setSelected(false);
                cells[i][j].setValid(true);
                if (board[i][j] == 0) cells[i][j].setLocked(false);
                else cells[i][j].setLocked(true);
            }
        initStates();
        setCurrentCell(4, 4);
    }
    
    public void undo() {
        if (currentStateIndex - 1 < 0) return;
        currentStateIndex--;
        int[][] state = (int[][])states.elementAt(currentStateIndex);
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) {
                cells[i][j].setValue(state[i][j]);
                if (mode == CREATEMODE) cells[i][j].setLocked(state[i][j] != 0);
            }
        check();
    }
    
    public void redo() {
        if (currentStateIndex + 1 == states.size()) return;
        currentStateIndex++;
        int[][] state = (int[][])states.elementAt(currentStateIndex);
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) {
                cells[i][j].setValue(state[i][j]);
                if (mode == CREATEMODE) cells[i][j].setLocked(state[i][j] != 0);
            }
        check();
    }
    
    public void save(String name, String time) {
        BoardRecord.Create().save(name, time, this);
    }
    
    private void initStates() {
        currentStateIndex = 0;
        states.removeAllElements();
        saveState();
    }
    
    private void saveState() {
        if (currentStateIndex + 1 < states.size()) {
            states.setSize(currentStateIndex + 1);
        }
        int[][] state = new int[9][9];
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                state[i][j] = cells[i][j].getValue();
        currentStateIndex = states.size();
        states.addElement(state);
    }
    
    public Image getImage() {
        return image;
    }
    
    public int getMode() {
        return mode;
    }
    
    public Cell getCurrentCell() {
        return currentCell;
    }
    
    public void setCurrentCell(int row, int column) {
        if (currentCell != null) currentCell.setSelected(false);
        currentCell = cells[row][column];
        currentCell.setSelected(true);
    }
    
    public void setCellValue(int value) {
        if (mode == PLAYMODE) {
            if (currentCell.getLocked() ||
            currentCell.getValue() == value) return;
        }
        else {
            currentCell.setLocked(value != 0);
            if (currentCell.getValue() == value) return;
        }
        currentCell.setValue(value);
        saveState();
        check();
        if (finish()) {
            midlet.getSudokuCanvas().pause();
            midlet.getSudokuAlert().setAlert(
                SudokuImages.Congratulations,
                midlet.getSudokuCanvas());
            midlet.setCurrentSudokuAlert();
        }
    }
    
    private boolean finish() {
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                if (cells[i][j].getValue() == 0 ||
                    !cells[i][j].getValid()) return false;
        return true;
    }
    
    public String getString() {
        String string = "";
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) {
                string += cells[i][j].getValue();
                if (cells[i][j].getLocked()) string += "0";
                else string += "1";
            }
        return string;
    }
    
    public void reset() {
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                if (!cells[i][j].getLocked())
                    cells[i][j].setValue(0);
        check();
        initStates();
    }
    
    public void reset(String time, String board) {
        midlet.getSudokuCanvas().setCurrentTime(time);
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) {
                int value = board.charAt(i * 18 + j * 2) - '0';
                char locked = board.charAt(i * 18 + j * 2 + 1);
                cells[i][j].setValue(value);
                cells[i][j].setSelected(false);
                cells[i][j].setLocked(locked == '0');
            }
        check();
        initStates();
        setCurrentCell(4, 4);
    }
    
    private void check() {
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                cells[i][j].setValid(true);
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                if (cells[i][j].getValue() != 0) {
                    checkRow(cells[i][j], i);
                    checkColumn(cells[i][j], j);
                    checkBlock(cells[i][j], cells[i][j].getBlock());
                }
    }
    
    private void checkRow(Cell cell, int row) {
        boolean valid = true;
        for (int column=0; column<9; column++)
            if (column != cell.getColumn() &&
                cells[row][column].getValue() == cell.getValue()) {
                valid = false;
                cells[row][column].setValid(false);
            }
        if (!valid) cell.setValid(false);
    }
    
    private void checkColumn(Cell cell, int column) {
        boolean valid = true;
        for (int row=0; row<9; row++)
            if (row != cell.getRow() &&
                cells[row][column].getValue() == cell.getValue()) {
                valid = false;
                cells[row][column].setValid(false);
            }
        if (!valid) cell.setValid(false);
    }
    
    private void checkBlock(Cell cell, int block) {
        boolean valid = true;
        for (int row=0; row<9; row++)
            for (int column=0; column<9; column++)
                if (cells[row][column].getBlock() == block &&
                    row != cell.getRow() && column != cell.getColumn() &&
                    cells[row][column].getValue() == cell.getValue()) {
                    valid = false;
                    cells[row][column].setValid(false);
                }
        if (!valid) cell.setValid(false);
    }
    
    public boolean solve() {
        boolean result = SudokuSolver.solve(cells);
        if (result) saveState();
        return result;
    }
}
