using ConsoleApp.RepositoryPattern.Factory.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Implementations.Memory;
using ConsoleApp.RepositoryPattern.Repository.Implementations.Mongo;
using ConsoleApp.RepositoryPattern.Repository.Implementations.SqlServerAdoNet;
using ConsoleApp.RepositoryPattern.Settings;

namespace ConsoleApp.RepositoryPattern.Factory.Implementations
{
    public class FactoryCustomerRepository : IFactoryCustomerRepository
    {
        public ICustomerRepository CreateRepository()
        {
            return DbEngineSettings.Engine.ToLower().Trim() switch
            {
                "mongo" => new MongoCustomerRepository(),
                "sqlserver" => new SqlServerCustomerRepository(),
                "memory" => new MemoryCustomerRepository(),
                _ => throw new ArgumentNullException("La configuracion del motor de base de datos no es valida")
            };
        }
    }
}
