namespace MarketingDataManagment.Databases.MongoDB.Data
{
    using System;
    using System.Configuration;

    using global::MongoDB.Driver;

    using Models;

    public class ProductsCatalogDbContext : IProductsCatalogDbContext
    {
        private IMongoDatabase db;

        public ProductsCatalogDbContext()
        {
            var connectionStirng = ConfigurationManager.ConnectionStrings["MarketingDataManagmentMongoDBConnection"].ConnectionString;

            var mongoClient = new MongoClient(connectionStirng);
            var dbName = connectionStirng.Substring(connectionStirng.LastIndexOf('/') + 1, connectionStirng.Length - (connectionStirng.LastIndexOf('/') + 1));
            this.db = mongoClient.GetDatabase(dbName);
        }

        public IMongoCollection<Product> Products { get; set; }

        public IMongoCollection<T> Set<T>(string name) where T : class
        {
            return this.db.GetCollection<T>(name);
        }
    }
}
