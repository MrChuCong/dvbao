using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Unikey
{
    public class Telex : InputMethod
    {
        private static InputMethod inputMethod = null;
        private static Hashtable VietnameseCode = new Hashtable();

        private Telex() { }

        public static InputMethod Create()
        {
            if (inputMethod == null) inputMethod = new Telex();
            return inputMethod;
        }

        protected override string GetVNChar()
        {
            return "ADEIOUYSFRXJW";
        }

        protected override Hashtable GetVietnameseCode()
        {
            return VietnameseCode;
        }

        public static void Init()
        {
            VietnameseCode['a'] = new VnCode[] {
				new VnCode('S', "á"),
				new VnCode('F', "à"),
				new VnCode('R', "ả"),
				new VnCode('X', "ã"),
				new VnCode('J', "ạ"),
				new VnCode('A', "â"),
				new VnCode('W', "ă"),
			};
            VietnameseCode['á'] = new VnCode[] {
				new VnCode('S', "as"),
				new VnCode('F', "à"),
				new VnCode('R', "ả"),
				new VnCode('X', "ã"),
				new VnCode('J', "ạ"),
				new VnCode('A', "ấ"),
				new VnCode('W', "ắ"),
			};
            VietnameseCode['à'] = new VnCode[] {
				new VnCode('S', "á"),
				new VnCode('F', "af"),
				new VnCode('R', "ả"),
				new VnCode('X', "ã"),
				new VnCode('J', "ạ"),
				new VnCode('A', "ầ"),
				new VnCode('W', "ằ"),
			};
            VietnameseCode['ả'] = new VnCode[] {
				new VnCode('S', "á"),
				new VnCode('F', "à"),
				new VnCode('R', "ar"),
				new VnCode('X', "ã"),
				new VnCode('J', "ạ"),
				new VnCode('A', "ẩ"),
				new VnCode('W', "ẳ"),
			};
            VietnameseCode['ã'] = new VnCode[] {
				new VnCode('S', "á"),
				new VnCode('F', "à"),
				new VnCode('R', "ả"),
				new VnCode('X', "ax"),
				new VnCode('J', "ạ"),
				new VnCode('A', "ẫ"),
				new VnCode('W', "ẵ"),
			};
            VietnameseCode['ạ'] = new VnCode[] {
				new VnCode('S', "á"),
				new VnCode('F', "à"),
				new VnCode('R', "ả"),
				new VnCode('X', "ã"),
				new VnCode('J', "aj"),
				new VnCode('A', "ậ"),
				new VnCode('W', "ặ"),
			};
            VietnameseCode['â'] = new VnCode[] {
				new VnCode('S', "ấ"),
				new VnCode('F', "ầ"),
				new VnCode('R', "ẩ"),
				new VnCode('X', "ẫ"),
				new VnCode('J', "ậ"),
				new VnCode('A', "aa"),
				new VnCode('W', "ă"),
			};
            VietnameseCode['ấ'] = new VnCode[] {
				new VnCode('S', "âs"),
				new VnCode('F', "ầ"),
				new VnCode('R', "ẩ"),
				new VnCode('X', "ẫ"),
				new VnCode('J', "ậ"),
				new VnCode('A', "áa"),
				new VnCode('W', "ắ"),
			};
            VietnameseCode['ầ'] = new VnCode[] {
				new VnCode('S', "ấ"),
				new VnCode('F', "âf"),
				new VnCode('R', "ẩ"),
				new VnCode('X', "ẫ"),
				new VnCode('J', "ậ"),
				new VnCode('A', "àa"),
				new VnCode('W', "ằ"),
			};
            VietnameseCode['ẩ'] = new VnCode[] {
				new VnCode('S', "ấ"),
				new VnCode('F', "ầ"),
				new VnCode('R', "âr"),
				new VnCode('X', "ẫ"),
				new VnCode('J', "ậ"),
				new VnCode('A', "ảa"),
				new VnCode('W', "ẳ"),
			};
            VietnameseCode['ẫ'] = new VnCode[] {
				new VnCode('S', "ấ"),
				new VnCode('F', "ầ"),
				new VnCode('R', "ẩ"),
				new VnCode('X', "âx"),
				new VnCode('J', "ậ"),
				new VnCode('A', "ãa"),
				new VnCode('W', "ẵ"),
			};
            VietnameseCode['ậ'] = new VnCode[] {
				new VnCode('S', "ấ"),
				new VnCode('F', "ầ"),
				new VnCode('R', "ẩ"),
				new VnCode('X', "ẫ"),
				new VnCode('J', "âj"),
				new VnCode('A', "ạa"),
				new VnCode('W', "ặ"),
			};
            VietnameseCode['ă'] = new VnCode[] {
				new VnCode('S', "ắ"),
				new VnCode('F', "ằ"),
				new VnCode('R', "ẳ"),
				new VnCode('X', "ẵ"),
				new VnCode('J', "ặ"),
				new VnCode('A', "â"),
				new VnCode('W', "aw"),
			};
            VietnameseCode['ắ'] = new VnCode[] {
				new VnCode('S', "ăs"),
				new VnCode('F', "ằ"),
				new VnCode('R', "ẳ"),
				new VnCode('X', "ẵ"),
				new VnCode('J', "ặ"),
				new VnCode('A', "ấ"),
				new VnCode('W', "áw"),
			};
            VietnameseCode['ằ'] = new VnCode[] {
				new VnCode('S', "ắ"),
				new VnCode('F', "ăf"),
				new VnCode('R', "ẳ"),
				new VnCode('X', "ẵ"),
				new VnCode('J', "ặ"),
				new VnCode('A', "ầ"),
				new VnCode('W', "àw"),
			};
            VietnameseCode['ẳ'] = new VnCode[] {
				new VnCode('S', "ắ"),
				new VnCode('F', "ằ"),
				new VnCode('R', "ăr"),
				new VnCode('X', "ẵ"),
				new VnCode('J', "ặ"),
				new VnCode('A', "ẩ"),
				new VnCode('W', "ảw"),
			};
            VietnameseCode['ẵ'] = new VnCode[] {
				new VnCode('S', "ắ"),
				new VnCode('F', "ằ"),
				new VnCode('R', "ẳ"),
				new VnCode('X', "ăx"),
				new VnCode('J', "ặ"),
				new VnCode('A', "ẫ"),
				new VnCode('W', "ãw"),
			};
            VietnameseCode['ặ'] = new VnCode[] {
				new VnCode('S', "ắ"),
				new VnCode('F', "ằ"),
				new VnCode('R', "ẳ"),
				new VnCode('X', "ẵ"),
				new VnCode('J', "ăj"),
				new VnCode('A', "ậ"),
				new VnCode('W', "ạw"),
			};
            VietnameseCode['d'] = new VnCode[] {
				new VnCode('D', "đ"),
			};
            VietnameseCode['đ'] = new VnCode[] {
				new VnCode('D', "dd"),
			};
            VietnameseCode['e'] = new VnCode[] {
				new VnCode('S', "é"),
				new VnCode('F', "è"),
				new VnCode('R', "ẻ"),
				new VnCode('X', "ẽ"),
				new VnCode('J', "ẹ"),
				new VnCode('E', "ê"),
			};
            VietnameseCode['é'] = new VnCode[] {
				new VnCode('S', "es"),
				new VnCode('F', "è"),
				new VnCode('R', "ẻ"),
				new VnCode('X', "ẽ"),
				new VnCode('J', "ẹ"),
				new VnCode('E', "ế"),
			};
            VietnameseCode['è'] = new VnCode[] {
				new VnCode('S', "é"),
				new VnCode('F', "ef"),
				new VnCode('R', "ẻ"),
				new VnCode('X', "ẽ"),
				new VnCode('J', "ẹ"),
				new VnCode('E', "ề"),
			};
            VietnameseCode['ẻ'] = new VnCode[] {
				new VnCode('S', "é"),
				new VnCode('F', "è"),
				new VnCode('R', "er"),
				new VnCode('X', "ẽ"),
				new VnCode('J', "ẹ"),
				new VnCode('E', "ể"),
			};
            VietnameseCode['ẽ'] = new VnCode[] {
				new VnCode('S', "é"),
				new VnCode('F', "è"),
				new VnCode('R', "ẻ"),
				new VnCode('X', "ex"),
				new VnCode('J', "ẹ"),
				new VnCode('E', "ễ"),
			};
            VietnameseCode['ẹ'] = new VnCode[] {
				new VnCode('S', "é"),
				new VnCode('F', "è"),
				new VnCode('R', "ẻ"),
				new VnCode('X', "ẽ"),
				new VnCode('J', "ej"),
				new VnCode('E', "ệ"),
			};
            VietnameseCode['ê'] = new VnCode[] {
				new VnCode('S', "ế"),
				new VnCode('F', "ề"),
				new VnCode('R', "ể"),
				new VnCode('X', "ễ"),
				new VnCode('J', "ệ"),
				new VnCode('E', "ee"),
			};
            VietnameseCode['ế'] = new VnCode[] {
				new VnCode('S', "ês"),
				new VnCode('F', "ề"),
				new VnCode('R', "ể"),
				new VnCode('X', "ễ"),
				new VnCode('J', "ệ"),
				new VnCode('E', "ée"),
			};
            VietnameseCode['ề'] = new VnCode[] {
				new VnCode('S', "ế"),
				new VnCode('F', "êf"),
				new VnCode('R', "ể"),
				new VnCode('X', "ễ"),
				new VnCode('J', "ệ"),
				new VnCode('E', "èe"),
			};
            VietnameseCode['ể'] = new VnCode[] {
				new VnCode('S', "ế"),
				new VnCode('F', "ề"),
				new VnCode('R', "êr"),
				new VnCode('X', "ễ"),
				new VnCode('J', "ệ"),
				new VnCode('E', "ẻe"),
			};
            VietnameseCode['ễ'] = new VnCode[] {
				new VnCode('S', "ế"),
				new VnCode('F', "ề"),
				new VnCode('R', "ể"),
				new VnCode('X', "êx"),
				new VnCode('J', "ệ"),
				new VnCode('E', "ẽe"),
			};
            VietnameseCode['ệ'] = new VnCode[] {
				new VnCode('S', "ế"),
				new VnCode('F', "ề"),
				new VnCode('R', "ể"),
				new VnCode('X', "ễ"),
				new VnCode('J', "êj"),
				new VnCode('E', "ẹe"),
			};
            VietnameseCode['i'] = new VnCode[] {
				new VnCode('S', "í"),
				new VnCode('F', "ì"),
				new VnCode('R', "ỉ"),
				new VnCode('X', "ĩ"),
				new VnCode('J', "ị"),
			};
            VietnameseCode['í'] = new VnCode[] {
				new VnCode('S', "is"),
				new VnCode('F', "ì"),
				new VnCode('R', "ỉ"),
				new VnCode('X', "ĩ"),
				new VnCode('J', "ị"),
			};
            VietnameseCode['ì'] = new VnCode[] {
				new VnCode('S', "í"),
				new VnCode('F', "if"),
				new VnCode('R', "ỉ"),
				new VnCode('X', "ĩ"),
				new VnCode('J', "ị"),
			};
            VietnameseCode['ỉ'] = new VnCode[] {
				new VnCode('S', "í"),
				new VnCode('F', "ì"),
				new VnCode('R', "ir"),
				new VnCode('X', "ĩ"),
				new VnCode('J', "ị"),
			};
            VietnameseCode['ĩ'] = new VnCode[] {
				new VnCode('S', "í"),
				new VnCode('F', "ì"),
				new VnCode('R', "ỉ"),
				new VnCode('X', "ix"),
				new VnCode('J', "ị"),
			};
            VietnameseCode['ị'] = new VnCode[] {
				new VnCode('S', "í"),
				new VnCode('F', "ì"),
				new VnCode('R', "ỉ"),
				new VnCode('X', "ĩ"),
				new VnCode('J', "ij"),
			};
            VietnameseCode['o'] = new VnCode[] {
				new VnCode('S', "ó"),
				new VnCode('F', "ò"),
				new VnCode('R', "ỏ"),
				new VnCode('X', "õ"),
				new VnCode('J', "ọ"),
				new VnCode('O', "ô"),
				new VnCode('W', "ơ"),
			};
            VietnameseCode['ó'] = new VnCode[] {
				new VnCode('S', "os"),
				new VnCode('F', "ò"),
				new VnCode('R', "ỏ"),
				new VnCode('X', "õ"),
				new VnCode('J', "ọ"),
				new VnCode('O', "ố"),
				new VnCode('W', "ớ"),
			};
            VietnameseCode['ò'] = new VnCode[] {
				new VnCode('S', "ó"),
				new VnCode('F', "of"),
				new VnCode('R', "ỏ"),
				new VnCode('X', "õ"),
				new VnCode('J', "ọ"),
				new VnCode('O', "ồ"),
				new VnCode('W', "ờ"),
			};
            VietnameseCode['ỏ'] = new VnCode[] {
				new VnCode('S', "ó"),
				new VnCode('F', "ò"),
				new VnCode('R', "or"),
				new VnCode('X', "õ"),
				new VnCode('J', "ọ"),
				new VnCode('O', "ổ"),
				new VnCode('W', "ở"),
			};
            VietnameseCode['õ'] = new VnCode[] {
				new VnCode('S', "ó"),
				new VnCode('F', "ò"),
				new VnCode('R', "ỏ"),
				new VnCode('X', "ox"),
				new VnCode('J', "ọ"),
				new VnCode('O', "ỗ"),
				new VnCode('W', "ỡ"),
			};
            VietnameseCode['ọ'] = new VnCode[] {
				new VnCode('S', "ó"),
				new VnCode('F', "ò"),
				new VnCode('R', "ỏ"),
				new VnCode('X', "õ"),
				new VnCode('J', "oj"),
				new VnCode('O', "ộ"),
				new VnCode('W', "ợ"),
			};
            VietnameseCode['ô'] = new VnCode[] {
				new VnCode('S', "ố"),
				new VnCode('F', "ồ"),
				new VnCode('R', "ổ"),
				new VnCode('X', "ỗ"),
				new VnCode('J', "ộ"),
				new VnCode('O', "oo"),
				new VnCode('W', "ơ"),
			};
            VietnameseCode['ố'] = new VnCode[] {
				new VnCode('S', "ôs"),
				new VnCode('F', "ồ"),
				new VnCode('R', "ổ"),
				new VnCode('X', "ỗ"),
				new VnCode('J', "ộ"),
				new VnCode('O', "óo"),
				new VnCode('W', "ớ"),
			};
            VietnameseCode['ồ'] = new VnCode[] {
				new VnCode('S', "ố"),
				new VnCode('F', "ôf"),
				new VnCode('R', "ổ"),
				new VnCode('X', "ỗ"),
				new VnCode('J', "ộ"),
				new VnCode('O', "òo"),
				new VnCode('W', "ờ"),
			};
            VietnameseCode['ổ'] = new VnCode[] {
				new VnCode('S', "ố"),
				new VnCode('F', "ồ"),
				new VnCode('R', "ôr"),
				new VnCode('X', "ỗ"),
				new VnCode('J', "ộ"),
				new VnCode('O', "ỏo"),
				new VnCode('W', "ở"),
			};
            VietnameseCode['ỗ'] = new VnCode[] {
				new VnCode('S', "ố"),
				new VnCode('F', "ồ"),
				new VnCode('R', "ổ"),
				new VnCode('X', "ôx"),
				new VnCode('J', "ộ"),
				new VnCode('O', "õo"),
				new VnCode('W', "ỡ"),
			};
            VietnameseCode['ộ'] = new VnCode[] {
				new VnCode('S', "ố"),
				new VnCode('F', "ồ"),
				new VnCode('R', "ổ"),
				new VnCode('X', "ỗ"),
				new VnCode('J', "ôj"),
				new VnCode('O', "ọo"),
				new VnCode('W', "ợ"),
			};
            VietnameseCode['ơ'] = new VnCode[] {
				new VnCode('S', "ớ"),
				new VnCode('F', "ờ"),
				new VnCode('R', "ở"),
				new VnCode('X', "ỡ"),
				new VnCode('J', "ợ"),
				new VnCode('O', "ô"),
				new VnCode('W', "ow"),
			};
            VietnameseCode['ớ'] = new VnCode[] {
				new VnCode('S', "ơs"),
				new VnCode('F', "ờ"),
				new VnCode('R', "ở"),
				new VnCode('X', "ỡ"),
				new VnCode('J', "ợ"),
				new VnCode('O', "ố"),
				new VnCode('W', "ów"),
			};
            VietnameseCode['ờ'] = new VnCode[] {
				new VnCode('S', "ớ"),
				new VnCode('F', "ơf"),
				new VnCode('R', "ở"),
				new VnCode('X', "ỡ"),
				new VnCode('J', "ợ"),
				new VnCode('O', "ồ"),
				new VnCode('W', "òw"),
			};
            VietnameseCode['ở'] = new VnCode[] {
				new VnCode('S', "ớ"),
				new VnCode('F', "ờ"),
				new VnCode('R', "ơr"),
				new VnCode('X', "ỡ"),
				new VnCode('J', "ợ"),
				new VnCode('O', "ổ"),
				new VnCode('W', "ỏw"),
			};
            VietnameseCode['ỡ'] = new VnCode[] {
				new VnCode('S', "ớ"),
				new VnCode('F', "ờ"),
				new VnCode('R', "ở"),
				new VnCode('X', "ơx"),
				new VnCode('J', "ợ"),
				new VnCode('O', "ỗ"),
				new VnCode('W', "õw"),
			};
            VietnameseCode['ợ'] = new VnCode[] {
				new VnCode('S', "ớ"),
				new VnCode('F', "ờ"),
				new VnCode('R', "ở"),
				new VnCode('X', "ỡ"),
				new VnCode('J', "ơj"),
				new VnCode('O', "ộ"),
				new VnCode('W', "ọw"),
			};
            VietnameseCode['u'] = new VnCode[] {
				new VnCode('S', "ú"),
				new VnCode('F', "ù"),
				new VnCode('R', "ủ"),
				new VnCode('X', "ũ"),
				new VnCode('J', "ụ"),
				new VnCode('W', "ư"),
			};
            VietnameseCode['ú'] = new VnCode[] {
				new VnCode('S', "us"),
				new VnCode('F', "ù"),
				new VnCode('R', "ủ"),
				new VnCode('X', "ũ"),
				new VnCode('J', "ụ"),
				new VnCode('W', "ứ"),
			};
            VietnameseCode['ù'] = new VnCode[] {
				new VnCode('S', "ú"),
				new VnCode('F', "uf"),
				new VnCode('R', "ủ"),
				new VnCode('X', "ũ"),
				new VnCode('J', "ụ"),
				new VnCode('W', "ừ"),
			};
            VietnameseCode['ủ'] = new VnCode[] {
				new VnCode('S', "ú"),
				new VnCode('F', "ù"),
				new VnCode('R', "ur"),
				new VnCode('X', "ũ"),
				new VnCode('J', "ụ"),
				new VnCode('W', "ử"),
			};
            VietnameseCode['ũ'] = new VnCode[] {
				new VnCode('S', "ú"),
				new VnCode('F', "ù"),
				new VnCode('R', "ủ"),
				new VnCode('X', "ux"),
				new VnCode('J', "ụ"),
				new VnCode('W', "ữ"),
			};
            VietnameseCode['ụ'] = new VnCode[] {
				new VnCode('S', "ú"),
				new VnCode('F', "ù"),
				new VnCode('R', "ủ"),
				new VnCode('X', "ũ"),
				new VnCode('J', "uj"),
				new VnCode('W', "ự"),
			};
            VietnameseCode['ư'] = new VnCode[] {
				new VnCode('S', "ứ"),
				new VnCode('F', "ừ"),
				new VnCode('R', "ử"),
				new VnCode('X', "ữ"),
				new VnCode('J', "ự"),
				new VnCode('W', "uw"),
			};
            VietnameseCode['ứ'] = new VnCode[] {
				new VnCode('S', "ưs"),
				new VnCode('F', "ừ"),
				new VnCode('R', "ử"),
				new VnCode('X', "ữ"),
				new VnCode('J', "ự"),
				new VnCode('W', "úw"),
			};
            VietnameseCode['ừ'] = new VnCode[] {
				new VnCode('S', "ứ"),
				new VnCode('F', "ưf"),
				new VnCode('R', "ử"),
				new VnCode('X', "ữ"),
				new VnCode('J', "ự"),
				new VnCode('W', "ùw"),
			};
            VietnameseCode['ử'] = new VnCode[] {
				new VnCode('S', "ứ"),
				new VnCode('F', "ừ"),
				new VnCode('R', "ưr"),
				new VnCode('X', "ữ"),
				new VnCode('J', "ự"),
				new VnCode('W', "ủw"),
			};
            VietnameseCode['ữ'] = new VnCode[] {
				new VnCode('S', "ứ"),
				new VnCode('F', "ừ"),
				new VnCode('R', "ử"),
				new VnCode('X', "ưx"),
				new VnCode('J', "ự"),
				new VnCode('W', "ũw"),
			};
            VietnameseCode['ự'] = new VnCode[] {
				new VnCode('S', "ứ"),
				new VnCode('F', "ừ"),
				new VnCode('R', "ử"),
				new VnCode('X', "ữ"),
				new VnCode('J', "ưj"),
				new VnCode('W', "ụw"),
			};
            VietnameseCode['y'] = new VnCode[] {
				new VnCode('S', "ý"),
				new VnCode('F', "ỳ"),
				new VnCode('R', "ỷ"),
				new VnCode('X', "ỹ"),
				new VnCode('J', "ỵ"),
			};
            VietnameseCode['ý'] = new VnCode[] {
				new VnCode('S', "ys"),
				new VnCode('F', "ỳ"),
				new VnCode('R', "ỷ"),
				new VnCode('X', "ỹ"),
				new VnCode('J', "ỵ"),
			};
            VietnameseCode['ỳ'] = new VnCode[] {
				new VnCode('S', "ý"),
				new VnCode('F', "yf"),
				new VnCode('R', "ỷ"),
				new VnCode('X', "ỹ"),
				new VnCode('J', "ỵ"),
			};
            VietnameseCode['ỷ'] = new VnCode[] {
				new VnCode('S', "ý"),
				new VnCode('F', "ỳ"),
				new VnCode('R', "yr"),
				new VnCode('X', "ỹ"),
				new VnCode('J', "ỵ"),
			};
            VietnameseCode['ỹ'] = new VnCode[] {
				new VnCode('S', "ý"),
				new VnCode('F', "ỳ"),
				new VnCode('R', "ỷ"),
				new VnCode('X', "yx"),
				new VnCode('J', "ỵ"),
			};
            VietnameseCode['ỵ'] = new VnCode[] {
				new VnCode('S', "ý"),
				new VnCode('F', "ỳ"),
				new VnCode('R', "ỷ"),
				new VnCode('X', "ỹ"),
				new VnCode('J', "yj"),
			};
            VietnameseCode['A'] = new VnCode[] {
				new VnCode('S', "Á"),
				new VnCode('F', "À"),
				new VnCode('R', "Ả"),
				new VnCode('X', "Ã"),
				new VnCode('J', "Ạ"),
				new VnCode('A', "Â"),
				new VnCode('W', "Ă"),
			};
            VietnameseCode['Á'] = new VnCode[] {
				new VnCode('S', "AS"),
				new VnCode('F', "À"),
				new VnCode('R', "Ả"),
				new VnCode('X', "Ã"),
				new VnCode('J', "Ạ"),
				new VnCode('A', "Ấ"),
				new VnCode('W', "Ắ"),
			};
            VietnameseCode['À'] = new VnCode[] {
				new VnCode('S', "Á"),
				new VnCode('F', "AF"),
				new VnCode('R', "Ả"),
				new VnCode('X', "Ã"),
				new VnCode('J', "Ạ"),
				new VnCode('A', "Ầ"),
				new VnCode('W', "Ằ"),
			};
            VietnameseCode['Ả'] = new VnCode[] {
				new VnCode('S', "Á"),
				new VnCode('F', "À"),
				new VnCode('R', "AR"),
				new VnCode('X', "Ã"),
				new VnCode('J', "Ạ"),
				new VnCode('A', "Ẩ"),
				new VnCode('W', "Ẳ"),
			};
            VietnameseCode['Ã'] = new VnCode[] {
				new VnCode('S', "Á"),
				new VnCode('F', "À"),
				new VnCode('R', "Ả"),
				new VnCode('X', "AX"),
				new VnCode('J', "Ạ"),
				new VnCode('A', "Ẫ"),
				new VnCode('W', "Ẵ"),
			};
            VietnameseCode['Ạ'] = new VnCode[] {
				new VnCode('S', "Á"),
				new VnCode('F', "À"),
				new VnCode('R', "Ả"),
				new VnCode('X', "Ã"),
				new VnCode('J', "AJ"),
				new VnCode('A', "Ậ"),
				new VnCode('W', "Ặ"),
			};
            VietnameseCode['Â'] = new VnCode[] {
				new VnCode('S', "Ấ"),
				new VnCode('F', "Ầ"),
				new VnCode('R', "Ẩ"),
				new VnCode('X', "Ẫ"),
				new VnCode('J', "Ậ"),
				new VnCode('A', "AA"),
				new VnCode('W', "Ă"),
			};
            VietnameseCode['Ấ'] = new VnCode[] {
				new VnCode('S', "ÂS"),
				new VnCode('F', "Ầ"),
				new VnCode('R', "Ẩ"),
				new VnCode('X', "Ẫ"),
				new VnCode('J', "Ậ"),
				new VnCode('A', "ÁA"),
				new VnCode('W', "Ắ"),
			};
            VietnameseCode['Ầ'] = new VnCode[] {
				new VnCode('S', "Ấ"),
				new VnCode('F', "ÂF"),
				new VnCode('R', "Ẩ"),
				new VnCode('X', "Ẫ"),
				new VnCode('J', "Ậ"),
				new VnCode('A', "ÀA"),
				new VnCode('W', "Ằ"),
			};
            VietnameseCode['Ẩ'] = new VnCode[] {
				new VnCode('S', "Ấ"),
				new VnCode('F', "Ầ"),
				new VnCode('R', "ÂR"),
				new VnCode('X', "Ẫ"),
				new VnCode('J', "Ậ"),
				new VnCode('A', "ẢA"),
				new VnCode('W', "Ẳ"),
			};
            VietnameseCode['Ẫ'] = new VnCode[] {
				new VnCode('S', "Ấ"),
				new VnCode('F', "Ầ"),
				new VnCode('R', "Ẩ"),
				new VnCode('X', "ÂX"),
				new VnCode('J', "Ậ"),
				new VnCode('A', "ÃA"),
				new VnCode('W', "Ẵ"),
			};
            VietnameseCode['Ậ'] = new VnCode[] {
				new VnCode('S', "Ấ"),
				new VnCode('F', "Ầ"),
				new VnCode('R', "Ẩ"),
				new VnCode('X', "Ẫ"),
				new VnCode('J', "ÂJ"),
				new VnCode('A', "ẠA"),
				new VnCode('W', "Ặ"),
			};
            VietnameseCode['Ă'] = new VnCode[] {
				new VnCode('S', "Ắ"),
				new VnCode('F', "Ằ"),
				new VnCode('R', "Ẳ"),
				new VnCode('X', "Ẵ"),
				new VnCode('J', "Ặ"),
				new VnCode('A', "Â"),
				new VnCode('W', "AW"),
			};
            VietnameseCode['Ắ'] = new VnCode[] {
				new VnCode('S', "ĂS"),
				new VnCode('F', "Ằ"),
				new VnCode('R', "Ẳ"),
				new VnCode('X', "Ẵ"),
				new VnCode('J', "Ặ"),
				new VnCode('A', "Ấ"),
				new VnCode('W', "ÁW"),
			};
            VietnameseCode['Ằ'] = new VnCode[] {
				new VnCode('S', "Ắ"),
				new VnCode('F', "ĂF"),
				new VnCode('R', "Ẳ"),
				new VnCode('X', "Ẵ"),
				new VnCode('J', "Ặ"),
				new VnCode('A', "Ầ"),
				new VnCode('W', "ÀW"),
			};
            VietnameseCode['Ẳ'] = new VnCode[] {
				new VnCode('S', "Ắ"),
				new VnCode('F', "Ằ"),
				new VnCode('R', "ĂR"),
				new VnCode('X', "Ẵ"),
				new VnCode('J', "Ặ"),
				new VnCode('A', "Ẩ"),
				new VnCode('W', "ẢW"),
			};
            VietnameseCode['Ẵ'] = new VnCode[] {
				new VnCode('S', "Ắ"),
				new VnCode('F', "Ằ"),
				new VnCode('R', "Ẳ"),
				new VnCode('X', "ĂX"),
				new VnCode('J', "Ặ"),
				new VnCode('A', "Ẫ"),
				new VnCode('W', "ÃW"),
			};
            VietnameseCode['Ặ'] = new VnCode[] {
				new VnCode('S', "Ắ"),
				new VnCode('F', "Ằ"),
				new VnCode('R', "Ẳ"),
				new VnCode('X', "Ẵ"),
				new VnCode('J', "ĂJ"),
				new VnCode('A', "Ậ"),
				new VnCode('W', "ẠW"),
			};
            VietnameseCode['D'] = new VnCode[] {
				new VnCode('D', "Đ"),
			};
            VietnameseCode['Đ'] = new VnCode[] {
				new VnCode('D', "DD"),
			};
            VietnameseCode['E'] = new VnCode[] {
				new VnCode('S', "É"),
				new VnCode('F', "È"),
				new VnCode('R', "Ẻ"),
				new VnCode('X', "Ẽ"),
				new VnCode('J', "Ẹ"),
				new VnCode('E', "Ê"),
			};
            VietnameseCode['É'] = new VnCode[] {
				new VnCode('S', "ES"),
				new VnCode('F', "È"),
				new VnCode('R', "Ẻ"),
				new VnCode('X', "Ẽ"),
				new VnCode('J', "Ẹ"),
				new VnCode('E', "Ế"),
			};
            VietnameseCode['È'] = new VnCode[] {
				new VnCode('S', "É"),
				new VnCode('F', "EF"),
				new VnCode('R', "Ẻ"),
				new VnCode('X', "Ẽ"),
				new VnCode('J', "Ẹ"),
				new VnCode('E', "Ề"),
			};
            VietnameseCode['Ẻ'] = new VnCode[] {
				new VnCode('S', "É"),
				new VnCode('F', "È"),
				new VnCode('R', "ER"),
				new VnCode('X', "Ẽ"),
				new VnCode('J', "Ẹ"),
				new VnCode('E', "Ể"),
			};
            VietnameseCode['Ẽ'] = new VnCode[] {
				new VnCode('S', "É"),
				new VnCode('F', "È"),
				new VnCode('R', "Ẻ"),
				new VnCode('X', "EX"),
				new VnCode('J', "Ẹ"),
				new VnCode('E', "Ễ"),
			};
            VietnameseCode['Ẹ'] = new VnCode[] {
				new VnCode('S', "É"),
				new VnCode('F', "È"),
				new VnCode('R', "Ẻ"),
				new VnCode('X', "Ẽ"),
				new VnCode('J', "EJ"),
				new VnCode('E', "Ệ"),
			};
            VietnameseCode['Ê'] = new VnCode[] {
				new VnCode('S', "Ế"),
				new VnCode('F', "Ề"),
				new VnCode('R', "Ể"),
				new VnCode('X', "Ễ"),
				new VnCode('J', "Ệ"),
				new VnCode('E', "EE"),
			};
            VietnameseCode['Ế'] = new VnCode[] {
				new VnCode('S', "ÊS"),
				new VnCode('F', "Ề"),
				new VnCode('R', "Ể"),
				new VnCode('X', "Ễ"),
				new VnCode('J', "Ệ"),
				new VnCode('E', "ÉE"),
			};
            VietnameseCode['Ề'] = new VnCode[] {
				new VnCode('S', "Ế"),
				new VnCode('F', "ÊF"),
				new VnCode('R', "Ể"),
				new VnCode('X', "Ễ"),
				new VnCode('J', "Ệ"),
				new VnCode('E', "ÈE"),
			};
            VietnameseCode['Ể'] = new VnCode[] {
				new VnCode('S', "Ế"),
				new VnCode('F', "Ề"),
				new VnCode('R', "ÊR"),
				new VnCode('X', "Ễ"),
				new VnCode('J', "Ệ"),
				new VnCode('E', "ẺE"),
			};
            VietnameseCode['Ễ'] = new VnCode[] {
				new VnCode('S', "Ế"),
				new VnCode('F', "Ề"),
				new VnCode('R', "Ể"),
				new VnCode('X', "ÊX"),
				new VnCode('J', "Ệ"),
				new VnCode('E', "ẼE"),
			};
            VietnameseCode['Ệ'] = new VnCode[] {
				new VnCode('S', "Ế"),
				new VnCode('F', "Ề"),
				new VnCode('R', "Ể"),
				new VnCode('X', "Ễ"),
				new VnCode('J', "ÊJ"),
				new VnCode('E', "ẸE"),
			};
            VietnameseCode['I'] = new VnCode[] {
				new VnCode('S', "Í"),
				new VnCode('F', "Ì"),
				new VnCode('R', "Ỉ"),
				new VnCode('X', "Ĩ"),
				new VnCode('J', "Ị"),
			};
            VietnameseCode['Í'] = new VnCode[] {
				new VnCode('S', "IS"),
				new VnCode('F', "Ì"),
				new VnCode('R', "Ỉ"),
				new VnCode('X', "Ĩ"),
				new VnCode('J', "Ị"),
			};
            VietnameseCode['Ì'] = new VnCode[] {
				new VnCode('S', "Í"),
				new VnCode('F', "IF"),
				new VnCode('R', "Ỉ"),
				new VnCode('X', "Ĩ"),
				new VnCode('J', "Ị"),
			};
            VietnameseCode['Ỉ'] = new VnCode[] {
				new VnCode('S', "Í"),
				new VnCode('F', "Ì"),
				new VnCode('R', "IR"),
				new VnCode('X', "Ĩ"),
				new VnCode('J', "Ị"),
			};
            VietnameseCode['Ĩ'] = new VnCode[] {
				new VnCode('S', "Í"),
				new VnCode('F', "Ì"),
				new VnCode('R', "Ỉ"),
				new VnCode('X', "IX"),
				new VnCode('J', "Ị"),
			};
            VietnameseCode['Ị'] = new VnCode[] {
				new VnCode('S', "Í"),
				new VnCode('F', "Ì"),
				new VnCode('R', "Ỉ"),
				new VnCode('X', "Ĩ"),
				new VnCode('J', "IJ"),
			};
            VietnameseCode['O'] = new VnCode[] {
				new VnCode('S', "Ó"),
				new VnCode('F', "Ò"),
				new VnCode('R', "Ỏ"),
				new VnCode('X', "Õ"),
				new VnCode('J', "Ọ"),
				new VnCode('O', "Ô"),
				new VnCode('W', "Ơ"),
			};
            VietnameseCode['Ó'] = new VnCode[] {
				new VnCode('S', "OS"),
				new VnCode('F', "Ò"),
				new VnCode('R', "Ỏ"),
				new VnCode('X', "Õ"),
				new VnCode('J', "Ọ"),
				new VnCode('O', "Ố"),
				new VnCode('W', "Ớ"),
			};
            VietnameseCode['Ò'] = new VnCode[] {
				new VnCode('S', "Ó"),
				new VnCode('F', "OF"),
				new VnCode('R', "Ỏ"),
				new VnCode('X', "Õ"),
				new VnCode('J', "Ọ"),
				new VnCode('O', "Ồ"),
				new VnCode('W', "Ờ"),
			};
            VietnameseCode['Ỏ'] = new VnCode[] {
				new VnCode('S', "Ó"),
				new VnCode('F', "Ò"),
				new VnCode('R', "OR"),
				new VnCode('X', "Õ"),
				new VnCode('J', "Ọ"),
				new VnCode('O', "Ổ"),
				new VnCode('W', "Ở"),
			};
            VietnameseCode['Õ'] = new VnCode[] {
				new VnCode('S', "Ó"),
				new VnCode('F', "Ò"),
				new VnCode('R', "Ỏ"),
				new VnCode('X', "OX"),
				new VnCode('J', "Ọ"),
				new VnCode('O', "Ỗ"),
				new VnCode('W', "Ỡ"),
			};
            VietnameseCode['Ọ'] = new VnCode[] {
				new VnCode('S', "Ó"),
				new VnCode('F', "Ò"),
				new VnCode('R', "Ỏ"),
				new VnCode('X', "Õ"),
				new VnCode('J', "OJ"),
				new VnCode('O', "Ộ"),
				new VnCode('W', "Ợ"),
			};
            VietnameseCode['Ô'] = new VnCode[] {
				new VnCode('S', "Ố"),
				new VnCode('F', "Ồ"),
				new VnCode('R', "Ổ"),
				new VnCode('X', "Ỗ"),
				new VnCode('J', "Ộ"),
				new VnCode('O', "OO"),
				new VnCode('W', "Ơ"),
			};
            VietnameseCode['Ố'] = new VnCode[] {
				new VnCode('S', "ÔS"),
				new VnCode('F', "Ồ"),
				new VnCode('R', "Ổ"),
				new VnCode('X', "Ỗ"),
				new VnCode('J', "Ộ"),
				new VnCode('O', "ÓO"),
				new VnCode('W', "Ớ"),
			};
            VietnameseCode['Ồ'] = new VnCode[] {
				new VnCode('S', "Ố"),
				new VnCode('F', "ÔF"),
				new VnCode('R', "Ổ"),
				new VnCode('X', "Ỗ"),
				new VnCode('J', "Ộ"),
				new VnCode('O', "ÒO"),
				new VnCode('W', "Ờ"),
			};
            VietnameseCode['Ổ'] = new VnCode[] {
				new VnCode('S', "Ố"),
				new VnCode('F', "Ồ"),
				new VnCode('R', "ÔR"),
				new VnCode('X', "Ỗ"),
				new VnCode('J', "Ộ"),
				new VnCode('O', "ỎO"),
				new VnCode('W', "Ở"),
			};
            VietnameseCode['Ỗ'] = new VnCode[] {
				new VnCode('S', "Ố"),
				new VnCode('F', "Ồ"),
				new VnCode('R', "Ổ"),
				new VnCode('X', "ÔX"),
				new VnCode('J', "Ộ"),
				new VnCode('O', "ÕO"),
				new VnCode('W', "Ỡ"),
			};
            VietnameseCode['Ộ'] = new VnCode[] {
				new VnCode('S', "Ố"),
				new VnCode('F', "Ồ"),
				new VnCode('R', "Ổ"),
				new VnCode('X', "Ỗ"),
				new VnCode('J', "ÔJ"),
				new VnCode('O', "ỌO"),
				new VnCode('W', "Ợ"),
			};
            VietnameseCode['Ơ'] = new VnCode[] {
				new VnCode('S', "Ớ"),
				new VnCode('F', "Ờ"),
				new VnCode('R', "Ở"),
				new VnCode('X', "Ỡ"),
				new VnCode('J', "Ợ"),
				new VnCode('O', "Ô"),
				new VnCode('W', "OW"),
			};
            VietnameseCode['Ớ'] = new VnCode[] {
				new VnCode('S', "ƠS"),
				new VnCode('F', "Ờ"),
				new VnCode('R', "Ở"),
				new VnCode('X', "Ỡ"),
				new VnCode('J', "Ợ"),
				new VnCode('O', "Ố"),
				new VnCode('W', "ÓW"),
			};
            VietnameseCode['Ờ'] = new VnCode[] {
				new VnCode('S', "Ớ"),
				new VnCode('F', "ƠF"),
				new VnCode('R', "Ở"),
				new VnCode('X', "Ỡ"),
				new VnCode('J', "Ợ"),
				new VnCode('O', "Ồ"),
				new VnCode('W', "ÒW"),
			};
            VietnameseCode['Ở'] = new VnCode[] {
				new VnCode('S', "Ớ"),
				new VnCode('F', "Ờ"),
				new VnCode('R', "ƠR"),
				new VnCode('X', "Ỡ"),
				new VnCode('J', "Ợ"),
				new VnCode('O', "Ổ"),
				new VnCode('W', "ỎW"),
			};
            VietnameseCode['Ỡ'] = new VnCode[] {
				new VnCode('S', "Ớ"),
				new VnCode('F', "Ờ"),
				new VnCode('R', "Ở"),
				new VnCode('X', "ƠX"),
				new VnCode('J', "Ợ"),
				new VnCode('O', "Ỗ"),
				new VnCode('W', "ÕW"),
			};
            VietnameseCode['Ợ'] = new VnCode[] {
				new VnCode('S', "Ớ"),
				new VnCode('F', "Ờ"),
				new VnCode('R', "Ở"),
				new VnCode('X', "Ỡ"),
				new VnCode('J', "ƠJ"),
				new VnCode('O', "Ộ"),
				new VnCode('W', "ỌW"),
			};
            VietnameseCode['U'] = new VnCode[] {
				new VnCode('S', "Ú"),
				new VnCode('F', "Ù"),
				new VnCode('R', "Ủ"),
				new VnCode('X', "Ũ"),
				new VnCode('J', "Ụ"),
				new VnCode('W', "Ư"),
			};
            VietnameseCode['Ú'] = new VnCode[] {
				new VnCode('S', "US"),
				new VnCode('F', "Ù"),
				new VnCode('R', "Ủ"),
				new VnCode('X', "Ũ"),
				new VnCode('J', "Ụ"),
				new VnCode('W', "Ứ"),
			};
            VietnameseCode['Ù'] = new VnCode[] {
				new VnCode('S', "Ú"),
				new VnCode('F', "UF"),
				new VnCode('R', "Ủ"),
				new VnCode('X', "Ũ"),
				new VnCode('J', "Ụ"),
				new VnCode('W', "Ừ"),
			};
            VietnameseCode['Ủ'] = new VnCode[] {
				new VnCode('S', "Ú"),
				new VnCode('F', "Ù"),
				new VnCode('R', "UR"),
				new VnCode('X', "Ũ"),
				new VnCode('J', "Ụ"),
				new VnCode('W', "Ử"),
			};
            VietnameseCode['Ũ'] = new VnCode[] {
				new VnCode('S', "Ú"),
				new VnCode('F', "Ù"),
				new VnCode('R', "Ủ"),
				new VnCode('X', "UX"),
				new VnCode('J', "Ụ"),
				new VnCode('W', "Ữ"),
			};
            VietnameseCode['Ụ'] = new VnCode[] {
				new VnCode('S', "Ú"),
				new VnCode('F', "Ù"),
				new VnCode('R', "Ủ"),
				new VnCode('X', "Ũ"),
				new VnCode('J', "UJ"),
				new VnCode('W', "Ự"),
			};
            VietnameseCode['Ư'] = new VnCode[] {
				new VnCode('S', "Ứ"),
				new VnCode('F', "Ừ"),
				new VnCode('R', "Ử"),
				new VnCode('X', "Ữ"),
				new VnCode('J', "Ự"),
				new VnCode('W', "UW"),
			};
            VietnameseCode['Ứ'] = new VnCode[] {
				new VnCode('S', "ƯS"),
				new VnCode('F', "Ừ"),
				new VnCode('R', "Ử"),
				new VnCode('X', "Ữ"),
				new VnCode('J', "Ự"),
				new VnCode('W', "ÚW"),
			};
            VietnameseCode['Ừ'] = new VnCode[] {
				new VnCode('S', "Ứ"),
				new VnCode('F', "ƯF"),
				new VnCode('R', "Ử"),
				new VnCode('X', "Ữ"),
				new VnCode('J', "Ự"),
				new VnCode('W', "ÙW"),
			};
            VietnameseCode['Ử'] = new VnCode[] {
				new VnCode('S', "Ứ"),
				new VnCode('F', "Ừ"),
				new VnCode('R', "ƯR"),
				new VnCode('X', "Ữ"),
				new VnCode('J', "Ự"),
				new VnCode('W', "ỦW"),
			};
            VietnameseCode['Ữ'] = new VnCode[] {
				new VnCode('S', "Ứ"),
				new VnCode('F', "Ừ"),
				new VnCode('R', "Ử"),
				new VnCode('X', "ƯX"),
				new VnCode('J', "Ự"),
				new VnCode('W', "ŨW"),
			};
            VietnameseCode['Ự'] = new VnCode[] {
				new VnCode('S', "Ứ"),
				new VnCode('F', "Ừ"),
				new VnCode('R', "Ử"),
				new VnCode('X', "Ữ"),
				new VnCode('J', "ƯJ"),
				new VnCode('W', "ỤW"),
			};
            VietnameseCode['Y'] = new VnCode[] {
				new VnCode('S', "Ý"),
				new VnCode('F', "Ỳ"),
				new VnCode('R', "Ỷ"),
				new VnCode('X', "Ỹ"),
				new VnCode('J', "Ỵ"),
			};
            VietnameseCode['Ý'] = new VnCode[] {
				new VnCode('S', "YS"),
				new VnCode('F', "Ỳ"),
				new VnCode('R', "Ỷ"),
				new VnCode('X', "Ỹ"),
				new VnCode('J', "Ỵ"),
			};
            VietnameseCode['Ỳ'] = new VnCode[] {
				new VnCode('S', "Ý"),
				new VnCode('F', "YF"),
				new VnCode('R', "Ỷ"),
				new VnCode('X', "Ỹ"),
				new VnCode('J', "Ỵ"),
			};
            VietnameseCode['Ỷ'] = new VnCode[] {
				new VnCode('S', "Ý"),
				new VnCode('F', "Ỳ"),
				new VnCode('R', "YR"),
				new VnCode('X', "Ỹ"),
				new VnCode('J', "Ỵ"),
			};
            VietnameseCode['Ỹ'] = new VnCode[] {
				new VnCode('S', "Ý"),
				new VnCode('F', "Ỳ"),
				new VnCode('R', "Ỷ"),
				new VnCode('X', "YX"),
				new VnCode('J', "Ỵ"),
			};
            VietnameseCode['Ỵ'] = new VnCode[] {
				new VnCode('S', "Ý"),
				new VnCode('F', "Ỳ"),
				new VnCode('R', "Ỷ"),
				new VnCode('X', "Ỹ"),
				new VnCode('J', "YJ"),
			};
        }
    }
}
