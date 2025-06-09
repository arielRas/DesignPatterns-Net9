namespace ConsoleApp.FactoryPattern.Abstractions
{
    public interface IAccount
    {
        double Balance { get; }
        void Deposit(double amount);
        void Transfer(IAccount destinationAccount, double amount);
    }
}
