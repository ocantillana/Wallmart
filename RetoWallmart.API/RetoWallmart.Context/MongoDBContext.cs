using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RetoWallmart.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetoWallmart.Context
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _mongoDB;
        private static IConfiguration _configuration;
        private static IConfigurationSection _configSection;

        public MongoDBContext()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            _configSection = _configuration.GetSection("appSettings");

            MongoInternalIdentity internalIdentity =
                      new MongoInternalIdentity("admin", _configSection["mongoDBUserName"]);
            PasswordEvidence passwordEvidence = new PasswordEvidence(_configSection["mongoDBPassword"]);
            MongoCredential mongoCredential =
                 new MongoCredential(_configSection["mongoDbAuthMechanism"],
                         internalIdentity, passwordEvidence);
            List<MongoCredential> credentials =
                       new List<MongoCredential>() { mongoCredential };


            MongoClientSettings settings = new MongoClientSettings();
            settings.Credentials = credentials;
            MongoServerAddress address = new MongoServerAddress(
                _configSection["mongoDBHost"], 
                Convert.ToInt32(_configSection["mongoDBPort"])
            );
            settings.Server = address;

            var client = new MongoClient(settings);
            _mongoDB = client.GetDatabase(_configSection["bdNameMongoDB"]);
            
        }

        public IMongoCollection<Producto_Entity> Productos
        {
            get
            {
                return _mongoDB.GetCollection<Producto_Entity>(_configSection["collectionNameMongoDB"]);
            }
        }

    }
}
