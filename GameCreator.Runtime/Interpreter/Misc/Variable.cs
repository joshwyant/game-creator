using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    // I ALWAYS thought that GM had only 2 value types: real and string. But upon
    // writing this interpreter, I have discovered that this is not true. For instance,
    // up until now, I thought that an empty script returned 0 by default, since it
    // must have SOME value. But, that's not true! It returns neither a real nor string!
    // script() + script() is a type error; so is (script0()).x; is_real(script()) and
    // is_string(script()) are BOTH 0. I also noticed, that when a script calls a function
    // or script that returns a value, but does not return a value itself, the value returned
    // is that of the function called. So I concluded that there is a variable that keeps track
    // of the last returned value, reset to 0 when a script is called. Then I noticed that that
    // also happens when assigning variables. func().x = 5 gives a compile error. GM 4 doesn't even
    // catch all of the errors so I'm convinced, that the GM interpreter needs to be rewritten.
    // I can't emulate all of the bugs, so I'm going to do this the best I can.
    // ---------
    // The Variable class holds string and real values, in a 2 dimensional array.
    // The interpreter will throw an error if a variable 'IsReadOnly.'
    // Whenever an array index is set, space is added. As in GM:
    // - t corresponds to t[0,0].
    // - t[1] corresponds to t[0,1].
    // - if we initialize array t to have indices x and y:
    //   1. t[x,...] is an array of size y+1, with each t[x,0..y-1] = 0.
    //   2. t[x,y] = value;
    //   3. each t[0..x-1,...] is an array of length 1, with each t[0..x-1,0] equal to 0.
    //   t[2,2] = "str" ->
    //    t[0,...]: {0}
    //    t[1,...]: {0}
    //    t[2,...]: {0,0,"str"}
    //   t[0,0] = 7 ->
    //    t = 7;
    //    t[0] = 7;
    //   t[0,8] = t[8]; t[0,0] = t[0] = t;
    public class Variable
    {
        List<List<Value>> values;
        protected bool readOnly = false;
        protected GetAccessor get = null;
        protected SetAccessor set = null;
        public Variable()
        {
            values = new List<List<Value>>();
            values.Add(new List<Value>());
            values[0].Add(Value.Zero);
        }
        public Variable(Value val)
        {
            values = new List<List<Value>>();
            values.Add(new List<Value>());
            values[0].Add(val);
        }
        public Variable(int index, Value val)
        {
            values = new List<List<Value>>();
            this[index] = val;
        }
        public Variable(int i1, int i2, Value val)
        {
            values = new List<List<Value>>();
            this[i1, i2] = val;
        }
        public Variable(GetAccessor g)
        {
            readOnly = true;
            get = g;
        }
        public Variable(GetAccessor g, SetAccessor s)
        {
            get = g;
            set = s;
        }
        // The interpreter checks the array index.
        public bool CheckIndex(int i1, int i2)
        {
            return (get != null || (values.Count > i1 && values[i1].Count > i2));
        }
        public Value Value
        {
            get
            {
                return this[0,0];
            }
            set
            {
                this[0,0] = value;
            }
        }
        public Value this[int i1, int i2]
        {
            get
            {
                if (get == null)
                    return values[i1][i2];
                return get(i1, i2);
            }
            set
            {
                if (set != null)
                {
                    set(i1, i2, value);
                    return;
                }
                for (int i = values.Count; i <= i1; i++)
                {
                    values.Add(new List<Value>());
                    values[i].Add(Value.Zero);
                }
                for (int i = values[i1].Count; i <= i2; i++)
                    values[i1].Add(Value.Zero);
                values[i1][i2] = value;
            }
        }
        public Value this[int index]
        {
            get
            {
                return this[0, index];
            }
            set
            {
                this[0, index] = value;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
            }
        }
    }
}
