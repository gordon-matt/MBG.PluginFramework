using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginFramework.Interface
{
    public interface IUserControlPlugin: IPlugin
    {
        UserControl Content { get; }
    }
}