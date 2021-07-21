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
    public interface IMenuSevice
    {
        void Add(Menu menu);
        void Update(Menu menu);
        void Delete(int id);
        IEnumerable<Menu> GetAll();
        IEnumerable<Menu> GetAllPaging(int page, int pageSize, out int totalRow);
        Menu GetById(int id);
        void SaveChanges();
    }
    public class MenuSevice:IMenuSevice
    {
        IMenuRepository _menuRepository;
        IUnitOfWork _unitOfWork;
        public MenuSevice(IMenuRepository menuRepository,IUnitOfWork unitOfWork)
        {
            this._menuRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Menu menu)
        {
            _menuRepository.Add(menu);
        }

        public void Delete(int id)
        {
            _menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll(new string[]{"MenuGroup"}).OrderBy(x=>x.DisplayOrder);
        }

        public IEnumerable<Menu> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _menuRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Menu menu)
        {
            _menuRepository.Update(menu);
        }
    }
}
