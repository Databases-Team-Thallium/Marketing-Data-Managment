namespace MarketingDataManagment.StringsUtilities
{
    using System.Text.RegularExpressions;

    public static class TextFormatter
    {
        public static string FormatColumnName(string columnName)
        {
            columnName = CaptializeFirstLetters(columnName);
            columnName = ClearWhiteSpaces(columnName);

            return columnName;
        }

        public static string CaptializeFirstLetters(string text)
        {
            return Regex.Replace(text, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
        }

        public static string ClearWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s", m => m.Value.Remove(0));
        }
    }
}
