namespace MarketingDataManagment.Databases.MSSQL.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using Migrations;

    public class StoresDbContext : DbContext, IStoresDbContext
    {
        public StoresDbContext()
        : base("name=MarketingDataManagmentMSSQLConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoresDbContext, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Store> Stores { get; set; }

        public IDbSet<Revenue> Revenues { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}