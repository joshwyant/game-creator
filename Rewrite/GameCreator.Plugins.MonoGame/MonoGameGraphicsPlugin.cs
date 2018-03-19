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
            Game.BasicEffect.View = 
                Matrix.CreateScale(1, 1, -1) // convert to left-handed
                * Matrix.CreateLookAt(
                    new Vector3(xfrom, yfrom, -zfrom), 
                    new Vector3(xto, yto, -zto), 
                    new Vector3(xup, yup, -zup));
            Game.BasicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(angle, aspect, znear, zfar);
        }

        public void SetOrthographicProjection(float x, float y, float w, float h, float angle)
        {
            Game.BasicEffect.View =
                Matrix.CreateScale(1, 1, -1); // convert to left-handed
            
            Game.BasicEffect.Projection =
                Matrix.CreateOrthographicOffCenter(x, x + w, y + h, y, float.MinValue, float.MaxValue)
                * Matrix.CreateRotationZ(angle * MathHelper.Pi / 180f);
        }

        private void WithDrawingSettings(Action draw)
        {
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

        private void makeColor(uint c, float alpha, out Color color)
        {
            color = new Color(c) {A = (byte) (alpha * 255f)};
        }
        
        private void makeTexCoord(GameSprite s, float x, float y, out Vector2 texCoord)
        {
            texCoord = default(Vector2);
            texCoord.X = x / s.Width;
            texCoord.Y = y / s.Height;
        }
        
        public void DrawSprite(GameSprite s, int subimg, float left, float top, float w, float h, float x, float y,
            float xscale, float yscale, float angle, uint c1, uint c2, uint c3, uint c4, float a)
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
                * Matrix.CreateScale(xscale, yscale, 1)
                * Matrix.CreateRotationZ(-angle * MathHelper.Pi / 180)
                * Matrix.CreateTranslation(x, y, 0);
            
            Game.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            Game.BasicEffect.TextureEnabled = true;
            Game.BasicEffect.VertexColorEnabled = true;
            Game.BasicEffect.Texture = tex;
            

            var vertices = new[]
            {
                new VertexPositionColorTexture
                {
                    Color = color1,
                    Position = new Vector3(0, 0, DrawDepth3d),
                    TextureCoordinate = tc1
                },
                new VertexPositionColorTexture
                {
                    Color = color3,
                    Position = new Vector3(w, h, DrawDepth3d),
                    TextureCoordinate = tc3
                },
                new VertexPositionColorTexture
                {
                    Color = color2,
                    Position = new Vector3(w, 0, DrawDepth3d),
                    TextureCoordinate = tc2
                },
                
                new VertexPositionColorTexture
                {
                    Color = color1,
                    Position = new Vector3(0, 0, DrawDepth3d),
                    TextureCoordinate = tc1
                },
                new VertexPositionColorTexture
                {
                    Color = color4,
                    Position = new Vector3(0, h, DrawDepth3d),
                    TextureCoordinate = tc4
                },
                new VertexPositionColorTexture
                {
                    Color = color3,
                    Position = new Vector3(w, h, DrawDepth3d),
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

        public float DrawDepth3d { get; set; }
    }
}