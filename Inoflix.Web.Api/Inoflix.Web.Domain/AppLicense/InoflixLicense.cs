namespace Inoflix.Web.Domain.AppLicense
{
    public class InoflixLicense
    {
        public int Id { get; set; }
        public string LicenseType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
