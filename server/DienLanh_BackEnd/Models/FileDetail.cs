namespace DienLanh_BackEnd.Models
{
    public class FileDetail
    {
        public string? FileID { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
