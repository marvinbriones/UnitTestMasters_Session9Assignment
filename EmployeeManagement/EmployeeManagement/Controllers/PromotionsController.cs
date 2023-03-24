using EmployeeManagement.Events;
using EmployeeManagement.Model;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Logger;
using EmployeeManagement.Services.MessageBus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class PromotionsController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPromotionService _promotionService;
        private readonly EventDispatcher _eventDispatcher;

        public PromotionsController(IEmployeeService employeeService, 
            IPromotionService promotionService, 
            IMessageBus messageBus,
            IDomainLogger domainLogger)
        {
            _employeeService = employeeService;
            _promotionService = promotionService;
            _eventDispatcher = new EventDispatcher(messageBus, domainLogger);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionForCreationDto promotionForCreation)
        {
            var internalEmployeeToPromote = await _employeeService
                .FetchInternalEmployeeAsync(promotionForCreation.EmployeeId);

            if (internalEmployeeToPromote == null)
            {
                return BadRequest();
            }

            var response = await _promotionService.PromoteInternalEmployeeAsync(internalEmployeeToPromote);
            if (response.Success)
            {
                _eventDispatcher.Dispatch(response.Employee.Events);
                return Ok(new PromotionResultDto()
                {
                    EmployeeId = response.Employee.EmployeeId,
                    JobLevel = response.Employee.JobLevel
                });
            }
            else
            {
                return BadRequest("Employee not eligible for promotion.");
            }
        }
    }
}
