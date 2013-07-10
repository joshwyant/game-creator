using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using System.Reflection;
using System.Reflection.Emit;

namespace GameCreator.IDE
{
    [Serializable]
    class EXEBuilder
    {
        string exename;
        string pathname;
        string asmname;
        [NonSerialized] AssemblyBuilder asm;
        public EXEBuilder(string path)
        {
            exename = path.Contains('/') ? path.Substring(path.LastIndexOf('/') + 1) : path;
            pathname = path.Contains('/') ? path.Remove(path.LastIndexOf('/')) : null;
            asmname = exename.Contains('.') ? exename.Remove(exename.LastIndexOf('.')) : exename;
            System.Reflection.Emit.AssemblyBuilder asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(asmname), AssemblyBuilderAccess.RunAndSave, pathname);
        }
    }
}
