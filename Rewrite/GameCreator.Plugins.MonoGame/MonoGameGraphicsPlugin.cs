using System;
using GameCreator.Engine;
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

        public void SetProjection(float xfrom, float yfrom, float zfrom, float xto, float yto, float zto, float xup, float yup,
            float zup, float angle, float aspect, float znear, float zfar)
        {
            Game.BasicEffect.View = Matrix.CreateLookAt(
                new Vector3(xfrom, yfrom, zfrom), 
                new Vector3(xto, yto, zto), 
                new Vector3(xup, yup, zup));
            Game.BasicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(angle, aspect, znear, zfar);
        }

        private void WithDrawingSettings(Action draw)
        {
            Game.GraphicsDevice.RasterizerState = Game.RasterizerState;
            foreach (var pass in Game.BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                draw();
            }
            
        }

        public void Clear(byte r, byte g, byte b)
        {
            Game.GraphicsDevice.Clear(new Color(r, g, b));
        }

        public void DrawSprite(ITexture t, float x, float y, float z, float w, float h, float originx, float originy, 
            float xscale, float yscale, float angle, int r, int g, int b, int a)
        {
            var tex = (TextureWrapper) t;

            var color = new Color(r, g, b, a);

            Game.BasicEffect.World = Matrix.CreateTranslation(-originx, -originy, 0)
                * Matrix.CreateScale(xscale, yscale, 1)
                * Matrix.CreateRotationZ(-angle * MathHelper.Pi / 180)
                * Matrix.CreateTranslation(x, y, 0);
            
            Game.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            Game.BasicEffect.TextureEnabled = true;
            Game.BasicEffect.VertexColorEnabled = true;
            Game.BasicEffect.Texture = tex;
            
            var prevRasterizerState = Game.RasterizerState;
            Game.GraphicsDevice.RasterizerState = new RasterizerState
            {
                CullMode = CullMode.None
            };

            var vertices = new[]
            {
                new VertexPositionColorTexture
                {
                    Color = color,
                    Position = new Vector3(0, 0, z),
                    TextureCoordinate = new Vector2(0, 0)
                },
                new VertexPositionColorTexture
                {
                    Color = color,
                    Position = new Vector3(w, 0, z),
                    TextureCoordinate = new Vector2(1, 0)
                },
                new VertexPositionColorTexture
                {
                    Color = color,
                    Position = new Vector3(w, h, z),
                    TextureCoordinate = new Vector2(1, 1)
                },
                
                new VertexPositionColorTexture
                {
                    Color = color,
                    Position = new Vector3(0, 0, z),
                    TextureCoordinate = new Vector2(0, 0)
                },
                new VertexPositionColorTexture
                {
                    Color = color,
                    Position = new Vector3(w, h, z),
                    TextureCoordinate = new Vector2(1, 1)
                },
                new VertexPositionColorTexture
                {
                    Color = color,
                    Position = new Vector3(0, h, z),
                    TextureCoordinate = new Vector2(0, 1)
                },
            };
            
            WithDrawingSettings(() =>
            {
                Game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 2);
            });

            Game.GraphicsDevice.RasterizerState = prevRasterizerState;
        }
    }
}