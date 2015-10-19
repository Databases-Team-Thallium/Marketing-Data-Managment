namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;

    using Excel;

    using Databases;
    using Databases.MSSQL.Models;

    public class ExcelSalesReader : IStreamDataReader
    {
        private IGenericRepository<Sale> salesRepository;
        IGenericRepository<StoreProduct> productsRepository;

        public ExcelSalesReader(IGenericRepository<Sale> salesRepository, IGenericRepository<StoreProduct> productsRepository)
        {
            this.salesRepository = salesRepository;
            this.productsRepository = productsRepository;
        }

        public void ReadData(Stream stream, long streamLength, DateTime streamDate)
        {
            var streamContent = new byte[streamLength];
            stream.Read(streamContent, 0, (int)streamLength);
            var memoryStream = new MemoryStream(streamContent);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(memoryStream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet dataSet = excelReader.AsDataSet();

            int rowIndex = 0;

            while (excelReader.Read())
            {
                if (dataSet.Tables[0].Rows[rowIndex].IsNull(0) == true) { break; }

                if(rowIndex > 0)
                {
                    string productCode = dataSet.Tables[0].Rows[rowIndex].ItemArray[0].ToString();
                    StoreProduct product = this.productsRepository.All().Where(p => p.ProductCode == productCode).FirstOrDefault();
                    int quantitySold = int.Parse(dataSet.Tables[0].Rows[rowIndex].ItemArray[1].ToString());
                    
                    this.salesRepository.Add(new Sale()
                    {
                        QuantitySold = quantitySold,
                        StoreProductId = product.StoreProductId,
                        SaleDate = streamDate
                    });
                }

                rowIndex++;
            }

            excelReader.Dispose();
            memoryStream.Dispose();
        }
    }
}
