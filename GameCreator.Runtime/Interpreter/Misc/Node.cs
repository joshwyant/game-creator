using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    public class Node
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Node(int line, int col) { Line = line; Column = col; }
    }
}
