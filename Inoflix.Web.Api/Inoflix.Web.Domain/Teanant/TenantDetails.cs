using Inoflix.Web.Domain.AppLicense;
using Inoflix.Web.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inoflix.Web.Domain.Teanant
{
    public class TenantDetails: BaseEntity<int>
    {
        public string? Code { get; set; } = null;
        public string? Name { get; set; } = null;
        public int? LicenseId { get; set; } = null;
        [ForeignKey("LicenseId")]
        public InoflixLicense InoflixLicense { get; set; } = new InoflixLicense();
    }
}
