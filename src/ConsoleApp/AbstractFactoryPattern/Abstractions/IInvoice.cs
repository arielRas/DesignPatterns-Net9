using System;

namespace ConsoleApp.AbstractFactoryPattern.Abstractions
{
    public interface IInvoice
    {
        DateTime CreatedAt { get; set; }
        decimal Amount { get; set; }
        void Identify();
    }
}