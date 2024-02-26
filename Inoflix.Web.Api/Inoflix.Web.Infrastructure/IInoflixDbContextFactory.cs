namespace Inoflix.Web.Infrastructure
{
    public interface IInoflixDbContextFactory
    {
        InoflixDbContext Create();
    }
}
