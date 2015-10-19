namespace MarketingDataManagment.StringsUtilities
{
    using System;
    using System.IO;

    public static class PathNameParser
    {
        public static DateTime ExtractDateFromFolderName(string fullPathName)
        {
            return Convert.ToDateTime(Path.GetFileName(Path.GetDirectoryName(fullPathName)));
        }
    }
}
