using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class MembershipType
    {
        [Key]
        [Display(Name ="Membership Type")]
        public int MembershipTypeId { get; set; }

        public string MembershipName { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsUgo = 1;

    }
}