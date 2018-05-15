using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginFramework.Interface;

namespace PluginFramework.Utilities
{
    public class PluginInfo
    {
        public IPlugin Plugin { get; set; }
        public string AssemblyPath { get; set; }
    }
}