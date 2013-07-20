using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;
using System.Linq;
using GameCreator.Runtime.Library;

namespace GameCreator.Runtime.Game.Library.Actions
{
    public static partial class LibraryFunctions
    {
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
        public static bool action_if_number(int object_index, int inum, int action)
        {
            int num = 0;
            foreach (var e in ExecutionContext.Instances.Cast<GameInstance>()) if (e.object_index == object_index) num++;
            switch (action)
            {
                case 0: return num == inum;
                case 1: return num < inum;
                case 2: return num > inum;
            }
            return false;
        }
        [GmlFunction]
        public static bool action_if_dice(int bound)
        {
            return GmlFunctions.rnd.Next(0, bound) == 0;
        }
        [GmlFunction]
        public static Value action_if_question(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if(bool arg)
        {
            return arg;
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
            return Script.Manager[args[0]].ExecutionDelegate(args[1], args[2], args[3], args[4], args[5]);
        }
        [GmlFunction]
        public static Value action_if_variable(params Value[] args)
        {
            switch ((int)args[2])
            {
                case 0: return args[0].IsString == args[1].IsString ? args[0].IsString ? (args[0] == args[1]) : (args[0] == args[1]) : (Value)false;
                case 1: return args[0].IsString == args[1].IsString ? args[0].IsString ? String.Compare(args[0], args[1]) < 0 : args[0] < args[1] : false;
                case 2: return args[0].IsString == args[1].IsString ? args[0].IsString ? String.Compare(args[0], args[1]) > 0 : args[0] > args[1] : false;
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
