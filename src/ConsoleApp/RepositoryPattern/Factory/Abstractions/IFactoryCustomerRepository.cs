using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Factory.Abstractions
{
    public interface IFactoryCustomerRepository : IFactoryRepository<ICustomerRepository, Customer>
    {

    }
}
