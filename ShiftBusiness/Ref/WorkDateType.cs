using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Ref
{
    public class WorkDateType
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Year { get; set; }

        
    }
}
