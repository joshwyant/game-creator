using System;
using System.IO;
using static System.BitConverter;

namespace GameCreator.Projects.GMFiles
{
    public class GMKIn : Stream
    {
        private Stream Source { get; }
        private int[,] SwapTable { get; }
        private int SourceLength { get; }
        private long OutPos { get; }
        private byte[] Buffer { get; }
        private int SourcePos { get; set; }
        private int BufferPtrIn { get; set; }
        private int BufferPtrOut { get; set; }
        
        public GMKIn(Stream source)
        {
            Buffer = new byte[512];
            Source = source;
            var tpos = (int)Source.Position;
            SourceLength = (int)Source.Length;
            Source.Seek(0, SeekOrigin.Begin);
            Source.Read(Buffer, 0, 16);
            var junkCount1 = ToInt32(Buffer, 8);
            var junkCount2 = ToInt32(Buffer, 12);
            Source.Seek(junkCount1 * 4, SeekOrigin.Current);
            Source.Read(Buffer, 8, 4);
            var seed = ToInt32(Buffer, 8);
            SwapTable = GenerateSwapTable(seed);
            Source.Seek(junkCount2 * 4, SeekOrigin.Current);
            Length = Source.Length - (Source.Position - 8L);
            OutPos = 0;
            Buffer[8] = (byte)Source.ReadByte();
            BufferPtrIn = 9;
            BufferPtrOut = tpos;
            SourcePos = (int)Source.Position;
        }
        
        private static int[,] GenerateSwapTable(int seed)
        {
            var table = new int[2, 256];
            var a = 6 + seed % 250;
            var b = seed / 250;
            for (var i = 0; i < 256; i++)
            {
                table[0, i] = i;
            }
            for (var i = 1; i <= 10000; i++)
            {
                var j = 1 + (i * a + b) % 254;
                var t = table[0, j];
                table[0, j] = table[0, j + 1];
                table[0, j + 1] = t;
            }
            table[1, 0] = 0; //this operation is optional, as 0 is default
            for (var i = 1; i < 256; i++)
            {
                table[1, table[0, i]] = i;
            }
            return table;
        }
        
        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override void Flush() { }

        public override long Length { get; }

        public override long Position
        {
            get => OutPos;
            set => throw new NotSupportedException();
        }

        private void FillBuffer()
        {
            if (BufferPtrIn == 512 || SourcePos == SourceLength)
            {
                BufferPtrOut = BufferPtrIn = 0;
            }
            for (; BufferPtrIn < 512 && SourcePos < SourceLength; BufferPtrIn++, SourcePos++)
            {
                Buffer[BufferPtrIn] = (byte) (SwapTable[1, Source.ReadByte()] - SourcePos);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var initialcount = count;
            do
            {
                for (; count > 0 && BufferPtrOut < BufferPtrIn; offset++, count--, BufferPtrOut++)
                {
                    buffer[offset] = Buffer[BufferPtrOut];
                }
                if (BufferPtrIn == BufferPtrOut)
                {
                    FillBuffer();
                }
            } while (count > 0 && BufferPtrIn < BufferPtrOut);
            
            return initialcount - count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException();
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Source?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}