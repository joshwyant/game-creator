using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;
using System.Linq;

namespace GameCreator.Runtime.Library
{
    public static partial class GmlFunctions
    {
        #region String handling functions
        [GmlFunction]
        public static string chr(int val)
        {
            return ((char)val).ToString();
        }

        [GmlFunction]
        public static int ord(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            return (int)str[0];
        }

        [GmlFunction]
        public static double real(Value val)
        {
            if (val.IsReal) return val.Real;
            if (val.String.Trim().Length == 0) return 0.0;
            try
            {
                return double.Parse(val.String, System.Globalization.NumberStyles.Float);
            }
            catch
            {
                throw new ProgramError(Error.RuntimeReal);
            }
        }

        [GmlFunction(Name = "string")]
        public static string _string(Value val)
        {
            return val.ToString();
        }

        // FIXME!!!
        [GmlFunction]
        public static string string_format(Value val)
        {
            return new Value(val.ToString());
        }

        [GmlFunction]
        public static int string_length(string str)
        {
            return string.IsNullOrEmpty(str) ? 0 : str.Length;
        }

        [GmlFunction]
        public static int string_pos(string substr, string str)
        {
            return str.IndexOf(substr)+1;
        }

        [GmlFunction]
        public static string string_copy(string str, int index, int len)
        {
            int i = index - 1;
            if (i < 0) i = 0;
            int l = len;
            if (i + l > str.Length) l = str.Length - i;
            return str.Substring(i, l);
        }

        [GmlFunction]
        public static string string_char_at(string str, int pos)
        {
            int i = Math.Max(0, pos - 1);
            if (i >= str.Length) return string.Empty;
            return str[i].ToString();
        }

        [GmlFunction]
        public static string string_delete(string str, int pos, int l)
        {
            if (pos < 1 || l <= 0 || pos > str.Length) return str;
            int i = pos - 1;
            if (i + l > str.Length) l = str.Length - i;
            return str.Remove(i, l);
        }

        [GmlFunction]
        public static string string_insert(string substr, string str, int pos)
        {
            return str.Insert(Math.Max(Math.Min(pos-1, str.Length), 0), substr);
        }

        [GmlFunction]
        public static string string_replace(string str, string oldstr, string newstr)
        {
            var pos = str.IndexOf(oldstr);
            if (pos == -1) return str;
            return str.Remove(pos, oldstr.Length).Insert(pos, newstr);
        }

        [GmlFunction]
        public static string string_replace_all(string str, string oldstr, string newstr)
        {
            return str.Replace(oldstr, newstr);
        }

        [GmlFunction]
        public static int string_count(string substr, string str)
        {
            if (substr.Length == 0) return 0;
            int count = 0;
            int pos = -substr.Length;
            for (; ; )
            {
                pos = str.IndexOf(substr, pos + substr.Length);
                if (pos == -1) break;
                count++;
            }
            return count;
        }

        [GmlFunction]
        public static string string_lower(string str)
        {
            return str.ToLowerInvariant();
        }

        [GmlFunction]
        public static string string_upper(string str)
        {
            return str.ToUpperInvariant();
        }

        [GmlFunction]
        public static string string_repeat(string str, int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
                sb.Append(str);
            return sb.ToString();
        }

        [GmlFunction]
        public static string string_letters(string str)
        {
            return new string(str.Where(c => char.IsLetter(c)).ToArray());
        }

        [GmlFunction]
        public static string string_digits(string str)
        {
            return new string(str.Where(c => char.IsDigit(c)).ToArray());
        }

        [GmlFunction]
        public static string string_lettersdigits(string str)
        {
            return new string(str.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }
        #endregion
        /*
        [GmlFunction]
        public static Value f(params Value[] args)
        {
            return new Value();
        }
        */
    }
}
