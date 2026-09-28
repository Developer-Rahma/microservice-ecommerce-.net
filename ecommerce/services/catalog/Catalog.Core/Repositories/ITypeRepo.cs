
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface ITypeRepo
    {
        Task<IEnumerable<ProductType>> getAllTypes();
    }
}
