using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCodesAndCategoriesWF.Domains
{
    public class SortTreeNodeByText : IComparer<TreeNode>
    {
        int IComparer<TreeNode>.Compare(TreeNode x, TreeNode y) => x.Text.CompareTo(y.Text);
    }
}
