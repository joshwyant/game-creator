using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime
{
    public class Globals
    {
        public int current_time { get { return Environment.TickCount; } }
        public ArgumentList argument = new ArgumentList();
        public bool argument_relative;
        public Value argument0 { get { return argument[0]; } set { argument[0] = value; } }
        public Value argument1 { get { return argument[1]; } set { argument[1] = value; } }
        public Value argument2 { get { return argument[2]; } set { argument[2] = value; } }
        public Value argument3 { get { return argument[3]; } set { argument[3] = value; } }
        public Value argument4 { get { return argument[4]; } set { argument[4] = value; } }
        public Value argument5 { get { return argument[5]; } set { argument[5] = value; } }
        public Value argument6 { get { return argument[6]; } set { argument[6] = value; } }
        public Value argument7 { get { return argument[7]; } set { argument[7] = value; } }
        public Value argument8 { get { return argument[8]; } set { argument[8] = value; } }
        public Value argument9 { get { return argument[9]; } set { argument[9] = value; } }
        public Value argument10 { get { return argument[10]; } set { argument[10] = value; } }
        public Value argument11 { get { return argument[11]; } set { argument[11] = value; } }
        public Value argument12 { get { return argument[12]; } set { argument[12] = value; } }
        public Value argument13 { get { return argument[13]; } set { argument[13] = value; } }
        public Value argument14 { get { return argument[14]; } set { argument[14] = value; } }
        public Value argument15 { get { return argument[15]; } set { argument[15] = value; } }
    }
}
