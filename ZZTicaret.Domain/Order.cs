using ZZTicaret.Domain.Common;

namespace ZZTicaret.Domain
{
    public class Order : BaseEntity
    {
      
        public Guid UserId { get; set; }  
        public DateTime OrderDate { get; set; }         
        public DateTime CreateDate { get; set; }
        public decimal TotalAmount { get; set; }



        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual User User { get; set; }
       
    }
}
