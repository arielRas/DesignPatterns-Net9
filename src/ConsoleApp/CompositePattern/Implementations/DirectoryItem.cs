using ConsoleApp.CompositePattern.Abstractions;

namespace ConsoleApp.CompositePattern.Implementations
{
    public class DirectoryItem : IFileSystemItem
    {
        private string _name;
        public string Name => _name;

        public List<IFileSystemItem> Files = new List<IFileSystemItem>();


        public void Display(int ident = 0)
        {
            var currentIdent = new string(' ', ident);

            Console.WriteLine($"{currentIdent} Directory: {Name}");

            Files.ForEach(x => x.Display(ident + 2));
        }

        public void LoadFromPath(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            var rootDirectory = new DirectoryInfo(path);

            SetName(rootDirectory.Name);

            foreach (var item in rootDirectory.GetDirectories())
            {
                var subDir = new DirectoryItem();

                subDir.LoadFromPath(item.FullName);

                Files.Add(subDir);
            }

            foreach (var item in rootDirectory.GetFiles())
            {
                var size = item.Length / (1024);

                var file = new FileItem(item.Name, item.Extension, size);

                Files.Add(file);
            }
        }

        private void SetName(string name)
            => _name = name;
    }
}
