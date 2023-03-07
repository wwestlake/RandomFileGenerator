namespace RandomFileGeneratorLib
{
    public interface IFileGeneratorOptions
    {
        string? Filename { get; set; }
        string? FileType { get; set; }
        string? HashType { get; set; }
        int MaxPAragraphSize { get; set; }
        int MinPAragraphSize { get; set; }
        bool Paragraphize { get; set; }
        long Size { get; set; }
        string? TextType { get; set; }
        string? Unit { get; set; }
        bool Zeros { get; set; }
    }
}