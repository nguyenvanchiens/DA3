using DA3.Data.Infrastrure;
using DA3.Data.Reponsitories;
using DA3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Service
{
    public interface IVisitorStaticService
    {
        void Add(VisitorStatic supportOnline);
        void Delete(int id);
        IEnumerable<VisitorStatic> GetAll();
        VisitorStatic GetById(int id);
        void SaveChanges();
    }
    public class VisitorStaticService : IVisitorStaticService
    {
        IVisitorStaticRepository _visitorStaticRepository;
        IUnitOfWork _unitOfWork;
        public VisitorStaticService(IVisitorStaticRepository visitorStaticRepository,IUnitOfWork unitOfWork)
        {
            this._visitorStaticRepository = visitorStaticRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(VisitorStatic supportOnline)
        {
            _visitorStaticRepository.Add(supportOnline);
        }

        public void Delete(int id)
        {
            _visitorStaticRepository.Delete(id);
        }

        public IEnumerable<VisitorStatic> GetAll()
        {
            return _visitorStaticRepository.GetAll();
        }

       

        public VisitorStatic GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
