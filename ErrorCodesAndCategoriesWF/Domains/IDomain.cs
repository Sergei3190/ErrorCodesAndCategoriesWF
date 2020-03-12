using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorCodesAndCategoriesWF.Models;

namespace ErrorCodesAndCategoriesWF.Domains
{
    public interface IDomain
    {
        SortedSet<TreeNode> GetTreeNodes(List<Category> categories);
    }
}
