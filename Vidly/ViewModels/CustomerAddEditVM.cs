﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerAddEditVM
    {
        public Customers Customer { get; set; }
        public IEnumerable<MembershipType> MembershipType { get; set; }
    }
}