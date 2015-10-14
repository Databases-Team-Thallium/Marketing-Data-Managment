namespace MarketingDataManagment.DataWriters
{
    using DataTypes;

    public interface IDataWriter
    {
        void WriteData(TableData tableData);
    }
}
