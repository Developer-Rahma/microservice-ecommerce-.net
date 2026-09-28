using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<ProductEntity> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> ProductTypes { get; }


        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Brands =database.GetCollection<ProductBrand>(configuration["DatabaseSettings:BrandsCollection"]);
            ProductTypes = database.GetCollection<ProductType>(configuration["DatabaseSettings:TypesCollection"]);
            Products = database.GetCollection<ProductEntity>(configuration["DatabaseSettings:ProductsCollection"]);
            _ = BrandContextSeed.seedDataAsync(Brands);
            _ = ProductsContext.seedDataAsync(Products);
            _ = TypeContext.seedDataAsync(ProductTypes);




        }
    }
}
