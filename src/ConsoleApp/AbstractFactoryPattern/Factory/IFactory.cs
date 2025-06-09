using ConsoleApp.AbstractFactorypattern.Entities;
using ConsoleApp.AbstractFactoryPattern.Abstractions;

namespace ConsoleApp.AbstractFactoryPattern.Factory
{
    public interface IFactory<TInvoice, TShipment>
        where TInvoice : class, IInvoice
        where TShipment : class, IShipment
    {
        TInvoice CreateInvoice(decimal amount);
        TShipment CreateShipment(Address address);
    }
}
