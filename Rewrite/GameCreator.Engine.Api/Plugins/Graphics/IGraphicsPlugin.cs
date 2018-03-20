using System;

namespace GameCreator.Engine.Api
{
    public interface IGraphicsPlugin
    {
        void SetWindowSize(int width, int height);
        void Run();
        event EventHandler<EventArgs> Load;
        event EventHandler<EventArgs> Draw;
        ITexture LoadTexture(IImage image);
        void SetProjection(float xfrom, float yfrom, float zfrom, float xto, float yto, float zto, float xup,
            float yup, float zup, float angle, float aspect, float znear, float zfar);
        void SetOrthographicProjection(float x, float y, float w, float h, float angle);
        void Clear(byte r, byte g, byte b);
        void DrawSprite(IGameSprite s, int subimg, float left, float top, float w, float h, float x, float y,
            float xscale, float yscale, float angle, uint c1, uint c2, uint c3, uint c4, float a);

        bool DepthStencilEnable { get; set; }
        float DrawDepth3d { get; set; }
    }
}