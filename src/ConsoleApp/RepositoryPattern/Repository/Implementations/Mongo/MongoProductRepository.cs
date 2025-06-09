using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Enums;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.Mongo
{
    public class MongoProductRepository : MongoRepository<Product>, IProductRepository
    {   
        public MongoProductRepository() : base(MongoCollections.Products)
        {

        }
    }
}
