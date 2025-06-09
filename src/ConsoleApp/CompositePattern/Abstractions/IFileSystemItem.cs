namespace ConsoleApp.CompositePattern.Abstractions
{
    public interface IFileSystemItem
    {
        string Name { get; }
        void Display(int ident = 0);
    }
}
