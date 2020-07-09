using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class NewCustomerViewModel
    {
        
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

     
        public Customer Customer { get; set; }
    }
}