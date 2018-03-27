using System.Collections.Generic;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadPaths()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Paths.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var path = Project.Paths.Create();

                    path.Name = ReadString();

                    version = ReadInt();

                    path.IsSmooth = ReadBool();
                    path.IsClosed = ReadBool();
                    path.Precision = ReadInt();
                    path.RoomReference = ReadInt();
                    path.SnapX = ReadInt();
                    path.SnapY = ReadInt();

                    var points = ReadInt();
                    path.Points = new List<PathVertex>(points);
                    for (var j = 0; j < points; j++)
                    {
                        path.Points.Add(new PathVertex(Reader.ReadDouble(), Reader.ReadDouble(), Reader.ReadDouble()));
                    }
                }
            }
        }
    }
}
