namespace ConsoleApp.DecoratorPattern.Abstractions
{
    public interface INotifierDecorator : INotifier
    {
        INotifier Wrappee {  get ; }  
    }
}
