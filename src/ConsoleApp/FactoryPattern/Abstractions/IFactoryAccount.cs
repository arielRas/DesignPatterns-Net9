using ConsoleApp.FactoryPattern.Enums;

namespace ConsoleApp.FactoryPattern.Abstractions
{
    public interface IFactoryAccount
    {
        IAccount Create(AccountTypes accountType);
    }
}
