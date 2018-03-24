using System;
using GameCreator.Engine;
using GameCreator.Engine.Api;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCreator.Plugins.MonoGame
{
    internal sealed class MonoGameGraphicsPlugin : IGraphicsPlugin
    {
        private GameCreatorXnaGame Game { get; }
        
        public MonoGameGraphicsPlugin(GameCreatorXnaGame game)
        {
            Game = game;
        }

        public void SetWindowSize(int width, int height)
        {
            Game.Graphics.PreferredBackBufferWidth = width;
            Game.Graphics.PreferredBackBufferHeight = height;
            Game.Graphics.ApplyChanges();
        }

        public void Run()
        {
            Game.Run(GameRunBehavior.Synchronous);
        }

        public event EventHandler<EventArgs> Load
        {
            add => Game.Load += value;
            remove => Game.Load -= value;
        }

        public event EventHandler<EventArgs> Draw
        {
            add => Game.GameCreatorDraw += value;
            remove => Game.GameCreatorDraw -= value;
        }

        public ITexture LoadTexture(IImage image)
        {
            var tex = new TextureWrapper(Game.GraphicsDevice, image);

            Game.ManagedTextures.Add(tex);
            
            return tex;
        }

        public void SetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup, double yup, double zup, double angle, double aspect, double znear, double zfar)
        {
            Game.BasicEffect.View = 
                Matrix.CreateScale(1, 1, -1) // convert to left-handed
                * Matrix.CreateLookAt(
                    new Vector3((float)xfrom, (float)yfrom, (float)-zfrom), 
                    new Vector3((float)xto, (float)yto, (float)-zto), 
                    new Vector3((float)xup, (float)yup, (float)-zup));
            Game.BasicEffect.Projection = 
                Matrix.CreatePerspectiveFieldOfView((float)angle, (float)aspect, (float)znear, (float)zfar);
        }

        public void SetOrthographicProjection(double x, double y, double w, double h, double angle)
        {
            Game.BasicEffect.View =
                Matrix.CreateScale(1, 1, -1); // convert to left-handed
            
            Game.BasicEffect.Projection =
                Matrix.CreateOrthographicOffCenter((float)x, (float)(x + w), (float)(y + h), (float)y, 
                    float.MinValue, float.MaxValue)
                * Matrix.CreateRotationZ((float)angle * MathHelper.Pi / 180f);
        }

        private void WithDrawingSettings(Action draw)
        {
            foreach (var pass in Game.BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                draw();
            }
            
        }

        public void Clear(int color)
        {
            Game.GraphicsDevice.Clear(new Color((uint)color));
        }

        private void makeColor(int c, double alpha, out Color color)
        {
            color = new Color((uint)c) {A = (byte) (alpha * 255)};
        }
        
        private void makeTexCoord(IGameSprite s, double x, double y, out Vector2 texCoord)
        {
            texCoord = default(Vector2);
            texCoord.X = (float)x / s.Width;
            texCoord.Y = (float)y / s.Height;
        }
        
        public void DrawSprite(IGameSprite s, int subimg, double left, double top, double w, double h, double x, double y, double xscale, double yscale, double angle, int c1, int c2, int c3, int c4, double a)
        {
            var tex = (TextureWrapper) s.Textures[subimg];

            makeColor(c1, a, out var color1);
            makeColor(c2, a, out var color2);
            makeColor(c3, a, out var color3);
            makeColor(c4, a, out var color4);
            makeTexCoord(s, left, top, out var tc1);
            makeTexCoord(s, left+w, top, out var tc2);
            makeTexCoord(s, left+w, top+h, out var tc3);
            makeTexCoord(s, left, top+h, out var tc4);

            Game.BasicEffect.World = Matrix.CreateTranslation(-s.XOrigin, -s.YOrigin, 0)
                * Matrix.CreateScale((float)xscale, (float)yscale, 1)
                * Matrix.CreateRotationZ((float)-angle * MathHelper.Pi / 180)
                * Matrix.CreateTranslation((float)x, (float)y, 0);
            
            Game.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            Game.BasicEffect.TextureEnabled = true;
            Game.BasicEffect.VertexColorEnabled = true;
            Game.BasicEffect.Texture = tex;

            var z = (float) DrawDepth3d;
            var vertices = new[]
            {
                new VertexPositionColorTexture
                {
                    Color = color1,
                    Position = new Vector3(0, 0, z),
                    TextureCoordinate = tc1
                },
                new VertexPositionColorTexture
                {
                    Color = color3,
                    Position = new Vector3((float)w, (float)h, z),
                    TextureCoordinate = tc3
                },
                new VertexPositionColorTexture
                {
                    Color = color2,
                    Position = new Vector3((float)w, 0, z),
                    TextureCoordinate = tc2
                },
                
                new VertexPositionColorTexture
                {
                    Color = color1,
                    Position = new Vector3(0, 0, z),
                    TextureCoordinate = tc1
                },
                new VertexPositionColorTexture
                {
                    Color = color4,
                    Position = new Vector3(0, (float)h, z),
                    TextureCoordinate = tc4
                },
                new VertexPositionColorTexture
                {
                    Color = color3,
                    Position = new Vector3((float)w, (float)h, z),
                    TextureCoordinate = tc3
                },
            };
            
            var prevRasterizerState = Game.GraphicsDevice.RasterizerState;
            Game.GraphicsDevice.RasterizerState = new RasterizerState
            {
                CullMode = CullMode.None
            };
            
            WithDrawingSettings(() =>
            {
                Game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 2);
            });

            Game.GraphicsDevice.RasterizerState = prevRasterizerState;
        }

        public bool DepthStencilEnable
        {
            get => Game.GraphicsDevice.DepthStencilState != DepthStencilState.None;
            set => Game.GraphicsDevice.DepthStencilState = 
                value ? DepthStencilState.Default : DepthStencilState.None;
        }

        public double DrawDepth3d { get; set; }
    }
}