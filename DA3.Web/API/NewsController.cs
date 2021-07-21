using AutoMapper;
using DA3.Data.Reponsitories;
using DA3.Model.Models;
using DA3.Sevice;
using DA3Angular.Infrastructure.Core;
using DA3Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DA3.Web.API
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiControllerBase
    {
        INewsRepository _newsRepository;
        public NewsController(IErrorSevice error,INewsRepository newsRepository) : base(error)
        {
            this._newsRepository = newsRepository;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respon = null;

                var Listnew = _newsRepository.GetAll();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<News, NewsViewModel>();
                });
                var mapper = new Mapper(configuration);

                var responData = mapper.Map<List<NewsViewModel>>(Listnew);

                respon = request.CreateResponse(HttpStatusCode.OK, responData);

                return respon;
            });
        }

    }
}
