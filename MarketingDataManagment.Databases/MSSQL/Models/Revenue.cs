namespace MarketingDataManagment.Databases.MSSQL.Models
{
    using System;

    public class Revenue
    {
        public int Id { get; set; }
    
        public DateTime Date { get; set; }
    
        public decimal Amount { get; set; }
    }
}
