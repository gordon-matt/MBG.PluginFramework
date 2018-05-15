using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MBG.Extensions.Core;
using PluginFramework.Attributes;
using PluginFramework.Interface;

namespace PluginFramework.Utilities
{
    public static class PluginHelper
    {
        private static string pluginsDirectory = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        public static string PluginsDirectory
        {
            get { return pluginsDirectory; }
            set { pluginsDirectory = value; }
        }

        /// <summary>
        /// Returns a new plugin and the assembly location.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static PluginInfo AddPlugin(string file)
        {
            Assembly assembly = Assembly.LoadFile(file);

            //PluginVersionAttribute version = (PluginVersionAttribute)Attribute.GetCustomAttribute(assembly,
            //    typeof(PluginVersionAttribute));
            //if (version != null && version.VersonNumber == "1.0.0")
            //{
            MainContentAttribute contentAttribute = (MainContentAttribute)Attribute.GetCustomAttribute(assembly,
                typeof(MainContentAttribute));
            IPlugin plugin = (IPlugin)assembly.CreateInstance(contentAttribute.Content, true);

            PluginInfo pluginInfo = new PluginInfo();
            pluginInfo.AssemblyPath = file;
            pluginInfo.Plugin = plugin;

            return pluginInfo;
            //}
            //else
            //{
            //    return null;
            //    //txtDescription.Text = "You tried to load an unsupported assembly";
            //}
        }

        /// <summary>
        /// Creates a new instance of the plugin inside the specified assembly file
        /// </summary>
        /// <typeparam name="T">Form / UserControl</typeparam>
        /// <param name="assemblyFile">The assembly file to load</param>
        /// <returns></returns>
        public static T CreateNewInstance<T>(string assemblyFile)
        {
            Assembly assembly = Assembly.LoadFile(assemblyFile);

            MainContentAttribute contentAttribute = (MainContentAttribute)Attribute.GetCustomAttribute(assembly,
                    typeof(MainContentAttribute));
            T item = (T)assembly.CreateInstance(contentAttribute.Content, true);

            return item;
        }

        /// <summary>
        /// <para>Looks for plugins in the directory specified by the PluginsDirectory</para>
        /// <para>property</para>
        /// </summary>
        /// <returns>an IDictionary with plugin Title as the Key and Assembly path as the Value</returns>
        public static IDictionary<string, string> FindPlugins()
        {
            Dictionary<string, string> plugins = new Dictionary<string, string>();
            PluginInfo pluginInfo;
            foreach (string file in Directory.GetFiles(PluginsDirectory))
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension.In(".dll", ".exe"))
                {
                    try
                    {
                        pluginInfo = AddPlugin(file);
                        plugins.Add(pluginInfo.Plugin.Title, file);
                    }
                    catch
                    {
                    }
                }
            }

            return plugins;
        }
        /// <summary>
        /// Gets all plug-ins from the PluginDirectory
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, PluginInfo> GetPlugins()
        {
            Dictionary<string, PluginInfo> plugins = new Dictionary<string, PluginInfo>();
            PluginInfo pluginInfo;
            foreach (string file in Directory.GetFiles(PluginsDirectory))
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension.In(".dll", ".exe"))
                {
                    try
                    {
                        pluginInfo = AddPlugin(file);
                        plugins.Add(pluginInfo.Plugin.Title, pluginInfo);
                    }
                    catch
                    {
                    }
                }
            }

            return plugins;
        }
        /// <summary>
        /// Gets the specified plugins
        /// </summary>
        /// <param name="pluginsToLoad">List of assembly paths</param>
        /// <returns></returns>
        public static IDictionary<string, PluginInfo> GetPlugins(IEnumerable<string> pluginsToLoad)
        {
            Dictionary<string, PluginInfo> plugins = new Dictionary<string, PluginInfo>();
            PluginInfo pluginInfo;
            foreach (string file in pluginsToLoad)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension.In(".dll", ".exe"))
                {
                    try
                    {
                        pluginInfo = AddPlugin(file);
                        plugins.Add(pluginInfo.Plugin.Title, pluginInfo);
                    }
                    catch
                    {
                    }
                }
            }

            return plugins;
        }

        public static ISettingsPlugin GetSettingsPlugin(string assemblyFile)
        {
            Assembly assembly = Assembly.LoadFile(assemblyFile);

            SettingsContentAttribute contentAttribute = (SettingsContentAttribute)Attribute.GetCustomAttribute(
                assembly,
                typeof(SettingsContentAttribute));

            if (contentAttribute != null)
            {
                return (ISettingsPlugin)assembly.CreateInstance(contentAttribute.Content, true);
            }

            return null;
        }
    }
}