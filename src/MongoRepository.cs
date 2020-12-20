using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Minify.Interfaces;
using Minify.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Minify{
    public class MongoRepository : IRepository
    {
        private IMongoDatabase database;
        private TokenGenerator tokengenerator = new TokenGenerator();
        public MongoRepository(){
            var client = new MongoClient(
                                "mongodb+srv://EpsiEleve:TvxreYSXYCg89lz1@cluster0-b8srw.azure.mongodb.net/test?retryWrites=true&w=majority"
                            );
            database = client.GetDatabase("Epsi");
        }
        
        public void Add(MinifyData minifyData)
        {
            minifyData._id= tokengenerator.Generate();
            database.GetCollection<MinifyData>("Tom").InsertOne(minifyData);
        }

        public void Delete(string key)
        {
            database.GetCollection<MinifyData>("Tom").DeleteOne(a => a._id==key);
        }

        public IEnumerable<MinifyData> Get()
        {
            var collection = database.GetCollection<MinifyData>("Tom");

            return collection.Find(new BsonDocument()).ToList();
        }

        public async Task<MinifyData> Get(string key)
        {
            var collection = database.GetCollection<MinifyData>("Tom");
            var filter = Builders<MinifyData>.Filter.Eq("_id", key);

            return await collection.Find(filter).FirstAsync();
        }
    }
}