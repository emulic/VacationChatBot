using Daenet.LLMPlugin.TestConsole.App.Entities;

namespace Daenet.LLMPlugin.TestConsole.App.EmployeeServiceClient
{
    public interface IEmployeeServiceClient
    {
        Task<int> GetUserIdFromNameAsync(string userName);
        Task<UserVacationInfo> GetVacationInfoForUserAsync(int userId);

    }
}