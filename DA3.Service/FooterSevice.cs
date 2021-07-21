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
    public interface IFooterSevice
    {
        void Add(Footer footer);
        void Update(Footer footer);
        void Delete(int id);
        IEnumerable<Footer> GetAll();
        IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow);
        Footer GetById(int id);
        void SaveChanges();
    }
    public class FooterSevice : IFooterSevice
    {
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;
        public FooterSevice(IFooterRepository footerRepository,IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._footerRepository = footerRepository;
        }
        public void Add(Footer footer)
        {
            _footerRepository.Add(footer);
        }

        public void Delete(int id)
        {
            _footerRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _footerRepository.GetAll();
        }

        public IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _footerRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Footer GetById(int id)
        {
            return _footerRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Footer footer)
        {
            _footerRepository.Update(footer);
        }
    }
}
