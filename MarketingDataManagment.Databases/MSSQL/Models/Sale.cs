namespace MarketingDataManagment.Databases.MSSQL.Models
{
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
        /// Gets or sets the name for the sales table
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string SaleName { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the sold items
        /// </summary>
        public int QuantitySold { get; set; }

        /// <summary>
        /// Gets or sets the sold product
        /// </summary>
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the store, where the product was sold
        /// </summary>
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
