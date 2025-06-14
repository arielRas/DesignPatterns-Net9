using ConsoleApp.DecoratorPattern.Abstractions;
using ConsoleApp.DecoratorPattern.Entities;

namespace ConsoleApp.DecoratorPattern.Implementations
{
    public abstract class NotifierDecorator : INotifierDecorator
    {
        protected readonly INotifier _notifier;

        public INotifier Wrappee => _notifier;

        protected NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public abstract void Notify(Notification notification);
    }
}
