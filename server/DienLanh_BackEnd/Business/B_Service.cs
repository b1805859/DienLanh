using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_Service : S_Service
    {
        readonly DatabaseContext _dbContext = new();

        public B_Service(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddService(Service service)
        {
            try
            {
                service.ServiceID = C_Function.randomID();
                service.CreatedDate = DateTime.Now;
                service.UpdatedDate = DateTime.Now;

                while (_dbContext.Services!.Any(serviceDB => serviceDB.ServiceID == service.ServiceID))
                {
                    service.ServiceID = C_Function.randomID();
                }

                _dbContext.Services!.Add(service);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteService(string id)
        {
            bool result = false;
            try
            {
                Service services = _dbContext.Services!.Find(id)!;

                if (services != null)
                {
                    _dbContext.Services.Remove(services);
                    _dbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                return false;
            }
        }

        public Service GetServiceDetails(string id)
        {
            try
            {
                Service service = _dbContext.Services!.Find(id)!;

                return service;

            }
            catch
            {
                return null;
            }
        }

        public List<Service> GetServices()
        {
            try
            {
                return _dbContext.Services!.OrderBy(x => x.Title).ToList();
            }
            catch
            {
                return new List<Service>();
            }
        }

        public bool UpdateService(Service service)
        {
            try
            {
                service.UpdatedDate = DateTime.Now;

                _dbContext.Entry(service).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
