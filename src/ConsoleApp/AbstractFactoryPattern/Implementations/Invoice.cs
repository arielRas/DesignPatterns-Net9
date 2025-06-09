using ConsoleApp.AbstractFactoryPattern.Abstractions;
using System;

namespace ConsoleApp.AbstractFactorypattern.Entities
{
    public abstract class Invoice : IInvoice
    {
        protected Invoice(decimal amount)
        {
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; set; }
        public decimal Amount { get ; set ; }

        public void Identify()
        {
            Console.WriteLine($"Formato de factura: {this.GetType().Name}");
        }
    }
}
