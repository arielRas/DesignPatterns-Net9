using ConsoleApp.DecoratorPattern.Abstractions;
using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Implementations
{
    public class NotifierLoggerDecorator : NotifierDecorator
    {
        public NotifierLoggerDecorator(INotifier notifier) : base(notifier)
        {

        }

        public override void Notify(Notification notification)
        {
            Thread.Sleep(1000);

            Console.WriteLine($"[INFO] - {DateTime.Now} - Inicio de notificaciones al cliente: {notification.Customer.Name} - Mensaje: {notification.Message}");

            _notifier.Notify(notification);

        }
    }
}
