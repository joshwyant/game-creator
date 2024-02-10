using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework
{
    public interface IFunction
    {
        string Name { get; set; }
        /// <summary>
        /// The argument count for the function. Use -1 for a variable argument count.
        /// </summary>
        int Argc { get; set; }
    }
}
