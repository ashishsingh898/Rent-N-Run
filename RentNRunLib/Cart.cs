﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RentNRunLib
{
    public partial class Cart
    {
        public int RentId { get; set; }
        public int? CarId { get; set; }
        public string Email { get; set; }

        public virtual Car Car { get; set; }
        public virtual Signup EmailNavigation { get; set; }
    }
}