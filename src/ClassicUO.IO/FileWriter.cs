using System;
using System.IO;

namespace ClassicUO.IO
{
    public abstract class FileWriter : IDisposable
    {
        private long _position;
        private readonly FileStream _Stream;
        
        protected FileWriter(FileStream stream)
        {
            _Stream = stream;
        }
        
        public long Length => _Stream.Length;
        public long Position => _position;

        public abstract BinaryWriter Writer { get; }

        public void Dispose()
        {
            Writer?.Dispose();
            _Stream?.Dispose();
        }
        
        public void Seek(long index, SeekOrigin origin) => _position = Writer.BaseStream.Seek(index, origin);
        
        //It is used only by UltimaLive, that's why it is the only method here
        public void WriteArray(long position, byte[] array)
        {
            Seek((int) position, SeekOrigin.Begin);
            Writer.Write(array, 0, array.Length);
            Writer.Flush();
        }
    }
}
