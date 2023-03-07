using System;
using System.Runtime.Serialization;

namespace FileGeneratorGui.Models
{
    [Serializable]
    internal class FileConflictException : Exception
    {
        private FileModelBase? existingFile;
        private FileModelBase? file;

        public FileConflictException()
        {
        }

        public FileConflictException(string? message) : base(message)
        {
        }

        public FileConflictException(FileModelBase existingFile, FileModelBase file)
            : base($"{existingFile.FileName}: Conflicts with new file {file.FileName}")
        {
            this.existingFile = existingFile;
            this.file = file;
        }

        public FileConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FileConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FileModelBase? ExistingFile { get => existingFile;  }
        public FileModelBase? File { get => file; }
    }
}