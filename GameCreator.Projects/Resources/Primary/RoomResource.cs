using System;
using System.Collections.Generic;

namespace GameCreator.Projects
{
    public class RoomResource : BaseResource
    {
        public string Caption { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int SnapY { get; set; }
        public int SnapX { get; set; }
        public bool Isometric { get; set; }
        public int Speed { get; set; }
        public bool Persistent { get; set; }
        public int BackgroundColor { get; set; }
        public bool DrawBackgroundColor { get; set; }
        public string CreationCode { get; set; }
        public List<RoomBackground> Backgrounds { get; set; }
        public bool EnableViews { get; set; }
        public List<RoomView> Views { get; set; }
        public List<InstanceResource> Instances { get; set; }
        public List<TileResource> Tiles { get; set; }
        public bool RememberRoomEditorInfo { get; set; }
        public int EditorWidth { get; set; }
        public int EditorHeight { get; set; }
        public bool ShowGrid { get; set; }
        public bool ShowObjects { get; set; }
        public bool ShowTiles { get; set; }
        public bool ShowBackgrounds { get; set; }
        public bool ShowForegrounds { get; set; }
        public bool ShowViews { get; set; }
        public bool DeleteUnderlyingObjects { get; set; }
        public bool DeleteUnderlyingTiles { get; set; }
        [Obsolete] public int TileWidth { get; set; }
        [Obsolete] public int TileHeight { get; set; }
        [Obsolete] public int TileHorizontalSeparation { get; set; }
        [Obsolete] public int TileVerticalSeparation { get; set; }
        [Obsolete] public int TileHorizontalOffset { get; set; }
        [Obsolete] public int TileVerticalOffset { get; set; }
        public int CurrentTab { get; set; }
        public int ScrollbarX { get; set; }
        public int ScrollbarY { get; set; }
    }
}