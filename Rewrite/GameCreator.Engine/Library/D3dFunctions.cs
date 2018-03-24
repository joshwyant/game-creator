using System;

namespace GameCreator.Engine.Library
{
    public class D3dFunctions
    {
        public GameContext Context { get; }
        
        public D3dFunctions(GameContext context)
        {
            Context = context;
        }

        public void Start3dMode()
        {
            Context.Start3dMode();
        }

        public void End3dMode()
        {
            Context.End3dMode();
        }
        
        public void SetProjectionPerspective(double x, double y, double w, double h, double angle)
        {
            var aspectRatio = w / h;
            var xcenter = x + w * 0.5;
            var ycenter = y + h * 0.5;
            var c = Math.Cos(angle * Math.PI / 180.0);
            var s = Math.Sin(angle * Math.PI / 180.0);
            
            Context.Graphics.SetProjection(
                xcenter, 
                ycenter, 
                -w, 
                xcenter, 
                ycenter, 
                0, 
                -s, // xup = 0, rotated by angle
                c, // yup = 1, rotated by angle
                0, 
                2*Math.Atan(0.5 / aspectRatio), 
                aspectRatio, 
                1, 
                32000);
        }


        public void SetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup,
            double yup, double zup, double angle, double aspect, double znear, double zfar)
        {
            Context.Graphics.SetProjection(xfrom, yfrom, zfrom, xto, yto, zto, xup, yup, zup, angle, aspect, znear, zfar);
        }
        public void SetOrthographicProjection(double x, double y, double w, double h, double angle)
        {
            Context.Graphics.SetOrthographicProjection(x, y, w, h, angle);
        }

        public void Set3dDrawDepth(double depth)
        {
            Context.Graphics.DrawDepth3d = depth;
        }
    }
}