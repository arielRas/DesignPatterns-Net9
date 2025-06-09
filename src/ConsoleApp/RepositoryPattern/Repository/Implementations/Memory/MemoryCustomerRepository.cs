using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.Memory
{
    public class MemoryCustomerRepository : MemoryRepository<Customer>, ICustomerRepository
    {
        public MemoryCustomerRepository()
        {
            CreateStaticData();    
        }

        public Customer GetByEmail(string email)
            => entities.SingleOrDefault(x => x.Email == email)
               ?? throw new Exception($"El cliente con el email {email} no existe");

        private void CreateStaticData()
        {
            entities.AddRange(
                new List<Customer>
                {
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestCustomer01",
                        Email = "TestCustomer01@test.com"
                    },
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestCustomer02",
                        Email = "TestCustomer02@test.com"
                    },
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestCustomer03",
                        Email = "TestCustomer03@test.com"
                    },
                }                    
            );
        }
    }
}
/*
    Clase Repositorio concreta, solo necesita implementar los metodos propios de la interfaz
    ICustomerRepository, ya que los metodos de IRepository<T> han sido resueltos en la clase
    abstracta.
 */