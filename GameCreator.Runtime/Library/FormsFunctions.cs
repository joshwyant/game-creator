using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Interpreter;

namespace GameCreator.Runtime
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
            public GameCreator.Interpreter.Script click;
            public GameCreator.Interpreter.Script create;
            public Env inst;
        }
        [GMLFunction(1)]
        public static Value window_create(params Value[] args)
        {
            int ind = formc++;
            System.Windows.Forms.Form m = new System.Windows.Forms.Form();
            m.Text = args[0].String;
            forms.Add(ind, m);
            window w = new window();
            w.inst = Env.CreatePrivateInstance();
            w.inst.SetLocalVar("window_index", new Value(ind));
            m.Tag = w;
            m.Click += new EventHandler(m_Click);
            m.Load += new EventHandler(m_Load);
            return new Value(ind);
        }
        [GMLFunction(1)]
        public static Value window_close(params Value[] args)
        {
            forms[(int)args[0].Real].Close();
            forms.Remove((int)args[0].Real);
            return Value.Zero;
        }
        [GMLFunction(0)]
        public static Value window_count(params Value[] args)
        {
            return new Value(forms.Count);
        }
        [GMLFunction(1)]
        public static Value window_show(params Value[] args)
        {
            forms[(int)args[0].Real].Show();
            return new Value();
        }
        [GMLFunction(2)]
        public static Value window_set_color(params Value[] args)
        {
            forms[(int)args[0].Real].BackColor = System.Drawing.Color.FromArgb((int)args[1].Real&0xFF,((int)args[1].Real>>8)&0xFF,((int)args[1].Real>>16)&0xFF);
            return new Value();
        }
        [GMLFunction(2)]
        public static Value window_set_click(params Value[] args)
        {
            System.Windows.Forms.Form f = forms[(int)args[0].Real];
            ((window)f.Tag).click = new GameCreator.Interpreter.Script(null, args[1].String);
            return Value.Zero;
        }
        [GMLFunction(2)]
        public static Value window_set_create(params Value[] args)
        {
            System.Windows.Forms.Form f = forms[(int)args[0].Real];
            ((window)f.Tag).create = new GameCreator.Interpreter.Script(null, args[1].String);
            return Value.Zero;
        }
        [GMLFunction(6)]
        public static Value window_add_button(params Value[] args)
        {
            System.Windows.Forms.Form t = forms[(int)args[0].Real];
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            b.Text = args[5].String;
            b.Location = new System.Drawing.Point((int)args[1].Real, (int)args[2].Real);
            b.Size = new System.Drawing.Size((int)args[3].Real, (int)args[4].Real);
            t.Controls.Add(b);
            b.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control);
            return Value.Zero;
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
