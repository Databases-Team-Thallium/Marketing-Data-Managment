namespace MarketingDataManagment.DataWriters.PdfWriters
{
    using System.IO;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using DataTypes;

    public class PdfTableWriter: IDataWriter
    {
        private readonly Document document;
        private readonly PdfWriter writer;

        public PdfTableWriter(string destinationFullPathName)
        {
            this.document = new Document();

            var documentFileStream = new FileStream(destinationFullPathName, FileMode.Create);
            this.writer = PdfWriter.GetInstance(this.document, documentFileStream);

            this.document.Open();
        }

        public void WriteData(TableData tableData)
        {
            var table = new PdfPTable(tableData.ColumnsCount);

            for(int i = 0; i < tableData.ColumnsCount; i++)
            {
                table.AddCell(tableData.GetColumnName(i));
            }

            for(int i = 0; i < tableData.RowsCount; i++)
            {
                for(int j = 0; j < tableData.ColumnsCount; j++)
                {
                    table.AddCell(tableData.GetData(j, i).ToString());
                }
            }

            this.document.Close();
            this.writer.Close();
        }
    }
}
