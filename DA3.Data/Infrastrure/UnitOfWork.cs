using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data.Infrastrure
{
    //sau khi thực thi thì sẽ lưu vào database
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private FasFoodDbcontext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public FasFoodDbcontext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
