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
    public interface IContactSevice
    {
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
        IEnumerable<Contact> GetAll();
        IEnumerable<Contact> GetAllPaging(int page, int pageSize, out int totalRow);
        Contact GetById(int id);
        void SaveChanges();
    }
    public class ContactSevice:IContactSevice
    {
        IContactRepository _contactRepository;
        IUnitOfWork _unitOfWork;
        public ContactSevice(IContactRepository contactRepository, IUnitOfWork unitOfWord)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWord;
        }

        public void Add(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public IEnumerable<Contact> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _contactRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Contact contact)
        {
            _contactRepository.Update(contact);
        }
    }
}
