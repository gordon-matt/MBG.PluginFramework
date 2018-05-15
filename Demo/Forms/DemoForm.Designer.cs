namespace Demo.Forms
{
    partial class DemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pluginMenuStrip = new PluginFramework.Controls.PluginMenuStrip();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsChoosePlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolPluginSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginTreeView = new PluginFramework.Controls.PluginTreeView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pluginMenuStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pluginMenuStrip
            // 
            this.pluginMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTools});
            this.pluginMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.pluginMenuStrip.Name = "pluginMenuStrip";
            this.pluginMenuStrip.Size = new System.Drawing.Size(806, 24);
            this.pluginMenuStrip.TabIndex = 0;
            this.pluginMenuStrip.Text = "pluginMenuStrip1";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsChoosePlugins,
            this.mnuToolPluginSettings});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuToolsChoosePlugins
            // 
            this.mnuToolsChoosePlugins.Name = "mnuToolsChoosePlugins";
            this.mnuToolsChoosePlugins.Size = new System.Drawing.Size(156, 22);
            this.mnuToolsChoosePlugins.Text = "Choose Plugins";
            this.mnuToolsChoosePlugins.Click += new System.EventHandler(this.mnuToolsChoosePlugins_Click);
            // 
            // mnuToolPluginSettings
            // 
            this.mnuToolPluginSettings.Name = "mnuToolPluginSettings";
            this.mnuToolPluginSettings.Size = new System.Drawing.Size(156, 22);
            this.mnuToolPluginSettings.Text = "Plugin Settings";
            this.mnuToolPluginSettings.Click += new System.EventHandler(this.mnuToolsPluginSettings_Click);
            // 
            // pluginTreeView
            // 
            this.pluginTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginTreeView.ImageIndex = 0;
            this.pluginTreeView.ImageListImageSize = new System.Drawing.Size(24, 24);
            this.pluginTreeView.ItemHeight = 32;
            this.pluginTreeView.Location = new System.Drawing.Point(0, 0);
            this.pluginTreeView.Name = "pluginTreeView";
            this.pluginTreeView.SelectedImageIndex = 0;
            this.pluginTreeView.Size = new System.Drawing.Size(218, 427);
            this.pluginTreeView.TabIndex = 1;
            this.pluginTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pluginTreeView_AfterSelect);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pluginTreeView);
            this.splitContainer.Size = new System.Drawing.Size(806, 427);
            this.splitContainer.SplitterDistance = 218;
            this.splitContainer.TabIndex = 2;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 451);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pluginMenuStrip);
            this.MainMenuStrip = this.pluginMenuStrip;
            this.Name = "DemoForm";
            this.Text = "PluginDemo";
            this.Load += new System.EventHandler(this.DemoForm_Load);
            this.pluginMenuStrip.ResumeLayout(false);
            this.pluginMenuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PluginFramework.Controls.PluginMenuStrip pluginMenuStrip;
        private PluginFramework.Controls.PluginTreeView pluginTreeView;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsChoosePlugins;
        private System.Windows.Forms.ToolStripMenuItem mnuToolPluginSettings;
    }
}

