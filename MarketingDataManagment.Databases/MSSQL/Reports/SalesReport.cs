namespace MarketingDataManagment.Databases.MSSQL.Reports
{
    using Models;
   
        public class SalesReport
        {
            public int SaleId { get; set; }

            public Sale Sale { get; set; }

            public Store Store { get; set; }

            public int TotalQuantitySold { get; set; }

            public double TotalIncomes { get; set; }
        }
    }

