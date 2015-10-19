namespace MarketingDataManagment.Databases.MSSQL.Data
{
    using Repositories;
    using Models;

    public interface IStoresData
    {
        IGenericRepository<StoreProduct> Products { get; }

        IGenericRepository<Sale> Sales { get; }

        void SaveChanges();
    }
}