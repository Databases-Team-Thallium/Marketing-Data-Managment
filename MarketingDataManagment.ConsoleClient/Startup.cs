namespace MarketingDataManagment.ConsoleClient
{
    using System.Data.Entity;

    using Databases.MSSQL.Data;
    using Databases.MSSQL.Data.Migrations;
    using Databases.MSSQL.Models;
    using XmlHandler;

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

            //puts revenues in Revenues table in the database
            //since no such store exists in the database, a default value of 0 is set

            //var xmlParser = new XmlHandler(new XmlRevenueStrategy(), "../../../revenues.xml");
            //xmlParser.Handle();
        }
    }
}
