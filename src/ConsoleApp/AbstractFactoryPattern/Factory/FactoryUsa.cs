using ConsoleApp.AbstractFactorypattern.Entities;

namespace ConsoleApp.AbstractFactoryPattern.Factory
{
    public class FactoryUsa : IFactoryUsa
    {
        public InvoiceIrs CreateInvoice(decimal amount)
            => new InvoiceIrs(amount);

        public FedexShipment CreateShipment(Address address)
            => new FedexShipment(address);
    }
}
