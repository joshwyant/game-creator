using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        TreeResourceHeader readTreeResourceHeader()
        {
            return new TreeResourceHeader
            {
                Status = (TreeResourceStatus) getInt(),
                Grouping = (TreeResourceKind) getInt(),
                Index = getInt(),
                Name = getString(),
                Count = getInt()
            };
        }
        
        void readRootResource()
        {
            var header = readTreeResourceHeader();

            switch (header.Grouping)
            {
                case TreeResourceKind.Backgrounds:
                    readRootResource(header, project.Backgrounds);
                    break;
                case TreeResourceKind.Fonts:
                    readRootResource(header, project.Fonts);
                    break;
                case TreeResourceKind.Objects:
                    readRootResource(header, project.Objects);
                    break;
                case TreeResourceKind.Paths:
                    readRootResource(header, project.Objects);
                    break;
                case TreeResourceKind.Rooms:
                    readRootResource(header, project.Objects);
                    break;
                case TreeResourceKind.Scripts:
                    readRootResource(header, project.Objects);
                    break;
                case TreeResourceKind.Sounds:
                    readRootResource(header, project.Objects);
                    break;
                case TreeResourceKind.Sprites:
                    readRootResource(header, project.Objects);
                    break;
                case TreeResourceKind.TimeLines:
                    readRootResource(header, project.Timelines);
                    break;
            }
        }

        void readRootResource<T>(TreeResourceHeader header, ProjectResourceManager<T> manager)
            where T : BaseResource, new()
        {
            manager.Root.Name = header.Name;

            for (var i = 0; i < header.Count; i++)
            {
                readTreeResource(manager, manager.Root);
            }
        }

        void readTreeResource<T>(ProjectResourceManager<T> manager, ResourceDirectoryNode<T> parent) 
            where T : BaseResource, new()
        {
            var header = readTreeResourceHeader();

            switch (header.Status)
            {
                case TreeResourceStatus.Group:
                    var group = manager.AddDirectoryNode(header.Name);
                    group.AddTo(parent);
                    for (var i = 0; i < header.Count; i++)
                    {
                        readTreeResource(manager, group);
                    }
                    break;
                case TreeResourceStatus.Secondary:
                    var node = manager.GetNode(header.Index);
                    node.AddTo(parent);
                    break;
            }
        }
    }
}
