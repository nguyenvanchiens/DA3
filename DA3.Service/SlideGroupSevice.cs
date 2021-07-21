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
    public interface ISlideGroupSevice
    {
        SlideGroup Add(SlideGroup slideGroup);
        void Update(SlideGroup slideGroup);
        SlideGroup Delete(int id);
        IEnumerable<SlideGroup> GetAll();
        IEnumerable<SlideGroup> GetAllPaging(int page, int pageSize, out int totalRow);
        SlideGroup GetById(int id);
        void SaveChanges();
    }
    public class SlideGroupSevice:ISlideGroupSevice
    {
        ISlideGroupRepository _slideGroupRepository;
        IUnitOfWork _unitOfWork;
        public SlideGroupSevice(ISlideGroupRepository slideGroupRepository,IUnitOfWork unitOfWord)
        {
            this._slideGroupRepository = slideGroupRepository;
            this._unitOfWork = unitOfWord;
        }

        public SlideGroup Add(SlideGroup slideGroup)
        {
            return _slideGroupRepository.Add(slideGroup);
        }

        public SlideGroup Delete(int id)
        {
            return _slideGroupRepository.Delete(id);
        }

        public IEnumerable<SlideGroup> GetAll()
        {
            return _slideGroupRepository.GetAll();
        }

        public IEnumerable<SlideGroup> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _slideGroupRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public SlideGroup GetById(int id)
        {
            return _slideGroupRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SlideGroup slideGroup)
        {
            _slideGroupRepository.Update(slideGroup);
        }
    }
}
