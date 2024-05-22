using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Order;

namespace ZZTicaret.Application.DTO.User
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
