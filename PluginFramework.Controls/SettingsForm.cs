using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginFramework.Interface;
using PluginFramework.Utilities;

namespace PluginFramework.Controls
{
    public partial class SettingsForm : Form
    {
        private IDictionary<string, PluginInfo> plugins = null;
        private Dictionary<string, ISettingsPlugin> settingsPlugins = new Dictionary<string, ISettingsPlugin>();
        private ImageList imageList = new ImageList();

        public SettingsForm(IDictionary<string, PluginInfo> plugins)
        {
            InitializeComponent();

            this.plugins = plugins;
            LoadSettings();

            if (settingsPlugins.Count == 0)
            {
                MessageBox.Show(
                    "None of the plugins have any settings to configure",
                    "No Settings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.Dispose();
            }
        }

        private void LoadSettings()
        {
            foreach (KeyValuePair<string, PluginInfo> kv in plugins)
            {
                ISettingsPlugin settingsPlugin = PluginHelper.GetSettingsPlugin(kv.Value.AssemblyPath);
                if (settingsPlugin != null)
                {
                    settingsPlugins.Add(kv.Key, settingsPlugin);
                }
            }

            foreach (KeyValuePair<string, ISettingsPlugin> kv in settingsPlugins)
            {
                pluginTreeView.AddSettingsPlugin(plugins[kv.Key], kv.Value);
            }
        }

        private void pluginTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            { return; }

            ISettingsPlugin settingsPlugin = e.Node.Tag as ISettingsPlugin;

            UserControl control = settingsPlugin.Content;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}