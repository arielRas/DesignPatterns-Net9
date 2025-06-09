using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Entities
{
    public class Product : IBaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
//Entidad para ejemplo, implementa IBaseEntity y cumple el contrato de tener una propiedad Id.