using ConsoleApp.RepositoryPattern.Repository.Abstractions;
using ConsoleApp.RepositoryPattern.Repository.Enums;
using ConsoleApp.RepositoryPattern.Repository.Helpers;
using ConsoleApp.RepositoryPattern.Settings;
using MongoDB.Driver;

namespace ConsoleApp.RepositoryPattern.Repository.Implementations.Mongo
{
    public abstract class MongoRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        protected readonly FilterDefinitionBuilder<T> _filterBuilder;

        protected MongoRepository(MongoCollections collection)
        {
            MongoDbHelpers.RegisterSerializers();

            var databaseName = MongoSettings.Database.Trim()
                ?? throw new ArgumentNullException("El nombre de la base de datos MongoDb no esta configurado");

            var database = MongoDbHelpers.GetMongoClient().GetDatabase(databaseName);

            _collection = database.GetCollection<T>(collection.ToString());

            _filterBuilder = Builders<T>.Filter;
        }

        public T GetById(Guid id)
        {
            var filter = _filterBuilder.Eq(c => c.Id, id);

            return _collection.Find(filter).FirstOrDefault()
                ?? throw new KeyNotFoundException($"La entidad con id: {id} no existe");
        }

        public IEnumerable<T> GetAll()
        {
            return _collection.Find(_filterBuilder.Empty).ToList();
        }

        public void Create(T entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(T entity)
        {
            var filter = _filterBuilder.Eq(c => c.Id, entity.Id);

            var result = _collection.FindOneAndReplace(filter, entity)
                ?? throw new KeyNotFoundException($"La entidad con id: {entity.Id} no existe");
        }

        public void Delete(Guid id)
        {
            var filter = _filterBuilder.Eq(c => c.Id, id);

            var result = _collection.FindOneAndDelete(filter)
                ?? throw new KeyNotFoundException($"La entidad con id: {id} no existe");
        }

        public bool Exists(Guid id)
        {
            var filter = _filterBuilder.Eq(c => c.Id, id);

            return _collection.Find(filter).Any();
        }
    }
}
