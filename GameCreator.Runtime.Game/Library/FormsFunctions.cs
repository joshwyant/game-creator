using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;
using System.Windows.Forms;
using System.Drawing;

namespace GameCreator.Runtime.Game.Library
{
    // Experimental set of functions for displaying forms, NOT functions included in YoYo GM
    public static class FormsFunctions
    {
        static readonly Dictionary<int, Form> forms = new Dictionary<int, Form>();
        static int formc = 0;
        class window
        {
            public FunctionDelegate click;
            public FunctionDelegate create;
            public RuntimeInstance inst;
        }
        [GmlFunction]
        public static int window_create(string text)
        {
            int ind = formc++;
            System.Windows.Forms.Form m = new System.Windows.Forms.Form();
            m.Text = text;
            forms.Add(ind, m);
            window w = new window();
            w.inst = LibraryContext.Current.InstanceFactory.CreatePrivateInstance() as RuntimeInstance;
            w.inst.SetLocalVar("window_index", ind);
            m.Tag = w;
            m.Click += new EventHandler(m_Click);
            m.Load += new EventHandler(m_Load);
            return ind;
        }
        [GmlFunction]
        public static void window_close(int form)
        {
            forms[form].Close();
            forms.Remove(form);
        }
        [GmlFunction]
        public static int window_count()
        {
            return forms.Count;
        }
        [GmlFunction]
        public static void window_show(int form)
        {
            forms[form].Show();
        }
        [GmlFunction]
        public static void window_set_color(int form, int color)
        {
            forms[form].BackColor = System.Drawing.Color.FromArgb(color&0xFF,(color>>8)&0xFF,(color>>16)&0xFF);
        }
        [GmlFunction]
        public static void window_set_click(int form, int script)
        {
            var f = forms[form];
            ((window)f.Tag).click = Script.Manager[script].ExecutionDelegate;
        }
        [GmlFunction]
        public static void window_set_create(int form, int script)
        {
            var f = forms[form];
            ((window)f.Tag).create = Script.Manager[script].ExecutionDelegate;
        }
        [GmlFunction]
        public static void window_add_button(int form, int x, int y, int width, int height, string text)
        {
            var t = forms[form];
            var b = new Button();
            b.Text = text;
            b.Location = new Point(x, y);
            b.Size = new Size(width, height);
            t.Controls.Add(b);
            b.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        static void m_Click(object sender, EventArgs e)
        {
            window w = (window)(((System.Windows.Forms.Form)sender).Tag);
            if (w.click == null) return;
            ExecutionContext.Current = w.inst;
            w.click();
        }
        static void m_Load(object sender, EventArgs e)
        {
 	        window w = (window)(((System.Windows.Forms.Form)sender).Tag);
            if (w.create == null) return;
            ExecutionContext.Current = w.inst;
            w.create();
        }
    }
}
