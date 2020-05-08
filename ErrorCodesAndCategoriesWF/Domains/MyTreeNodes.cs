using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorCodesAndCategoriesWF.Models;

namespace ErrorCodesAndCategoriesWF.Domains
{
    public class MyTreeNodes : IDomain
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public SortedSet<TreeNode> GetTreeNodes(List<Category> categories)
        {
            Logger.Debug($"Cоздание узлов дерева для treeView");
            var treeNodes = new SortedSet<TreeNode>(new SortTreeNodeByText());
            foreach (var item in categories)
            {
                if (item.Parent == 0)
                {
                    treeNodes.Add(new TreeNode(item.Name, AddChildNodes(item.ID, categories)));
                }
            }
            return treeNodes;
        }

        private TreeNode[] AddChildNodes(int _id, List<Category> categories)
        {
            var child = new SortedSet<TreeNode>(new SortTreeNodeByText());
            foreach (var item in categories)
            {
                if (_id == item.Parent)
                {
                    child.Add(new TreeNode(item.Name, AddChildNodes(item.ID, categories)));
                }
            }
            return child.ToArray();
        }
    }
}
