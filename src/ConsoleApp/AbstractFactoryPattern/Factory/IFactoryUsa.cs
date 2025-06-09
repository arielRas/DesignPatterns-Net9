using ConsoleApp.AbstractFactorypattern.Entities;

namespace ConsoleApp.AbstractFactoryPattern.Factory
{
    public interface IFactoryUsa : IFactory<InvoiceIrs, FedexShipment>
    {

    }
}
