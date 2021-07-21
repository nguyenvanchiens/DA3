using DA3.Model.Models;
using DA3.Web.Models;
using DA3Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA3Angular.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateNewCategory(this NewCategory newCategory,NewCategoryViewModel categoryVM)
        {
            newCategory.ID = categoryVM.ID;
            newCategory.Name = categoryVM.Name;
            newCategory.Alias = categoryVM.MetaTitle;
            newCategory.DisplayOrder = categoryVM.DisplayOrder;
            newCategory.CreatedDate = categoryVM.CreatedDate;
            newCategory.CreatedBy = categoryVM.CreatedBy;
            newCategory.ModifiedDate = categoryVM.ModifiedDate;
            newCategory.ModifiedBy = categoryVM.ModifiedBy;
            newCategory.MetaKeywords = categoryVM.MetaKeywords;
            newCategory.MetaDescriptions = categoryVM.MetaDescriptions;
            newCategory.Status = categoryVM.Status;          
        }
        public static void UpdateNews(this News news, NewsViewModel newsVM)
        {
            news.ID = newsVM.ID;
            news.Name = newsVM.Name;
            news.Alias = newsVM.Alias;
            news.Description = newsVM.Description;
            news.Image = newsVM.Image;
            news.Description = newsVM.Description;
            news.Content = newsVM.Content;
            news.NewCategoryID = newsVM.NewCategoryID;
            news.CreatedDate = newsVM.CreatedDate;
            news.CreatedBy = newsVM.CreatedBy;
            news.ModifiedDate = newsVM.ModifiedDate;
            news.ModifiedBy = newsVM.ModifiedBy;
            news.MetaKeywords = newsVM.MetaKeywords;
            news.MetaDescriptions = newsVM.MetaDescriptions;
            news.Status = newsVM.Status;           
        }
        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVM)
        {
            productCategory.ID = productCategoryVM.ID;
            productCategory.Name = productCategoryVM.Name;
            productCategory.Alias = productCategoryVM.Alias;
            productCategory.Icon = productCategoryVM.Icon;
            productCategory.DisplayOrder = productCategoryVM.DisplayOrder;
            productCategory.Description = productCategoryVM.Description;         
            productCategory.CreatedDate = productCategoryVM.CreatedDate;
            productCategory.CreatedBy = productCategoryVM.CreatedBy;
            productCategory.ModifiedDate = productCategoryVM.ModifiedDate;
            productCategory.ModifiedBy = productCategoryVM.ModifiedBy;
            productCategory.MetaKeywords = productCategoryVM.MetaKeywords;
            productCategory.MetaDescriptions = productCategoryVM.MetaDescriptions;
            productCategory.Status = productCategoryVM.Status;
            
        }
        public static void UpdateProduct(this Product product, ProductViewModel productVM)
        {
            product.ID = productVM.ID;
            product.Name = productVM.Name;
            product.Alias = productVM.Alias;
            product.Image = productVM.Image;
            product.MoreImage = productVM.MoreImage;
            product.Price = productVM.Price;
            product.Promotion = productVM.Promotion;
            product.Quantity = productVM.Quantity;
            product.Warranty = productVM.Warranty;
            product.Content = productVM.Content;
            product.ProductCategoryID = productVM.ProductCategoryID;
            product.Description = productVM.Description;          
            product.CreatedDate = productVM.CreatedDate;
            product.CreatedBy = productVM.CreatedBy;
            product.ModifiedDate = productVM.ModifiedDate;
            product.ModifiedBy = productVM.ModifiedBy;
            product.MetaKeywords = productVM.MetaKeywords;
            product.MetaDescriptions = productVM.MetaDescriptions;
            product.Status = productVM.Status;          
        }

    }
}