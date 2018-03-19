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
        
        public void SetProjectionPerspective(float x, float y, float w, float h, float angle)
        {
            var aspectRatio = w / h;
            var xcenter = x + w * 0.5f;
            var ycenter = y + h * 0.5f;
            var c = (float)Math.Cos(angle * Math.PI / 180.0);
            var s = (float)Math.Sin(angle * Math.PI / 180.0);
            
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
                (float)(2*Math.Atan(0.5 / aspectRatio)), 
                aspectRatio, 
                1, 
                32000);
        }


        public void SetProjection(float xfrom, float yfrom, float zfrom, float xto, float yto, float zto, float xup,
            float yup, float zup, float angle, float aspect, float znear, float zfar)
        {
            Context.Graphics.SetProjection(xfrom, yfrom, zfrom, xto, yto, zto, xup, yup, zup, angle, aspect, znear, zfar);
        }
        public void SetOrthographicProjection(float x, float y, float w, float h, float angle)
        {
            Context.Graphics.SetOrthographicProjection(x, y, w, h, angle);
        }

        public void Set3dDrawDepth(float depth)
        {
            Context.Graphics.DrawDepth3d = depth;
        }
    }
}