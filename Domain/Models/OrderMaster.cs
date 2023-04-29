﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class OrderMaster
    {
        public OrderMaster()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderMasterId { get; set; }
        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
        public string StaffId { get; set; }
        public string OrderStatus { get; set; }
        public decimal? Bill { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Staffs Staff { get; set; }
        public virtual Tables Table { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}