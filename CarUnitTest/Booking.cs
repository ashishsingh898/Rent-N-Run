﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CarUnitTest
{
    public partial class Booking
    {
        public int RentId { get; set; }
        public int? CarId { get; set; }
        public string Email { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? Amount { get; set; }

        public virtual Car Car { get; set; }
        public virtual Signup EmailNavigation { get; set; }
    }
}