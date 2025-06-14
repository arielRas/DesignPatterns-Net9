using ConsoleApp.DecoratorPattern.Abstractions;
using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Implementations
{
    public class NotifierWhatsappDecorator : NotifierDecorator
    {
        public NotifierWhatsappDecorator(INotifier notifier) : base(notifier)
        {
            
        }

        public override void Notify(Notification notification)
        {
            Thread.Sleep(1000);

            _notifier.Notify(notification);

            Console.WriteLine($"Enviando notificacion a Whatsapp {notification.Customer.PhoneNumber}: {notification.Message}");
        }
    }
}
