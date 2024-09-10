using System.IO;
using System.IO.MemoryMappedFiles;

namespace ClassicUO.IO;

public class MMFileWriter : FileWriter
{
    private readonly MemoryMappedViewAccessor _accessor;
    private readonly MemoryMappedFile _mmf;
    private readonly BinaryWriter _writer;

    public MMFileWriter(FileStream stream, FileMode mode) : base(stream)
    {
        if (mode == FileMode.CreateNew)
        {
            _mmf = MemoryMappedFile.CreateFromFile
            (
                stream,
                null,
                0,
                MemoryMappedFileAccess.Read,
                HandleInheritability.None,
                false
            );
        } else if (mode == FileMode.Open)
        {
            _mmf = MemoryMappedFile.
        }
        
    }

    public override BinaryWriter Writer => _writer; 
}