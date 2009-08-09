using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Interpreter;

namespace GameCreator
{
    // Holds the GML functions
    public static class Functions
    {
        public static Random rnd = new Random(System.Environment.TickCount);
        readonly static DateTime epoch = new DateTime(1899, 12, 30);
        static Dictionary<int, System.Windows.Forms.Form> forms = new Dictionary<int, System.Windows.Forms.Form>();
        static int formc = 0;
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
         * Functions
         */
        #region Real-valued functions
        [GMLFunction(1)]
        public static Value random(params Value[] args)
        {
            return new Value(rnd.NextDouble() * args[0].Real);
        }
        [GMLFunction(-1)]
        public static Value choose(params Value[] args)
        {
            return args[rnd.Next(args.Length)];
        }
        [GMLFunction(1)]
        public static Value abs(params Value[] args)
        {
            return new Value(Math.Abs(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value sign(params Value[] args)
        {
            return new Value(Math.Sign(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value round(params Value[] args)
        {
            return new Value(Math.Round(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value floor(params Value[] args)
        {
            return new Value(Math.Floor(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value ceil(params Value[] args)
        {
            return new Value(Math.Ceiling(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value frac(params Value[] args)
        {
            double d = args[0].Real;
            return new Value(d < 0 ? d + Math.Truncate(d) : d - Math.Truncate(d));
        }
        [GMLFunction(1)]
        public static Value sqrt(params Value[] args)
        {
            return new Value(Math.Sqrt(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value sqr(params Value[] args)
        {
            return new Value(args[0].Real*args[0].Real);
        }
        [GMLFunction(2)]
        public static Value power(params Value[] args)
        {
            return new Value(Math.Pow(args[0].Real, args[1].Real));
        }
        [GMLFunction(1)]
        public static Value exp(params Value[] args)
        {
            return new Value(Math.Exp(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value ln(params Value[] args)
        {
            return new Value(Math.Log(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value log2(params Value[] args)
        {
            return new Value(Math.Log(args[0].Real, 2.0));
        }
        [GMLFunction(1)]
        public static Value log10(params Value[] args)
        {
            return new Value(Math.Log10(args[0].Real));
        }
        [GMLFunction(2)]
        public static Value logn(params Value[] args)
        {
            return new Value(Math.Log(args[1].Real, args[0].Real));
        }
        [GMLFunction(1)]
        public static Value sin(params Value[] args)
        {
            return new Value(Math.Sin(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value cos(params Value[] args)
        {
            return new Value(Math.Cos(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value tan(params Value[] args)
        {
            return new Value(Math.Tan(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value arccos(params Value[] args)
        {
            return new Value(Math.Acos(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value arcsin(params Value[] args)
        {
            return new Value(Math.Asin(args[0].Real));
        }
        [GMLFunction(1)]
        public static Value arctan(params Value[] args)
        {
            return new Value(Math.Atan(args[0].Real));
        }
        [GMLFunction(2)]
        public static Value arctan2(params Value[] args)
        {
            return new Value(Math.Atan2(args[0].Real, args[1].Real));
        }
        [GMLFunction(1)]
        public static Value degtorad(params Value[] args)
        {
            return new Value(args[0].Real*Math.PI/180.0);
        }
        [GMLFunction(1)]
        public static Value radtodeg(params Value[] args)
        {
            return new Value(args[0].Real/Math.PI*180.0);
        }
        [GMLFunction(-1)]
        public static Value min(params Value[] args)
        {
            bool real = false, str = false;
            double min_real = 0.0;
            string min_str = String.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IsString)
                {
                    if (!str) min_str = args[i].String;
                    else if (string.CompareOrdinal(args[i].String, min_str) < 0) min_str = args[i].String;
                    str = true;
                }
                else
                {
                    if (!real) min_real = args[i].Real;
                    else if (args[i].Real < min_real) min_real = args[i].Real;
                    real = true;
                }
            }
            return str && !real ? new Value(min_str) : new Value(min_real);
        }
        [GMLFunction(-1)]
        public static Value max(params Value[] args)
        {
            bool real = false, str = false;
            double max_real = 0.0;
            string max_str = String.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IsString)
                {
                    if (str == false) max_str = args[i].String;
                    else if (string.CompareOrdinal(args[i].String, max_str) > 0) max_str = args[i].String;
                    str = true;
                }
                else
                {
                    if (real == false) max_real = args[i].Real;
                    else if (args[i].Real > max_real) max_real = args[i].Real;
                    real = true;
                }
            }
            return str ? new Value(max_str) : new Value(max_real);
        }
        [GMLFunction(-1)]
        public static Value mean(params Value[] args)
        {
            if (args.Length == 0) return Value.Zero;
            double d = 0;
            foreach (Value v in args)
                d += v.Real;
            return new Value(d/(double)args.Length);
        }
        [GMLFunction(-1)]
        public static Value median(params Value[] args)
        {
            List<double> dl = new List<double>();
            foreach (Value v in args)
                dl.Add(v.Real);
            double[] d = dl.ToArray();
            Array.Sort<double>(d);
            return args.Length % 2 == 1 ? new Value(d[d.Length/2]) : new Value(d[d.Length/2-1]);
        }
        [GMLFunction(4)]
        public static Value point_distance(params Value[] args)
        {
            double a = args[2].Real - args[0].Real;
            double b = args[3].Real - args[1].Real;
            return new Value(Math.Sqrt(a*a+b*b));
        }
        [GMLFunction(4)]
        public static Value point_direction(params Value[] args)
        {
            double a = args[2].Real - args[0].Real;
            double b = args[3].Real - args[1].Real;
            double dist = Math.Sqrt(a*a+b*b);
            if (dist == 0.0) return Value.Zero;
            a /= dist;
            b /= dist;
            double d = Math.Atan2(-b, a) / Math.PI * 180.0;
            return new Value(d < 0 ? d + 360.0 : d);
        }
        [GMLFunction(2)]
        public static Value lengthdir_x(params Value[] args)
        {
            return new Value(Math.Cos(args[1].Real * Math.PI / 180.0) * args[0].Real);
        }
        [GMLFunction(2)]
        public static Value lengthdir_y(params Value[] args)
        {
            return new Value(-Math.Sin(args[1].Real * Math.PI / 180.0) * args[0].Real);
        }
        [GMLFunction(1)]
        public static Value is_real(params Value[] args)
        {
            return new Value(args[0].IsReal ? 1.0 : 0.0);
        }
        [GMLFunction(1)]
        public static Value is_string(params Value[] args)
        {
            return new Value(args[0].IsString ? 1.0 : 0.0);
        }
        #endregion
        #region String handling functions
        [GMLFunction(1)]
        public static Value chr(params Value[] args)
        {
            return new Value(((char)(int)args[0].Real).ToString());
        }
        [GMLFunction(1)]
        public static Value ord(params Value[] args)
        {
            try { return new Value((double)(int)args[0].String[0]); }
            catch { return Value.Zero; }
        }
        [GMLFunction(1)]
        public static Value real(params Value[] args)
        {
            if (args[0].IsReal) return args[0];
            if (args[0].String.Trim().Length == 0) return Value.Zero;
            try
            {
                return new Value(double.Parse(args[0].String, System.Globalization.NumberStyles.Float));
            }
            catch
            {
                throw new ProgramError("Error in function real().");
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
            return new Value((double)args[0].String.Length);
        }
        [GMLFunction(2)]
        public static Value string_pos(params Value[] args)
        {
            return new Value(args[1].String.IndexOf(args[0].String)+1);
        }
        [GMLFunction(3)]
        public static Value string_copy(params Value[] args)
        {
            int i = (int)args[1].Real - 1;
            if (i < 0) i = 0;
            int l = (int)args[2].Real;
            if (i + l > args[0].String.Length) l = args[0].String.Length - i;
            return new Value(args[0].String.Substring(i, l));
        }
        [GMLFunction(2)]
        public static Value string_char_at(params Value[] args)
        {
            int i = Math.Max(0, (int)args[1].Real - 1);
            if (i >= args[0].String.Length) return Value.EmptyString;
            return new Value(args[0].String[i].ToString());
        }
        [GMLFunction(3)]
        public static Value string_delete(params Value[] args)
        {
            if (args[1].Real < 1 || args[2].Real <= 0 || args[1].Real > args[0].String.Length) return new Value(args[0].String);
            int i = (int)args[1].Real-1;
            int l = (int)args[2].Real;
            if (i + l > args[0].String.Length) l = args[0].String.Length - i;
            return new Value(args[0].String.Remove(i, l));
        }
        [GMLFunction(3)]
        public static Value string_insert(params Value[] args)
        {
            return new Value(args[1].String.Insert(Math.Max(Math.Min((int)args[2].Real-1, (int)args[1].String.Length), 0), args[0].String));
        }
        [GMLFunction(3)]
        public static Value string_replace(params Value[] args)
        {
            int pos = args[0].String.IndexOf(args[1].String);
            if (pos == -1) return new Value(args[0].String);
            return new Value(args[0].String.Remove(pos, args[1].String.Length).Insert(pos, args[2].String));
        }
        [GMLFunction(3)]
        public static Value string_replace_all(params Value[] args)
        {
            return new Value(args[0].String.Replace(args[1].String, args[2].String));
        }
        [GMLFunction(2)]
        public static Value string_count(params Value[] args)
        {
            if (args[0].String.Length == 0) return Value.Zero;
            int count = 0;
            int pos = -args[0].String.Length;
            for (; ; )
            {
                pos = args[1].String.IndexOf(args[0].String, pos + args[0].String.Length);
                if (pos == -1) break;
                count++;
            }
            return new Value(count);
        }
        [GMLFunction(1)]
        public static Value string_lower(params Value[] args)
        {
            return new Value(args[0].String.ToLowerInvariant());
        }
        [GMLFunction(1)]
        public static Value string_upper(params Value[] args)
        {
            return new Value(args[0].String.ToUpperInvariant());
        }
        [GMLFunction(2)]
        public static Value string_repeat(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[1].Real; i++)
                sb.Append(args[0].String);
            return new Value(sb.ToString());
        }
        [GMLFunction(1)]
        public static Value string_letters(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[0].String.Length; i++)
                if (char.IsLetter(args[0].String[i])) sb.Append(args[0].String[i]);
            return new Value(sb.ToString());
        }
        [GMLFunction(1)]
        public static Value string_digits(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[0].String.Length; i++)
                if (char.IsDigit(args[0].String[i])) sb.Append(args[0].String[i]);
            return new Value(sb.ToString());
        }
        [GMLFunction(1)]
        public static Value string_lettersdigits(params Value[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args[0].String.Length; i++)
                if (char.IsLetterOrDigit(args[0].String[i])) sb.Append(args[0].String[i]);
            return new Value(sb.ToString());
        }
        [GMLFunction(0)]
        public static Value clipboard_has_text(params Value[] args)
        {
            return new Value(System.Windows.Forms.Clipboard.ContainsText());
        }
        [GMLFunction(0)]
        public static Value clipboard_get_text(params Value[] args)
        {
            return new Value(System.Windows.Forms.Clipboard.ContainsText() ? System.Windows.Forms.Clipboard.GetText() : String.Empty);
        }
        [GMLFunction(1)]
        public static Value clipboard_set_text(params Value[] args)
        {
            if (!String.IsNullOrEmpty(args[0].String))
                System.Windows.Forms.Clipboard.SetText(args[0].String);
            return Value.Zero;
        }
        #endregion
        [GMLFunction(0)]
        public static Value date_current_datetime(params Value[] args)
        {
            return new Value(DateTime.Now.Subtract(new DateTime(1899,12,30)).TotalDays);
        }
        [GMLFunction(0)]
        public static Value date_current_date(params Value[] args)
        {
            return new Value(Math.Floor(DateTime.Now.Subtract(new DateTime(1899, 12, 30)).TotalDays));
        }
        [GMLFunction(0)]
        public static Value date_current_time(params Value[] args)
        {
            double val = DateTime.Now.Subtract(new DateTime(1899, 12, 30)).TotalDays;
            return new Value(val - Math.Floor(val));
        }
        [GMLFunction(6)]
        public static Value date_create_datetime(params Value[] args)
        {
            try
            {
                return new Value(new DateTime((int)args[0].Real, (int)args[1].Real, (int)args[2].Real, (int)args[3].Real, (int)args[4].Real, (int)args[5].Real).Subtract(epoch).TotalDays);
            }
            catch
            {
                return Value.Zero;
            }
        }
        [GMLFunction(1)]
        public static Value show_message(params Value[] args)
        {
            MessageForm mf = new MessageForm();
            mf.Message = newlines(args[0].String);
            mf.ShowDialog();
            //System.Windows.Forms.MessageBox.Show(newlines(args[0].String), Env.Title);
            return Value.Zero;
        }
        [GMLFunction(1)]
        public static Value execute_string(params Value[] args)
        {
            Env.Returned = Value.Zero;
            Parser p = new Parser(args[0].String);
            p.Parse().Exec();
            return Env.Returned;
        }
        class window
        {
            public Script click;
            public Script create;
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
            forms[(int)args[0].Real].BackColor = System.Drawing.Color.FromArgb((int)args[1].Real, (int)args[1].Real&0xFF, ((int)args[1].Real>>8)&0xFF, ((int)args[1].Real>>16)&0xff);
            return new Value();
        }
        [GMLFunction(2)]
        public static Value window_set_click(params Value[] args)
        {
            System.Windows.Forms.Form f = forms[(int)args[0].Real];
            ((window)f.Tag).click = new Script(null, args[1].String);
            return Value.Zero;
        }
        [GMLFunction(2)]
        public static Value window_set_create(params Value[] args)
        {
            System.Windows.Forms.Form f = forms[(int)args[0].Real];
            ((window)f.Tag).create = new Script(null, args[1].String);
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
        [GMLFunction(0)]
        public static Value game_end(params Value[] args)
        {
            System.Windows.Forms.Application.Exit();
            return new Value();
        }
        /*
        [GMLFunction(-1)]
        public static Value f(params Value[] args)
        {
            return new Value();
        }
        */
    }
}
