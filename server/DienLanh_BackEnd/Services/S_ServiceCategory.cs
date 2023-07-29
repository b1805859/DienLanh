using DienLanh_BackEnd.Models;

namespace WebAPI_JWT_NET6_Base.Services
{
    public interface S_ServiceCategory
    {
        public List<ServiceCategory> GetServiceCategorys();
        public ServiceCategory GetServiceCategoryDetails(string id);
        public bool AddServiceCategory(ServiceCategory serviceCategory);
        public bool UpdateServiceCategory(ServiceCategory serviceCategory);
        public bool DeleteServiceCategory(string id);
    }
}
