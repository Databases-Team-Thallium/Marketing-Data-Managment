namespace MarketingDataManagment.Databases.MSSQL.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<MarketingDataManagmentDbContenxt>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MarketingDataManagmentDbContenxt.MSSQL.Data.MarketingDataManagmentDbContenxt";
        }

        protected override void Seed(MarketingDataManagmentDbContenxt context)
        {
        }
    }
}
