namespace MarketingDataManagment.DataReaders
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using Databases;
    using Databases.MSSQL.Models;

    public class XmlRevenuesDataReader : IFileDataReader
    {
        private IGenericRepository<Revenue> revenuesRepository;
        private IGenericRepository<Store> storesRepository;

        public XmlRevenuesDataReader(IGenericRepository<Revenue> revenuesRepository, IGenericRepository<Store> storesRepository)
        {
            this.revenuesRepository = revenuesRepository;
            this.storesRepository = storesRepository;
        }

        public void ReadData(string filePath)
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

            foreach (var revenueStore in stores)
            {
                foreach (var revenue in revenueStore.Revenues)
                {
                    if(this.storesRepository.All().Any(s => s.StoreName == revenueStore.Name) == false)
                    {
                        this.storesRepository.Add(new Store()
                        {
                            StoreName = revenueStore.Name
                        });
                    }

                    this.revenuesRepository.Add(new Revenue()
                    {
                        Date = DateTime.Parse(revenue.Date),
                        Amount = decimal.Parse(revenue.Value)
                    });
                }
            }
        }
    }
}
