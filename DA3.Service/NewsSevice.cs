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
    public interface INewsSevice
    {

        void Add(News news);
        void Update(News news);
        void Delete(int id);
        IEnumerable<News> GetAll();
        IEnumerable<News> GetAllPaging(int page, int pageSize, out int totalRow);
        News GetById(int id);
        void SaveChanges();
    }
    public class NewsSevice : INewsSevice
    {
        INewsRepository _newRepository;
        IUnitOfWork _unitOfWork;
        public NewsSevice(NewsRepository newsRepository, IUnitOfWork unitOfWork)
        {
            this._newRepository = newsRepository;
            this._unitOfWork = unitOfWork;

        }

        public void Add(News news)
        {
            _newRepository.Add(news);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public News GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(News news)
        {
            throw new NotImplementedException();
        }
        //public void Add(News news)
        //{
        //    _newRepository.Add(news);
        //}

        //public void Delete(int id)
        //{
        //    _newRepository.Delete(id);
        //}

        //public IEnumerable<News> GetAll()
        //{
        //    return _newRepository.GetAll(new string[] { "NewCategory" }).OrderBy(x=>x.CreatedDate);//lấy ra được cả các loại tin tức
        //}

        //public IEnumerable<News> GetAllPaging(int page, int pageSize, out int totalRow)
        //{
        //    return _newRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        //}

        //public News GetById(int id)
        //{
        //    return _newRepository.GetSingleById(id);
        //}

        //public void SaveChanges()
        //{
        //    _unitOfWork.Commit();
        //}

        //public void Update(News news)
        //{
        //    _newRepository.Update(news);
        //}
    }
}
