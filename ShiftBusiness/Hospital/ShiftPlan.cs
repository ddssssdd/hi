using ShiftBusiness.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftBusiness.Hospital
{
    public class ShiftPlan:BaseEntityWithDepartment
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        private List<ShiftPlanException> _exceptions;
        public List<ShiftPlanException> Exceptions {
            get
            {
                if (_exceptions == null)
                {
                    using (var db = new ShiftContext())
                    {
                        _exceptions = db.ShiftPlanExceptions.Where(ex => ex.ShiftPlanId == this.Id).ToList();
                    }
                }
                return _exceptions;
            }
            
        }
    }
    public class ShiftPlanException
    {
        public int Id { get; set; }
        public int ShiftPlanId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime? StartDate { get; set; }//如果周末和假日设定为false，那么开始结束日期生效
        public DateTime? EndDate { get; set; }
        
        public Boolean UsedToWeekend { get; set; } //true=这条规则适应所有周末
        public Boolean UsedToHoliday { get; set; }//true=这条规则使用法定假日，优先级高于周末
        public TimeSpan? BeginTime { get; set; }
        public TimeSpan? EndTime { get; set; }

    }
}
