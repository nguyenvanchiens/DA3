using AutoMapper;
using DA3.Model.Models;
using DA3.Sevice;
using DA3.Web.Infrastructure.Core;
using DA3.Web.Models;
using DA3Angular.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DA3Angular.Infrastructure.Extensions;

namespace DA3.Web.API
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        IProductSevice _productSevice;
        public ProductController(IErrorSevice errorSevice, IProductSevice productSevice)
            : base(errorSevice)
        {
            this._productSevice = productSevice;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respon = null;

                int totalRow = 0;

                var listProduct = _productSevice.GetAll(keyword);

                totalRow = listProduct.Count();

                var query = listProduct.OrderBy(x => x.CreatedBy).Skip(page * pageSize).Take(pageSize);

                var configuration = new MapperConfiguration(cfg =>
                 {
                     cfg.CreateMap<Product, ProductViewModel>();
                 });

                var mapper = new Mapper(configuration);

                var responData = mapper.Map<List<ProductViewModel>>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                respon = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return respon;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Getbyid(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respon = null;

                var product = _productSevice.GetById(id);

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>();
                });

                var mapper = new Mapper(configuration);

                var responData = mapper.Map<Product, ProductViewModel>(product);

                respon = request.CreateResponse(HttpStatusCode.OK, responData);

                return respon;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respon = null;

                var Product = new Product();

                Product.UpdateProduct(productVM);

                _productSevice.Add(Product);
                _productSevice.Save();




                respon = request.CreateResponse(HttpStatusCode.OK);

                return respon;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productVM)
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
                    //lấy ra sản phẩm có id 
                    var product = _productSevice.GetById(productVM.ID);
                    //update dữ liệu cũ thành dữ liệu mới
                    product.UpdateProduct(productVM);

                    _productSevice.Update(product);
                    _productSevice.Save();
                    //lấy ra dữ liệu bảng
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Product, ProductViewModel>();
                    });
                    //sử dụng
                    var mapper = new Mapper(configuration);
                    var responseData = mapper.Map<Product, ProductViewModel>(product);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage respon = null;

               
                var product = _productSevice.Delete(id);
                _productSevice.Save();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>();
                });
                //sử dụng
                var mapper = new Mapper(configuration);
                var responseData = mapper.Map<Product, ProductViewModel>(product);
                respon = request.CreateResponse(HttpStatusCode.OK, responseData);

                return respon;
            });
        }
    }

}
