namespace DienLanh_BackEnd.Models
{
    public class Product
    {
        public string? ProductID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
