using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Events
{
    public class EmployeePromotionEvent : IEvent
    {
        public int EmployeeId { get; set; }
        public int OldJobLevel { get; set; }
        public int NewJobLevel { get; set; }
        public EmployeePromotionEvent(int employeeId, int oldJobLevel, int newJobLevel)
        {
            EmployeeId = employeeId;
            OldJobLevel = oldJobLevel;
            NewJobLevel = newJobLevel;
        }
    }
}
