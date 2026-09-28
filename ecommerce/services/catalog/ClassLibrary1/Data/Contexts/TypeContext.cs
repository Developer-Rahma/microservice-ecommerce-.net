using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class TypeContext
    {
        public static async Task seedDataAsync(IMongoCollection<ProductType> typeCollection)
        {
            var hasTypes = await typeCollection.Find(_ => true).AnyAsync();
            if (hasTypes) return;
            var filePath = Path.Combine("Data", "SeedData", "types.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"file is not exist : {filePath}");
                return;

            }
            var brandData = await File.ReadAllTextAsync(filePath);
            var types = JsonSerializer.Deserialize<List<ProductType>>(brandData);
            if (types?.Any() is true)
            {
                await typeCollection.InsertManyAsync(types);
            }


        }
    }
}
