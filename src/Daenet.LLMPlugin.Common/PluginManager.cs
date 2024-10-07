


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Daenet.LLMPlugin.Common
{
    /// <summary>
    /// Helps creation of plugin instances with corrresponding configuraiton.
    /// </summary>
    public class PluginManager
    {
        private readonly ILogger _logger;

        private readonly PluginLibrary _pluginLib;

        private readonly IPlugInProvider _pluginProvider;

        /// <summary>
        /// Loads all plugins specified in the configuration section 'Plugins'.
        /// </summary>
        /// <param name="serviceProvider">Th service provider responsible for creating the instance of the service.</param>  
        /// <param name="pluginLib">The list of plugins to be created.</param>
        /// <param name="logger"></param>
        public PluginManager(IPlugInProvider pluginProvider, PluginLibrary pluginLib, ILogger<PluginManager> logger)
        {
            _pluginProvider = pluginProvider;
            _logger = logger;
            _pluginLib = pluginLib;
        }

        /// <summary>
        /// Creates the instances of plugins for the given configuration. The dependencies are resolved by the service provider and the plugin config is resolved from appsettings.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        /// <param name="config"></param>
        public List<object> CreateRequiredPlugins(List<string> pluginNames = null)
        {
            List<object> pluginInstances = new List<object>();

            if (pluginNames != null && pluginNames.Count == 0)
            {
                //
                // Traverses the list fo specified plugins.
                foreach (var pluginName in pluginNames)
                {
                    var plugin = _pluginLib.Plugins.FirstOrDefault(p => p.Name == pluginName);
                    if (plugin != null)
                    {
                        var inst = _pluginProvider.CreatePluginInstance(pluginName, plugin);
                        if (inst != null)
                            pluginInstances.Add(inst);
                    }
                    else
                        _logger.LogWarning($"The plugin '{pluginName}' is not found in the plugin library.");
                }
            }
            else
            {
                foreach (var plugin in _pluginLib.Plugins)
                {
                    var inst = _pluginProvider.CreatePluginInstance(plugin.Name!, plugin);
                    if (inst != null)
                        pluginInstances.Add(inst);
                }
            }

            return pluginInstances!;
        }



    }
}
