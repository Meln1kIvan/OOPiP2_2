using System;
using System.IO;

namespace MyLib
{
    public class MemoryStreamDecorator : StreamDecorator
    {
        private readonly byte[] _closingBytes;

        public MemoryStreamDecorator(MemoryStream memoryStream, byte[] closingBytes) : base(memoryStream)
        {
            _closingBytes = closingBytes;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Array.IndexOf(_closingBytes, buffer[i + offset]) != -1)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }


            base.Write(buffer, offset, count);
        }
    }
}
