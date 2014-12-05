using ShiftBusiness.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class Employee:BaseEntityWithDepartment
    {
        
        public int Id { get; set; }
       
        public String Name { get; set; }
        public String WorkNo { get; set; }
        public String CellPhone { get; set; }
        public String officePhone { get; set; }
        public String Address { get; set; }
        public String IdentityNo { get; set; }
        private List<EmployeeShiftType> _shiftTypes;
        public List<EmployeeShiftType> ShiftTypes {

            get {
                if (_shiftTypes == null)
                {
                    using (var db = new ShiftContext())
                    {
                        _shiftTypes = db.EmployeeShiftTypes.Where(es => es.EmployeeId == Id).ToList();
                    }
                    
                }
                return _shiftTypes;
            }
       }
        [NotMapped]
        public String[] FormShiftTypes { get; set; }
        [NotMapped]
        public bool isInGroup { get; set; }
    }
}
