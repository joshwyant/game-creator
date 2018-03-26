using System.Collections.Generic;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readPaths()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Paths.NextIndex = i;

                if (getInt() != 0)
                {
                    var path = project.Paths.Create();

                    path.Name = getString();

                    version = getInt();

                    path.IsSmooth = getBool();
                    path.IsClosed = getBool();
                    path.Precision = getInt();
                    path.RoomReference = getInt();
                    path.SnapX = getInt();
                    path.SnapY = getInt();

                    var points = getInt();
                    path.Points = new List<PathVertex>(points);
                    for (var j = 0; j < points; j++)
                    {
                        path.Points.Add(new PathVertex(reader.ReadDouble(), reader.ReadDouble(), reader.ReadDouble()));
                    }
                }
            }
        }
    }
}
