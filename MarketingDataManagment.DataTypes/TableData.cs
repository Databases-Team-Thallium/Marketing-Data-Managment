namespace MarketingDataManagment.DataTypes
{
    using System.Collections.Generic;

    public class TableData
    {
        private readonly IList<string> columns;
        private readonly IList<IList<object>> rows;

        public TableData()
        {
            this.columns = new List<string>();
            this.rows = new List<IList<object>>();
        }

        public int ColumnsCount
        {
            get
            {
                return this.columns.Count;
            }
        }

        public int RowsCount
        {
            get
            {
                return this.rows.Count;
            }
        }

        public int AddColumnName(string name)
        {
            this.columns.Add(name);

            return this.columns.IndexOf(name);
        }

        public string GetColumnName(int columnIndex)
        {
            return this.columns[columnIndex];
        }

        public void AddData(int columnIndex, object data)
        {
            if(this.rows[columnIndex] == null)
            {
                this.rows[columnIndex] = new List<object>();
            }
            
            this.rows[columnIndex].Add(data);
        }

        public object GetData(int columnIndex, int rowIndex)
        {
            return this.rows[rowIndex][columnIndex];
        }
    }
}
