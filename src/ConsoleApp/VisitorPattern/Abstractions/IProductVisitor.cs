using ConsoleApp.VisitorPattern.Implementations;

namespace ConsoleApp.VisitorPattern.Abstractions
{
    public interface IProductVisitor
    {
        void Visit(SmartPhone product);
        void Visit(Tablet product);
        void Visit(Router product);
    }
}
