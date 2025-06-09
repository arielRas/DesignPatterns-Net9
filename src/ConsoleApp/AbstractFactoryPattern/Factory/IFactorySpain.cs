using ConsoleApp.AbstractFactorypattern.Entities;

namespace ConsoleApp.AbstractFactoryPattern.Factory
{
    public interface IFactorySpain : IFactory<InvoiceAeat, CorreosShipment>
    {
    }
}
