using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepo : IBrandRepo, IProductRepo, ITypeRepo
    {


        public ICatalogContext _context { get; set; }

        public ProductRepo(ICatalogContext context)
        {
            _context = context;
        }

        Task<ProductEntity> IProductRepo.createProduct(ProductEntity product)
        {

            throw new NotImplementedException();
        }

        Task<bool> IProductRepo.deleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductBrand>> IBrandRepo.getAllBrands()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductEntity>> IProductRepo.getAllProducts()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductEntity>> IProductRepo.getAllProductsByBrandName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductEntity>> getAllProductsByName(string name)
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        Task<IEnumerable<ProductType>> ITypeRepo.getAllTypes()
        {
            throw new NotImplementedException();
        }

       public async Task<ProductEntity> getProductById(string Id)
        {
            return await _context.Products.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        Task<bool> IProductRepo.updateProduct(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }


}
