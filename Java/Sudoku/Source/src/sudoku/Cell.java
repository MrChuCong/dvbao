package sudoku;

import javax.microedition.lcdui.*;

public class Cell {
    
    private int size;
    private int space;
    private int row;
    private int column;
    private int block;
    private int value = 0;
    private boolean selected = false;
    private boolean valid = true;
    private boolean locked = false;
    
    public int getRow() {
        return row;
    }
    
    public int getColumn() {
        return column;
    }
    
    public int getBlock() {
        return block;
    }
    
    public int getValue() {
        return value;
    }
    
    public void setValue(int value) {
        this.value = value;
    }
    
    public void setSelected(boolean selected) {
        this.selected = selected;
    }
    
    public boolean getValid() {
        return valid;
    }
    
    public void setValid(boolean valid) {
        this.valid = valid;
    }
    
    public boolean getLocked() {
        return locked;
    }
    
    public void setLocked(boolean locked) {
        this.locked = locked;
    }
    
    public Cell(int row, int column, int size, int space) {
        this.row = row;
        this.column = column;
        this.block = SudokuSolver.getBlock(row, column);
        this.size = size;
        this.space = space;
    }
    
    public void paint(Graphics graphics, int dx, int dy) {
        Image image = null;
        if (selected) image = SudokuImages.Cells[4];
        else {
            if (valid) {
                if (locked) image = SudokuImages.Cells[2];
                else image = SudokuImages.Cells[block % 2];
            }
            else image = SudokuImages.Cells[3];
        }
        graphics.drawImage(image,
            dx + column * size + (column / 3) * space,
            dy + row * size + (row / 3) * space,
            Graphics.TOP | Graphics.LEFT);
        if (value != 0) {
            graphics.drawImage(SudokuImages.CellDigits[value],
                dx + column * size + (column / 3) * space,
                dy + row * size + (row / 3) * space,
                Graphics.TOP | Graphics.LEFT);
        }
        graphics.setColor(0, 0, 0);
        graphics.drawRect(
            dx + column * size + (column / 3) * space,
            dy + row * size + (row / 3) * space,
            size, size);
    }
}
