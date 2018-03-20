using GameCreator.Engine.Api;

namespace GameCreator.Engine
{
    public interface IInstanceVars
    {
        [Gml("id")] int InstanceId { get; }
        [Gml("object_index")] int ObjectIndex { get; }
        [Gml("x")] double X { get; set; }
        [Gml("y")] double Y { get; set; }
        [Gml("xstart")] double XStart { get; set; }
        [Gml("ystart")] double YStart { get; set; }
        [Gml("xprevious")] double XPrevious { get; set; }
        [Gml("yprevious")] double YPrevious { get; set; }
        [Gml("visible")] bool Visible { get; set; }
        [Gml("solid")] bool Solid { get; set; }
        [Gml("persistent")] bool Persistent { get; set; }
        [Gml("depth")] double Depth { get; set; }
        [Gml("sprite_index")] int SpriteIndex { get; set; }
        [Gml("image_speed")] double ImageSpeed { get; set; }
        [Gml("image_single")] double ImageSingle { get; set; }
        [Gml("image_index")] double ImageIndex { get; set; }
        [Gml("image_angle")] double ImageAngle { get; set; }
        [Gml("image_blend")] uint ImageBlend { get; set; }
        [Gml("image_alpha")] double ImageAlpha { get; set; }
        [Gml("image_xscale")] double ImageXScale { get; set; }
        [Gml("image_yscale")] double ImageYScale { get; set; }
        [Gml("alarm")] int[] Alarm { get; }
        [Gml("direction")] double Direction { get; set; }
        [Gml("speed")] double Speed { get; set; }
        [Gml("hspeed")] double HSpeed { get; set; }
        [Gml("vspeed")] double VSpeed { get; set; }
        [Gml("gravity")] double Gravity { get; set; }
        [Gml("gravity_direction")] double GravityDirection { get; set; }
        [Gml("friction")] double Friction { get; set; }
    }
}