namespace MarketingDataManagment.Databases.MSSQL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Creates the Sales Table
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Gets or sets the is for the sales table
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the sold items
        /// </summary>
        public int QuantitySold { get; set; }

        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the sold product
        /// </summary>
        public int StoreProductId { get; set; }

        public virtual StoreProduct Product { get; set; }
    }
}
