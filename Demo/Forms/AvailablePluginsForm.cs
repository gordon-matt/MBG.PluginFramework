using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MBG.Extensions.Core;
using Demo.Properties;
using PluginFramework.Utilities;

namespace Demo.Forms
{
    public partial class AvailablePluginsForm : Form
    {
        private IDictionary<string, string> availablePlugins;
        public IDictionary<string, string> SelectedPlugins { get; private set; }

        public AvailablePluginsForm()
        {
            InitializeComponent();
        }
        private void AvailablePluginsForm_Load(object sender, EventArgs e)
        {
            availablePlugins = PluginHelper.FindPlugins();
            clbAvailablePlugins.Items.AddRange(availablePlugins.Keys.ToArray());

            SelectedPlugins = (from p in AppContext.ConfigurationFile.Startup.Plugins
                               select p).ToDictionary(key => key.Title, value => value.AssemblyPath);

            for (int i = 0; i < clbAvailablePlugins.Items.Count; i++)
            {
                if (clbAvailablePlugins.Items[i].ToString().In(SelectedPlugins.Keys))
                {
                    clbAvailablePlugins.SetItemChecked(i, true);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedPlugins = (from p in availablePlugins
                               where p.Key.In(clbAvailablePlugins.CheckedItems)
                               select p).ToDictionary(key => key.Key, value => value.Value);

            if (SelectedPlugins != null && SelectedPlugins.Count > 0)
            {
                AppContext.ConfigurationFile.Startup.Plugins.Clear();
                foreach (KeyValuePair<string, string> kv in SelectedPlugins)
                {
                    if (!AppContext.ConfigurationFile.Startup.Plugins.Contains(kv.Key))
                    {
                        StartupPlugin plugin = new StartupPlugin();
                        plugin.Title = kv.Key;
                        plugin.AssemblyPath = kv.Value;
                        AppContext.ConfigurationFile.Startup.Plugins.Add(plugin);
                    }
                }
            }

            AppContext.ConfigurationFile.Save(Settings.Default.PluginConfigFile);
        }
    }
}