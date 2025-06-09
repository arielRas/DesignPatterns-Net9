namespace ConsoleApp.MementoPattern.Implementations
{
    public class Memento
    {
        private readonly decimal _colorFilter;
        private readonly decimal _rotation;
        private readonly decimal _crop;
        private readonly decimal _compression;

        public decimal ColorFilter => _colorFilter;
        public decimal Rotation => _rotation;
        public decimal Crop => _crop;
        public decimal Compression => _compression;

        public Memento(Image image)
        {
            _colorFilter = image.ColorFilter;
            _rotation = image.Rotation;
            _crop = image.Crop;
            _compression = image.Compression;
        }
    }
}
