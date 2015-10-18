namespace MarketingDataManagment.XmlHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using MarketingDataManagment.Databases.MSSQL.Data;
    using MarketingDataManagment.Databases.MSSQL.Models;

    public class XmlHandler
    {
        private IXmlDataStrategy xmlDataStrategy;
        public XmlHandler(IXmlDataStrategy strategy, string filePath)
        {
            this.FilePath = filePath;
            this.xmlDataStrategy = strategy;
        }

        public void Handle()
        {
            this.xmlDataStrategy.Handle(this.FilePath);
        }
        public string FilePath { get; set; }
    }
}
