namespace GameCreator.Engine
{
    public interface IInstanceVars
    {
        [Gml("id")] int InstanceId { get; }
        [Gml("object_index")] int ObjectIndex { get; }
        [Gml("x")] double X { get; set; }
        [Gml("y")] double Y { get; set; }
        [Gml("persistent")] bool Persistent { get; set; }
        [Gml("depth")] double Depth { get; set; }
        [Gml("sprite_index")] int SpriteIndex { get; set; }
        [Gml("image_index")] int ImageIndex { get; set; }
        [Gml("image_angle")] double ImageAngle { get; set; }
        [Gml("image_blend")] uint ImageBlend { get; set; }
        [Gml("image_alpha")] int ImageAlpha { get; set; }
        [Gml("image_xscale")] double ImageXScale { get; set; }
        [Gml("image_yscale")] double ImageYScale { get; set; }
    }
}