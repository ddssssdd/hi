using ShiftBusiness.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class ShiftType:BaseEntityWithDepartment
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String BriefName { get; set; }

        [NotMapped]
        public bool isUsed { get; set; }
        
    }
}
