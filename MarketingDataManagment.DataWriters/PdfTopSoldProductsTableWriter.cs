namespace MarketingDataManagment.DataWriters
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using Databases;
    using Databases.MSSQL.Models;
    

    public class PdfTopSoldProductsTableWriter: IReportFilesDataWriter
    {
        private readonly IList<string> ColumnsNames = new List<string>() { "Product Code" , "Produce Price", "Quantity Sold" };
        private IGenericRepository<Sale> salesRepository;

        public PdfTopSoldProductsTableWriter(IGenericRepository<Sale> salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        public void WriteData(string directoryPath)
        {
            var document = new Document();

            var documentFileStream = new FileStream(directoryPath +  "\\top-ten-" + DateTime.Now + ".pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(document, documentFileStream);

            document.Open();

            var topTenSoldProducts = this.salesRepository.All().Take(10).Select(s => new
            {
                Code = s.Product.ProductCode,
                Price = s.Product.Price,
                QuantitySold = s.QuantitySold
            });

            var table = new PdfPTable(this.ColumnsNames.Count());

            for(int i = 0; i < this.ColumnsNames.Count(); i++)
            {
                table.AddCell(this.ColumnsNames[i]);
            }

            foreach(var product in topTenSoldProducts)
            {
                table.AddCell(product.Code);
                table.AddCell(product.Price.ToString());
                table.AddCell(product.QuantitySold.ToString());
            }

            document.Close();
            writer.Close();
        }
    }
}
