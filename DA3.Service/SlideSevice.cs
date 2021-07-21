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
    public interface ISlideSevice
    {
        void Add(Slide slide);
        void Update(Slide slide);
        void Delete(int id);
        IEnumerable<Slide> GetAll();
        IEnumerable<Slide> GetAllPaging(int page, int pageSize, out int totalRow);
        Slide GetById(int id);
        void SaveChanges();
    }
    public class SlideSevice : ISlideSevice
    {
        ISlideRepository _slideRepository;
        IUnitOfWork _unitOfWork;
        public SlideSevice(ISlideRepository slideRepository,IUnitOfWork unitOfWord)
        {
            this._slideRepository = slideRepository;
            this._unitOfWork = unitOfWord;
        }
        public void Add(Slide slide)
        {
            _slideRepository.Add(slide);
        }

        public void Delete(int id)
        {
            _slideRepository.Delete(id);
        }

        public IEnumerable<Slide> GetAll()
        {
            return _slideRepository.GetAll(new string[] {"SlideGroup"}).OrderBy(x => x.DisplayOrder);
        }

        public IEnumerable<Slide> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _slideRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Slide GetById(int id)
        {
            return _slideRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Slide slide)
        {
            _slideRepository.Update(slide);
        }
    }
}
