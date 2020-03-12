using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorCodesAndCategoriesWF.Views
{
    public interface IView
    {
        void SetTreeNodes(SortedSet<TreeNode> treeNodes);
    }
}
