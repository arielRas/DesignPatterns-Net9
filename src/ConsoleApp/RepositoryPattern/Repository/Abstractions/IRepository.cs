namespace ConsoleApp.RepositoryPattern.Repository.Abstractions
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
/*
    Interfaz generica que define los contratos para todos los repositorios que la implementen, tiene la
    restriccion de que <T> sea de tipo IBaseEntity, de esta manera se asegura porder trabajar con un 
    identificador unico de nombre Id
 */