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
        public static Value action_create_object(params Value[] args)
        {
            GmlFunctions.instance_create(
                ExecutionContext.Globals.argument_relative ? Game.Current.x + args[1] : args[1],
                ExecutionContext.Globals.argument_relative ? Game.Current.y + args[2] : args[2],
                args[0]
            );
            return 0;
        }
        [GmlFunction]
        public static Value action_create_object_motion(params Value[] args)
        {
            var e = GmlFunctions.CreateInstance(
                args[0],
                ExecutionContext.Globals.argument_relative ? Game.Current.x + args[1] : args[1],
                ExecutionContext.Globals.argument_relative ? Game.Current.y + args[2] : args[2]
            ) as GameInstance;
            if (e != null)
            {
                e.direction = args[4];
                e.speed = args[3];
                LibraryContext.Current.PerformEvent(e, EventType.Create, 0);
            }
            return 0;
        }
        [GmlFunction]
        public static Value action_create_object_random(params Value[] args)
        {
            List<int> list = new List<int>(4);
            for (int i = 0; i < 4; i++)
            {
                if (LibraryContext.Current.Resources.Objects.ContainsKey(args[i]))
                    list.Add(args[i]);
            }
            if (list.Count != 0)
                GmlFunctions.CreateInstance(list[GmlFunctions.rnd.Next(list.Count)], args[4], args[5]);
            return 0;
        }
        [GmlFunction]
        public static Value action_change_object(params Value[] args)
        {
            GameCreator.Framework.Object obj;
            if (LibraryContext.Current.Resources.Objects.TryGetValue(args[0], out obj))
            {
                if (args[1])
                    LibraryContext.Current.PerformEvent(Game.Current, EventType.Destroy, 0);
                Game.Current.ObjectIndex = obj.Id;
                if (args[1])
                    LibraryContext.Current.PerformEvent(Game.Current, EventType.Create, 0);
            }
            else
            {
                throw new ProgramError(string.Format("Asking to change into non-existing object: {0}", args[0]), ErrorSeverity.Error, 0, 0);
            }
            return 0;
        }
        [GmlFunction]
        public static Value action_kill_object(params Value[] args)
        {
            LibraryContext.Current.PerformEvent(Game.Current, EventType.Destroy, 0);
            Game.Current.Destroyed = true;
            return 0;
        }
        [GmlFunction]
        public static Value action_kill_position(params Value[] args)
        {
            return 0;
        }
        // gm7 (or gm6)
        [GmlFunction]
        public static Value action_sprite_set(params Value[] args)
        {
            Game.Current.sprite_index = args[0];
            Game.Current.image_single = args[1];
            Game.Current.image_speed = args[2];
            return 0;
        }
        [GmlFunction]
        public static Value action_sprite_transform(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_sprite_color(params Value[] args)
        {
            return 0;
        }
        // <= gm5? (gm6 maybe)
        [GmlFunction]
        public static Value action_set_sprite(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_sound(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_end_sound(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_sound(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_previous_room(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_next_room(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_current_room(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_another_room(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_previous_room(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_if_next_room(params Value[] args)
        {
            return 0;
        }
    }
}
