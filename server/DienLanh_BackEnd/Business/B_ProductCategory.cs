using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_ProductCategory : S_ProductCategory
    {
        readonly DatabaseContext _dbContext = new();

        public B_ProductCategory(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddProductCategory(ProductCategory productCategory)
        {
            try
            {
                productCategory.ProductCategoryID = C_Function.randomID();
                productCategory.CreatedDate = DateTime.Now;
                productCategory.UpdatedDate = DateTime.Now;

                _dbContext.ProductCategorys!.Add(productCategory);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteProductCategory(string id)
        {
            bool result = false;
            try
            {
                ProductCategory productCategorys = _dbContext.ProductCategorys!.Find(id)!;

                if (productCategorys != null)
                {
                    _dbContext.ProductCategorys.Remove(productCategorys);
                    _dbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                return false;
            }
        }

        public ProductCategory GetProductCategoryDetails(string id)
        {
            try
            {
                ProductCategory productCategory = _dbContext.ProductCategorys!.Find(id)!;

                return productCategory;

            }
            catch
            {
                return null;
            }
        }

        public List<ProductCategory> GetProductCategorys()
        {
            try
            {
                return _dbContext.ProductCategorys!.ToList();
            }
            catch
            {
                return new List<ProductCategory>();
            }
        }

        public bool UpdateProductCategory(ProductCategory productCategory)
        {
            try
            {
                productCategory.UpdatedDate = DateTime.Now;

                _dbContext.Entry(productCategory).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
