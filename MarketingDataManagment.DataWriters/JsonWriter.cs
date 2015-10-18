namespace MarketingDataManagment.DataWriters
{
    using Databases.MSSQL.Reports;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Web.Script.Serialization;

    public class JsonWriters
    {
        private const string JsonReportFilePath = @"..\..\..\Exported-Files\Json";

        public static void CreateJsonFiles(List<SalesReport> saleStores)
        {
            if (!Directory.Exists(JsonReportFilePath))
            {
                Directory.CreateDirectory(JsonReportFilePath);
            }

            foreach (var productSales in saleStores)
            {
                FileStream fs1 = new FileStream(JsonReportFilePath + @"\" + productSales.Sale.SaleId + ".json", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);

                writer.WriteLine(CreateJsonReport(productSales));
                writer.Close();
            }

            Process.Start(JsonReportFilePath);
        }

        public static string CreateJsonReport(SalesReport salesReport)
        {
            return new JavaScriptSerializer().Serialize(
                    new Dictionary<string, string>()
                        {
                            { "sale-id", salesReport.SaleId.ToString() },
                            { "sale-name", salesReport.Sale.SaleName},
                            { "store-name", salesReport.Store.StoreName },
                            { "total-quantity-sold", salesReport.TotalQuantitySold.ToString() },
                            { "total-incomes", salesReport.TotalIncomes.ToString() }
                        });
        }
    }
}
