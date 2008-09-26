package sudoku;

import java.util.Vector;
import javax.microedition.rms.*;

public class HighScoreRecord {
    
    private static final String RSNAME = "db_SudokuHS";
    public static final int MAXHS = 10;
    private static HighScoreRecord highScoreRecord;
    private Vector records = new Vector();
    
    private HighScoreRecord() {
    }
    
    public Vector getRecords() {
        return records;
    }
    
    public static HighScoreRecord Create() {
        if (highScoreRecord == null) highScoreRecord = new HighScoreRecord();
        return highScoreRecord;
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
                    string.substring(index + 1)
                });
            }
            recordStore.closeRecordStore();
        }
        catch (RecordStoreException ex) {
        }
    }
    
    public void save(String name, String time) {
        if (records.size() == MAXHS) {
            records.removeElementAt(records.size() - 1);
        }
        records.addElement(new String[] {
            name,
            time
        });
        sort();
        update();
    }
    
    private void sort() {
        for (int i=0; i<records.size()-1; i++)
            for (int j=i+1; j<records.size(); j++) {
                String timei = ((String[])records.elementAt(i))[1];
                String timej = ((String[])records.elementAt(j))[1];
                if (timei.compareTo(timej) > 0) {
                    Object obj = records.elementAt(i);
                    records.setElementAt(records.elementAt(j), i);
                    records.setElementAt(obj, j);
                }
            }
    }
    
    private void update() {
        try {
            RecordStore.deleteRecordStore(RSNAME);
            if (records.size() > 0) {
                RecordStore recordStore = RecordStore.openRecordStore(RSNAME, true);
                for (int i=0; i<records.size(); i++) {
                    String[] record = (String[])records.elementAt(i);
                    byte[] bytes = (record[0] + ":" + record[1]).getBytes();
                    recordStore.addRecord(bytes, 0, bytes.length);
                }
                recordStore.closeRecordStore();
            }
        } catch (RecordStoreException ex) {
        }
    }
}
