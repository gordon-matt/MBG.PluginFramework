using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginFramework.Interface;
using System.Xml.Linq;

namespace DemoUserControlPlugin
{
    public partial class UserControl1 : UserControl, IUserControlPlugin
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked button 1!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked button 2!");
        }

        #region IUserControlPlugin Members

        public UserControl Content
        {
            get { return this; }
        }

        #endregion

        #region IPlugin Members

        public string Title
        {
            get { return "UserControlTest"; }
        }
        public string Description
        {
            get { return "Info about this user control plugin"; }
        }
        public string Group
        {
            get { return "UCGroup"; }
        }
        public string SubGroup
        {
            get { return "UCSubGroup"; }
        }

        private XElement configuration = new XElement("UCConfig");
        public XElement Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }

        public string Icon
        {
            //get { return "C:\\Icons\\Globe.ico"; }
            get { return string.Empty; }
        }

        #endregion
    }
}