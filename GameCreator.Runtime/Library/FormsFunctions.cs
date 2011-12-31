using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Runtime.Interpreter;

namespace GameCreator.Runtime.Library
{
    // Experimental set of functions for displaying forms, NOT functions included in YoYo GM
    internal static class FormsFunctions
    {
        static Dictionary<int, System.Windows.Forms.Form> forms = new Dictionary<int, System.Windows.Forms.Form>();
        static int formc = 0;
        /*
        [GMLFunction(-1)]
        public static Value f(params Value[] args)
        {
           return new Value();
        }
        */
        class window
        {
            public GameCreator.Runtime.Interpreter.ScriptFunction click;
            public GameCreator.Runtime.Interpreter.ScriptFunction create;
            public Instance inst;
        }
        [GMLFunction(1)]
        public static Value window_create(params Value[] args)
        {
            int ind = formc++;
            System.Windows.Forms.Form m = new System.Windows.Forms.Form();
            m.Text = args[0];
            forms.Add(ind, m);
            window w = new window();
            w.inst = Env.CreatePrivateInstance();
            w.inst.SetLocalVar("window_index", ind);
            m.Tag = w;
            m.Click += new EventHandler(m_Click);
            m.Load += new EventHandler(m_Load);
            return ind;
        }
        [GMLFunction(1)]
        public static Value window_close(params Value[] args)
        {
            forms[args[0]].Close();
            forms.Remove(args[0]);
            return 0;
        }
        [GMLFunction(0)]
        public static Value window_count(params Value[] args)
        {
            return forms.Count;
        }
        [GMLFunction(1)]
        public static Value window_show(params Value[] args)
        {
            forms[args[0]].Show();
            return Value.Null;
        }
        [GMLFunction(2)]
        public static Value window_set_color(params Value[] args)
        {
            forms[args[0]].BackColor = System.Drawing.Color.FromArgb(args[1]&0xFF,(args[1]>>8)&0xFF,(args[1]>>16)&0xFF);
            return Value.Null;
        }
        [GMLFunction(2)]
        public static Value window_set_click(params Value[] args)
        {
            System.Windows.Forms.Form f = forms[args[0]];
            ((window)f.Tag).click = new GameCreator.Runtime.Interpreter.ScriptFunction(null, args[1]);
            return 0;
        }
        [GMLFunction(2)]
        public static Value window_set_create(params Value[] args)
        {
            System.Windows.Forms.Form f = forms[args[0]];
            ((window)f.Tag).create = new GameCreator.Runtime.Interpreter.ScriptFunction(null, args[1]);
            return 0;
        }
        [GMLFunction(6)]
        public static Value window_add_button(params Value[] args)
        {
            System.Windows.Forms.Form t = forms[args[0]];
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            b.Text = args[5];
            b.Location = new System.Drawing.Point(args[1], args[2]);
            b.Size = new System.Drawing.Size(args[3], args[4]);
            t.Controls.Add(b);
            b.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
            return 0;
        }
        static void m_Click(object sender, EventArgs e)
        {
            window w = (window)(((System.Windows.Forms.Form)sender).Tag);
            if (w.click == null) return;
            Env.Current = w.inst;
            w.click.Execute();
        }
        static void m_Load(object sender, EventArgs e)
        {
 	        window w = (window)(((System.Windows.Forms.Form)sender).Tag);
            if (w.create == null) return;
            Env.Current = w.inst;
            w.create.Execute();
        }
    }
}
