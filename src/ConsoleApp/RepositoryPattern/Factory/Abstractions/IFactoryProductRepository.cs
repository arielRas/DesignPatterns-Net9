using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Factory.Abstractions
{
    public interface IFactoryProductRepository : IFactoryRepository<IProductRepository, Product>
    {

    }
}
