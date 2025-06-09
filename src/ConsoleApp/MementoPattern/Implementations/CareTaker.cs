using ConsoleApp.MementoPattern.Abstractions;

namespace ConsoleApp.MementoPattern.Implementations
{
    public class CareTaker
    {
        private readonly Image _originator;
        private Stack<Memento> _undo;
        private Stack<Memento> _redo;

        public CareTaker(Image originator)
        {
            _originator = originator;
            _undo = new Stack<Memento>();
            _redo = new Stack<Memento>();
        }

        public void SaveMemento()
        {
            _undo.Push(GetCurrentState(_originator));

            if (_redo.Count > 0)
                _redo.Clear();
        }

        public Memento Undo()
        {
            if (_undo != null && _undo.Count > 0)
            {
                _redo.Push(GetCurrentState(_originator));

                var lastMemento = _undo.Pop();

                return lastMemento;
            }
            else
                throw new Exception("No existen estados guardados de la imagen");
        }

        public Memento Redo()
        {
            if (_redo != null && _redo.Count > 0)
            {
                _undo.Push(GetCurrentState(_originator));

                var nextMemento = _redo.Pop();

                return nextMemento;
            }
            else
                throw new Exception("No existen estados para rehacer");
        }

        private Memento GetCurrentState(Image image)
        {
            return new Memento(image);
        }
    }
}
