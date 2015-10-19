namespace MarketingDataManagment.Databases.MSSQL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Creating the Product Table 
    /// </summary>
    public class StoreProduct
    {
        private ICollection<Sale> sales;

        public StoreProduct()
        {
            this.Sales = new HashSet<Sale>();
        }

        /// <summary>
        /// Gets or sets the primary Key for the Product Table
        /// </summary>
        public int StoreProductId { get; set; }

        /// <summary>
        /// Gets or sets how the product is stored in Excel file system
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets sale Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the initial ordered quantity, from which the sold items will be subtracted
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status of the product
        /// </summary>
        public string Status { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
    }
}
