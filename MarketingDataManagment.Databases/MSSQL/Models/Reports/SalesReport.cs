namespace MarketingDataManagment.Databases.MSSQL.Models.Reports
{
    using Models;
   
        public class SalesReport
        {
            public int ProductId { get; set; }

            public Sale Product { get; set; }

            public Store Store { get; set; }

            public int TotalQuantitySold { get; set; }

            public double TotalIncomes { get; set; }
        }
    }

