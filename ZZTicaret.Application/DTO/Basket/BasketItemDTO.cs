using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application.DTO.Basket
{
    public class BasketItemDTO
    {
        public Guid BasketId { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal Price { get; set; }

        public virtual Domain.Basket Basket { get; set; }

        

    }
}
