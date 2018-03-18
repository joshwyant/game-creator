using System;
using System.Drawing;
using System.Runtime.InteropServices;
using GameCreator.Engine;
using OpenTK;
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

        public void SetProjection(float xfrom, float yfrom, float zfrom, float xto, float yto, float zto, float xup, float yup,
            float zup, float angle, float aspect, float znear, float zfar)
        {
            GL.MatrixMode(MatrixMode.Projection);
            var perspective = Matrix4.CreatePerspectiveFieldOfView(angle, aspect, znear, zfar);
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            var view = Matrix4.LookAt(xfrom, yfrom, zfrom, xto, yto, zto, xup, yup, zup);
            GL.LoadMatrix(ref view);
        }

        public void Clear(byte r, byte g, byte b)
        {
            GL.ClearColor(1f/255f*r, 1f/255f*g, 1f/255f*b, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void DrawSprite(ITexture t, float x, float y, float z, float w, float h, float originx, float originy, float xscale,
            float yscale, float angle, int r, int g, int b)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.Translate(x, y, 0);
            GL.Rotate(angle, new Vector3d(0, 0, -1));
            GL.Scale(xscale, yscale, 1);
            GL.Translate(-originx, -originy, 0);
            
            var color = new Vector3(r / 255f, g / 255f, b / 255f);
            
            var texId = ((TextureInfo) t).Id;
            GL.BindTexture(TextureTarget.Texture2D, texId);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0, 0, z);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(w, 0, z);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(w, h, z);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(0, h, z);
            GL.End();
            
            GL.PopMatrix();
        }
    }
}