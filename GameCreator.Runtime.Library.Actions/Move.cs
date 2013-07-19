using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Library.Actions
{
    internal static partial class LibraryFunctions
    {
        /*
        [GmlFunction]
        public static Value f(params Value[] args)
        {
           return 0;
        }
        */
        [GmlFunction]
        public static Value action_move(params Value[] args)
        {
            string str = args[0];
            List<double> dirs = new List<double>();
            if (str[0] == '1') dirs.Add(-135.0);
            if (str[1] == '1') dirs.Add(- 90.0);
            if (str[2] == '1') dirs.Add(- 45.0);
            if (str[3] == '1') dirs.Add( 180.0);
            if (str[4] == '1') dirs.Add(-  1.0);
            if (str[5] == '1') dirs.Add(   0.0);
            if (str[6] == '1') dirs.Add( 135.0);
            if (str[7] == '1') dirs.Add(  90.0);
            if (str[8] == '1') dirs.Add(  45.0);
            if (dirs.Count == 0)
                return 0;
            double dir = dirs[GMLFunctions.rnd.Next(dirs.Count)];
            if (dir == -1.0f)
            {
                ExecutionContext.Current.speed.Value = Value.Zero;
            }
            else
            {
                ExecutionContext.Current.speed.Value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.speed.Value + args[1] : args[1];
                ExecutionContext.Current.direction.Value = dir;
            }
            return 0;
        }
        [GmlFunction]
        public static Value action_set_motion(params Value[] args)
        {
            if (ExecutionContext.argument_relative.value)
            {
                ExecutionContext.Current.AddSpeedVector(
                    GMLFunctions.lengthdir_x(args[1], args[0]),
                    GMLFunctions.lengthdir_y(args[1], args[0])
                    );
            }
            else
            {
                ExecutionContext.Current.direction.Value = args[0];
                ExecutionContext.Current.speed.Value = args[1];
            }
            return 0;
        }
        [GmlFunction]
        public static Value action_move_point(params Value[] args)
        {
            ExecutionContext.Current.direction.Value = 
                GMLFunctions.point_direction(
                 ExecutionContext.Current.x.value, 
                 ExecutionContext.Current.y.value, 
                 ExecutionContext.argument_relative.value ? ExecutionContext.Current.x.Value + args[0] : args[0],
                 ExecutionContext.argument_relative.value ? ExecutionContext.Current.y.Value + args[1] : args[0]
                );
            ExecutionContext.Current.speed.Value = args[2];
            return 0;
        }
        [GmlFunction]
        public static Value action_set_hspeed(params Value[] args)
        {
            ExecutionContext.Current.hspeed.Value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.hspeed.Value + args[0] : args[0];
            return 0;
        }
        [GmlFunction]
        public static Value action_set_vspeed(params Value[] args)
        {
            ExecutionContext.Current.vspeed.Value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.vspeed.Value + args[0] : args[0];
            return 0;
        }
        [GmlFunction]
        public static Value action_set_gravity(params Value[] args)
        {
            ExecutionContext.Current.gravity_direction.value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.gravity_direction.value + args[0] : args[0];
            ExecutionContext.Current.gravity.value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.gravity.Value + args[1] : args[1];
            return 0;
        }
        [GmlFunction]
        public static Value action_reverse_xdir(params Value[] args)
        {
            ExecutionContext.Current.hspeed.Value = -ExecutionContext.Current.hspeed.Value.Real;
            return 0;
        }
        [GmlFunction]
        public static Value action_reverse_ydir(params Value[] args)
        {
            ExecutionContext.Current.vspeed.Value = -ExecutionContext.Current.vspeed.Value.Real;
            return 0;
        }
        [GmlFunction]
        public static Value action_set_friction(params Value[] args)
        {
            ExecutionContext.Current.friction.value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.friction.Value + args[0] : args[0];
            return 0;
        }
        [GmlFunction]
        public static Value action_move_to(params Value[] args)
        {
            ExecutionContext.Current.x.value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.x.Value + args[0] : args[0];
            ExecutionContext.Current.y.value = ExecutionContext.argument_relative.value ? ExecutionContext.Current.y.Value + args[1] : args[1];
            return 0;
        }
        [GmlFunction]
        public static Value action_move_start(params Value[] args)
        {
            ExecutionContext.Current.x.value = ExecutionContext.Current.xstart.value;
            ExecutionContext.Current.y.value = ExecutionContext.Current.ystart.value;
            return 0;
        }
        [GmlFunction]
        public static Value action_move_random(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_snap(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_wrap(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_move_contact(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_bounce(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_path(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_path_end(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_path_position(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_path_speed(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_linear_step(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_potential_step(params Value[] args)
        {
            return 0;
        }
    }
}
