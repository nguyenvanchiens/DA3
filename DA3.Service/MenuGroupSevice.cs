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
    public interface IMenuGroupSevice
    {
        void Add(MenuGroup menu);
        void Update(MenuGroup menu);
        void Delete(int id);
        IEnumerable<MenuGroup> GetAll();
        IEnumerable<MenuGroup> GetAllPaging(int page, int pageSize, out int totalRow);
        MenuGroup GetById(int id);
        void SaveChanges();
    }
    public class MenuGroupSevice: IMenuGroupSevice
    {
        IMenuGroupRepository _menuGroupRepository;
        IUnitOfWork _unitOfWork;
        public MenuGroupSevice(IMenuGroupRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this._menuGroupRepository = menuRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(MenuGroup menuGroup)
        {
            _menuGroupRepository.Add(menuGroup);
        }

        public void Delete(int id)
        {
            _menuGroupRepository.Delete(id);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }

        public IEnumerable<MenuGroup> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _menuGroupRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public MenuGroup GetById(int id)
        {
            return _menuGroupRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(MenuGroup menuGroup)
        {
            _menuGroupRepository.Update(menuGroup);
        }
    }
}
