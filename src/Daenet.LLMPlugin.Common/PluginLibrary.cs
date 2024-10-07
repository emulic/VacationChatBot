namespace Daenet.LLMPlugin.Common
{
    /// <summary>
    /// Defines the set of plugins that are used in the application.
    /// </summary>
    public class PluginLibrary
    {
        /// <summary>
        /// List of plugins.
        /// </summary>
        public List<SkPlugin> Plugins { get; set; } = new List<SkPlugin>();
    }

}
