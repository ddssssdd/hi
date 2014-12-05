using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembershipLearning.Models
{
    public class LocalPasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}