using ConsoleApp.DecoratorPattern.Abstractions;
using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Implementations
{
    public class NotifierPerformanceDecorator : NotifierDecorator
    {
        public NotifierPerformanceDecorator(INotifier notifier) : base(notifier)
        {

        }

        public override void Notify(Notification notification)
        {
            var startTime = DateTime.Now;

            Thread.Sleep(1000);

            _notifier.Notify(notification);

            var executionTime = DateTime.Now - startTime;

            Console.WriteLine($"El tiempo de ejecucion de las notificaciones al cliente: {notification.Customer.Name} es: {executionTime.TotalSeconds} segundos");
        }
    }
}
