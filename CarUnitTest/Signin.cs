﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CarUnitTest
{
    public partial class Signin
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Signup EmailNavigation { get; set; }
    }
}