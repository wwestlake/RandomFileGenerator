namespace FileGeneration.Models
{
    public abstract class FileDetails
    {
        public string? FileName { get; set; }
        public string? Description { get; set; }
        public long Size { get; set; }

        public abstract void GenerateFile();

    }
}