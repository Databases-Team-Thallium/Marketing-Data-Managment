namespace MarketingDataManagment.ConsoleClient
{
    
    using Databases.MSSQL.Data;
    using Databases.MongoDB.Data;
    using System.Linq;
    using System.Linq.Expressions;

    public class Startup
    {
        //TODO: Add ability to Dispose databases data ?
        //TODO: Where you check if record exists, instead of .All() implement Find()
        //TODO: In IDataWriters and IDataReaders check for file extension, if its invalid replace it with valid

        public static void Main()
        {
            var mongoDb = new ProductsCatalogData();
            var mssqlDb = new StoresData();

            var all = mongoDb.Products.All();

            foreach(var item in all)
            {
                System.Console.WriteLine(item.Id);
                mongoDb.Products.Delete(item);
            }
        }
    }
}
