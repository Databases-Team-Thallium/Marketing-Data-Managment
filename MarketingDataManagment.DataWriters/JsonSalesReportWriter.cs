namespace MarketingDataManagment.DataWriters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;

    using Databases;
    using Databases.MSSQL.Models;


    public class JsonSalesReportWriter : IReportFilesDataWriter
    {
        private IGenericRepository<Sale> salesRepository;
        private IGenericRepository<StoreProduct> productsRepository;

        public JsonSalesReportWriter(IGenericRepository<Sale> salesRepository, IGenericRepository<StoreProduct> productsRepository)
        {
            this.salesRepository = salesRepository;
            this.productsRepository = productsRepository;
        }

        public void WriteData(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var sales = this.salesRepository.All();

            foreach (var sale in sales)
            {
                FileStream fileStream = new FileStream(directoryPath + @"\" + sale.SaleId + ".json", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fileStream);

                writer.WriteLine(CreateJsonReport(sale));
                writer.Close();
            }
        }

        public string CreateJsonReport(Sale sale)
        {
            decimal totalIncome = sale.Product.Price * sale.QuantitySold;
            return new JavaScriptSerializer().Serialize(
                    new Dictionary<string, string>()
                        {
                            { "sale-id", sale.SaleId.ToString() },
                            { "total-quantity-sold", sale.QuantitySold.ToString() },
                            { "total-incomes", totalIncome.ToString() }
                        });
        }
    }
}
