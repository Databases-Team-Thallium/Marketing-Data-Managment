namespace MarketingDataManagment.Databases.MongoDB.Data
{
    using global::MongoDB.Driver;

    using Models;

    public interface IProductsCatalogDbContext
    {
        IMongoCollection<Product> Products { get; set; }

        IMongoCollection<T> Set<T>(string name) where T : class;
    }
}
