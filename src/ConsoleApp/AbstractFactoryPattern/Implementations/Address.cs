using ConsoleApp.AbstractFactoryPattern.Enums;

namespace ConsoleApp.AbstractFactorypattern.Entities
{
    public class Address
    {
        public string? Street {  get; set; }
        public int Number {  get; set; }
        public Countries Country { get; set; }
    }
}
