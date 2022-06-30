﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CarUnitTest
{
    public partial class Car
    {
        public Car()
        {
            Bookings = new HashSet<Booking>();
            Carts = new HashSet<Cart>();
        }

        public int CarId { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public int NumberOfPersons { get; set; }
        public int DailyRent { get; set; }
        public string Images { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}