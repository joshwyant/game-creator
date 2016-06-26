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
        TreeResource readTreeResource()
        {
            var resource = new TreeResource();

            resource.Status = (TreeResourceStatus)getInt();
            resource.Grouping = (TreeResourceKind)getInt();
            resource.Index = getInt();
            resource.Name = getString();

            var contentsCount = getInt();
            resource.Contents = new List<TreeResource>();

            for (var i = 0; i < contentsCount; i++)
            {
                resource.Contents.Add(readTreeResource());
            }

            return resource;
        }
    }
}
