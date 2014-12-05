using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class Department
    {
        private Department _parent;
        public int Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Area { get; set; }
        [NotMapped]
        public Department Parent {
            get
            {
                if (_parent == null || _parent.Id != Parent_Id)
                {
                    using (var db = new ShiftContext())
                    {
                        _parent = db.Departments.Find(Parent_Id);
                    }
                }
                return _parent;
            }    
        }

        
        public int? Parent_Id { get; set; }
        public List<Department> departs()
        {
            using (var db = new ShiftContext())
            {
                return db.Departments.ToList();
            }
        }

    }
}
