using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GameCreator.Framework;

namespace GameCreator.Runtime.Game.Library
{
    public static class GameFunctions
    {
        static string newlines(string s)
        {
            var sb = new StringBuilder();
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

        public static GameInstance CreateInstance(int id, double x, double y)
        {
            Framework.Object o;
            if (!LibraryContext.Current.Resources.Objects.TryGetValue(id, out o))
                return null;

            var inst = LibraryContext.Current.InstanceFactory.CreateInstance(o.Id) as GameInstance;
            inst.sprite_index = o.SpriteIndex;
            inst.xstart = inst.x = x;
            inst.ystart = inst.y = y;

            return inst;
        }

        [GmlFunction]
        public static int instance_create(double x, double y, int object_index)
        {
            var e = CreateInstance(object_index, x, y);
            LibraryContext.Current.PerformEvent(e, EventType.Create, 0);
            return e.id;
        }
        [GmlFunction]
        public static int show_message(string msg)
        {
            var mf = new MessageForm();
            mf.Message = newlines(msg);
            mf.ShowDialog();
            //System.Windows.Forms.MessageBox.Show(newlines(args[0].String), Env.Title);
            return 0;
        }

        [GmlFunction]
        public static void game_end()
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
