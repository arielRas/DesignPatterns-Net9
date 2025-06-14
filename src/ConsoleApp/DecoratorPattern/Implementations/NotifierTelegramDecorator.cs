using ConsoleApp.DecoratorPattern.Abstractions;
using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Implementations
{
    internal class NotifierTelegramDecorator : NotifierDecorator
    {
        public NotifierTelegramDecorator(INotifier notifier) : base(notifier)
        {

        }

        public override void Notify(Notification notification)
        {
            Thread.Sleep(1000);

            _notifier.Notify(notification);

            Console.WriteLine($"Enviando notificacion a Telegram {notification.Customer.PhoneNumber}: {notification.Message}");
        }
    }
}