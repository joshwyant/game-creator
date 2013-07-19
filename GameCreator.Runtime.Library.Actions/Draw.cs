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
        public static Value action_draw_sprite(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_background(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_text(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_text_transformed(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_rectangle(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_gradient_hor(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_gradient_vert(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_ellipse(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_ellipse_gradient(params Value[] args)
        {
            double w = (args[2] - args[0]) * 0.5;
            double h = (args[3] - args[1]) * 0.5;
            double x = args[0] + w;
            double y = args[1] + h;
            if (ExecutionContext.argument_relative.value)
            {
                x += ExecutionContext.Current.x.value;
                y += ExecutionContext.Current.y.value;
            }
            GL.Disable(EnableCap.Texture2D);
            GL.Begin(BeginMode.TriangleFan);
            GL.Color3(System.Drawing.Color.FromArgb(args[4] & 0xFF, (args[4] >> 8) & 0xFF, (args[4] >> 16) & 0xFF));
            GL.Vertex2(x, y);
            for (double d = 0.0; d <= 360.0; d += 15.0)
            {
                GL.Color3(
                    System.Drawing.Color.FromArgb(
                    args[5] & 0xFF,
                    (args[5] >> 8) & 0xFF,
                    (args[5] >> 16) & 0xFF
                    ));
                GL.Vertex2(
                    x + Math.Cos(d * Math.PI / 180.0f) * w,
                    y - Math.Sin(d * Math.PI / 180.0f) * h
                    ); 
            }
            GL.End();
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_line(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_draw_arrow(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_color(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_font(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_fullscreen(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_snapshot(params Value[] args)
        {
            return 0;
        }
        [GmlFunction]
        public static Value action_effect(params Value[] args)
        {
            return 0;
        }
    }
}
