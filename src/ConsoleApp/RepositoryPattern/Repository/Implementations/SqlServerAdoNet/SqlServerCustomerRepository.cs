using ConsoleApp.RepositoryPattern.Entities;
using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Settings;
using Microsoft.Data.SqlClient;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.SqlServerAdoNet
{
    public class SqlServerCustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public SqlServerCustomerRepository()
        {
            _connectionString = SqlServerSettings.ConnectionString;
        }

        public Customer GetById(Guid id)
        {
            var sqlQuery = "SELECT * FROM Customers WHERE Id = @id";

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
                            return new Customer
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
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

        public Customer GetByEmail(string email)
        {
            var sqlQuery = "SELECT * FROM Customers WHERE Email = @email";

            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                        }
                        else
                        {
                            throw new KeyNotFoundException($"Email: {email} no existente");
                        }

                    }
                }
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var sqlQuery = "SELECT * FROM Customers";
            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var products = new List<Customer>();

                        while (reader.Read())
                        {
                            products.Add(
                                new Customer
                                {
                                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email"))
                                }
                            );
                        }

                        return products;
                    }
                }
            }
        }

        public void Create(Customer entity)
        {
            var sqlQuery = "INSERT INTO Customers VALUES (@id, @name, @email)";

            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@email", entity.Email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Customer entity)
        {
            var sqlQuery = "UPDATE Customers SET [Name] = @name, Email = @email WHERE Id = @id";
            var connection = new SqlConnection(_connectionString);

            using (connection)
            {
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@email", entity.Email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Guid id)
        {
            var sqlQuery = "DELETE Customers WHERE Id = @id";

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
            var sqlQuery = "SELECT 1 FROM Customers WHERE Id = @id";

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