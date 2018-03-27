using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadObjects()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Objects.NextIndex = i;
                
                if (ReadInt() != 0)
                {
                    var obj = Project.Objects.Create();

                    obj.Name = ReadString();

                    version = ReadInt();

                    obj.SpriteIndex = ReadInt();
                    obj.Solid = ReadBool();
                    obj.Visible = ReadBool();
                    obj.Depth = ReadInt();
                    obj.Persistent = ReadBool();
                    obj.Parent = ReadInt();
                    obj.MaskSpriteIndex = ReadInt();

                    var eventType = (EventType) ReadInt(); // Event type count minus 1

                    obj.Events = new Dictionary<EventType, List<EventEntry>>();

                    while (eventType >= 0)
                    {
                        obj.Events.Add(eventType, new List<EventEntry>());

                        int numb;
                        while ((numb = ReadInt()) != -1) // Once we get to -1, we can decrement eventType.
                        {
                            var evt = new EventEntry(eventType, numb, GetActions());
                            obj.Events[eventType].Add(evt);
                        }

                        eventType -= 1;
                    }
                }
            }
        }
    }
}
