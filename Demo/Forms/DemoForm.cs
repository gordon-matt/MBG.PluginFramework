using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginFramework.Interface;
using PluginFramework.Utilities;
using Demo.Properties;
using PluginFramework.Controls;

namespace Demo.Forms
{
    public partial class DemoForm : Form
    {
        private IDictionary<string, PluginInfo> plugins = null;

        public DemoForm()
        {
            InitializeComponent();
            PluginHelper.PluginsDirectory = Path.Combine(Application.StartupPath, "Plugins");
        }
        private void DemoForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(Settings.Default.PluginConfigFile))
            {
                AppContext.ConfigurationFile = ConfigurationFile.Load(Settings.Default.PluginConfigFile);
                LoadPlugins((from x in AppContext.ConfigurationFile.Startup.Plugins
                             select x.AssemblyPath).ToList());
            }
            else
            {
                AppContext.ConfigurationFile = new ConfigurationFile();
                AppContext.ConfigurationFile.Save(Settings.Default.PluginConfigFile);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (AppContext.ConfigurationFile.PluginConfiguration.Plugins != null)
            {
                foreach (KeyValuePair<string, PluginInfo> kv in plugins)
                {
                    PluginConfig config = AppContext.ConfigurationFile.PluginConfiguration.Plugins[kv.Key];
                    if (config == null)
                    {
                        config = new PluginConfig();
                        config.Title = kv.Key;
                        AppContext.ConfigurationFile.PluginConfiguration.Plugins.Add(config);
                    }

                    try
                    {
                        config.Configuration = kv.Value.Plugin.Configuration;
                    }
                    catch (NotImplementedException) { }
                }
            }

            AppContext.ConfigurationFile.Save(Settings.Default.PluginConfigFile);

            base.OnClosing(e);
        }

        private void LoadPlugins(IEnumerable<string> assemblyPaths)
        {
            plugins = PluginHelper.GetPlugins(assemblyPaths);
            try
            {
                plugins = plugins.OrderBy(g => g.Value.Plugin.Group)
                    .ThenBy(sg => sg.Value.Plugin.SubGroup)
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v => v.Value);
            }
            catch (NotImplementedException)
            {
                plugins = plugins.OrderBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
            }

            pluginMenuStrip.RemovePlugins();
            pluginTreeView.Nodes.Clear();

            foreach (PluginInfo pluginInfo in plugins.Values)
            {
                if (pluginInfo.Plugin is IFormPlugin)
                {
                    pluginMenuStrip.AddPlugin(pluginInfo);
                    pluginTreeView.AddPlugin(pluginInfo);
                }
                else if (pluginInfo.Plugin is IUserControlPlugin)
                {
                    pluginTreeView.AddPlugin(pluginInfo);
                }
            }
        }

        private void pluginTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            { return; }

            PluginInfo pluginInfo = e.Node.Tag as PluginInfo;

            if (pluginInfo.Plugin is IUserControlPlugin)
            {
                UserControl control = ((IUserControlPlugin)pluginInfo.Plugin).Content;
                splitContainer.Panel2.Controls.Clear();
                splitContainer.Panel2.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            }
            else if (pluginInfo.Plugin is IFormPlugin)
            {
                IFormPlugin formPlugin = (IFormPlugin)pluginInfo.Plugin;
                Form form = formPlugin.Content;

                if (form.IsDisposed)
                {
                    form = PluginHelper.CreateNewInstance<Form>(pluginInfo.AssemblyPath);
                }

                if (formPlugin.ShowAs == ShowAs.Dialog)
                {
                    form.ShowDialog();
                }
                else
                {
                    form.Show();
                }
            }
        }

        private void mnuToolsChoosePlugins_Click(object sender, EventArgs e)
        {
            AvailablePluginsForm form = new AvailablePluginsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPlugins(form.SelectedPlugins.Values);
            }
        }
        private void mnuToolsPluginSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(plugins);

            if (!form.IsDisposed)
            { form.ShowDialog(); }
        }
    }
}