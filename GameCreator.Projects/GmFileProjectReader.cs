using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    class GmFileProjectReader
    {
        IProject project;
        public IProject Project { get; }

        BinaryReader reader;
        public BinaryReader Reader { get; }

        bool isReading = false;
        
        public GmFileProjectReader(IProject project, BinaryReader reader)
        {
            this.project = project;
            this.reader = reader;
        }

        public void Read()
        {
            if (isReading)
                throw new InvalidOperationException("Cannot read the file after it has already been read.");

            isReading = true;
        }
    }
}
