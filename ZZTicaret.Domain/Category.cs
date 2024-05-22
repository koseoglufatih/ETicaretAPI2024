using ZZTicaret.Domain.Common;

namespace ZZTicaret.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
