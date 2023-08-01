using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using DienLanh_BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;

namespace DienLanh_BackEnd.Business
{
    public class B_FileDetail : S_FileDetail
    {
        private readonly DatabaseContext _dbContext;

        public B_FileDetail(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var fileDetails = new FileDetail()
                {
                    FileID = C_Function.randomFileID(),
                    FileName = fileData.FileName,
                    UpdatedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                };

                while (_dbContext.FileDetails!.Any(FileDetailDB => FileDetailDB.FileID == fileDetails.FileID))
                {
                    fileDetails.FileID = C_Function.randomFileID();
                }

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _dbContext.FileDetails.Add(fileDetails);

                await _dbContext.SaveChangesAsync();

                await DownloadFileByName(fileDetails.FileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostMultiFileAsync(List<IFormFile> fileData)
        {
            try
            {
                foreach (IFormFile file in fileData)
                {
                    var fileDetails = new FileDetail()
                    {
                        FileID = C_Function.randomFileID(),
                        FileName = file.FileName,
                        UpdatedDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                    };


                    while (_dbContext.FileDetails!.Any(FileDetailDB => FileDetailDB.FileID == fileDetails.FileID))
                    {
                        fileDetails.FileID = C_Function.randomFileID();
                    }


                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
                        fileDetails.FileData = stream.ToArray();
                    }

                    var result = _dbContext.FileDetails.Add(fileDetails);
                    await _dbContext.SaveChangesAsync();
                    await DownloadFileByName(fileDetails.FileName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DownloadFileByName(string fileName)
        {
            try
            {
                var file = _dbContext.FileDetails.Where(x => x.FileName == fileName).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result!.FileData!);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "wwwroot/img", file.Result.FileName!);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }


    }
}
