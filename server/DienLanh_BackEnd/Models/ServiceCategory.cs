namespace DienLanh_BackEnd.Models
{
    public class ServiceCategory
    {
        public string? ServiceCategoryID { get; set; }
        public string? Title { get; set; }
        public List<Service>? Services { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
