namespace Inoflix.Web.Application.Contracts.RequestResponse
{
    public interface IBaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
