namespace DienLanh_BackEnd.Models
{
    public class Service
    {
        public string? ServiceID { get; set; }

        public string? Image { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public Blog? ServiceCategory { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
