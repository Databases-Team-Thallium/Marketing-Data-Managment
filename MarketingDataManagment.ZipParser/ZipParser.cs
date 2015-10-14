namespace MarketingDataManagment.ZipParser
{
    using System;
    using System.IO.Compression;
    using System.Collections.Generic;

    using DataTypes;
    using DataReaders;
    using StringsUtilities;

    public class ZipParser: IDisposable
    {
        private readonly ZipArchive archive;
        private readonly IDataReader dataReader;
        private readonly ICollection<string> extensionsToRead;

        public ZipParser(string zipFilePath, ICollection<string> extensionsToRead, IDataReader dataReader)
        {
            this.archive = ZipFile.OpenRead(zipFilePath);
            this.dataReader = dataReader;
            this.extensionsToRead = extensionsToRead;
        }

        public ICollection<TableData> Parse()
        {
            return this.Parse(false);
        }

        public ICollection<TableData> Parse(bool extractDateFromFolderName)
        {
            var tablesData = new List<TableData>();

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (IsExtensionToRead(entry.FullName) == true)
                {
                    var entryStream = entry.Open();
                    
                    DateTime entryDate;

                    if (extractDateFromFolderName == true)
                    {
                        entryDate = PathNameParser.ExtractDateFromFolderName(entry.FullName);
                    }
                    else
                    {
                        entryDate = DateTime.Now;
                    }

                    tablesData.Add(dataReader.ReadData());

                    entryStream.Dispose();
                }
            }

            return tablesData;
        }

        private bool IsExtensionToRead(string fileName)
        {
            foreach (var extension in extensionsToRead)
            {
                if (fileName.EndsWith(extension, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            return false;
        }

        public void Dispose()
        {
            this.archive.Dispose();
        }
    }
}
