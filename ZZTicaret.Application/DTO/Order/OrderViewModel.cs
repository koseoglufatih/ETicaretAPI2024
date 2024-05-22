using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application.DTO.Order
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
