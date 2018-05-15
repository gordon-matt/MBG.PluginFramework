using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PluginFramework.Interface
{
    public interface IPlugin
    {
        string Title { get; }
        string Description { get; }
        string Group { get; }
        string SubGroup { get; }
        XElement Configuration { get; set; }
        string Icon { get; }

        void Dispose();
    }
}