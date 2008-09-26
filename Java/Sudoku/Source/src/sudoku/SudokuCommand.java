package sudoku;

import javax.microedition.lcdui.Command;

public class SudokuCommand {
    public static Command commandExit = new Command("Exit", Command.EXIT, 0);
    public static Command commandMenu = new Command("Menu", Command.ITEM, 0);
    public static Command commandSelect = new Command("Select", Command.ITEM, 0);
    public static Command commandBack = new Command("Back", Command.BACK, 0);
    public static Command commandDone = new Command("Done", Command.BACK, 0);
    public static Command commandOK = new Command("OK", Command.OK, 0);
    public static Command commandDelete = new Command("Delete", Command.ITEM, 1);
    public static Command commandErase = new Command("Delete All", Command.ITEM, 2);
}
