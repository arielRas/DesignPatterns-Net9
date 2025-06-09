using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Settings;
using Microsoft.Data.SqlClient;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.SqlServerAdoNet
{
    public class SqlServerProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public SqlServerProductRepository()
        {
            _connectionString = SqlServerSettings.ConnectionString;
        }

        public Product GetById(Guid id)
        {
            var sqlQuery = "SELECT * FROM Products WHERE Id = @id";

            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                            };
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Id: {id} no existente");
                        }

                    }
                }
            }
        }


        public IEnumerable<Product> GetAll()
        {
            var sqlQuery = "SELECT * FROM Products";
            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var products = new List<Product>();

                        while (reader.Read())
                        {
                            products.Add(
                                new Product
                                {
                                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                                }
                            );
                        }

                        return products;
                    }
                }
            }
        }

        public void Create(Product entity)
        {
            var sqlQuery = "INSERT INTO Products VALUES (@id, @name, @price)";

            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@price", entity.Price);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Product entity)
        {
            var sqlQuery = "UPDATE Products SET [Name] = @name, Price = @price WHERE Id = @id";
            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@price", entity.Price);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            var sqlQuery = "DELETE Products WHERE Id = @id";
            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Exists(Guid id)
        {
            var sqlQuery = "SELECT 1 FROM Products WHERE Id = @id";
            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    var result = command.ExecuteScalar();

                    return result != DBNull.Value;
                }
            }
        }
    }
}
/*
    Clase Repositorio concreta, a diferencia del motor "memory" todos los metodos de las interfaces 
    se implementan aqui, ya que con la tecnologia ADO.NET no contamos con tanta versaltilidad como
    con LINQ, esto nos lleva a no poder definir una clase abstracta generica que implemente los
    metodos de IRepository.
 */