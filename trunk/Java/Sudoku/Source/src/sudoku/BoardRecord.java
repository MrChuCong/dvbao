package sudoku;

import java.util.Vector;
import javax.microedition.rms.*;

public class BoardRecord {
    
    private static final String RSNAME = "db_Sudoku";
    private static BoardRecord boardRecord = null;
    private Vector records = new Vector();
    
    private BoardRecord() {
    }
    
    public Vector getRecords() {
        return records;
    }
    
    public void init() {
        try {
            RecordStore recordStore = RecordStore.openRecordStore(RSNAME, true);
            int count = recordStore.getNumRecords();
            records.removeAllElements();
            for (int i=1; i<=count; i++) {
                byte[] record = recordStore.getRecord(i);
                String string = new String(record, 0, record.length);
                int index = string.indexOf(":");
                records.addElement(new String[] {
                    string.substring(0, index),
                    string.substring(index + 1, index + 6),
                    string.substring(index + 7)
                });
            }
            recordStore.closeRecordStore();
        }
        catch (RecordStoreException ex) {
        }
    }
    
    public void save(String name, String time, Board board) {
        records.addElement(new String[] {
            name,
            time,
            board.getString()
        });
        update();
    }
    
    public void delete(String name) {
        int index = -1;
        for (int i=0; i<records.size(); i++)
            if (name.equals(((String[])records.elementAt(i))[0])) {
                index = i;
                break;
            }
        if (index != -1) {
            records.removeElementAt(index);
            update();
        }
    }
    
    public void deleteAll() {
        records.removeAllElements();
        update();
    }
    
    private void update() {
        try {
            RecordStore.deleteRecordStore(RSNAME);
            if (records.size() > 0) {
                RecordStore recordStore = RecordStore.openRecordStore(RSNAME, true);
                for (int i=0; i<records.size(); i++) {
                    String[] record = (String[])records.elementAt(i);
                    byte[] bytes = (record[0] + ":" + record[1] + ":" +
                        record[2]).getBytes();
                    recordStore.addRecord(bytes, 0, bytes.length);
                }
                recordStore.closeRecordStore();
            }
        }
        catch (RecordStoreException ex) {
        }
    }
    
    public static BoardRecord Create() {
        if (boardRecord == null) boardRecord = new BoardRecord();
        return boardRecord;
    }
}
