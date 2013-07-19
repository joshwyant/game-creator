using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime.Library.Actions
{
    internal static partial class LibraryFunctions
    {
        /*
        [GmlFunction]
        public static Value f(params Value[] args)
        {
           return new Value();
        }
        */
        [GmlFunction]
        public static Value action_if_empty(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_collision(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_object(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_number(params Value[] args)
        {
            int num = 0;
            foreach (RuntimeInstance e in ExecutionContext.Instances.Values) if (e.object_index.value == (int)args[0]) num++;
            switch ((int)args[2])
            {
                case 0: return num == args[1];
                case 1: return num < args[1];
                case 2: return num > args[1];
            }
            return false;
        }
        [GmlFunction]
        public static Value action_if_dice(params Value[] args)
        {
            return GmlFunctions.rnd.Next(0, args[0]) == 0;
        }
        [GmlFunction]
        public static Value action_if_question(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if(params Value[] args)
        {
            return (bool)args[0];
        }
        [GmlFunction]
        public static Value action_if_mouse(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_aligned(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_inherited(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_execute_script(params Value[] args)
        {
            return (Script.Manager.Resources[args[0]] as Script).CompiledScript.Execute(args[1], args[2], args[3], args[4], args[5]);
        }
        [GmlFunction]
        public static Value action_if_variable(params Value[] args)
        {
            switch ((int)args[2])
            {
                case 0: return args[0].IsString == args[1].IsString ? args[0].IsString ? args[0].String == args[1] : args[0].Real == args[1] : false;
                case 1: return args[0].IsString == args[1].IsString ? args[0].IsString ? String.Compare(args[0], args[1]) < 0 : args[0].Real < args[1] : false;
                case 2: return args[0].IsString == args[1].IsString ? args[0].IsString ? String.Compare(args[0], args[1]) > 0 : args[0].Real > args[1] : false;
            }
            return false;
        }
        [GmlFunction]
        public static Value action_draw_variable(params Value[] args)
        {
            return 0;
        }
    }
}
