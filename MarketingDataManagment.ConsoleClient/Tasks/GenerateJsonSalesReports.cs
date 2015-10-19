namespace MarketingDataManagment.ConsoleClient.Tasks
{
    using System.IO;

    using DataWriters;
    using Databases.MSSQL.Data;
   
    public static class GenerateJsonSalesReports
    {
        public static string Execute()
        {
            var db = new StoresData();

            var jsonWriter = new JsonSalesReportWriter(db.Sales, db.Products);

            string reportDirectory = Directory.GetCurrentDirectory() + "\\Sales Reports";
            jsonWriter.WriteData(reportDirectory);

            return "Json reports generated at location:\r\n" + reportDirectory;
        }
    }
}
