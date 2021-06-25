using EindopdrachtDatabases2.DatabaseConnections.DatabaseEntities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtDatabases2.DatabaseConnections
{
    class Mongo : IDBConn
    {
        private MongoClient conn;
        private IMongoDatabase database;
        private bool connected = false;

        public Mongo()
        {
            this.conn = new MongoClient(ConfigurationManager.ConnectionStrings["MongoConn"].ConnectionString);
        }

        public void Connect()
        {
            conn.StartSession();
            database = conn.GetDatabase("netflix");
            var collections = database.ListCollectionNames().ToList();

            if (!collections.Contains("Aflevering"))
                database.CreateCollection("Aflevering");
            if (!collections.Contains("Genre"))
                database.CreateCollection("Genre");
            if (!collections.Contains("Aflevering_Genre"))
                database.CreateCollection("Aflevering_Genre");

            var version = database.RunCommand(new BsonDocumentCommand<BsonDocument>(new BsonDocument() { { "buildInfo", 1 } }))["version"];
            connected = true;
            Console.WriteLine($"Connected to a MongoDB Server\n - MongoDB Server version: {version}");
        }

        public void Insert(int amount)
        {
            var afleveringCollection = database.GetCollection<MongoAflevering>("Aflevering");
            var genreCollection = database.GetCollection<MongoGenre>("Genre");
            var aflevering_genreCollection = database.GetCollection<MongoAlevering_Genre>("Aflevering_Genre");
            List<MongoAflevering> afleveringen = new List<MongoAflevering>();
            List<MongoGenre> genres = new List<MongoGenre>();
            List<MongoAlevering_Genre> aflevering_genres = new List<MongoAlevering_Genre>();

            for (int index = 1; index <= amount; index++)
            {
                var aflevering = new MongoAflevering()
                {
                    ID = index,
                    lengte = 27
                };
                afleveringen.Add(aflevering);

                var genre = new MongoGenre()
                {
                    ID = index,
                    genre = "Spooky"
                };
                genres.Add(genre);

                var aflevering_genre = new MongoAlevering_Genre()
                {
                    ID = index,
                    afleveringID = index,
                    genreID = index
                };
                aflevering_genres.Add(aflevering_genre);
            }

            afleveringCollection.InsertMany(afleveringen);
            genreCollection.InsertMany(genres);
            aflevering_genreCollection.InsertMany(aflevering_genres);
        }

        public void Select(int amount)
        {
            var collection = database.GetCollection<MongoAflevering>("Aflevering_Genre");
            collection.Find<MongoAflevering>(x => x.ID < amount);
        }

        public void Update(int amount)
        {
            var afleveringCollection = database.GetCollection<MongoAflevering>("Aflevering");
            afleveringCollection.UpdateMany(x => x.ID < amount, "{ $set: { \"lengte\": 24 }}");
        }

        public void Delete(int amount)
        {
            var afleveringCollection = database.GetCollection<MongoAflevering>("Aflevering");
            var genreCollection = database.GetCollection<MongoGenre>("Genre");
            var aflevering_genreCollection = database.GetCollection<MongoAlevering_Genre>("Aflevering_Genre");

            afleveringCollection.DeleteMany(x => x.ID < amount);
            genreCollection.DeleteMany(x => x.ID < amount);
            aflevering_genreCollection.DeleteMany(x => x.ID < amount);
        }

        public string GetName() => $"MongoDB";

        public bool IsConnected() => connected;
    }
}
