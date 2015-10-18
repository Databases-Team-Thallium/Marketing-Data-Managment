namespace MarketingDataManagment.XmlHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using MarketingDataManagment.Databases.MSSQL.Data;
    using MarketingDataManagment.Databases.MSSQL.Models;
    public class XmlRevenueStrategy: IXmlDataStrategy
    {
        public XmlRevenueStrategy() { }
        public void Handle(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            var stores =
                from store in xmlDoc.Descendants("store")
                select new
                {
                    Name = store.Attribute("name").Value,
                    Revenues =
                        from revenue in store.Descendants("revenues")
                        select new
                        {
                            Date = revenue.Attribute("day").Value,
                            Value = revenue.Value
                        }
                };

            var dbContext = new MarketingDataManagmentDbContenxt();

            var allStores =
                from store in dbContext.Stores
                select store;

            foreach (var revenueStore in stores)
            {
                int currentStoreId = 0;
                foreach (var store in allStores)
                {
                    if (revenueStore.Name == store.StoreName)
                    {
                        currentStoreId = store.StoreId;
                    }
                }

                foreach (var revenue in revenueStore.Revenues)
                {
                    string[] date = revenue.Date.Split('-');
                    int day = int.Parse(date[0]);
                    int month = int.Parse(date[1]);
                    int year = int.Parse(date[2]);

                    dbContext.Revenues.Add(new Revenue

                    {
                        StoreId = currentStoreId,
                        Date = new DateTime(year, month, day),
                        Amount = decimal.Parse(revenue.Value)
                    });
                }
            }

            dbContext.SaveChanges();
        }
    }
}
