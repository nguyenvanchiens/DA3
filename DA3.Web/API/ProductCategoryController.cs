using AutoMapper;
using DA3.Model.Models;
using DA3.Sevice;
using DA3.Web.Infrastructure.Core;
using DA3.Web.Models;
using DA3Angular.Infrastructure.Core;
using DA3Angular.Infrastructure.Extensions;
using DA3Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace DA3.Web.API
{
    [RoutePrefix("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategorySevice _productCategorySevice;
        public ProductCategoryController(IErrorSevice errorSevice, IProductCategorySevice productCategorySevice)
            : base(errorSevice)
        {
            this._productCategorySevice = productCategorySevice;
        }
        [Route("getallParent")]
        public HttpResponseMessage GetParent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                //lấy ra dữ liệu bảng
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                });
                //sử dụng
               

                var ListProductCategory = _productCategorySevice.GetAll();

                var mapper = new Mapper(configuration);

                var responData = mapper.Map<List<ProductCategoryViewModel>>(ListProductCategory);

              

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responData);

                return response;
            });
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,string keyword, int page,int pageSize=10)
        {
            return CreateHttpResponse(request, () =>
            {
                //lấy ra dữ liệu bảng
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                });
                //sử dụng
                var mapper = new Mapper(configuration);

                int totalRow = 0;

                var ListProductCategory = _productCategorySevice.GetAll(keyword);

                totalRow = ListProductCategory.Count();

                var query = ListProductCategory.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
                
                var responData = mapper.Map<List<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK,paginationSet);

                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                //lấy ra dữ liệu bảng
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                });
                //sử dụng
                var mapper = new Mapper(configuration);
                
                var ListProductCategory = _productCategorySevice.GetById(id);
             
            
                var responData = mapper.Map<ProductCategory,ProductCategoryViewModel>(ListProductCategory);              

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, responData);

                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryVm);
                    _productCategorySevice.Add(newProductCategory);
                    _productCategorySevice.SaveChanges();
                    //lấy ra dữ liệu bảng
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                    });
                    //sử dụng
                    var mapper = new Mapper(configuration);
                    var responseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Put(HttpRequestMessage request, ProductCategoryViewModel productCategoryVM)
        {
            //xong rồikp lỗi ở update thôi để ae chạy thử  ch,vl ban cu de yen, ban con ko hieu thi chay kieu gi
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //để ae chạy thử 
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var productCategory = _productCategorySevice.GetById(productCategoryVM.ID);
                    productCategory.UpdateProductCategory(productCategoryVM);

                    _productCategorySevice.Update(productCategory);
                    _productCategorySevice.SaveChanges();
                    //lấy ra dữ liệu bảng
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                    });
                    //sử dụng
                    var mapper = new Mapper(configuration);
                    var responseData = mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategory);

                    response = request.CreateResponse(HttpStatusCode.Created,responseData);
                }
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request,int id)
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
                    var productCategory = _productCategorySevice.Delete(id);
                    _productCategorySevice.SaveChanges();
                    //lấy ra dữ liệu bảng
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                    });
                    //sử dụng
                    var mapper = new Mapper(configuration);
                    
                    response = request.CreateResponse(HttpStatusCode.Created, productCategory);
                }
                return response;
            });
        }
        [Route("deleteMultiple")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMultiple(HttpRequestMessage request, string checkProductCategory)
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
                    var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkProductCategory);
                    foreach(var item in listProductCategory)
                    {
                        var productCategory = _productCategorySevice.Delete(item);
                    }
                   
                    _productCategorySevice.SaveChanges();
                    //lấy ra dữ liệu bảng
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                    });
                    //sử dụng
                    var mapper = new Mapper(configuration);

                    response = request.CreateResponse(HttpStatusCode.OK, listProductCategory.Count);
                }
                return response;
            });
        }
    }
}
