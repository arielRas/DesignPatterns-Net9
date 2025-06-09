using ConsoleApp.RepositoryPattern.Repository.Abstractions;

namespace ConsoleApp.RepositoryPattern.Entities
{
    public class Customer : IBaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
//Entidad para ejemplo, implementa IBaseEntity y cumple el contrato de tener una propiedad Id.