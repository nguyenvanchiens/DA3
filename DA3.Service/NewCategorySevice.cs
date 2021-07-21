using DA3.Data.Infrastrure;
using DA3.Data.Reponsitories;
using DA3.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Sevice
{
    public interface INewCategorySevice
    {
        NewCategory Add(NewCategory slideGroup);
        void Update(NewCategory slideGroup);
        NewCategory Delete(int id);
        IEnumerable<NewCategory> GetAll();
        IEnumerable<NewCategory> GetAll(string keyword);
        IEnumerable<NewCategory> GetAllPaging(int page, int pageSize, out int totalRow);
        NewCategory GetById(int id);
        void SaveChanges();
    }
    public class NewCategorySevice : INewCategorySevice
    {
        INewCategoryRepository _newCategoryRepository;
        IUnitOfWork _unitOfWork;
        public NewCategorySevice(INewCategoryRepository newCategoryRepository,IUnitOfWork unitOfWork)
        {
            this._newCategoryRepository = newCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public NewCategory Add(NewCategory slideGroup)
        {
            return _newCategoryRepository.Add(slideGroup);
        }

        public NewCategory Delete(int id)
        {
            return _newCategoryRepository.Delete(id);
        }

        public IEnumerable<NewCategory> GetAll()
        {
            return _newCategoryRepository.GetAll().OrderBy(x=>x.CreatedDate);
        }

        public IEnumerable<NewCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _newCategoryRepository.GetAll().OrderBy(x => x.Name==keyword||x.Description==keyword);
            }
            else
                return _newCategoryRepository.GetAll().OrderBy(x => x.CreatedDate);
        }

        public IEnumerable<NewCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _newCategoryRepository.GetMultiPaging(x=>x.Status,out totalRow,page,pageSize);
        }

        public NewCategory GetById(int id)
        {
            return _newCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(NewCategory slideGroup)
        {
            _newCategoryRepository.Update(slideGroup);
        }
    }
}
