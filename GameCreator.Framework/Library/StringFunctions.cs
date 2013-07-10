using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework.Library
{
    internal static partial class GMLFunctions
    {
        #region String handling functions
        [GMLFunction(1)]
        public static Value chr(params Value[] args)
        {
            return new Value(((char)(int)args[0]).ToString());
        }
        [GMLFunction(1)]
        public static Value ord(params Value[] args)
        {
            try { return (int)((string)args[0])[0]; }
            catch { return 0; }
        }
        [GMLFunction(1)]
        public static Value real(params Value[] args)
        {
            if (args[0].IsReal) return args[0];
            if (args[0].String.Trim().Length == 0) return 0.0;
            try
            {
                return new Value(double.Parse(args[0], System.Globalization.NumberStyles.Float));
            }
            catch
            {
                throw new ProgramError("Error in function real().", ErrorSeverity.Error, ExecutionContext.ExecutingStatement);
            }
        }
        [GMLFunction(1, Name = "string")]
        public static Value _string(params Value[] args)
        {
            return new Value(args[0].ToString());
        }
        // FIXME!!!
        [GMLFunction(3)]
        public static Value string_format(params Value[] args)
        {
            return new Value(args[0].ToString());
        }
        [GMLFunction(1)]
        public static Value string_length(params Value[] args)
        {
            return args[0].String.Length;
        }
        [GMLFunction(2)]
        public static Value string_pos(params Value[] args)
        {
            return new Value(args[1].String.IndexOf(args[0].String)+1);
        }
        [GMLFunction(3)]
        public static Value string_copy(params Value[] args)
        {
            int i = args[1] - 1;
            if (i < 0) i = 0;
            int l = args[2];
            if (i + l > args[0].String.Length) l = args[0].String.Length - i;
            return args[0].String.Substring(i, l);
        }
        [GMLFunction(2)]
        public static Value string_char_at(params Value[] args)
        {
            int i = Math.Max(0, (int)args[1] - 1);
            if (i >= args[0].String.Length) return string.Empty;
            return ((string)args[0])[i].ToString();
        }
        [GMLFunction(3)]
        public static Value string_delete(params Value[] args)
        {
            if (args[1] < 1 || args[2] <= 0 || args[1] > args[0].String.Length) return args[0].String;
            int i = args[1]-1;
            int l = args[2];
            if (i + l > args[0].String.Length) l = args[0].String.Length - i;
            return args[0].String.Remove(i, l);
        }
        [GMLFunction(3)]
        public static Value string_insert(params Value[] args)
        {
            return args[1].String.Insert(Math.Max(Math.Min(args[2]-1, args[1].String.Length), 0), args[0]);
        }
        [GMLFunction(3)]
        public static Value string_replace(params Value[] args)
        {
            int pos = args[0].String.IndexOf(args[1]);
            if (pos == -1) return args[0].String;
            return args[0].String.Remove(pos, args[1].String.Length).Insert(pos, args[2]);
        }
        [GMLFunction(3)]
        public static Value string_replace_all(params Value[] args)
        {
            return args[0].String.Replace(args[1].String, args[2]);
        }
        [GMLFunction(2)]
        public static Value string_count(params Value[] args)
        {
            if (args[0].String.Length == 0) return 0;
            int count = 0;
            int pos = -args[0].String.Length;
            for (; ; )
            {
                pos = args[1].String.IndexOf(args[0], pos + args[0].String.Length);
                if (pos == -1) break;
                count++;
            }
            return count;
        }
        [GMLFunction(1)]
        public static Value string_lower(params Value[] args)
        {
            return args[0].String.ToLowerInvariant();
        }
        [GMLFunction(1)]
        public static Value string_upper(params Value[] args)
        {
            return args[0].String.ToUpperInvariant();
        }
        [GMLFunction(2)]
        public static Value string_repeat(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[1].Real; i++)
                sb.Append(args[0].String);
            return sb.ToString();
        }
        [GMLFunction(1)]
        public static Value string_letters(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[0].String.Length; i++)
                if (char.IsLetter(args[0].String[i])) sb.Append(args[0].String[i]);
            return sb.ToString();
        }
        [GMLFunction(1)]
        public static Value string_digits(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[0].String.Length; i++)
                if (char.IsDigit(args[0].String[i])) sb.Append(args[0].String[i]);
            return sb.ToString();
        }
        [GMLFunction(1)]
        public static Value string_lettersdigits(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[0].String.Length; i++)
                if (char.IsLetterOrDigit(args[0].String[i])) sb.Append(args[0].String[i]);
            return sb.ToString();
        }
        [GMLFunction(0)]
        public static Value clipboard_has_text(params Value[] args)
        {
            return System.Windows.Forms.Clipboard.ContainsText();
        }
        [GMLFunction(0)]
        public static Value clipboard_get_text(params Value[] args)
        {
            return System.Windows.Forms.Clipboard.ContainsText() ? System.Windows.Forms.Clipboard.GetText() : string.Empty;
        }
        [GMLFunction(1)]
        public static Value clipboard_set_text(params Value[] args)
        {
            if (!string.IsNullOrEmpty(args[0]))
                System.Windows.Forms.Clipboard.SetText(args[0]);
            return 0;
        }
        #endregion
        /*
        [GMLFunction(-1)]
        public static Value f(params Value[] args)
        {
            return new Value();
        }
        */
    }
}
