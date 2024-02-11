using System.Collections.Generic;
using GameCreator.Api.Resources;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private TreeResourceHeader ReadTreeResourceHeader()
        {
            return new TreeResourceHeader
            {
                Status = (TreeResourceStatus) ReadInt(),
                Grouping = (TreeResourceKind) ReadInt(),
                Index = ReadInt(),
                Name = ReadString(),
                Count = ReadInt()
            };
        }

        private void ReadRootResource()
        {
            var header = ReadTreeResourceHeader();

            switch (header.Grouping)
            {
                case TreeResourceKind.Backgrounds:
                    ReadRootResource(header, Project.Backgrounds);
                    break;
                case TreeResourceKind.Fonts:
                    ReadRootResource(header, Project.Fonts);
                    break;
                case TreeResourceKind.Objects:
                    ReadRootResource(header, Project.Objects);
                    break;
                case TreeResourceKind.Paths:
                    ReadRootResource(header, Project.Objects);
                    break;
                case TreeResourceKind.Rooms:
                    ReadRootResource(header, Project.Objects);
                    break;
                case TreeResourceKind.Scripts:
                    ReadRootResource(header, Project.Objects);
                    break;
                case TreeResourceKind.Sounds:
                    ReadRootResource(header, Project.Objects);
                    break;
                case TreeResourceKind.Sprites:
                    ReadRootResource(header, Project.Objects);
                    break;
                case TreeResourceKind.TimeLines:
                    ReadRootResource(header, Project.Timelines);
                    break;
            }
        }

        private void ReadRootResource<T>(TreeResourceHeader header, ProjectResourceManager<T> manager)
            where T : BaseResource, new()
        {
            manager.Root.Name = header.Name;

            for (var i = 0; i < header.Count; i++)
            {
                ReadTreeResource(manager, manager.Root);
            }
        }

        private void ReadTreeResource<T>(ProjectResourceManager<T> manager, ResourceDirectoryNode<T> parent) 
            where T : BaseResource, new()
        {
            var header = ReadTreeResourceHeader();

            switch (header.Status)
            {
                case TreeResourceStatus.Group:
                    var group = manager.AddDirectoryNode(header.Name);
                    group.AddTo(parent);
                    for (var i = 0; i < header.Count; i++)
                    {
                        ReadTreeResource(manager, group);
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
