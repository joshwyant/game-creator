using App.Contracts;
using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    partial class GmFileProjectReader
    {
        void readRooms()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                if (getInt() != 0)
                {
                    var room = project.Repository.Rooms.Add();

                    room.Name = getString();

                    version = getInt();

                    room.Caption = getString();
                    room.Width = getInt();
                    room.Height = getInt();
                    room.SnapY = getInt();
                    room.SnapX = getInt();
                    room.Isometric = getBool();
                    room.Speed = getInt();
                    room.Persistent = getBool();
                    room.BackgroundColor = getInt();
                    room.DrawBackgroundColor = getBool();
                    room.CreationCode = getString();

                    var backgroundCount = getInt();
                    room.Backgrounds = new List<RoomBackground>(backgroundCount);
                    for (var j = 0; j < backgroundCount; j++)
                    {
                        var bg = new RoomBackground
                        {
                            VisibleWhenRoomStarts = getBool(),
                            ForegroundImage = getBool(),
                            BackgroundImageIndex = getInt(),
                            X = getInt(),
                            Y = getInt(),
                            TileHorizontally = getBool(),
                            TileVertically = getBool(),
                            HorizontalSpeed = getInt(),
                            VerticalSpeed = getInt(),
                            Stretch = getBool()
                        };

                        room.Backgrounds.Add(bg);
                    }

                    room.EnableViews = getBool();

                    room.Views = new List<RoomView>(8);
                    for (int viewc = getInt(), j = 0; j < viewc; j++)
                    {
                        var view = new RoomView();
                        view.VisibleWhenRoomStarts = getBool();
                        if (version == 520)
                        {
                            view.Left = getInt();
                            view.Top = getInt();
                            view.Width = getInt();
                            view.Height = getInt();
                            view.X = getInt();
                            view.Y = getInt();
                        }
                        else if (version >= 541)
                        {
                            view.X = getInt();
                            view.Y = getInt();
                            view.Width = getInt();
                            view.Height = getInt();
                            view.ViewportX = getInt();
                            view.ViewportY = getInt();
                            view.ViewportWidth = getInt();
                            view.ViewportHeight = getInt();
                        }
                        view.HorizontalBorder = getInt();
                        view.VerticalBorder = getInt();
                        view.HorizontalSpeed = getInt();
                        view.VerticalSpeed = getInt();
                        view.ObjectFollowing = getInt();

                        room.Views.Add(view);
                    }

                    room.Instances = new List<RoomInstance>();
                    for (int instanceCount = getInt(), j = 0; j < instanceCount; j++)
                    {
                        var instance = new RoomInstance
                        {
                            X = getInt(),
                            Y = getInt(),
                            ObjectIndex = getInt(),
                            ID = getInt(),
                            CreationCode = getString(),
                            Locked = getBool()
                        };

                        room.Instances.Add(instance);
                    }

                    room.Tiles = new List<RoomTile>();
                    for (int tileCount = getInt(), j = 0; j < tileCount; j++)
                    {
                        var instance = new RoomTile
                        {
                            X = getInt(),
                            Y = getInt(),
                            BackgroundIndex = getInt(),
                            TileX = getInt(),
                            TileY = getInt(),
                            Width = getInt(),
                            Height = getInt(),
                            Layer = getInt(),
                            ID = getInt(),
                            Locked = getBool()
                        };

                        room.Tiles.Add(instance);
                    }

                    room.RememberRoomEditorInfo = getBool();
                    room.EditorWidth = getInt();
                    room.EditorHeight = getInt();
                    room.ShowGrid = getBool();
                    room.ShowObjects = getBool();
                    room.ShowTiles = getBool();
                    room.ShowBackgrounds = getBool();
                    room.ShowForegrounds = getBool();
                    room.ShowViews = getBool();
                    room.DeleteUnderlyingObjects = getBool();
                    room.DeleteUnderlyingTiles = getBool();

                    if (version == 520)
                    {
                        room.TileWidth = getInt();
                        room.TileHeight = getInt();
                        room.TileHorizontalSeparation = getInt();
                        room.TileVerticalSeparation = getInt();
                        room.TileHorizontalOffset = getInt();
                        room.TileVerticalOffset = getInt();
                    }

                    room.CurrentTab = getInt();
                    room.ScrollbarX = getInt();
                    room.ScrollbarY = getInt();
                }
            }
            
            project.Repository.Rooms.NextIndex = count;
        }
    }
}
