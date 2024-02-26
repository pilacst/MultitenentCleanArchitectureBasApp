using Inoflix.Web.Application.Contracts.Repository;
using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Helpers;

namespace Inoflix.Web.Application.Services
{
    [InoflixDIRegistyService(typeof(IInoflixLicenseService), LifetimeOfService.Scoped)]
    public class InoflixLicenseService : IInoflixLicenseService
    {
        private readonly IInoflixLicenseRepository _inoflixLicenseRepository;

        public InoflixLicenseService(IInoflixLicenseRepository inoflixLicenseRepository)
        {
            _inoflixLicenseRepository = inoflixLicenseRepository;
        }

        public async Task<string?> GetLicenseAsync()
        {
            var result =  await _inoflixLicenseRepository.GetInoflixLicenseAsync(11);

            return result?.FirstOrDefault()?.LicenseType;
        }
    }
}
