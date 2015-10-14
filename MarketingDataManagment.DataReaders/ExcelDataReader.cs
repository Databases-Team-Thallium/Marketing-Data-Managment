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
            var dataSet = new Dictionary<string, ICollection<string>>();
            var formatedColumnsNames = new List<string>();

            while (excelReader.Read())
            {
                if (result.Tables[0].Rows[rowIndex].IsNull(0) == true) { break; }

                if (rowIndex == 0)
                {
                    for (int i = 0; i < result.Tables[0].Columns.Count; i++)
                    {
                        string columnName = TextFormatter.FormatColumnName(result.Tables[0].Columns[i].ColumnName);
                        dataSet.Add(columnName, new List<string>());
                        formatedColumnsNames.Add(columnName);
                    }
                }
                else
                {
                    for (int i = 0; i < formatedColumnsNames.Count; i++)
                    {
                        string columnName = formatedColumnsNames[i];
                        dataSet[columnName].Add(result.Tables[0].Rows[rowIndex].ItemArray[i].ToString());
                    }
                }

                rowIndex++;
            }
        }
    }
}
