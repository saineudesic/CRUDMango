using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Util.Internal.PlatformServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
 using ModelClass;

namespace DataContextLayer
{
    public class MongoDbDataContext
    {
        private string _connectionStrings = string.Empty;
        private string _databaseName = string.Empty;
        private string _collectionName = string.Empty;


        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoDbDataContext(string strCollectionName, IOptions<MongoDbSettings> conection)
        {
            this._collectionName = strCollectionName;
            //this._connectionStrings = conection.Value.ServerName;
            this._databaseName = conection.Value.DatabaseName;
            this._client = new MongoClient(_connectionStrings);
            this._database = _client.GetDatabase(_databaseName);
        }
        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoDatabase Database
        {
            get { return _database; }
        }

        public IMongoCollection<Product> GetProducts
        {
            get { return _database.GetCollection<Product>(_collectionName); }
        }
    }
}
