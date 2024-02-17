namespace Inoflix.Web.Domain.Common
{
    public class BaseEntity<TId>: IBaseEntity
    {
        public TId Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
