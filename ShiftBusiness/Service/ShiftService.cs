using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Service
{
    public class ShiftService:Base.BaseService<ShiftBusiness.Shift.Shift>
    {
        public ShiftService()
            : base()
        {

        }
        public override void BeforeInsert(Shift.Shift shift)
        {
            shift.Version = 1;
            shift.CreatedDate = DateTime.Now;
            shift.LastUpdatedDate = DateTime.Now;
            shift.CreatorId = 1;
        }
        public override void BeforeUpdate(Shift.Shift shift)
        {
            shift.Version = shift.Version + 1;

            shift.LastUpdatedDate = DateTime.Now;
            shift.CreatorId = 1;
        }
        
    }
}
