using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using MBG.Extensions.Core;
using MBG.IO;

namespace PluginFramework.Utilities
{
    public class ConfigurationFile
    {
        public Startup Startup { get; set; }
        public PluginConfiguration PluginConfiguration { get; set; }

        public ConfigurationFile()
        {
            Startup = new Startup();
            PluginConfiguration = new PluginConfiguration();
        }

        public static ConfigurationFile Load(string filePath)
        {
            return FlatFile.ReadFile(filePath).XmlDeserialize<ConfigurationFile>();
        }
        public void Save(string filePath)
        {
            this.XmlSerialize(filePath);
        }
    }

    public class Startup
    {
        [XmlElement(ElementName = "Plugin")]
        public StartupPluginCollection Plugins { get; set; }

        public Startup()
        {
            Plugins = new StartupPluginCollection();
        }
    }
    public class StartupPlugin
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "AssemblyPath")]
        public string AssemblyPath { get; set; }

        public StartupPlugin()
        {
            Title = string.Empty;
            AssemblyPath = string.Empty;
        }
    }
    public class StartupPluginCollection : List<StartupPlugin>
    {
        public StartupPlugin this[string title]
        {
            get { return this.SingleOrDefault(x => x.Title == title); }
        }
        public bool Contains(string title)
        {
            return this[title] != null;
        }
    }

    public class PluginConfiguration
    {
        [XmlElement(ElementName = "Plugin")]
        public PluginConfigCollection Plugins { get; set; }
    }

    public class PluginConfig
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "Configuration")]
        public XElement Configuration { get; set; }
    }
    public class PluginConfigCollection : List<PluginConfig>
    {
        public PluginConfig this[string title]
        {
            get { return this.SingleOrDefault(x => x.Title == title); }
        }
    }
}