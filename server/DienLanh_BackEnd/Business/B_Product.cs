using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_Product : S_Product
    {
        readonly DatabaseContext _dbContext = new();

        public B_Product(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddProduct(Product product)
        {
            try
            {
                product.ProductID = C_Function.randomID();
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;

                _dbContext.Products!.Add(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteProduct(string id)
        {
            bool result = false;
            try
            {
                Product products = _dbContext.Products!.Find(id)!;

                if (products != null)
                {
                    _dbContext.Products.Remove(products);
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

        public Product GetProductDetails(string id)
        {
            try
            {
                Product product = _dbContext.Products!.Find(id)!;

                return product;

            }
            catch
            {
                return null;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _dbContext.Products!.ToList();
            }
            catch
            {
                return new List<Product>();
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                product.UpdatedDate = DateTime.Now;

                _dbContext.Entry(product).State = EntityState.Modified;
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
