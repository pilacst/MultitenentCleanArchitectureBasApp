namespace Inoflix.Web.Application.Contracts.Service
{
    public interface IInoflixLicenseService : IBaseService
    {
        Task<string> GetLicenseAsync();
    }
}
