using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.User;

namespace ZZTicaret.Application.DTO.Basket
{
    public class BasketDto
    {
        public Guid UserId { get; set; }
        public List<BasketItemDTO> BasketItems { get; set; }
        public UserDto User { get; set; }
    }
}
