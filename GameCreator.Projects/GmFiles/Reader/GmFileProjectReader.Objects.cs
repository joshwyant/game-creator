using App.Contracts;
using App.Resources;
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
        void readObjects()
        {
            int version = getInt();

            int count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Repository.Objects.NextIndex = i;
                
                if (getInt() != 0)
                {
                    var obj = project.Repository.Objects.Add();

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

                    obj.Events = new Dictionary<EventType, List<IAppObjectEvent>>();

                    while (evtTypeIdx >= 0)
                    {
                        var eventType = (EventType)(topEvtTypeIdx - evtTypeIdx);

                        obj.Events.Add(eventType, new List<IAppObjectEvent>());

                        int numb;
                        while ((numb = getInt()) != -1) // Once we get to -1, we can decrement evtTypeIdx.
                        {
                            var evt = new AppObjectEvent(eventType, numb, getActions());
                            obj.Events[eventType].Add(evt);
                        }

                        evtTypeIdx--;
                    }
                }
            }
        }
    }
}
