using Daenet.LLMPlugin.TestConsole.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.TestConsole.App.EmployeeServiceClient
{
    public class EmployeeServiceClientMock : IEmployeeServiceClient
    {
        public async Task<int> GetUserIdFromNameAsync(string userName)
        {
            return 1;
        }

        public async Task<UserVacationInfo> GetVacationInfoForUserAsync(int userId)
        {
            return new UserVacationInfo
            {
                AvailableVacationDays = 10,
                PendingDays = 3,
                RemainingVacationDays = 15,
                VacationPerYear = 28
            };
        }
    }
}
