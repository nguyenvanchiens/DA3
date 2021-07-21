using AutoMapper;
using DA3.Model.Models;
using DA3.Model;
using DA3Angular.Models;
using DA3.Web.Models;

namespace DA3Angular.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewCategory, NewCategoryViewModel>();
                cfg.CreateMap<News,NewsViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
            });
        }
    }
}