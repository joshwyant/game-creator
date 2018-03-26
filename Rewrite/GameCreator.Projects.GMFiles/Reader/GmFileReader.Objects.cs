using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readObjects()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Objects.NextIndex = i;
                
                if (getInt() != 0)
                {
                    var obj = project.Objects.Create();

                    obj.Name = getString();

                    version = getInt();

                    obj.SpriteIndex = getInt();
                    obj.Solid = getBool();
                    obj.Visible = getBool();
                    obj.Depth = getInt();
                    obj.Persistent = getBool();
                    obj.Parent = getInt();
                    obj.MaskSpriteIndex = getInt();

                    var topEvtTypeIdx = getInt(); // Event type count minus 1
                    var evtTypeIdx = topEvtTypeIdx;

                    obj.Events = new Dictionary<EventType, List<EventEntry>>();

                    while (evtTypeIdx >= 0)
                    {
                        var eventType = (EventType)(topEvtTypeIdx - evtTypeIdx);

                        obj.Events.Add(eventType, new List<EventEntry>());

                        int numb;
                        while ((numb = getInt()) != -1) // Once we get to -1, we can decrement evtTypeIdx.
                        {
                            var evt = new EventEntry(eventType, numb, getActions());
                            obj.Events[eventType].Add(evt);
                        }

                        evtTypeIdx--;
                    }
                }
            }
        }
    }
}
