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
           return new Value();
        }
        */
        [GMLFunction(3)]
        public static Value action_create_object(params Value[] args)
        {
            GMLFunctions.instance_create(
                ExecutionContext.argument_relative.value ? ExecutionContext.Current.x.Value + args[1] : args[1],
                ExecutionContext.argument_relative.value ? ExecutionContext.Current.y.Value + args[2] : args[2],
                args[0]
            );
            return 0;
        }
        [GMLFunction(5)]
        public static Value action_create_object_motion(params Value[] args)
        {
            Instance e = GMLFunctions.CreateInstance(
                args[0],
                ExecutionContext.argument_relative.value ? ExecutionContext.Current.x.Value + args[1] : args[1],
                ExecutionContext.argument_relative.value ? ExecutionContext.Current.y.Value + args[2] : args[2]
            );
            if (e != null)
            {
                e.direction.Value = args[4];
                e.speed.Value = args[3];
                (Object.Manager.Resources[args[0]] as Object).PerformEvent(e, EventType.Create, 0);
            }
            return 0;
        }
        [GMLFunction(6)]
        public static Value action_create_object_random(params Value[] args)
        {
            List<int> list = new List<int>(4);
            for (int i = 0; i < 4; i++)
            {
                if (Object.Manager.Resources.ContainsKey(args[i]))
                    list.Add(args[i]);
            }
            if (list.Count != 0)
                GMLFunctions.CreateInstance(list[GMLFunctions.rnd.Next(list.Count)], args[4], args[5]);
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_change_object(params Value[] args)
        {
            IndexedResource res;
            if (Object.Manager.Resources.TryGetValue(args[0], out res))
            {
                if (args[1])
                    (Object.Manager.Resources[ExecutionContext.Current.object_index.value] as Object).PerformEvent(ExecutionContext.Current, EventType.Destroy, 0);
                ExecutionContext.Current.object_index.value = res.Index;
                if (args[1])
                    (res as Object).PerformEvent(ExecutionContext.Current, EventType.Create, 0);
            }
            else
            {
                throw new ProgramError(string.Format("Asking to change into non-existing object: {0}", args[0]), ErrorSeverity.Error, 0, 0);
            }
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_kill_object(params Value[] args)
        {
            (Object.Manager.Resources[ExecutionContext.Current.object_index.value] as Object).PerformEvent(ExecutionContext.Current, EventType.Destroy, 0);
            ExecutionContext.Current.Destroyed = true;
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_kill_position(params Value[] args)
        {
            return 0;
        }
        // gm7 (or gm6)
        [GMLFunction(3)]
        public static Value action_sprite_set(params Value[] args)
        {
            ExecutionContext.Current.sprite_index.value = args[0];
            ExecutionContext.Current.image_single.value = args[1];
            ExecutionContext.Current.image_speed.value = args[2];
            return 0;
        }
        [GMLFunction(4)]
        public static Value action_sprite_transform(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_sprite_color(params Value[] args)
        {
            return 0;
        }
        // <= gm5? (gm6 maybe)
        [GMLFunction(2)]
        public static Value action_set_sprite(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_sound(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_end_sound(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_if_sound(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_previous_room(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_next_room(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_current_room(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_another_room(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_if_previous_room(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_if_next_room(params Value[] args)
        {
            return 0;
        }
    }
}
