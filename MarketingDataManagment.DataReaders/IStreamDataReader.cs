namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.IO;

    public interface IStreamDataReader
    {
        void ReadData(Stream stream, long streamLength, DateTime streamDate);
    }
}
