using ShiftBusiness.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Base
{
    public class BaseEntityWithDepartment
    {
        protected Department _department;
        public int DepartmentId { get; set; }
        public Department Department
        {
            get
            {
                if (_department == null || _department.Id != DepartmentId)
                {
                    using (var db = new ShiftContext())
                    {
                        _department = db.Departments.Find(DepartmentId);
                    }

                }
                return _department;
            }
        }
    }
}
