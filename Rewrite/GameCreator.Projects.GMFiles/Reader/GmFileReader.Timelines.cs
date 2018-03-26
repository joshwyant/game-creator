using System.Collections.Generic;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readTimelines()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Timelines.NextIndex = i;

                if (getInt() != 0)
                {
                    var timeline = project.Timelines.Create();

                    timeline.Name = getString();

                    version = getInt();

                    timeline.Moments = new SortedDictionary<int, List<ActionEntry>>();

                    for (int momentCount = getInt(), j = 0; j < momentCount; j++)
                    {
                        timeline.Moments.Add(getInt(), getActions());
                    }
                }
            }
        }
    }
}
