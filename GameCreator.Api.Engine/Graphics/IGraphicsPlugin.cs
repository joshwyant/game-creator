using System;
using GameCreator.Api.Resources;

namespace GameCreator.Api.Engine
{
    public interface IGraphicsPlugin
    {
        void SetWindowSize(int width, int height);
        void Run();
        event EventHandler<EventArgs> Load;
        event EventHandler<EventArgs> Draw;
        ITexture LoadTexture(IImage image);
        void SetProjection(double xfrom, double yfrom, double zfrom, double xto, double yto, double zto, double xup,
            double yup, double zup, double angle, double aspect, double znear, double zfar);
        void SetOrthographicProjection(double x, double y, double w, double h, double angle);
        void Clear(int color);
        void DrawSprite(IGameSprite s, int subimg, double left, double top, double w, double h, double x, double y,
            double xscale, double yscale, double angle, int c1, int c2, int c3, int c4, double a);

        bool DepthStencilEnable { get; set; }
        double DrawDepth3d { get; set; }
    }
}