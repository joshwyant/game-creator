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
        IProject project;

        BinaryReader reader;

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

            var magic = reader.ReadInt32();

            if (magic != 1234321)
                throw new Exception("File is not a valid Game Maker file.");

            var version = reader.ReadInt32();

            var supportedVersions = new[] { 500, 510, 520, 530, 600 };

            if (!supportedVersions.Contains(version))
                throw new Exception("Unsuppoerted version.");

            project.Settings.GameID = reader.ReadInt32();

            var guidBytes = new byte[16];

            reader.Read(guidBytes, 0, 16);

            project.Settings.DirectPlayGuid = new Guid(guidBytes);

            readSettings();

            readSounds();

            readSprites();

            readBackgrounds();

            readPaths();

            readScripts();

            readFonts();

            readTimelines();

            readObjects();

            readRooms();
        }

        byte[] deflate(byte[] data)
        {
            using (var ims = new MemoryStream(data))
            using (var oms = new MemoryStream())
            using (var ds = new DeflateStream(reader.BaseStream, CompressionMode.Decompress, true))
            {
                ds.CopyTo(oms);
                return oms.ToArray();
            }
        }

        string readString()
        {
            var sb = new StringBuilder();

            for (int length = reader.ReadInt32(), i = 0; i < length; i++)
            {
                sb.Append((char)reader.ReadByte());
            }

            return sb.ToString();
        }
    }
}
