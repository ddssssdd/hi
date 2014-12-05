using ShiftBusiness.Hospital;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftBusiness.Ref;

namespace ShiftBusiness
{
    public class ShiftContext: DbContext
    {
        public  ShiftContext()
            : base("ShiftConnection")
        {
 
        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<ShiftBusiness.Hospital.ShiftType> ShiftTypes { get; set; }

        public System.Data.Entity.DbSet<ShiftBusiness.Hospital.ShiftPlan> ShiftPlans { get; set; }

        public System.Data.Entity.DbSet<ShiftBusiness.Hospital.ShiftPlanException> ShiftPlanExceptions { get; set; }

        public System.Data.Entity.DbSet<ShiftBusiness.Hospital.EmployeeGroup> EmployeeGroups { get; set; }
        public DbSet<GroupDetail> GroupDetails { get; set; }

        public System.Data.Entity.DbSet<ShiftBusiness.Shift.Shift> Shifts { get; set; }

        public DbSet<EmployeeShiftType> EmployeeShiftTypes { get; set; }

        public DbSet<ShiftTypePlan> ShiftTypePlans { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<WorkDateType> WorkDateTypes { get; set; }

        public System.Data.Entity.DbSet<ShiftBusiness.Shift.EmployeeExclude> EmployeeExcludes { get; set; }
    }
}
