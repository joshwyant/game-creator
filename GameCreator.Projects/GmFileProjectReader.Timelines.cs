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
        void readTimelines()
        {
            int version = getInt();

            for (int count = getInt(), i = 0; i < count; i++)
            {
                project.Repository.Timelines.NextIndex = count;

                if (getInt() != 0)
                {
                    var timeline = project.Repository.Timelines.Add();

                    timeline.Name = getString();

                    version = getInt();

                    timeline.Moments = new Dictionary<int, List<IAppAction>>();

                    for (int momentCount = getInt(), j = 0; j < momentCount; j++)
                    {
                        timeline.Moments.Add(getInt(), getActions());
                    }
                }
            }
        }
    }
}
