package sudoku;

import java.util.Random;
import java.util.Vector;

public class SudokuSolver {
    
    private static int[][] cells = new int[9][9];
    private static Random random = new Random();
    private static boolean[][] rows = new boolean[9][10];
    private static boolean[][] columns = new boolean[9][10];
    private static boolean[][] blocks = new boolean[9][10];
    
    public static int getBlock(int x, int y) {
        return (x / 3) * 3 + (y / 3);
    }
    
    public static int[][] generate(int level) {
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) cells[i][j] = 0;
        if (level == 0) return cells;
        for (int i=0; i<9; i++)
            for (int j=0; j<10; j++)
                rows[i][j] = columns[i][j] = blocks[i][j] = false;
        findRandom(0, 0);
        for (int i=0; i<9; i++) {
            Vector vector = new Vector();
            for (int j=0; j<9; j++) vector.addElement(new Integer(j));
            int count = (6 - level) + random.nextInt(3);
            while (count > 0) {
                Integer value = (Integer)vector.elementAt(
                        random.nextInt(vector.size()));
                cells[i][value.intValue()] = 0;
                vector.removeElement(value);
                count--;
            }
        }
        return cells;
    }
    
    public static boolean solve(Cell[][] board) {
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++) cells[i][j] = board[i][j].getValue();
        for (int i=0; i<9; i++)
            for (int j=0; j<10; j++)
                rows[i][j] = columns[i][j] = blocks[i][j] = false;
        for (int i=0; i<9; i++)
            for (int j=0; j<9; j++)
                if (cells[i][j] != 0) {
                    if (!rows[i][cells[i][j]] &&
                        !columns[j][cells[i][j]] &&
                        !blocks[getBlock(i, j)][cells[i][j]]) {
                        rows[i][cells[i][j]] = true;
                        columns[j][cells[i][j]] = true;
                        blocks[getBlock(i, j)][cells[i][j]] = true;
                    }
                    else return false;
                }
        boolean result = find(0, 0);
        if (result) {
            for (int i=0; i<9; i++)
                for (int j=0; j<9; j++) board[i][j].setValue(cells[i][j]);
        }
        return result;
    }

    private static boolean findRandom(int x, int y) {
        if (y == 9) {
            x++;
            y = 0;
            if (x == 9) return true;
        }
        if (cells[x][y] != 0)
            return findRandom(x, y + 1);
        Vector nums = new Vector();
        for (int num=1; num<=9; num++)
            if (!rows[x][num] && !columns[y][num] &&
                !blocks[getBlock(x, y)][num])
                nums.addElement(new Integer(num));
        while (!nums.isEmpty()) {
            Integer num = (Integer)nums.elementAt(random.nextInt(nums.size()));
            cells[x][y] = num.intValue();
            rows[x][cells[x][y]] = true;
            columns[y][cells[x][y]] = true;
            blocks[getBlock(x, y)][cells[x][y]] = true;
            if (findRandom(x, y + 1)) return true;
            rows[x][cells[x][y]] = false;
            columns[y][cells[x][y]] = false;
            blocks[getBlock(x, y)][cells[x][y]] = false;
            nums.removeElement(num);
        }
        cells[x][y] = 0;
        return false;
    }
    
    private static boolean find(int x, int y) {
        if (y == 9) {
            x++;
            y = 0;
            if (x == 9) return true;
        }
        if (cells[x][y] != 0)
            return find(x, y + 1);
        for (int num=1; num<=9; num++)
            if (!rows[x][num] && !columns[y][num] &&
                !blocks[getBlock(x, y)][num]) {
                cells[x][y] = num;
                rows[x][cells[x][y]] = true;
                columns[y][cells[x][y]] = true;
                blocks[getBlock(x, y)][cells[x][y]] = true;
                if (find(x, y + 1)) return true;
                rows[x][cells[x][y]] = false;
                columns[y][cells[x][y]] = false;
                blocks[getBlock(x, y)][cells[x][y]] = false;
            }
        cells[x][y] = 0;
        return false;
    }
}
