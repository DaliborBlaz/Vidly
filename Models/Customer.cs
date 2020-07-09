﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedtoNewsletter{ get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

       
        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }
    }
}