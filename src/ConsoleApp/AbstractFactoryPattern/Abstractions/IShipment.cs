using ConsoleApp.AbstractFactorypattern.Entities;

namespace ConsoleApp.AbstractFactoryPattern.Abstractions
{
    public interface IShipment
    {
        Address Address { get; set; }
        void Identify();
    }
}
