using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;


namespace MongoDBConsoleApp {
    class Program {
        static void Main( string [] args ) {

            // ReSharper disable once InconsistentNaming
            var mongoDB = new MongoDBClass();


            Console.WriteLine( "The list of databases on this server is: " );
            foreach ( var db in mongoDB.GetDatabasesList() ) {
                Console.WriteLine( db [ "name" ] );
                foreach ( var dbCol in mongoDB.GetCollectionsList( db [ "name" ].ToString() ) ) {
                    Console.WriteLine( "    " + dbCol [ "name" ] );
                }
            }

            mongoDB.Create();
            var list = mongoDB.ReadAll();
            foreach ( var item in list ) {
                Console.WriteLine( item.ToString() );
            }
            




            ////string         connectionString = "mongodb://localhost:27017";
            ////MongoClient    client           = new MongoClient(connectionString);
            ////IMongoDatabase database         = client.GetDatabase("test");

            //string con    = ConfigurationManager.ConnectionStrings [ "MongoDb" ].ConnectionString;
            //var    client = new MongoClient( con );
            //// GetDatabaseNames( client ).GetAwaiter();
            //// GetCollectionsNames( client ).GetAwaiter();

            //// Список баз данных
            //var dbList = client.ListDatabases().ToList();
            //Console.WriteLine( "The list of databases on this server is: " );
            //foreach ( var db in dbList ) {
            //    Console.WriteLine( db [ "name" ] );
            //}



            //GetDatabaseNames( client );



            //IMongoDatabase                   database = client.GetDatabase( "test" );
            //IMongoCollection< BsonDocument > col      = database.GetCollection< BsonDocument >( "users" );

            //// Создание документа
            //BsonDocument doc = new BsonDocument { { "name", "Bill" } };
            //Console.WriteLine( doc );
            //Console.WriteLine( doc [ "name" ] );
            //// изменим поле name
            //doc [ "name" ] = "Tom";

            //Console.WriteLine( doc.GetValue( "name" ) );

            Console.ReadLine();
        }

        //    private static async Task GetDatabaseNamesAsync( MongoClient client ) {
        //        using( var cursor = await client.ListDatabasesAsync() ) {
        //            var databaseDocuments = await cursor.ToListAsync();
        //            foreach( var databaseDocument in databaseDocuments ) {
        //                Console.WriteLine( databaseDocument["name"] );
        //            }
        //        }
        //    }

        //    private static List< string > GetDatabaseNames( IMongoClient client ) {
        //        var list = new List< string >();
        //        using ( var cursor = client.ListDatabases() ) {
        //            var databaseDocuments = cursor.ToList();
        //            foreach ( var databaseDocument in databaseDocuments ) {
        //                list.Add( databaseDocument [ "name" ].ToString() );
        //            }
        //        }
        //        return list;
        //    }


        //    private static async Task GetCollectionsNames( MongoClient client ) {
        //        using ( var cursor = await client.ListDatabasesAsync() ) {
        //            var dbs = await cursor.ToListAsync();
        //            foreach ( var db in dbs ) {
        //                Console.WriteLine( "В базе данных {0} имеются следующие коллекции:", db [ "name" ] );

        //                IMongoDatabase database = client.GetDatabase( db [ "name" ].ToString() );

        //                using ( var collCursor = await database.ListCollectionsAsync() ) {
        //                    var colls = await collCursor.ToListAsync();
        //                    foreach ( var col in colls ) {
        //                        Console.WriteLine( col [ "name" ] );
        //                    }
        //                }
        //                Console.WriteLine();
        //            }

        //        }
        //    }

        //    /// <summary>
        //    /// Создание документа
        //    /// </summary>
        //    private static void Create() {
        //        BsonDocument doc = new BsonDocument { {"name","Bill"}};
        //        BsonElement bel = new BsonElement("name", "Ted");
        //        doc.Add( bel );
        //        doc.Add( "countries", new BsonArray( new[] { "Бразилия", "Аргентина", "Германия", "Нидерланды" } ) );
        //        doc.Add( "finished",  new BsonBoolean( true ) );
        //        BsonDocument doc1 = new BsonDocument {
        //                               {"name","Bill"},
        //                               {"surname", "Gates"},
        //                               {"age", new BsonInt32(48)},
        //                               { "company",
        //                                   new BsonDocument{
        //                                                       {"name" , "microsoft"},
        //                                                       {"year", new BsonInt32(1974)},
        //                                                       {"price", new BsonInt32(300000)},
        //                                                   }
        //                               }
        //                           };

        //    }
        //}
    }

}
