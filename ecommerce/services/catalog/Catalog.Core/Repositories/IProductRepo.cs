using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductEntity>> getAllProducts();
        Task<ProductEntity> getProductById( string Id);

        Task<IEnumerable<ProductEntity>> getAllProductsByName( string name);
        Task<IEnumerable<ProductEntity>> getAllProductsByBrandName(string name);
        Task<ProductEntity> createProduct(ProductEntity product);

        Task<bool> updateProduct(ProductEntity product);

        Task<bool> deleteProduct(string id);



    }
}
