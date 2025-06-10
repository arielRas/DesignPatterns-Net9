using ConsoleApp.MementoPattern.Implementations;

namespace ConsoleApp.MementoPattern.Abstractions
{
    public interface IOriginator
    {
        void Redo();
        void Undo();
        void SaveState();
    }
}
