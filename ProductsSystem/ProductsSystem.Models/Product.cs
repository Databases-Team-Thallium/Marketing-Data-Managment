namespace ProductsSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Creating the Product Table 
    /// </summary>
    public class Product
    {
        private ICollection<Sale> sales;
        private ICollection<Store> stores;

        public Product()
        {
            this.Sales = new HashSet<Sale>();
            this.Stores = new HashSet<Store>(); 
        }

        /// <summary>
        /// Gets or sets the primary Key for the Product Table
        /// </summary>
        public int ProductId { get; set; }

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
        public ProductStatus Status { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
        
        public virtual ICollection<Store> Stores
        {
            get { return this.stores; }
            set { this.stores = value; }
        }
    }
}
