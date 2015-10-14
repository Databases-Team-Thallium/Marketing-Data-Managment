namespace MarketingDataManagment.Databases
{
    using System.Collections.Generic;

    public interface IDatabase
    {
        void SelectTable(string tableName);
        void InsertRow(IDictionary<string, ICollection<string>> rowData);
    }
}
