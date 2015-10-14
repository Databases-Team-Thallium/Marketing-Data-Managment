namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;

    using Excel;

    using DataTypes;
    using StringsUtilities;

    public class ExcelDataReaderFromStream : IDataReader
    {
        private readonly long streamLength;
        private readonly Stream stream;
        private readonly DateTime streamDate;
        private readonly MemoryStream memoryStream;

        public ExcelDataReaderFromStream(Stream stream, long streamLength, DateTime streamDate)
        {
            this.stream = stream;
            this.streamLength = streamLength;
            this.streamDate = streamDate;

            var streamContent = new byte[streamLength];
            stream.Read(streamContent, 0, (int)streamLength);
            this.memoryStream = new MemoryStream(streamContent);
        }

        public TableData ReadData()
        {
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(this.memoryStream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet dataSet = excelReader.AsDataSet();

            int rowIndex = 0;
            var tableData = new TableData();

            while (excelReader.Read())
            {
                if (dataSet.Tables[0].Rows[rowIndex].IsNull(0) == true) { break; }

                if (rowIndex == 0)
                {
                    for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                    {
                        string columnName = dataSet.Tables[0].Columns[i].ColumnName;
                        string formattedColumnName = TextFormatter.FormatColumnName(columnName);
                        tableData.AddColumnName(formattedColumnName);
                    }
                }
                else
                {
                    for (int i = 0; i < tableData.ColumnsCount; i++)
                    {
                        string formattedColumnName = tableData.GetColumnName(i);
                        object data = dataSet.Tables[0].Rows[rowIndex].ItemArray[i].ToString();
                        tableData.AddData(i, data);
                    }
                }

                rowIndex++;
            }

            excelReader.Dispose();
            this.memoryStream.Dispose();

            return tableData;
        }
    }
}
