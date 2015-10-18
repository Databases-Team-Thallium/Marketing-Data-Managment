namespace MarketingDataManagment.Databases
{
    using DataTypes;

    public interface IDatabase
    {
        void SelectTable(string tableName);
        void Insert(TableData tableData);
    }
}
