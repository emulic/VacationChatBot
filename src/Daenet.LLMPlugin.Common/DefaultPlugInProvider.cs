using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.Common
{
    /// <summary>
    /// Implements the default provider, that creates instances of plugins of types loaded into the app domain.
    /// </summary>
    public class DefaultPlugInProvider : IPlugInProvider
    {
        private IServiceProvider _serviceProvider;

        ILogger<DefaultPlugInProvider> _logger;

        /// <summary>
        /// Creates the instance of the default plugin provider.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        public DefaultPlugInProvider(IServiceProvider serviceProvider, ILogger<DefaultPlugInProvider> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Creates the instance from materialized plugin type.
        /// </summary>
        /// <param name="pluginName"></param>
        /// <param name="plugin"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public object? CreatePluginInstance(string pluginName, SkPlugin plugin)
        {
            if (plugin != null)
            {
                if (plugin.AssemblyQualifiedName == null)
                    throw new ArgumentNullException($"The plugin {pluginName} is not properly configured. The AssemblyQualifiedName is missing.");

                var pluginType = Type.GetType(plugin.AssemblyQualifiedName);
                if (pluginType != null)
                {
                    Type? cfgType = GetPluginConfigType(pluginType!);
                    if (cfgType != null)
                    {
                        var jsonString = JsonSerializer.Serialize(plugin.JsonConfiguration);
                        object? cfgInst = JsonSerializer.Deserialize(jsonString, cfgType, new JsonSerializerOptions());

                        if (cfgInst != null)
                        {
                            var pluginInst = CreatePluginInstance(_serviceProvider, pluginType, cfgInst);
                            if (pluginInst != null)
                                return pluginInst;
                            else
                                _logger.LogWarning($"The instance of plugin '{pluginName}' with the type '{cfgType.Name}' cannot be created!");
                        }
                        else
                            _logger.LogWarning($"The configuration instance {cfgType.Name} for plugin {pluginType} cannot be created!");

                    }
                    else
                        _logger.LogWarning($"The plugin type {pluginType} cannot be loaded.");
                }
                else
                    _logger.LogWarning($"The plugin type {plugin.AssemblyQualifiedName} cannot be instantiated!");
            }
            else
                _logger.LogWarning($"The plugin with name {pluginName} cannot be found in the plugin library!.");

            return null;
        }

        /// <summary>
        /// Creates the instance of the plugin.
        /// </summary>
        /// <param name="pluginType"></param>
        /// <param name="cfgType"></param>
        /// <param name="cfgInst"></param>
        /// <returns></returns>
        private object? CreatePluginInstance(IServiceProvider serviceProvider, Type? pluginType, object cfgInst)
        {
            object? pluginInst = ActivatorUtilities.CreateInstance(serviceProvider, pluginType!, cfgInst);

            if (pluginInst != null)
            {
                return pluginInst;
            }
            else
                _logger.LogWarning($"The plugin instance {pluginType} cannot be created!");

            return null;
        }

        /// <summary>
        /// Resolves the type of the configuration of the plugin. The plugin type must be 
        /// sufixed with 'Config'. For example, if th eplugin type is called 'MyPlugin', then
        /// the configuration type of the plugin is 'MyPluginConfig'.
        /// </summary>
        /// <param name="pluginType">The type of the plugin.</param>
        /// <returns>The type or null.</returns>    
        private static Type? GetPluginConfigType(Type pluginType)
        {
            var assmName = pluginType.Assembly.GetName().Name;
            var cfgName = $"{pluginType.FullName}Config";

            var asmQualNameConfig = $"{cfgName},{assmName}";
            var cfgType = Type.GetType(asmQualNameConfig);

            return cfgType;
        }
    }
}
