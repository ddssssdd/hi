using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class EmployeeShiftType
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        
        public int CreatorId { get; set; }

        [NotMapped]
        public String ShiftTypeName { get; set; }
    }
}
