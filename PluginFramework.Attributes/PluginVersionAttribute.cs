using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class PluginVersionAttribute : Attribute
    {
        public string VersionNumber { get; set; }

        public PluginVersionAttribute(string versionNumber)
        {
            this.VersionNumber = versionNumber;
        }
    }
}