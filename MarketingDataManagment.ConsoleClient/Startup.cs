namespace MarketingDataManagment.ConsoleClient
{
    using System.Data.Entity;

    using Databases.MSSQL.Data;
    using Databases.MSSQL.Data.Migrations;
    using Databases.MSSQL.Models;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MarketingDataManagmentDbContenxt, Configuration>());

            var db = new MarketingDataManagmentDbContenxt();

            db.Stores.Add(new Store
            {
                StoreName = "Physical Store",
                StoreLocation = "Sofia"

            });
            db.SaveChanges();

        }
    }
}
