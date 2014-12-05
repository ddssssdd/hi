using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class EmployeeGroup
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int DepartmentId { get; set; }
        public int CreatorId { get; set; }
        private List<GroupDetail> _employees;
        public List<GroupDetail> Employees
        {
            get
            {
                if (_employees == null)
                {
                    using(var db  = new ShiftContext()){
                        _employees = db.GroupDetails.Where(gd => gd.EmployeeGroupId == this.Id).ToList();
                    }
                    
                }
                return _employees;
            }
        }
        [NotMapped]
        public String[] FormDetails { get; set; }
    }

    public class GroupDetail
    {
        public int Id { get; set; }
        public int EmployeeGroupId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        
        public int CreatorId { get; set; }
    }
    
}
