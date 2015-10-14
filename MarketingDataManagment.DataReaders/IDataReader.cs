namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.IO;

    public interface IDataReader
    {
        void ReadData(Stream stream, long streamLength, DateTime streamDate);
    }
}
