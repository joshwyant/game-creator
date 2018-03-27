using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader : IDisposable
    {
        private static readonly DateTime ReferenceDate = new DateTime(1899, 12, 30);
        private static readonly HashSet<int> SupportedVersions = new HashSet<int>(new[] {500, 510, 520, 530, 600});

        public Project Project { get; }
        public Stream Source { get; }
        private BinaryReader Reader { get; set; }

        private bool _isReading;
        
        public GmFileReader(Project project, Stream source)
        {
            Project = project;
            Source = source;
        }

        public void Read()
        {
            if (_isReading)
                throw new InvalidOperationException("Cannot read the file after it has already been read.");

            _isReading = true;

            using (Reader = new BinaryReader(Source, Encoding.ASCII))
            {
                var magic = ReadInt();

                if (magic != 1234321)
                    throw new InvalidDataException("File is not a valid Game Maker file.");

                var version = ReadInt();

                if (!SupportedVersions.Contains(version))
                    throw new NotSupportedException("Unsupported version.");

                Project.Settings.GameID = ReadInt();
                Project.Settings.DirectPlayGuid = new Guid(ReadBlob(16));

                ReadSettings();

                ReadSounds();

                ReadSprites();

                ReadBackgrounds();

                ReadPaths();

                ReadScripts();

                ReadFonts();

                ReadTimelines();

                ReadObjects();

                ReadRooms();

                Project.Instances.NextIndex = ReadInt();
                Project.Tiles.NextIndex = ReadInt();

                ReadGameInformation();

                var versionForFollowing = ReadInt();
                var libraryDependencyCount = ReadInt();
                var libraryCreationCodes = new List<string>();
                for (var i = 0; i < libraryDependencyCount; i++)
                {
                    libraryCreationCodes.Add(ReadString());
                }
                Project.LibraryCreationCodes = libraryCreationCodes;

                versionForFollowing = ReadInt();
                var executableRoomCount = ReadInt();
                var executableRoomList = new List<int>();
                for (var i = 0; i < executableRoomCount; i++)
                {
                    executableRoomList.Add(ReadInt());
                }
                //project.ExecutableRoomList = executableRoomList;

                var rootCount = version >= 700 ? 12 : 11;

                for (var i = 0; i < rootCount; i++)
                {
                    ReadRootResource();
                }
            }
        }

        private byte[] ReadZipped()
        {
            var data = new byte[Reader.ReadUInt32()];

            Reader.Read(data, 0, data.Length);

            using (var ims = new MemoryStream(data))
            using (var oms = new MemoryStream())
            using (var ds = new DeflateStream(ims, CompressionMode.Decompress, true))
            {
                ims.Position = 2; // Skip past the zlib header
                ds.CopyTo(oms);
                return oms.ToArray();
            }
        }

        private byte[] ReadBlob() => ReadBlob(ReadInt());

        private byte[] ReadBlob(int length)
        {
            var data = new byte[length];
            Reader.Read(data, 0, length);
            return data;
        }

        private string ReadString() => new string(Reader.ReadChars(Reader.ReadInt32()));

        private DateTime ReadDate() => ReferenceDate.AddDays(Reader.ReadDouble());

        private bool ReadBool() => Reader.ReadInt32() != 0;

        private int ReadInt() => Reader.ReadInt32();

        public void Dispose()
        {
            Reader?.Dispose();
        }
    }
}
