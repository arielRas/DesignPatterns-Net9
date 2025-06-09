using ConsoleApp.CompositePattern.Abstractions;

namespace ConsoleApp.CompositePattern.Implementations
{
    public class FileItem : IFileSystemItem
    {
        public string Name { get; }
        public string Extension { get; }
        public double Size { get; }

        public FileItem(string name, string extension, double size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }

        public void Display(int ident = 0)
        {
            var currentIdent = new string(' ', ident);

            Console.WriteLine($"{currentIdent}{Name} | Size: {Size}Kb");
        }
    }
}
