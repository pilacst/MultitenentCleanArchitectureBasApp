
using Inoflix.Web.Domain.AppLicense;

namespace Inoflix.Web.Application.Contracts.Repository
{
    public interface IInoflixLicenseRepository
    {
        public Task<IEnumerable<InoflixLicense>> GetInoflixLicenseAsync(int id);
    }
}
