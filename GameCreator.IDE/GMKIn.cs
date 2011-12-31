using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.IDE
{
    class GMKIn : System.IO.Stream
    {
        System.IO.Stream s;
        int[,] table;
        int pos;
        int len;
        long outlen;
        long outpos;
        byte[] buffer = new byte[512];
        int bufferptrin;
        int bufferptrout;
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
        public GMKIn(System.IO.Stream source)
        {
            s = source;
            int tpos = (int)s.Position;
            len = (int)s.Length;
            s.Seek(0, System.IO.SeekOrigin.Begin);
            s.Read(buffer, 0, 16);
            int junk1 = BitConverter.ToInt32(buffer, 8);
            int junk2 = BitConverter.ToInt32(buffer, 12);
            s.Seek(junk1 * 4, System.IO.SeekOrigin.Current);
            s.Read(buffer, 8, 4);
            int seed = BitConverter.ToInt32(buffer, 8);
            table = GenerateSwapTable(seed);
            s.Seek(junk2 * 4, System.IO.SeekOrigin.Current);
            outlen = s.Length - (s.Position - 8L);
            outpos = 0;
            buffer[8] = (byte)s.ReadByte();
            bufferptrin = 9;
            bufferptrout = tpos;
            pos = (int)s.Position;
        }
        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush() { }

        public override long Length
        {
            get { return outlen; }
        }

        public override long Position
        {
            get
            {
                return outpos;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        void FillBuffer()
        {
            if ((bufferptrin == 512) || (pos == len))
                bufferptrout = bufferptrin = 0;
            for (; bufferptrin < 512 && pos < len; bufferptrin++, pos++)
                buffer[bufferptrin] = (byte)(table[1, s.ReadByte()] - pos);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int initialcount = count;
            do
            {
                for (; count > 0 && bufferptrout < bufferptrin; offset++, count--, bufferptrout++)
                    buffer[offset] = this.buffer[bufferptrout];
                if (bufferptrin == bufferptrout)
                    FillBuffer();
            } while (count > 0 && bufferptrin < bufferptrout);
            return initialcount - count;
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
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
    }
}
