using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Unikey
{
    public class Vni : InputMethod
    {
        private static InputMethod inputMethod = null;
        private static Hashtable VietnameseCode = new Hashtable();

        private Vni() { }

        public static InputMethod Create()
        {
            if (inputMethod == null) inputMethod = new Vni();
            return inputMethod;
        }

        protected override string GetVNChar()
        {
            return "ADEIOUY123456789";
        }

        protected override Hashtable GetVietnameseCode()
        {
            return VietnameseCode;
        }

        public static void Init()
        {
            VietnameseCode['a'] = new VnCode[] {
				new VnCode('1', "á"),
				new VnCode('2', "à"),
				new VnCode('3', "ả"),
				new VnCode('4', "ã"),
				new VnCode('5', "ạ"),
				new VnCode('6', "â"),
				new VnCode('8', "ă"),
			};
            VietnameseCode['á'] = new VnCode[] {
				new VnCode('1', "a1"),
				new VnCode('2', "à"),
				new VnCode('3', "ả"),
				new VnCode('4', "ã"),
				new VnCode('5', "ạ"),
				new VnCode('6', "ấ"),
				new VnCode('8', "ắ"),
			};
            VietnameseCode['à'] = new VnCode[] {
				new VnCode('1', "á"),
				new VnCode('2', "a2"),
				new VnCode('3', "ả"),
				new VnCode('4', "ã"),
				new VnCode('5', "ạ"),
				new VnCode('6', "ầ"),
				new VnCode('8', "ằ"),
			};
            VietnameseCode['ả'] = new VnCode[] {
				new VnCode('1', "á"),
				new VnCode('2', "à"),
				new VnCode('3', "a3"),
				new VnCode('4', "ã"),
				new VnCode('5', "ạ"),
				new VnCode('6', "ẩ"),
				new VnCode('8', "ẳ"),
			};
            VietnameseCode['ã'] = new VnCode[] {
				new VnCode('1', "á"),
				new VnCode('2', "à"),
				new VnCode('3', "ả"),
				new VnCode('4', "a4"),
				new VnCode('5', "ạ"),
				new VnCode('6', "ẫ"),
				new VnCode('8', "ẵ"),
			};
            VietnameseCode['ạ'] = new VnCode[] {
				new VnCode('1', "á"),
				new VnCode('2', "à"),
				new VnCode('3', "ả"),
				new VnCode('4', "ã"),
				new VnCode('5', "a5"),
				new VnCode('6', "ậ"),
				new VnCode('8', "ặ"),
			};
            VietnameseCode['â'] = new VnCode[] {
				new VnCode('1', "ấ"),
				new VnCode('2', "ầ"),
				new VnCode('3', "ẩ"),
				new VnCode('4', "ẫ"),
				new VnCode('5', "ậ"),
				new VnCode('6', "a6"),
				new VnCode('8', "ă"),
			};
            VietnameseCode['ấ'] = new VnCode[] {
				new VnCode('1', "â1"),
				new VnCode('2', "ầ"),
				new VnCode('3', "ẩ"),
				new VnCode('4', "ẫ"),
				new VnCode('5', "ậ"),
				new VnCode('6', "á6"),
				new VnCode('8', "ắ"),
			};
            VietnameseCode['ầ'] = new VnCode[] {
				new VnCode('1', "ấ"),
				new VnCode('2', "â2"),
				new VnCode('3', "ẩ"),
				new VnCode('4', "ẫ"),
				new VnCode('5', "ậ"),
				new VnCode('6', "à6"),
				new VnCode('8', "ằ"),
			};
            VietnameseCode['ẩ'] = new VnCode[] {
				new VnCode('1', "ấ"),
				new VnCode('2', "ầ"),
				new VnCode('3', "â3"),
				new VnCode('4', "ẫ"),
				new VnCode('5', "ậ"),
				new VnCode('6', "ả6"),
				new VnCode('8', "ẳ"),
			};
            VietnameseCode['ẫ'] = new VnCode[] {
				new VnCode('1', "ấ"),
				new VnCode('2', "ầ"),
				new VnCode('3', "ẩ"),
				new VnCode('4', "â4"),
				new VnCode('5', "ậ"),
				new VnCode('6', "ã6"),
				new VnCode('8', "ẵ"),
			};
            VietnameseCode['ậ'] = new VnCode[] {
				new VnCode('1', "ấ"),
				new VnCode('2', "ầ"),
				new VnCode('3', "ẩ"),
				new VnCode('4', "ẫ"),
				new VnCode('5', "â5"),
				new VnCode('6', "ạ6"),
				new VnCode('8', "ặ"),
			};
            VietnameseCode['ă'] = new VnCode[] {
				new VnCode('1', "ắ"),
				new VnCode('2', "ằ"),
				new VnCode('3', "ẳ"),
				new VnCode('4', "ẵ"),
				new VnCode('5', "ặ"),
				new VnCode('6', "â"),
				new VnCode('8', "a8"),
			};
            VietnameseCode['ắ'] = new VnCode[] {
				new VnCode('1', "ă1"),
				new VnCode('2', "ằ"),
				new VnCode('3', "ẳ"),
				new VnCode('4', "ẵ"),
				new VnCode('5', "ặ"),
				new VnCode('6', "ấ"),
				new VnCode('8', "á8"),
			};
            VietnameseCode['ằ'] = new VnCode[] {
				new VnCode('1', "ắ"),
				new VnCode('2', "ă2"),
				new VnCode('3', "ẳ"),
				new VnCode('4', "ẵ"),
				new VnCode('5', "ặ"),
				new VnCode('6', "ầ"),
				new VnCode('8', "à8"),
			};
            VietnameseCode['ẳ'] = new VnCode[] {
				new VnCode('1', "ắ"),
				new VnCode('2', "ằ"),
				new VnCode('3', "ă3"),
				new VnCode('4', "ẵ"),
				new VnCode('5', "ặ"),
				new VnCode('6', "ẩ"),
				new VnCode('8', "ả8"),
			};
            VietnameseCode['ẵ'] = new VnCode[] {
				new VnCode('1', "ắ"),
				new VnCode('2', "ằ"),
				new VnCode('3', "ẳ"),
				new VnCode('4', "ă4"),
				new VnCode('5', "ặ"),
				new VnCode('6', "ẫ"),
				new VnCode('8', "ã8"),
			};
            VietnameseCode['ặ'] = new VnCode[] {
				new VnCode('1', "ắ"),
				new VnCode('2', "ằ"),
				new VnCode('3', "ẳ"),
				new VnCode('4', "ẵ"),
				new VnCode('5', "ă5"),
				new VnCode('6', "ậ"),
				new VnCode('8', "ạ8"),
			};
            VietnameseCode['d'] = new VnCode[] {
				new VnCode('9', "đ"),
			};
            VietnameseCode['đ'] = new VnCode[] {
				new VnCode('9', "d9"),
			};
            VietnameseCode['e'] = new VnCode[] {
				new VnCode('1', "é"),
				new VnCode('2', "è"),
				new VnCode('3', "ẻ"),
				new VnCode('4', "ẽ"),
				new VnCode('5', "ẹ"),
				new VnCode('6', "ê"),
			};
            VietnameseCode['é'] = new VnCode[] {
				new VnCode('1', "e1"),
				new VnCode('2', "è"),
				new VnCode('3', "ẻ"),
				new VnCode('4', "ẽ"),
				new VnCode('5', "ẹ"),
				new VnCode('6', "ế"),
			};
            VietnameseCode['è'] = new VnCode[] {
				new VnCode('1', "é"),
				new VnCode('2', "e2"),
				new VnCode('3', "ẻ"),
				new VnCode('4', "ẽ"),
				new VnCode('5', "ẹ"),
				new VnCode('6', "ề"),
			};
            VietnameseCode['ẻ'] = new VnCode[] {
				new VnCode('1', "é"),
				new VnCode('2', "è"),
				new VnCode('3', "e3"),
				new VnCode('4', "ẽ"),
				new VnCode('5', "ẹ"),
				new VnCode('6', "ể"),
			};
            VietnameseCode['ẽ'] = new VnCode[] {
				new VnCode('1', "é"),
				new VnCode('2', "è"),
				new VnCode('3', "ẻ"),
				new VnCode('4', "e4"),
				new VnCode('5', "ẹ"),
				new VnCode('6', "ễ"),
			};
            VietnameseCode['ẹ'] = new VnCode[] {
				new VnCode('1', "é"),
				new VnCode('2', "è"),
				new VnCode('3', "ẻ"),
				new VnCode('4', "ẽ"),
				new VnCode('5', "e5"),
				new VnCode('6', "ệ"),
			};
            VietnameseCode['ê'] = new VnCode[] {
				new VnCode('1', "ế"),
				new VnCode('2', "ề"),
				new VnCode('3', "ể"),
				new VnCode('4', "ễ"),
				new VnCode('5', "ệ"),
				new VnCode('6', "e6"),
			};
            VietnameseCode['ế'] = new VnCode[] {
				new VnCode('1', "ê1"),
				new VnCode('2', "ề"),
				new VnCode('3', "ể"),
				new VnCode('4', "ễ"),
				new VnCode('5', "ệ"),
				new VnCode('6', "é6"),
			};
            VietnameseCode['ề'] = new VnCode[] {
				new VnCode('1', "ế"),
				new VnCode('2', "ê2"),
				new VnCode('3', "ể"),
				new VnCode('4', "ễ"),
				new VnCode('5', "ệ"),
				new VnCode('6', "è6"),
			};
            VietnameseCode['ể'] = new VnCode[] {
				new VnCode('1', "ế"),
				new VnCode('2', "ề"),
				new VnCode('3', "ê3"),
				new VnCode('4', "ễ"),
				new VnCode('5', "ệ"),
				new VnCode('6', "ẻ6"),
			};
            VietnameseCode['ễ'] = new VnCode[] {
				new VnCode('1', "ế"),
				new VnCode('2', "ề"),
				new VnCode('3', "ể"),
				new VnCode('4', "ê4"),
				new VnCode('5', "ệ"),
				new VnCode('6', "ẽ6"),
			};
            VietnameseCode['ệ'] = new VnCode[] {
				new VnCode('1', "ế"),
				new VnCode('2', "ề"),
				new VnCode('3', "ể"),
				new VnCode('4', "ễ"),
				new VnCode('5', "ê5"),
				new VnCode('6', "ẹ6"),
			};
            VietnameseCode['i'] = new VnCode[] {
				new VnCode('1', "í"),
				new VnCode('2', "ì"),
				new VnCode('3', "ỉ"),
				new VnCode('4', "ĩ"),
				new VnCode('5', "ị"),
			};
            VietnameseCode['í'] = new VnCode[] {
				new VnCode('1', "i1"),
				new VnCode('2', "ì"),
				new VnCode('3', "ỉ"),
				new VnCode('4', "ĩ"),
				new VnCode('5', "ị"),
			};
            VietnameseCode['ì'] = new VnCode[] {
				new VnCode('1', "í"),
				new VnCode('2', "i2"),
				new VnCode('3', "ỉ"),
				new VnCode('4', "ĩ"),
				new VnCode('5', "ị"),
			};
            VietnameseCode['ỉ'] = new VnCode[] {
				new VnCode('1', "í"),
				new VnCode('2', "ì"),
				new VnCode('3', "i3"),
				new VnCode('4', "ĩ"),
				new VnCode('5', "ị"),
			};
            VietnameseCode['ĩ'] = new VnCode[] {
				new VnCode('1', "í"),
				new VnCode('2', "ì"),
				new VnCode('3', "ỉ"),
				new VnCode('4', "i4"),
				new VnCode('5', "ị"),
			};
            VietnameseCode['ị'] = new VnCode[] {
				new VnCode('1', "í"),
				new VnCode('2', "ì"),
				new VnCode('3', "ỉ"),
				new VnCode('4', "ĩ"),
				new VnCode('5', "i5"),
			};
            VietnameseCode['o'] = new VnCode[] {
				new VnCode('1', "ó"),
				new VnCode('2', "ò"),
				new VnCode('3', "ỏ"),
				new VnCode('4', "õ"),
				new VnCode('5', "ọ"),
				new VnCode('6', "ô"),
				new VnCode('7', "ơ"),
			};
            VietnameseCode['ó'] = new VnCode[] {
				new VnCode('1', "o1"),
				new VnCode('2', "ò"),
				new VnCode('3', "ỏ"),
				new VnCode('4', "õ"),
				new VnCode('5', "ọ"),
				new VnCode('6', "ố"),
				new VnCode('7', "ớ"),
			};
            VietnameseCode['ò'] = new VnCode[] {
				new VnCode('1', "ó"),
				new VnCode('2', "o2"),
				new VnCode('3', "ỏ"),
				new VnCode('4', "õ"),
				new VnCode('5', "ọ"),
				new VnCode('6', "ồ"),
				new VnCode('7', "ờ"),
			};
            VietnameseCode['ỏ'] = new VnCode[] {
				new VnCode('1', "ó"),
				new VnCode('2', "ò"),
				new VnCode('3', "o3"),
				new VnCode('4', "õ"),
				new VnCode('5', "ọ"),
				new VnCode('6', "ổ"),
				new VnCode('7', "ở"),
			};
            VietnameseCode['õ'] = new VnCode[] {
				new VnCode('1', "ó"),
				new VnCode('2', "ò"),
				new VnCode('3', "ỏ"),
				new VnCode('4', "o4"),
				new VnCode('5', "ọ"),
				new VnCode('6', "ỗ"),
				new VnCode('7', "ỡ"),
			};
            VietnameseCode['ọ'] = new VnCode[] {
				new VnCode('1', "ó"),
				new VnCode('2', "ò"),
				new VnCode('3', "ỏ"),
				new VnCode('4', "õ"),
				new VnCode('5', "o5"),
				new VnCode('6', "ộ"),
				new VnCode('7', "ợ"),
			};
            VietnameseCode['ô'] = new VnCode[] {
				new VnCode('1', "ố"),
				new VnCode('2', "ồ"),
				new VnCode('3', "ổ"),
				new VnCode('4', "ỗ"),
				new VnCode('5', "ộ"),
				new VnCode('6', "o6"),
				new VnCode('7', "ơ"),
			};
            VietnameseCode['ố'] = new VnCode[] {
				new VnCode('1', "ô1"),
				new VnCode('2', "ồ"),
				new VnCode('3', "ổ"),
				new VnCode('4', "ỗ"),
				new VnCode('5', "ộ"),
				new VnCode('6', "ó6"),
				new VnCode('7', "ớ"),
			};
            VietnameseCode['ồ'] = new VnCode[] {
				new VnCode('1', "ố"),
				new VnCode('2', "ô2"),
				new VnCode('3', "ổ"),
				new VnCode('4', "ỗ"),
				new VnCode('5', "ộ"),
				new VnCode('6', "ò6"),
				new VnCode('7', "ờ"),
			};
            VietnameseCode['ổ'] = new VnCode[] {
				new VnCode('1', "ố"),
				new VnCode('2', "ồ"),
				new VnCode('3', "ô3"),
				new VnCode('4', "ỗ"),
				new VnCode('5', "ộ"),
				new VnCode('6', "ỏ6"),
				new VnCode('7', "ở"),
			};
            VietnameseCode['ỗ'] = new VnCode[] {
				new VnCode('1', "ố"),
				new VnCode('2', "ồ"),
				new VnCode('3', "ổ"),
				new VnCode('4', "ô4"),
				new VnCode('5', "ộ"),
				new VnCode('6', "õ6"),
				new VnCode('7', "ỡ"),
			};
            VietnameseCode['ộ'] = new VnCode[] {
				new VnCode('1', "ố"),
				new VnCode('2', "ồ"),
				new VnCode('3', "ổ"),
				new VnCode('4', "ỗ"),
				new VnCode('5', "ô5"),
				new VnCode('6', "ọ6"),
				new VnCode('7', "ợ"),
			};
            VietnameseCode['ơ'] = new VnCode[] {
				new VnCode('1', "ớ"),
				new VnCode('2', "ờ"),
				new VnCode('3', "ở"),
				new VnCode('4', "ỡ"),
				new VnCode('5', "ợ"),
				new VnCode('6', "ô"),
				new VnCode('7', "o7"),
			};
            VietnameseCode['ớ'] = new VnCode[] {
				new VnCode('1', "ơ1"),
				new VnCode('2', "ờ"),
				new VnCode('3', "ở"),
				new VnCode('4', "ỡ"),
				new VnCode('5', "ợ"),
				new VnCode('6', "ố"),
				new VnCode('7', "ó7"),
			};
            VietnameseCode['ờ'] = new VnCode[] {
				new VnCode('1', "ớ"),
				new VnCode('2', "ơ2"),
				new VnCode('3', "ở"),
				new VnCode('4', "ỡ"),
				new VnCode('5', "ợ"),
				new VnCode('6', "ồ"),
				new VnCode('7', "ò7"),
			};
            VietnameseCode['ở'] = new VnCode[] {
				new VnCode('1', "ớ"),
				new VnCode('2', "ờ"),
				new VnCode('3', "ơ3"),
				new VnCode('4', "ỡ"),
				new VnCode('5', "ợ"),
				new VnCode('6', "ổ"),
				new VnCode('7', "ỏ7"),
			};
            VietnameseCode['ỡ'] = new VnCode[] {
				new VnCode('1', "ớ"),
				new VnCode('2', "ờ"),
				new VnCode('3', "ở"),
				new VnCode('4', "ơ4"),
				new VnCode('5', "ợ"),
				new VnCode('6', "ỗ"),
				new VnCode('7', "õ7"),
			};
            VietnameseCode['ợ'] = new VnCode[] {
				new VnCode('1', "ớ"),
				new VnCode('2', "ờ"),
				new VnCode('3', "ở"),
				new VnCode('4', "ỡ"),
				new VnCode('5', "ơ5"),
				new VnCode('6', "ộ"),
				new VnCode('7', "ọ7"),
			};
            VietnameseCode['u'] = new VnCode[] {
				new VnCode('1', "ú"),
				new VnCode('2', "ù"),
				new VnCode('3', "ủ"),
				new VnCode('4', "ũ"),
				new VnCode('5', "ụ"),
				new VnCode('7', "ư"),
			};
            VietnameseCode['ú'] = new VnCode[] {
				new VnCode('1', "u1"),
				new VnCode('2', "ù"),
				new VnCode('3', "ủ"),
				new VnCode('4', "ũ"),
				new VnCode('5', "ụ"),
				new VnCode('7', "ứ"),
			};
            VietnameseCode['ù'] = new VnCode[] {
				new VnCode('1', "ú"),
				new VnCode('2', "u2"),
				new VnCode('3', "ủ"),
				new VnCode('4', "ũ"),
				new VnCode('5', "ụ"),
				new VnCode('7', "ừ"),
			};
            VietnameseCode['ủ'] = new VnCode[] {
				new VnCode('1', "ú"),
				new VnCode('2', "ù"),
				new VnCode('3', "u3"),
				new VnCode('4', "ũ"),
				new VnCode('5', "ụ"),
				new VnCode('7', "ử"),
			};
            VietnameseCode['ũ'] = new VnCode[] {
				new VnCode('1', "ú"),
				new VnCode('2', "ù"),
				new VnCode('3', "ủ"),
				new VnCode('4', "u4"),
				new VnCode('5', "ụ"),
				new VnCode('7', "ữ"),
			};
            VietnameseCode['ụ'] = new VnCode[] {
				new VnCode('1', "ú"),
				new VnCode('2', "ù"),
				new VnCode('3', "ủ"),
				new VnCode('4', "ũ"),
				new VnCode('5', "u5"),
				new VnCode('7', "ự"),
			};
            VietnameseCode['ư'] = new VnCode[] {
				new VnCode('1', "ứ"),
				new VnCode('2', "ừ"),
				new VnCode('3', "ử"),
				new VnCode('4', "ữ"),
				new VnCode('5', "ự"),
				new VnCode('7', "u7"),
			};
            VietnameseCode['ứ'] = new VnCode[] {
				new VnCode('1', "ư1"),
				new VnCode('2', "ừ"),
				new VnCode('3', "ử"),
				new VnCode('4', "ữ"),
				new VnCode('5', "ự"),
				new VnCode('7', "ú7"),
			};
            VietnameseCode['ừ'] = new VnCode[] {
				new VnCode('1', "ứ"),
				new VnCode('2', "ư2"),
				new VnCode('3', "ử"),
				new VnCode('4', "ữ"),
				new VnCode('5', "ự"),
				new VnCode('7', "ù7"),
			};
            VietnameseCode['ử'] = new VnCode[] {
				new VnCode('1', "ứ"),
				new VnCode('2', "ừ"),
				new VnCode('3', "ư3"),
				new VnCode('4', "ữ"),
				new VnCode('5', "ự"),
				new VnCode('7', "ủ7"),
			};
            VietnameseCode['ữ'] = new VnCode[] {
				new VnCode('1', "ứ"),
				new VnCode('2', "ừ"),
				new VnCode('3', "ử"),
				new VnCode('4', "ư4"),
				new VnCode('5', "ự"),
				new VnCode('7', "ũ7"),
			};
            VietnameseCode['ự'] = new VnCode[] {
				new VnCode('1', "ứ"),
				new VnCode('2', "ừ"),
				new VnCode('3', "ử"),
				new VnCode('4', "ữ"),
				new VnCode('5', "ư5"),
				new VnCode('7', "ụ7"),
			};
            VietnameseCode['y'] = new VnCode[] {
				new VnCode('1', "ý"),
				new VnCode('2', "ỳ"),
				new VnCode('3', "ỷ"),
				new VnCode('4', "ỹ"),
				new VnCode('5', "ỵ"),
			};
            VietnameseCode['ý'] = new VnCode[] {
				new VnCode('1', "y1"),
				new VnCode('2', "ỳ"),
				new VnCode('3', "ỷ"),
				new VnCode('4', "ỹ"),
				new VnCode('5', "ỵ"),
			};
            VietnameseCode['ỳ'] = new VnCode[] {
				new VnCode('1', "ý"),
				new VnCode('2', "y2"),
				new VnCode('3', "ỷ"),
				new VnCode('4', "ỹ"),
				new VnCode('5', "ỵ"),
			};
            VietnameseCode['ỷ'] = new VnCode[] {
				new VnCode('1', "ý"),
				new VnCode('2', "ỳ"),
				new VnCode('3', "y3"),
				new VnCode('4', "ỹ"),
				new VnCode('5', "ỵ"),
			};
            VietnameseCode['ỹ'] = new VnCode[] {
				new VnCode('1', "ý"),
				new VnCode('2', "ỳ"),
				new VnCode('3', "ỷ"),
				new VnCode('4', "y4"),
				new VnCode('5', "ỵ"),
			};
            VietnameseCode['ỵ'] = new VnCode[] {
				new VnCode('1', "ý"),
				new VnCode('2', "ỳ"),
				new VnCode('3', "ỷ"),
				new VnCode('4', "ỹ"),
				new VnCode('5', "y5"),
			};
            VietnameseCode['A'] = new VnCode[] {
				new VnCode('1', "Á"),
				new VnCode('2', "À"),
				new VnCode('3', "Ả"),
				new VnCode('4', "Ã"),
				new VnCode('5', "Ạ"),
				new VnCode('6', "Â"),
				new VnCode('8', "Ă"),
			};
            VietnameseCode['Á'] = new VnCode[] {
				new VnCode('1', "A1"),
				new VnCode('2', "À"),
				new VnCode('3', "Ả"),
				new VnCode('4', "Ã"),
				new VnCode('5', "Ạ"),
				new VnCode('6', "Ấ"),
				new VnCode('8', "Ắ"),
			};
            VietnameseCode['À'] = new VnCode[] {
				new VnCode('1', "Á"),
				new VnCode('2', "A2"),
				new VnCode('3', "Ả"),
				new VnCode('4', "Ã"),
				new VnCode('5', "Ạ"),
				new VnCode('6', "Ầ"),
				new VnCode('8', "Ằ"),
			};
            VietnameseCode['Ả'] = new VnCode[] {
				new VnCode('1', "Á"),
				new VnCode('2', "À"),
				new VnCode('3', "A3"),
				new VnCode('4', "Ã"),
				new VnCode('5', "Ạ"),
				new VnCode('6', "Ẩ"),
				new VnCode('8', "Ẳ"),
			};
            VietnameseCode['Ã'] = new VnCode[] {
				new VnCode('1', "Á"),
				new VnCode('2', "À"),
				new VnCode('3', "Ả"),
				new VnCode('4', "A4"),
				new VnCode('5', "Ạ"),
				new VnCode('6', "Ẫ"),
				new VnCode('8', "Ẵ"),
			};
            VietnameseCode['Ạ'] = new VnCode[] {
				new VnCode('1', "Á"),
				new VnCode('2', "À"),
				new VnCode('3', "Ả"),
				new VnCode('4', "Ã"),
				new VnCode('5', "A5"),
				new VnCode('6', "Ậ"),
				new VnCode('8', "Ặ"),
			};
            VietnameseCode['Â'] = new VnCode[] {
				new VnCode('1', "Ấ"),
				new VnCode('2', "Ầ"),
				new VnCode('3', "Ẩ"),
				new VnCode('4', "Ẫ"),
				new VnCode('5', "Ậ"),
				new VnCode('6', "A6"),
				new VnCode('8', "Ă"),
			};
            VietnameseCode['Ấ'] = new VnCode[] {
				new VnCode('1', "Â1"),
				new VnCode('2', "Ầ"),
				new VnCode('3', "Ẩ"),
				new VnCode('4', "Ẫ"),
				new VnCode('5', "Ậ"),
				new VnCode('6', "Á6"),
				new VnCode('8', "Ắ"),
			};
            VietnameseCode['Ầ'] = new VnCode[] {
				new VnCode('1', "Ấ"),
				new VnCode('2', "Â2"),
				new VnCode('3', "Ẩ"),
				new VnCode('4', "Ẫ"),
				new VnCode('5', "Ậ"),
				new VnCode('6', "À6"),
				new VnCode('8', "Ằ"),
			};
            VietnameseCode['Ẩ'] = new VnCode[] {
				new VnCode('1', "Ấ"),
				new VnCode('2', "Ầ"),
				new VnCode('3', "Â3"),
				new VnCode('4', "Ẫ"),
				new VnCode('5', "Ậ"),
				new VnCode('6', "Ả6"),
				new VnCode('8', "Ẳ"),
			};
            VietnameseCode['Ẫ'] = new VnCode[] {
				new VnCode('1', "Ấ"),
				new VnCode('2', "Ầ"),
				new VnCode('3', "Ẩ"),
				new VnCode('4', "Â4"),
				new VnCode('5', "Ậ"),
				new VnCode('6', "Ã6"),
				new VnCode('8', "Ẵ"),
			};
            VietnameseCode['Ậ'] = new VnCode[] {
				new VnCode('1', "Ấ"),
				new VnCode('2', "Ầ"),
				new VnCode('3', "Ẩ"),
				new VnCode('4', "Ẫ"),
				new VnCode('5', "Â5"),
				new VnCode('6', "Ạ6"),
				new VnCode('8', "Ặ"),
			};
            VietnameseCode['Ă'] = new VnCode[] {
				new VnCode('1', "Ắ"),
				new VnCode('2', "Ằ"),
				new VnCode('3', "Ẳ"),
				new VnCode('4', "Ẵ"),
				new VnCode('5', "Ặ"),
				new VnCode('6', "Â"),
				new VnCode('8', "A8"),
			};
            VietnameseCode['Ắ'] = new VnCode[] {
				new VnCode('1', "Ă1"),
				new VnCode('2', "Ằ"),
				new VnCode('3', "Ẳ"),
				new VnCode('4', "Ẵ"),
				new VnCode('5', "Ặ"),
				new VnCode('6', "Ấ"),
				new VnCode('8', "Á8"),
			};
            VietnameseCode['Ằ'] = new VnCode[] {
				new VnCode('1', "Ắ"),
				new VnCode('2', "Ă2"),
				new VnCode('3', "Ẳ"),
				new VnCode('4', "Ẵ"),
				new VnCode('5', "Ặ"),
				new VnCode('6', "Ầ"),
				new VnCode('8', "À8"),
			};
            VietnameseCode['Ẳ'] = new VnCode[] {
				new VnCode('1', "Ắ"),
				new VnCode('2', "Ằ"),
				new VnCode('3', "Ă3"),
				new VnCode('4', "Ẵ"),
				new VnCode('5', "Ặ"),
				new VnCode('6', "Ẩ"),
				new VnCode('8', "Ả8"),
			};
            VietnameseCode['Ẵ'] = new VnCode[] {
				new VnCode('1', "Ắ"),
				new VnCode('2', "Ằ"),
				new VnCode('3', "Ẳ"),
				new VnCode('4', "Ă4"),
				new VnCode('5', "Ặ"),
				new VnCode('6', "Ẫ"),
				new VnCode('8', "Ã8"),
			};
            VietnameseCode['Ặ'] = new VnCode[] {
				new VnCode('1', "Ắ"),
				new VnCode('2', "Ằ"),
				new VnCode('3', "Ẳ"),
				new VnCode('4', "Ẵ"),
				new VnCode('5', "Ă5"),
				new VnCode('6', "Ậ"),
				new VnCode('8', "Ạ8"),
			};
            VietnameseCode['D'] = new VnCode[] {
				new VnCode('9', "Đ"),
			};
            VietnameseCode['Đ'] = new VnCode[] {
				new VnCode('9', "D9"),
			};
            VietnameseCode['E'] = new VnCode[] {
				new VnCode('1', "É"),
				new VnCode('2', "È"),
				new VnCode('3', "Ẻ"),
				new VnCode('4', "Ẽ"),
				new VnCode('5', "Ẹ"),
				new VnCode('6', "Ê"),
			};
            VietnameseCode['É'] = new VnCode[] {
				new VnCode('1', "E1"),
				new VnCode('2', "È"),
				new VnCode('3', "Ẻ"),
				new VnCode('4', "Ẽ"),
				new VnCode('5', "Ẹ"),
				new VnCode('6', "Ế"),
			};
            VietnameseCode['È'] = new VnCode[] {
				new VnCode('1', "É"),
				new VnCode('2', "E2"),
				new VnCode('3', "Ẻ"),
				new VnCode('4', "Ẽ"),
				new VnCode('5', "Ẹ"),
				new VnCode('6', "Ề"),
			};
            VietnameseCode['Ẻ'] = new VnCode[] {
				new VnCode('1', "É"),
				new VnCode('2', "È"),
				new VnCode('3', "E3"),
				new VnCode('4', "Ẽ"),
				new VnCode('5', "Ẹ"),
				new VnCode('6', "Ể"),
			};
            VietnameseCode['Ẽ'] = new VnCode[] {
				new VnCode('1', "É"),
				new VnCode('2', "È"),
				new VnCode('3', "Ẻ"),
				new VnCode('4', "E4"),
				new VnCode('5', "Ẹ"),
				new VnCode('6', "Ễ"),
			};
            VietnameseCode['Ẹ'] = new VnCode[] {
				new VnCode('1', "É"),
				new VnCode('2', "È"),
				new VnCode('3', "Ẻ"),
				new VnCode('4', "Ẽ"),
				new VnCode('5', "E5"),
				new VnCode('6', "Ệ"),
			};
            VietnameseCode['Ê'] = new VnCode[] {
				new VnCode('1', "Ế"),
				new VnCode('2', "Ề"),
				new VnCode('3', "Ể"),
				new VnCode('4', "Ễ"),
				new VnCode('5', "Ệ"),
				new VnCode('6', "E6"),
			};
            VietnameseCode['Ế'] = new VnCode[] {
				new VnCode('1', "Ê1"),
				new VnCode('2', "Ề"),
				new VnCode('3', "Ể"),
				new VnCode('4', "Ễ"),
				new VnCode('5', "Ệ"),
				new VnCode('6', "É6"),
			};
            VietnameseCode['Ề'] = new VnCode[] {
				new VnCode('1', "Ế"),
				new VnCode('2', "Ê2"),
				new VnCode('3', "Ể"),
				new VnCode('4', "Ễ"),
				new VnCode('5', "Ệ"),
				new VnCode('6', "È6"),
			};
            VietnameseCode['Ể'] = new VnCode[] {
				new VnCode('1', "Ế"),
				new VnCode('2', "Ề"),
				new VnCode('3', "Ê3"),
				new VnCode('4', "Ễ"),
				new VnCode('5', "Ệ"),
				new VnCode('6', "Ẻ6"),
			};
            VietnameseCode['Ễ'] = new VnCode[] {
				new VnCode('1', "Ế"),
				new VnCode('2', "Ề"),
				new VnCode('3', "Ể"),
				new VnCode('4', "Ê4"),
				new VnCode('5', "Ệ"),
				new VnCode('6', "Ẽ6"),
			};
            VietnameseCode['Ệ'] = new VnCode[] {
				new VnCode('1', "Ế"),
				new VnCode('2', "Ề"),
				new VnCode('3', "Ể"),
				new VnCode('4', "Ễ"),
				new VnCode('5', "Ê5"),
				new VnCode('6', "Ẹ6"),
			};
            VietnameseCode['I'] = new VnCode[] {
				new VnCode('1', "Í"),
				new VnCode('2', "Ì"),
				new VnCode('3', "Ỉ"),
				new VnCode('4', "Ĩ"),
				new VnCode('5', "Ị"),
			};
            VietnameseCode['Í'] = new VnCode[] {
				new VnCode('1', "I1"),
				new VnCode('2', "Ì"),
				new VnCode('3', "Ỉ"),
				new VnCode('4', "Ĩ"),
				new VnCode('5', "Ị"),
			};
            VietnameseCode['Ì'] = new VnCode[] {
				new VnCode('1', "Í"),
				new VnCode('2', "I2"),
				new VnCode('3', "Ỉ"),
				new VnCode('4', "Ĩ"),
				new VnCode('5', "Ị"),
			};
            VietnameseCode['Ỉ'] = new VnCode[] {
				new VnCode('1', "Í"),
				new VnCode('2', "Ì"),
				new VnCode('3', "I3"),
				new VnCode('4', "Ĩ"),
				new VnCode('5', "Ị"),
			};
            VietnameseCode['Ĩ'] = new VnCode[] {
				new VnCode('1', "Í"),
				new VnCode('2', "Ì"),
				new VnCode('3', "Ỉ"),
				new VnCode('4', "I4"),
				new VnCode('5', "Ị"),
			};
            VietnameseCode['Ị'] = new VnCode[] {
				new VnCode('1', "Í"),
				new VnCode('2', "Ì"),
				new VnCode('3', "Ỉ"),
				new VnCode('4', "Ĩ"),
				new VnCode('5', "I5"),
			};
            VietnameseCode['O'] = new VnCode[] {
				new VnCode('1', "Ó"),
				new VnCode('2', "Ò"),
				new VnCode('3', "Ỏ"),
				new VnCode('4', "Õ"),
				new VnCode('5', "Ọ"),
				new VnCode('6', "Ô"),
				new VnCode('7', "Ơ"),
			};
            VietnameseCode['Ó'] = new VnCode[] {
				new VnCode('1', "O1"),
				new VnCode('2', "Ò"),
				new VnCode('3', "Ỏ"),
				new VnCode('4', "Õ"),
				new VnCode('5', "Ọ"),
				new VnCode('6', "Ố"),
				new VnCode('7', "Ớ"),
			};
            VietnameseCode['Ò'] = new VnCode[] {
				new VnCode('1', "Ó"),
				new VnCode('2', "O2"),
				new VnCode('3', "Ỏ"),
				new VnCode('4', "Õ"),
				new VnCode('5', "Ọ"),
				new VnCode('6', "Ồ"),
				new VnCode('7', "Ờ"),
			};
            VietnameseCode['Ỏ'] = new VnCode[] {
				new VnCode('1', "Ó"),
				new VnCode('2', "Ò"),
				new VnCode('3', "O3"),
				new VnCode('4', "Õ"),
				new VnCode('5', "Ọ"),
				new VnCode('6', "Ổ"),
				new VnCode('7', "Ở"),
			};
            VietnameseCode['Õ'] = new VnCode[] {
				new VnCode('1', "Ó"),
				new VnCode('2', "Ò"),
				new VnCode('3', "Ỏ"),
				new VnCode('4', "O4"),
				new VnCode('5', "Ọ"),
				new VnCode('6', "Ỗ"),
				new VnCode('7', "Ỡ"),
			};
            VietnameseCode['Ọ'] = new VnCode[] {
				new VnCode('1', "Ó"),
				new VnCode('2', "Ò"),
				new VnCode('3', "Ỏ"),
				new VnCode('4', "Õ"),
				new VnCode('5', "O5"),
				new VnCode('6', "Ộ"),
				new VnCode('7', "Ợ"),
			};
            VietnameseCode['Ô'] = new VnCode[] {
				new VnCode('1', "Ố"),
				new VnCode('2', "Ồ"),
				new VnCode('3', "Ổ"),
				new VnCode('4', "Ỗ"),
				new VnCode('5', "Ộ"),
				new VnCode('6', "O6"),
				new VnCode('7', "Ơ"),
			};
            VietnameseCode['Ố'] = new VnCode[] {
				new VnCode('1', "Ô1"),
				new VnCode('2', "Ồ"),
				new VnCode('3', "Ổ"),
				new VnCode('4', "Ỗ"),
				new VnCode('5', "Ộ"),
				new VnCode('6', "Ó6"),
				new VnCode('7', "Ớ"),
			};
            VietnameseCode['Ồ'] = new VnCode[] {
				new VnCode('1', "Ố"),
				new VnCode('2', "Ô2"),
				new VnCode('3', "Ổ"),
				new VnCode('4', "Ỗ"),
				new VnCode('5', "Ộ"),
				new VnCode('6', "Ò6"),
				new VnCode('7', "Ờ"),
			};
            VietnameseCode['Ổ'] = new VnCode[] {
				new VnCode('1', "Ố"),
				new VnCode('2', "Ồ"),
				new VnCode('3', "Ô3"),
				new VnCode('4', "Ỗ"),
				new VnCode('5', "Ộ"),
				new VnCode('6', "Ỏ6"),
				new VnCode('7', "Ở"),
			};
            VietnameseCode['Ỗ'] = new VnCode[] {
				new VnCode('1', "Ố"),
				new VnCode('2', "Ồ"),
				new VnCode('3', "Ổ"),
				new VnCode('4', "Ô4"),
				new VnCode('5', "Ộ"),
				new VnCode('6', "Õ6"),
				new VnCode('7', "Ỡ"),
			};
            VietnameseCode['Ộ'] = new VnCode[] {
				new VnCode('1', "Ố"),
				new VnCode('2', "Ồ"),
				new VnCode('3', "Ổ"),
				new VnCode('4', "Ỗ"),
				new VnCode('5', "Ô5"),
				new VnCode('6', "Ọ6"),
				new VnCode('7', "Ợ"),
			};
            VietnameseCode['Ơ'] = new VnCode[] {
				new VnCode('1', "Ớ"),
				new VnCode('2', "Ờ"),
				new VnCode('3', "Ở"),
				new VnCode('4', "Ỡ"),
				new VnCode('5', "Ợ"),
				new VnCode('6', "Ô"),
				new VnCode('7', "O7"),
			};
            VietnameseCode['Ớ'] = new VnCode[] {
				new VnCode('1', "Ơ1"),
				new VnCode('2', "Ờ"),
				new VnCode('3', "Ở"),
				new VnCode('4', "Ỡ"),
				new VnCode('5', "Ợ"),
				new VnCode('6', "Ố"),
				new VnCode('7', "Ó7"),
			};
            VietnameseCode['Ờ'] = new VnCode[] {
				new VnCode('1', "Ớ"),
				new VnCode('2', "Ơ2"),
				new VnCode('3', "Ở"),
				new VnCode('4', "Ỡ"),
				new VnCode('5', "Ợ"),
				new VnCode('6', "Ồ"),
				new VnCode('7', "Ò7"),
			};
            VietnameseCode['Ở'] = new VnCode[] {
				new VnCode('1', "Ớ"),
				new VnCode('2', "Ờ"),
				new VnCode('3', "Ơ3"),
				new VnCode('4', "Ỡ"),
				new VnCode('5', "Ợ"),
				new VnCode('6', "Ổ"),
				new VnCode('7', "Ỏ7"),
			};
            VietnameseCode['Ỡ'] = new VnCode[] {
				new VnCode('1', "Ớ"),
				new VnCode('2', "Ờ"),
				new VnCode('3', "Ở"),
				new VnCode('4', "Ơ4"),
				new VnCode('5', "Ợ"),
				new VnCode('6', "Ỗ"),
				new VnCode('7', "Õ7"),
			};
            VietnameseCode['Ợ'] = new VnCode[] {
				new VnCode('1', "Ớ"),
				new VnCode('2', "Ờ"),
				new VnCode('3', "Ở"),
				new VnCode('4', "Ỡ"),
				new VnCode('5', "Ơ5"),
				new VnCode('6', "Ộ"),
				new VnCode('7', "Ọ7"),
			};
            VietnameseCode['U'] = new VnCode[] {
				new VnCode('1', "Ú"),
				new VnCode('2', "Ù"),
				new VnCode('3', "Ủ"),
				new VnCode('4', "Ũ"),
				new VnCode('5', "Ụ"),
				new VnCode('7', "Ư"),
			};
            VietnameseCode['Ú'] = new VnCode[] {
				new VnCode('1', "U1"),
				new VnCode('2', "Ù"),
				new VnCode('3', "Ủ"),
				new VnCode('4', "Ũ"),
				new VnCode('5', "Ụ"),
				new VnCode('7', "Ứ"),
			};
            VietnameseCode['Ù'] = new VnCode[] {
				new VnCode('1', "Ú"),
				new VnCode('2', "U2"),
				new VnCode('3', "Ủ"),
				new VnCode('4', "Ũ"),
				new VnCode('5', "Ụ"),
				new VnCode('7', "Ừ"),
			};
            VietnameseCode['Ủ'] = new VnCode[] {
				new VnCode('1', "Ú"),
				new VnCode('2', "Ù"),
				new VnCode('3', "U3"),
				new VnCode('4', "Ũ"),
				new VnCode('5', "Ụ"),
				new VnCode('7', "Ử"),
			};
            VietnameseCode['Ũ'] = new VnCode[] {
				new VnCode('1', "Ú"),
				new VnCode('2', "Ù"),
				new VnCode('3', "Ủ"),
				new VnCode('4', "U4"),
				new VnCode('5', "Ụ"),
				new VnCode('7', "Ữ"),
			};
            VietnameseCode['Ụ'] = new VnCode[] {
				new VnCode('1', "Ú"),
				new VnCode('2', "Ù"),
				new VnCode('3', "Ủ"),
				new VnCode('4', "Ũ"),
				new VnCode('5', "U5"),
				new VnCode('7', "Ự"),
			};
            VietnameseCode['Ư'] = new VnCode[] {
				new VnCode('1', "Ứ"),
				new VnCode('2', "Ừ"),
				new VnCode('3', "Ử"),
				new VnCode('4', "Ữ"),
				new VnCode('5', "Ự"),
				new VnCode('7', "U7"),
			};
            VietnameseCode['Ứ'] = new VnCode[] {
				new VnCode('1', "Ư1"),
				new VnCode('2', "Ừ"),
				new VnCode('3', "Ử"),
				new VnCode('4', "Ữ"),
				new VnCode('5', "Ự"),
				new VnCode('7', "Ú7"),
			};
            VietnameseCode['Ừ'] = new VnCode[] {
				new VnCode('1', "Ứ"),
				new VnCode('2', "Ư2"),
				new VnCode('3', "Ử"),
				new VnCode('4', "Ữ"),
				new VnCode('5', "Ự"),
				new VnCode('7', "Ù7"),
			};
            VietnameseCode['Ử'] = new VnCode[] {
				new VnCode('1', "Ứ"),
				new VnCode('2', "Ừ"),
				new VnCode('3', "Ư3"),
				new VnCode('4', "Ữ"),
				new VnCode('5', "Ự"),
				new VnCode('7', "Ủ7"),
			};
            VietnameseCode['Ữ'] = new VnCode[] {
				new VnCode('1', "Ứ"),
				new VnCode('2', "Ừ"),
				new VnCode('3', "Ử"),
				new VnCode('4', "Ư4"),
				new VnCode('5', "Ự"),
				new VnCode('7', "Ũ7"),
			};
            VietnameseCode['Ự'] = new VnCode[] {
				new VnCode('1', "Ứ"),
				new VnCode('2', "Ừ"),
				new VnCode('3', "Ử"),
				new VnCode('4', "Ữ"),
				new VnCode('5', "Ư5"),
				new VnCode('7', "Ụ7"),
			};
            VietnameseCode['Y'] = new VnCode[] {
				new VnCode('1', "Ý"),
				new VnCode('2', "Ỳ"),
				new VnCode('3', "Ỷ"),
				new VnCode('4', "Ỹ"),
				new VnCode('5', "Ỵ"),
			};
            VietnameseCode['Ý'] = new VnCode[] {
				new VnCode('1', "Y1"),
				new VnCode('2', "Ỳ"),
				new VnCode('3', "Ỷ"),
				new VnCode('4', "Ỹ"),
				new VnCode('5', "Ỵ"),
			};
            VietnameseCode['Ỳ'] = new VnCode[] {
				new VnCode('1', "Ý"),
				new VnCode('2', "Y2"),
				new VnCode('3', "Ỷ"),
				new VnCode('4', "Ỹ"),
				new VnCode('5', "Ỵ"),
			};
            VietnameseCode['Ỷ'] = new VnCode[] {
				new VnCode('1', "Ý"),
				new VnCode('2', "Ỳ"),
				new VnCode('3', "Y3"),
				new VnCode('4', "Ỹ"),
				new VnCode('5', "Ỵ"),
			};
            VietnameseCode['Ỹ'] = new VnCode[] {
				new VnCode('1', "Ý"),
				new VnCode('2', "Ỳ"),
				new VnCode('3', "Ỷ"),
				new VnCode('4', "Y4"),
				new VnCode('5', "Ỵ"),
			};
            VietnameseCode['Ỵ'] = new VnCode[] {
				new VnCode('1', "Ý"),
				new VnCode('2', "Ỳ"),
				new VnCode('3', "Ỷ"),
				new VnCode('4', "Ỹ"),
				new VnCode('5', "Y5"),
			};
        }
    }
}
