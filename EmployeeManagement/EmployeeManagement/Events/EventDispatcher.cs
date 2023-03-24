using EmployeeManagement.Services.Logger;
using EmployeeManagement.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Events
{
    public class EventDispatcher
    {
        private readonly IMessageBus _messageBus;
        private readonly IDomainLogger _domainLogger;

        public EventDispatcher(
            IMessageBus messageBus,
            IDomainLogger domainLogger)
        {
            _domainLogger = domainLogger;
            _messageBus = messageBus;
        }

        public void Dispatch(List<IEvent> events)
        {
            foreach (IEvent ev in events)
            {
                Dispatch(ev);
            }
        }

        private void Dispatch(IEvent ev)
        {
            switch (ev)
            {
                case EmployeePromotionEvent employeePromotionEvent:
                    _messageBus.SendMessage(
                        employeePromotionEvent.EmployeeId,
                        employeePromotionEvent.NewJobLevel);
                    break;

                case EmployeeTypeChangedEvent employeeTypeChangedEvent:
                    _domainLogger.EmployeeTypeHasChanged(
                        employeeTypeChangedEvent.EmployeeId,
                        employeeTypeChangedEvent.OldType,
                        employeeTypeChangedEvent.NewType);
                    break;
            }
        }
    }
}
