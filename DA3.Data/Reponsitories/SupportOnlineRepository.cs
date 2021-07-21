﻿using DA3.Data.Infrastrure;
using DA3.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data.Reponsitories
{
    public interface ISupportOnlineRepository : IRepository<SupportOnline>
    {

    }
    public class SupportOnlineRepository: RepositoryBase<SupportOnline>, ISupportOnlineRepository
    {
         public SupportOnlineRepository(IDbFactory dbFactory) : base(dbFactory)
         { 

         }
    }
}
