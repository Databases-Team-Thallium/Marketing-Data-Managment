namespace MarketingDataManagment.Databases.MSSQL.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IStoresDbContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<Sale> Sales { get; set; }

        IDbSet<Store> Stores { get; set; }

        IDbSet<Revenue> Revenues { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
