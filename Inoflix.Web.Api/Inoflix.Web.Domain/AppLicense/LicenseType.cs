using Inoflix.Web.Domain.Common;

namespace Inoflix.Web.Domain.AppLicense
{
    public class LicenseType: BaseEntity<int>
    {
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
