using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Enums;
using MongoDB.Driver;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.Mongo
{
    public class MongoCustomerRepository : MongoRepository<Customer>, ICustomerRepository
    {
        public MongoCustomerRepository() : base(MongoCollections.Customers)
        {

        }

        public Customer GetByEmail(string email)
        {
            var filter = _filterBuilder.Eq(c => c.Email, email);

            return _collection.Find(filter).FirstOrDefault()
                ?? throw new KeyNotFoundException($"El producto con email: {email} no existe");
        }
    }
}
