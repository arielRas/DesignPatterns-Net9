using ConsoleApp.RepositoryPattern.Factory.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Implementations.Memory;
using ConsoleApp.RepositoryPattern.Repository.Implementations.Mongo;
using ConsoleApp.RepositoryPattern.Repository.Implementations.SqlServerAdoNet;
using ConsoleApp.RepositoryPattern.Settings;

namespace ConsoleApp.RepositoryPattern.Factory.Implementations
{
    public class FactoryProductRepository : IFactoryProductRepository
    {
        public IProductRepository CreateRepository()
        {
            return DbEngineSettings.Engine.ToLower().Trim() switch
            {
                "mongo" => new MongoProductRepository(),
                "sqlserver" => new SqlServerProductRepository(),
                "memory" => new MemoryProductRepository(),
                _ => throw new ArgumentNullException("La configuracion del motor de base de datos no es valida")
            };
        }
    }
}
