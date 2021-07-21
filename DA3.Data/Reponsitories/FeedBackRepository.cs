using DA3.Data.Infrastrure;
using DA3.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data.Reponsitories
{
    public interface IFeedBackRepository : IRepository<FeedBack>
    {

    }
    public class FeedBackRepository : RepositoryBase<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
