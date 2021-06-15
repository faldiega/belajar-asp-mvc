using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMembershipVM
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(35)]
        public string CustomerName { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}