using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;


namespace MongoDBConsoleApp {
    class MongoDBClass {

        /// <summary>
        /// 
        /// </summary>
        private readonly MongoClient _client;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMongoCollection< BsonDocument > _collection;


        public MongoDBClass() {
            //string         connectionString = "mongodb://localhost:27017";
            //MongoClient    client           = new MongoClient(connectionString);
            //IMongoDatabase database         = client.GetDatabase("test");

            var connectionString = ConfigurationManager.ConnectionStrings [ "MongoDb" ].ConnectionString;
            _client     = new MongoClient( connectionString );
            _database   = _client.GetDatabase( "sample_training" );
            _collection = _database.GetCollection< BsonDocument >( "grades" );
        }

        /// <summary>
        /// Получить список баз данных сервера
        /// </summary>
        /// <returns></returns>
        public List< BsonDocument > GetDatabasesList() => _client.ListDatabases().ToList();

        /// <summary>
        /// Получить список баз данных сервера
        /// </summary>
        /// <returns></returns>
        public List< BsonDocument > GetCollectionsList( string name ) =>
            _client.GetDatabase( name ).ListCollections().ToList();


        public void Create() {
            var document = new BsonDocument {
                                                { "student_id", 10000 }, {
                                                    "scores",
                                                    new BsonArray {
                                                                      new BsonDocument {
                                                                                           { "type", "exam" }, {
                                                                                               "score",
                                                                                               88.12334193287023
                                                                                           }
                                                                                       },
                                                                      new BsonDocument {
                                                                                           { "type", "quiz" }, {
                                                                                               "score",
                                                                                               74.92381029342834
                                                                                           }
                                                                                       },
                                                                      new BsonDocument {
                                                                                           { "type", "homework" }, {
                                                                                               "score",
                                                                                               89.97929384290324
                                                                                           }
                                                                                       },
                                                                      new BsonDocument {
                                                                                           { "type", "homework" }, {
                                                                                               "score",
                                                                                               82.12931030513218
                                                                                           }
                                                                                       }
                                                                  }
                                                },
                                                { "class_id", 480 }
                                            };
            _collection.InsertOne( document );
        }

        public List<BsonDocument> ReadAll() => _collection.Find( new BsonDocument() ).ToList();

        public BsonDocument Read() => _collection.Find( new BsonDocument() ).FirstOrDefault();

    }
}
