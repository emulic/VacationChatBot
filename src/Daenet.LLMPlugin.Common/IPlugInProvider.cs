using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.Common
{
    /// <summary>
    /// Defines the interface for cretion of instances of plugins.
    /// </summary>
    public interface IPlugInProvider
    {
        /// <summary>
        /// Creates an instance of the plugin.
        /// </summary>
        /// <param name="pluginName">The name of the plugin.</param>
        /// <param name="plugin">The plugin info class, that describes the plugin configuraiton.</param>
        /// <returns>The instance of the plugin.</returns>
        object? CreatePluginInstance(string pluginName, SkPlugin plugin);
      
    }
}
