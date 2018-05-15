using System.Linq;
using System.Windows.Forms;

namespace MBG.Extensions.Controls
{
    public static class TreeViewExtensions
    {
        #region TreeView

        public static TreeNode GetNodeByName(this TreeView treeView, string nodeName)
        {
            return (from x in treeView.Nodes.Cast<TreeNode>()
                    where x.Name == nodeName
                    select x).SingleOrDefault();
        }
        public static TreeNode GetNodeByFullPath(this TreeView treeView, string path)
        {
            return (from x in treeView.Nodes.Cast<TreeNode>()
                    where x.FullPath == path
                    select x).SingleOrDefault();
        }
        public static TreeNode GetNodeByText(this TreeView treeView, string nodeText)
        {
            return (from x in treeView.Nodes.Cast<TreeNode>()
                    where x.Text == nodeText
                    select x).SingleOrDefault();
        }

        #endregion

        #region TreeNode

        public static TreeNode GetNodeByText(this TreeNode treeNode, string nodeText)
        {
            return (from x in treeNode.Nodes.Cast<TreeNode>()
                    where x.Text == nodeText
                    select x).SingleOrDefault();
        }

        #endregion
    }
}