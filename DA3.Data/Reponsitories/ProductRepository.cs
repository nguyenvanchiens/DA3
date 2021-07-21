
using System;
using System.Collections;
using System.Collections.Generic;
using DA3.Data.Infrastrure;
using DA3.Model.Models;
using System.Linq;

namespace DA3.Data.Reponsitories
{
    public interface IProductRepository : IRepository<Product>
    {
       
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }     
        
    }
}