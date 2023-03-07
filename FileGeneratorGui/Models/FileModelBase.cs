using System;

namespace FileGeneratorGui.Models
{
    public abstract class FileModelBase
    {
        public Guid Id { get; set; }
        public string? Folder { get; set; }
        public string? FileName { get; set; }
        public string? Description { get; set; }
        public long Size { get; set; }

        public int BlockSize { get; set; }
        protected FileModelBase(string? folder, string? fileName, string? description, long size, int blockSize)
        {
            Id = Guid.NewGuid();
            Folder = folder;
            FileName = fileName;
            Description = description;
            Size = size;
            BlockSize = blockSize;
        }

        public abstract void GenerateFile();

        internal bool ConflictsWith(FileModelBase file)
        {
            return file.FileName == FileName;
        }
    }
}