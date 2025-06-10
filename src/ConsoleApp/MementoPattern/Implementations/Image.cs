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
            _careTaker = new CareTaker();
        }

        public void SetColorFilter(decimal value)
        {
            _careTaker.SaveState(GetCurrentState());

            _colorFilter = value;
        }

        public void SetRotation(decimal value)
        {
            _careTaker.SaveState(GetCurrentState());

            _rotation = value;
        }

        public void SetCrop(decimal value)
        {
            _careTaker.SaveState(GetCurrentState());

            _crop = value;
        }

        public void SetCompression(decimal value)
        {
            _careTaker.SaveState(GetCurrentState());

            _compression = value;
        }

        public void Undo()
        {
            Memento previousState = _careTaker.Undo(GetCurrentState());

            SetState(previousState);
        }

        public void Redo()
        {
            Memento nextMemento = _careTaker.Redo(GetCurrentState());

            SetState(nextMemento);
        }

        public void PrintCurrentProperties()
        {
            Console.WriteLine($"Propiedades actuales de la imagen:\nFiltro de color: {ColorFilter}\nRotacion: {Rotation}\nRecorte: {Crop}\nCompresion: {Compression}\n");
        }        

        public void SaveState()
        {
            _careTaker.SaveState(GetCurrentState());
        }

        private void SetState(Memento memento)
        {
            _colorFilter = memento.ColorFilter;
            _rotation = memento.Rotation;
            _crop = memento.Crop;
            _compression = memento.Compression;
        }

        private Memento GetCurrentState()
        {
            return new Memento(this);
        }
    }
}
