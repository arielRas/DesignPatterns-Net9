using ConsoleApp.AbstractFactorypattern.Entities;

namespace ConsoleApp.AbstractFactoryPattern.Factory
{
    public class FactoryArgentina : IFactoryArgentina
    {
        public InvoiceAfip CreateInvoice(decimal amount)
            => new InvoiceAfip(amount);

        public CorreoArgentinoShipment CreateShipment(Address address)
            => new CorreoArgentinoShipment(address);
    }
}
