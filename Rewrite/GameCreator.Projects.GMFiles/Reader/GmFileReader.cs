using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader : IDisposable
    {
        static readonly DateTime ReferenceDate = new DateTime(1899, 12, 30);
        private static readonly HashSet<int> SupportedVersions = new HashSet<int>(new[] {500, 510, 520, 530, 600});
        
        Project project;

        BinaryReader reader;
        private Stream source;

        bool isReading = false;
        
        public GmFileReader(Project project, Stream source)
        {
            this.project = project;
            this.source = source;
        }

        public void Read()
        {
            if (isReading)
                throw new InvalidOperationException("Cannot read the file after it has already been read.");

            isReading = true;

            using (reader = new BinaryReader(source))
            {
                var magic = reader.ReadInt32();

                if (magic != 1234321)
                    throw new InvalidDataException("File is not a valid Game Maker file.");

                var version = reader.ReadInt32();

                if (!SupportedVersions.Contains(version))
                    throw new NotSupportedException("Unsupported version.");

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

                project.Instances.NextIndex = getInt();
                project.Tiles.NextIndex = getInt();

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
                //project.ExecutableRoomList = executableRoomList;

                var rootCount = 11;

                if (version == 500 || version == 540)
                    rootCount = 11;
                else if (version >= 700)
                    rootCount = 12;

                for (var i = 0; i < rootCount; i++)
                {
                    readRootResource();
                }
            }
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
            return ReferenceDate.AddDays(reader.ReadDouble());
        }

        bool getBool() { return Convert.ToBoolean(reader.ReadInt32()); }

        int getInt() { return reader.ReadInt32(); }

        public void Dispose()
        {
            reader?.Dispose();
        }
    }
}
