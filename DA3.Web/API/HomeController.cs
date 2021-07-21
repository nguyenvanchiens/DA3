using DA3.Sevice;
using DA3Angular.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DA3.Web.API
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorSevice _errorSevice;
        public HomeController(IErrorSevice errorSevice) : base(errorSevice)
        {
            this._errorSevice = errorSevice;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "trả về demo ";
        }
    }
}
