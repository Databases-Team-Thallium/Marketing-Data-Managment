namespace MarketingDataManagment.DataWriters
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Web.Script.Serialization;
    using Databases.MSSQL.Models;
    using Databases.MSSQL.Models.Reports;

    public class JsonWriters
    {
        private const string JsonReportFilePath = @"..\..\..\Exported-Files\Json";

        public static void CreateJsonFiles(List<SalesReport> saleStores)
        {
            if (!Directory.Exists(JsonReportFilePath))
            {
                Directory.CreateDirectory(JsonReportFilePath);
            }

            foreach (var productsSales in saleStores)
            {
                FileStream fs1 = new FileStream(JsonReportFilePath + @"\" + productsSales.Product.ProductId + ".json", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);

                writer.WriteLine(CreateJsonReport(productsSales));
                writer.Close();
            }

            Process.Start(JsonReportFilePath);
        }

        public static string CreateJsonReport(SalesReport salesReport)
        {
            return new JavaScriptSerializer().Serialize(
                    new Dictionary<string, string>()
                        {
                            { "product-id", salesReport.ProductId.ToString() },
                            { "product-code", salesReport.Product.Product.ProductCode},
                            { "store-name", salesReport.Product.Store.StoreName },
                            { "total-quantity-sold", salesReport.TotalQuantitySold.ToString() },
                            { "total-incomes", salesReport.TotalIncomes.ToString() }
                        });
        }
    }
}
