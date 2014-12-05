using ShiftBusiness.Hospital;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Service
{
    public class EmployeeGroupService:Base.BaseService<ShiftBusiness.Hospital.EmployeeGroup>
    {
        public EmployeeGroupService()
            : base()
        {

        }
        public override void BeforeInsert(Hospital.EmployeeGroup entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.LastUpdatedDate = DateTime.Now;
            entity.CreatorId = 1;
        }
        public override void BeforeUpdate(Hospital.EmployeeGroup entity)
        {
            entity.LastUpdatedDate = DateTime.Now;
            entity.CreatorId = 1;
        }
        public override void AfterInsert(EmployeeGroup entity)
        {
            AddDetailsFromForm(entity);
        }
        public override void AfterUpdate(EmployeeGroup entity)
        {
            AddDetailsFromForm(entity);
        }
        public List<Employee> employees(int departId)
        {
            var list = db.Employees.Where(ep => ep.DepartmentId == departId).ToList();
            return list;
        }
        #region Group Details actions
        public List<Employee> details(EmployeeGroup eg,int departId)
        {
            var results = employees(departId);
            foreach (var emp in results)
            {
                if (eg != null && eg.Employees!=null && eg.Employees.Find(gd => gd.EmployeeId == emp.Id)!=null)
                {
                    emp.isInGroup = true;
                }
                else
                {
                    emp.isInGroup = false;
                }
            }
            return results;
        }
        public void AddDetailsFromForm(EmployeeGroup eg)
        {
            db.Database.ExecuteSqlCommand("Delete From GroupDetails where EmployeeGroupId=@id", new SqlParameter { ParameterName = "@id", Value = eg.Id });
            if (eg.FormDetails != null)
            {
                foreach (var id in eg.FormDetails)
                {
                    var gd = new GroupDetail();
                    gd.EmployeeGroupId = eg.Id;
                    gd.EmployeeId = int.Parse(id);
                    gd.CreatorId = 1;
                    gd.CreatedDate = DateTime.Now;
                    db.GroupDetails.Add(gd);
                }
                db.SaveChanges();
            }
        }

        #endregion
    }
}
