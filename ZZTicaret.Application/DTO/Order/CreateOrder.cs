using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application.DTO.Order
{
    public class CreateOrder
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
