using EmployeeManagement.Events;
using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly HttpClient _httpClient;
        private readonly IEmployeeRepository _employeeManagementRepository;
        public PromotionService(HttpClient httpClient, IEmployeeRepository employeeManagementRepository)
        {
            _httpClient = httpClient;
            _employeeManagementRepository = employeeManagementRepository;
        }

        public async Task<Result> PromoteInternalEmployeeAsync(InternalEmployee employee)
        {
            var result = new Result { Success = false };
            if (await CheckIfInternalEmployeeIsEligibleForPromotion(employee.EmployeeId))
            {
                int newJobLevel = employee.JobLevel++;
                employee.Events.Add(new EmployeePromotionEvent(employee.EmployeeId, employee.JobLevel, newJobLevel));
                await _employeeManagementRepository.SaveChangesAsync();
                result.Success = true;
                result.Employee = employee;
            }
            return result;
        }

        private async Task<bool> CheckIfInternalEmployeeIsEligibleForPromotion(
            int employeeId)
        {
            // call into API
            var apiRoot = "http://localhost:5057";

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{apiRoot}/api/promotioneligibilities/{employeeId}");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // deserialize content
            var content = await response.Content.ReadAsStringAsync();
            var promotionEligibility = JsonSerializer.Deserialize<PromotionEligibility>(content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            // return value
            return promotionEligibility == null ?
                false : promotionEligibility.EligibleForPromotion;
        }
    }
}
