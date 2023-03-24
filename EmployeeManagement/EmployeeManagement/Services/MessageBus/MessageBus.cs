using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IBus _bus;

        public void SendMessage(int employeeId, int newJobLevel)
        {
            _bus.Send("Type: EMPLOYEE JOB LEVEL CHANGED; " +
                $"Id: {employeeId}; " +
                $"NewJobLevel: {newJobLevel}");
        }
    }
}
