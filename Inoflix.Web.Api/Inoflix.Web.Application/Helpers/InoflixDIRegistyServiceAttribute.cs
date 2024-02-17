namespace Inoflix.Web.Application.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InoflixDIRegistyServiceAttribute: Attribute
    {
        public Type ServiceInterface { get; set; }
        public LifetimeOfService Lifetime { get; set; } = LifetimeOfService.Scoped;

        public InoflixDIRegistyServiceAttribute(Type ServiceInterface, LifetimeOfService ServiceLifetime)
        {
            this.ServiceInterface = ServiceInterface;
            this.Lifetime = ServiceLifetime;
        }
    }

    public enum LifetimeOfService
    {
        Transient = 1,
        Scoped = 2,
        Singleton = 3
    }
}
