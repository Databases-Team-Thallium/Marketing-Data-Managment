namespace MarketingDataManagment.Databases.MongoDB.Data
{
    using Models;

    public interface IProductsCatalogData
    {
        IGenericRepository<CatalogProduct> Products { get; }
    }
}
