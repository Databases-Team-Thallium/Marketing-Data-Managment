namespace MarketingDataManagment.Databases.MSSQL.Models
{
    /// <summary>
    /// Creates the Store table
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Gets or sets the id of the store
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the name of the store
        /// </summary>
        public string StoreName { get; set; }
    }
}
