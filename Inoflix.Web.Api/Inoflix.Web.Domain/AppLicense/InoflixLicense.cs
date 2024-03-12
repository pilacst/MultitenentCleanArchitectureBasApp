using System.ComponentModel.DataAnnotations.Schema;

namespace Inoflix.Web.Domain.AppLicense
{
    public class InoflixLicense
    {
        public int Id { get; set; }
        public int LicenseTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("LicenseTypeId")]
        public LicenseType? LicenseType { get; set; } = null;
    }
}
