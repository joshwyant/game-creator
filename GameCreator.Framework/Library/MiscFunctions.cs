using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Gml;
using System.IO;

namespace GameCreator.Framework.Library
{
    internal static partial class GMLFunctions
    {
        static string newlines(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#') sb.Append('\n');
                else if (s[i] == '\\')
                {
                    if (i + 1 == s.Length || s[i + 1] != '#') sb.Append('\\');
                    else sb.Append(s[++i]);
                }
                else
                    sb.Append(s[i]);
            }
            return sb.ToString();
        }
        /*
        [GMLFunction(-1)]
        public static Value f(params Value[] args)
        {
           return new Value();
        }
        */
        [GMLFunction(1)]
        public static Value show_message(params Value[] args)
        {
            MessageForm mf = new MessageForm();
            mf.Message = newlines(args[0]);
            mf.ShowDialog();
            //System.Windows.Forms.MessageBox.Show(newlines(args[0].String), Env.Title);
            return Value.Zero;
        }
        [GMLFunction(1)]
        public static Value execute_string(params Value[] args)
        {
            ExecutionContext.Returned = 0;
            Parser p = new Parser(new StringReader(args[0]));
            p.Parse().Exec();
            return ExecutionContext.Returned;
        }
        [GMLFunction(0)]
        public static Value game_end(params Value[] args)
        {
            System.Windows.Forms.Application.Exit();
            return Value.Null;
        }
    }
}
