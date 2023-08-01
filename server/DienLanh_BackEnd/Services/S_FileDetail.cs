namespace DienLanh_BackEnd.Services
{
    public interface S_FileDetail
    {
        public Task PostFileAsync(IFormFile fileData);

        public Task PostMultiFileAsync(List<IFormFile> fileData);

        public Task DownloadFileByName(String fileName);
    }
}
