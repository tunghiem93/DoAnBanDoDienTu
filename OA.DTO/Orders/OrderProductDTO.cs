﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Orders
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public float Prices { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
    }
}
