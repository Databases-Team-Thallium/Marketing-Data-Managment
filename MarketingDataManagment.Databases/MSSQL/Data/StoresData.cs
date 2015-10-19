namespace MarketingDataManagment.Databases.MSSQL.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Repositories;

    public class StoresData : IStoresData
    {
        private IStoresDbContext context;
        private IDictionary<Type, object> repositories;

        public StoresData()
            : this(new StoresDbContext())
        {
        }

        public StoresData(IStoresDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<StoreProduct> Products
        {
            get
            {
                return this.GetRepository<StoreProduct>();
            }
        }

        public IGenericRepository<Sale> Sales
        {
            get
            {
                return this.GetRepository<Sale>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
