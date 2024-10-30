using Daenet.LLMPlugin.TestConsole.App.EmployeeServiceClient;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.TestConsole.App.Plugins.EmployeeService
{
    public class VacationPlugin
    {
        private readonly EmployeeServiceClientConfig _cfg;
        private readonly IEmployeeServiceClient _employeeServiceClient;

        public VacationPlugin(EmployeeServiceClientConfig cfg, IEmployeeServiceClient employeeServiceClient)
        {
            _cfg = cfg;
            _employeeServiceClient = employeeServiceClient;
        }

        [KernelFunction]
        [Description("Provides information how many vacation days an user has for specified year")]
        public async Task<string> GetUserVacationDays([Description("Name of the user")] string? user = null, [Description("Type of vacation days to get")] List<string> kindOfDaysToGet = null)
        {
            // If user is not defined, then get the current user
            if (string.IsNullOrWhiteSpace(user))
                user = GetCurrentUser();

            // If kind of days is not set, then get all kinds of known vacation days
            if (kindOfDaysToGet == null || kindOfDaysToGet.Count() == 0)
                kindOfDaysToGet = ["all"];

            // Get EmployeeService UserId from User Name
            var userId = await _employeeServiceClient.GetUserIdFromNameAsync(user);

            // Use EmployeeService RestApi to get the vacation days
            var vacationInfo = await _employeeServiceClient.GetVacationInfoForUserAsync(userId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Vacation days for the user {user}:");

            // If kind of days is not set, then get all kinds of known vacation days
            if (kindOfDaysToGet == null || kindOfDaysToGet.Count() == 0)
            {
                sb.AppendLine($"Vacation days per year: {vacationInfo.VacationPerYear}");
                sb.AppendLine($"Available vacation days: {vacationInfo.AvailableVacationDays}");
                sb.AppendLine($"Remaining vacation days: {vacationInfo.RemainingVacationDays}");
                sb.AppendLine($"Pending vacation days: {vacationInfo.PendingDays}");
            }
            else
            {
                //if (kindOfDaysToGet.Contains(""))

            }
            return sb.ToString();
        }

        private object GetUserId(string? user)
        {
            return 1;
        }

        private string? GetCurrentUser()
        {
            return "Edin Mulic";
        }
    }
}
