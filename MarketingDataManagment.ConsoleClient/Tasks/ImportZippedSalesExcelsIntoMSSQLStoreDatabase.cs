namespace MarketingDataManagment.ConsoleClient.Tasks
{
    using System.Collections.Generic;

    using ZipParser;
    using DataReaders;
    using Databases.MSSQL.Data;
    using Databases.MSSQL.Models;

    public static class ImportZippedSalesExcelsIntoMSSQLStoreDatabase
    {
        public static string Execute()
        {
            var storesDb = new StoresData();

            var excelReader = new ExcelSalesReader(storesDb.Sales, storesDb.Products);

            var zipParser = new ZipParser("../../../Jan 2015 Report.zip", new List<string>() { ".xls" }, excelReader);

            zipParser.Parse(true);

            storesDb.SaveChanges();

            return "Excels imported";
        }
    }
}
