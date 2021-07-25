using CDI.Catalog.Domain.DomainObjects;
using CDI.Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDI.Catalog.Domain.Repositories
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(Guid id);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
    }
}