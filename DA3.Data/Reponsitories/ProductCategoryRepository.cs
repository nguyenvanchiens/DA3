using DA3.Data.Infrastrure;
using DA3.Model.Models;
using System;
using System.Collections.Generic;

namespace DA3.Data.Reponsitories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory>//xây dựng thêm các thuộc tính phát sinh
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            throw new NotImplementedException();
        }
    }
}