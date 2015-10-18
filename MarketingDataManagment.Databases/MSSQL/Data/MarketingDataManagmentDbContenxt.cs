namespace MarketingDataManagment.Databases.MSSQL.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using Migrations;

    public class MarketingDataManagmentDbContenxt : DbContext
    {
        public MarketingDataManagmentDbContenxt()
        : base("name=MarketingDataManagmentConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MarketingDataManagmentDbContenxt, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Store> Stores { get; set; }

        public IDbSet<Sale> Sales { get; set; }
    }
}