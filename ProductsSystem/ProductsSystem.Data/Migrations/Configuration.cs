namespace ProductsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ProductsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProductsSystem.Data.ProductsSystemDbContext";
        }

        protected override void Seed(ProductsSystemDbContext context)
        {
        }
    }
}
