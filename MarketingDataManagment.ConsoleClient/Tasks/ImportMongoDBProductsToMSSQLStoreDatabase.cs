namespace MarketingDataManagment.ConsoleClient.Tasks
{
    using System.Linq;

    using Databases.MongoDB.Models;
    using Databases.MongoDB.Data;
    using Databases.MSSQL.Models;
    using Databases.MSSQL.Data;

    public static class ImportMongoDBProductsToMSSQLStoreDatabase
    {
        public static string Execute()
        {
            var productsCatalogDb = new ProductsCatalogData();
            var storeDb = new StoresData();

            var productsCatalogEntries = productsCatalogDb.Products.All();

            int countOfAddedProducts = 0;
            foreach (var catalogProduct in productsCatalogEntries)
            {
                storeDb.Products.Add(new StoreProduct()
                {
                    Price = catalogProduct.Price,
                    ProductCode = catalogProduct.ProductCode,
                    Quantity = catalogProduct.Quantity,
                    Status = catalogProduct.Status
                });

                countOfAddedProducts++;
            }

            storeDb.SaveChanges();

            return countOfAddedProducts + " products added to the store database";
        }
    }
}
