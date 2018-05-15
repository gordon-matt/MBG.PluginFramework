using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginFramework.Interface
{
    public enum ShowAs
    {
        Normal,
        Dialog
    }
    public interface IFormPlugin: IPlugin
    {
        Form Content { get; }
        ShowAs ShowAs { get; }
    }
}