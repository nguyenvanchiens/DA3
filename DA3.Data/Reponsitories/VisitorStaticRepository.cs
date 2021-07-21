using DA3.Data.Infrastrure;
using DA3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data.Reponsitories
{
    public interface IVisitorStaticRepository : IRepository<VisitorStatic>
    {

    }
    public class VisitorStaticRepository : RepositoryBase<VisitorStatic>
    {
        public VisitorStaticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
