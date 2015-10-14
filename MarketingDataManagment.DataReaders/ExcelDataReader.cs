namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;

    using Excel;

    using Databases;
    using StringsUtilities;

    public class ExcelDataReader : IDataReader
    {
        private readonly IDatabase database;

        public ExcelDataReader(IDatabase database)
        {
            this.database = database;
        }

        public void ReadData(Stream stream, long streamLength, DateTime streamDate)
        {
            var entryContent = new byte[streamLength];
            stream.Read(entryContent, 0, (int)streamLength);
            var entryMemoryStream = new MemoryStream(entryContent);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(entryMemoryStream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            int rowIndex = 0;
            var tableData = new TableData();

            while (excelReader.Read())
            {
                if (result.Tables[0].Rows[rowIndex].IsNull(0) == true) { break; }

                if (rowIndex == 0)
                {
                    for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    {
                        string columnName = result.Tables[0].Columns[i].ColumnName;
                        string formattedColumnName = TextFormatter.FormatColumnName(columnName);
                        tableData.AddColumnName(formattedColumnName);
                    }
                }
                else
                {
                    for (int i = 0; i < tableData.ColumnsCount; i++)
                    {
                        string formattedColumnName = tableData.GetColumnName(i);
                        object data = result.Tables[0].Rows[rowIndex].ItemArray[i].ToString();
                        tableData.AddData(i, data);
                    }
                }

                rowIndex++;
            }
        }
    }
}
