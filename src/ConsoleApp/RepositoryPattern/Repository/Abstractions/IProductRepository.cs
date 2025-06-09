using ConsoleApp.RepositoryPattern.Entities;

namespace ConsoleApp.RepositoryPattern.Repository.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        
    }
}
/*
    Interfaz que define el contrato para los ProductRepository independientemente del
    motor de persistencia que utilicen.
    A su vez esta interfaz implementa IRepository, la cual obliga a todas clases concretas
    que implementen ProductRepository a cumplir el contrato de IRepository.
    Tambien se define el tipo <T> de IRepository, en este caso Product. De esta manera aquel 
    repositorio que implemente esta clase solo manejara el tipo <T> definido aqui.
 */
