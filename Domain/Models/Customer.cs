﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            OrderMaster = new HashSet<OrderMaster>();
            Tables = new HashSet<Tables>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerPhoneNumber { get; set; }

        public virtual ICollection<OrderMaster> OrderMaster { get; set; }
        public virtual ICollection<Tables> Tables { get; set; }
    }
}