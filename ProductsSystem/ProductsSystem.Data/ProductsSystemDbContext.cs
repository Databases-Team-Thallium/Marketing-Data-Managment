namespace ProductsSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ProductsSystem.Models;
    using ProductsSystem.Data.Migrations;

    public class ProductsSystemDbContext : DbContext
    {
        public ProductsSystemDbContext() 
            : base("name=ProductsSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsSystemDbContext, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Store> Stores { get; set; }

        public IDbSet<Sale> Sales { get; set; }
    }
}
