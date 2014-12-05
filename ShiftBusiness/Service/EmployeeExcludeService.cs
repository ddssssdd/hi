using ShiftBusiness.Shift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Service
{
    public class EmployeeExcludeService:Base.BaseService<EmployeeExclude>
    {
        public EmployeeExcludeService()
            : base()
        {

        }
        public override void BeforeInsert(EmployeeExclude entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.LastUpdatedDate = DateTime.Now;
            entity.CreatorId = 1;
            base.BeforeInsert(entity);
        }
        public override void BeforeUpdate(EmployeeExclude entity)
        {
            entity.LastUpdatedDate = DateTime.Now;
            entity.CreatorId = 1;
            base.BeforeUpdate(entity);
        }
    }
}
