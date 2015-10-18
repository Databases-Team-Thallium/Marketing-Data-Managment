using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingDataManagment.Databases.MSSQL.Models
{
    public class Revenue
    {
        public Revenue() { }

        public int RevenueID { get; set; }

        public int StoreId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
