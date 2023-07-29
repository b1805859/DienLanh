using DienLanh_BackEnd.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_Service
    {
        public List<Service> GetServices();
        public Service GetServiceDetails(string id);
        public bool AddService(Service service);
        public bool UpdateService(Service service);
        public bool DeleteService(string id);
    }
}
