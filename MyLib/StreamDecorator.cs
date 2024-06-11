using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace MyLib
{
    public abstract class StreamDecorator : Stream
    {
        protected Stream DecoratedStream { get; }

        protected StreamDecorator(Stream decoratedStream)
        {
            DecoratedStream = decoratedStream;
        }

        public override bool CanRead => DecoratedStream.CanRead;

        public override bool CanSeek => DecoratedStream.CanSeek;

        public override bool CanWrite => DecoratedStream.CanWrite;

        public override long Length => DecoratedStream.Length;

        public override long Position
        {
            get => DecoratedStream.Position;
            set => DecoratedStream.Position = value;
        }

        public override void Flush() => DecoratedStream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => DecoratedStream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => DecoratedStream.Seek(offset, origin);

        public override void SetLength(long value) => DecoratedStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => DecoratedStream.Write(buffer, offset, count);
    }
}
