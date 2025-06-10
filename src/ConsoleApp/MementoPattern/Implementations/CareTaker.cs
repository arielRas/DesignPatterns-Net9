namespace ConsoleApp.MementoPattern.Implementations
{
    public class CareTaker
    {
        private Stack<Memento> _undoStack;
        private Stack<Memento> _redoStack;

        public CareTaker()
        {
            _undoStack = new Stack<Memento>();
            _redoStack = new Stack<Memento>();
        }

        public void SaveState(Memento state)
        {
            _undoStack.Push(state);

            if (_redoStack.Count > 0)
                _redoStack.Clear();
        }

        public Memento Undo(Memento currentState)
        {
            if (_undoStack != null && _undoStack.Count > 0)
            {
                _redoStack.Push(currentState);

                var previousState = _undoStack.Pop();

                return previousState;
            }
            else
                throw new Exception("No existen estados guardados de la imagen");
        }

        public Memento Redo(Memento currentState)
        {
            if (_redoStack != null && _redoStack.Count > 0)
            {
                _undoStack.Push(currentState);

                var nextMemento = _redoStack.Pop();

                return nextMemento;
            }
            else
                throw new Exception("No existen estados para rehacer");
        }
    }
}
