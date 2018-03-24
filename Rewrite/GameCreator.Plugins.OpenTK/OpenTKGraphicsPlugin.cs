using System;
using GameCreator.Engine;
using GameCreator.Engine.Api;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GameCreator.Plugins.OpenTK
{
    internal sealed class OpenTKGraphicsPlugin : IGraphicsPlugin
    {
        private GameCreatorOpenTKGameWindow GameWindow { get; }
        
        public OpenTKGraphicsPlugin(GameCreatorOpenTKGameWindow gameWindow)
        {
            GameWindow = gameWindow;
        }

        public void SetWindowSize(int width, int height)
        {
            GameWindow.SetWindowSize(width, height);
        }

        public void Run()
        {
            GameWindow.Run();
        }

        public event EventHandler<EventArgs> Load
        {
            add => GameWindow.GameCreatorLoad += value;
            remove => GameWindow.GameCreatorLoad -= value;
        }

        public event EventHandler<EventArgs> Draw
        {
            add => GameWindow.GameCreatorDraw += value;
            remove => GameWindow.GameCreatorDraw -= value;
        }

        public unsafe ITexture LoadTexture(IImage image)
        {
            var texId = GameWindow.GenTexture();
            
            GL.BindTexture(TextureTarget.Texture2D, texId);

            fixed (uint* data = &image.ImageData[0])
            {
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, 
                    PixelFormat.Rgba, PixelType.UnsignedByte, (IntPtr)data);
            }
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            
            return new TextureInfo(texId);
        }

        public void SetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup, double angle, double aspect, double znear, double zfar)
        {
            GL.MatrixMode(MatrixMode.Projection);
            var perspective = 
                Matrix4.CreatePerspectiveFieldOfView((float)angle, (float)aspect, (float)znear, (float)zfar);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            var view = Matrix4.LookAt((float)xfrom, (float)yfrom, (float)-zfrom, (float)xto, (float)yto, (float)-zto, 
                (float)xup, (float)yup, (float)-zup);
            GL.LoadMatrix(ref view);
            GL.Scale(1, 1, -1); // Convert to left-handed coordinate system for primitives
        }

        public void SetOrthographicProjection(double x, double y, double w, double h, double angle)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Rotate(angle, 0, 0, 1);
            var ortho = Matrix4.CreateOrthographicOffCenter((float)x, (float)(x + w), (float)(y + h), (float)y, 
                float.MinValue, float.MaxValue);
            GL.MultMatrix(ref ortho);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Scale(1, 1, -1); // Convert to left-handed coordinate system
        }

        public void Clear(int color)
        {
            makeColor(color, 1.0, out var vc);
            GL.ClearColor(vc);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        private const float inv255 = 1f / 255f;
        private void makeColor(int color, double alpha, out Color4 v)
        {
            v = default(Color4);
            v.R = (color & 0xFF) * inv255;
            v.G = ((color & 0xFF00) >> 8) * inv255;
            v.B = ((color & 0xFF0000) >> 16) * inv255;
            v.A = (float)alpha;
        }

        private void makeTexCoord(IGameSprite s, double x, double y, out Vector2 texCoord)
        {
            texCoord = default(Vector2);
            texCoord.X = (float)x / s.Width;
            texCoord.Y = (float)y / s.Height;
        }

        public void DrawSprite(IGameSprite s, int subimg, double left, double top, double w, double h, double x, double y, double xscale, double yscale, double angle, int c1, int c2, int c3, int c4, double a)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, new Vector3d(0, 0, -1));
            GL.Scale(xscale, yscale, 1);
            GL.Translate(-s.XOrigin, -s.YOrigin, 0);

            makeColor(c1, a, out var vc1);
            makeColor(c2, a, out var vc2);
            makeColor(c3, a, out var vc3);
            makeColor(c4, a, out var vc4);
            makeTexCoord(s, left, top, out var tc1);
            makeTexCoord(s, left+w, top, out var tc2);
            makeTexCoord(s, left+w, top+h, out var tc3);
            makeTexCoord(s, left, top+h, out var tc4);
            
            var texId = ((TextureInfo) s.Textures[subimg]).Id;
            GL.BindTexture(TextureTarget.Texture2D, texId);
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(vc1);
            GL.TexCoord2(tc1);
            GL.Vertex3(0, 0, DrawDepth3d);
            GL.Color4(vc2);
            GL.TexCoord2(tc2);
            GL.Vertex3(w, 0, DrawDepth3d);
            GL.Color4(vc3);
            GL.TexCoord2(tc3);
            GL.Vertex3(w, h, DrawDepth3d);
            GL.Color4(vc4);
            GL.TexCoord2(tc4);
            GL.Vertex3(0, h, DrawDepth3d);
            GL.End();
            
            GL.PopMatrix();
        }

        private bool _depthStencilEnable;
        public bool DepthStencilEnable
        {
            get => _depthStencilEnable;
            set
            {
                _depthStencilEnable = value;
                GL.DepthFunc(value ? DepthFunction.Lequal : DepthFunction.Always);
            }
        }

        public double DrawDepth3d { get; set; }
    }
}