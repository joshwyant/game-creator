using System;
using System.IO;
using static System.BitConverter;

namespace GameCreator.Projects.GMFiles
{
    public class GMKOut : Stream
    {
        private Stream Source { get; }
        private int[,] SwapTable { get; }
        private int Extra { get; }
        private long SourcePos { get; set; }
        
        public GMKOut(Stream source)
        {
            Source = source;
            var r = new Random(Environment.TickCount);
            var junkCount1 = r.Next(1, 3000) + 123;
            var junkCount2 = r.Next(1, 3000) + 321;
            var seed = r.Next(1, 25600) + 3328;
            Extra = (junkCount1 + junkCount2 + 3) * 4;
            SwapTable = GenerateSwapTable(seed);
            Source.Write(new byte[] { 0x91, 0xD5, 0x12, 0x00, 0xBD, 0x02, 0x00, 0x00 }, 0, 8);
            Source.Write(GetBytes(junkCount1), 0, 4);
            Source.Write(GetBytes(junkCount2), 0, 4);
            for (var i = 0; i < junkCount1; i++)
            {
                Source.Write(GetBytes(r.Next(1, 3000)), 0, 4);
            }
            Source.Write(GetBytes(seed), 0, 4);
            for (var i = 0; i < junkCount2; i++)
            {
                Source.Write(GetBytes(r.Next(1, 3000)), 0, 4);
            }
            SourcePos = Source.Position;
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
        
        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override void Flush()
        {
            Source.Flush();
        }

        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new InvalidOperationException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            while (count > 0)
            {
                if (SourcePos < 8)
                {
                    for (; SourcePos < 8 && count > 0; SourcePos++, count--)
                    {
                        Source.WriteByte(buffer[offset++]);
                    }
                    if (SourcePos == 8)
                    {
                        SourcePos += Extra;
                        Source.Seek(Extra, SeekOrigin.Current);
                    }
                }
                else if (SourcePos == Extra + 8 && count > 0)
                {
                    Source.WriteByte(buffer[offset++]);
                    count--;
                    SourcePos++;
                }
                else
                {
                    for (; count > 0; count--, SourcePos++)
                    {
                        Source.WriteByte((byte) (SwapTable[0, buffer[offset++]] + SourcePos));
                    }
                }
            }
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