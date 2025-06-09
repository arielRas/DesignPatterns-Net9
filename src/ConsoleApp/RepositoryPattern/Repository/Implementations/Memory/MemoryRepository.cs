using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.Memory
{
    public abstract class MemoryRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected static List<T> entities = new List<T>();

        public T GetById(Guid id)
            => entities.SingleOrDefault(x => x.Id == id)
               ?? throw new KeyNotFoundException("El id no existe");

        public IEnumerable<T> GetAll()
            => entities;

        public void Create(T entity)
            => entities.Add(entity);

        public void Update(T entity)
        {
            var existingEntity = entities.SingleOrDefault(x => x.Id == entity.Id)
                ?? throw new KeyNotFoundException("El id no existe");

            existingEntity = entity;
        }

        public void Delete(Guid id)
        {
            var existingEntity = entities.SingleOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException("El id no existe");

            entities.Remove(existingEntity);
        }

        public bool Exists(Guid id)
            => entities.Any(x => x.Id == id);
    }
}
/*
    Aprovechando la versatalidad de LINQ en el caso del repositorio basado en memmoria, se crea esta clase 
    abstracta que implemente IRepository<T> pero sin definir el tipo <T> en este momento.
    Se manejan las colecciones tipo T pudiendo implementar todos los metodos del contrato IRepository de 
    manera generica.
    El objetivo es que los repositorios concretos hereden de esta clase e implementen la interfaz propia
    segun que entidad manejen (IProductRepository, ICustomerRepository, etc.), de esta manera el 
    repositorio concreto solo tendra que definir los metodos propios de la interfaz que implemente, mas 
    no los del contrato IRepository.
*/

