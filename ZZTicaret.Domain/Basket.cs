using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Domain.Common;

namespace ZZTicaret.Domain
{
    public class Basket : BaseEntity
    {
        public Guid UserId { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public virtual User User { get; set; } 
        
    }
}
