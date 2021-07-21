using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data.Infrastrure
{
    //giao tiếp để khởi tạo các đối tượng entity
    public interface IDbFactory : IDisposable
    {
        FasFoodDbcontext init();
    }
}
