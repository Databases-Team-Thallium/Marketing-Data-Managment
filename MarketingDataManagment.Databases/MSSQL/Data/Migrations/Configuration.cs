namespace MarketingDataManagment.Databases.MSSQL.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<StoresDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MarketingDataManagmentDbContenxt.MSSQL.Data.StoresData";
        }

        protected override void Seed(StoresDbContext context)
        {
        }
    }
}
