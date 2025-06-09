using ConsoleApp.MementoPattern.Abstractions;

namespace ConsoleApp.MementoPattern.Implementations
{
    public class Image : IOriginator
    {
        private decimal _colorFilter;
        private decimal _rotation;
        private decimal _crop;
        private decimal _compression;

        private CareTaker _careTaker;
        public decimal ColorFilter => _colorFilter;
        public decimal Rotation => _rotation;
        public decimal Crop => _crop;
        public decimal Compression => _compression;


        public Image(decimal colorFilter, decimal rotation, decimal crop, decimal compression)
        {
            _colorFilter = colorFilter;
            _rotation = rotation;
            _crop = crop;
            _compression = compression;
            _careTaker = new CareTaker(this);
        }

        public void SetColorFilter(decimal value)
        {
            _careTaker.SaveMemento();

            _colorFilter = value;
        }

        public void SetRotation(decimal value)
        {
            _careTaker.SaveMemento();

            _rotation = value;
        }

        public void SetCrop(decimal value)
        {
            _careTaker.SaveMemento();

            _crop = value;
        }

        public void SetCompression(decimal value)
        {
            _careTaker.SaveMemento();

            _compression = value;
        }

        public void Undo()
            => SetState(_careTaker.Undo());

        public void Redo()
            => SetState(_careTaker.Redo());

        public void PrintCurrentProperties()
        {
            Console.WriteLine($"Propiedades actuales de la imagen:\nFiltro de color: {ColorFilter}\nRotacion: {Rotation}\nRecorte: {Crop}\nCompresion: {Compression}\n");
        }

        private void SetState(Memento memento)
        {
            _colorFilter = memento.ColorFilter;
            _rotation = memento.Rotation;
            _crop = memento.Crop;
            _compression = memento.Compression;
        }
    }
}
