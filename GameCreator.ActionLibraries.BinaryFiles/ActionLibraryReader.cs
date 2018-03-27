using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using GameCreator.Resources.Api;

namespace GameCreator.ActionLibraries.BinaryFiles
{
    public class ActionLibraryReader : IDisposable
    {
        public Stream InputStream { get; }

        public ActionLibraryReader(string filename)
            : this(new FileStream(filename, FileMode.Open))
        {
            
        }
        
        public ActionLibraryReader(Stream inputStream)
        {
            InputStream = inputStream;
        }

        private bool _alreadyRead;
        public ActionLibrary Read()
        {
            if (_alreadyRead)
            {
                throw new EndOfStreamException();
            }

            _alreadyRead = true;

            using (var br = new BinaryReader(InputStream, Encoding.ASCII))
            {
                byte[] ReadPrefixedBytes()
                {
                    var bytes = new byte[br.ReadInt32()];
                    br.Read(bytes, 0, bytes.Length);
                    return bytes;
                }

                int ver;
                return new ActionLibrary
                {
                    GameMakerVersion = br.ReadInt32(),
                    TabCaption = new string(br.ReadChars(br.ReadInt32())),
                    LibraryID = br.ReadInt32(),
                    Author = new string(br.ReadChars(br.ReadInt32())),
                    Version = br.ReadInt32(),
                    LastChanged = new DateTime(1899, 12, 30).AddDays(br.ReadDouble()),
                    Info = new string(br.ReadChars(br.ReadInt32())),
                    InitializationCode = new string(br.ReadChars(br.ReadInt32())),
                    AdvancedModeOnly = br.ReadInt32() != 0,
                    LastActionId = br.ReadInt32(),
                    Actions = Enumerable
                        .Range(0, br.ReadInt32())
                        .Select(i => new ActionDefinition
                        {
                            GameMakerVersion = ver = br.ReadInt32(),
                            Name = new string(br.ReadChars(br.ReadInt32())),
                            ActionID = br.ReadInt32(),
                            Image = ReadPrefixedBytes(),
                            Hidden = br.ReadInt32() != 0,
                            Advanced = br.ReadInt32() != 0,
                            RegisteredOnly = ver != 500 && br.ReadInt32() != 0,
                            Description = new string(br.ReadChars(br.ReadInt32())),
                            ListText = new string(br.ReadChars(br.ReadInt32())),
                            HintText = new string(br.ReadChars(br.ReadInt32())),
                            Kind = (ActionKind) br.ReadInt32(),
                            InterfaceKind = (ActionInterfaceKind) br.ReadInt32(),
                            IsQuestion = br.ReadInt32() != 0,
                            ShowApplyTo = br.ReadInt32() != 0,
                            ShowRelative = br.ReadInt32() != 0,
                            ArgumentCount = br.ReadInt32(),
                            Arguments = Enumerable.Range(0, br.ReadInt32())
                                .Select(j => new ActionArgument
                                {
                                    Caption = new string(br.ReadChars(br.ReadInt32())),
                                    Type = (ActionArgumentType) br.ReadInt32(),
                                    DefaultValue = new string(br.ReadChars(br.ReadInt32())),
                                    Menu = new string(br.ReadChars(br.ReadInt32()))
                                }).ToArray(),
                            ExecutionType = (ActionExecutionType) br.ReadInt32(),
                            FunctionName = new string(br.ReadChars(br.ReadInt32())),
                            Code = new string(br.ReadChars(br.ReadInt32()))
                        }).ToList()
                };
            }
        }

        public void Dispose()
        {
            InputStream?.Dispose();
        }
    }
}