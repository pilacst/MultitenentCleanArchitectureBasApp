using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Helpers;

namespace Inoflix.Web.Application.Services
{
    [InoflixDIRegistyService(typeof(IInoflixLicenseService), LifetimeOfService.Scoped)]
    public class InoflixLicenseService : IInoflixLicenseService
    {
        public Task<string> GetLicenseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
