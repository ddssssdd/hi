using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class ShiftTypePlan
    {
        public int Id { get; set; }
        public int ShiftTypeId { get; set; }
        public int ShiftPlanId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        
        public int CreatorId { get; set; }
    }
}
