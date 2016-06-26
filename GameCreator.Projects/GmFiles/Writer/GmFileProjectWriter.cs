using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    class GmFileProjectWriter
    {
        IProject project;
        public IProject Project { get; }

        BinaryWriter writer;
        public BinaryWriter Writer { get; }

        bool isWriting = false;

        public GmFileProjectWriter(IProject project, BinaryWriter writer)
        {
            this.project = project;
            this.writer = writer;
        }

        public void Write()
        {
            if (isWriting)
                throw new InvalidOperationException("Cannot write the file after it has already been written.");

            isWriting = true;
        }
    }
}
