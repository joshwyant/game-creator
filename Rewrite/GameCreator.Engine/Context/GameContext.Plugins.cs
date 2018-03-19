using System.Linq;

namespace GameCreator.Engine
{
    public abstract partial class GameContext
    {
        private void LoadContent()
        {
            // Load all the sprite textures
            foreach (var sprite in Sprites)
            {
                sprite.Textures = sprite.SubImages.Select(si => Graphics.LoadTexture(si)).ToArray();
            }

            // ...
        }

        public void Run()
        {
            Graphics.Run();
        }
    }
}