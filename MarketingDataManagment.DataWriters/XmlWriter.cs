namespace MarketingDataManagment.DataWriters
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Xml;
    using Databases.MSSQL.Models.Reports;

    public class XmlUtility
    {
        private const string XmlReportFilePath = @"..\..\..\Exported-Files\Xml";
        private const string XmlReportFileName = @"\Sales-by-Store-Report.xml";

        public static void CreateXmlFile(List<StoresSalesReports> dataGroups)
        {
            if (!Directory.Exists(XmlReportFilePath))
            {
                Directory.CreateDirectory(XmlReportFilePath);
            }

            string reportFileName = XmlReportFilePath + XmlReportFileName;
            Encoding reportEncoding = Encoding.GetEncoding("utf-8");

            using (var reportWriter = new XmlTextWriter(reportFileName, reportEncoding))
            {
                reportWriter.Formatting = Formatting.Indented;
                reportWriter.IndentChar = '\t';
                reportWriter.Indentation = 1;

                reportWriter.WriteStartDocument();
                reportWriter.WriteStartElement("sales");
                foreach (var group in dataGroups)
                {
                    WriteSale(reportWriter, group.Store.StoreName, group.VendorReports);
                }

                reportWriter.WriteEndElement();
                reportWriter.WriteEndDocument();
            }

            Process.Start(XmlReportFilePath);
        }

        public static Dictionary<string, List<string[]>> ReadXmlReport(string filePath)
        {
            XmlDocument xmlReportDoc = new XmlDocument();
            xmlReportDoc.Load(filePath);

            XmlNodeList nodes = xmlReportDoc.SelectNodes("/expenses-by-month/");
            var results = new Dictionary<string, List<string[]>>();

            foreach (XmlNode stores in nodes)
            {
                string storeName = stores.Attributes["name"].Value;

                foreach (XmlNode expense in stores.ChildNodes)
                {
                    var expensesResults = new string[2];
                    expensesResults[0] = expense.Attributes["month"].Value;
                    expensesResults[1] = expense.InnerText;

                    if (results.ContainsKey(storeName))
                    {
                        results[storeName].Add(expensesResults);
                    }
                    else
                    {
                        results.Add(storeName, new List<string[]> { expensesResults });
                    }
                }
            }

            return results;
        }

        private static void WriteSale(XmlWriter reportWriter, string storeName, IEnumerable<StoreSalesReport> summaries)
        {
            reportWriter.WriteStartElement("sale");
            reportWriter.WriteAttributeString("store", storeName);

            foreach (var summary in summaries)
            {
                reportWriter.WriteStartElement("summary");
                reportWriter.WriteAttributeString("date", summary.DateOfSale.ToShortDateString());
                reportWriter.WriteAttributeString("total-sum", summary.SumOfSales.ToString("F"));
                reportWriter.WriteEndElement();
            }

            reportWriter.WriteEndElement();
        }
    }
}
