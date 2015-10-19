namespace MarketingDataManagment.Databases.MongoDB.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using global::MongoDB.Driver;
    using System.Threading;
    using global::MongoDB.Bson;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IProductsCatalogDbContext context;
        private IMongoCollection<T> set;

        public GenericRepository(IProductsCatalogDbContext context, string name)
        {
            this.context = context;
            this.set = context.Set<T>(name);
        }

        public void Add(T entity)
        {
            this.set.InsertOneAsync(entity);
        }

        public IQueryable<T> All()
        {
            var asyncTaskResult = new Dictionary<string, IEnumerable<T>>();
            var readyEvent = new AutoResetEvent(false);

            AsyncAll(asyncTaskResult, readyEvent);

            readyEvent.WaitOne();

            return asyncTaskResult["return"].AsQueryable<T>();
        }

        private async void AsyncAll(IDictionary<string, IEnumerable<T>> asyncTaskResult, EventWaitHandle readyEvent)
        {
            var result = await this.set.Find<T>(t => true).ToListAsync();
            asyncTaskResult.Add("return", result);
            readyEvent.Set();
        }

        public void BulkAdd(IEnumerable<T> entities)
        {
            this.set.InsertManyAsync(entities);
        }

        public void Delete(T entity)
        {
            var entityAsBson = entity.ToBsonDocument<T>();
            var filter = Builders<T>.Filter.Eq("Id", entityAsBson["_id"]);
            this.set.DeleteOneAsync(filter);
        }

        public void Detach(T entity)
        {
            
        }

        public void Update(T entity)
        {
            var entityAsBson = entity.ToBsonDocument<T>();
            var filter = Builders<T>.Filter.Eq("Id", entityAsBson["_id"]);
            this.set.ReplaceOneAsync(filter, entity);
        }
    }
}
