using ZZTicaret.Domain.Common;

namespace ZZTicaret.Domain
{
    public class User : BaseEntity
    {
        public string NameSurname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }     
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();



    }
}
