using Daenet.LLMPlugin.TestConsole.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.TestConsole.App.EmployeeServiceClient
{
    public class EmployeeServiceClient : IEmployeeServiceClient
    {
        private readonly EmployeeServiceClientConfig _config;

        public EmployeeServiceClient(EmployeeServiceClientConfig config)
        {
            _config = config;        
        }

        public async Task<int> GetUserIdFromNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserVacationInfo> GetVacationInfoForUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
