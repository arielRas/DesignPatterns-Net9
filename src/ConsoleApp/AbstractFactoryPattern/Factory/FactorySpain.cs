using ConsoleApp.AbstractFactorypattern.Entities;

namespace ConsoleApp.AbstractFactoryPattern.Factory
{
    public class FactorySpain : IFactorySpain
    {
        public InvoiceAeat CreateInvoice(decimal amount)
            => new InvoiceAeat(amount);

        public CorreosShipment CreateShipment(Address address)
            => new CorreosShipment(address);
    }
}
