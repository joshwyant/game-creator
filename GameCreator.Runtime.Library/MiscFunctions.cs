using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GameCreator.Framework;

namespace GameCreator.Runtime.Library
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
        [GmlFunction]
        public static Value f(params Value[] args)
        {
           return new Value();
        }
        */

        [GmlFunction]
        public static int show_message(string msg)
        {
            MessageForm mf = new MessageForm();
            mf.Message = newlines(msg);
            mf.ShowDialog();
            //System.Windows.Forms.MessageBox.Show(newlines(args[0].String), Env.Title);
            return 0;
        }

        [GmlFunction]
        public static Value execute_string(string code)
        {
            ExecutionContext.Returned = 0;
            Parser p = new Parser(new StringReader(args[0]));
            p.Parse().Exec();
            return ExecutionContext.Returned;
        }

        [GmlFunction]
        public static void game_end()
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
