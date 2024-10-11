using Daenet.EmbeddingSearchApi.Interfaces;
using Daenet.EmbeddingSearchApi.Services;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.TestConsole.App.Plugin2
{
    public class RagPlugin
    {
        private readonly RagPluginConfig _config;
        private readonly ISearchApi _sApi;

        public RagPlugin(RagPluginConfig config, ISearchApi searchApi)
        {
            _config = config;
            _sApi = searchApi;
        }

        [KernelFunction]
        [Description("Urlaub buchen.")]
        public string VacationBooking()
        {
            return "Urlaub kann nicht gebucht werden, weil viele deiner Kollegen in diesem Period abwesend sind.";
        }

        [KernelFunction]
        [Description("Berechnet Umsatz aus gegebenen monat")]
        public int RevenueNumbers(int monat)
        {
            return 1000;
        }


    }
}
