using DA3.Model.Models;
using DA3.Sevice;
using DA3Angular.Infrastructure.Core;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DA3Angular.Models;
using DA3Angular.Mappings;
using DA3Angular.Infrastructure.Extensions;
using AutoMapper;
using System.Linq;
using DA3.Web.Infrastructure.Core;
using System;

namespace DA3Angular.API
{
    [RoutePrefix("api/newcategory")]
    public class NewCategoryController : ApiControllerBase
    {
        INewCategorySevice _newCategorySevice;
        public NewCategoryController(IErrorSevice errorSevice, INewCategorySevice newCategorySevice) : base(errorSevice)
        {

            this._newCategorySevice = newCategorySevice;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var Category = _newCategorySevice.GetAll(keyword);
                totalRow = Category.Count();
                var listProduct = Category.OrderBy(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                //lấy ra dữ liệu bảng 
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NewCategory, NewCategoryViewModel>();
                });

                //sử dụng
                var mapper = new Mapper(configuration);
                var responData = mapper.Map<List<NewCategoryViewModel>>(listProduct);

                var paginationSet = new PaginationSet<NewCategoryViewModel>
                {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)

                };

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, NewCategoryViewModel newCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    NewCategory NewCategory = new NewCategory();
                    NewCategory.UpdateNewCategory(newCategoryVm);

                    var category = _newCategorySevice.Add(NewCategory);
                    _newCategorySevice.SaveChanges();


                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Getbyid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respon = null;

                var newcategory = _newCategorySevice.GetById(id);

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NewCategory, NewCategoryViewModel>();
                });
                var mapper = new Mapper(configuration);
                var responData = mapper.Map<NewCategory, NewCategoryViewModel>(newcategory);

                respon = request.CreateResponse(HttpStatusCode.OK, responData);

                return respon;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, NewCategoryViewModel newCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var NewCategoryDb = _newCategorySevice.GetById(newCategoryVm.ID);

                    NewCategoryDb.UpdateNewCategory(newCategoryVm);

                    _newCategorySevice.Update(NewCategoryDb);

                    _newCategorySevice.SaveChanges();

                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<NewCategory, NewCategoryViewModel>();
                    });
                    var mapper = new Mapper(configuration);

                    var responData = mapper.Map<NewCategory, NewCategoryViewModel>(NewCategoryDb);

                    response = request.CreateResponse(HttpStatusCode.OK, responData);
                }
                return response;
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var Category = _newCategorySevice.Delete(id);
                    _newCategorySevice.SaveChanges();

                    var configuration = new MapperConfiguration(cfg =>
                      {
                          cfg.CreateMap<NewCategory, NewCategoryViewModel>();
                      });
                    var mapper = new Mapper(configuration);

                    var responData = mapper.Map<NewCategory, NewCategoryViewModel>(Category);

                    response = request.CreateResponse(HttpStatusCode.OK,responData);
                }
                return response;
            });
        }
    }
}