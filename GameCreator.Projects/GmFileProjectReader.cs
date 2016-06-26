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

            project.LastInstanceIdPlaced = getInt();
            project.LastTileIdPlaced = getInt();

            readGameInformation();

            var versionForFollowing = getInt();
            var libraryDependencyCount = getInt();
            var libraryCreationCodes = new List<string>();
            for (var i = 0; i < libraryDependencyCount; i++)
            {
                libraryCreationCodes.Add(getString());
            }
            project.LibraryCreationCodes = libraryCreationCodes;

            versionForFollowing = getInt();
            var executableRoomCount = getInt();
            var executableRoomList = new List<int>();
            for (var i = 0; i < executableRoomCount; i++)
            {
                executableRoomList.Add(getInt());
            }
            project.ExecutableRoomList = executableRoomList;
            
            int rootCount = 11;

            if (version == 500 || version == 540)
                rootCount = 11;
            else if (version >= 700)
                rootCount = 12;

            var items = new List<TreeResource>();
            for (var i = 0; i < rootCount; i++)
            {
                items.Add(readTreeResource());
            }

            project.ResourceTree = items;
        }

        byte[] getZipped()
        {
            var data = new byte[reader.ReadUInt32()];

            reader.Read(data, 0, data.Length);

            using (var ims = new MemoryStream(data))
            using (var oms = new MemoryStream())
            using (var ds = new DeflateStream(ims, CompressionMode.Decompress, true))
            {
                ims.Position = 2; // Skip past the zlib header
                ds.CopyTo(oms);
                return oms.ToArray();
            }
        }

        byte[] getBlob()
        {
            var data = new byte[reader.ReadInt32()];
            reader.Read(data, 0, data.Length);
            return data;
        }

        string getString()
        {
            var sb = new StringBuilder();

            for (int length = reader.ReadInt32(), i = 0; i < length; i++)
            {
                sb.Append((char)reader.ReadByte());
            }

            return sb.ToString();
        }

        DateTime getDate()
        {
            return reader.ReadDouble().ToDateTime();
        }

        bool getBool() { return Convert.ToBoolean(reader.ReadInt32()); }

        int getInt() { return reader.ReadInt32(); }
    }
}
