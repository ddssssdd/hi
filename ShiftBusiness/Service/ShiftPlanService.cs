using ShiftBusiness.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Service
{
    public class ShiftPlanService : Base.BaseService<ShiftPlan>
    {
        public ShiftPlanService()
            : base()
        {

        }
        private Base.BaseService<ShiftPlanException> _ShiftPlanExceptions;
        public Base.BaseService<ShiftPlanException> ShiftPlanExceptions
        {
            get
            {
                if (_ShiftPlanExceptions == null)
                {
                    _ShiftPlanExceptions = new Base.BaseService<ShiftPlanException>();
                }
                return _ShiftPlanExceptions;
            }
        }
        public override void Dispose(){
            if (_ShiftPlanExceptions != null)
            {
                _ShiftPlanExceptions.Dispose();
            }
            base.Dispose();
        }
    }
}
