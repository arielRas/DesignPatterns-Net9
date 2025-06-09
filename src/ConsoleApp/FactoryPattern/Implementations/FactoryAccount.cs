using ConsoleApp.FactoryPattern.Abstractions;
using ConsoleApp.FactoryPattern.Enums;

namespace ConsoleApp.FactoryPattern.Implementations
{
    public class FactoryAccount : IFactoryAccount
    {
        public IAccount Create(AccountTypes accountType)
        {
            switch (accountType)
            {
                case AccountTypes.Bank:
                    Console.WriteLine($"Creando {nameof(BankAccount)}...");
                    return new BankAccount();

                case AccountTypes.VirtualWallet:
                    Console.WriteLine($"Creando {nameof(VirtualWallet)}...");
                    return new VirtualWallet();

                default:
                    throw new ArgumentException("El tipo de cuenta que desea crear no existe");
            }
        }
    }
}
