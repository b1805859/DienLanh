using DienLanh_BackEnd.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_Product
    {
        public List<Product> GetProducts();
        public Product GetProductDetails(string id);
        public bool AddProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(string id);
    }
}
