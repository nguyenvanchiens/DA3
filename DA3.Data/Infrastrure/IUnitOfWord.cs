using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data.Infrastrure
{
    //thiết kế phương thức commit
    public interface IUnitOfWork
    {
        void Commit();
    }
}
