using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MBG.Extensions.Core;
using PluginFramework.Interface;
using PluginFramework.Utilities;

namespace PluginFramework.Controls
{
    public class PluginMenuStrip : MenuStrip
    {
        private List<string> pluginItems = new List<string>();

        public void AddPlugin(PluginInfo pluginInfo)
        {
            #region Main Plugin Node

            ToolStripMenuItem pluginItem = new ToolStripMenuItem(pluginInfo.Plugin.Title);
            pluginItem.Tag = pluginInfo;

            try
            {
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.Icon))
                {
                    pluginItem.Image = Image.FromFile(pluginInfo.Plugin.Icon);
                }
            }
            catch (NotImplementedException) { } // No icon

            if (pluginInfo.Plugin is IFormPlugin)
            {
                pluginItem.Click += new EventHandler(pluginItem_Click);
            }

            #endregion

            ToolStripMenuItem subGroup = null;
            try
            {
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.SubGroup))
                {
                    subGroup = new ToolStripMenuItem(pluginInfo.Plugin.SubGroup);
                    subGroup.DropDownItems.Add(pluginItem);
                }
            }
            catch (NotImplementedException)
            {
                // Do nothing (check for main group next)
            }

            ToolStripMenuItem group = null;
            try
            {
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.Group))
                {
                    group = new ToolStripMenuItem(pluginInfo.Plugin.Group);

                    if (subGroup != null)
                    {
                        group.DropDownItems.Add(subGroup);
                    }
                    else { group.DropDownItems.Add(pluginItem); }
                    //this.Items.Add(group);
                    EnsureItem(group);
                    pluginItems.Add(pluginInfo.Plugin.Group);
                }
            }
            catch (NotImplementedException)
            {
                if (subGroup != null)
                {
                    this.Items.Add(subGroup);
                    pluginItems.Add(pluginInfo.Plugin.SubGroup);
                }
                else
                {
                    this.Items.Add(pluginItem);
                    pluginItems.Add(pluginInfo.Plugin.Title);
                }
                return;
            }

            if (group == null && subGroup == null)
            {
                this.Items.Add(pluginItem);
                pluginItems.Add(pluginInfo.Plugin.Title);
            }
        }
        private ToolStripMenuItem EnsureItem(ToolStripMenuItem menuItem)
        {
            ToolStripMenuItem item = (from x in this.Items.Cast<ToolStripMenuItem>()
                                      where x.Text == menuItem.Text
                                      select x).SingleOrDefault();

            if (item == null)
            {
                this.Items.Add(menuItem);
                return menuItem;
            }
            else
            {
                foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
                { item.DropDownItems.Add(subItem); }
                return item;
            }
        }
        public void RemovePlugins()
        {
            foreach (string item in pluginItems)
            {
                this.Items.RemoveByKey(item);
            }
        }

        void pluginItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            PluginInfo pluginInfo = menuItem.Tag as PluginInfo;
            IFormPlugin plugin = pluginInfo.Plugin as IFormPlugin;
            Form form = plugin.Content;

            if (form.IsDisposed)
            {
                form = PluginHelper.CreateNewInstance<Form>(pluginInfo.AssemblyPath);
            }

            if (plugin.ShowAs == ShowAs.Dialog)
            {
                form.ShowDialog();
            }
            else
            {
                form.Show();
            }
        }
    }
}