using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Abstractions
{
    public interface INotifier
    {
        void Notify(Notification notification);
    }
}
