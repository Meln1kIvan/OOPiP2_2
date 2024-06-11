using System;
using System.IO;

namespace MyLib
{
    public class FileStreamDecorator : StreamDecorator
    {
        readonly byte[] _closingBytes;

        public FileStreamDecorator(FileStream fileStream, byte[] closingBytes) : base(fileStream)
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
