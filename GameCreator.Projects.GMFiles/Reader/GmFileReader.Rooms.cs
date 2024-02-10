using System.Collections.Generic;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadRooms()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Rooms.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var room = Project.Rooms.Create();

                    room.Name = ReadString();

                    version = ReadInt();

                    room.Caption = ReadString();
                    room.Width = ReadInt();
                    room.Height = ReadInt();
                    room.SnapY = ReadInt();
                    room.SnapX = ReadInt();
                    room.Isometric = ReadBool();
                    room.Speed = ReadInt();
                    room.Persistent = ReadBool();
                    room.BackgroundColor = ReadInt();
                    room.DrawBackgroundColor = ReadBool();
                    room.CreationCode = ReadString();

                    var backgroundCount = ReadInt();
                    room.Backgrounds = new List<RoomBackground>(backgroundCount);
                    for (var j = 0; j < backgroundCount; j++)
                    {
                        var bg = new RoomBackground
                        {
                            VisibleWhenRoomStarts = ReadBool(),
                            ForegroundImage = ReadBool(),
                            BackgroundImageIndex = ReadInt(),
                            X = ReadInt(),
                            Y = ReadInt(),
                            TileHorizontally = ReadBool(),
                            TileVertically = ReadBool(),
                            HorizontalSpeed = ReadInt(),
                            VerticalSpeed = ReadInt(),
                            Stretch = ReadBool()
                        };

                        room.Backgrounds.Add(bg);
                    }

                    room.EnableViews = ReadBool();

                    room.Views = new List<RoomView>(8);
                    for (int viewc = ReadInt(), j = 0; j < viewc; j++)
                    {
                        var view = new RoomView();
                        view.VisibleWhenRoomStarts = ReadBool();
                        if (version == 520)
                        {
                            view.Left = ReadInt();
                            view.Top = ReadInt();
                            view.Width = ReadInt();
                            view.Height = ReadInt();
                            view.X = ReadInt();
                            view.Y = ReadInt();
                        }
                        else if (version >= 541)
                        {
                            view.X = ReadInt();
                            view.Y = ReadInt();
                            view.Width = ReadInt();
                            view.Height = ReadInt();
                            view.ViewportX = ReadInt();
                            view.ViewportY = ReadInt();
                            view.ViewportWidth = ReadInt();
                            view.ViewportHeight = ReadInt();
                        }
                        view.HorizontalBorder = ReadInt();
                        view.VerticalBorder = ReadInt();
                        view.HorizontalSpeed = ReadInt();
                        view.VerticalSpeed = ReadInt();
                        view.ObjectFollowing = ReadInt();

                        room.Views.Add(view);
                    }

                    room.Instances = new List<InstanceResource>();
                    for (int instanceCount = ReadInt(), j = 0; j < instanceCount; j++)
                    {
                        var instance = new InstanceResource
                        {
                            X = ReadInt(),
                            Y = ReadInt(),
                            ObjectIndex = ReadInt(),
                            Id = ReadInt(),
                            CreationCode = ReadString(),
                            Locked = ReadBool()
                        };

                        Project.Instances[instance.Id] = instance;

                        room.Instances.Add(instance);
                    }

                    room.Tiles = new List<TileResource>();
                    for (int tileCount = ReadInt(), j = 0; j < tileCount; j++)
                    {
                        var tile = new TileResource
                        {
                            X = ReadInt(),
                            Y = ReadInt(),
                            BackgroundIndex = ReadInt(),
                            TileX = ReadInt(),
                            TileY = ReadInt(),
                            Width = ReadInt(),
                            Height = ReadInt(),
                            Layer = ReadInt(),
                            Id = ReadInt(),
                            Locked = ReadBool()
                        };

                        Project.Tiles[tile.Id] = tile;

                        room.Tiles.Add(tile);
                    }

                    room.RememberRoomEditorInfo = ReadBool();
                    room.EditorWidth = ReadInt();
                    room.EditorHeight = ReadInt();
                    room.ShowGrid = ReadBool();
                    room.ShowObjects = ReadBool();
                    room.ShowTiles = ReadBool();
                    room.ShowBackgrounds = ReadBool();
                    room.ShowForegrounds = ReadBool();
                    room.ShowViews = ReadBool();
                    room.DeleteUnderlyingObjects = ReadBool();
                    room.DeleteUnderlyingTiles = ReadBool();

                    if (version == 520)
                    {
                        room.TileWidth = ReadInt();
                        room.TileHeight = ReadInt();
                        room.TileHorizontalSeparation = ReadInt();
                        room.TileVerticalSeparation = ReadInt();
                        room.TileHorizontalOffset = ReadInt();
                        room.TileVerticalOffset = ReadInt();
                    }

                    room.CurrentTab = ReadInt();
                    room.ScrollbarX = ReadInt();
                    room.ScrollbarY = ReadInt();
                }
            }
        }
    }
}
