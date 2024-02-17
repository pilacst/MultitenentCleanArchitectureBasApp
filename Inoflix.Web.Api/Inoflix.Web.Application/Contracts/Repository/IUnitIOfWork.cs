namespace Inoflix.Web.Application.Contracts.Repository
{
    public interface IUnitIOfWork
    {
        Task<int> CommitAsync();

        ValueTask RollbackAsync();
    }
}
