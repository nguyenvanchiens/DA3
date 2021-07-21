using DA3.Data.Infrastrure;
using DA3.Data.Reponsitories;
using DA3.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Service
{
    public interface ISystemConfigService
    {
        void Add(SystemConfig supportOnline);
        void Update(SystemConfig supportOnline);
        void Delete(int id);
        IEnumerable<SystemConfig> GetAll();
        IEnumerable<SystemConfig> GetAllPaging(int page, int pageSize, out int totalRow);
        SystemConfig GetById(int id);
        void SaveChanges();
    }
    public class SystemConfigService : ISystemConfigService
    {
        ISystemConfigRepository _systemConfigRepository;
        IUnitOfWork _unitOfWork;
        public SystemConfigService(ISystemConfigRepository systemConfigRepository,IUnitOfWork unitOfWork)
        {
            this._systemConfigRepository = systemConfigRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(SystemConfig supportOnline)
        {
            _systemConfigRepository.Add(supportOnline);
        }

        public void Delete(int id)
        {
            _systemConfigRepository.Delete(id);
        }

        public IEnumerable<SystemConfig> GetAll()
        {
            return _systemConfigRepository.GetAll();
        }

        public IEnumerable<SystemConfig> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _systemConfigRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public SystemConfig GetById(int id)
        {
            return _systemConfigRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SystemConfig supportOnline)
        {
            _systemConfigRepository.Update(supportOnline);
        }
    }
}
