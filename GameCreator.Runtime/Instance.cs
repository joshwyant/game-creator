using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Runtime.Interpreter;

namespace GameCreator.Runtime
{
    public class Instance
    {
        internal Dictionary<string, Variable> instancevars = new Dictionary<string, Variable>();
        #region Instance variables and access methods
        int[] ialarm = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        double ddirection, dhspeed, dvspeed, dspeed;
        public Variable direction, hspeed, vspeed, speed, alarm;
        public IntVariable object_index, id, sprite_index, image_blend /* which I believe to be an int, I have no way to test it now. */;
        public RealVariable x, y, gravity, gravity_direction, friction, depth, image_speed, image_single, image_index,
            image_xscale, image_yscale, image_angle, image_alpha, xstart, ystart, xprevious, yprevious;
        public BoolVariable visible, solid, persistent;
        public Value get_direction(int i1, int i2) { return ddirection; }
        public void set_direction(int i1, int i2, Value v) { ddirection = v; sethspeedvspeed(); }
        public Value get_speed(int i1, int i2) { return dspeed; }
        public void set_speed(int i1, int i2, Value v) { dspeed = v; sethspeedvspeed(); }
        public Value get_alarm(int i1, int i2) { return ialarm[i1 != 0 || i2 >= 12 ? 0 : i2]; }
        public void set_alarm(int i1, int i2, Value v) { ialarm[i1 != 0 || i2 >= 12 ? 0 : i2] = v; }
        // used after setting vspeed or hspeed to set speed and direction variables.
        // resetdir indicates whether direction should be set to 0 by default if speed is 0.
        void setspeeddirection(bool resetdir)
        {
            dspeed = Math.Sqrt(dhspeed * dhspeed + dvspeed * dvspeed);
            if (dspeed == 0.0)
            {
                if (resetdir) ddirection = 0.0;
            }
            else
            {
                ddirection = Math.Atan2(-dvspeed / dspeed, dhspeed / dspeed) / Math.PI * 180.0;
                if (ddirection < 0.0)
                    ddirection += 360.0;
            }
        }
        // used after setting speed or direction to set vspeed and hspeed variables.
        void sethspeedvspeed()
        {
            dhspeed = Math.Cos(ddirection * Math.PI / 180.0) * dspeed;
            dvspeed = -Math.Sin(ddirection * Math.PI / 180.0) * dspeed;
        }
        public void SetSpeedVector(double hspeed, double vspeed)
        {
            dhspeed = hspeed;
            dvspeed = vspeed;
            setspeeddirection(false);
        }
        public void AddSpeedVector(double hspeed, double vspeed)
        {
            dhspeed += hspeed;
            dvspeed += vspeed;
            setspeeddirection(false);
        }
        public void SetMotion(double direction, double speed)
        {
            ddirection = direction;
            dspeed = speed;
            sethspeedvspeed();
        }
        Value get_hspeed(int i1, int i2) { return dhspeed; }
        void set_hspeed(int i1, int i2, Value v) { dhspeed = v; setspeeddirection(true); }
        Value get_vspeed(int i1, int i2) { return new Value(dvspeed); }
        void set_vspeed(int i1, int i2, Value v) { dvspeed = v; setspeeddirection(true); }
        #endregion
        public bool Destroyed = false;
        // use Env.CreateInstance() or Env.CreatePrivateInstance().
        internal Instance()
        {
            // read-only variables with get accessors
            object_index = DefineLocalVar("object_index", 0, true);
            id = DefineLocalVar("id", 0, true);
            // normal variables, with get/set accessors
            x = DefineLocalVar("x", 0.0, false);
            y = DefineLocalVar("y", 0.0, false);
            hspeed = DefineLocalVar("hspeed", get_hspeed, set_hspeed);
            vspeed = DefineLocalVar("vspeed", get_vspeed, set_vspeed);
            speed = DefineLocalVar("speed", get_speed, set_speed);
            direction = DefineLocalVar("direction", get_direction, set_direction);
            sprite_index = DefineLocalVar("sprite_index", -1, false);
            gravity = DefineLocalVar("gravity", 0.0, false);
            gravity_direction = DefineLocalVar("gravity_direction", 270.0, false);
            friction = DefineLocalVar("friction", 0.0, false);
            xstart = DefineLocalVar("xstart", 0.0, false);
            ystart = DefineLocalVar("ystart", 0.0, false);
            xprevious = DefineLocalVar("xprevious", 0.0, false);
            yprevious = DefineLocalVar("yprevious", 0.0, false);
            depth = DefineLocalVar("depth", 0.0, false);
            image_speed = DefineLocalVar("image_speed", 1.0, false);
            image_single = DefineLocalVar("image_single", -1.0, false);
            image_index = DefineLocalVar("image_index", 0.0, false);
            image_xscale = DefineLocalVar("image_xscale", 1.0, false);
            image_yscale = DefineLocalVar("image_yscale", 1.0, false);
            image_angle = DefineLocalVar("image_angle", 0.0, false);
            image_alpha = DefineLocalVar("image_alpha", 1.0, false);
            image_blend = DefineLocalVar("image_blend", 16777215, false); // c_white, (2^^24)-1
            alarm = DefineLocalVar("alarm", get_alarm, set_alarm);
        }
        private Variable DefineLocalVar(string p, GetAccessor getAccessor, SetAccessor setAccessor)
        {
            Variable t;
            instancevars.Add(p, t = new Variable(getAccessor, setAccessor));
            return t;
        }
        private RealVariable DefineLocalVar(string p, double initial, bool readOnly)
        {
            RealVariable v;
            instancevars.Add(p, v = new RealVariable(initial, readOnly));
            return v;
        }
        private IntVariable DefineLocalVar(string p, int initial, bool readOnly)
        {
            IntVariable v;
            instancevars.Add(p, v = new IntVariable(initial, readOnly));
            return v;
        }
        private BoolVariable DefineLocalVar(string p, bool initial, bool readOnly)
        {
            BoolVariable v;
            instancevars.Add(p, v = new BoolVariable(initial, readOnly));
            return v;
        }
        private StringVariable DefineLocalVar(string p, string initial, bool readOnly)
        {
            StringVariable v;
            instancevars.Add(p, v = new StringVariable(initial, readOnly));
            return v;
        }
        Variable DefineLocalVar(string p, GetAccessor getAccessor)
        {
            Variable t;
            instancevars.Add(p, t = new Variable(getAccessor));
            return t;
        }
        public void SetLocalVar(string name, Value val)
        {
            if (instancevars.ContainsKey(name))
                instancevars[name].Value = val;
            else
                instancevars.Add(name, new Variable(val));
        }
        public void SetLocalVar(string name, int index, Value val)
        {
            if (instancevars.ContainsKey(name))
                instancevars[name][index] = val;
            else
                instancevars.Add(name, new Variable(index, val));
        }
        public void SetLocalVar(string name, int i1, int i2, Value val)
        {
            if (instancevars.ContainsKey(name))
                instancevars[name][i1, i2] = val;
            else
                instancevars.Add(name, new Variable(i1, i2, val));
        }
        public Value GetLocalVar(string name)
        {
            return instancevars[name].Value;
        }
        public Value GetLocalVar(string name, int index)
        {
            return instancevars[name][index];
        }
        public Value GetLocalVar(string name, int i1, int i2)
        {
            return instancevars[name][i1, i2];
        }
        private void NewReadOnly(string p)
        {
            instancevars.Add(p, new Variable());
            instancevars[p].IsReadOnly = true;
        }
        internal void assign_id(int id)
        {
            this.id.value = id;
            Env.Instances.Add(id, this);
            Env.InstanceIds.Add(id);
        }
        internal void assign_id()
        {
            assign_id(++Env.ids);
        }
        // Execute a string. The string is cached, and subsequent calls of Exec() with the same code string
        //  execute code that is already compiled and cached. Code that is executed from a known location, i.e., a script,
        //  is recommended to have its own local code unit, so it does not have to be looked up in a table.
        public void Exec(string s)
        {
            Instance t = Env.Current;
            Env.Current = this;
            Env.Enter();
            // Make sure the code is in the cache
            if (!Env.CodeStrings.ContainsKey(s))
                Env.CodeStrings.Add(s, new CodeUnit(s));
            ((CodeUnit)Env.CodeStrings[s]).Run();
            Env.Leave();
            Env.Current = t;
        }
    }
}
