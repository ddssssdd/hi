using ShiftBusiness.Hospital;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Service
{
    public class EmployeeService:Base.BaseService<Employee>
    {
        public EmployeeService()
            : base()
        { }
        public override bool Insert(Employee entity)
        {
            if (base.Insert(entity))
            {
                UpdateShiftType(entity);
                return true;
            }
            return false;
        }
        public override bool Update(Employee entity)
        {
            if (base.Update(entity))
            {
                UpdateShiftType(entity);
                return true;
            }
            return false;
        }
        #region Employe Shift Type 
        public List<ShiftType> ShiftTypes(Employee emp)
        {
            //should base on settings and rules to get right list;

            var types= db.ShiftTypes.ToList();
            
            foreach (var t in types)
            {
                if ((emp!=null)  && (emp.ShiftTypes.Find(st => st.ShiftTypeId == t.Id)!=null)) {
                    t.isUsed = true;
                }
                else
                {
                    t.isUsed = false;
                }
            }
            return types;
        }
        public void UpdateShiftType(Employee emp)
        {
            db.Database.ExecuteSqlCommand("Delete From EmployeeShiftTypes where EmployeeId=@id", new SqlParameter {ParameterName="@id",Value=emp.Id});
            if (emp.FormShiftTypes!=null)
            {
                //String[] ids = emp.FormShiftTypes.Split(',');
                foreach (var id in emp.FormShiftTypes)
                {
                    AddShiftTypeToEmployee(int.Parse(id), emp.Id);
                }
            }
        }
        public bool AddShiftTypeToEmployee(int ShiftTypeId, int EmployeeId)
        {
            //should do the verify
            EmployeeShiftType es = new EmployeeShiftType();
            es.EmployeeId = EmployeeId;
            es.CreatorId = 1;
            es.ShiftTypeId = ShiftTypeId;
            es.CreatedDate = DateTime.Now;
            es.LastUpdatedDate = DateTime.Now;
            db.EmployeeShiftTypes.Add(es);
            return db.SaveChanges() > 0;
        }
        public bool RemoveShiftTypeFromEmployee(int EmployeeId, int ShiftTypeId)
        {
            var items = db.EmployeeShiftTypes.Where(es => es.EmployeeId == EmployeeId && es.ShiftTypeId == ShiftTypeId);
            if (items != null && items.Count() > 0)
            {
                var es = items.First();
                db.EmployeeShiftTypes.Remove(es);
                return db.SaveChanges() > 0;
            }
            return false;
        }
        #endregion
    }
}
