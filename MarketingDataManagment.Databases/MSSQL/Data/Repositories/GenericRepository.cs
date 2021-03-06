﻿namespace MarketingDataManagment.Databases.MSSQL.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Data;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IStoresDbContext context;
        private IDbSet<T> set;

        public GenericRepository(IStoresDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }

        public void BulkAdd(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                var entry = AttachIfDetached(entity);
                entry.State = EntityState.Added;
            }
        }
    }
}