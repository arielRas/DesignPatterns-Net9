using ConsoleApp.RepositoryPattern.Entities;

namespace ConsoleApp.RepositoryPattern.Repository.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
/*
    Interfaz que define el contrato para los CustomerRepository independientemente del
    motor de persistencia que utilicen.
    A su vez esta interfaz implementa IRepository, la cual obliga a todas clases concretas
    que implementen CustomerRepository a cumplir el contrato de IRepository.
    Tambien se define el tipo <T> de IRepository, en este caso Customer. De esta manera aquel 
    repositorio que implemente esta clase solo manejara el tipo <T> definido aqui.
 */