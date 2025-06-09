using ConsoleApp.FactoryPattern.Abstractions;

namespace ConsoleApp.FactoryPattern.Implementations
{
    public class BankAccount : IAccount
    {
        private double balance;

        public BankAccount()
        {
            balance = 0;
        }

        public double Balance => balance;

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Transfer(IAccount destinationAccount, double amount)
        {
            balance -= amount;

            destinationAccount.Deposit(amount);
        }
    }
}
