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

            var sales = this.salesRepository.All().Select(s => new {
                SaleId = s.SaleId.ToString(),
                QuantitySold = s.QuantitySold.ToString(),
                TotalIncome = (s.Product.Price * s.QuantitySold).ToString()
            });

            foreach (var sale in sales)
            {
                FileStream fileStream = new FileStream(directoryPath + @"\" + sale.SaleId + ".json", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fileStream);

                var serializedData = new JavaScriptSerializer().Serialize(
                    new Dictionary<string, string>()
                    {
                            { "sale-id", sale.SaleId },
                            { "total-quantity-sold", sale.QuantitySold },
                            { "total-incomes", sale.TotalIncome }
                    });

                writer.WriteLine(serializedData);
                writer.Close();
            }
        }

    }
}
