using Daenet.LLMPlugin.TestConsole.App.EmployeeServiceClient;
using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text;

namespace Daenet.LLMPlugin.TestConsole.App.Plugins.EmployeeService
{
    public class VacationPlugin
    {
        private readonly VacationPluginConfig _cfg;
        private readonly IEmployeeServiceClient _employeeServiceClient;

        public VacationPlugin(VacationPluginConfig cfg, IEmployeeServiceClient employeeServiceClient)
        {
            _cfg = cfg;
            _employeeServiceClient = employeeServiceClient;
        }

        [KernelFunction]
        [Description("Provides information how many vacation days an user has for specified year")]
        public async Task<string> GetUserVacationDays([Description("Name of the user")] string? user = null)
        {
            // If user is not defined, then get the current user
            if (string.IsNullOrWhiteSpace(user))
                user = GetCurrentUser();

            // Get EmployeeService UserId from User Name
            var userId = await _employeeServiceClient.GetUserIdFromNameAsync(user);

            // Use EmployeeService RestApi to get the vacation days
            var vacationInfo = await _employeeServiceClient.GetVacationInfoForUserAsync(userId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Vacation days for the user {user}:");

            sb.AppendLine($"Vacation days per year: {vacationInfo.VacationPerYear}");
            sb.AppendLine($"Available vacation days: {vacationInfo.AvailableVacationDays}");
            sb.AppendLine($"Pending vacation days: {vacationInfo.PendingDays}");
            
            return sb.ToString();
        }


        private string? GetCurrentUser()
        {
            return "Edin Mulic";
        }
    }
}
