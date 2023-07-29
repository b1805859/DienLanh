using DienLanh_BackEnd.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_ProductCategory
    {
        public List<ProductCategory> GetProductCategorys();
        public ProductCategory GetProductCategoryDetails(string id);
        public bool AddProductCategory(ProductCategory productCategory);
        public bool UpdateProductCategory(ProductCategory productCategory);
        public bool DeleteProductCategory(string id);
    }
}
