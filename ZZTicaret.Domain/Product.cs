using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Domain.Common;

namespace ZZTicaret.Domain
{
    public class Product : BaseEntity
    {

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }      
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();



    }
}
