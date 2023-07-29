namespace DienLanh_BackEnd.Models
{
    public class ProductCategory
    {
        public string? ProductCategoryID { get; set; }
        public string? Title { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
