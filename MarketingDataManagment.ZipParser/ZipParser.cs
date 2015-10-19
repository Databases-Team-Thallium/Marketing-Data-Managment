namespace MarketingDataManagment.ZipParser
{
    using System;
    using System.IO.Compression;
    using System.Collections.Generic;

    using DataReaders;
    using StringsUtilities;

    public class ZipParser: IDisposable
    {
        private readonly ZipArchive archive;
        private readonly IStreamDataReader dataReader;
        private readonly ICollection<string> extensionsToRead;

        public ZipParser(string zipFilePath, ICollection<string> extensionsToRead, IStreamDataReader dataReader)
        {
            this.archive = ZipFile.OpenRead(zipFilePath);
            this.dataReader = dataReader;
            this.extensionsToRead = extensionsToRead;
        }

        public void Parse()
        {
            this.Parse(false);
        }

        public void Parse(bool extractDateFromFolderName)
        {
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

                    dataReader.ReadData(entryStream, entry.Length, entryDate);

                    entryStream.Dispose();
                }
            }
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
