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
    public interface IFeedBackSevice
    {
        void Add(FeedBack feedBack);
        void Update(FeedBack feedBack);
        void Delete(int id);
        IEnumerable<FeedBack> GetAll();
        IEnumerable<FeedBack> GetAllPaging(int page, int pageSize, out int totalRow);
        FeedBack GetById(int id);
        void SaveChanges();
    }
    public class FeedBackSevice : IFeedBackSevice
    {
        IFeedBackRepository _feedBackRepository;
        IUnitOfWork _unitOfWork;
        public FeedBackSevice(IFeedBackRepository feedBackRepository, IUnitOfWork unitOfWord)
        {
            this._feedBackRepository = feedBackRepository;
            this._unitOfWork = unitOfWord;
        }
        public void Add(FeedBack feedBack)
        {
            _feedBackRepository.Add(feedBack);
        }

        public void Delete(int id)
        {
            _feedBackRepository.Delete(id);
        }

        public IEnumerable<FeedBack> GetAll()
        {
            return _feedBackRepository.GetAll().OrderBy(x=>x.CreatedDate);
        }

        public IEnumerable<FeedBack> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _feedBackRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public FeedBack GetById(int id)
        {
            return _feedBackRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FeedBack feedBack)
        {
            _feedBackRepository.Update(feedBack);
        }
    }
}
