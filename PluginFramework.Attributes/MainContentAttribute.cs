using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class MainContentAttribute : Attribute
    {
        public string Content { get; set; }

        public MainContentAttribute(string mainContent)
        {
            this.Content = mainContent;
        }
    }
}