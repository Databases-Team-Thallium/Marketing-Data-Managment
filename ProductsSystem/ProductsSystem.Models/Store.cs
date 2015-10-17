﻿namespace ProductsSystem.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Creates the Store table
    /// </summary>
    public class Store
    {
        private ICollection<Sale> sales;
        private ICollection<Product> products;

        public Store()
        {
            this.Sales = new HashSet<Sale>();
            this.Products = new HashSet<Product>();
        }

        /// <summary>
        /// Gets or sets the id of the store
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the name of the store
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// Gets or sets the location of the store
        /// </summary>
        public string StoreLocation { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}