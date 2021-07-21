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
    public interface IAboutSevice
    {
        void Add(About about);
        void Update(About about);
        void Delete(int id);
        IEnumerable<About> GetAll();
        IEnumerable<About> GetAllPaging(int page, int pageSize, out int totalRow);
        About GetById(int id);
        void SaveChanges();
    }

    public class AboutSevice :IAboutSevice
    {
        IAboutRepository _aboutRepository;
        IUnitOfWork _unitOfWork;
        public AboutSevice(IAboutRepository aboutRepository,IUnitOfWork unitOfWord)
        {
            this._aboutRepository = aboutRepository;
            this._unitOfWork = unitOfWord;
        }

        public void Add(About about)
        {
            _aboutRepository.Add(about);
        }

        public void Delete(int id)
        {
            _aboutRepository.Delete(id);
        }

        public void Update(About about)
        {
            _aboutRepository.Update(about);
        }

        public IEnumerable<About> GetAll()
        {
            return _aboutRepository.GetAll();
        }

        public IEnumerable<About> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _aboutRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public About GetById(int id)
        {
            return _aboutRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
