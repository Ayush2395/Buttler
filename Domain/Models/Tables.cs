﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Tables
    {
        public Tables()
        {
            OrderMaster = new HashSet<OrderMaster>();
        }

        public int TableId { get; set; }
        public string TableNumber { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderMaster> OrderMaster { get; set; }
    }
}