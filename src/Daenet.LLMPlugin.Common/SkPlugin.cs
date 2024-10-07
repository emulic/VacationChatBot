using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.LLMPlugin.Common
{

    /// <summary>
    /// Defines the plugin, which will be instantiated on request in context which reuires the plugin.
    /// </summary>
    public class SkPlugin
    {
        /// <summary>
        /// The name of the plugin. This is any name, which is unique inside appsettings.json
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The implementaiton of the plugin.
        /// </summary>
        public string? AssemblyQualifiedName { get; set; }

        /// <summary>
        /// Plugin's configuration.
        /// </summary>
        public Dictionary<string, object>? JsonConfiguration { get; set; }
        //public JsonValue JsonConfiguration { get; set; }

    }
}
