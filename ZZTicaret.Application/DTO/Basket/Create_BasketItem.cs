﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZTicaret.Application.DTO.Basket
{
    public class Create_BasketItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string Productname {  get; set; }
        public int UnitPrice {  get; set; }
    }
}
