using DA3.Data.Infrastrure;
using DA3.Data.Reponsitories;
using DA3.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Sevice
{
    public interface IProductCategorySevice
    {

        void Add(ProductCategory supportOnline);
        void Update(ProductCategory supportOnline);
        ProductCategory Delete(int id);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAll(string keyword);
        IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow);
        ProductCategory GetById(int id);
        void SaveChanges();
    }
    public class ProductCategorySevice : IProductCategorySevice
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWork _unitOfWork;
        public ProductCategorySevice(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(ProductCategory supportOnline)
        {
            _productCategoryRepository.Add(supportOnline);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if(!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x=>x.Name.Contains(keyword)||x.Description.Contains(keyword));
            else 
                return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory supportOnline)
        {
             _productCategoryRepository.Update(supportOnline);
        }
    }
}
