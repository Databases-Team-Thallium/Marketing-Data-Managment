namespace ProductsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<ProductsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "ProductsSystem.Data.ProductsSystemDbContext";
        }

        protected override void Seed(ProductsSystemDbContext context)
        {
            context.Stores.AddOrUpdate(
                st => st.StoreName,
                new Store
                {
                    StoreName = "Physical Store",
                    StoreLocation = "Sofia",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            ProductCode = "75100.43",
                            Price = 49,
                            Quantity = 202,
                            Status = ProductStatus.Ordinary,
                            Sales = new List<Sale>
                            {
                                new Sale
                                {
                                    SaleName = "Sale Number 3",
                                    QuantitySold = 2
                                }
                            }
                        },
                        new Product
                        {
                            ProductCode = "75100.48",
                            Price = 49,
                            Quantity = 242,
                            Status = ProductStatus.Ordinary,
                            Sales = new List<Sale>
                            {
                                new Sale
                                {
                                    SaleName = "Sale Number 2",
                                    QuantitySold = 2
                                }
                            }
                        },
                        new Product
                        {
                            ProductCode = "75100.60",
                            Price = 49,
                            Quantity = 192,
                            Status = ProductStatus.Ordinary,
                            Sales = new List<Sale>
                            {
                                new Sale
                                {
                                SaleName = "Sale Number 1",
                                QuantitySold = 2
                                }
                            }
                        }
                    }
                });
        }
    }
}