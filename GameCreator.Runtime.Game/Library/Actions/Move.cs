using System;
using System.Collections.Generic;
using System.Text;
using GameCreator.Framework;
using GameCreator.Runtime.Library;

namespace GameCreator.Runtime.Game.Library.Actions
{
    public static partial class LibraryFunctions
    {
        [GmlFunction]
        public static int action_move(string direction, double speed)
        {
            List<double> dirs = new List<double>();
            if (direction[0] == '1') dirs.Add(-135.0);
            if (direction[1] == '1') dirs.Add(- 90.0);
            if (direction[2] == '1') dirs.Add(- 45.0);
            if (direction[3] == '1') dirs.Add( 180.0);
            if (direction[4] == '1') dirs.Add(-  1.0);
            if (direction[5] == '1') dirs.Add(   0.0);
            if (direction[6] == '1') dirs.Add( 135.0);
            if (direction[7] == '1') dirs.Add(  90.0);
            if (direction[8] == '1') dirs.Add(  45.0);
            if (dirs.Count == 0)
                return 0;
            double dir = dirs[GmlFunctions.rnd.Next(dirs.Count)];
            if (dir == -1.0f)
            {
                Game.Current.speed = 0;
            }
            else
            {
                Game.Current.speed = ExecutionContext.Globals.argument_relative ? Game.Current.speed + speed : speed;
                Game.Current.direction = dir;
            }
            return 0;
        }
        [GmlFunction]
        public static Value action_set_motion(params Value[] args)
        {
            if (ExecutionContext.Globals.argument_relative)
            {
                Game.Current.AddSpeedVector(
                    GmlFunctions.lengthdir_x(args[1], args[0]),
                    GmlFunctions.lengthdir_y(args[1], args[0])
                    );
            }
            else
            {
                Game.Current.direction = args[0];
                Game.Current.speed = args[1];
            }
            return 0;
        }
        [GmlFunction]
        public static Value action_move_point(params Value[] args)
        {
            Game.Current.direction = 
                GmlFunctions.point_direction(
                 Game.Current.x, 
                 Game.Current.y, 
                 ExecutionContext.Globals.argument_relative ? Game.Current.x + args[0] : args[0],
                 ExecutionContext.Globals.argument_relative ? Game.Current.y + args[1] : args[0]
                );
            Game.Current.speed = args[2];
            return 0;
        }
        [GmlFunction]
        public static Value action_set_hspeed(params Value[] args)
        {
            Game.Current.hspeed = ExecutionContext.Globals.argument_relative ? Game.Current.hspeed + args[0] : args[0];
            return 0;
        }
        [GmlFunction]
        public static Value action_set_vspeed(params Value[] args)
        {
            Game.Current.vspeed = ExecutionContext.Globals.argument_relative ? Game.Current.vspeed + args[0] : args[0];
            return 0;
        }
        [GmlFunction]
        public static Value action_set_gravity(params Value[] args)
        {
            Game.Current.gravity_direction = ExecutionContext.Globals.argument_relative ? Game.Current.gravity_direction + args[0] : args[0];
            Game.Current.gravity = ExecutionContext.Globals.argument_relative ? Game.Current.gravity + args[1] : args[1];
            return 0;
        }
        [GmlFunction]
        public static Value action_reverse_xdir(params Value[] args)
        {
            Game.Current.hspeed = -Game.Current.hspeed;
            return 0;
        }
        [GmlFunction]
        public static Value action_reverse_ydir(params Value[] args)
        {
            Game.Current.vspeed = -Game.Current.vspeed;
            return 0;
        }
        [GmlFunction]
        public static Value action_set_friction(params Value[] args)
        {
            Game.Current.friction = ExecutionContext.Globals.argument_relative ? Game.Current.friction + args[0] : args[0];
            return 0;
        }
        [GmlFunction]
        public static Value action_move_to(params Value[] args)
        {
            Game.Current.x = ExecutionContext.Globals.argument_relative ? Game.Current.x + args[0] : args[0];
            Game.Current.y = ExecutionContext.Globals.argument_relative ? Game.Current.y + args[1] : args[1];
            return 0;
        }
        [GmlFunction]
        public static Value action_move_start(params Value[] args)
        {
            Game.Current.x = Game.Current.xstart;
            Game.Current.y = Game.Current.ystart;
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
