namespace ProductsSystem.Client
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ProductsSystemDbContext, Configuration>());

            var db = new ProductsSystemDbContext();

            db.Stores.Add(new Store
            {
                StoreName = "Physical Store",
                StoreLocation = "Sofia"
                
            });
            db.SaveChanges();

        }
    }
}
