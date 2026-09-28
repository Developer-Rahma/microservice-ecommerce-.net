using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class ProductsContext
    {
        public static async Task seedDataAsync(IMongoCollection<ProductEntity> productsCollection)
        {
            var hasProducts = await productsCollection.Find(_ => true).AnyAsync();
            if (hasProducts) return;
            var filePath = Path.Combine("Data", "SeedData", "products.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"file is not exist : {filePath}");
                return;

            }
            var productData = await File.ReadAllTextAsync(filePath);
            var products = JsonSerializer.Deserialize<List<ProductEntity>>(productData);
            if (products?.Any() is true)
            {
                await productsCollection.InsertManyAsync(products);
            }


        }
    }
}
