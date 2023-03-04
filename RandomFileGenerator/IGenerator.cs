
namespace RandomFileGenerator
{
    public interface IGenerator
    {
        void Generate(Stream sink, long numberOfBytes);
    }
}