﻿using OA.Entity.Carts;
using OA.Entity.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entity.Users
{
    public class UsersEntities
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public int IsActive { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CartsEntities> Carts { get; set; }
        public virtual ICollection<OrderEntities> Orders { get; set; }
    }
}
