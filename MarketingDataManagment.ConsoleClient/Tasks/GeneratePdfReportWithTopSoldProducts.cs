namespace MarketingDataManagment.ConsoleClient.Tasks
{
    using System.IO;

    using DataWriters;
    using Databases.MSSQL.Data;

    public static class GeneratePdfReportWithTopSoldProducts
    {
        public static string Execute()
        {
            var storeDb = new StoresData();

            var pdfWriter = new PdfTopSoldProductsTableWriter(storeDb.Sales);

            string reportDirectory = Directory.GetCurrentDirectory();
            pdfWriter.WriteData(reportDirectory); 

            return "PDF report written at follow location:\r\n" + reportDirectory;
        }
    }
}
