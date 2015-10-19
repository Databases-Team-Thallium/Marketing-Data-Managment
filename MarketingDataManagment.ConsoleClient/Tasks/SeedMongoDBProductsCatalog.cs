namespace MarketingDataManagment.ConsoleClient.Tasks
{
    using System.Collections.Generic;

    using ZipParser;
    using DataReaders;
    using Databases.MongoDB.Data;

    public static class SeedMongoDBProductsCatalog
    {
        public static string Execute()
        {
            var db = new ProductsCatalogData();

            var excelReader = new ExcelCatalogProductsReader(db.Products);

            var zipParser = new ZipParser("../../../Jan 2015 Report.zip", new List<string>() { ".xls" }, excelReader);

            zipParser.Parse();

            return "Products added to MongoDB products catalog";
        }
    }
}
