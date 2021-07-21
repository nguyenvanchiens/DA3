﻿using DA3.Data.Infrastrure;
using DA3.Data.Reponsitories;
using DA3.Model.Models;
using DA3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Service
{
    public interface ISupportOnlineService
    {
        void Add(SupportOnline supportOnline);
        void Update(SupportOnline supportOnline);
        void Delete(int id);
        IEnumerable<SupportOnline> GetAll();
        IEnumerable<SupportOnline> GetAllPaging(int page, int pageSize, out int totalRow);
        SupportOnline GetById(int id);
        void SaveChanges();
    }
    public class SupportOnlineService : ISupportOnlineService
    {
        ISupportOnlineRepository _supportOnlineRepository;
        IUnitOfWork _unitOfWork;
        public SupportOnlineService(ISupportOnlineRepository supportOnlineRepository,IUnitOfWork unitOfWork)
        {
            this._supportOnlineRepository = supportOnlineRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(SupportOnline supportOnline)
        {
            _supportOnlineRepository.Add(supportOnline);
        }

        public void Delete(int id)
        {
            _supportOnlineRepository.Delete(id);
        }

        public IEnumerable<SupportOnline> GetAll()
        {
            return _supportOnlineRepository.GetAll();
        }

        public IEnumerable<SupportOnline> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _supportOnlineRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public SupportOnline GetById(int id)
        {
            return _supportOnlineRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SupportOnline supportOnline)
        {
            _supportOnlineRepository.Update(supportOnline);
        }
    }
}
