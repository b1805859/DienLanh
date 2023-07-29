using DienLanh_BackEnd.Common;
using DienLanh_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI_JWT_NET6_Base.Models;
using WebAPI_JWT_NET6_Base.Services;

namespace WebAPI_JWT_NET6_Base.Business
{
    public class B_ServiceCategory : S_ServiceCategory
    {
        readonly DatabaseContext _dbContext = new();

        public B_ServiceCategory(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddServiceCategory(ServiceCategory serviceCategory)
        {
            try
            {
                serviceCategory.ServiceCategoryID = C_Function.randomID();
                serviceCategory.CreatedDate = DateTime.Now;
                serviceCategory.UpdatedDate = DateTime.Now;

                _dbContext.ServiceCategorys!.Add(serviceCategory);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteServiceCategory(string id)
        {
            bool result = false;
            try
            {
                ServiceCategory serviceCategorys = _dbContext.ServiceCategorys!.Find(id)!;

                if (serviceCategorys != null)
                {
                    _dbContext.ServiceCategorys.Remove(serviceCategorys);
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

        public ServiceCategory GetServiceCategoryDetails(string id)
        {
            try
            {
                ServiceCategory serviceCategory = _dbContext.ServiceCategorys!.Find(id)!;

                return serviceCategory;

            }
            catch
            {
                return null;
            }
        }

        public List<ServiceCategory> GetServiceCategorys()
        {
            try
            {
                return _dbContext.ServiceCategorys!.ToList();
            }
            catch
            {
                return new List<ServiceCategory>();
            }
        }

        public bool UpdateServiceCategory(ServiceCategory serviceCategory)
        {
            try
            {
                serviceCategory.UpdatedDate = DateTime.Now;

                _dbContext.Entry(serviceCategory).State = EntityState.Modified;
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
