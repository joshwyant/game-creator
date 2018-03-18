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
    }
}