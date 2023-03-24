using EmployeeManagement.Controllers;
using EmployeeManagement.Events;
using EmployeeManagement.Model;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Logger;
using EmployeeManagement.Services.MessageBus;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagementTests
{
    public class IntegrationTests
    {
        [Fact]
        public async void Employee_Promotion_Should_Succeed()
        {
            // Arrange
            var promotionDto = new PromotionForCreationDto { EmployeeId = 1 };

            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(e => e.FetchInternalEmployeeAsync(It.IsAny<int>())).ReturnsAsync(new InternalEmployee { EmployeeId = 1});
            
            var promotionServiceMock = new Mock<IPromotionService>();
            promotionServiceMock.Setup(p => p.PromoteInternalEmployeeAsync(It.IsAny<InternalEmployee>()))
                .ReturnsAsync(new Result { 
                    Success = true, 
                    Employee = new InternalEmployee { EmployeeId = 1, JobLevel = 2, Events = new List<IEvent> { new EmployeePromotionEvent(1, 1, 2) }}});

            var messageBusMock = new Mock<IMessageBus>();
            var loggerMock = new Mock<IDomainLogger>();

            var sut = new PromotionsController(
                employeeServiceMock.Object, promotionServiceMock.Object, messageBusMock.Object, loggerMock.Object);

            // Act
            var result = await sut.CreatePromotion(promotionDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            promotionServiceMock.Verify(x => x.PromoteInternalEmployeeAsync(It.IsAny<InternalEmployee>()), Times.Once);

            PromotionResultDto value = (PromotionResultDto)((OkObjectResult)result).Value;
            Assert.Equal(1, value.EmployeeId);
            Assert.Equal(2, value.JobLevel);

            messageBusMock.Verify(x => x.SendMessage(1, 2), Times.Once);
        }
    }
}