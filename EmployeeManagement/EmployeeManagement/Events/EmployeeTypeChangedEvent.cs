using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Events
{
    public class EmployeeTypeChangedEvent : IEvent
    {
        public int EmployeeId { get; set; }
        public int OldType { get; set; }
        public int NewType { get; set; }
        public EmployeeTypeChangedEvent(int employeeId, int oldType, int newType)
        {
            EmployeeId = employeeId;
            OldType = oldType;
            NewType = newType;
        }
    }
}
