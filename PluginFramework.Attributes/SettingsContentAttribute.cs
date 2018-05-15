using System;

namespace PluginFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class SettingsContentAttribute : Attribute
    {
        public string Content { get; set; }

        public SettingsContentAttribute(string settingsContent)
        {
            this.Content = settingsContent;
        }
    }
}