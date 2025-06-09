using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Factory.Abstractions
{
    public interface IFactoryRepository<TRepository, TEntity> 
        where TRepository : IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        TRepository CreateRepository();
    }
}
