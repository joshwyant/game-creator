using System.Collections.Generic;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadTimelines()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Timelines.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var timeline = Project.Timelines.Create();

                    timeline.Name = ReadString();

                    version = ReadInt();

                    timeline.Moments = new SortedDictionary<int, List<ActionEntry>>();

                    for (int momentCount = ReadInt(), j = 0; j < momentCount; j++)
                    {
                        timeline.Moments.Add(ReadInt(), GetActions());
                    }
                }
            }
        }
    }
}
