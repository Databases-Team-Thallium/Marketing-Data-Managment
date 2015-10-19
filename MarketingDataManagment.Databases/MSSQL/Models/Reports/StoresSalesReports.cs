namespace MarketingDataManagment.Databases.MSSQL.Models.Reports
{
    using System.Collections.Generic;

    public class StoresSalesReports
    {
        public Store Store { get; set; }

        public IEnumerable<StoreSalesReport> VendorReports { get; set; }
    }
}
