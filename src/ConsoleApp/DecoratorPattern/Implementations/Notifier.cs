using ConsoleApp.DecoratorPattern.Abstractions;
using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Implementations
{
    public class Notifier : INotifier
    {
        public void Notify(Notification notification)
        {
            Console.WriteLine("Iniciando notificaciones");
        }
    }
}
