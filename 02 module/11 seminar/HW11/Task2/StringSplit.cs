using System;
namespace Task2
{
    public static class StringSplit
    {
        public static bool Validate(string str)
        {
            char[] english = new char[53];
            english[0] = ' ';
            for (int i = 1; i <= 26; i++)
            {
                english[i] = (char)('a' + i);
            }
            for (int i = 27; i < english.Length; i++)
            {
                english[i] = (char)('A' + i);
            }
            if (str.IndexOfAny(english) < 0)
                return false;
            return true;
        } // end of Validate(string)

        public static string[] ValidatedSplit(string str, char ch)
        {
            string[] output = null;
            output = str.Split(ch);
            foreach (string s in output)
            {
                if (!Validate(s)) return null;
            }
            return output;
        } // end of ValidatdSplit(string, char)

        public static string Shorten(string str)
        { // TODO: учесть заглавные гласные
            char[] alph = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
            int ind = str.IndexOfAny(alph);
            return str.Substring(0, ind + 1);
        } // end of Shorten(string)

        public static string Abbrevation(string str)
        {
            string output = String.Empty;
            if (str != String.Empty)
            {
                string[] tmp = str.Split(' '); foreach (string s in tmp)
                {
                    string shortenS = Shorten(s);
                    FirstUpcase(ref shortenS);
                    output += shortenS;
                }
            }
            return output;
        } // end of Abbrevation(string)

        public static void FirstUpcase(ref string str)
        {
            if (str.Length == 0)
                return;
            char[] chars = str.ToCharArray();
            string str2 = str.Substring(1).ToLower();
            str = str[0].ToString().ToUpper() + str2;
        } // end of FirstUpcase(ref string)
    }
}
