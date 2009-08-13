using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.IDE
{
    interface IScriptExportable
    {
        void WriteToStream(System.IO.TextWriter stream);
    }
}
