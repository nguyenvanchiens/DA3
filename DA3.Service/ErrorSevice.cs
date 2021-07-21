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
    public interface IErrorSevice
    {
        void Add(Error error);
        void Save();
    }
    public class ErrorSevice : IErrorSevice
    {
        IErrorRepository _errorSevice;
        IUnitOfWork _unitOfWork;
        public ErrorSevice(IErrorRepository errorRepository,IUnitOfWork unitOfWork)
        {
            this._errorSevice = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Error error)
        {
            _errorSevice.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
