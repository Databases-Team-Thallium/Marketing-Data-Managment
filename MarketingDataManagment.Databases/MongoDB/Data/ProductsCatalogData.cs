namespace MarketingDataManagment.Databases.MongoDB.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Repositories;

    public class ProductsCatalogData : IProductsCatalogData
    {
        private IProductsCatalogDbContext context;
        private IDictionary<Type, object> repositories;

        public ProductsCatalogData()
        {
            this.context = new ProductsCatalogDbContext();
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>("test_products");
            }
        }

        private IGenericRepository<T> GetRepository<T>(string name) where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context, name));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
