using ConsoleApp.AbstractFactoryPattern.Abstractions;
using System;

namespace ConsoleApp.AbstractFactorypattern.Entities
{
    public abstract class Shipment : IShipment
    {
        public Address Address { get; set; }

        protected Shipment(Address address)
        {
            Address = address;
        }

        public void Identify()
        {
            Console.WriteLine($"Proveedor de envio: {this.GetType().Name}");
        }
    }
}
