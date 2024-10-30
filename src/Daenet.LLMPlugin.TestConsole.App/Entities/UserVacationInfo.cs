using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.TestConsole.App.Entities
{
    public class UserVacationInfo
    {
        public int AvailableVacationDays { get; set; }
        public int RemainingVacationDays { get; set; }
        public int PendingDays { get; set; }
        public int VacationPerYear { get; set; }
    }
}
