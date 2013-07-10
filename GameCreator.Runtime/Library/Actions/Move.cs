using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework.Gml;

namespace GameCreator.Framework.Library.Actions
{
    internal static partial class LibraryFunctions
    {
        /*
        [GMLFunction(-1)]
        public static Value f(params Value[] args)
        {
           return 0;
        }
        */
        [GMLFunction(2)]
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
                Env.Current.speed.Value = Value.Zero;
            }
            else
            {
                Env.Current.speed.Value = Env.argument_relative.value ? Env.Current.speed.Value + args[1] : args[1];
                Env.Current.direction.Value = dir;
            }
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_set_motion(params Value[] args)
        {
            if (Env.argument_relative.value)
            {
                Env.Current.AddSpeedVector(
                    GMLFunctions.lengthdir_x(args[1], args[0]),
                    GMLFunctions.lengthdir_y(args[1], args[0])
                    );
            }
            else
            {
                Env.Current.direction.Value = args[0];
                Env.Current.speed.Value = args[1];
            }
            return 0;
        }
        [GMLFunction(3)]
        public static Value action_move_point(params Value[] args)
        {
            Env.Current.direction.Value = 
                GMLFunctions.point_direction(
                 Env.Current.x.value, 
                 Env.Current.y.value, 
                 Env.argument_relative.value ? Env.Current.x.Value + args[0] : args[0],
                 Env.argument_relative.value ? Env.Current.y.Value + args[1] : args[0]
                );
            Env.Current.speed.Value = args[2];
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_set_hspeed(params Value[] args)
        {
            Env.Current.hspeed.Value = Env.argument_relative.value ? Env.Current.hspeed.Value + args[0] : args[0];
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_set_vspeed(params Value[] args)
        {
            Env.Current.vspeed.Value = Env.argument_relative.value ? Env.Current.vspeed.Value + args[0] : args[0];
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_set_gravity(params Value[] args)
        {
            Env.Current.gravity_direction.value = Env.argument_relative.value ? Env.Current.gravity_direction.value + args[0] : args[0];
            Env.Current.gravity.value = Env.argument_relative.value ? Env.Current.gravity.Value + args[1] : args[1];
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_reverse_xdir(params Value[] args)
        {
            Env.Current.hspeed.Value = -Env.Current.hspeed.Value.Real;
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_reverse_ydir(params Value[] args)
        {
            Env.Current.vspeed.Value = -Env.Current.vspeed.Value.Real;
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_set_friction(params Value[] args)
        {
            Env.Current.friction.value = Env.argument_relative.value ? Env.Current.friction.Value + args[0] : args[0];
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_move_to(params Value[] args)
        {
            Env.Current.x.value = Env.argument_relative.value ? Env.Current.x.Value + args[0] : args[0];
            Env.Current.y.value = Env.argument_relative.value ? Env.Current.y.Value + args[1] : args[1];
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_move_start(params Value[] args)
        {
            Env.Current.x.value = Env.Current.xstart.value;
            Env.Current.y.value = Env.Current.ystart.value;
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_move_random(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_snap(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_wrap(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(3)]
        public static Value action_move_contact(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_bounce(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(4)]
        public static Value action_path(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_path_end(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_path_position(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_path_speed(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(4)]
        public static Value action_linear_step(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(4)]
        public static Value action_potential_step(params Value[] args)
        {
            return 0;
        }
    }
}
