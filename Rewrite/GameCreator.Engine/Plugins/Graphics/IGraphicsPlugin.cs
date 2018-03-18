using System;

namespace GameCreator.Engine
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
        void Clear(byte r, byte g, byte b);
        void DrawSprite(ITexture t, float x, float y, float z, float w, float h, float originx, float originy,
            float xscale, float yscale, float angle, int r, int g, int b, int a);
    }
}