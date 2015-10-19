﻿namespace MarketingDataManagment.Databases.MongoDB.Models
{
    using global::MongoDB.Bson;
    using global::MongoDB.Bson.Serialization.Attributes;

    public class CatalogProduct
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public CatalogProduct()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
