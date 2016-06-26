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
        void readPaths()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Repository.Paths.NextIndex = i;

                if (getInt() != 0)
                {
                    var path = project.Repository.Paths.Add();

                    path.Name = getString();

                    version = getInt();

                    path.ConnectionKind = (PathKind)getInt();
                    path.IsClosed = getBool();
                    path.Precision = getInt();
                    path.RoomReference = getInt();
                    path.SnapX = getInt();
                    path.SnapY = getInt();

                    var points = getInt();
                    path.Points = new List<PathVertex>(points);
                    for (int j = 0; j < points; j++)
                    {
                        path.Points.Add(new PathVertex(reader.ReadDouble(), reader.ReadDouble(), reader.ReadDouble()));
                    }
                }
            }
        }
    }
}
