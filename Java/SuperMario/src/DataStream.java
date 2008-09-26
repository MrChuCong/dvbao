import java.io.*;

public class DataStream extends DataInputStream {
	public DataStream (String path) {		
		super(path.getClass().getResourceAsStream(path));
	}
	
	public int ReadNextInt () {
		try {
			int a = readUnsignedByte();
			int b = readUnsignedByte();
			return (((b & 0xff) << 8) | (a & 0xff));
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		return 0;
	}
	
	public int ReadNextByte () {
		try {
			return readUnsignedByte();
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		return 0;
	}
}