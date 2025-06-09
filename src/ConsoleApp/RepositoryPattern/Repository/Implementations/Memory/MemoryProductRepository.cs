using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.Memory
{
    public class MemoryProductRepository : MemoryRepository<Product>, IProductRepository
    {
        public MemoryProductRepository()
        {
            CreateStaticData();    
        }

        public Product GetByName(string name)
            => entities.SingleOrDefault(x => x.Name == name)
               ?? throw new Exception($"El producto con el nombre {name} no existe");

        private void CreateStaticData()
        {
            entities.AddRange(
                new List<Product>
                {
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestProduct01",
                        Price = 200m
                    },
                    new Product 
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestProduct02",
                        Price = 500
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestProduct03",
                        Price = 1000
                    },
                }
            );
        }
    }
}
/*
    Clase Repositorio concreta, solo necesita implementar los metodos propios de la interfaz
    IProductRepository, ya que los metodos de IRepository<T> han sido resueltos en la clase
    abstracta.
 */
