namespace ProductsSystem.Client
{
    using Data;
    using Models;
    using System.Data.Entity;

    public class Startup
    {
        public static void Main()
        {
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
