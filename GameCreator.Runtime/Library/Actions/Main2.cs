using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Library.Actions
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
        [GMLFunction(2)]
        public static Value action_set_alarm(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_sleep(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_set_timeline(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(4)]
        public static Value action_timeline_set(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_set_timeline_position(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_set_timeline_speed(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_timeline_start(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_timeline_pause(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_timeline_stop(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_message(params Value[] args)
        {
            GMLFunctions.show_message(args[0].ToString());
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_show_info(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(3)]
        public static Value action_show_video(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_splash_text(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_splash_image(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_splash_web(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_splash_video(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(5)]
        public static Value action_splash_settings(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_restart_game(params Value[] args)
        {
            // ... TODO
            return 0;
        }
        [GMLFunction(0)]
        public static Value action_end_game(params Value[] args)
        {
            GMLFunctions.game_end();
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_save_game(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(1)]
        public static Value action_load_game(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(3)]
        public static Value action_replace_sprite(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_replace_sound(params Value[] args)
        {
            return 0;
        }
        [GMLFunction(2)]
        public static Value action_replace_background(params Value[] args)
        {
            return 0;
        }
    }
}
