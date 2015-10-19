namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;

    using Excel;

    using Databases;
    using Databases.MongoDB.Models;

    public class ExcelCatalogProductsReader : IStreamDataReader
    {
        IGenericRepository<CatalogProduct> productsRepository;

        public ExcelCatalogProductsReader(IGenericRepository<CatalogProduct> productsRepository)
        {
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

                if (rowIndex > 0)
                {
                    string productCode = dataSet.Tables[0].Rows[rowIndex].ItemArray[0].ToString();
                    int quantity = int.Parse(dataSet.Tables[0].Rows[rowIndex].ItemArray[1].ToString()) * 2;
                    decimal productPrice = decimal.Parse(dataSet.Tables[0].Rows[rowIndex].ItemArray[2].ToString());

                    this.productsRepository.Add(new CatalogProduct()
                    {
                        ProductCode = productCode,
                        Price = productPrice,
                        Quantity = quantity,
                        Status = "Ordinary"
                    });
                }

                rowIndex++;
            }

            excelReader.Dispose();
            memoryStream.Dispose();
        }
    }
}
