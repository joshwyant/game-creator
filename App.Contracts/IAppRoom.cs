using System.Collections.Generic;

namespace App.Contracts
{
    /// <summary>
    /// Interface for a room resource.
    /// </summary>
    public interface IAppRoom : INamedIndexedResource
    {
        int EditorWidth { get; set; }
        int EditorHeight { get; set; }
        bool ShowGrid { get; set; }
        bool ShowObjects { get; set; }
        bool ShowForegrounds { get; set; }
        bool ShowViews { get; set; }
        bool DeleteUnderlyingObjects { get; set; }
        int ScrollbarY { get; set; }
        int ScrollbarX { get; set; }
        int CurrentTab { get; set; }
        int TileVerticalOffset { get; set; }
        int TileHorizontalOffset { get; set; }
        int TileVerticalSeparation { get; set; }
        int TileHorizontalSeparation { get; set; }
        int TileHeight { get; set; }
        int TileWidth { get; set; }
        bool DeleteUnderlyingTiles { get; set; }
        bool ShowBackgrounds { get; set; }
        bool ShowTiles { get; set; }
        bool RememberRoomEditorInfo { get; set; }
        List<RoomTile> Tiles { get; set; }
        List<RoomInstance> Instances { get; set; }
        List<RoomView> Views { get; set; }
        bool EnableViews { get; set; }
        List<RoomBackground> Backgrounds { get; set; }
        string CreationCode { get; set; }
        bool DrawBackgroundColor { get; set; }
        int BackgroundColor { get; set; }
        bool Persistent { get; set; }
        int Speed { get; set; }
        bool Isometric { get; set; }
        int SnapX { get; set; }
        int SnapY { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        string Caption { get; set; }
    }
}
