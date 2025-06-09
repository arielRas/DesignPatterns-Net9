using ConsoleApp.RepositoryPattern.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace ConsoleApp.RepositoryPattern.Repository.Helpers
{
    internal static class MongoDbHelpers
    {
        private static bool _registeredSerializer = false;
        private static MongoClient? _client;

        public static void RegisterSerializers()
        {
            if (_registeredSerializer) return;

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            _registeredSerializer = true;
        }

        public static MongoClient GetMongoClient()
        {
            if (_client == null)
            {
                var connectionString = MongoSettings.ConnectionString.Trim();

                _client = new MongoClient(connectionString);
            }

            return _client;
        }
    }
}
