using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PluginFramework.Interface;
using System.Xml.Linq;

namespace DemoFormPlugin
{
    public partial class Form1 : Form, IFormPlugin
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Plugins");
        }

        #region IFormPlugin Members

        public Form Content
        {
            get { return this; }
        }

        public ShowAs ShowAs
        {
            get { return ShowAs.Normal; }
        }

        #endregion

        #region IPlugin Members

        public string Title
        {
            get { return "DemoFormPlugin"; }
        }
        public string Description
        {
            get { return "Info about this plugin"; }
        }
        public string Group
        {
            get { return "TestGroup"; }
        }
        public string SubGroup
        {
            get { return "TestSubGroup"; }
        }

        private XElement configuration = new XElement("ThisFormConfig");
        public XElement Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }

        public string Icon
        {
            //get { return "C:\\Icons\\Folder.ico"; }
            get { return string.Empty; }
        }

        #endregion
    }
}