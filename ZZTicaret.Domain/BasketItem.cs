using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Domain.Common;

namespace ZZTicaret.Domain
{
    public class BasketItem : BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Basket Basket { get; set; } 
        public virtual Product Product { get; set; } 
    }
}
