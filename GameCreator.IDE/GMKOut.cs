using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.IDE
{
    class GMKOut : System.IO.Stream
    {
        System.IO.Stream s;
        int[,] table;
        int extra;
        long pos;
        private static int[,] GenerateSwapTable(int seed)
        {
            int[,] table = new int[2, 256];
            int a = 6 + (seed % 250);
            int b = seed / 250;
            for (int i = 0; i < 256; i++)
            {
                table[0, i] = i;
            }
            for (int i = 1; i <= 10000; i++)
            {
                int j = 1 + ((i * a + b) % 254);
                int t = table[0, j];
                table[0, j] = table[0, j + 1];
                table[0, j + 1] = t;
            }
            table[1, 0] = 0; //this operation is optional, as 0 is default
            for (int i = 1; i < 256; i++)
            {
                table[1, table[0, i]] = i;
            }
            return table;
        }
        public GMKOut(System.IO.Stream source)
        {
            s = source;
            Random r = new Random(Environment.TickCount);
            int junk1 = 0; // r.Next(1, 3000) + 123;
            int junk2 = 0; // r.Next(1, 3000) + 321;
            int seed = 0xF8; // r.Next(1, 25600) + 3328;
            extra = (junk1 + junk2 + 3) * 4;
            table = GenerateSwapTable(seed);
            s.Write(new byte[] { 0x91, 0xD5, 0x12, 0x00, 0xBD, 0x02, 0x00, 0x00 }, 0, 8);
            s.Write(BitConverter.GetBytes(junk1), 0, 4);
            s.Write(BitConverter.GetBytes(junk2), 0, 4);
            for (int i = 0; i < junk1; i++)
                s.Write(BitConverter.GetBytes(r.Next(1, 3000)), 0, 4);
            s.Write(BitConverter.GetBytes(seed), 0, 4);
            for (int i = 0; i < junk2; i++)
                s.Write(BitConverter.GetBytes(r.Next(1, 3000)), 0, 4);
            pos = s.Position;
        }
        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            s.Flush();
        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new InvalidOperationException();
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
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
                if (pos < 8)
                {
                    for (; pos < 8 && count > 0; pos++, count--)
                        s.WriteByte(buffer[offset++]);
                    if (pos == 8)
                    {
                        pos += extra;
                        s.Seek(extra, System.IO.SeekOrigin.Current);
                    }
                }
                else if (pos == extra + 8 && count > 0)
                {
                    s.WriteByte(buffer[offset++]);
                    count--;
                    pos++;
                }
                else
                {
                    for (; count > 0; count--, pos++)
                        s.WriteByte((byte)(table[0, buffer[offset++]] + pos));
                }
            }
        }
    }
}
