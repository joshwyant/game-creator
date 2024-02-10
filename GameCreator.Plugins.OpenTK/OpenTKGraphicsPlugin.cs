using System;
using GameCreator.Engine.Api;
using GameCreator.Resources.Api;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using static OpenTK.Graphics.OpenGL.GL;
using MatrixMode = OpenTK.Graphics.OpenGL.MatrixMode;

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
            
            BindTexture(TextureTarget.Texture2D, texId);

            fixed (uint* data = &image.ImageData[0])
            {
                TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, 
                    PixelFormat.Rgba, PixelType.UnsignedByte, (IntPtr)data);
            }
            
            TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            
            return new TextureInfo(texId);
        }

        public void SetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup, double angle, double aspect, double znear, double zfar)
        {
            MatrixMode(MatrixMode.Projection);
            var perspective = 
                Matrix4.CreatePerspectiveFieldOfView((float)angle, (float)aspect, (float)znear, (float)zfar);
            LoadMatrix(ref perspective);
            MatrixMode(MatrixMode.Modelview);
            var view = Matrix4.LookAt((float)xfrom, (float)yfrom, (float)-zfrom, (float)xto, (float)yto, (float)-zto, 
                (float)xup, (float)yup, (float)-zup);
            LoadMatrix(ref view);
            Scale(1, 1, -1); // Convert to left-handed coordinate system for primitives
        }

        public void SetOrthographicProjection(double x, double y, double w, double h, double angle)
        {
            MatrixMode(MatrixMode.Projection);
            LoadIdentity();
            Rotate(angle, 0, 0, 1);
            var ortho = Matrix4.CreateOrthographicOffCenter((float)x, (float)(x + w), (float)(y + h), (float)y, 
                float.MinValue, float.MaxValue);
            MultMatrix(ref ortho);

            MatrixMode(MatrixMode.Modelview);
            LoadIdentity();
            Scale(1, 1, -1); // Convert to left-handed coordinate system
        }

        public void Clear(int color)
        {
            makeColor(color, 1.0, out var vc);
            ClearColor(vc);
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
            MatrixMode(MatrixMode.Modelview);
            PushMatrix();
            Translate(x, y, 0);
            Rotate(angle, new Vector3d(0, 0, -1));
            Scale(xscale, yscale, 1);
            Translate(-s.XOrigin, -s.YOrigin, 0);

            makeColor(c1, a, out var vc1);
            makeColor(c2, a, out var vc2);
            makeColor(c3, a, out var vc3);
            makeColor(c4, a, out var vc4);
            makeTexCoord(s, left, top, out var tc1);
            makeTexCoord(s, left+w, top, out var tc2);
            makeTexCoord(s, left+w, top+h, out var tc3);
            makeTexCoord(s, left, top+h, out var tc4);
            
            var texId = ((TextureInfo) s.Textures[subimg]).Id;
            BindTexture(TextureTarget.Texture2D, texId);
            Begin(PrimitiveType.Quads);
            Color4(vc1);
            TexCoord2(tc1);
            Vertex3(0, 0, DrawDepth3d);
            Color4(vc2);
            TexCoord2(tc2);
            Vertex3(w, 0, DrawDepth3d);
            Color4(vc3);
            TexCoord2(tc3);
            Vertex3(w, h, DrawDepth3d);
            Color4(vc4);
            TexCoord2(tc4);
            Vertex3(0, h, DrawDepth3d);
            End();
            
            PopMatrix();
        }

        private bool _depthStencilEnable;
        public bool DepthStencilEnable
        {
            get => _depthStencilEnable;
            set
            {
                _depthStencilEnable = value;
                DepthFunc(value ? DepthFunction.Lequal : DepthFunction.Always);
            }
        }

        public double DrawDepth3d { get; set; }
    }
}