using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembershipLearning.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public String Password { get; set; }

        public String ConfirmPassword { get; set; }
    }
}