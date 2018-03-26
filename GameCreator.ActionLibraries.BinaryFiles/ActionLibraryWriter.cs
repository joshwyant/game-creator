using System;
using System.IO;
using System.Text;

namespace GameCreator.ActionLibraries.BinaryFiles
{
    public class ActionLibraryWriter : IDisposable
    {
        public ActionLibrary Library { get; }
        public Stream OutputStream { get; }

        public ActionLibraryWriter(ActionLibrary library, Stream outputStream)
        {
            Library = library;
            OutputStream = outputStream;
        }

        public ActionLibraryWriter(ActionLibrary library, string filename)
            : this(library, new FileStream(filename, FileMode.Create))
        {
            
        }

        private bool _alreadyWritten;
        public void Write()
        {
            if (_alreadyWritten)
            {
                throw new InvalidOperationException("Library has already been saved.");
            }

            _alreadyWritten = true;
            
            using (var bw = new BinaryWriter(OutputStream, Encoding.ASCII))
            {
                bw.Write(Library.GameMakerVersion);
                bw.Write(Library.TabCaption.Length);
                bw.Write(Library.TabCaption.ToCharArray());
                bw.Write(Library.LibraryID);
                bw.Write(Library.Author.Length); 
                bw.Write(Library.Author.ToCharArray());
                bw.Write(Library.Version);
                bw.Write(Library.LastChanged.Subtract(new DateTime(1899, 12, 30)).TotalDays);
                bw.Write(Library.Info.Length);
                bw.Write(Library.Info.ToCharArray());
                bw.Write(Library.InitializationCode.Length); 
                bw.Write(Library.InitializationCode.ToCharArray());
                bw.Write(Library.AdvancedModeOnly ? 1 : 0);
                bw.Write(Library.LastActionId);
                bw.Write(Library.Actions.Count);
                foreach (var a in Library.Actions)
                {
                    bw.Write(a.GameMakerVersion);
                    bw.Write(a.Name.Length); 
                    bw.Write(a.Name.ToCharArray());
                    bw.Write(a.ActionID);
                    bw.Write(a.Image.Length);
                    bw.Write(a.Image);
                    bw.Write(a.Hidden ? 1 : 0);
                    bw.Write(a.Advanced ? 1 : 0);
                    if (a.GameMakerVersion != 500)
                    {
                        bw.Write(a.RegisteredOnly ? 1 : 0);
                    }

                    bw.Write(a.Description.Length);
                    bw.Write(a.Description.ToCharArray());
                    bw.Write(a.ListText.Length);
                    bw.Write(a.ListText.ToCharArray());
                    bw.Write(a.HintText.Length); 
                    bw.Write(a.HintText.ToCharArray());
                    bw.Write((int)a.Kind);
                    bw.Write((int)a.InterfaceKind);
                    bw.Write(a.IsQuestion ? 1 : 0);
                    bw.Write(a.ShowApplyTo ? 1 : 0);
                    bw.Write(a.ShowRelative ? 1 : 0);
                    bw.Write(a.ArgumentCount);
                    bw.Write(8);
                    for (var i = 0; i < 8; i++)
                    {
                        var arg = i < a.ArgumentCount 
                            ? a.Arguments[i] 
                            : new ActionArgument();
                        bw.Write(arg.Caption.Length);
                        bw.Write(arg.Caption.ToCharArray());
                        bw.Write((int)arg.Type);
                        bw.Write(arg.DefaultValue.Length);
                        bw.Write(arg.DefaultValue.ToCharArray());
                        bw.Write(arg.Menu.Length);
                        bw.Write(arg.Menu.ToCharArray());
                    }
                    bw.Write((int)a.ExecutionType);
                    bw.Write(a.FunctionName.Length); 
                    bw.Write(a.FunctionName.ToCharArray());
                    bw.Write(a.Code.Length);
                    bw.Write(a.Code.ToCharArray());
                }
                OutputStream.Flush();
            }
        }

        public void Dispose()
        {
            OutputStream?.Dispose();
        }
    }
}