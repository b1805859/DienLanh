namespace DienLanh_BackEnd.Models
{
    public class Blog
    {
        public string? BlogID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Source { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
