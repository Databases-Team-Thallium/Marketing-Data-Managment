namespace MarketingDataManagment.DataTypes
{
    using System.Collections.Generic;

    public class TableData
    {
        private readonly IList<string> columnsNames;
        private readonly IList<ICollection<object>> rowsData;

        public TableData()
        {
            this.columnsNames = new List<string>();
            this.rowsData = new List<ICollection<object>>();
        }

        public int ColumnsCount
        {
            get
            {
                return this.columnsNames.Count;
            }
        }

        public int RowsCount
        {
            get
            {
                return this.rowsData.Count;
            }
        }

        public int AddColumnName(string name)
        {
            this.columnsNames.Add(name);

            return this.columnsNames.IndexOf(name);
        }

        public string GetColumnName(int columnIndex)
        {
            return this.columnsNames[columnIndex];
        }

        public void AddData(int columnIndex, object data)
        {
            if(this.rowsData[columnIndex] == null)
            {
                this.rowsData[columnIndex] = new List<object>();
            }
            
            this.rowsData[columnIndex].Add(data);
        }
    }
}
